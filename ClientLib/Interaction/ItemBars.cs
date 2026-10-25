using ClientLib.Inventory;
using ClientLib.Maths;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas.Items;

namespace ClientLib.Interaction;

/// <summary>
/// The bar a slot draws under an item: <c>Item.isBarVisible</c>, <c>getBarWidth</c> and <c>getBarColor</c>,
/// with <c>BundleItem</c>'s fill level in place of durability for a bundle.
/// </summary>
public static class ItemBars {
    public const int MaxBarWidth = 13;

    // BundleItem.FULL_BAR_COLOR and BAR_COLOR, ARGB.colorFromFloat(1, r, g, b).
    private const uint BundleFullBarColor = 0xFFFF5454;
    private const uint BundleBarColor = 0xFF7087FF;

    public static bool IsBarVisible(ItemStack stack) {
        if (IsBundle(stack)) {
            return BundleWeight(stack).CompareTo(Fraction.Zero) > 0;
        }
        return IsDamaged(stack);
    }

    public static int GetBarWidth(ItemStack stack) {
        if (IsBundle(stack)) {
            Fraction weight = BundleWeight(stack);
            // Mth.mulAndTruncate.
            return Math.Min(1 + unchecked(weight.Numerator * 12) / weight.Denominator, 13);
        }
        // Math.round(float) is floor(x + 0.5F).
        return Math.Clamp((int)MathF.Floor(13.0F - DamageValue(stack) * 13.0F / MaxDamage(stack) + 0.5F), 0, 13);
    }

    /// <returns>The colour as 0xRRGGBB, alpha not included.</returns>
    public static uint GetBarColor(ItemStack stack) {
        if (IsBundle(stack)) {
            Fraction weight = BundleWeight(stack);
            return (weight.CompareTo(Fraction.One) >= 0 ? BundleFullBarColor : BundleBarColor) & 0xFFFFFF;
        }
        int maxDamage = MaxDamage(stack);
        float healthPercentage = Math.Max(0.0F, ((float)maxDamage - DamageValue(stack)) / maxDamage);
        return HsvToRgb(healthPercentage / 3.0F, 1.0F, 1.0F);
    }

    /// <summary>Only a <c>BundleItem</c> overrides the bar; another stack given bundle contents keeps the durability bar.</summary>
    public static bool IsBundle(ItemStack stack) => BundleItem.Is(stack.Type);

    /// <summary><c>ItemStack.isDamageableItem</c>.</summary>
    internal static bool IsDamageableItem(ItemStack stack) =>
        ItemComponents.Has(stack, DataComponent.MaxDamage) && !ItemComponents.Has(stack, DataComponent.Unbreakable) && ItemComponents.Has(stack, DataComponent.Damage);

    internal static bool IsDamaged(ItemStack stack) => IsDamageableItem(stack) && DamageValue(stack) > 0;

    internal static int MaxDamage(ItemStack stack) => ItemComponents.Get(stack, DataComponent.MaxDamage);

    internal static int DamageValue(ItemStack stack) => Math.Clamp(ItemComponents.Get(stack, DataComponent.Damage), 0, MaxDamage(stack));

    internal static int MaxStackSize(ItemStack stack) =>
        ItemComponents.Has(stack, DataComponent.MaxStackSize) ? ItemComponents.Get(stack, DataComponent.MaxStackSize) : 1;

    /// <summary><c>BundleItem.getFullnessDisplay</c>.</summary>
    internal static float BundleFullness(ItemStack stack) => BundleWeight(stack).FloatValue;

    /// <summary><c>BundleItem.getWeightSafe</c>: an unusable weight counts as full.</summary>
    private static Fraction BundleWeight(ItemStack stack) =>
        BundleContents.Weight(BundleContents.Of(stack) ?? []) ?? Fraction.One;

    /// <summary><c>Mth.hsvToRgb</c>.</summary>
    private static uint HsvToRgb(float hue, float saturation, float value) {
        int h = (int)(hue * 6.0F) % 6;
        float f = hue * 6.0F - h;
        float p = value * (1.0F - saturation);
        float q = value * (1.0F - f * saturation);
        float t = value * (1.0F - (1.0F - f) * saturation);
        (float red, float green, float blue) = h switch {
            0 => (value, t, p),
            1 => (q, value, p),
            2 => (p, value, t),
            3 => (p, q, value),
            4 => (t, p, value),
            5 => (value, p, q),
            _ => throw new InvalidOperationException($"Something went wrong when converting from HSV to RGB. Input was {hue}, {saturation}, {value}")
        };
        return (uint)Math.Clamp((int)(red * 255.0F), 0, 255) << 16 | (uint)Math.Clamp((int)(green * 255.0F), 0, 255) << 8
            | (uint)Math.Clamp((int)(blue * 255.0F), 0, 255);
    }
}
