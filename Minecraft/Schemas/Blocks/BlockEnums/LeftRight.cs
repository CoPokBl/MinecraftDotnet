namespace Minecraft.Schemas.Blocks.BlockEnums;

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
    
    public static string ToName(this LeftRight leftRight) {
        return leftRight switch {
            LeftRight.Left => "left",
            LeftRight.Right => "right",
            _ => throw new ArgumentOutOfRangeException(nameof(leftRight), leftRight, "Unknown LeftRight value.")
        };
    }
}
