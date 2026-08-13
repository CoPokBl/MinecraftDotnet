using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Impl;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Packets;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Damage;

/// <summary>
/// <see cref="ShieldFeature"/> against <c>LivingEntity.applyItemBlocking</c> and
/// <c>Player.blockUsingItem</c>.
/// <p/>
/// The two that matter most are the ones a feature written as a damage modifier could not get right:
/// a blocked hit leaves the invulnerable window measuring the damage that got <i>through</i> rather
/// than the swing, and a shield with its component removed blocks nothing at all.
/// </summary>
[TestFixture]
public class ShieldFeatureTest {
    /// <summary>A player needs one, and nothing here reads what was sent.</summary>
    private sealed class SilentConnection : PlayerConnection {
        protected override void SendPacketInternal(MinecraftPacket packet) { }
        public override void InitialiseEncryption() { }
        public override Task HandlePackets() => Task.CompletedTask;
        public override void Disconnect() { }
    }

    private ManagedMinecraftServer _server = null!;
    private World _world = null!;
    private ShieldFeature _shields = null!;
    private Player _player = null!;

    /// <summary>Where the shield's block delay ends: a quarter of a second.</summary>
    private const int BlockDelayTicks = 5;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { };
        _shields = new ShieldFeature();
        _server.AddFeature(_shields);

        _world = _server.CreateWorld(new VoidProvider(), "minecraft:overworld", new FullBrightLightingProvider());
        _world.LoadChunk(new Vec2<int>(0, 0)).Wait();

        _player = new Player(_server, new SilentConnection(), "tester") {
            Position = new Vec3<double>(8.5, 64, 8.5),
            Yaw = Angle.FromDegrees(0)  // facing +Z, so an attacker to the south is in front
        };
        _player.SetWorld(_world);
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    /// <summary>The block delay and the disable cooldown are counted in ticks, which nothing moves here.</summary>
    private void AdvanceTicks(int count) {
        typeof(ManagedMinecraftServer)
            .GetProperty(nameof(ManagedMinecraftServer.CurrentTick))!
            .SetValue(_server, _server.CurrentTick + (ulong)count);
    }

    /// <summary>Raises the given item the way a client does, and waits out the block delay.</summary>
    private void Raise(ItemStack shield, Hand hand = Hand.MainHand, bool waitOutDelay = true) {
        _player.SetItemInHand(hand, shield);
        _player.Events.CallEvent(new PlayerPacketHandleEvent {
            Player = _player,
            World = _world,
            Packet = new ServerBoundUseItemPacket {
                UsedHand = hand,
                Sequence = 1,
                Yaw = _player.Yaw.DegreesF,
                Pitch = _player.Pitch.DegreesF
            }
        });

        if (waitOutDelay) {
            AdvanceTicks(BlockDelayTicks);
        }
    }

    private void Release() {
        _player.Events.CallEvent(new PlayerPacketHandleEvent {
            Player = _player,
            World = _world,
            Packet = new ServerBoundPlayerActionPacket {
                ActionStatus = ServerBoundPlayerActionPacket.Status.UpdateHeldItem,
                Location = Vec3<int>.Zero,
                Face = BlockFace.PosY,
                Sequence = 1
            }
        });
    }

    /// <summary>An attacker standing <paramref name="dz"/> away on the Z axis, with a weapon.</summary>
    private DamageSource Attack(double dz, ItemStack? weapon = null) {
        return AttackFrom(new Vec3<double>(8.5, 64, 8.5 + dz), weapon);
    }

    private DamageSource AttackFrom(Vec3<double> position, ItemStack? weapon = null) {
        LivingEntity attacker = new(EntityType.Zombie) {
            Position = position
        };
        attacker.SetWorld(_world);

        return new DamageSource(DamageType.MobAttack) {
            Attacker = attacker,
            Direct = attacker,
            Weapon = weapon
        };
    }

    /// <summary>An attacker <paramref name="degrees"/> off the blocker's facing, at arm's length.</summary>
    private DamageSource AttackAtAngle(double degrees) {
        double radians = degrees * Math.PI / 180.0;
        return AttackFrom(_player.Position + new Vec3<double>(-Math.Sin(radians), 0, Math.Cos(radians)));
    }

    private static ItemStack Shield => new(Item.Shield);
    private static ItemStack Axe => new(Item.DiamondAxe);
    private static ItemStack Sword => new(Item.DiamondSword);

    [Test]
    public void TestRaisedShieldStopsAHitFromTheFront() {
        Raise(Shield);

        Assert.That(_player.Damage(Attack(4), 6f), Is.False, "a hit blocked whole did not happen");
        Assert.That(_player.Health, Is.EqualTo(20f));
    }

    [Test]
    public void TestHitFromBehindIsNotBlocked() {
        Raise(Shield);

        Assert.That(_player.Damage(Attack(-4), 6f), Is.True);
        Assert.That(_player.Health, Is.EqualTo(14f));
    }

    /// <summary>
    /// The edge of the ninety degree arc. Vanilla works the limit out as a float product and compares
    /// the double angle against it, and it reads the facing off its sine table rather than out of
    /// <see cref="Math.Sin"/>, so both sides of the boundary are decided by arithmetic that has to be
    /// the same arithmetic. Ninety exactly is inside it.
    /// </summary>
    [TestCase(0.0, true)]
    [TestCase(89.9, true)]
    [TestCase(90.0, true)]
    [TestCase(90.1, false)]
    [TestCase(180.0, false)]
    public void TestArcBoundary(double degrees, bool blocked) {
        Raise(Shield);

        Assert.That(_player.Damage(AttackAtAngle(degrees), 6f), Is.EqualTo(!blocked));
        Assert.That(_player.Health, Is.EqualTo(blocked ? 20f : 14f));
    }

    /// <summary>
    /// A hit from the entity's own position has no direction to compare, and vanilla's normalize gives
    /// up below a length of 1e-4 rather than at zero, which leaves the angle at exactly ninety degrees
    /// and so inside the arc.
    /// </summary>
    [Test]
    public void TestHitFromTheSamePositionIsBlocked() {
        Raise(Shield);

        Assert.That(_player.Damage(AttackFrom(_player.Position), 6f), Is.False);
        Assert.That(_player.Health, Is.EqualTo(20f));
    }

    /// <summary>An item with no <c>blocks_attacks</c> component cannot be blocked with.</summary>
    [Test]
    public void TestSwordDoesNotBlock() {
        Raise(Sword);

        _player.Damage(Attack(4), 6f);
        Assert.That(_player.Health, Is.EqualTo(14f));
    }

    /// <summary>
    /// The point of the cosmetic shield: the component is removed rather than the item replaced, so the
    /// client stops predicting a block too.
    /// </summary>
    [Test]
    public void TestShieldWithoutTheComponentBlocksNothing() {
        Raise(Shield.Without(DataComponent.BlocksAttacks));

        _player.Damage(Attack(4), 6f);
        Assert.That(_player.Health, Is.EqualTo(14f));
    }

    [Test]
    public void TestShieldRaisedInsideTheBlockDelayDoesNothing() {
        Raise(Shield, waitOutDelay: false);
        AdvanceTicks(BlockDelayTicks - 1);

        _player.Damage(Attack(4), 6f);
        Assert.That(_player.Health, Is.EqualTo(14f));
    }

    [Test]
    public void TestReleasingLowersTheShield() {
        Raise(Shield);
        Release();

        _player.Damage(Attack(4), 6f);
        Assert.That(_player.Health, Is.EqualTo(14f));
    }

    /// <summary>
    /// A second use packet for an item already up must not start the block delay over, which is what
    /// vanilla's <c>startUsingItem</c> avoids by returning early.
    /// </summary>
    [Test]
    public void TestRaisingAgainDoesNotRestartTheBlockDelay() {
        Raise(Shield);
        Raise(Shield, waitOutDelay: false);

        Assert.That(_player.Damage(Attack(4), 6f), Is.False);
        Assert.That(_player.Health, Is.EqualTo(20f));
    }

    [Test]
    public void TestShieldBlocksFromTheOffHand() {
        Raise(Shield, Hand.OffHand);

        Assert.That(_player.Damage(Attack(4), 6f), Is.False);
        Assert.That(_player.Health, Is.EqualTo(20f));
    }

    /// <summary>
    /// <c>bypassed_by</c> is <c>minecraft:bypasses_shield</c>, which holds everything in
    /// <c>bypasses_armor</c>, so a fall goes straight through a raised shield.
    /// </summary>
    [Test]
    public void TestFallDamageBypassesTheShield() {
        Raise(Shield);

        _player.Damage(new DamageSource(DamageType.Fall) { Position = _player.Position + new Vec3<double>(0, -1, 0) }, 6f);
        Assert.That(_player.Health, Is.EqualTo(14f));
    }

    /// <summary>
    /// What a modifier could not do. Vanilla subtracts the blocked damage before judging the window, so
    /// a hit that a shield ate whole leaves nothing behind for the next one to be measured against.
    /// </summary>
    [Test]
    public void TestBlockedHitLeavesTheWindowMeasuringWhatGotThrough() {
        Raise(Shield);
        Assert.That(_player.Damage(Attack(4), 10f), Is.False);

        // Two ticks later, well inside the ten tick window, and from behind so nothing blocks it.
        AdvanceTicks(2);
        Assert.That(_player.Damage(Attack(-4), 4f), Is.True);
        Assert.That(_player.Health, Is.EqualTo(16f));
    }

    /// <summary>
    /// A reduction that does not cover the whole hit, which is what a weaker shield is: half of it is
    /// blocked and the rest lands, so the hit happened.
    /// </summary>
    [Test]
    public void TestPartialBlockLetsTheRestThrough() {
        BlocksAttacksComponent.Data half = BlocksAttacksComponent.Data.Default with {
            DamageReductions = [new BlocksAttacksComponent.DamageReduction(90f, null, 0f, 0.5f)]
        };
        Raise(Shield.With(DataComponent.BlocksAttacks, half), waitOutDelay: false);

        Assert.That(_player.Damage(Attack(4), 6f), Is.True);
        Assert.That(_player.Health, Is.EqualTo(17f));
    }

    /// <summary>
    /// An axe carries <c>disable_blocking_for_seconds</c>, which is the whole of what "an axe breaks a
    /// shield" is: five seconds during which the shield cannot be raised again.
    /// </summary>
    [Test]
    public void TestAxeDisablesTheShield() {
        Raise(Shield);
        Assert.That(_player.Damage(Attack(4, Axe), 6f), Is.False, "the axe hit itself is still blocked");

        // Raising it again inside the cooldown does nothing, so the next hit lands whole.
        AdvanceTicks(10);
        Raise(Shield);
        Assert.That(_player.Damage(Attack(4, Axe), 6f), Is.True);
        Assert.That(_player.Health, Is.EqualTo(14f));

        // Five seconds after the disable the shield works again.
        AdvanceTicks(100);
        Raise(Shield);
        Assert.That(_player.Damage(Attack(4, Axe), 6f), Is.False);
        Assert.That(_player.Health, Is.EqualTo(14f));
    }

    [Test]
    public void TestSwordDoesNotDisableTheShield() {
        Raise(Shield);
        _player.Damage(Attack(4, Sword), 6f);

        AdvanceTicks(10);
        Assert.That(_player.Damage(Attack(4, Sword), 6f), Is.False);
        Assert.That(_player.Health, Is.EqualTo(20f));
    }

    /// <summary>
    /// A shield's <c>item_damage</c> is a threshold of three with a base of one and a factor of one, so
    /// a hit worth six costs seven durability and one worth less than three costs nothing at all.
    /// </summary>
    [TestCase(6f, 7)]
    [TestCase(2f, 0)]
    public void TestBlockingWearsTheShieldOut(float damage, int expected) {
        Raise(Shield);
        _player.Damage(Attack(4), damage);

        Assert.That(_player.HeldItem.GetStructOrNull(DataComponent.Damage) ?? 0, Is.EqualTo(expected));
    }

    [Test]
    public void TestDamageItemsOffLeavesTheShieldAlone() {
        _shields.DamageItems = false;
        Raise(Shield);

        _player.Damage(Attack(4), 6f);
        Assert.That(_player.HeldItem.GetStructOrNull(DataComponent.Damage) ?? 0, Is.EqualTo(0));
    }

    /// <summary>A shield worn out by blocking breaks, which also ends the block.</summary>
    [Test]
    public void TestShieldBreaksWhenItRunsOutOfDurability() {
        Raise(Shield.With(DataComponent.Damage, 335));  // one short of the shield's 336
        _player.Damage(Attack(4), 6f);

        Assert.That(_player.HeldItem.IsAir(), Is.True);

        AdvanceTicks(10);
        Assert.That(_player.Damage(Attack(4), 6f), Is.True, "a broken shield keeps blocking");
    }

    /// <summary>
    /// A mob blocks too. Nothing raises one on its own, so this is what <c>Mob.startUsingItem</c> would
    /// be called from, and the shield is equipment rather than an inventory slot.
    /// </summary>
    [Test]
    public void TestMobBlocksWhenToldTo() {
        LivingEntity zombie = SpawnZombie();
        zombie.SetEquipmentItem(EquipmentSlot.OffHand, Shield);
        _shields.StartBlocking(zombie, Hand.OffHand);
        AdvanceTicks(BlockDelayTicks);

        Assert.That(zombie.Damage(AttackOn(zombie, 4), 6f), Is.False);
        Assert.That(zombie.Health, Is.EqualTo(20f));

        ShieldFeature.StopBlocking(zombie);
        AdvanceTicks(10);
        Assert.That(zombie.Damage(AttackOn(zombie, 4), 6f), Is.True);
        Assert.That(zombie.Health, Is.EqualTo(14f));
    }

    /// <summary>
    /// Both of these are behind an <c>instanceof Player</c> upstream: <c>hurtBlockingItem</c> does
    /// nothing for anything else, and only <c>Player.blockUsingItem</c> reaches
    /// <c>BlocksAttacks.disable</c>. So an axe neither wears a mob's shield out nor knocks it aside.
    /// </summary>
    [Test]
    public void TestAxeNeitherDisablesNorWearsOutAMobsShield() {
        LivingEntity zombie = SpawnZombie();
        zombie.SetEquipmentItem(EquipmentSlot.MainHand, Shield);
        _shields.StartBlocking(zombie, Hand.MainHand);
        AdvanceTicks(BlockDelayTicks);

        Assert.That(zombie.Damage(AttackOn(zombie, 4, Axe), 6f), Is.False);
        Assert.That(zombie.GetEquipmentItem(EquipmentSlot.MainHand).GetStructOrNull(DataComponent.Damage) ?? 0,
            Is.EqualTo(0), "a mob's shield does not wear out");

        AdvanceTicks(10);
        Assert.That(zombie.Damage(AttackOn(zombie, 4, Axe), 6f), Is.False, "and it is not disabled either");
        Assert.That(zombie.Health, Is.EqualTo(20f));
    }

    private LivingEntity SpawnZombie() {
        LivingEntity zombie = new(EntityType.Zombie) {
            Position = new Vec3<double>(4.5, 64, 4.5),
            Yaw = Angle.FromDegrees(0)
        };
        zombie.SetWorld(_world);
        return zombie;
    }

    /// <summary>An attacker <paramref name="dz"/> away from <paramref name="target"/> on the Z axis.</summary>
    private DamageSource AttackOn(LivingEntity target, double dz, ItemStack? weapon = null) {
        return AttackFrom(target.Position + new Vec3<double>(0, 0, dz), weapon);
    }

    /// <summary>
    /// Only the shield's own damage types are blocked, which is what a shield built for one thing is.
    /// </summary>
    [Test]
    public void TestReductionScopedToADamageTypeIgnoresEverythingElse() {
        BlocksAttacksComponent.Data explosionsOnly = BlocksAttacksComponent.Data.Default with {
            DamageReductions = [
                new BlocksAttacksComponent.DamageReduction(90f, new Minecraft.Schemas.Tags.IdSet.Tag("minecraft:is_explosion"), 0f, 1f)
            ]
        };
        Raise(Shield.With(DataComponent.BlocksAttacks, explosionsOnly), waitOutDelay: false);

        Assert.That(_player.Damage(Attack(4), 6f), Is.True);
        Assert.That(_player.Health, Is.EqualTo(14f));

        AdvanceTicks(10);
        Assert.That(_player.Damage(new DamageSource(DamageType.Explosion) {
            Position = _player.Position + new Vec3<double>(0, 0, 4)
        }, 6f), Is.False);
        Assert.That(_player.Health, Is.EqualTo(14f));
    }
}
