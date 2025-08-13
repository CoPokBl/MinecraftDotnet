namespace Minecraft.Text;

public enum NamedTextColor {
    Black,
    DarkBlue,
    DarkGreen,
    DarkAqua,
    DarkRed,
    DarkPurple,
    Gold,
    Gray,
    DarkGray,
    Blue,
    Green,
    Aqua,
    Red,
    LightPurple,
    Yellow,
    White
}

public static class NamedTextColorExtensions {
    public static TextColor ToTextColor(this NamedTextColor color) {
        return color switch {
            NamedTextColor.Black => TextColor.Black,
            NamedTextColor.DarkBlue => TextColor.DarkBlue,
            NamedTextColor.DarkGreen => TextColor.DarkGreen,
            NamedTextColor.DarkAqua => TextColor.DarkAqua,
            NamedTextColor.DarkRed => TextColor.DarkRed,
            NamedTextColor.DarkPurple => TextColor.DarkPurple,
            NamedTextColor.Gold => TextColor.Gold,
            NamedTextColor.Gray => TextColor.Gray,
            NamedTextColor.DarkGray => TextColor.DarkGray,
            NamedTextColor.Blue => TextColor.Blue,
            NamedTextColor.Green => TextColor.Green,
            NamedTextColor.Aqua => TextColor.Aqua,
            NamedTextColor.Red => TextColor.Red,
            NamedTextColor.LightPurple => TextColor.LightPurple,
            NamedTextColor.Yellow => TextColor.Yellow,
            NamedTextColor.White => TextColor.White,
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
        };
    }
    
    public static string GetName(this NamedTextColor color) {
        return color switch {
            NamedTextColor.Black => "black",
            NamedTextColor.DarkBlue => "dark_blue",
            NamedTextColor.DarkGreen => "dark_green",
            NamedTextColor.DarkAqua => "dark_aqua",
            NamedTextColor.DarkRed => "dark_red",
            NamedTextColor.DarkPurple => "dark_purple",
            NamedTextColor.Gold => "gold",
            NamedTextColor.Gray => "gray",
            NamedTextColor.DarkGray => "dark_gray",
            NamedTextColor.Blue => "blue",
            NamedTextColor.Green => "green",
            NamedTextColor.Aqua => "aqua",
            NamedTextColor.Red => "red",
            NamedTextColor.LightPurple => "light_purple",
            NamedTextColor.Yellow => "yellow",
            NamedTextColor.White => "white",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
        };
    }

    public static NamedTextColor FromName(string name) {
        return name.ToLowerInvariant() switch {
            "black" => NamedTextColor.Black,
            "dark_blue" => NamedTextColor.DarkBlue,
            "dark_green" => NamedTextColor.DarkGreen,
            "dark_aqua" => NamedTextColor.DarkAqua,
            "dark_red" => NamedTextColor.DarkRed,
            "dark_purple" => NamedTextColor.DarkPurple,
            "gold" => NamedTextColor.Gold,
            "gray" => NamedTextColor.Gray,
            "dark_gray" => NamedTextColor.DarkGray,
            "blue" => NamedTextColor.Blue,
            "green" => NamedTextColor.Green,
            "aqua" => NamedTextColor.Aqua,
            "red" => NamedTextColor.Red,
            "light_purple" => NamedTextColor.LightPurple,
            "yellow" => NamedTextColor.Yellow,
            "white" => NamedTextColor.White,
            _ => throw new ArgumentException($"Unknown named text color: {name}", nameof(name))
        };
    }
}
