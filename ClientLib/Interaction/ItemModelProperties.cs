using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Interaction;

/// <summary><c>CrossbowItem.ChargeType</c>, in its serialised names' order.</summary>
public enum CrossbowChargeType {
    None,
    Arrow,
    Rocket
}

/// <summary>
/// What vanilla's item model properties and tint sources read off a stack alone, without the level or
/// the entity holding it.
/// </summary>
public static class ItemModelProperties {
    /// <summary><c>ItemStack.hasFoil</c> over <c>Item.isFoil</c> and <c>CompassItem</c>'s, the only override.</summary>
    public static bool HasFoil(ItemStack stack) {
        if (ItemComponents.Has(stack, DataComponent.EnchantmentGlintOverride)) {
            return ItemComponents.Get(stack, DataComponent.EnchantmentGlintOverride);
        }
        return IsEnchanted(stack) || stack.Type.Identifier == Item.Compass.Identifier && ItemComponents.Has(stack, DataComponent.LodestoneTracker);
    }

    /// <summary><c>ItemStack.isEnchanted</c>.</summary>
    public static bool IsEnchanted(ItemStack stack) => ItemComponents.Get(stack, DataComponent.Enchantments) is { Length: > 0 };

    /// <summary><c>CrossbowItem.isCharged</c>.</summary>
    public static bool IsCharged(ItemStack stack) => ItemComponents.Get(stack, DataComponent.ChargedProjectiles) is { Length: > 0 };

    /// <summary><c>Charge.get</c>: a rocket among the projectiles makes it a rocket.</summary>
    public static CrossbowChargeType ChargeType(ItemStack stack) {
        if (ItemComponents.Get(stack, DataComponent.ChargedProjectiles) is not { Length: > 0 } projectiles) {
            return CrossbowChargeType.None;
        }
        return projectiles.Any(p => p.Type.Identifier == Item.FireworkRocket.Identifier) ? CrossbowChargeType.Rocket : CrossbowChargeType.Arrow;
    }

    /// <summary><c>CrossbowItem.getChargeDuration</c>, with quick charge's quarter second a level as the only enchantment effect.</summary>
    public static int CrossbowChargeDuration(ItemStack crossbow) {
        float duration = Math.Max(0.0F, 1.25F - 0.25F * crossbow.GetEnchantmentLevel(Enchantment.QuickCharge));
        return (int)MathF.Floor(duration * 20.0F);
    }

    /// <summary><c>CrossbowPull.get</c>, given the ticks the holder has used it, <c>UseDuration.useDuration</c>.</summary>
    public static float CrossbowPull(ItemStack stack, int ticksUsed) => IsCharged(stack) ? 0.0F : (float)ticksUsed / CrossbowChargeDuration(stack);

    /// <summary><c>ItemStack.isDamageableItem</c>.</summary>
    public static bool IsDamageableItem(ItemStack stack) => ItemBars.IsDamageableItem(stack);

    /// <summary><c>ItemStack.getDamageValue</c>.</summary>
    public static int DamageValue(ItemStack stack) => ItemBars.DamageValue(stack);

    /// <summary><c>ItemStack.getMaxDamage</c>.</summary>
    public static int MaxDamage(ItemStack stack) => ItemBars.MaxDamage(stack);

    /// <summary><c>ItemStack.isDamaged</c>.</summary>
    public static bool IsDamaged(ItemStack stack) => ItemBars.IsDamaged(stack);

    /// <summary><c>ItemStack.nextDamageWillBreak</c>.</summary>
    public static bool NextDamageWillBreak(ItemStack stack) =>
        ItemBars.IsDamageableItem(stack) && ItemBars.DamageValue(stack) >= ItemBars.MaxDamage(stack) - 1;

    /// <summary><c>Damage.get</c>. With no maximum it is nought over nought, which a range dispatch takes as its fallback.</summary>
    public static float Damage(ItemStack stack, bool normalize) {
        float damage = ItemBars.DamageValue(stack);
        float maxDamage = ItemBars.MaxDamage(stack);
        return normalize ? Clamp(damage / maxDamage, 0.0F, 1.0F) : Clamp(damage, 0.0F, maxDamage);
    }

    /// <summary><c>Count.get</c>.</summary>
    public static float Count(ItemStack stack, bool normalize) {
        float count = stack.Count;
        float maxCount = ItemBars.MaxStackSize(stack);
        return normalize ? Clamp(count / maxCount, 0.0F, 1.0F) : Clamp(count, 0.0F, maxCount);
    }

    /// <summary><c>BundleItem.getFullnessDisplay</c>.</summary>
    public static float BundleFullness(ItemStack stack) => ItemBars.BundleFullness(stack);

    /// <summary><c>Mth.clamp(float)</c>, which lets NaN through as Java's <c>Math.min</c> does.</summary>
    private static float Clamp(float value, float min, float max) => value < min ? min : float.IsNaN(value) ? value : Math.Min(value, max);

    /// <summary><c>CustomModelData.getFloat</c>.</summary>
    public static float? CustomModelDataFloat(ItemStack stack, int index) =>
        ItemComponents.Get(stack, DataComponent.CustomModelData) is { } data && index < data.Floats.Length ? data.Floats[index] : null;

    /// <summary><c>CustomModelData.getBoolean</c>.</summary>
    public static bool? CustomModelDataFlag(ItemStack stack, int index) =>
        ItemComponents.Get(stack, DataComponent.CustomModelData) is { } data && index < data.Flags.Length ? data.Flags[index] : null;

    /// <summary><c>CustomModelData.getString</c>.</summary>
    public static string? CustomModelDataString(ItemStack stack, int index) =>
        ItemComponents.Get(stack, DataComponent.CustomModelData) is { } data && index < data.Strings.Length ? data.Strings[index] : null;

    /// <summary><c>CustomModelData.getColor</c>.</summary>
    public static int? CustomModelDataColour(ItemStack stack, int index) =>
        ItemComponents.Get(stack, DataComponent.CustomModelData) is { } data && index < data.Colors.Length ? data.Colors[index] : null;

    private static int Opaque(int rgb) => unchecked((int)0xFF000000) | rgb;

    /// <summary><c>DyedItemColor.getOrDefault</c>.</summary>
    public static int DyeColour(ItemStack stack, int defaultColour) {
        if (!ItemComponents.Has(stack, DataComponent.DyedColor)) {
            return defaultColour;
        }
        Minecraft.Text.TextColor colour = ItemComponents.Get(stack, DataComponent.DyedColor);
        return Opaque(colour.R << 16 | colour.G << 8 | colour.B);
    }

    /// <summary><c>Firework.calculate</c>: one colour as it is, several averaged.</summary>
    public static int FireworkColour(ItemStack stack, int defaultColour) {
        int[] colours = ItemComponents.Get(stack, DataComponent.FireworkExplosion)?.Colors ?? [];
        if (colours.Length == 0) {
            return defaultColour;
        }
        if (colours.Length == 1) {
            return Opaque(colours[0]);
        }
        int red = 0, green = 0, blue = 0;
        foreach (int colour in colours) {
            red += colour >> 16 & 0xFF;
            green += colour >> 8 & 0xFF;
            blue += colour & 0xFF;
        }
        return Opaque(red / colours.Length << 16 | green / colours.Length << 8 | blue / colours.Length);
    }

    /// <summary><c>Potion.calculate</c> over <c>PotionContents.getColorOr</c>.</summary>
    public static int PotionColour(ItemStack stack, int defaultColour) {
        if (ItemComponents.Get(stack, DataComponent.PotionContents) is not { } contents) {
            return Opaque(defaultColour);
        }
        if (contents.CustomColor is { } custom) {
            return Opaque(custom);
        }
        IEnumerable<(Identifier Type, int Amplifier, bool Visible)> effects = contents.CustomEffects.Select(e => (e.Type.Identifier, e.Amplifier, e.ShowParticles));
        if (contents.Potion != null && PotionEffects.TryGetValue(contents.Potion.Identifier, out (Minecraft.Data.PotionEffectTypes.SimplePotionEffectType, int)[]? own)) {
            effects = own.Select(e => (e.Item1.Identifier, e.Item2, true)).Concat(effects);
        }
        return Opaque(EffectColour(effects) ?? defaultColour);
    }

    /// <summary><c>PotionContents.getColorOptional</c>: the visible effects' colours, weighted by amplifier plus one.</summary>
    private static int? EffectColour(IEnumerable<(Identifier Type, int Amplifier, bool Visible)> effects) {
        int red = 0, green = 0, blue = 0, totalWeight = 0;
        foreach ((Identifier type, int amplifier, bool visible) in effects) {
            if (!visible) {
                continue;
            }
            int colour = Entities.MobEffects.Get(type).Color;
            int weight = amplifier + 1;
            red += weight * (colour >> 16 & 0xFF);
            green += weight * (colour >> 8 & 0xFF);
            blue += weight * (colour & 0xFF);
            totalWeight += weight;
        }
        return totalWeight == 0 ? null : red / totalWeight << 16 | green / totalWeight << 8 | blue / totalWeight;
    }

    /// <summary>Each <c>Potions</c> entry's effects and their amplifiers; every one is visible.</summary>
    private static readonly Dictionary<Identifier, (Minecraft.Data.PotionEffectTypes.SimplePotionEffectType, int)[]> PotionEffects = new() {
        [Potion.Water.Identifier] = [],
        [Potion.Mundane.Identifier] = [],
        [Potion.Thick.Identifier] = [],
        [Potion.Awkward.Identifier] = [],
        [Potion.NightVision.Identifier] = [(PotionEffectType.NightVision, 0)],
        [Potion.LongNightVision.Identifier] = [(PotionEffectType.NightVision, 0)],
        [Potion.Invisibility.Identifier] = [(PotionEffectType.Invisibility, 0)],
        [Potion.LongInvisibility.Identifier] = [(PotionEffectType.Invisibility, 0)],
        [Potion.Leaping.Identifier] = [(PotionEffectType.JumpBoost, 0)],
        [Potion.LongLeaping.Identifier] = [(PotionEffectType.JumpBoost, 0)],
        [Potion.StrongLeaping.Identifier] = [(PotionEffectType.JumpBoost, 1)],
        [Potion.FireResistance.Identifier] = [(PotionEffectType.FireResistance, 0)],
        [Potion.LongFireResistance.Identifier] = [(PotionEffectType.FireResistance, 0)],
        [Potion.Swiftness.Identifier] = [(PotionEffectType.Speed, 0)],
        [Potion.LongSwiftness.Identifier] = [(PotionEffectType.Speed, 0)],
        [Potion.StrongSwiftness.Identifier] = [(PotionEffectType.Speed, 1)],
        [Potion.Slowness.Identifier] = [(PotionEffectType.Slowness, 0)],
        [Potion.LongSlowness.Identifier] = [(PotionEffectType.Slowness, 0)],
        [Potion.StrongSlowness.Identifier] = [(PotionEffectType.Slowness, 3)],
        [Potion.TurtleMaster.Identifier] = [(PotionEffectType.Slowness, 3), (PotionEffectType.Resistance, 2)],
        [Potion.LongTurtleMaster.Identifier] = [(PotionEffectType.Slowness, 3), (PotionEffectType.Resistance, 2)],
        [Potion.StrongTurtleMaster.Identifier] = [(PotionEffectType.Slowness, 5), (PotionEffectType.Resistance, 3)],
        [Potion.WaterBreathing.Identifier] = [(PotionEffectType.WaterBreathing, 0)],
        [Potion.LongWaterBreathing.Identifier] = [(PotionEffectType.WaterBreathing, 0)],
        [Potion.Healing.Identifier] = [(PotionEffectType.InstantHealth, 0)],
        [Potion.StrongHealing.Identifier] = [(PotionEffectType.InstantHealth, 1)],
        [Potion.Harming.Identifier] = [(PotionEffectType.InstantDamage, 0)],
        [Potion.StrongHarming.Identifier] = [(PotionEffectType.InstantDamage, 1)],
        [Potion.Poison.Identifier] = [(PotionEffectType.Poison, 0)],
        [Potion.LongPoison.Identifier] = [(PotionEffectType.Poison, 0)],
        [Potion.StrongPoison.Identifier] = [(PotionEffectType.Poison, 1)],
        [Potion.Regeneration.Identifier] = [(PotionEffectType.Regeneration, 0)],
        [Potion.LongRegeneration.Identifier] = [(PotionEffectType.Regeneration, 0)],
        [Potion.StrongRegeneration.Identifier] = [(PotionEffectType.Regeneration, 1)],
        [Potion.Strength.Identifier] = [(PotionEffectType.Strength, 0)],
        [Potion.LongStrength.Identifier] = [(PotionEffectType.Strength, 0)],
        [Potion.StrongStrength.Identifier] = [(PotionEffectType.Strength, 1)],
        [Potion.Weakness.Identifier] = [(PotionEffectType.Weakness, 0)],
        [Potion.LongWeakness.Identifier] = [(PotionEffectType.Weakness, 0)],
        [Potion.Luck.Identifier] = [(PotionEffectType.Luck, 0)],
        [Potion.SlowFalling.Identifier] = [(PotionEffectType.SlowFalling, 0)],
        [Potion.LongSlowFalling.Identifier] = [(PotionEffectType.SlowFalling, 0)],
        [Potion.WindCharged.Identifier] = [(PotionEffectType.WindCharged, 0)],
        [Potion.Weaving.Identifier] = [(PotionEffectType.Weaving, 0)],
        [Potion.Oozing.Identifier] = [(PotionEffectType.Oozing, 0)],
        [Potion.Infested.Identifier] = [(PotionEffectType.Infested, 0)]
    };
}

/// <summary>
/// <c>NeedleDirectionHelper.Wobbler</c>: a needle that eases toward its target once a game tick, or one
/// that jumps straight to it when the property asks for no wobble.
/// </summary>
public sealed class NeedleWobbler(bool wobble, float factor) {
    private float _deltaRotation;
    private long _lastUpdateTick;

    public float Rotation { get; private set; }

    public bool ShouldUpdate(long tick) => !wobble || _lastUpdateTick != tick;

    public void Update(long tick, float targetRotation) {
        if (!wobble) {
            Rotation = targetRotation;
            return;
        }
        _lastUpdateTick = tick;
        float tempDeltaRotation = PositiveModulo(targetRotation - Rotation + 0.5F, 1.0F) - 0.5F;
        _deltaRotation += tempDeltaRotation * 0.1F;
        _deltaRotation *= factor;
        Rotation = PositiveModulo(Rotation + _deltaRotation, 1.0F);
    }

    /// <summary><c>Mth.positiveModulo(float)</c>.</summary>
    public static float PositiveModulo(float input, float mod) => (input % mod + mod) % mod;
}
