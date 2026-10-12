using GraphicalClient.Rendering;
using Minecraft.Data.Blocks;
using Minecraft.Data.Items;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// Block appearances and textures from resource packs the user supplies, the game's own jar among
/// them if they choose. Anything the packs do not cover falls back to <paramref name="fallback"/>, so a
/// pack that only retextures a few blocks still gives a whole world.
/// </summary>
public sealed class ResourcePackSource(PackFiles files, IResourceSource fallback) : IResourceSource {
    private const string PackPrefix = "pack:";

    private readonly BlockModelBaker _baker = new(files);

    /// <summary>
    /// Held around everything that touches the baker or the texture cache, neither of which is safe to
    /// share: entity and item models are built on workers while the game thread asks for its own.
    /// </summary>
    private readonly Lock _gate = new();
    private readonly Dictionary<string, TextureImage> _textures = new();
    private ItemIcons? _items;

    private ItemIcons Items => _items ??= new ItemIcons(files, _baker, id => Texture(BlockModels.TextureKey(id)), ColourMaps());

    public IReadOnlyList<string> Warnings => _baker.Warnings;

    public BlockAppearance Appearance(IBlock state) {
        string path = state.Identifier.Key;
        // Fluids are drawn by the client's own fluid mesher, which only needs the still texture.
        if (path is "water" or "lava") {
            string texture = PackPrefix + $"minecraft:block/{path}_still";
            return new BlockAppearance(BlockGeometry.Fluid, path == "water" ? RenderLayer.Translucent : RenderLayer.Solid,
                [texture, texture, texture, texture, texture, texture], path == "lava", path == "water" ? TintKind.Water : TintKind.None);
        }
        BakedBlockModel? model = _baker.Bake(state);
        if (model == null) {
            return fallback.Appearance(state);
        }
        string particle = BlockModels.TextureKey(model.Particle);
        if (!model.Parts.Any(p => p.Options.Any(o => o.Quads.Length > 0))) {
            // Chests, banners, heads and the like have an empty block model: their block entity renderer draws them.
            return BlockAppearance.Invisible with { Particle = particle };
        }
        return new BlockAppearance(BlockGeometry.Model, RenderLayer.Solid, ["", "", "", "", "", ""], Model: model, Tints: BlockTints.For(state),
            Particle: particle);
    }

    public TextureImage Texture(string key) {
        lock (_gate) {
            return TextureLocked(key);
        }
    }

    private TextureImage TextureLocked(string key) {
        if (key == "missing") {
            return DevArt.MissingTexture();
        }
        if (!key.StartsWith(PackPrefix, StringComparison.Ordinal)) {
            return fallback.Texture(key);
        }
        if (!_textures.TryGetValue(key, out TextureImage? texture)) {
            texture = LoadFirstFrame(FileOf(key));
            if (texture == null) {
                _baker.Warnings.Add($"Missing texture {Minecraft.Schemas.Identifier.Parse(key[PackPrefix.Length..])}");
                texture = DevArt.MissingTexture();
            }
            _textures[key] = texture;
        }
        return texture;
    }

    /// <summary>The pack file a <c>pack:</c> texture key names.</summary>
    private static string FileOf(string key) {
        Minecraft.Schemas.Identifier id = Minecraft.Schemas.Identifier.Parse(key[PackPrefix.Length..]);
        return $"assets/{id.Namespace}/textures/{id.Key}.png";
    }

    public TextureAnimation? Animation(string key) {
        if (!key.StartsWith(PackPrefix, StringComparison.Ordinal)) {
            return null;
        }
        string file = FileOf(key);
        byte[]? meta = files.Read(file + ".mcmeta");
        return meta != null && Load(file) is { } image ? TextureAnimation.Read(image, meta) : null;
    }

    public string SpriteKey(Minecraft.Schemas.Identifier sprite) => BlockModels.TextureKey(sprite);

    /// <summary>A pack image by its path, cut to its first frame when its <c>.mcmeta</c> animates it.</summary>
    public TextureImage? LoadFirstFrame(string file) => Load(file) is { } image ? FirstFrame(image, files.Read(file + ".mcmeta")) : null;

    /// <summary>A pack image by its path, or null when no pack has it or it does not decode.</summary>
    public TextureImage? Load(string file) {
        byte[]? data = files.Read(file);
        if (data == null) {
            return null;
        }
        try {
            return Png.Decode(data);
        }
        catch (Exception e) when (e is InvalidDataException or IndexOutOfRangeException or ArgumentException) {
            lock (_gate) {
                _baker.Warnings.Add($"{file}: {e.Message}");
            }
            return null;
        }
    }

    /// <summary>
    /// An animated texture is a strip of frames, square unless its <c>.mcmeta</c> gives a frame size.
    /// Only the first frame is drawn.
    /// </summary>
    private static TextureImage FirstFrame(TextureImage image, byte[]? meta) {
        if (meta == null) {
            return image;
        }
        int width = image.Width, height = Math.Min(image.Width, image.Height);
        try {
            if (JObject.Parse(System.Text.Encoding.UTF8.GetString(meta))["animation"] is JObject animation) {
                width = animation.Value<int?>("width") ?? width;
                height = animation.Value<int?>("height") ?? height;
            }
        }
        catch (Newtonsoft.Json.JsonException) {
            return image;
        }
        width = Math.Clamp(width, 1, image.Width);
        height = Math.Clamp(height, 1, image.Height);
        return width == image.Width && height == image.Height ? image : image.Region(0, 0, width, height);
    }

    public Rendering.BiomeColours.ColourMaps ColourMaps() => new(
        Load("assets/minecraft/textures/colormap/grass.png"),
        Load("assets/minecraft/textures/colormap/foliage.png"),
        Load("assets/minecraft/textures/colormap/dry_foliage.png"));

    public TextureImage ItemIcon(IItem item) {
        lock (_gate) {
            return Items.Icon(item) ?? fallback.ItemIcon(item);
        }
    }

    public ItemModelNode? ItemDefinition(Minecraft.Schemas.Identifier modelId) {
        lock (_gate) {
            return Items.Definition(modelId);
        }
    }

    public TextureImage? ItemIcon(IReadOnlyList<ItemModelLayer> layers, Minecraft.Schemas.Items.ItemStack stack) {
        lock (_gate) {
            return Items.Icon(layers, stack);
        }
    }

    public string? SpecialIdentity(IReadOnlyList<ItemModelLayer> layers, Minecraft.Schemas.Items.ItemStack stack) {
        lock (_gate) {
            return Items.SpecialIdentity(layers, stack);
        }
    }

    /// <summary>A pack file's bytes by its path from the pack root, <c>assets/minecraft/equipment/iron.json</c>; null when no pack has it.</summary>
    public byte[]? ReadFile(string path) => files.Read(path);

    /// <summary>A block state's baked model, or null when the packs have none.</summary>
    public BakedBlockModel? BlockModel(IBlock state) {
        lock (_gate) {
            return _baker.Bake(state);
        }
    }

    /// <summary>A blockstate file's model for the given properties, for a state no registered block has; null when the packs have no such file.</summary>
    public BakedBlockModel? BlockModel(Minecraft.Schemas.Identifier blockstate, IReadOnlyDictionary<string, string> properties) {
        lock (_gate) {
            return _baker.Bake(blockstate, properties);
        }
    }

    /// <summary>A model texture by identifier, <c>minecraft:block/stone</c>; the missing checks when no pack has it.</summary>
    public TextureImage ModelTexture(string? id) => Texture(BlockModels.TextureKey(id));

    public uint ColourOf(string identifierPath) => fallback.ColourOf(identifierPath);
}
