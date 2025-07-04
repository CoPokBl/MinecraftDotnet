namespace Minecraft.Schemas.BlockEnums;

public enum LeftRight {
    Left,
    Right
}

public static class LeftRightExtensions {
    public static LeftRight FromString(string value) {
        return value switch {
            "left" => LeftRight.Left,
            "right" => LeftRight.Right,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for LeftRight.")
        };
    }
}
