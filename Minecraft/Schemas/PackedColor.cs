namespace Minecraft.Schemas;

/// <summary>
/// Colours the way registry data writes them: a packed int, spelled as a lowercase hex string with
/// a leading <c>#</c>.
/// </summary>
/// <remarks>
/// <see cref="Minecraft.Text.TextColor"/> is the same idea for text components, but it writes
/// uppercase and has no room for alpha, so registry data can't go through it.
/// </remarks>
public static class PackedColor {

    /// <summary>Reads either width; the alpha byte is simply absent on the opaque form.</summary>
    public static int Parse(string value) {
        return (int)Convert.ToUInt32(value.TrimStart('#'), 16);
    }

    public static string ToRgbString(int color) {
        return $"#{color & 0xFFFFFF:x6}";
    }

    public static string ToArgbString(int color) {
        return $"#{(uint)color:x8}";
    }
}
