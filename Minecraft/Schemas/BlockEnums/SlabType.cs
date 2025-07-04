namespace Minecraft.Schemas.BlockEnums;

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
}
