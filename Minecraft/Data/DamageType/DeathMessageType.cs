namespace Minecraft.Data.DamageType;

public enum DeathMessageType {
    Default,
    FallVariants,
    IntentionalGameDesign
}

public static class DeathMessageTypeExtensions {
    public static string ToProtocolString(this DeathMessageType type) => type switch {
        DeathMessageType.Default => "default",
        DeathMessageType.FallVariants => "fall_variants",
        DeathMessageType.IntentionalGameDesign => "intentional_game_design",
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

    public static DeathMessageType ParseDeathMessageType(string value) => value switch {
        "default" => DeathMessageType.Default,
        "fall_variants" => DeathMessageType.FallVariants,
        "intentional_game_design" => DeathMessageType.IntentionalGameDesign,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown death message type")
    };
}
