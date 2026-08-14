namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// <c>creaking_heart_state</c>, vanilla's <c>CreakingHeartState</c>. Whether the heart is part of a
/// live pale oak, and it is recomputed from the logs above and below it.
/// </summary>
public enum CreakingHeartState {
    Uprooted,
    Dormant,
    Awake
}

public static class CreakingHeartStateExtensions {
    public static CreakingHeartState FromString(string value) {
        return value switch {
            "uprooted" => CreakingHeartState.Uprooted,
            "dormant" => CreakingHeartState.Dormant,
            "awake" => CreakingHeartState.Awake,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for CreakingHeartState.")
        };
    }
    
    public static string ToName(this CreakingHeartState state) {
        return state switch {
            CreakingHeartState.Uprooted => "uprooted",
            CreakingHeartState.Dormant => "dormant",
            CreakingHeartState.Awake => "awake",
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown CreakingHeartState value.")
        };
    }
}
