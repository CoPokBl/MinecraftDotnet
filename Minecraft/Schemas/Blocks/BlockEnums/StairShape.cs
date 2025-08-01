namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum StairShape {
    Straight,
    InnerLeft,
    InnerRight,
    OuterLeft,
    OuterRight
}

public static class StairShapeExtensions {
    public static StairShape FromString(string value) {
        return value switch {
            "straight" => StairShape.Straight,
            "inner_left" => StairShape.InnerLeft,
            "inner_right" => StairShape.InnerRight,
            "outer_left" => StairShape.OuterLeft,
            "outer_right" => StairShape.OuterRight,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for StairShape.")
        };
    }
    
    public static string ToName(this StairShape stairShape) {
        return stairShape switch {
            StairShape.Straight => "straight",
            StairShape.InnerLeft => "inner_left",
            StairShape.InnerRight => "inner_right",
            StairShape.OuterLeft => "outer_left",
            StairShape.OuterRight => "outer_right",
            _ => throw new ArgumentOutOfRangeException(nameof(stairShape), stairShape, "Unknown StairShape value.")
        };
    }
}
