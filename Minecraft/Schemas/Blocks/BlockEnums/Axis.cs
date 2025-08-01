namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum Axis {
    X,
    Y,
    Z
}

public static class AxisExtensions {
    public static Axis FromString(string value) {
        return value switch {
            "x" => Axis.X,
            "y" => Axis.Y,
            "z" => Axis.Z,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Axis.")
        };
    }
    
    public static string ToName(this Axis axis) {
        return axis switch {
            Axis.X => "x",
            Axis.Y => "y",
            Axis.Z => "z",
            _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, "Unknown Axis value.")
        };
    }
}
