using GraphicalClient.Assets.ResourcePacks;

namespace GraphicalClient.Assets;

/// <summary>
/// This client's own stand ins for the sky's textures, used where no resource pack supplies them: rain streaks,
/// snowflakes and the cloud map. Each is drawn from a fixed seed, so it is the same every run, and each tiles.
/// </summary>
public static class WeatherArt {
    /// <summary>The size vanilla's rain and snow textures have, which the weather geometry's scrolling is scaled to.</summary>
    private const int Width = 64, Height = 256;

    private static uint Hash(uint seed, int x, int y) {
        uint h = seed * 0x9E3779B9u ^ (uint)x * 0x85EBCA6Bu ^ (uint)y * 0xC2B2AE35u;
        h ^= h >> 15;
        h *= 0x2C1B3C6Du;
        h ^= h >> 12;
        h *= 0x297A2D39u;
        return h ^ h >> 15;
    }

    private static float Unit(uint seed, int x, int y) => (Hash(seed, x, y) & 0xFFFFFF) / 16777216.0F;

    private static void Blend(byte[] rgba, int x, int y, uint rgb, int alpha) {
        int i = ((y & (Height - 1)) * Width + (x & (Width - 1))) * 4;
        if (rgba[i + 3] >= alpha) {
            return;
        }
        rgba[i] = (byte)(rgb >> 16);
        rgba[i + 1] = (byte)(rgb >> 8);
        rgba[i + 2] = (byte)rgb;
        rgba[i + 3] = (byte)alpha;
    }

    /// <summary>Thin pale blue streaks, one pixel wide and brightest in the middle, that wrap top to bottom.</summary>
    public static TextureImage Rain() {
        byte[] rgba = new byte[Width * Height * 4];
        for (int streak = 0; streak < 26; streak++) {
            int x = (int)(Unit(0x5241, streak, 0) * Width);
            int top = (int)(Unit(0x5241, streak, 1) * Height);
            int length = 6 + (int)(Unit(0x5241, streak, 2) * 20);
            uint rgb = Unit(0x5241, streak, 3) < 0.5F ? 0x5F7FCCu : 0x4A6BC0u;
            float peak = 0.55F + 0.45F * Unit(0x5241, streak, 4);
            for (int y = 0; y < length; y++) {
                float along = (y + 0.5F) / length;
                float strength = 1.0F - MathF.Abs(along * 2.0F - 1.0F);
                Blend(rgba, x, top + y, rgb, (int)((40 + 200 * strength) * peak));
            }
        }
        return new TextureImage(Width, Height, rgba);
    }

    /// <summary>Scattered white flakes of one to three pixels, some fainter than others.</summary>
    public static TextureImage Snow() {
        byte[] rgba = new byte[Width * Height * 4];
        for (int flake = 0; flake < 70; flake++) {
            int x = (int)(Unit(0x534E, flake, 0) * Width);
            int y = (int)(Unit(0x534E, flake, 1) * Height);
            int alpha = Unit(0x534E, flake, 2) < 0.3F ? 170 : 255;
            float size = Unit(0x534E, flake, 3);
            Blend(rgba, x, y, 0xFFFFFF, alpha);
            if (size > 0.45F) {
                Blend(rgba, x + 1, y, 0xFFFFFF, alpha);
                Blend(rgba, x, y + 1, 0xFFFFFF, alpha);
            }
            if (size > 0.8F) {
                Blend(rgba, x + 1, y + 1, 0xFFFFFF, alpha);
                Blend(rgba, x - 1, y, 0xF0F4FF, alpha * 2 / 3);
                Blend(rgba, x, y - 1, 0xF0F4FF, alpha * 2 / 3);
            }
        }
        return new TextureImage(Width, Height, rgba);
    }

    /// <summary>
    /// The cloud cell map: a cell is cloud where its texel is opaque. Blobs of tileable value noise, twice as wide
    /// as they are deep, cut so a little over a quarter of the sky is cloud.
    /// </summary>
    public static TextureImage Clouds() {
        const int size = 256;
        float[] values = new float[size * size];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float value = 0.0F, amplitude = 1.0F;
                for (int octave = 0; octave < 3; octave++) {
                    int periodX = 24 << octave, periodY = 48 << octave;
                    value += amplitude * PeriodicNoise((uint)(0xC10D + octave), x * periodX / (float)size, y * periodY / (float)size, periodX, periodY);
                    amplitude *= 0.5F;
                }
                values[y * size + x] = value;
            }
        }
        float[] sorted = (float[])values.Clone();
        Array.Sort(sorted);
        float threshold = sorted[(int)(sorted.Length * 0.72F)];
        byte[] rgba = new byte[size * size * 4];
        for (int i = 0; i < values.Length; i++) {
            if (values[i] >= threshold) {
                rgba[i * 4] = rgba[i * 4 + 1] = rgba[i * 4 + 2] = rgba[i * 4 + 3] = 255;
            }
        }
        return new TextureImage(size, size, rgba);
    }

    /// <summary>Smoothly interpolated lattice noise whose lattice wraps at the given periods, so the result tiles.</summary>
    private static float PeriodicNoise(uint seed, float x, float y, int periodX, int periodY) {
        int x0 = (int)MathF.Floor(x), y0 = (int)MathF.Floor(y);
        float fx = x - x0, fy = y - y0;
        fx = fx * fx * (3.0F - 2.0F * fx);
        fy = fy * fy * (3.0F - 2.0F * fy);
        float Corner(int cx, int cy) => Unit(seed, (cx % periodX + periodX) % periodX, (cy % periodY + periodY) % periodY);
        float top = Corner(x0, y0) + (Corner(x0 + 1, y0) - Corner(x0, y0)) * fx;
        float bottom = Corner(x0, y0 + 1) + (Corner(x0 + 1, y0 + 1) - Corner(x0, y0 + 1)) * fx;
        return top + (bottom - top) * fy;
    }
}
