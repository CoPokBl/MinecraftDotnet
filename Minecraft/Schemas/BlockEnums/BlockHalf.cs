namespace Minecraft.Schemas.BlockEnums;

public enum BlockHalf {
    Upper,
    Lower
}

public static class BlockHalfExtensions {
    public static BlockHalf FromString(string value) {
        return value switch {
            "upper" => BlockHalf.Upper,
            "lower" => BlockHalf.Lower,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for BlockHalf.")
        };
    }
}
