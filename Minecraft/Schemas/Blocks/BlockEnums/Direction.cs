namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum Direction {
    North,
    South,
    East,
    West
}

public static class DirectionExtensions {
    public static Direction FromString(string value) {
        return value switch {
            "north" => Direction.North,
            "south" => Direction.South,
            "east" => Direction.East,
            "west" => Direction.West,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Direction.")
        };
    }
}
