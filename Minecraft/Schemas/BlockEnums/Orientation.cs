namespace Minecraft.Schemas.BlockEnums;

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
}
