using GraphicalClient.Assets.ResourcePacks;

namespace GraphicalClient.Assets;

/// <summary>
/// This client's own celestial sprites, used where no resource pack supplies them. The sky adds them to what is
/// behind, so black is nothing and the background is opaque black, as a pack's are.
/// </summary>
public static class SkyArt {
    private const int Size = 32;

    private static void Put(byte[] rgba, int width, int x, int y, float r, float g, float b) {
        int i = (y * width + x) * 4;
        rgba[i] = (byte)Math.Clamp((int)(r * 255.0F), 0, 255);
        rgba[i + 1] = (byte)Math.Clamp((int)(g * 255.0F), 0, 255);
        rgba[i + 2] = (byte)Math.Clamp((int)(b * 255.0F), 0, 255);
        rgba[i + 3] = 255;
    }

    /// <summary>A pale yellow disc filling the middle half, with a faint glow out to the edges.</summary>
    public static TextureImage Sun() {
        byte[] rgba = new byte[Size * Size * 4];
        for (int y = 0; y < Size; y++) {
            for (int x = 0; x < Size; x++) {
                float dx = (x + 0.5F) / Size * 2.0F - 1.0F, dy = (y + 0.5F) / Size * 2.0F - 1.0F;
                float r = MathF.Sqrt(dx * dx + dy * dy);
                float disc = r < 0.5F ? 1.0F : 0.0F;
                float glow = MathF.Max(0.0F, 1.0F - r) * 0.35F;
                float v = MathF.Min(1.0F, disc + glow * glow * 2.0F);
                Put(rgba, Size, x, y, v, v * 0.97F, v * 0.82F);
            }
        }
        return new TextureImage(Size, Size, rgba);
    }

    /// <summary>
    /// One phase of the moon, <paramref name="phase"/> 0 for full to 4 for new and back, in the order of vanilla's
    /// <c>MoonPhase</c>: a speckled grey disc lit from the side the phase says, its dark side faint.
    /// </summary>
    public static TextureImage Moon(int phase) {
        float angle = phase * MathF.PI / 4.0F;
        float sunX = MathF.Sin(angle), sunZ = MathF.Cos(angle);
        byte[] rgba = new byte[Size * Size * 4];
        for (int y = 0; y < Size; y++) {
            for (int x = 0; x < Size; x++) {
                float dx = (x + 0.5F) / Size * 2.0F - 1.0F, dy = (y + 0.5F) / Size * 2.0F - 1.0F;
                float rr = (dx * dx + dy * dy) / 0.36F;
                if (rr >= 1.0F) {
                    Put(rgba, Size, x, y, 0, 0, 0);
                    continue;
                }
                float nx = dx / 0.6F, nz = MathF.Sqrt(1.0F - rr);
                float lit = nx * sunX + nz * sunZ > 0.0F ? 1.0F : 0.12F;
                float tone = (0.72F + 0.22F * DevArt.Noise(0x4D4F, x / 2, y / 2)) * lit;
                Put(rgba, Size, x, y, tone * 0.88F, tone * 0.92F, tone);
            }
        }
        return new TextureImage(Size, Size, rgba);
    }

    /// <summary>A soft violet glow, brightest in the middle.</summary>
    public static TextureImage EndFlash() {
        const int size = 64;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float dx = (x + 0.5F) / size * 2.0F - 1.0F, dy = (y + 0.5F) / size * 2.0F - 1.0F;
                float v = MathF.Max(0.0F, 1.0F - MathF.Sqrt(dx * dx + dy * dy));
                v *= v;
                Put(rgba, size, x, y, v * 0.48F, v * 0.36F, v * 0.58F);
            }
        }
        return new TextureImage(size, size, rgba);
    }
}
