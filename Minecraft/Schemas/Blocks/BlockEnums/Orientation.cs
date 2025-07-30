namespace Minecraft.Schemas.Blocks.BlockEnums;

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
