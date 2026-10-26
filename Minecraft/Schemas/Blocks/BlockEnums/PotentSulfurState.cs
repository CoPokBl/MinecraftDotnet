namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// <c>potent_sulfur_state</c>, vanilla's <c>PotentSulfurState</c>.
/// </summary>
public enum PotentSulfurState {
    Dry,
    Wet,
    Dormant,
    Erupting,
    Continuous
}

public static class PotentSulfurStateExtensions {
    public static PotentSulfurState FromString(string value) {
        return value switch {
            "dry" => PotentSulfurState.Dry,
            "wet" => PotentSulfurState.Wet,
            "dormant" => PotentSulfurState.Dormant,
            "erupting" => PotentSulfurState.Erupting,
            "continuous" => PotentSulfurState.Continuous,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for PotentSulfurState.")
        };
    }
    
    public static string ToName(this PotentSulfurState state) {
        return state switch {
            PotentSulfurState.Dry => "dry",
            PotentSulfurState.Wet => "wet",
            PotentSulfurState.Dormant => "dormant",
            PotentSulfurState.Erupting => "erupting",
            PotentSulfurState.Continuous => "continuous",
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown PotentSulfurState value.")
        };
    }
}
