namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum SculkSensorPhase {
    Inactive,
    Active,
    Cooldown
}

public static class SculkSensorPhaseExtensions {
    public static SculkSensorPhase FromString(string value) {
        return value switch {
            "inactive" => SculkSensorPhase.Inactive,
            "active" => SculkSensorPhase.Active,
            "cooldown" => SculkSensorPhase.Cooldown,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for SculkSensorPhase.")
        };
    }
}
