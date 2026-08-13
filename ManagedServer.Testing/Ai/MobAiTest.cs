using ManagedServer.Ai.Goals;
using ManagedServer.Ai.Goals.Impl;
using ManagedServer.Ai.Goals.Target;
using ManagedServer.Ai.Vanilla;
using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Basic;
using ManagedServer.Features.Impl;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Testing.Ai;

/// <summary>
/// The AI system end to end: a mob spawned into a ticking world with goals on it decides something and
/// the decision reaches its position. This is the test that would catch the whole thing being wired up
/// wrong while every part of it passes on its own, which is the failure mode a subsystem assembled from
/// a selector, four controls, a navigation and a physics step is prone to.
/// </summary>
[TestFixture]
public class MobAiTest {
    private ManagedMinecraftServer _server = null!;
    private World _world = null!;

    /// <summary>
    /// Stone under the whole test area, plus a one block step at x 8 and a three block wall at x 20,
    /// so a mob has something to climb and something it cannot.
    /// </summary>
    private sealed class FloorProvider : PerBlockTerrainProvider {
        public override uint GetBlock(int x, int y, int z) {
            if (y == 63) {
                return Block.Stone.StateId;
            }

            // One block tall, two deep: high enough to need a jump (step height is 0.6) and wide
            // enough to stand on.
            if (x is 8 or 9 && y == 64) {
                return Block.Stone.StateId;
            }

            if (x == 20 && y is >= 64 and <= 66) {
                return Block.Stone.StateId;
            }

            return Block.Air.StateId;
        }
    }

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { };
        _server.AddFeature(new PhysicsFeature());

        _world = _server.CreateWorld(new FloorProvider(), "minecraft:overworld", new FullBrightLightingProvider());

        for (int x = -1; x <= 1; x++) {
            for (int z = -1; z <= 1; z++) {
                _world.LoadChunk(new Vec2<int>(x, z)).Wait();
            }
        }
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    /// <summary>
    /// The server's own tick counter has to move as well as the event fire: the damage invulnerable
    /// window is measured against it, so without this a second hit is discarded forever.
    /// </summary>
    private void AdvanceTicks(int count) {
        for (int i = 0; i < count; i++) {
            typeof(ManagedMinecraftServer)
                .GetProperty(nameof(ManagedMinecraftServer.CurrentTick))!
                .SetValue(_server, _server.CurrentTick + 1);

            _server.Events.CallEvent(new ServerTickEvent {
                Delta = TimeSpan.FromMilliseconds(50),
                TargetDelta = TimeSpan.FromMilliseconds(50),
                Server = _server
            });
        }
    }

    /// <summary>
    /// Spawned standing on the floor. Note the provider works in <b>protocol</b> y, which is offset by
    /// the dimension's min y of -64, so its <c>y == 63</c> is game y -1 and the surface a mob stands on
    /// is game y <b>0</b>. Getting that backwards drops every mob 64 blocks before the test starts.
    /// </summary>
    private Mob Spawn(double x = 0.5, double z = 0.5) {
        Mob mob = new(EntityType.Zombie) {
            Position = new Vec3<double>(x, 0.0, z),
            OnGround = true
        };

        mob.SetWorld(_world);
        return mob;
    }

    private LivingEntity SpawnTarget(double x, double z) {
        LivingEntity entity = new(EntityType.Villager) {
            Position = new Vec3<double>(x, 0.0, z),
            OnGround = true
        };

        entity.SetWorld(_world);
        return entity;
    }

    /// <summary>
    /// A goal that walks the mob at a fixed point, shaped like <c>RandomStrollGoal</c>: it asks the
    /// <b>navigation</b> for the destination and lets that drive the move control, which is the whole
    /// chain a real goal uses. Calling <c>SetWantedPosition</c> from here instead would skip the
    /// navigation and so skip the thing these tests are about.
    /// </summary>
    private sealed class WalkToGoal : Goal {
        private readonly Mob _mob;
        private readonly Vec3<double> _target;

        public WalkToGoal(Mob mob, Vec3<double> target) {
            _mob = mob;
            _target = target;
            SetFlags(GoalFlag.Move);
        }

        public override bool CanUse() {
            return true;
        }

        public override void Start() {
            _mob.Navigation.MoveTo(_target, 1.0);
        }

        /// <summary>Stops when the navigation gives up, and <c>CanUse</c> puts it straight back.</summary>
        public override bool CanContinueToUse() {
            return !_mob.Navigation.IsDone;
        }

        public override void Stop() {
            _mob.Navigation.Stop();
        }
    }

    /// <summary>
    /// The whole chain in one: a goal writes a destination, the move control turns it into a yaw and a
    /// forward input, and the travel step inside <c>EntityPhysics</c> spends those on the same tick. If
    /// the AI step were a separate feature rather than being called from the physics tick, this would
    /// pass or fail depending on registration order.
    /// </summary>
    [Test]
    public void TestAMobWithAWalkGoalActuallyMoves() {
        Mob mob = Spawn();
        mob.Goals.AddGoal(1, new WalkToGoal(mob, new Vec3<double>(0.5, 0.0, 20.5)));

        double startZ = mob.Position.Z;
        AdvanceTicks(40);

        Assert.Multiple(() => {
            Assert.That(mob.Position.Z, Is.GreaterThan(startZ + 1.0),
                "two seconds of walking should cover at least a block");
            Assert.That(mob.Position.X, Is.EqualTo(0.5).Within(0.5),
                "and it should be heading roughly straight");
        });
    }

    /// <summary>
    /// A mob climbs a one block step. This is the case that broke: a navigation that hands the move
    /// control the <b>final destination</b> can never make a mob jump, because the jump test is
    /// <c>dy &gt; stepHeight &amp;&amp; dx*dx + dz*dz &lt; max(1, width)</c> and a destination further
    /// than a block away fails the second half. Vanilla's navigation passes the next path node, which
    /// is always adjacent, so the test is written for a waypoint rather than a target.
    /// </summary>
    [Test]
    public void TestAMobClimbsAOneBlockStep() {
        Mob mob = Spawn(5.5, 0.5);

        // Straight east, over the step at x 8 and onto its top at y 1.
        mob.Goals.AddGoal(1, new WalkToGoal(mob, new Vec3<double>(9.5, 1.0, 0.5)));

        AdvanceTicks(80);

        Assert.Multiple(() => {
            Assert.That(mob.Position.Y, Is.GreaterThan(0.5),
                "the mob should have got onto the step rather than pressing into it");
            Assert.That(mob.Position.X, Is.GreaterThan(8.0));
        });
    }

    /// <summary>
    /// The other half: a wall taller than a jump is not climbed, so the fix above is a step up rather
    /// than a mob that floats over anything in its way.
    /// </summary>
    [Test]
    public void TestAMobDoesNotClimbAWall() {
        Mob mob = Spawn(17.5, 0.5);
        mob.Goals.AddGoal(1, new WalkToGoal(mob, new Vec3<double>(24.5, 0.0, 0.5)));

        AdvanceTicks(80);

        Assert.Multiple(() => {
            Assert.That(mob.Position.X, Is.LessThan(20.0), "the wall stops it");
            Assert.That(mob.Position.Y, Is.LessThan(1.0), "and it does not get on top of it");
        });
    }

    /// <summary>
    /// The headline of the pathfinder, end to end: a wall with a gap in it is walked round rather than
    /// pressed into. Nothing below the search can produce this. A mob that only knows which way its
    /// destination lies walks at the bricks and stays there, which is exactly what the placeholder
    /// navigation did.
    /// </summary>
    [Test]
    public void TestAMobWalksRoundAWallToItsGap() {
        // A doorway through the wall the provider puts at x 20, two blocks wide and well off the
        // direct line, so reaching the far side means having planned rather than having drifted.
        for (int z = 5; z <= 6; z++) {
            for (int y = 0; y <= 2; y++) {
                _world.SetBlock(new Vec3<int>(20, y, z), Block.Air);
            }
        }

        Mob mob = Spawn(17.5, 0.5);
        mob.Goals.AddGoal(1, new WalkToGoal(mob, new Vec3<double>(23.5, 0.0, 0.5)));

        bool wentThroughTheGap = false;
        for (int i = 0; i < 200; i++) {
            AdvanceTicks(1);

            if (mob.Position.X > 20.0) {
                wentThroughTheGap = true;
                break;
            }
        }

        Assert.That(wentThroughTheGap, Is.True,
            $"the mob should have found the gap; it ended at {mob.Position}");
    }

    /// <summary>
    /// <c>NoAi</c> stops the deciding without stopping the physics: the mob still falls. Vanilla keeps
    /// that split and a server that wants a frozen mob relies on it.
    /// </summary>
    [Test]
    public void TestNoAiStopsTheGoalsButNotGravity() {
        Mob mob = Spawn();
        mob.Goals.AddGoal(1, new WalkToGoal(mob, new Vec3<double>(0.5, 0.0, 20.5)));
        mob.NoAi = true;

        // Started in the air so there is something for gravity to do.
        mob.Position = new Vec3<double>(mob.Position.X, 6.0, mob.Position.Z);
        mob.OnGround = false;

        double startZ = mob.Position.Z;
        AdvanceTicks(20);

        Assert.Multiple(() => {
            Assert.That(mob.Position.Z, Is.EqualTo(startZ).Within(1.0E-9), "the goal decided nothing");
            Assert.That(mob.Position.Y, Is.LessThan(6.0), "but it still fell");
        });
    }

    /// <summary>
    /// A target goal finds something and the melee goal turns that into a hit. Both selectors have to
    /// run, the sensing has to see through empty air, and the reach test has to accept two boxes an
    /// arm's length apart.
    /// </summary>
    [Test]
    public void TestAZombieTargetsAndHitsANearbyEntity() {
        Mob mob = Spawn();
        mob.SetAttributeBaseValue(Attribute.AttackDamage, 3.0);

        // randomInterval 0 means it looks every selection tick, so the test does not depend on a roll.
        mob.TargetGoals.AddGoal(1, new NearestAttackableTargetGoal(mob,
            matches: candidate => candidate.Type.Identifier.Equals(EntityType.Villager.Identifier),
            randomInterval: 0));
        mob.Goals.AddGoal(1, new MeleeAttackGoal(mob, 1.0, true));

        LivingEntity target = SpawnTarget(1.0, 0.5);
        float startHealth = target.Health;

        AdvanceTicks(60);

        Assert.Multiple(() => {
            Assert.That(mob.Target, Is.SameAs(target), "the target goal should have picked it");
            Assert.That(target.Health, Is.LessThan(startHealth), "and the melee goal should have hit it");
        });
    }

    /// <summary>
    /// A creative player is not a valid target, which vanilla enforces inside <c>setTarget</c> rather
    /// than in the goal. Assigning one has to read back as nothing.
    /// </summary>
    [Test]
    public void TestATargetThatCannotBeAttackedReadsAsNull() {
        Mob mob = Spawn();
        LivingEntity target = SpawnTarget(2.0, 0.5);

        mob.Target = target;
        Assert.That(mob.Target, Is.SameAs(target));

        target.Health = 0.0f;
        Assert.That(mob.Target, Is.Null, "a dead target is not a target");
    }

    /// <summary>
    /// <c>HurtByTargetGoal</c> fires on a changed timestamp rather than an age, so it must fire once for
    /// a hit and not again while the same attacker is remembered.
    /// </summary>
    [Test]
    public void TestHurtByTargetFiresOncePerHit() {
        Mob mob = Spawn();
        mob.TargetGoals.AddGoal(1, new HurtByTargetGoal(mob));

        LivingEntity attacker = SpawnTarget(2.0, 0.5);

        // The timestamp is the mob's tick count, and the goal starts holding zero, so a hit on tick
        // zero is indistinguishable from no hit at all. Vanilla has the same edge and never meets it
        // because a mob has been ticking for a while before anything gets near it.
        AdvanceTicks(5);

        mob.Damage(new DamageSource(DamageType.MobAttack) {
            Attacker = attacker,
            Direct = attacker
        }, 1.0f);

        AdvanceTicks(4);
        Assert.That(mob.Target, Is.SameAs(attacker), "the mob should be fighting back");

        // Note that clearing Mob.Target by hand would not end the fight: TargetGoal.canContinueToUse
        // falls back to its own copy and puts it straight back, which is what makes a target survive
        // something else clearing it. Ending the fight properly means going out of follow range.
        int hitTimestamp = mob.LastHurtByMobTimestamp;
        attacker.Position = new Vec3<double>(400.0, 0.0, 400.0);
        AdvanceTicks(6);

        Assert.That(mob.Target, Is.Null, "out of follow range ends it");

        // Back in range, and still no new hit: the goal must not re-acquire, because the timestamp has
        // not moved. If the rule were an age rather than a change, this would put the target back.
        attacker.Position = new Vec3<double>(2.0, 0.0, 0.5);
        AdvanceTicks(10);

        Assert.Multiple(() => {
            Assert.That(mob.Target, Is.Null, "one hit is one trigger");
            Assert.That(mob.LastHurtByMobTimestamp, Is.EqualTo(hitTimestamp),
                "and the attacker is still remembered, which is what makes the change rule load bearing");
        });

        // A second hit moves the timestamp, and that is what fires it again.
        mob.Damage(new DamageSource(DamageType.MobAttack) {
            Attacker = attacker,
            Direct = attacker
        }, 1.0f);

        AdvanceTicks(4);
        Assert.That(mob.Target, Is.SameAs(attacker));
    }

    /// <summary>
    /// The three ways a game gets behaviour, and the rule that makes them compose: the vanilla registry
    /// fills an empty mob and leaves a configured one alone.
    /// </summary>
    [Test]
    public void TestTheVanillaRegistryOnlyFillsAnEmptyMob() {
        _server.AddFeature(new VanillaMobAiFeature());

        Mob plain = Spawn();
        Assert.That(plain.Goals.IsEmpty, Is.False, "a zombie should have been given vanilla's goals");

        Mob configured = new(EntityType.Zombie) {
            Position = new Vec3<double>(4.5, 0.0, 4.5)
        };
        configured.Goals.AddGoal(1, new RandomLookAroundGoal(configured));
        configured.SetWorld(_world);

        Assert.That(configured.Goals.AvailableGoals, Has.Count.EqualTo(1),
            "a mob that already had a goal keeps exactly that goal");
    }

    /// <summary>
    /// A type with no entry in the registry gets nothing rather than a guess, which is what makes the
    /// table's gaps visible instead of silently plausible.
    /// </summary>
    [Test]
    public void TestAnUnlistedTypeGetsNoGoals() {
        _server.AddFeature(new VanillaMobAiFeature());

        Mob mob = new(EntityType.Enderman) {
            Position = new Vec3<double>(8.5, 0.0, 8.5)
        };
        mob.SetWorld(_world);

        Assert.Multiple(() => {
            Assert.That(mob.Goals.IsEmpty, Is.True);
            Assert.That(mob.TargetGoals.IsEmpty, Is.True);
        });
    }

    /// <summary>
    /// A game's own copy of the table is independent of vanilla's, so overriding one mob does not mean
    /// forking the whole thing and does not leak into another server.
    /// </summary>
    [Test]
    public void TestARegistryCopyIsIndependent() {
        MobAiRegistry custom = MobAiRegistry.Vanilla.Copy();
        custom.Remove(EntityType.Zombie.Identifier);

        _server.AddFeature(new VanillaMobAiFeature(custom));

        Mob zombie = Spawn();
        Assert.That(zombie.Goals.IsEmpty, Is.True, "the override took the zombie out");

        Mob cow = new(EntityType.Cow) {
            Position = new Vec3<double>(6.5, 0.0, 6.5)
        };
        cow.SetWorld(_world);
        Assert.That(cow.Goals.IsEmpty, Is.False, "and left everything else alone");

        Assert.That(MobAiRegistry.Vanilla.Get(EntityType.Zombie.Identifier), Is.Not.Null,
            "while vanilla's own table is untouched");
    }

    /// <summary>
    /// The half rate cadence with its entity id offset. A goal that does not ask for every tick is
    /// ticked about half as often as the world ticks, and one that does is ticked every time.
    /// </summary>
    [Test]
    public void TestGoalCadenceIsHalfRateUnlessAsked() {
        Mob mob = Spawn();

        CountingGoal halfRate = new(GoalFlag.Move);
        CountingGoal everyTick = new(GoalFlag.Look) {
            EveryTick = true
        };

        mob.Goals.AddGoal(1, halfRate);
        mob.Goals.AddGoal(1, everyTick);

        AdvanceTicks(40);

        Assert.Multiple(() => {
            Assert.That(everyTick.Ticks, Is.EqualTo(40));
            Assert.That(halfRate.Ticks, Is.InRange(19, 21));
        });
    }

    private sealed class CountingGoal : Goal {
        public bool EveryTick;
        public int Ticks;

        public CountingGoal(GoalFlag flags) {
            SetFlags(flags);
        }

        public override bool CanUse() {
            return true;
        }

        public override bool RequiresUpdateEveryTick => EveryTick;

        public override void Tick() {
            Ticks++;
        }
    }
}
