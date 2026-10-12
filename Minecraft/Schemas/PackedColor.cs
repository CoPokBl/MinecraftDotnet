using NBT;
using NBT.Tags;

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

    /// <summary>
    /// <c>ExtraCodecs.STRING_RGB_COLOR</c>: the hex string, made opaque, or either form
    /// <see cref="RgbFromNbt"/> takes.
    /// </summary>
    public static int StringRgbFromNbt(INbtTag tag) {
        return tag is StringTag hex ? Parse(hex.Value) | unchecked((int)0xFF000000) : RgbFromNbt(tag);
    }

    /// <summary><c>ExtraCodecs.STRING_ARGB_COLOR</c>.</summary>
    public static int StringArgbFromNbt(INbtTag tag) {
        return tag is StringTag hex ? Parse(hex.Value) : ArgbFromNbt(tag);
    }

    /// <summary>
    /// <c>ExtraCodecs.RGB_COLOR_CODEC</c>: a packed number kept as sent, or three channels from 0 to
    /// 1 made opaque.
    /// </summary>
    public static int RgbFromNbt(INbtTag tag) {
        if (tag.IsNumber()) {
            return tag.AsInt();
        }

        INbtTag[] channels = Channels(tag, 3);
        return 0xFF << 24 | Channel(channels[0]) << 16 | Channel(channels[1]) << 8 | Channel(channels[2]);
    }

    /// <summary>
    /// <c>ExtraCodecs.ARGB_COLOR_CODEC</c>: a packed number, or red, green, blue and alpha from 0 to 1.
    /// </summary>
    public static int ArgbFromNbt(INbtTag tag) {
        if (tag.IsNumber()) {
            return tag.AsInt();
        }

        INbtTag[] channels = Channels(tag, 4);
        return Channel(channels[3]) << 24 | Channel(channels[0]) << 16 | Channel(channels[1]) << 8
               | Channel(channels[2]);
    }

    private static INbtTag[] Channels(INbtTag tag, int count) {
        INbtTag[] channels = tag.AsList();
        if (channels.Length != count) {
            throw new InvalidCastException($"Expected a colour of {count} channels, got {channels.Length}.");
        }

        return channels;
    }

    /// <summary><c>ARGB.as8BitChannel</c>, masked the way <c>ARGB.color</c> masks it.</summary>
    private static int Channel(INbtTag tag) {
        return Mth.Floor(tag.AsFloat() * 255.0F) & 0xFF;
    }
}
