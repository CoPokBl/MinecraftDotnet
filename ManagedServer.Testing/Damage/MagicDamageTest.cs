using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Features;
using ManagedServer.Features.Impl;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.EnchantmentEffects.Types;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Testing.Damage;

/// <summary>
/// The <see cref="DamageStage.Magic"/> stage: <see cref="ResistanceFeature"/> and
/// <see cref="ProtectionFeature"/>, which together are vanilla's
/// <c>LivingEntity.getDamageAfterMagicAbsorb</c>, plus the <see cref="FireResistanceFeature"/> that
/// drops burning damage before any of it.
/// <p/>
/// As in <c>ArmourFeatureTest</c> the numbers are the vanilla arithmetic in float and are pinned
/// exactly.
/// </summary>
[TestFixture]
public class MagicDamageTest {
    private ManagedMinecraftServer _server = null!;
    private World _world = null!;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { };
        _server.AddFeature(new ResistanceFeature());
        _server.AddFeature(new ProtectionFeature());
        _server.AddFeature(new FireResistanceFeature());

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
        entity.SetAttributeBaseValue(Attribute.Armor, 0);
        return entity;
    }

    private static DamageSource Attack => new(DamageType.PlayerAttack);

    private static void Wear(LivingEntity entity, IEnchantment enchantment, int level) {
        EquipmentSlot[] armour = [
            EquipmentSlot.Helmet, EquipmentSlot.Chestplate, EquipmentSlot.Leggings, EquipmentSlot.Boots
        ];

        foreach (EquipmentSlot slot in armour) {
            entity.SetEquipmentItem(slot,
                new ItemStack(Item.LeatherHelmet).With(DataComponent.Enchantments, [(enchantment, level)]));
        }
    }

    /// <summary>Amplifiers are zero based, so this is Resistance I, II and V.</summary>
    [TestCase(0, 8f)]
    [TestCase(1, 6f)]
    [TestCase(4, 0f)]
    public void TestResistanceTakesAFifthPerLevel(int amplifier, float expected) {
        LivingEntity zombie = Spawn();
        zombie.Effects.Add(PotionEffectType.Resistance, amplifier, 100);

        zombie.Damage(Attack, 10f);

        Assert.That(zombie.Health, Is.EqualTo(20f - expected));
    }

    [Test]
    public void TestResistanceIsSkippedByBypassingDamage() {
        LivingEntity zombie = Spawn();
        zombie.Effects.Add(PotionEffectType.Resistance, 4, 100);

        // minecraft:starve is in bypasses_effects, so nothing in this stage touches it.
        zombie.Damage(new DamageSource(DamageType.Starve), 10f);

        Assert.That(zombie.Health, Is.EqualTo(10f));
    }

    [Test]
    public void TestNoResistanceChangesNothing() {
        LivingEntity zombie = Spawn();

        zombie.Damage(Attack, 10f);

        Assert.That(zombie.Health, Is.EqualTo(10f));
    }

    /// <summary>
    /// Protection is linear from one, so four pieces of Protection IV is four points each and
    /// sixteen in total, under vanilla's cap of twenty.
    /// </summary>
    [Test]
    public void TestProtectionOnFourPiecesSums() {
        LivingEntity zombie = Spawn();
        Wear(zombie, Enchantment.Protection, 4);

        zombie.Damage(Attack, 10f);

        Assert.That(zombie.Health, Is.EqualTo(20f - 3.6000001430511475f));
    }

    /// <summary>
    /// Fire protection is worth nothing against a sword. That the requirement is read out of the
    /// enchantment's own data rather than written into the feature is the point of this one.
    /// </summary>
    [Test]
    public void TestFireProtectionOnlyCountsAgainstFire() {
        LivingEntity zombie = Spawn();
        Wear(zombie, Enchantment.FireProtection, 1);

        zombie.Damage(Attack, 10f);
        Assert.That(zombie.Health, Is.EqualTo(10f));

        LivingEntity burnt = Spawn();
        Wear(burnt, Enchantment.FireProtection, 1);

        // Two points a piece at level one, so eight, and 10 * (1 - 8/25).
        burnt.Damage(new DamageSource(DamageType.OnFire), 10f);
        Assert.That(burnt.Health, Is.EqualTo(20f - 6.800000190734863f));
    }

    /// <summary>
    /// The enchantment registry has to actually carry the effect, which it only does because
    /// <see cref="DamageProtectionEnchantmentEffect"/> is parsed out of the datapack form.
    /// </summary>
    [Test]
    public void TestProtectionEnchantmentsCarryTheirDamageProtectionEffect() {
        foreach (IEnchantment enchantment in new[] {
                     Enchantment.Protection, Enchantment.FireProtection, Enchantment.BlastProtection,
                     Enchantment.ProjectileProtection, Enchantment.FeatherFalling
                 }) {
            string name = enchantment.Identifier.ToString();
            DamageProtectionEnchantmentEffect? effect = enchantment.Effects
                .OfType<DamageProtectionEnchantmentEffect>()
                .FirstOrDefault();

            Assert.That(effect, Is.Not.Null, name);
            Assert.That(effect!.Entries, Is.Not.Empty, name);

            // Every one of them refuses to apply to damage that bypasses invulnerability.
            Assert.That(effect.Entries[0].Requirements
                    .Any(r => r.Tag.Equals("minecraft:bypasses_invulnerability") && !r.Expected),
                Is.True, name);
        }
    }

    [Test]
    public void TestFireResistanceStopsBurningEntirely() {
        LivingEntity zombie = Spawn();
        zombie.Effects.Add(PotionEffectType.FireResistance, 0, 100);

        Assert.That(zombie.Damage(new DamageSource(DamageType.OnFire), 4f), Is.False);
        Assert.That(zombie.Damage(new DamageSource(DamageType.Lava), 4f), Is.False);
        Assert.That(zombie.Health, Is.EqualTo(20f));

        // A sword still works, and the dropped hits left no invulnerable window behind.
        Assert.That(zombie.Damage(Attack, 4f), Is.True);
        Assert.That(zombie.Health, Is.EqualTo(16f));
    }

    /// <summary>
    /// Armour first, then the magic stage, whatever order the features were registered in. Ten
    /// damage through twenty armour is 3.9999998, and Resistance I takes a fifth of that.
    /// </summary>
    [Test]
    public void TestArmourRunsBeforeResistance() {
        _server.AddFeature(new ArmourFeature());

        LivingEntity zombie = Spawn();
        zombie.SetAttributeBaseValue(Attribute.Armor, 20);
        zombie.Effects.Add(PotionEffectType.Resistance, 0, 100);

        zombie.Damage(Attack, 10f);

        Assert.That(zombie.Health, Is.EqualTo(20f - 3.1999998092651367f));
    }
}
