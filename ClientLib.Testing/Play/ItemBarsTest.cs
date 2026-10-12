using ClientLib.Interaction;
using ClientLib.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace ClientLib.Testing.Play;

/// <summary>
/// <c>Item.getBarWidth</c>/<c>getBarColor</c> and <c>BundleItem</c>'s overrides, against values worked by
/// hand from vanilla's arithmetic, and <c>ItemCooldowns</c>' fraction.
/// </summary>
public class ItemBarsTest {
    private static ItemStack Damaged(int damage) {
        return new ItemStack(Item.DiamondPickaxe, 1).With(DataComponent.Damage, damage);
    }

    [Test]
    public void AnUndamagedToolHasNoBar() {
        Assert.That(ItemBars.IsBarVisible(new ItemStack(Item.DiamondPickaxe, 1)), Is.False);
        Assert.That(ItemBars.IsBarVisible(new ItemStack(Item.Stone, 1)), Is.False);
    }

    /// <summary>
    /// Diamond tools last 1561. At 780 damage: round(13 - 780 * 13 / 1561) = round(6.504) = 7, and the
    /// health 781/1561 = 0.50032 gives hue 0.16677, so h = 1, f = 0.00064, red = 1 - f = 0.99936: (254, 255, 0).
    /// </summary>
    [Test]
    public void AHalfWornToolHasAYellowBarHalfFull() {
        ItemStack stack = Damaged(780);
        Assert.That(ItemBars.IsBarVisible(stack), Is.True);
        Assert.That(ItemBars.GetBarWidth(stack), Is.EqualTo(7));
        Assert.That(ItemBars.GetBarColor(stack), Is.EqualTo(0xFEFF00));
    }

    /// <summary>1560 damage leaves 1/1561 health: width round(0.0083) = 0, hue 0.000213 is red with a trace of green.</summary>
    [Test]
    public void AnAlmostBrokenToolHasAnEmptyRedBar() {
        ItemStack stack = Damaged(1560);
        Assert.That(ItemBars.GetBarWidth(stack), Is.EqualTo(0));
        Assert.That(ItemBars.GetBarColor(stack) >> 16, Is.EqualTo(255));
        Assert.That(ItemBars.GetBarColor(stack) & 0xFF, Is.EqualTo(0));
    }

    [Test]
    public void AnUnbreakableToolHasNoBar() {
        ItemStack stack = Damaged(100).With(DataComponent.Unbreakable, UnbreakableComponent.Value);
        Assert.That(ItemBars.IsBarVisible(stack), Is.False);
    }

    /// <summary>32 stone of 64 weigh 1/2: width min(1 + 12 / 2, 13) = 7, under full so the blue bar.</summary>
    [Test]
    public void AHalfFullBundleHasAHalfBlueBar() {
        ItemStack bundle = new ItemStack(Item.Bundle, 1).With(DataComponent.BundleContents, [new ItemStack(Item.Stone, 32)]);
        Assert.That(ItemBars.IsBarVisible(bundle), Is.True);
        Assert.That(ItemBars.GetBarWidth(bundle), Is.EqualTo(7));
        Assert.That(ItemBars.GetBarColor(bundle), Is.EqualTo(0x7087FF));
    }

    /// <summary>One sword weighs a whole bundle: width min(1 + 12, 13) = 13 and the full colour.</summary>
    [Test]
    public void AFullBundleHasAFullRedBar() {
        ItemStack bundle = new ItemStack(Item.RedBundle, 1).With(DataComponent.BundleContents, [new ItemStack(Item.DiamondSword, 1)]);
        Assert.That(ItemBars.GetBarWidth(bundle), Is.EqualTo(13));
        Assert.That(ItemBars.GetBarColor(bundle), Is.EqualTo(0xFF5454));
    }

    [Test]
    public void AnEmptyBundleHasNoBar() {
        Assert.That(ItemBars.IsBarVisible(new ItemStack(Item.Bundle, 1)), Is.False);
    }

    [Test]
    public void ACooldownRunsDownOverItsTicks() {
        ItemCooldowns cooldowns = new();
        ItemStack pearl = new(Item.EnderPearl, 16);
        cooldowns.AddCooldown(Item.EnderPearl.Identifier, 20);
        Assert.That(cooldowns.GetCooldownPercent(pearl, 0.0F), Is.EqualTo(1.0F));
        for (int i = 0; i < 5; i++) {
            cooldowns.Tick();
        }
        Assert.That(cooldowns.GetCooldownPercent(pearl, 0.5F), Is.EqualTo(14.5F / 20.0F));
        for (int i = 0; i < 15; i++) {
            cooldowns.Tick();
        }
        Assert.That(cooldowns.IsOnCooldown(pearl), Is.False);
    }
}
