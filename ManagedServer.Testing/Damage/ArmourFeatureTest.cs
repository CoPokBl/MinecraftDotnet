using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Features;
using ManagedServer.Features.Impl;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Testing.Damage;

/// <summary>
/// <see cref="ArmourFeature"/> against <c>CombatRules.getDamageAfterAbsorb</c>.
/// <p/>
/// The expected numbers are the vanilla formula worked through in <b>float</b>, which is what it is
/// upstream. Ten damage through twenty armour is 3.9999998 rather than four, and the test says so on
/// purpose: computing the same thing in double lands on exactly four, so a tolerance wide enough to
/// read nicely would be wide enough to miss the widening.
/// </summary>
[TestFixture]
public class ArmourFeatureTest {
    private ManagedMinecraftServer _server = null!;
    private World _world = null!;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { };
        _server.AddFeature(new ArmourFeature());

        _world = _server.CreateWorld(new VoidProvider(), "minecraft:overworld", new FullBrightLightingProvider());
        _world.LoadChunk(new Vec2<int>(0, 0)).Wait();
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    /// <summary>
    /// Both values are set as the base rather than added as modifiers, because a zombie's entity type
    /// already carries two armour of its own and the point here is to pin exact numbers.
    /// </summary>
    private LivingEntity Spawn(double armour = 0, double toughness = 0) {
        LivingEntity entity = new(EntityType.Zombie) {
            Position = new Vec3<double>(8.5, 64, 8.5)
        };
        entity.SetWorld(_world);
        entity.SetAttributeBaseValue(Attribute.Armor, armour);
        entity.SetAttributeBaseValue(Attribute.ArmorToughness, toughness);
        return entity;
    }

    [TestCase(10f, 20f, 0f, 3.999999761581421f)]
    [TestCase(10f, 20f, 8f, 3f)]
    [TestCase(1f, 20f, 0f, 0.2200000286102295f)]
    [TestCase(4f, 20f, 8f, 0.9600000381469727f)]
    [TestCase(10f, 7f, 0f, 9.199999809265137f)]
    [TestCase(10f, 0f, 0f, 10f)]
    public void TestDamageAfterAbsorbMatchesVanilla(float amount, float armour, float toughness, float expected) {
        Assert.That(ArmourFeature.DamageAfterAbsorb(amount, armour, toughness), Is.EqualTo(expected));
    }

    /// <summary>
    /// The armour factor is worked out from the incoming damage, so a big hit gets through more of
    /// the same armour than a small one does. This is the whole reason armour is its own stage.
    /// </summary>
    [Test]
    public void TestBigHitsGetThroughProportionallyMoreArmour() {
        float small = ArmourFeature.DamageAfterAbsorb(4f, 20f, 0f) / 4f;
        float large = ArmourFeature.DamageAfterAbsorb(100f, 20f, 0f) / 100f;

        Assert.That(large, Is.GreaterThan(small));
        Assert.That(ArmourFeature.DamageAfterAbsorb(100f, 20f, 0f), Is.EqualTo(84f));
    }

    [Test]
    public void TestArmourReducesAHitThroughThePipeline() {
        LivingEntity zombie = Spawn(20);

        zombie.Damage(new DamageSource(DamageType.PlayerAttack), 10f);

        Assert.That(zombie.Health, Is.EqualTo(20f - 3.999999761581421f));
    }

    [Test]
    public void TestToughnessKeepsMoreOfABigHitOut() {
        LivingEntity plain = Spawn(20);
        LivingEntity tough = Spawn(20, 8);

        plain.Damage(new DamageSource(DamageType.PlayerAttack), 10f);
        tough.Damage(new DamageSource(DamageType.PlayerAttack), 10f);

        Assert.That(tough.Health, Is.GreaterThan(plain.Health));
        Assert.That(tough.Health, Is.EqualTo(17f));
    }

    /// <summary>
    /// <c>minecraft:generic</c> is in <c>minecraft:bypasses_armor</c>, along with falling, burning
    /// and the void, so a plated zombie still drowns at the same rate.
    /// </summary>
    [Test]
    public void TestBypassingDamageTypesIgnoreArmour() {
        LivingEntity zombie = Spawn(20);

        zombie.Damage(new DamageSource(DamageType.Generic), 10f);

        Assert.That(zombie.Health, Is.EqualTo(10f));
    }

    [Test]
    public void TestNoArmourChangesNothing() {
        LivingEntity zombie = Spawn();

        zombie.Damage(new DamageSource(DamageType.PlayerAttack), 10f);

        Assert.That(zombie.Health, Is.EqualTo(10f));
    }
}
