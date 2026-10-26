using Minecraft.Data.Generated;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Schemas;

namespace ClientLib.Entities;

public enum MobEffectCategory {
    Beneficial,
    Harmful,
    Neutral
}

/// <summary>What a <c>MobEffect</c> is registered with that the client reads: its category, colour and fade.</summary>
public sealed record MobEffect(MobEffectCategory Category, int Color, int BlendInDurationTicks = 0, int BlendOutDurationTicks = 0, int BlendOutAdvanceTicks = 0) {
    public bool IsBeneficial => Category == MobEffectCategory.Beneficial;

    /// <summary><c>getDescriptionId</c>: <c>effect.minecraft.speed</c>.</summary>
    public static string DescriptionId(IPotionEffectType effect) => $"effect.{effect.Identifier.Namespace}.{effect.Identifier.Key}";
}

/// <summary>The <c>MobEffects</c> registrations.</summary>
public static class MobEffects {
    private static readonly MobEffect Unknown = new(MobEffectCategory.Neutral, 0);

    private static readonly Dictionary<Identifier, MobEffect> Registered = new() {
        [PotionEffectType.Speed.Identifier] = new(MobEffectCategory.Beneficial, 0x33EBFF),
        [PotionEffectType.Slowness.Identifier] = new(MobEffectCategory.Harmful, 0x8BAFE0),
        [PotionEffectType.Haste.Identifier] = new(MobEffectCategory.Beneficial, 0xD9C043),
        [PotionEffectType.MiningFatigue.Identifier] = new(MobEffectCategory.Harmful, 0x4A4217),
        [PotionEffectType.Strength.Identifier] = new(MobEffectCategory.Beneficial, 0xFFC700),
        [PotionEffectType.InstantHealth.Identifier] = new(MobEffectCategory.Beneficial, 0xF82423),
        [PotionEffectType.InstantDamage.Identifier] = new(MobEffectCategory.Harmful, 0xA9656A),
        [PotionEffectType.JumpBoost.Identifier] = new(MobEffectCategory.Beneficial, 0xFDFF84),
        [PotionEffectType.Nausea.Identifier] = new(MobEffectCategory.Harmful, 0x551D4A, 150, 20, 60),
        [PotionEffectType.Regeneration.Identifier] = new(MobEffectCategory.Beneficial, 0xCD5CAB),
        [PotionEffectType.Resistance.Identifier] = new(MobEffectCategory.Beneficial, 0x9146F0),
        [PotionEffectType.FireResistance.Identifier] = new(MobEffectCategory.Beneficial, 0xFF9900),
        [PotionEffectType.WaterBreathing.Identifier] = new(MobEffectCategory.Beneficial, 0x98DAC0),
        [PotionEffectType.Invisibility.Identifier] = new(MobEffectCategory.Beneficial, 0xF6F6F6),
        [PotionEffectType.Blindness.Identifier] = new(MobEffectCategory.Harmful, 0x1F1F23),
        [PotionEffectType.NightVision.Identifier] = new(MobEffectCategory.Beneficial, 0xC2FF66),
        [PotionEffectType.Hunger.Identifier] = new(MobEffectCategory.Harmful, 0x587653),
        [PotionEffectType.Weakness.Identifier] = new(MobEffectCategory.Harmful, 0x484D48),
        [PotionEffectType.Poison.Identifier] = new(MobEffectCategory.Harmful, 0x87A363),
        [PotionEffectType.Wither.Identifier] = new(MobEffectCategory.Harmful, 0x736156),
        [PotionEffectType.HealthBoost.Identifier] = new(MobEffectCategory.Beneficial, 0xF87D23),
        [PotionEffectType.Absorption.Identifier] = new(MobEffectCategory.Beneficial, 0x2552A5),
        [PotionEffectType.Saturation.Identifier] = new(MobEffectCategory.Beneficial, 0xF82423),
        [PotionEffectType.Glowing.Identifier] = new(MobEffectCategory.Neutral, 0x94A061),
        [PotionEffectType.Levitation.Identifier] = new(MobEffectCategory.Harmful, 0xCEFFFF),
        [PotionEffectType.Luck.Identifier] = new(MobEffectCategory.Beneficial, 0x59C106),
        [PotionEffectType.Unluck.Identifier] = new(MobEffectCategory.Harmful, 0xC0A44D),
        [PotionEffectType.SlowFalling.Identifier] = new(MobEffectCategory.Beneficial, 0xF3CFB9),
        [PotionEffectType.ConduitPower.Identifier] = new(MobEffectCategory.Beneficial, 0x1DC2D1),
        [PotionEffectType.DolphinsGrace.Identifier] = new(MobEffectCategory.Beneficial, 0x88A3BE),
        [PotionEffectType.BadOmen.Identifier] = new(MobEffectCategory.Neutral, 0x0B6138),
        [PotionEffectType.HeroOfTheVillage.Identifier] = new(MobEffectCategory.Beneficial, 0x44FF44),
        [PotionEffectType.Darkness.Identifier] = new(MobEffectCategory.Harmful, 0x292721, 22, 22, 22),
        [PotionEffectType.TrialOmen.Identifier] = new(MobEffectCategory.Neutral, 0x16A6A6),
        [PotionEffectType.RaidOmen.Identifier] = new(MobEffectCategory.Neutral, 0xDE4058),
        [PotionEffectType.WindCharged.Identifier] = new(MobEffectCategory.Harmful, 0xBDC9FF),
        [PotionEffectType.Weaving.Identifier] = new(MobEffectCategory.Harmful, 0x78695A),
        [PotionEffectType.Oozing.Identifier] = new(MobEffectCategory.Harmful, 0x99FFA3),
        [PotionEffectType.Infested.Identifier] = new(MobEffectCategory.Harmful, 0x8C9B8C),
        [PotionEffectType.BreathOfTheNautilus.Identifier] = new(MobEffectCategory.Beneficial, 0x00FFEE)
    };

    public static MobEffect Get(IPotionEffectType effect) => Get(effect.Identifier);

    public static MobEffect Get(Identifier effect) => Registered.GetValueOrDefault(effect, Unknown);
}

public static class MobEffectUtil {
    /// <summary><c>MobEffectUtil.formatDuration</c> over <c>StringUtil.formatTickDuration</c>.</summary>
    public static string FormatDuration(MobEffectInstance instance, float scale, float tickRate) {
        if (instance.IsInfiniteDuration) {
            return Translations.Get("effect.duration.infinite")!;
        }
        int ticks = (int)Math.Floor(instance.Duration * scale);
        int seconds = (int)Math.Floor(ticks / tickRate);
        int minutes = seconds / 60;
        seconds %= 60;
        int hours = minutes / 60;
        minutes %= 60;
        return hours > 0 ? $"{hours:00}:{minutes:00}:{seconds:00}" : $"{minutes:00}:{seconds:00}";
    }
}
