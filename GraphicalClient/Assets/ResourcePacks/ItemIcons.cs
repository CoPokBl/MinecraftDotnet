using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// Item definitions from a pack (<c>assets/*/items/*.json</c>), read into their trees, and inventory icons
/// drawn from what a tree chose. A special model whose type is not ported reads as the missing model, so
/// an item drawn only by one has no model to draw and is left to the caller.
/// </summary>
public sealed class ItemIcons(PackFiles files, BlockModelBaker baker, Func<string?, TextureImage> texture, Rendering.BiomeColours.ColourMaps maps) {
    private const int Size = 64;

    private readonly ItemModelTree _tree = new(baker, maps);
    private readonly Dictionary<Identifier, ItemModelNode?> _definitions = new();
    private readonly Dictionary<Identifier, ClientItemProperties> _properties = new();
    private SpecialItemIcons? _special;

    private SpecialItemIcons Special => _special ??= new SpecialItemIcons(sprite => texture(sprite.Texture));

    /// <summary>The definition a model id names, <c>ClientItem.model</c>; null when no pack has one.</summary>
    public ItemModelNode? Definition(Identifier modelId) {
        if (_definitions.TryGetValue(modelId, out ItemModelNode? definition)) {
            return definition;
        }
        byte[]? data = files.Read($"assets/{modelId.Namespace}/items/{modelId.Key}.json");
        if (data != null) {
            try {
                JObject json = JObject.Parse(System.Text.Encoding.UTF8.GetString(data));
                if (json["model"] is JObject root) {
                    definition = _tree.Read(root);
                    _properties[modelId] = ClientItemProperties.Read(json);
                }
            }
            catch (Newtonsoft.Json.JsonException e) {
                baker.Warnings.Add($"{modelId}: {e.Message}");
            }
        }
        _definitions[modelId] = definition;
        return definition;
    }

    /// <summary><c>ClientItem.properties</c> of the definition a model id names, the defaults when no pack has one.</summary>
    public ClientItemProperties Properties(Identifier modelId) {
        Definition(modelId);
        return _properties.GetValueOrDefault(modelId, ClientItemProperties.Default);
    }

    /// <summary>The icon of a stack with nothing to read, as <see cref="ItemModelNode.UpdateDefault"/> resolves it.</summary>
    public TextureImage? Icon(IItem item) {
        if (Definition(item.Identifier) is not { } definition) {
            return null;
        }
        ItemModelOutput output = new();
        definition.UpdateDefault(output, item);
        return Icon(output.Layers, null);
    }

    /// <summary>What a stack's special layers draw as, joined; null when that is what a stack with no components draws.</summary>
    public string? SpecialIdentity(IReadOnlyList<ItemModelLayer> layers, ItemStack stack) => Special.Identity(layers.Select(l => l.Leaf.Model), stack);

    /// <summary>The layers a tree chose, drawn into an icon; special layers read <paramref name="stack"/>, or a stack with no components.</summary>
    public TextureImage? Icon(IReadOnlyList<ItemModelLayer> layers, ItemStack? stack) {
        if (layers.Count == 0) {
            return null;
        }
        if (layers.All(l => l.Leaf.Model.Layers.Length > 0)) {
            return Flat(layers);
        }
        List<IconQuad> quads = [];
        foreach ((ItemModelLeaf leaf, uint[] tints, _) in layers) {
            ItemModel model = leaf.Model;
            if (model.Special != null) {
                quads.AddRange(Special.Quads(model.Special, model.Local, stack));
                continue;
            }
            foreach (BakedQuad quad in model.Quads) {
                quads.Add(new IconQuad(quad.Positions, quad.Uvs, texture(quad.Texture),
                    quad.TintIndex >= 0 && quad.TintIndex < tints.Length ? tints[quad.TintIndex] : 0xFFFFFF));
            }
        }
        if (quads.Count == 0) {
            return null;
        }
        return IconRasterizer.Render(quads, layers[0].Leaf.Model.Gui, layers[0].Leaf.Model.SideLit, Size);
    }

    /// <summary>Generated items: the sprite layers stacked in order, each multiplied by its tint.</summary>
    private TextureImage Flat(IReadOnlyList<ItemModelLayer> models) {
        List<(TextureImage Image, uint Tint)> layers = [];
        foreach ((ItemModelLeaf leaf, uint[] tints, _) in models) {
            ItemModel model = leaf.Model;
            for (int i = 0; i < model.Layers.Length; i++) {
                layers.Add((texture(model.Layers[i]), i < tints.Length ? tints[i] : 0xFFFFFF));
            }
        }
        int size = layers.Max(l => Math.Max(l.Image.Width, l.Image.Height));
        byte[] rgba = new byte[size * size * 4];
        foreach ((TextureImage image, uint tint) in layers) {
            byte[] source = image.Resized(size).Rgba;
            for (int i = 0; i < size * size; i++) {
                int a = source[i * 4 + 3];
                if (a == 0) {
                    continue;
                }
                for (int c = 0; c < 3; c++) {
                    int channel = source[i * 4 + c] * (int)((tint >> (16 - c * 8)) & 0xFF) / 255;
                    rgba[i * 4 + c] = (byte)((channel * a + rgba[i * 4 + c] * (255 - a)) / 255);
                }
                rgba[i * 4 + 3] = (byte)Math.Min(255, a + rgba[i * 4 + 3] * (255 - a) / 255);
            }
        }
        return new TextureImage(size, size, rgba);
    }
}
