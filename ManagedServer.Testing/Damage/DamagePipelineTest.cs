using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Damage;

/// <summary>
/// <see cref="DamagePipeline"/> and the <see cref="LivingEntity.Damage(DamageSource, float)"/> around
/// it: the invulnerable window vanilla gets from counting down <c>invulnerableTime</c>, and the stage
/// order that is the only ordering guarantee a modifier gets.
/// </summary>
[TestFixture]
public class DamagePipelineTest {
    private ManagedMinecraftServer _server = null!;
    private World _world = null!;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { };
        _world = CreateWorld("minecraft:overworld");
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    private World CreateWorld(string name) {
        World world = _server.CreateWorld(new VoidProvider(), name, new FullBrightLightingProvider());
        world.LoadChunk(new Vec2<int>(0, 0)).Wait();
        return world;
    }

    private LivingEntity Spawn(World? world = null) {
        LivingEntity entity = new(EntityType.Zombie) {
            Position = new Vec3<double>(8.5, 64, 8.5)
        };
        entity.SetWorld(world ?? _world);
        return entity;
    }

    /// <summary>The window is measured against the tick counter, which nothing moves in a test.</summary>
    private void AdvanceTicks(int count) {
        typeof(ManagedMinecraftServer)
            .GetProperty(nameof(ManagedMinecraftServer.CurrentTick))!
            .SetValue(_server, _server.CurrentTick + (ulong)count);
    }

    private static DamageSource Generic => new(DamageType.Generic);

    [Test]
    public void TestHitTakesHealthAndReportsBothEvents() {
        LivingEntity zombie = Spawn();
        List<EntityDamageEvent> before = [];
        List<EntityDamagedEvent> after = [];
        _world.Events.AddListener<EntityDamageEvent>(e => before.Add(e));
        _world.Events.AddListener<EntityDamagedEvent>(e => after.Add(e));

        Assert.That(zombie.Damage(Generic, 6f), Is.True);

        Assert.That(zombie.Health, Is.EqualTo(14f));
        Assert.That(before, Has.Count.EqualTo(1));
        Assert.That(after, Has.Count.EqualTo(1));
        Assert.That(after[0].Amount, Is.EqualTo(6f));
        Assert.That(after[0].LivingEntity, Is.SameAs(zombie));
    }

    [Test]
    public void TestSecondHitInsideWindowIsThrownAway() {
        LivingEntity zombie = Spawn();

        zombie.Damage(Generic, 4f);
        AdvanceTicks(9);

        Assert.That(zombie.Damage(Generic, 4f), Is.False);
        Assert.That(zombie.Health, Is.EqualTo(16f));
    }

    [Test]
    public void TestHitAfterWindowLandsWhole() {
        LivingEntity zombie = Spawn();

        zombie.Damage(Generic, 4f);
        AdvanceTicks(10);

        Assert.That(zombie.Damage(Generic, 4f), Is.True);
        Assert.That(zombie.Health, Is.EqualTo(12f));
    }

    /// <summary>
    /// Vanilla's <c>lastHurt</c>: a harder hit inside the window is topped up to what it was worth
    /// rather than thrown away, so a sword through a burn is not free.
    /// </summary>
    [Test]
    public void TestHarderHitInsideWindowLandsForTheDifference() {
        LivingEntity zombie = Spawn();

        zombie.Damage(Generic, 4f);
        AdvanceTicks(3);

        Assert.That(zombie.Damage(Generic, 7f), Is.True);
        Assert.That(zombie.Health, Is.EqualTo(13f));

        // The window now measures against seven, so the original four no longer gets through.
        Assert.That(zombie.Damage(Generic, 4f), Is.False);
        Assert.That(zombie.Health, Is.EqualTo(13f));
    }

    [Test]
    public void TestZeroInvulnerableTicksLetsEveryHitLand() {
        LivingEntity zombie = Spawn();
        zombie.InvulnerableTicks = 0;

        zombie.Damage(Generic, 4f);
        Assert.That(zombie.Damage(Generic, 4f), Is.True);
        Assert.That(zombie.Health, Is.EqualTo(12f));
    }

    /// <summary>
    /// A cancelled hit has to leave no trace, or cancelling one would protect the entity from the
    /// next one for ten ticks.
    /// </summary>
    [Test]
    public void TestCancelledHitLeavesNoInvulnerableWindow() {
        LivingEntity zombie = Spawn();
        bool cancel = true;
        _world.Events.AddListener<EntityDamageEvent>(e => e.Cancelled = cancel);

        Assert.That(zombie.Damage(Generic, 4f), Is.False);
        Assert.That(zombie.Health, Is.EqualTo(20f));

        cancel = false;
        Assert.That(zombie.Damage(Generic, 4f), Is.True);
        Assert.That(zombie.Health, Is.EqualTo(16f));
    }

    [Test]
    public void TestDeadEntityTakesNoMoreHits() {
        LivingEntity zombie = Spawn();
        zombie.Health = 0;

        Assert.That(zombie.Damage(Generic, 4f), Is.False);
    }

    [Test]
    public void TestModifierReducesDamageAndIsReportedAfterwards() {
        LivingEntity zombie = Spawn();
        _server.DamagePipeline.Add(new DamageModifier(DamageStage.Armour, (_, _, amount) => amount / 2f));

        List<EntityDamagedEvent> after = [];
        _world.Events.AddListener<EntityDamagedEvent>(e => after.Add(e));

        zombie.Damage(Generic, 8f);

        Assert.That(zombie.Health, Is.EqualTo(16f));
        Assert.That(after[0].Amount, Is.EqualTo(4f));
    }

    /// <summary>
    /// The point of the stages. Armour has to see the raw amount whatever order the modifiers were
    /// registered in, because vanilla's armour factor is worked out from the incoming damage.
    /// </summary>
    [Test]
    public void TestStagesRunInOrderNotRegistrationOrder() {
        LivingEntity zombie = Spawn();
        List<float> seen = [];

        _server.DamagePipeline.Add(new DamageModifier(DamageStage.Absorption, (_, _, amount) => {
            seen.Add(amount);
            return amount;
        }));
        _server.DamagePipeline.Add(new DamageModifier(DamageStage.Magic, (_, _, amount) => {
            seen.Add(amount);
            return amount / 2f;
        }));
        _server.DamagePipeline.Add(new DamageModifier(DamageStage.Armour, (_, _, amount) => {
            seen.Add(amount);
            return amount - 2f;
        }));

        zombie.Damage(Generic, 10f);

        Assert.That(seen, Is.EqualTo(new[] { 10f, 8f, 4f }));
        Assert.That(zombie.Health, Is.EqualTo(16f));
    }

    [Test]
    public void TestModifiersInOneStageRunInRegistrationOrder() {
        LivingEntity zombie = Spawn();
        List<string> order = [];

        _server.DamagePipeline.Add(new DamageModifier(DamageStage.Magic, (_, _, amount) => {
            order.Add("first");
            return amount;
        }));
        _server.DamagePipeline.Add(new DamageModifier(DamageStage.Magic, (_, _, amount) => {
            order.Add("second");
            return amount;
        }));

        zombie.Damage(Generic, 4f);

        Assert.That(order, Is.EqualTo(new[] { "first", "second" }));
    }

    [Test]
    public void TestModifierCannotHealAnEntity() {
        LivingEntity zombie = Spawn();
        _server.DamagePipeline.Add(new DamageModifier(DamageStage.Armour, (_, _, amount) => amount - 100f));

        Assert.That(zombie.Damage(Generic, 4f), Is.True);
        Assert.That(zombie.Health, Is.EqualTo(20f));
    }

    [Test]
    public void TestWorldScopedModifierLeavesOtherWorldsAlone() {
        World other = CreateWorld("minecraft:the_nether");
        _server.DamagePipeline.Add(new DamageModifier(DamageStage.Armour, (_, _, _) => 0f), _world);

        LivingEntity inScope = Spawn();
        LivingEntity outOfScope = Spawn(other);

        inScope.Damage(Generic, 6f);
        outOfScope.Damage(Generic, 6f);

        Assert.That(inScope.Health, Is.EqualTo(20f));
        Assert.That(outOfScope.Health, Is.EqualTo(14f));
    }

    [Test]
    public void TestUnregisteringAFeatureTakesItsModifierOff() {
        LivingEntity zombie = Spawn();
        HalveDamageFeature feature = new();
        _world.AddFeature(feature);

        zombie.Damage(Generic, 8f);
        Assert.That(zombie.Health, Is.EqualTo(16f));

        feature.Unregister();
        AdvanceTicks(10);

        zombie.Damage(Generic, 8f);
        Assert.That(zombie.Health, Is.EqualTo(8f));
    }

    private class HalveDamageFeature : ScopedFeature {
        public override void Register() {
            AddDamageModifier(new DamageModifier(DamageStage.Armour, (_, _, amount) => amount / 2f));
        }
    }
}
