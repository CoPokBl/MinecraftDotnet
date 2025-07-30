namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum SlabType {
    Top,
    Bottom,
    Double
}

public static class SlabTypeExtensions {
    public static SlabType FromString(string value) {
        return value switch {
            "top" => SlabType.Top,
            "bottom" => SlabType.Bottom,
            "double" => SlabType.Double,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for SlabType.")
        };
    }
    
    public static string ToName(this SlabType slabType) {
        return slabType switch {
            SlabType.Top => "top",
            SlabType.Bottom => "bottom",
            SlabType.Double => "double",
            _ => throw new ArgumentOutOfRangeException(nameof(slabType), slabType, "Unknown SlabType value.")
        };
    }
}
