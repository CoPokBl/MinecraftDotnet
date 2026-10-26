namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// <c>shape</c> on the plain rail, vanilla's <c>RailShape</c>. The four curves are what separates it
/// from <see cref="RailDirection"/>, which is the same enum narrowed to the six a powered, detector
/// or activator rail can take (vanilla's <c>RAIL_SHAPE_STRAIGHT</c>).
/// </summary>
public enum RailShape {
    NorthSouth,
    EastWest,
    AscendingEast,
    AscendingWest,
    AscendingNorth,
    AscendingSouth,
    SouthEast,
    SouthWest,
    NorthWest,
    NorthEast
}

public static class RailShapeExtensions {
    public static RailShape FromString(string value) {
        return value switch {
            "north_south" => RailShape.NorthSouth,
            "east_west" => RailShape.EastWest,
            "ascending_east" => RailShape.AscendingEast,
            "ascending_west" => RailShape.AscendingWest,
            "ascending_north" => RailShape.AscendingNorth,
            "ascending_south" => RailShape.AscendingSouth,
            "south_east" => RailShape.SouthEast,
            "south_west" => RailShape.SouthWest,
            "north_west" => RailShape.NorthWest,
            "north_east" => RailShape.NorthEast,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for RailShape.")
        };
    }
    
    public static string ToName(this RailShape railShape) {
        return railShape switch {
            RailShape.NorthSouth => "north_south",
            RailShape.EastWest => "east_west",
            RailShape.AscendingEast => "ascending_east",
            RailShape.AscendingWest => "ascending_west",
            RailShape.AscendingNorth => "ascending_north",
            RailShape.AscendingSouth => "ascending_south",
            RailShape.SouthEast => "south_east",
            RailShape.SouthWest => "south_west",
            RailShape.NorthWest => "north_west",
            RailShape.NorthEast => "north_east",
            _ => throw new ArgumentOutOfRangeException(nameof(railShape), railShape, "Unknown RailShape value.")
        };
    }
}
