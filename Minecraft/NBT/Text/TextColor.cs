namespace Minecraft.NBT.Text;

// TODO: Add from legacy colour codes function (eg. &r&lHello &cWorld!)
public class TextColor {
    public int R { get; }
    public int G { get; }
    public int B { get; }
    
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
    
    public const char LegacyColorCodePrefix = '§';  // Prefix char to specify a color in legacy text formats

    private TextColor(int r, int g, int b) {
        R = r;
        G = g;
        B = b;
    }

    public static TextColor Rgb(int r, int g, int b) {
        return new TextColor(r, g, b);
    }
    
    public static TextColor Rgb(float r, float g, float b) {
        return new TextColor(
            (int)(r * 255),
            (int)(g * 255),
            (int)(b * 255)
        );
    }
    
    public static TextColor Hex(string hex) {
        if (hex.Length != 6 && hex.Length != 7) {
            throw new ArgumentException("Hex color must be 6 or 7 characters long.");
        }

        if (hex[0] == '#') {
            hex = hex[1..];
        }
        
        int r = Convert.ToInt32(hex.Substring(0, 2), 16);
        int g = Convert.ToInt32(hex.Substring(2, 2), 16);
        int b = Convert.ToInt32(hex.Substring(4, 2), 16);
        
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

    public static TextColor FromDecimal(int val) {
        if (val is < 0 or > 0xFFFFFF) {
            throw new ArgumentOutOfRangeException(nameof(val), "Value must be between 0 and 0xFFFFFF.");
        }
        
        int r = (val >> 16) & 0xFF;
        int g = (val >> 8) & 0xFF;
        int b = val & 0xFF;
        
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
}