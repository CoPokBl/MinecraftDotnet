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
            return BundleWeight(ItemComponents.Get(stack, DataComponent.BundleContents) ?? []).CompareTo(Fraction.Zero) > 0;
        }
        return IsDamaged(stack);
    }

    public static int GetBarWidth(ItemStack stack) {
        if (IsBundle(stack)) {
            Fraction weight = BundleWeight(ItemComponents.Get(stack, DataComponent.BundleContents) ?? []);
            // Mth.mulAndTruncate.
            return (int)Math.Min(1 + weight.Numerator * 12 / weight.Denominator, 13);
        }
        // Math.round(float) is floor(x + 0.5F).
        return Math.Clamp((int)MathF.Floor(13.0F - DamageValue(stack) * 13.0F / MaxDamage(stack) + 0.5F), 0, 13);
    }

    /// <returns>The colour as 0xRRGGBB, alpha not included.</returns>
    public static uint GetBarColor(ItemStack stack) {
        if (IsBundle(stack)) {
            Fraction weight = BundleWeight(ItemComponents.Get(stack, DataComponent.BundleContents) ?? []);
            return (weight.CompareTo(Fraction.One) >= 0 ? BundleFullBarColor : BundleBarColor) & 0xFFFFFF;
        }
        int maxDamage = MaxDamage(stack);
        float healthPercentage = Math.Max(0.0F, ((float)maxDamage - DamageValue(stack)) / maxDamage);
        return HsvToRgb(healthPercentage / 3.0F, 1.0F, 1.0F);
    }

    /// <summary>The items that are <c>BundleItem</c>s, the only class overriding the bar; another stack given bundle contents keeps the durability bar.</summary>
    private static readonly HashSet<IItem> Bundles = [
        Item.Bundle, Item.WhiteBundle, Item.OrangeBundle, Item.MagentaBundle, Item.LightBlueBundle, Item.YellowBundle, Item.LimeBundle,
        Item.PinkBundle, Item.GrayBundle, Item.LightGrayBundle, Item.CyanBundle, Item.PurpleBundle, Item.BlueBundle, Item.BrownBundle,
        Item.GreenBundle, Item.RedBundle, Item.BlackBundle
    ];

    public static bool IsBundle(ItemStack stack) => Bundles.Contains(stack.Type);

    /// <summary><c>ItemStack.isDamageableItem</c>.</summary>
    internal static bool IsDamageableItem(ItemStack stack) =>
        ItemComponents.Has(stack, DataComponent.MaxDamage) && !ItemComponents.Has(stack, DataComponent.Unbreakable) && ItemComponents.Has(stack, DataComponent.Damage);

    internal static bool IsDamaged(ItemStack stack) => IsDamageableItem(stack) && DamageValue(stack) > 0;

    internal static int MaxDamage(ItemStack stack) => ItemComponents.Get(stack, DataComponent.MaxDamage);

    internal static int DamageValue(ItemStack stack) => Math.Clamp(ItemComponents.Get(stack, DataComponent.Damage), 0, MaxDamage(stack));

    internal static int MaxStackSize(ItemStack stack) =>
        ItemComponents.Has(stack, DataComponent.MaxStackSize) ? ItemComponents.Get(stack, DataComponent.MaxStackSize) : 1;

    /// <summary><c>BundleItem.getFullnessDisplay</c>.</summary>
    internal static float BundleFullness(ItemStack stack) {
        Fraction weight = BundleWeight(ItemComponents.Get(stack, DataComponent.BundleContents) ?? []);
        return (float)weight.Numerator / weight.Denominator;
    }

    /// <summary><c>BundleContents.computeContentWeight</c>.</summary>
    private static Fraction BundleWeight(ItemStack[] items) {
        Fraction weight = Fraction.Zero;
        foreach (ItemStack stack in items) {
            weight = weight.Add(Weight(stack).Multiply(stack.Count));
        }
        return weight;
    }

    /// <summary><c>BundleContents.getWeight</c>: a bundle weighs its contents and a sixteenth, a hive with bees a whole bundle.</summary>
    private static Fraction Weight(ItemStack stack) {
        if (ItemComponents.Get(stack, DataComponent.BundleContents) is { } nested) {
            return BundleWeight(nested).Add(new Fraction(1, 16));
        }
        return ItemComponents.Get(stack, DataComponent.Bees) is { Length: > 0 } ? Fraction.One : new Fraction(1, MaxStackSize(stack));
    }

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

    /// <summary>The part of Apache's <c>Fraction</c> bundle weights use: always reduced, as its arithmetic leaves it.</summary>
    private readonly record struct Fraction : IComparable<Fraction> {
        public static readonly Fraction Zero = new(0, 1);
        public static readonly Fraction One = new(1, 1);

        public long Numerator { get; }
        public long Denominator { get; }

        public Fraction(long numerator, long denominator) {
            long gcd = (long)System.Numerics.BigInteger.GreatestCommonDivisor(numerator, denominator);
            Numerator = gcd == 0 ? 0 : numerator / gcd;
            Denominator = gcd == 0 ? 1 : denominator / gcd;
        }

        public Fraction Add(Fraction other) => new(Numerator * other.Denominator + other.Numerator * Denominator, Denominator * other.Denominator);

        public Fraction Multiply(int factor) => new(Numerator * factor, Denominator);

        public int CompareTo(Fraction other) => (Numerator * other.Denominator).CompareTo(other.Numerator * Denominator);
    }
}
