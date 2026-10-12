using ClientLib.Interaction;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Testing.Interaction;

/// <summary>
/// The stack side of vanilla's item model properties and tint sources, against values worked by hand from
/// <c>ItemStack.hasFoil</c>, <c>Charge</c>, <c>CrossbowPull</c>, <c>Damage</c>, <c>PotionContents.getColorOptional</c>,
/// <c>Firework</c> and <c>NeedleDirectionHelper</c>.
/// </summary>
public class ItemModelPropertiesTest {
    private static ItemStack Enchanted(IItem item, IEnchantment enchantment, int level) =>
        new ItemStack(item).With(DataComponent.Enchantments, new[] { (enchantment, level) });

    [Test]
    public void EnchantmentsGlintUnlessOverridden() {
        Assert.That(ItemModelProperties.HasFoil(new ItemStack(Item.DiamondSword)), Is.False);
        Assert.That(ItemModelProperties.HasFoil(Enchanted(Item.DiamondSword, Enchantment.Sharpness, 3)), Is.True);
        Assert.That(ItemModelProperties.HasFoil(Enchanted(Item.DiamondSword, Enchantment.Sharpness, 3).With(DataComponent.EnchantmentGlintOverride, false)),
            Is.False);
        Assert.That(ItemModelProperties.HasFoil(new ItemStack(Item.Stone).With(DataComponent.EnchantmentGlintOverride, true)), Is.True);
    }

    /// <summary><c>CompassItem.isFoil</c>: a lodestone compass glints whether or not its lodestone is tracked.</summary>
    [Test]
    public void ALodestoneCompassGlints() {
        Assert.That(ItemModelProperties.HasFoil(new ItemStack(Item.Compass)), Is.False);
        ItemStack lodestone = new ItemStack(Item.Compass).With(DataComponent.LodestoneTracker, new LodestoneTrackerComponent.Data(null, false));
        Assert.That(ItemModelProperties.HasFoil(lodestone), Is.True);
        Assert.That(ItemModelProperties.HasFoil(new ItemStack(Item.RecoveryCompass).With(DataComponent.LodestoneTracker, new LodestoneTrackerComponent.Data(null, false))),
            Is.False);
    }

    [Test]
    public void ARocketAnywhereAmongTheProjectilesMakesTheChargeARocket() {
        ItemStack Charged(params IItem[] projectiles) =>
            new ItemStack(Item.Crossbow).With(DataComponent.ChargedProjectiles, projectiles.Select(p => new ItemStack(p)).ToArray());
        Assert.That(ItemModelProperties.ChargeType(new ItemStack(Item.Crossbow)), Is.EqualTo(CrossbowChargeType.None));
        Assert.That(ItemModelProperties.ChargeType(Charged(Item.Arrow)), Is.EqualTo(CrossbowChargeType.Arrow));
        Assert.That(ItemModelProperties.ChargeType(Charged(Item.Arrow, Item.FireworkRocket, Item.Arrow)), Is.EqualTo(CrossbowChargeType.Rocket));
    }

    /// <summary>A crossbow takes 25 ticks to charge, 20 with quick charge I; a charged one reads no pull.</summary>
    [Test]
    public void CrossbowPullIsTicksOverTheChargeDuration() {
        Assert.That(ItemModelProperties.CrossbowPull(new ItemStack(Item.Crossbow), 10), Is.EqualTo(0.4F));
        Assert.That(ItemModelProperties.CrossbowPull(Enchanted(Item.Crossbow, Enchantment.QuickCharge, 1), 10), Is.EqualTo(0.5F));
        ItemStack charged = new ItemStack(Item.Crossbow).With(DataComponent.ChargedProjectiles, new[] { new ItemStack(Item.Arrow) });
        Assert.That(ItemModelProperties.CrossbowPull(charged, 10), Is.EqualTo(0.0F));
    }

    /// <summary>An elytra lasts 432: at 431 the next point of damage breaks it, which is what its broken model shows.</summary>
    [Test]
    public void AnElytraOneHitFromBreakingIsBroken() {
        Assert.That(ItemModelProperties.NextDamageWillBreak(new ItemStack(Item.Elytra).With(DataComponent.Damage, 431)), Is.True);
        Assert.That(ItemModelProperties.NextDamageWillBreak(new ItemStack(Item.Elytra).With(DataComponent.Damage, 430)), Is.False);
        Assert.That(ItemModelProperties.IsDamaged(new ItemStack(Item.Elytra).With(DataComponent.Damage, 1)), Is.True);
        Assert.That(ItemModelProperties.IsDamaged(new ItemStack(Item.Elytra)), Is.False);
    }

    /// <summary>Nought over nought for an item with no durability, which a range dispatch sends to its fallback.</summary>
    [Test]
    public void DamageIsAFractionOfTheMaximum() {
        Assert.That(ItemModelProperties.Damage(new ItemStack(Item.Elytra).With(DataComponent.Damage, 216), true), Is.EqualTo(0.5F));
        Assert.That(ItemModelProperties.Damage(new ItemStack(Item.Elytra).With(DataComponent.Damage, 216), false), Is.EqualTo(216.0F));
        Assert.That(float.IsNaN(ItemModelProperties.Damage(new ItemStack(Item.Stone), true)), Is.True);
        Assert.That(ItemModelProperties.Count(new ItemStack(Item.Stone, 32), true), Is.EqualTo(0.5F));
    }

    /// <summary>
    /// Swiftness is speed's 0x33EBFF. Turtle master weighs slowness IV (0x8BAFE0) four to resistance III's
    /// (0x9146F0) three: (991, 910, 1616) / 7 = (141, 130, 230). Water has no effects and takes the default.
    /// </summary>
    [Test]
    public void APotionIsItsEffectsColoursWeightedByAmplifier() {
        ItemStack Potion(PotionContentsComponent.Data contents) => new ItemStack(Item.Potion).With(DataComponent.PotionContents, contents);
        Assert.That(ItemModelProperties.PotionColour(Potion(new(Minecraft.Data.Generated.Potion.Swiftness)), -13083194), Is.EqualTo(unchecked((int)0xFF33EBFF)));
        Assert.That(ItemModelProperties.PotionColour(Potion(new(Minecraft.Data.Generated.Potion.TurtleMaster)), -13083194),
            Is.EqualTo(unchecked((int)0xFF8D82E6)));
        Assert.That(ItemModelProperties.PotionColour(Potion(new(Minecraft.Data.Generated.Potion.Water)), -13083194), Is.EqualTo(-13083194));
        Assert.That(ItemModelProperties.PotionColour(Potion(new(Minecraft.Data.Generated.Potion.Swiftness, CustomColor: 0x123456)), -13083194),
            Is.EqualTo(unchecked((int)0xFF123456)));
    }

    [Test]
    public void AFireworkStarAveragesItsColours() {
        ItemStack Star(params int[] colours) =>
            new ItemStack(Item.FireworkStar).With(DataComponent.FireworkExplosion, new FireworkExplosionComponent.Data(Colors: colours));
        Assert.That(ItemModelProperties.FireworkColour(new ItemStack(Item.FireworkStar), -7697782), Is.EqualTo(-7697782));
        Assert.That(ItemModelProperties.FireworkColour(Star(0x00FF00), -7697782), Is.EqualTo(unchecked((int)0xFF00FF00)));
        Assert.That(ItemModelProperties.FireworkColour(Star(0xFF0000, 0x0000FF), -7697782), Is.EqualTo(unchecked((int)0xFF7F007F)));
    }

    /// <summary>
    /// From rest at 0 toward 0.5 the shortest way is back through 1: a step of -0.5, a tenth of it, kept to
    /// 0.8, so the needle moves to 0.96. A needle without wobble is at its target at once.
    /// </summary>
    [Test]
    public void AWobblingNeedleEasesOncePerTick() {
        NeedleWobbler wobbler = new(true, 0.8F);
        Assert.That(wobbler.ShouldUpdate(1), Is.True);
        wobbler.Update(1, 0.5F);
        Assert.That(wobbler.Rotation, Is.EqualTo(0.96F).Within(1e-6F));
        Assert.That(wobbler.ShouldUpdate(1), Is.False);
        NeedleWobbler still = new(false, 0.8F);
        still.Update(1, 0.3F);
        Assert.That(still.Rotation, Is.EqualTo(0.3F));
        Assert.That(still.ShouldUpdate(1), Is.True);
    }
}
