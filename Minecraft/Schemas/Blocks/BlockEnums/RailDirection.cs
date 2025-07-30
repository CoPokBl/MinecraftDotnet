namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum RailDirection {
    NorthSouth,
    EastWest,
    AscendingEast,
    AscendingWest,
    AscendingNorth,
    AscendingSouth
}

public static class RailDirectionExtensions {
    public static RailDirection FromString(string value) {
        return value switch {
            "north_south" => RailDirection.NorthSouth,
            "east_west" => RailDirection.EastWest,
            "ascending_east" => RailDirection.AscendingEast,
            "ascending_west" => RailDirection.AscendingWest,
            "ascending_north" => RailDirection.AscendingNorth,
            "ascending_south" => RailDirection.AscendingSouth,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for RailDirection.")
        };
    }
    
    public static string ToName(this RailDirection direction) {
        return direction switch {
            RailDirection.NorthSouth => "north_south",
            RailDirection.EastWest => "east_west",
            RailDirection.AscendingEast => "ascending_east",
            RailDirection.AscendingWest => "ascending_west",
            RailDirection.AscendingNorth => "ascending_north",
            RailDirection.AscendingSouth => "ascending_south",
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown RailDirection value.")
        };
    }
}
