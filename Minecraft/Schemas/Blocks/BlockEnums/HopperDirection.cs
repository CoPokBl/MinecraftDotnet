namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// The five ways a hopper may point: down, or any of the four horizontals.
/// </summary>
/// <remarks>
/// Its own type rather than a <see cref="Cardinal"/> because up is missing, and a hopper pointing up
/// is a state that does not exist rather than one nothing places.
/// </remarks>
public enum HopperDirection {
    Down,
    North,
    South,
    West,
    East
}

public static class HopperDirectionExtensions {
    public static HopperDirection FromString(string value) {
        return value switch {
            "down" => HopperDirection.Down,
            "north" => HopperDirection.North,
            "south" => HopperDirection.South,
            "west" => HopperDirection.West,
            "east" => HopperDirection.East,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value,
                "Unknown value for HopperDirection.")
        };
    }

    public static string ToName(this HopperDirection direction) {
        return direction switch {
            HopperDirection.Down => "down",
            HopperDirection.North => "north",
            HopperDirection.South => "south",
            HopperDirection.West => "west",
            HopperDirection.East => "east",
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction,
                "Unknown HopperDirection value.")
        };
    }

    /// <summary>The face the hopper points at, which is what a rotation moves.</summary>
    public static BlockFace ToFace(this HopperDirection direction) {
        return direction switch {
            HopperDirection.Down => BlockFace.NegY,
            HopperDirection.North => BlockFace.NegZ,
            HopperDirection.South => BlockFace.PosZ,
            HopperDirection.West => BlockFace.NegX,
            _ => BlockFace.PosX
        };
    }

    /// <summary>
    /// The hopper direction for a face. Throws for up, which no hopper state has.
    /// </summary>
    public static HopperDirection FromFace(BlockFace face) {
        return face switch {
            BlockFace.NegY => HopperDirection.Down,
            BlockFace.NegZ => HopperDirection.North,
            BlockFace.PosZ => HopperDirection.South,
            BlockFace.NegX => HopperDirection.West,
            BlockFace.PosX => HopperDirection.East,
            _ => throw new ArgumentOutOfRangeException(nameof(face), face,
                "A hopper cannot point up.")
        };
    }
}
