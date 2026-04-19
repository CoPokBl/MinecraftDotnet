namespace Minecraft.Data.DamageType;

public enum DamageScaling {
    Never,
    WhenCausedByLivingNonPlayer,
    Always
}

public static class DamageScalingExtensions {
    public static string ToProtocolString(this DamageScaling scaling) => scaling switch {
        DamageScaling.Never => "never",
        DamageScaling.WhenCausedByLivingNonPlayer => "when_caused_by_living_non_player",
        DamageScaling.Always => "always",
        _ => throw new ArgumentOutOfRangeException(nameof(scaling), scaling, null)
    };

    public static DamageScaling ParseDamageScaling(string value) => value switch {
        "never" => DamageScaling.Never,
        "when_caused_by_living_non_player" => DamageScaling.WhenCausedByLivingNonPlayer,
        "always" => DamageScaling.Always,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown damage scaling value")
    };
}
