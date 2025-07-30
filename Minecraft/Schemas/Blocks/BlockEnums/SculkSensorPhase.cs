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
    
    public static string ToName(this SculkSensorPhase phase) {
        return phase switch {
            SculkSensorPhase.Inactive => "inactive",
            SculkSensorPhase.Active => "active",
            SculkSensorPhase.Cooldown => "cooldown",
            _ => throw new ArgumentOutOfRangeException(nameof(phase), phase, "Unknown SculkSensorPhase value.")
        };
    }
}
