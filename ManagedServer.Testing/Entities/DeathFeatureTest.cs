using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Basic;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Entities;

/// <summary>
/// <see cref="DeathFeature"/>, over the one thing it has to get right whatever took the health off: an
/// entity out of health is announced exactly once, and what happens to it afterwards is the listener's
/// to stop.
/// </summary>
[TestFixture]
public class DeathFeatureTest {
    private ManagedMinecraftServer _server = null!;
    private World _world = null!;
    private DeathFeature _feature = null!;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { };

        _feature = new DeathFeature();
        _server.AddFeature(_feature);

        _world = _server.CreateWorld(new VoidProvider(), "minecraft:overworld", new FullBrightLightingProvider());
        _world.LoadChunk(new Vec2<int>(0, 0)).Wait();
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    private LivingEntity Spawn() {
        LivingEntity entity = new(EntityType.Zombie) {
            Position = new Vec3<double>(8.5, 64, 8.5)
        };
        entity.SetWorld(_world);
        return entity;
    }

    /// <summary>The tick counter has to move as well as the event fire, or the scheduler never fires.</summary>
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

    [Test]
    public void TestRunningOutOfHealthAnnouncesDeath() {
        LivingEntity zombie = Spawn();
        List<EntityDeathEvent> deaths = [];
        _world.Events.AddListener<EntityDeathEvent>(e => deaths.Add(e));

        zombie.Health = 0;
        AdvanceTicks(1);

        Assert.That(deaths, Has.Count.EqualTo(1));
        Assert.That(deaths[0].LivingEntity, Is.SameAs(zombie));
        Assert.That(zombie.IsDead, Is.True);
    }

    /// <summary>An entity still on full health is nobody's death.</summary>
    [Test]
    public void TestLivingEntityIsNotAnnounced() {
        Spawn();
        int deaths = 0;
        _world.Events.AddListener<EntityDeathEvent>(_ => deaths++);

        AdvanceTicks(5);

        Assert.That(deaths, Is.Zero);
    }

    /// <summary>Vanilla leaves the body up for the animation, so the removal is a tick late by design.</summary>
    [Test]
    public void TestDeadEntityIsRemovedAfterTheAnimation() {
        LivingEntity zombie = Spawn();
        zombie.Health = 0;

        AdvanceTicks(_feature.RemoveAfterTicks);
        Assert.That(zombie.World, Is.SameAs(_world), "removed before the animation finished");

        AdvanceTicks(1);
        Assert.That(zombie.World, Is.Null);
        Assert.That(_world.Entities.GetEntities(), Does.Not.Contain(zombie));
    }

    [Test]
    public void TestZeroDelayRemovesInTheSameTick() {
        _feature.RemoveAfterTicks = 0;
        LivingEntity zombie = Spawn();
        zombie.Health = 0;

        AdvanceTicks(1);

        Assert.That(zombie.World, Is.Null);
    }

    /// <summary>Cancelling stops the removal and nothing else: the entity is still at zero health.</summary>
    [Test]
    public void TestCancellingKeepsTheEntity() {
        LivingEntity zombie = Spawn();
        _world.Events.AddListener<EntityDeathEvent>(e => e.Cancelled = true);

        zombie.Health = 0;
        AdvanceTicks(_feature.RemoveAfterTicks + 5);

        Assert.That(zombie.World, Is.SameAs(_world));
        Assert.That(zombie.IsDead, Is.True);
    }

    /// <summary>
    /// The reason <see cref="LivingEntity.IsDead"/> is set before the event rather than after it: a
    /// cancelled death leaves the entity sitting at zero health, and that must not be announced again on
    /// every tick that follows.
    /// </summary>
    [Test]
    public void TestCancelledDeathIsNotAnnouncedAgain() {
        LivingEntity zombie = Spawn();
        int deaths = 0;
        _world.Events.AddListener<EntityDeathEvent>(e => {
            deaths++;
            e.Cancelled = true;
        });

        zombie.Health = 0;
        AdvanceTicks(10);

        Assert.That(deaths, Is.EqualTo(1));
    }

    /// <summary>Healing is what puts the entity back in the running, whoever did it.</summary>
    [Test]
    public void TestHealingLetsTheEntityDieAgain() {
        LivingEntity zombie = Spawn();
        int deaths = 0;
        _world.Events.AddListener<EntityDeathEvent>(e => {
            deaths++;
            e.Cancelled = true;
        });

        zombie.Health = 0;
        AdvanceTicks(1);
        Assert.That(zombie.IsDead, Is.True);

        zombie.Heal();
        Assert.That(zombie.IsDead, Is.False);

        zombie.Health = 0;
        AdvanceTicks(1);

        Assert.That(deaths, Is.EqualTo(2));
    }

    /// <summary>
    /// A listener that heals the entity from inside the event has undone the death by the time the
    /// scheduled removal comes around, so the removal has to check again rather than trust the schedule.
    /// </summary>
    [Test]
    public void TestEntityHealedDuringTheAnimationIsNotRemoved() {
        LivingEntity zombie = Spawn();
        _world.Events.AddListener<EntityDeathEvent>(e => e.LivingEntity.Heal());

        zombie.Health = 0;
        AdvanceTicks(_feature.RemoveAfterTicks + 5);

        Assert.That(zombie.World, Is.SameAs(_world));
    }

    /// <summary>
    /// A tick reaches every world's event node as well as the server's, so a feature registered on one
    /// world has to keep to that world rather than handle every one of them.
    /// </summary>
    [Test]
    public void TestWorldScopedFeatureLeavesOtherWorldsAlone() {
        World other = _server.CreateWorld(new VoidProvider(), "minecraft:overworld",
            new FullBrightLightingProvider());
        other.LoadChunk(new Vec2<int>(0, 0)).Wait();

        // The server wide one would cover both, so this is about the world scoped one on its own.
        _feature.Unregister();
        other.AddFeature(new DeathFeature { RemoveAfterTicks = 0 });

        LivingEntity elsewhere = Spawn();
        elsewhere.Health = 0;
        AdvanceTicks(2);

        Assert.That(elsewhere.World, Is.SameAs(_world), "a world's feature reached into another world");
        Assert.That(elsewhere.IsDead, Is.False);
    }
}
