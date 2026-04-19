namespace Minecraft.Data.DamageType;

public enum DamageEffectType {
    Hurt,
    Thorns,
    Drowning,
    Burning,
    Poking,
    Freezing
}

public static class DamageEffectTypeExtensions {
    public static string ToProtocolString(this DamageEffectType effect) => effect switch {
        DamageEffectType.Hurt => "hurt",
        DamageEffectType.Thorns => "thorns",
        DamageEffectType.Drowning => "drowning",
        DamageEffectType.Burning => "burning",
        DamageEffectType.Poking => "poking",
        DamageEffectType.Freezing => "freezing",
        _ => throw new ArgumentOutOfRangeException(nameof(effect), effect, null)
    };

    public static DamageEffectType ParseDamageEffectType(string value) => value switch {
        "hurt" => DamageEffectType.Hurt,
        "thorns" => DamageEffectType.Thorns,
        "drowning" => DamageEffectType.Drowning,
        "burning" => DamageEffectType.Burning,
        "poking" => DamageEffectType.Poking,
        "freezing" => DamageEffectType.Freezing,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown damage effect type")
    };
}
