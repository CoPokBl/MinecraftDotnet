namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum AttachDirection {
    Floor,
    Wall,
    Ceiling
}

public static class AttachDirectionExtensions {
    public static AttachDirection FromString(string value) {
        return value switch {
            "floor" => AttachDirection.Floor,
            "wall" => AttachDirection.Wall,
            "ceiling" => AttachDirection.Ceiling,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for AttachDirection.")
        };
    }
    
    public static string ToName(this AttachDirection direction) {
        return direction switch {
            AttachDirection.Floor => "floor",
            AttachDirection.Wall => "wall",
            AttachDirection.Ceiling => "ceiling",
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown AttachDirection value.")
        };
    }
}
