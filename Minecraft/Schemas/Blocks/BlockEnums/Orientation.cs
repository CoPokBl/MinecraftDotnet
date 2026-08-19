namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// <c>FrontAndTop</c>: the twelve ways a block can face when it has a top as well as a front.
/// </summary>
/// <remarks>
/// The name reads front then top, so <see cref="DownEast"/> faces down with its top pointing east.
/// Only twelve of the 36 pairs exist, because the two directions have to be perpendicular.
/// </remarks>
public enum Orientation {
    DownEast,
    DownNorth,
    DownSouth,
    DownWest,
    UpEast,
    UpNorth,
    UpSouth,
    UpWest,
    WestUp,
    EastUp,
    NorthUp,
    SouthUp
}

public static class OrientationExtensions {
    public static Orientation FromString(string value) {
        return value switch {
            "down_east" => Orientation.DownEast,
            "down_north" => Orientation.DownNorth,
            "down_south" => Orientation.DownSouth,
            "down_west" => Orientation.DownWest,
            "up_east" => Orientation.UpEast,
            "up_north" => Orientation.UpNorth,
            "up_south" => Orientation.UpSouth,
            "up_west" => Orientation.UpWest,
            "west_up" => Orientation.WestUp,
            "east_up" => Orientation.EastUp,
            "north_up" => Orientation.NorthUp,
            "south_up" => Orientation.SouthUp,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Orientation.")
        };
    }
    
    public static string ToName(this Orientation orientation) {
        return orientation switch {
            Orientation.DownEast => "down_east",
            Orientation.DownNorth => "down_north",
            Orientation.DownSouth => "down_south",
            Orientation.DownWest => "down_west",
            Orientation.UpEast => "up_east",
            Orientation.UpNorth => "up_north",
            Orientation.UpSouth => "up_south",
            Orientation.UpWest => "up_west",
            Orientation.WestUp => "west_up",
            Orientation.EastUp => "east_up",
            Orientation.NorthUp => "north_up",
            Orientation.SouthUp => "south_up",
            _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation, "Unknown Orientation value.")
        };
    }
}

/// <summary>
/// The two directions an <see cref="Orientation"/> is made of, and the pair put back together.
/// </summary>
/// <remarks>
/// Vanilla builds the reverse lookup as a table indexed by both ordinals. There are twelve values, so
/// this is a switch instead, and a pair that is not one of them throws rather than answering a
/// neighbouring orientation.
/// </remarks>
public static class Orientations {
    /// <summary><c>FrontAndTop.front</c> and <c>FrontAndTop.top</c>.</summary>
    public static (BlockFace Front, BlockFace Top) Split(Orientation orientation) {
        return orientation switch {
            Orientation.DownEast => (BlockFace.NegY, BlockFace.PosX),
            Orientation.DownNorth => (BlockFace.NegY, BlockFace.NegZ),
            Orientation.DownSouth => (BlockFace.NegY, BlockFace.PosZ),
            Orientation.DownWest => (BlockFace.NegY, BlockFace.NegX),
            Orientation.UpEast => (BlockFace.PosY, BlockFace.PosX),
            Orientation.UpNorth => (BlockFace.PosY, BlockFace.NegZ),
            Orientation.UpSouth => (BlockFace.PosY, BlockFace.PosZ),
            Orientation.UpWest => (BlockFace.PosY, BlockFace.NegX),
            Orientation.WestUp => (BlockFace.NegX, BlockFace.PosY),
            Orientation.EastUp => (BlockFace.PosX, BlockFace.PosY),
            Orientation.NorthUp => (BlockFace.NegZ, BlockFace.PosY),
            Orientation.SouthUp => (BlockFace.PosZ, BlockFace.PosY),
            _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation,
                "Unknown Orientation value.")
        };
    }

    /// <summary><c>FrontAndTop.fromFrontAndTop</c>.</summary>
    public static Orientation Join(BlockFace front, BlockFace top) {
        return (front, top) switch {
            (BlockFace.NegY, BlockFace.PosX) => Orientation.DownEast,
            (BlockFace.NegY, BlockFace.NegZ) => Orientation.DownNorth,
            (BlockFace.NegY, BlockFace.PosZ) => Orientation.DownSouth,
            (BlockFace.NegY, BlockFace.NegX) => Orientation.DownWest,
            (BlockFace.PosY, BlockFace.PosX) => Orientation.UpEast,
            (BlockFace.PosY, BlockFace.NegZ) => Orientation.UpNorth,
            (BlockFace.PosY, BlockFace.PosZ) => Orientation.UpSouth,
            (BlockFace.PosY, BlockFace.NegX) => Orientation.UpWest,
            (BlockFace.NegX, BlockFace.PosY) => Orientation.WestUp,
            (BlockFace.PosX, BlockFace.PosY) => Orientation.EastUp,
            (BlockFace.NegZ, BlockFace.PosY) => Orientation.NorthUp,
            (BlockFace.PosZ, BlockFace.PosY) => Orientation.SouthUp,
            _ => throw new ArgumentOutOfRangeException(nameof(front),
                $"[{front}, {top}] is not one of the twelve orientations.")
        };
    }
}
