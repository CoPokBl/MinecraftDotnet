using System.Numerics;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using GraphicalClient.Rendering.Entities.Vanilla;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary>
/// The built in art for the block entity sprites. Each texture is painted onto the layout of the model
/// that draws it, face by face from the model's own texture coordinates, so it lines up whatever the
/// model: a colour per part, darker sides and edges, a little noise, and a few marks (locks, eyes,
/// faces) so the thing reads.
/// </summary>
public static class BlockEntityDevArt {
    private const uint Wood = 0x9C6B3A, DarkWood = 0x6E4A28, Iron = 0xB4B4B4, Gold = 0xD8B040;

    /// <summary>What a face is painted with: its part's name, its normal in the part's space, and the pixel within the face.</summary>
    private delegate uint? Painter(string part, Vector3 normal, int x, int y, int width, int height);

    public static TextureImage? Image(SpriteId sprite) {
        if (sprite.Texture.Namespace != "minecraft") {
            return null;
        }
        string key = sprite.Texture.Key;
        string name = key[(key.LastIndexOf('/') + 1)..];
        if (key.StartsWith("entity/chest/", StringComparison.Ordinal)) {
            return Chest(name);
        }
        if (key.StartsWith("entity/shulker/", StringComparison.Ordinal)) {
            return Shulker(name);
        }
        if (key == Sheets.BannerBase.Texture.Key) {
            return Paint(BannerModel.CreateBodyLayer(true), BannerFlagModel.CreateFlagLayer(true), (part, normal, x, y, _, _) =>
                part == "flag" ? Cloth(0xE4E4E4, x, y) : Grain(Wood, x, y, 5));
        }
        if (key.StartsWith("entity/banner/", StringComparison.Ordinal)) {
            return BannerPattern(name);
        }
        return key switch {
            "entity/bell/bell_body" => Paint(BellModel.CreateBodyLayer(), (part, normal, x, y, w, h) => Edge(Shade(Gold, normal), x, y, w, h, 0.8F, 7)),
            "entity/enchantment/enchanting_table_book" => Paint(BookModel.CreateBodyLayer(), (part, normal, x, y, w, h) =>
                part.Contains("pages") || part.Contains("flip") ? (y % 2 == 0 ? 0xFFDCD2BC : 0xFFF0E8D6) : Edge(0xFF6E2A1E, x, y, w, h, 0.7F, 9)),
            "entity/conduit/base" => Paint(ConduitRenderer.CreateShellLayer(), (_, normal, x, y, w, h) => Edge(Shade(0x8E7A5A, normal), x, y, w, h, 0.7F, 11)),
            "entity/conduit/cage" => Paint(ConduitRenderer.CreateCageLayer(), (_, normal, x, y, w, h) =>
                x == 0 || y == 0 || x == w - 1 || y == h - 1 || x == y ? DevArt.Shade(0xFF5FA89A, 0.9F + Noise(13, x, y) * 0.2F) : null),
            "entity/conduit/wind" or "entity/conduit/wind_vertical" => Paint(ConduitRenderer.CreateWindLayer(), (_, _, x, y, _, _) =>
                (x + y * 3) % 11 == 0 ? 0x90E0F0FF : null),
            "entity/beacon/beacon_beam" => Beam(),
            "entity/conduit/open_eye" => Eye(true),
            "entity/conduit/closed_eye" => Eye(false),
            "entity/decorated_pot/decorated_pot_base" => Paint(DecoratedPotRenderer.CreateBaseLayer(), (_, normal, x, y, _, _) =>
                DevArt.Shade(Terracotta(x, y), normal.Y != 0 ? 0.85F : 1.0F)),
            _ when key.StartsWith("entity/decorated_pot/", StringComparison.Ordinal) => PotSide(name),
            _ when key.StartsWith("entity/copper_golem/copper_golem", StringComparison.Ordinal) => CopperGolem(name),
            _ => HeadTexture(key)
        };
    }

    private static float Noise(int seed, int x, int y) => DevArt.Noise(seed, x, y);

    private static uint Grain(uint colour, int x, int y, int seed) =>
        0xFF000000 | DevArt.Shade(x % 4 == 0 ? DevArt.Shade(colour, 0.8F) : colour, 0.88F + Noise(seed, x, y / 3) * 0.2F);

    private static uint Cloth(uint colour, int x, int y) => 0xFF000000 | DevArt.Shade(colour, 0.93F + Noise(21, x, y) * 0.1F);

    private static uint Terracotta(int x, int y) => 0xFF000000 | DevArt.Shade(0x9A5A3C, 0.9F + Noise(31, x, y) * 0.15F);

    /// <summary>Tops lighter, bottoms darker, as a lit box reads.</summary>
    private static uint Shade(uint colour, Vector3 normal) =>
        0xFF000000 | DevArt.Shade(colour, normal.Y > 0.5F ? 1.1F : normal.Y < -0.5F ? 0.7F : 0.92F);

    /// <summary>The colour with a darker one pixel rim round the face and a little noise.</summary>
    private static uint Edge(uint colour, int x, int y, int width, int height, float rim, int seed) {
        bool edge = x == 0 || y == 0 || x == width - 1 || y == height - 1;
        return 0xFF000000 | DevArt.Shade(colour, (edge ? rim : 1.0F) * (0.92F + Noise(seed, x, y) * 0.12F));
    }

    private static TextureImage Paint(LayerDefinition layer, Painter painter) => Paint(layer, null, painter);

    /// <summary>
    /// Every face of the layers' cubes filled through <paramref name="painter"/>; a second layer shares
    /// the texture, as the banner's pole and flag do. Pixels no face covers stay clear.
    /// </summary>
    private static TextureImage Paint(LayerDefinition layer, LayerDefinition? second, Painter painter) {
        int width = layer.TexWidth, height = layer.TexHeight;
        byte[] rgba = new byte[width * height * 4];
        foreach (LayerDefinition each in second == null ? [layer] : new[] { layer, second }) {
            foreach ((string name, ModelPart part) in each.BakeRoot().PartLookup()) {
                foreach (ModelPart.Cube cube in part.Cubes) {
                    foreach (ModelPart.Polygon polygon in cube.Polygons) {
                        float u0 = polygon.Vertices.Min(v => v.U) * width, u1 = polygon.Vertices.Max(v => v.U) * width;
                        float v0 = polygon.Vertices.Min(v => v.V) * height, v1 = polygon.Vertices.Max(v => v.V) * height;
                        int x0 = (int)MathF.Round(u0), x1 = (int)MathF.Round(u1), y0 = (int)MathF.Round(v0), y1 = (int)MathF.Round(v1);
                        for (int y = Math.Max(0, y0); y < Math.Min(height, y1); y++) {
                            for (int x = Math.Max(0, x0); x < Math.Min(width, x1); x++) {
                                if (painter(name, polygon.Normal, x - x0, y - y0, x1 - x0, y1 - y0) is { } colour) {
                                    DevArt.Put(rgba, y * width + x, colour);
                                }
                            }
                        }
                    }
                }
            }
        }
        return new TextureImage(width, height, rgba);
    }

    private static TextureImage Chest(string name) {
        bool left = name.EndsWith("_left", StringComparison.Ordinal), right = name.EndsWith("_right", StringComparison.Ordinal);
        string material = left ? name[..^5] : right ? name[..^6] : name;
        (uint body, uint trim, uint latch) = material switch {
            "ender" => (0x1E2E2Eu, 0x0E1616u, 0x3AB08Au),
            "trapped" => (Wood, DarkWood, 0xC03030u),
            "christmas" => (0xB02828u, 0x2E7A2Eu, Gold),
            "copper" => (0xC06A47u, 0x8E4A30u, Iron),
            "copper_exposed" => (0xA1866Au, 0x7A6450u, Iron),
            "copper_weathered" => (0x6CA388u, 0x4E7A66u, Iron),
            "copper_oxidized" => (0x52A88Au, 0x3A7A64u, Iron),
            _ => (Wood, DarkWood, Iron)
        };
        LayerDefinition layer = left ? ChestModel.CreateDoubleBodyLeftLayer() : right ? ChestModel.CreateDoubleBodyRightLayer() : ChestModel.CreateSingleBodyLayer();
        return Paint(layer, (part, normal, x, y, w, h) => {
            if (part == "lock") {
                return 0xFF000000 | latch;
            }
            // A band of trim along the lid's bottom edge and the base's top edge, where the two meet.
            bool seam = normal.Y == 0 && (part == "lid" ? y >= h - 1 : y < 1);
            bool rim = x == 0 || x == w - 1 || y == 0 || y == h - 1;
            uint colour = seam || rim ? trim : body;
            return 0xFF000000 | DevArt.Shade(Shade(colour, normal), 0.9F + Noise(3, x, y / 2) * 0.15F);
        });
    }

    private static TextureImage Shulker(string name) {
        uint colour = 0x976997;
        foreach (Minecraft.Schemas.DyeColor dye in Enum.GetValues<Minecraft.Schemas.DyeColor>()) {
            if (name == "shulker_" + Sheets.DyeName(dye)) {
                colour = TropicalFish.TextureDiffuseColor(dye) & 0xFFFFFF;
            }
        }
        return Paint(ShulkerModel.CreateBoxLayer(), (part, normal, x, y, w, h) => {
            uint face = part == "lid" ? colour : DevArt.Shade(colour, 0.85F);
            return Edge(Shade(face, normal), x, y, w, h, 0.75F, 5);
        });
    }

    /// <summary>A white mask on both sides of the flag: the whole cloth for the pattern base, a shape picked by name otherwise.</summary>
    private static TextureImage BannerPattern(string name) {
        int shape = name == "base" ? -1 : DevArt.Hash(name) % 8;
        return Paint(BannerFlagModel.CreateFlagLayer(true), (_, normal, x, y, w, h) => {
            if (normal.Z == 0) {
                return null;
            }
            bool covered = shape switch {
                -1 => true,
                0 => y < h / 3,
                1 => y >= h * 2 / 3,
                2 => x < w / 3,
                3 => x >= w * 2 / 3,
                4 => Math.Abs(x - w / 2.0F + 0.5F) < 2.5F || Math.Abs(y - h / 2.0F + 0.5F) < 2.5F,
                5 => x * h > y * w,
                6 => x < 2 || y < 2 || x >= w - 2 || y >= h - 2,
                _ => (x - w / 2.0F + 0.5F) * (x - w / 2.0F + 0.5F) * 4 + (y - h / 2.0F + 0.5F) * (y - h / 2.0F + 0.5F) < 100
            };
            return covered ? 0xFFFFFFFF : null;
        });
    }

    /// <summary>Pale streaks running up the beam, brightest down the middle.</summary>
    private static TextureImage Beam() {
        byte[] rgba = new byte[16 * 16 * 4];
        for (int y = 0; y < 16; y++) {
            for (int x = 0; x < 16; x++) {
                float centre = 1.0F - Math.Abs(x - 7.5F) / 8.0F;
                byte level = (byte)(150 + 105 * centre * (0.7F + Noise(51, x, y / 4) * 0.3F));
                DevArt.Put(rgba, y * 16 + x, 0xFF000000 | (uint)level << 16 | (uint)level << 8 | level);
            }
        }
        return new TextureImage(16, 16, rgba);
    }

    private static TextureImage Eye(bool open) {
        byte[] rgba = new byte[16 * 16 * 4];
        for (int y = 0; y < 8; y++) {
            for (int x = 0; x < 8; x++) {
                float dx = x - 3.5F, dy = y - 3.5F;
                uint? colour = open
                    ? dx * dx + dy * dy < 4 ? 0xFF1A1A1A : dx * dx / 16 + dy * dy / 6 < 1 ? 0xFFE8D040 : null
                    : Math.Abs(dy) < 1 && Math.Abs(dx) < 3.5F ? 0xFF8A7A40 : null;
                if (colour is { } c) {
                    DevArt.Put(rgba, y * 16 + x, c);
                }
            }
        }
        return new TextureImage(16, 16, rgba);
    }

    /// <summary>The terracotta side, and for a sherd's pattern a darker motif picked by its name.</summary>
    private static TextureImage PotSide(string name) {
        int shape = name == "decorated_pot_side" ? -1 : DevArt.Hash(name) % 4;
        byte[] rgba = new byte[16 * 16 * 4];
        for (int y = 0; y < 16; y++) {
            for (int x = 0; x < 16; x++) {
                float dx = x - 7.5F, dy = y - 8.0F;
                bool motif = shape switch {
                    0 => dx * dx + dy * dy < 16 && dx * dx + dy * dy > 6,
                    1 => Math.Abs(dx) + Math.Abs(dy) < 5,
                    2 => Math.Abs(dx) < 1.5F || Math.Abs(dy) < 1.5F,
                    3 => (x + y) % 5 == 0 && Math.Abs(dy) < 5,
                    _ => false
                };
                DevArt.Put(rgba, y * 16 + x, motif ? 0xFF4A2A1C : Terracotta(x, y));
            }
        }
        return new TextureImage(16, 16, rgba);
    }

    private static TextureImage CopperGolem(string name) {
        uint colour = name.EndsWith("exposed") ? 0xA1866Au : name.EndsWith("weathered") ? 0x6CA388u : name.EndsWith("oxidized") ? 0x52A88Au : 0xC06A47u;
        return Paint(CopperGolemModel.CreateBodyLayer(), (part, normal, x, y, w, h) => {
            bool eye = part == "head" && normal.Z < -0.5F && w == 8 && y == 2 && x is 1 or 6;
            return eye ? 0xFF60E0F0 : Edge(Shade(colour, normal), x, y, w, h, 0.8F, 17);
        });
    }

    /// <summary>The mob heads and player skins a skull draws with: the head's six faces, with a face on the front.</summary>
    private static TextureImage? HeadTexture(string key) {
        (uint skin, uint feature, uint hair)? palette = key switch {
            "entity/skeleton/skeleton" => (0xC8C8C0u, 0x303030u, 0u),
            "entity/skeleton/wither_skeleton" => (0x2E2E2Eu, 0x0A0A0Au, 0u),
            "entity/zombie/zombie" => (0x5E8E4Eu, 0x1E2E1Eu, 0x2A4A2Au),
            "entity/creeper/creeper" => (0x5EB04Eu, 0x101010u, 0u),
            "entity/piglin/piglin" => (0xE0A090u, 0x3A1A10u, 0u),
            "entity/enderdragon/dragon" => (0x1E1E24u, 0xB040C0u, 0u),
            _ when key.StartsWith("entity/player/", StringComparison.Ordinal) => (0xD8A882u, 0x3A60A0u, 0x4A3020u),
            _ => null
        };
        if (palette is not { } p) {
            return null;
        }
        LayerDefinition layer = key switch {
            "entity/enderdragon/dragon" => DragonHeadModel.CreateHeadLayer(),
            "entity/piglin/piglin" => LayerDefinition.Create(PiglinHeadModel.CreateHeadModel(), 64, 64),
            "entity/zombie/zombie" => SkullBlockRenderer.CreateHumanoidHeadLayer(),
            _ when key.StartsWith("entity/player/", StringComparison.Ordinal) => SkullBlockRenderer.CreateHumanoidHeadLayer(),
            _ => SkullBlockRenderer.CreateMobHeadLayer()
        };
        bool creeper = key == "entity/creeper/creeper";
        return Paint(layer, (part, normal, x, y, w, h) => {
            if (part == "hat") {
                return p.hair != 0 && normal.Y > 0.5F ? 0xFF000000 | p.hair : null;
            }
            uint colour = DevArt.Shade(p.skin, 0.9F + Noise(41, x, y) * 0.15F);
            if (p.hair != 0 && (normal.Y > 0.5F || normal.Y == 0 && y < h / 4)) {
                colour = p.hair;
            }
            // The front of a head is its north face; two eyes, and a creeper's mouth.
            if (normal.Z < -0.5F && w >= 8 && h >= 8) {
                int fx = x * 8 / w, fy = y * 8 / h;
                bool eye = fy == 4 && (fx == 2 || fx == 5) || creeper && fy is 2 or 3 && fx is 1 or 2 or 5 or 6;
                bool mouth = creeper ? fy >= 5 && fx is >= 3 and <= 4 || fy is 6 or 7 && fx is 2 or 5 : fy == 6 && fx is >= 3 and <= 4;
                if (eye || mouth) {
                    colour = p.feature;
                }
            }
            return 0xFF000000 | Shade(colour, normal);
        });
    }
}
