using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities.Special;

namespace GraphicalClient.Assets;

/// <summary>
/// The built in art's sprites for the special item renderers, drawn here on the layout each model's
/// texture coordinates expect. Null for a sprite with no built in art, which draws as the missing checks.
/// </summary>
public static class DevArtSprites {
    private const string ShieldPrefix = "entity/shield/";

    private const uint Wood = 0x9C6B3A, DarkWood = 0x6E4A28, Iron = 0x9E9E9E, Blank = 0xD8D8D8;

    public static TextureImage? Image(SpriteId sprite) {
        if (sprite.Texture.Namespace != "minecraft" || !sprite.Texture.Key.StartsWith(ShieldPrefix, StringComparison.Ordinal)) {
            return Rendering.BlockEntities.BlockEntityDevArt.Image(sprite);
        }
        string name = sprite.Texture.Key[ShieldPrefix.Length..];
        if (sprite == Sheets.ShieldBaseNoPattern) {
            return Shield(false);
        }
        if (sprite == Sheets.ShieldBase) {
            return Shield(true);
        }
        return ShieldPattern(name);
    }

    /// <summary>
    /// <c>ShieldModel</c>'s 64 square layout: the plate's front at 1,1 (12 by 22), its back at 14,1, its
    /// edges between, and the handle's faces from 26,0. A patterned shield's face is left blank for the
    /// pattern layers to cover.
    /// </summary>
    private static TextureImage Shield(bool patterned) {
        byte[] rgba = new byte[64 * 64 * 4];
        void Fill(int x0, int y0, int x1, int y1, Func<int, int, uint> colour) {
            for (int y = y0; y < y1; y++) {
                for (int x = x0; x < x1; x++) {
                    DevArt.Put(rgba, y * 64 + x, 0xFF000000 | colour(x, y));
                }
            }
        }
        uint Planks(uint baseColour, int x, int y, int seed) {
            float grain = 0.88F + DevArt.Noise(seed, x, y / 3) * 0.2F;
            return DevArt.Shade(x % 4 == 0 ? DevArt.Shade(baseColour, 0.75F) : baseColour, grain);
        }
        uint IronAt(int x, int y) => DevArt.Shade(Iron, 0.9F + DevArt.Noise(7, x, y) * 0.15F);

        // Edges of the plate, then its front and back faces, each framed in iron.
        Fill(1, 0, 25, 1, IronAt);
        Fill(0, 1, 1, 23, IronAt);
        Fill(13, 1, 14, 23, IronAt);
        Fill(1, 1, 13, 23, (x, y) => {
            bool rim = x == 1 || x == 12 || y == 1 || y == 22;
            if (rim) {
                return IronAt(x, y);
            }
            if (patterned) {
                return DevArt.Shade(Blank, 0.95F + DevArt.Noise(3, x, y) * 0.08F);
            }
            // A boss in the middle of the front, so the facing reads.
            return x is >= 6 and <= 7 && y is >= 10 and <= 13 ? IronAt(x, y) : Planks(Wood, x - 1, y, 11);
        });
        Fill(14, 1, 26, 23, (x, y) => x == 14 || x == 25 || y == 1 || y == 22 ? IronAt(x, y) : Planks(DarkWood, x - 14, y, 13));
        // The handle.
        Fill(26, 0, 42, 12, (x, y) => DevArt.Shade(0x4A3020, 0.9F + DevArt.Noise(17, x, y) * 0.15F));
        return new TextureImage(64, 64, rgba);
    }

    /// <summary>
    /// A white mask over the front face, inside the rim: the whole of it for the pattern base, and for any
    /// other pattern a shape picked from its name, so different patterns at least look different.
    /// </summary>
    private static TextureImage ShieldPattern(string name) {
        byte[] rgba = new byte[64 * 64 * 4];
        const int x0 = 2, y0 = 2, width = 10, height = 20;
        int shape = name == "base" ? -1 : DevArt.Hash(name) % 8;
        for (int v = 0; v < height; v++) {
            for (int u = 0; u < width; u++) {
                bool covered = shape switch {
                    -1 => true,
                    0 => v < height / 3,
                    1 => v >= height * 2 / 3,
                    2 => u < width / 3,
                    3 => u >= width * 2 / 3,
                    4 => Math.Abs(u - width / 2.0F + 0.5F) < 1.5F || Math.Abs(v - height / 2.0F + 0.5F) < 1.5F,
                    5 => u * height > v * width,
                    6 => u == 0 || v == 0 || u == width - 1 || v == height - 1,
                    _ => (u - width / 2.0F + 0.5F) * (u - width / 2.0F + 0.5F) * 4 + (v - height / 2.0F + 0.5F) * (v - height / 2.0F + 0.5F) < 36
                };
                if (covered) {
                    DevArt.Put(rgba, (y0 + v) * 64 + x0 + u, 0xFFFFFFFF);
                }
            }
        }
        return new TextureImage(64, 64, rgba);
    }
}
