namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum Cardinal {
    North,
    East,
    South,
    West,
    Up,
    Down
}

public static class CardinalExtensions {
    public static Cardinal FromString(string value) {
        return value switch {
            "north" => Cardinal.North,
            "east" => Cardinal.East,
            "south" => Cardinal.South,
            "west" => Cardinal.West,
            "up" => Cardinal.Up,
            "down" => Cardinal.Down,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Cardinal.")
        };
    }
}
