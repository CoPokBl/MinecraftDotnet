namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// <c>attachment</c> on the bell, vanilla's <c>BellAttachType</c>. The two wall forms are what let a
/// bell hung between two walls survive losing one of them, so they are not interchangeable.
/// </summary>
public enum BellAttachType {
    Floor,
    Ceiling,
    SingleWall,
    DoubleWall
}

public static class BellAttachTypeExtensions {
    public static BellAttachType FromString(string value) {
        return value switch {
            "floor" => BellAttachType.Floor,
            "ceiling" => BellAttachType.Ceiling,
            "single_wall" => BellAttachType.SingleWall,
            "double_wall" => BellAttachType.DoubleWall,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for BellAttachType.")
        };
    }
    
    public static string ToName(this BellAttachType attachment) {
        return attachment switch {
            BellAttachType.Floor => "floor",
            BellAttachType.Ceiling => "ceiling",
            BellAttachType.SingleWall => "single_wall",
            BellAttachType.DoubleWall => "double_wall",
            _ => throw new ArgumentOutOfRangeException(nameof(attachment), attachment, "Unknown BellAttachType value.")
        };
    }
}
