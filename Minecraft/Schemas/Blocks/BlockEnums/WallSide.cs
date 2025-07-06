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
}
