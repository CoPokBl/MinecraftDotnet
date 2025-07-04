namespace Minecraft.Schemas.BlockEnums;

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
}
