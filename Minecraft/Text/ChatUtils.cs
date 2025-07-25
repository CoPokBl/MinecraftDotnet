namespace Minecraft.Text;

public static class ChatUtils {
    
    public static string FormatLegacy(string str, char colorChar = '&') {
        return str.Replace(colorChar, TextComponent.LegacyColorCodePrefix);
    }
}
