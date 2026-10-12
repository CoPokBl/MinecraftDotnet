namespace GraphicalClient.Assets;

/// <summary>
/// This client's own placeholder art: every texture is drawn here from a base colour and a pattern,
/// deterministically, so the same block always looks the same. No image files are involved.
/// </summary>
public static class DevArt {
    public const int Size = 16;

    /// <summary>Patterns a texture can be drawn in.</summary>
    public enum Style {
        Noise,
        Smooth,
        Planks,
        LogSide,
        LogEnd,
        Bricks,
        Tiles,
        Ore,
        Glass,
        Leaves,
        GrassTop,
        GrassSide,
        Sand,
        Wool,
        Plant,
        Flower,
        Crop,
        Water,
        Lava,
        Torch,
        Rail,
        Ladder,
        Door,
        Trapdoor,
        Machine,
        MachineFront,
        /// <summary>Flames rising from the bottom edge; the accent is the animation frame.</summary>
        Fire,
        Missing
    }

    /// <summary>One texture: a style, its colours, and a seed so two blocks of a style differ slightly.</summary>
    public readonly record struct Spec(Style Style, uint Base, uint Accent, int Seed);

    public static byte[] Draw(Spec spec) {
        byte[] rgba = new byte[Size * Size * 4];
        for (int y = 0; y < Size; y++) {
            for (int x = 0; x < Size; x++) {
                Put(rgba, y * Size + x, Pixel(spec, x, y));
            }
        }
        return rgba;
    }

    /// <summary>The magenta and black checks a texture nothing supplies is drawn as.</summary>
    public static ResourcePacks.TextureImage MissingTexture() => new(Size, Size, Draw(new Spec(Style.Missing, 0, 0, 0)));

    /// <summary>Writes a 0xAARRGGBB colour as the <paramref name="pixel"/>th pixel of an RGBA image.</summary>
    public static void Put(byte[] rgba, int pixel, uint argb) {
        int i = pixel * 4;
        rgba[i] = (byte)(argb >> 16);
        rgba[i + 1] = (byte)(argb >> 8);
        rgba[i + 2] = (byte)argb;
        rgba[i + 3] = (byte)(argb >> 24);
    }

    private static uint Pixel(Spec spec, int x, int y) {
        uint b = spec.Base;
        uint a = spec.Accent;
        float n = Noise(spec.Seed, x, y);
        bool edge = x == 0 || y == 0 || x == Size - 1 || y == Size - 1;

        switch (spec.Style) {
            case Style.Noise:
                return Opaque(Shade(b, 0.86F + n * 0.24F - (edge ? 0.06F : 0.0F)));

            case Style.Smooth:
                return Opaque(Shade(b, 0.95F + n * 0.08F - (edge ? 0.08F : 0.0F)));

            case Style.Planks: {
                bool seam = y % 4 == 3;
                bool joint = (y / 4 % 2 == 0 ? x == 11 : x == 4) && !seam;
                float grain = 0.9F + Noise(spec.Seed, x / 4, y) * 0.12F;
                return Opaque(Shade(b, seam || joint ? 0.68F : grain));
            }

            case Style.LogSide: {
                float stripe = (x * 7 + spec.Seed) % 5 == 0 ? 0.72F : 0.88F + n * 0.14F;
                return Opaque(Shade(b, stripe));
            }

            case Style.LogEnd: {
                int ring = Math.Max(Math.Abs(x * 2 - 15), Math.Abs(y * 2 - 15)) / 2;
                return Opaque(ring >= 7 ? Shade(a, 0.85F + n * 0.1F) : Shade(b, ring % 2 == 0 ? 1.0F : 0.82F));
            }

            case Style.Bricks: {
                int row = y / 4;
                int offset = row % 2 == 0 ? 0 : 4;
                bool mortar = y % 4 == 3 || (x + offset) % 8 == 7;
                return Opaque(mortar ? Shade(a, 0.95F) : Shade(b, 0.9F + n * 0.15F));
            }

            case Style.Tiles: {
                bool mortar = y % 8 == 7 || x % 8 == 7;
                return Opaque(Shade(b, mortar ? 0.7F : 0.92F + n * 0.1F));
            }

            case Style.Ore: {
                float spot = Noise(spec.Seed * 31 + 7, x / 3, y / 3);
                bool vein = spot > 0.72F && !edge && Noise(spec.Seed + 3, x, y) > 0.25F;
                return Opaque(vein ? Shade(a, 0.85F + n * 0.25F) : Shade(b, 0.86F + n * 0.2F));
            }

            case Style.Glass: {
                bool frame = edge || (x == 3 && y == 3) || (x == 4 && y == 4) || (x == 5 && y == 3);
                return frame ? Opaque(Shade(b, 1.05F)) : WithAlpha(b, (byte)(b >> 24 == 0 ? 40 : b >> 24));
            }

            case Style.Leaves: {
                bool hole = Noise(spec.Seed + 11, x, y) > 0.78F;
                return hole ? 0 : Opaque(Shade(b, 0.75F + n * 0.4F));
            }

            case Style.GrassTop:
                return Opaque(Shade(b, 0.82F + n * 0.3F));

            case Style.GrassSide: {
                int fringe = 3 + (int)(Noise(spec.Seed, x, 0) * 2.0F);
                return Opaque(y < fringe ? Shade(a, 0.8F + n * 0.3F) : Shade(b, 0.86F + n * 0.22F));
            }

            case Style.Sand:
                return Opaque(Shade(b, 0.9F + n * 0.12F + (Noise(spec.Seed + 5, x, y) > 0.9F ? -0.15F : 0.0F)));

            case Style.Wool: {
                float weave = (x + y) % 2 == 0 ? 1.0F : 0.94F;
                return Opaque(Shade(b, weave * (0.93F + n * 0.1F)));
            }

            case Style.Plant: {
                // Three blades rising from the bottom edge.
                int blade = x % 5;
                int height = 8 + (int)(Noise(spec.Seed, x / 5, 1) * 8.0F);
                bool on = (blade == 1 || blade == 2) && Size - 1 - y < height;
                return on ? Opaque(Shade(b, 0.8F + n * 0.35F)) : 0;
            }

            case Style.Flower: {
                int cx = x - 8, cy = y - 5;
                bool petal = cx * cx + cy * cy <= 10;
                bool centre = cx * cx + cy * cy <= 2;
                bool stem = (x == 7 || x == 8) && y > 7;
                bool leaf = y is 11 or 12 && x is >= 4 and <= 6;
                return centre ? Opaque(0xF2D84C)
                    : petal ? Opaque(Shade(a, 0.9F + n * 0.2F))
                    : stem || leaf ? Opaque(Shade(b, 0.85F + n * 0.2F)) : 0;
            }

            case Style.Crop: {
                bool stalk = x % 4 == 1 && y > 3;
                bool head = x % 4 is 0 or 2 && y is >= 2 and <= 5;
                return head ? Opaque(Shade(a, 0.85F + n * 0.2F)) : stalk ? Opaque(Shade(b, 0.8F + n * 0.3F)) : 0;
            }

            case Style.Water:
                return WithAlpha(Shade(b, 0.9F + n * 0.15F), 0xB4);

            case Style.Lava:
                return Opaque(Shade(b, 0.85F + n * 0.35F));

            case Style.Torch: {
                bool stick = x is 7 or 8 && y >= 6;
                bool flame = x is >= 6 and <= 9 && y is >= 2 and <= 5;
                return flame ? Opaque(Shade(a, 0.9F + n * 0.2F)) : stick ? Opaque(Shade(b, 0.9F)) : 0;
            }

            case Style.Rail: {
                bool track = x is 2 or 3 or 12 or 13;
                bool sleeper = y % 4 == 1 && x is >= 1 and <= 14;
                return track ? Opaque(Shade(a, 0.95F)) : sleeper ? Opaque(Shade(b, 0.85F + n * 0.1F)) : 0;
            }

            case Style.Ladder: {
                bool rail = x is 1 or 2 or 13 or 14;
                bool rung = y % 4 == 2;
                return rail || rung ? Opaque(Shade(b, 0.85F + n * 0.15F)) : 0;
            }

            case Style.Door: {
                bool frame = edge || x == 7 || y == 7;
                bool window = y < 7 && !frame && x is > 1 and < 14;
                return Opaque(Shade(b, window ? 0.6F : frame ? 0.75F : 0.92F + n * 0.1F));
            }

            case Style.Trapdoor: {
                bool frame = edge || x == 7 || x == 8;
                bool hole = !frame && y % 5 == 2;
                return hole ? 0 : Opaque(Shade(b, frame ? 0.75F : 0.92F + n * 0.1F));
            }

            case Style.Machine:
                return Opaque(Shade(b, edge ? 0.7F : 0.9F + n * 0.12F));

            case Style.MachineFront: {
                bool face = x is >= 4 and <= 11 && y is >= 5 and <= 11;
                return Opaque(face ? Shade(a, 0.7F + n * 0.3F) : Shade(b, edge ? 0.7F : 0.9F + n * 0.12F));
            }

            case Style.Fire: {
                // Each column's tongue wavers with the frame, smoothed against its neighbours, and the
                // pattern inside it scrolls upward a texel a frame.
                int frame = (int)a;
                float Height(int column) => 6.0F + Noise(spec.Seed, column, frame) * 9.0F;
                float height = (Height(x - 1) + Height(x) * 2.0F + Height(x + 1)) / 4.0F;
                int up = Size - 1 - y;
                if (up >= height) {
                    return 0;
                }
                float t = up / height;
                float flicker = Noise(spec.Seed + 5, x, y + frame);
                uint colour = t < 0.35F ? 0xFFE878u : t < 0.7F ? 0xFFA028u : 0xE85018u;
                return t > 0.55F && flicker > 0.8F ? 0 : Opaque(Shade(colour, 0.85F + flicker * 0.2F));
            }

            default:
                return Opaque((x / 8 + y / 8) % 2 == 0 ? 0xF800F8u : 0x000000u);
        }
    }

    /// <summary>Cheap hash noise in [0, 1], stable across runs.</summary>
    public static float Noise(int seed, int x, int y) {
        uint h = (uint)seed * 374761393u + (uint)x * 668265263u + (uint)y * 2147483647u;
        h = (h ^ (h >> 13)) * 1274126177u;
        h ^= h >> 16;
        return (h & 0xFFFF) / 65535.0F;
    }

    public static int Hash(string text) {
        int h = unchecked((int)2166136261);
        foreach (char c in text) {
            h = (h ^ c) * 16777619;
        }
        return h & 0x7FFFFFFF;
    }

    public static uint Shade(uint rgb, float factor) {
        int r = Math.Clamp((int)(((rgb >> 16) & 0xFF) * factor), 0, 255);
        int g = Math.Clamp((int)(((rgb >> 8) & 0xFF) * factor), 0, 255);
        int bl = Math.Clamp((int)((rgb & 0xFF) * factor), 0, 255);
        return (rgb & 0xFF000000) | (uint)(r << 16 | g << 8 | bl);
    }

    public static uint Mix(uint a, uint b, float t) {
        int r = (int)(((a >> 16) & 0xFF) * (1 - t) + ((b >> 16) & 0xFF) * t);
        int g = (int)(((a >> 8) & 0xFF) * (1 - t) + ((b >> 8) & 0xFF) * t);
        int bl = (int)((a & 0xFF) * (1 - t) + (b & 0xFF) * t);
        return (uint)(r << 16 | g << 8 | bl);
    }

    /// <summary>The end sky's stand in, which the end portal's base layer shows: a dim violet speckle, tiling.</summary>
    public static ResourcePacks.TextureImage EndSky() {
        const int size = 128;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float shade = 0.8F + 0.25F * Noise(0x3E5D, x, y) + 0.15F * Noise(0x3E5E, x / 4, y / 4);
                Put(rgba, y * size + x, 0xFF000000 | (uint)Math.Min(255, 100 * shade) << 16 | (uint)Math.Min(255, 76 * shade) << 8 | (uint)Math.Min(255, 136 * shade));
            }
        }
        return new ResourcePacks.TextureImage(size, size, rgba);
    }

    /// <summary>
    /// Nausea's overlay stand in: black in the middle and white at the edges, a soft ring between. It is added to
    /// the screen, so only the edges show.
    /// </summary>
    public static ResourcePacks.TextureImage Nausea() {
        const int size = 64;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float dx = (x + 0.5F) / size * 2.0F - 1.0F, dy = (y + 0.5F) / size * 2.0F - 1.0F;
                float edge = Math.Clamp((MathF.Sqrt(dx * dx + dy * dy) - 0.55F) / 0.4F, 0.0F, 1.0F);
                uint grey = (uint)(edge * edge * (3.0F - 2.0F * edge) * 255.0F);
                Put(rgba, y * size + x, 0xFF000000 | grey << 16 | grey << 8 | grey);
            }
        }
        return new ResourcePacks.TextureImage(size, size, rgba);
    }

    /// <summary>
    /// The vignette's stand in: black in the middle, greying towards the corners. The vignette darkens what
    /// is behind it by its colour, so black leaves the middle alone.
    /// </summary>
    public static ResourcePacks.TextureImage Vignette() {
        const int size = 64;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float dx = (x + 0.5F) / size * 2.0F - 1.0F, dy = (y + 0.5F) / size * 2.0F - 1.0F;
                float shade = Math.Clamp((dx * dx + dy * dy) * 0.45F - 0.05F, 0.0F, 1.0F);
                uint grey = (uint)(shade * 255.0F);
                Put(rgba, y * size + x, 0xFF000000 | grey * 0x010101);
            }
        }
        return new ResourcePacks.TextureImage(size, size, rgba);
    }

    /// <summary>The spyglass scope's stand in: a clear lens with a dark rim, in an opaque dark grey surround.</summary>
    public static ResourcePacks.TextureImage SpyglassScope() {
        const int size = 128;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float dx = (x + 0.5F) / size * 2.0F - 1.0F, dy = (y + 0.5F) / size * 2.0F - 1.0F;
                float r = MathF.Sqrt(dx * dx + dy * dy);
                uint argb = r > 0.97F ? 0xFF202020 : r > 0.9F ? 0xFF404040 : 0x10C0E0FFu;
                Put(rgba, y * size + x, argb);
            }
        }
        return new ResourcePacks.TextureImage(size, size, rgba);
    }

    /// <summary>The carved pumpkin's stand in: black, with two soft eye holes to look out of.</summary>
    public static ResourcePacks.TextureImage PumpkinBlur() {
        const int size = 128;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float u = (x + 0.5F) / size, v = (y + 0.5F) / size;
                float eye = 1.0F;
                foreach (float centre in (ReadOnlySpan<float>)[0.3F, 0.7F]) {
                    float dx = (u - centre) / 0.17F, dy = (v - 0.45F) / 0.22F;
                    eye = Math.Min(eye, Math.Clamp((MathF.Sqrt(dx * dx + dy * dy) - 0.7F) / 0.3F, 0.0F, 1.0F));
                }
                Put(rgba, y * size + x, (uint)(eye * 255.0F) << 24);
            }
        }
        return new ResourcePacks.TextureImage(size, size, rgba);
    }

    /// <summary>The powder snow outline's stand in: pale ice speckled in from the edges, clear in the middle.</summary>
    public static ResourcePacks.TextureImage PowderSnowOutline() {
        const int size = 128;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                int edge = Math.Min(Math.Min(x, size - 1 - x), Math.Min(y, size - 1 - y));
                float frost = 1.0F - edge / 18.0F + 0.35F * (Noise(0x5A0C, x / 2, y / 2) - 0.5F);
                if (frost > 0.5F) {
                    uint blue = 0xE0 + (uint)(Noise(0x5A0D, x, y) * 0x1F);
                    Put(rgba, y * size + x, 0xFF000000 | 0xA0u << 16 | 0xE0u << 8 | blue);
                }
            }
        }
        return new ResourcePacks.TextureImage(size, size, rgba);
    }

    /// <summary>The underwater overlay's stand in: a translucent blue ripple, tiling.</summary>
    public static ResourcePacks.TextureImage Underwater() {
        const int size = 16;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float wave = 0.5F + 0.5F * MathF.Sin((x + 2.0F * MathF.Sin(y * MathF.PI / 8.0F)) * MathF.PI / 8.0F);
                uint green = 0x50 + (uint)(wave * 0x20);
                Put(rgba, y * size + x, (0x80u + (uint)(wave * 0x10)) << 24 | 0x28u << 16 | green << 8 | 0xFF);
            }
        }
        return new ResourcePacks.TextureImage(size, size, rgba);
    }

    /// <summary>
    /// The end portal's stand in: sparse grey stars on black, tiling. The portal's layers tint, scale and
    /// scroll it, so it is the stars' spacing and brightness that matter, not their colour.
    /// </summary>
    public static ResourcePacks.TextureImage EndPortalStars() {
        const int size = 256;
        float[] light = new float[size * size];
        for (int star = 0; star < 420; star++) {
            int cx = (int)(Noise(0x57A2, star, 0) * size), cy = (int)(Noise(0x57A2, star, 1) * size);
            float brightness = 0.35F + 0.65F * Noise(0x57A2, star, 2);
            float radius = 0.6F + 1.2F * Noise(0x57A2, star, 3) * Noise(0x57A2, star, 4);
            int reach = (int)MathF.Ceiling(radius);
            for (int dy = -reach; dy <= reach; dy++) {
                for (int dx = -reach; dx <= reach; dx++) {
                    float falloff = 1.0F - MathF.Sqrt(dx * dx + dy * dy) / (radius + 0.5F);
                    if (falloff <= 0) {
                        continue;
                    }
                    int index = ((cy + dy) & (size - 1)) * size + ((cx + dx) & (size - 1));
                    light[index] = Math.Max(light[index], brightness * falloff);
                }
            }
        }
        byte[] rgba = new byte[size * size * 4];
        for (int i = 0; i < light.Length; i++) {
            uint grey = (byte)(light[i] * 255);
            Put(rgba, i, 0xFF000000 | grey * 0x010101);
        }
        return new ResourcePacks.TextureImage(size, size, rgba);
    }

    /// <summary>
    /// The enchantment glint's stand in: soft violet streaks along x, tiling, dark between them. The glint
    /// is added to what is under it, so black is where it leaves an item alone.
    /// </summary>
    public static ResourcePacks.TextureImage EnchantmentGlint() {
        const int size = 128;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float band = 0.5F + 0.5F * MathF.Sin((y + 6.0F * MathF.Sin(x * MathF.PI * 2.0F / size)) * MathF.PI * 6.0F / size);
                float light = band * band * band * (0.75F + 0.25F * Noise(0x6117, x / 2, y / 2));
                Put(rgba, y * size + x, 0xFF000000 | (uint)(150 * light) << 16 | (uint)(70 * light) << 8 | (uint)(230 * light));
            }
        }
        return new ResourcePacks.TextureImage(size, size, rgba);
    }

    private static uint Opaque(uint rgb) => 0xFF000000 | (rgb & 0xFFFFFF);

    private static uint WithAlpha(uint rgb, byte alpha) => (uint)alpha << 24 | (rgb & 0xFFFFFF);
}
