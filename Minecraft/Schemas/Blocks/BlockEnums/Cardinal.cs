namespace Minecraft.Schemas.Blocks.BlockEnums;

// IDs are used by EntityMeta, do not change them
public enum Cardinal {
    North = 2,
    East = 5,
    South = 3,
    West = 4,
    Up = 1,
    Down = 0
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
    
    public static string ToName(this Cardinal cardinal) {
        return cardinal switch {
            Cardinal.North => "north",
            Cardinal.East => "east",
            Cardinal.South => "south",
            Cardinal.West => "west",
            Cardinal.Up => "up",
            Cardinal.Down => "down",
            _ => throw new ArgumentOutOfRangeException(nameof(cardinal), cardinal, "Unknown Cardinal value.")
        };
    }
}
