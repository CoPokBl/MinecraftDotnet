namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum BedPart {
    Head,
    Foot
}

public static class BedPartExtensions {
    public static BedPart FromString(string value) {
        return value switch {
            "head" => BedPart.Head,
            "foot" => BedPart.Foot,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for BedPart.")
        };
    }
    
    public static string ToName(this BedPart part) {
        return part switch {
            BedPart.Head => "head",
            BedPart.Foot => "foot",
            _ => throw new ArgumentOutOfRangeException(nameof(part), part, "Unknown BedPart value.")
        };
    }
}
