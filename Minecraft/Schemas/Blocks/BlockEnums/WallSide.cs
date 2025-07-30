namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum WallSide {
    None,
    Low,
    Tall
}

public static class WallSideExtensions {
    public static WallSide FromString(string value) {
        return value switch {
            "none" => WallSide.None,
            "low" => WallSide.Low,
            "tall" => WallSide.Tall,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for WallSide.")
        };
    }
    
    public static string ToName(this WallSide side) {
        return side switch {
            WallSide.None => "none",
            WallSide.Low => "low",
            WallSide.Tall => "tall",
            _ => throw new ArgumentOutOfRangeException(nameof(side), side, "Unknown WallSide value.")
        };
    }
}
