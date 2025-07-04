namespace Minecraft.Schemas.BlockEnums;

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
}
