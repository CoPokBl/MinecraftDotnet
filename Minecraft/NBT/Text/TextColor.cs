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
    
    public string ToHex() {
        return $"#{R:X2}{G:X2}{B:X2}";
    }
}