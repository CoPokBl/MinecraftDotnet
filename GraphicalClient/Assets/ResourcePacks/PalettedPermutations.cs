using Minecraft.Schemas;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// The <c>paletted_permutations</c> sources of a pack's atlas definitions
/// (<c>assets/minecraft/atlases/&lt;atlas&gt;.json</c>): each listed texture recoloured once per palette,
/// as the sprite <c>&lt;texture&gt;&lt;separator&gt;&lt;suffix&gt;</c>. The definitions of every pack are read
/// lowest first, and a later source naming the same sprite replaces an earlier one, as vanilla's
/// <c>SpriteSourceList</c> collects them. Other source types are not read. It also recolours single textures
/// by their own palette metadata, as <c>PalettedTextureManager</c> does for armour trims.
/// </summary>
public sealed class PalettedPermutations(PackFiles files, Func<string, TextureImage?> load) {
    private readonly record struct Permutation(Identifier Texture, Identifier PaletteKey, Identifier Palette);

    private readonly Dictionary<string, Dictionary<Identifier, Permutation>> _atlases = new();
    private readonly Dictionary<Identifier, uint[]?> _paletteImages = new();
    private readonly Dictionary<(Identifier, Identifier), Dictionary<uint, uint>?> _mappings = new();

    /// <summary>The permutation sprite <paramref name="sprite"/> of the named atlas; null when no source makes it or its images are missing.</summary>
    public TextureImage? Sprite(string atlas, Identifier sprite) {
        if (!Sources(atlas).TryGetValue(sprite, out Permutation permutation)) {
            return null;
        }
        if (Mapping(permutation.PaletteKey, permutation.Palette) is not { } palette || load(FileOf(permutation.Texture)) is not { } image) {
            return null;
        }
        byte[] rgba = new byte[image.Rgba.Length];
        for (int i = 0; i < rgba.Length; i += 4) {
            uint pixel = Apply(palette, Argb(image.Rgba, i));
            rgba[i] = (byte)(pixel >> 16);
            rgba[i + 1] = (byte)(pixel >> 8);
            rgba[i + 2] = (byte)pixel;
            rgba[i + 3] = (byte)(pixel >> 24);
        }
        return new TextureImage(image.Width, image.Height, rgba);
    }

    /// <summary>
    /// <c>PalettedTextureManager.prepareSlot</c>: a texture recoloured from the palette its <c>.mcmeta</c> names
    /// as <c>base_palette</c> to <paramref name="paletteId"/>, palettes living under <c>textures/palettes</c>. Null
    /// when the texture is missing; a palette that is missing or of another size leaves the texture as it is.
    /// </summary>
    public TextureImage? PalettedTexture(Identifier baseTexture, Identifier paletteId) {
        string file = FileOf(baseTexture);
        if (load(file) is not { } image) {
            return null;
        }
        if (BasePalette(files.Read(file + ".mcmeta")) is not { } basePalette
            || Mapping(PaletteTexture(basePalette), PaletteTexture(paletteId)) is not { } palette) {
            return image;
        }
        byte[] rgba = new byte[image.Rgba.Length];
        for (int i = 0; i < rgba.Length; i += 4) {
            uint pixel = Apply(palette, Argb(image.Rgba, i));
            rgba[i] = (byte)(pixel >> 16);
            rgba[i + 1] = (byte)(pixel >> 8);
            rgba[i + 2] = (byte)pixel;
            rgba[i + 3] = (byte)(pixel >> 24);
        }
        return new TextureImage(image.Width, image.Height, rgba);
    }

    /// <summary><c>Palette.ID_CONVERTER</c>: a palette id names a texture under <c>textures/palettes</c>.</summary>
    private static Identifier PaletteTexture(Identifier palette) => new(palette.Namespace, "palettes/" + palette.Key);

    /// <summary><c>PaletteMetadataSection</c>: the <c>palette</c> section's <c>base_palette</c>, or null.</summary>
    private static Identifier? BasePalette(byte[]? meta) {
        if (meta == null) {
            return null;
        }
        try {
            return JObject.Parse(System.Text.Encoding.UTF8.GetString(meta))["palette"]?["base_palette"]?.Value<string>() is { } id ? (Identifier?)Identifier.Parse(id) : null;
        }
        catch (Exception e) when (e is Newtonsoft.Json.JsonException or FormatException or InvalidCastException or ArgumentException) {
            return null;
        }
    }

    private Dictionary<Identifier, Permutation> Sources(string atlas) {
        if (_atlases.TryGetValue(atlas, out Dictionary<Identifier, Permutation>? sprites)) {
            return sprites;
        }
        sprites = new Dictionary<Identifier, Permutation>();
        foreach (byte[] data in files.ReadEach($"assets/minecraft/atlases/{atlas}.json")) {
            try {
                if (JObject.Parse(System.Text.Encoding.UTF8.GetString(data))["sources"] is not JArray sources) {
                    continue;
                }
                foreach (JObject source in sources.OfType<JObject>()) {
                    if (source.Value<string>("type") is not ("paletted_permutations" or "minecraft:paletted_permutations")
                        || source.Value<string>("palette_key") is not { } paletteKey || source["permutations"] is not JObject permutations
                        || source["textures"] is not JArray textures) {
                        continue;
                    }
                    string separator = source.Value<string>("separator") ?? "_";
                    foreach (string texture in textures.Values<string>().OfType<string>()) {
                        Identifier textureId = Identifier.Parse(texture);
                        foreach ((string suffix, JToken? palette) in permutations) {
                            if (palette?.Value<string>() is { } paletteId) {
                                sprites[new Identifier(textureId.Namespace, textureId.Key + separator + suffix)] =
                                    new Permutation(textureId, Identifier.Parse(paletteKey), Identifier.Parse(paletteId));
                            }
                        }
                    }
                }
            }
            catch (Newtonsoft.Json.JsonException) {
                // A definition that does not parse adds nothing, as the rest of the pack still loads.
            }
        }
        _atlases[atlas] = sprites;
        return sprites;
    }

    private Dictionary<uint, uint>? Mapping(Identifier paletteKey, Identifier palette) {
        if (!_mappings.TryGetValue((paletteKey, palette), out Dictionary<uint, uint>? mapping)) {
            mapping = PaletteImage(paletteKey) is { } keys && PaletteImage(palette) is { } values ? CreatePaletteMapping(keys, values) : null;
            _mappings[(paletteKey, palette)] = mapping;
        }
        return mapping;
    }

    /// <summary><c>loadPaletteEntryFromImage</c>: every pixel, row by row, as ARGB.</summary>
    private uint[]? PaletteImage(Identifier location) {
        if (!_paletteImages.TryGetValue(location, out uint[]? pixels)) {
            pixels = load(FileOf(location)) is { } image ? Enumerable.Range(0, image.Width * image.Height).Select(i => Argb(image.Rgba, i * 4)).ToArray() : null;
            _paletteImages[location] = pixels;
        }
        return pixels;
    }

    private static string FileOf(Identifier id) => $"assets/{id.Namespace}/textures/{id.Key}.png";

    private static uint Argb(byte[] rgba, int i) => (uint)(rgba[i + 3] << 24 | rgba[i] << 16 | rgba[i + 1] << 8 | rgba[i + 2]);

    /// <summary><c>createPaletteMapping</c>'s table: each opaque key colour to its value; null when the two differ in size.</summary>
    public static Dictionary<uint, uint>? CreatePaletteMapping(uint[] keys, uint[] values) {
        if (values.Length != keys.Length) {
            return null;
        }
        Dictionary<uint, uint> palette = new(values.Length);
        for (int i = 0; i < keys.Length; i++) {
            if (keys[i] >> 24 != 0) {
                palette[keys[i] & 0xFFFFFF] = values[i];
            }
        }
        return palette;
    }

    /// <summary>
    /// <c>createPaletteMapping</c>'s operator on one ARGB pixel: a colour the key lacks stays as it is,
    /// and the alphas multiply.
    /// </summary>
    public static uint Apply(Dictionary<uint, uint> palette, uint pixel) {
        uint pixelAlpha = pixel >> 24;
        if (pixelAlpha == 0) {
            return pixel;
        }
        uint pixelRgb = pixel & 0xFFFFFF;
        uint value = palette.TryGetValue(pixelRgb, out uint mapped) ? mapped : pixelRgb | 0xFF000000;
        uint valueAlpha = value >> 24;
        return pixelAlpha * valueAlpha / 255 << 24 | value & 0xFFFFFF;
    }
}
