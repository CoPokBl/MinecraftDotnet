using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ColorLerper</c>: a jeb_ sheep's wool cycles through every dye, and the now playing toast's notes through a dozen.</summary>
public static class ColorLerper {
    /// <summary><c>DyeColor.getTextureDiffuseColor</c>, opaque, by dye id.</summary>
    private static readonly uint[] TextureDiffuseColors = [
        0xFFF9FFFE, 0xFFF9801D, 0xFFC74EBD, 0xFF3AB3DA, 0xFFFED83D, 0xFF80C71F, 0xFFF38BAA, 0xFF474F52,
        0xFF9D9D97, 0xFF169C9C, 0xFF8932B8, 0xFF3C44AA, 0xFF835432, 0xFF5E7C16, 0xFFB02E26, 0xFF1D1D21
    ];

    private const int SheepColorDuration = 25;
    private const float SheepBrightness = 0.75F;

    private static readonly uint[] SheepColors = Enumerable.Range(0, 16).Select(id => GetModifiedColor((DyeColor)id, SheepBrightness)).ToArray();

    private const int MusicNoteColorDuration = 30;
    private const float MusicNoteBrightness = 1.25F;

    /// <summary><c>MUSIC_NOTE_COLORS</c>, in its order.</summary>
    private static readonly uint[] MusicNoteColors = new[] {
        DyeColor.White, DyeColor.LightGray, DyeColor.LightBlue, DyeColor.Blue, DyeColor.Cyan, DyeColor.Green,
        DyeColor.Lime, DyeColor.Yellow, DyeColor.Orange, DyeColor.Pink, DyeColor.Red, DyeColor.Magenta
    }.Select(color => GetModifiedColor(color, MusicNoteBrightness)).ToArray();

    /// <summary><c>ColorLerper.Type.SHEEP.getColor</c>.</summary>
    public static uint GetSheepColor(DyeColor color) => SheepColors[(int)color];

    /// <summary><c>ColorLerper.getLerpedColor</c> for <c>Type.SHEEP</c>.</summary>
    public static uint GetLerpedSheepColor(float tick) => GetLerpedColor(SheepColors, SheepColorDuration, tick);

    /// <summary><c>ColorLerper.getLerpedColor</c> for <c>Type.MUSIC_NOTE</c>.</summary>
    public static uint GetLerpedMusicNoteColor(float tick) => GetLerpedColor(MusicNoteColors, MusicNoteColorDuration, tick);

    private static uint GetLerpedColor(uint[] colors, int colorDuration, float tick) {
        int tickCount = Mth.Floor(tick);
        int value = tickCount / colorDuration;
        int colorCount = colors.Length;
        int c1 = value % colorCount;
        int c2 = (value + 1) % colorCount;
        float subStep = (tickCount % colorDuration + Mth.Frac(tick)) / colorDuration;
        return SrgbLerp(subStep, colors[c1], colors[c2]);
    }

    private static uint GetModifiedColor(DyeColor color, float brightness) {
        if (color == DyeColor.White) {
            return unchecked((uint)-1644826);
        }
        uint src = TextureDiffuseColors[(int)color];
        uint Channel(int shift) => (uint)Math.Clamp(Mth.Floor(((src >> shift) & 0xFF) * brightness), 0, 255);
        return 0xFF000000 | Channel(16) << 16 | Channel(8) << 8 | Channel(0);
    }

    /// <summary><c>ARGB.srgbLerp</c>.</summary>
    private static uint SrgbLerp(float alpha, uint p0, uint p1) {
        uint Channel(int shift) {
            int a = (int)((p0 >> shift) & 0xFF), b = (int)((p1 >> shift) & 0xFF);
            // Mth.lerpInt.
            return (uint)(a + Mth.Floor(alpha * (b - a)));
        }
        return Channel(24) << 24 | Channel(16) << 16 | Channel(8) << 8 | Channel(0);
    }
}
