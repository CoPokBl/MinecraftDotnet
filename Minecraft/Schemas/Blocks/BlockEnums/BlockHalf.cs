namespace Minecraft.Schemas.Blocks.BlockEnums;

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
    
    public static string ToName(this BlockHalf half) {
        return half switch {
            BlockHalf.Upper => "upper",
            BlockHalf.Lower => "lower",
            _ => throw new ArgumentOutOfRangeException(nameof(half), half, "Unknown BlockHalf value.")
        };
    }
}
