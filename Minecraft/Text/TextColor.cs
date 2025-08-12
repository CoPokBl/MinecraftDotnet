namespace Minecraft.Text;

public readonly struct TextColor : IEquatable<TextColor> {
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }
    
    public static readonly TextColor Black = Hex("#000000");
    public static readonly TextColor DarkBlue = Hex("#0000AA");
    public static readonly TextColor DarkGreen = Hex("#00AA00");
    public static readonly TextColor DarkAqua = Hex("#00AAAA");
    public static readonly TextColor DarkRed = Hex("#AA0000");
    public static readonly TextColor DarkPurple = Hex("#AA00AA");
    public static readonly TextColor Gold = Hex("#FFAA00");
    public static readonly TextColor Gray = Hex("#AAAAAA");
    public static readonly TextColor DarkGray = Hex("#555555");
    public static readonly TextColor Blue = Hex("#5555FF");
    public static readonly TextColor Green = Hex("#55FF55");
    public static readonly TextColor Aqua = Hex("#55FFFF");
    public static readonly TextColor Red = Hex("#FF5555");
    public static readonly TextColor LightPurple = Hex("#FF55FF");
    public static readonly TextColor Yellow = Hex("#FFFF55");
    public static readonly TextColor White = Hex("#FFFFFF");

    private TextColor(byte r, byte g, byte b) {
        R = r;
        G = g;
        B = b;
    }

    public static TextColor Rgb(byte r, byte g, byte b) {
        return new TextColor(r, g, b);
    }
    
    public static TextColor Rgb(float r, float g, float b) {
        return new TextColor(
            (byte)(r * 255),
            (byte)(g * 255),
            (byte)(b * 255)
        );
    }
    
    public static TextColor Hex(string hex) {
        if (hex.Length != 6 && hex.Length != 7) {
            throw new ArgumentException("Hex color must be 6 or 7 characters long.");
        }

        if (hex[0] == '#') {
            hex = hex[1..];
        }
        
        byte r = Convert.ToByte(hex.Substring(0, 2), 16);
        byte g = Convert.ToByte(hex.Substring(2, 2), 16);
        byte b = Convert.ToByte(hex.Substring(4, 2), 16);
        
        return new TextColor(r, g, b);
    }

    public static TextColor Parse(string val) {
        switch (val) {
            case "black": return Black;
            case "dark_blue": return DarkBlue;
            case "dark_green": return DarkGreen;
            case "dark_aqua": return DarkAqua;
            case "dark_red": return DarkRed;
            case "dark_purple": return DarkPurple;
            case "gold": return Gold;
            case "gray": return Gray;
            case "dark_gray": return DarkGray;
            case "blue": return Blue;
            case "green": return Green;
            case "aqua": return Aqua;
            case "red": return Red;
            case "light_purple": return LightPurple;
            case "yellow": return Yellow;
            case "white": return White;
        }
        
        // maybe it's hex
        if (val[0] != '#') {
            throw new ArgumentException("Invalid color format.", nameof(val));
        }
        
        return Hex(val);
    }

    public static TextColor FromNamedTextColor(NamedTextColor color) => color switch {
        NamedTextColor.Black => Black,
        NamedTextColor.DarkBlue => DarkBlue,
        NamedTextColor.DarkGreen => DarkGreen,
        NamedTextColor.DarkAqua => DarkAqua,
        NamedTextColor.DarkRed => DarkRed,
        NamedTextColor.DarkPurple => DarkPurple,
        NamedTextColor.Gold => Gold,
        NamedTextColor.Gray => Gray,
        NamedTextColor.DarkGray => DarkGray,
        NamedTextColor.Blue => Blue,
        NamedTextColor.Green => Green,
        NamedTextColor.Aqua => Aqua,
        NamedTextColor.Red => Red,
        NamedTextColor.LightPurple => LightPurple,
        NamedTextColor.Yellow => Yellow,
        NamedTextColor.White => White,
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public static TextColor FromDecimal(int val) {
        if (val is < 0 or > 0xFFFFFF) {
            throw new ArgumentOutOfRangeException(nameof(val), "Value must be between 0 and 0xFFFFFF.");
        }
        
        byte r = (byte)((val >> 16) & 0xFF);
        byte g = (byte)((val >> 8) & 0xFF);
        byte b = (byte)(val & 0xFF);
        
        return new TextColor(r, g, b);
    }
    
    public string ToHex() {
        return $"#{R:X2}{G:X2}{B:X2}";
    }

    public int ToDecimal() {
        return (R << 16) + (G << 8) + B;
    }

    public bool Equals(TextColor other) {
        return R == other.R && G == other.G && B == other.B;
    }

    public override bool Equals(object? obj) {
        return obj is TextColor other && Equals(other);
    }

    public override int GetHashCode() {
        return ToDecimal();
    }

    public static bool operator ==(TextColor left, TextColor right) {
        return left.Equals(right);
    }

    public static bool operator !=(TextColor left, TextColor right) {
        return !(left == right);
    }
}
