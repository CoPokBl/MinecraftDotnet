using System.Numerics;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// <c>BlockRenderDispatcher.renderSingleBlock</c>: a block state's model drawn through a pose, the way a
/// minecart's contents, a falling block, an enderman's held block or a mooshroom's mushrooms are drawn.
/// The model spans 0 to 1 from the pose's origin.
/// </summary>
public sealed class BlockModelRenderer {
    // The colours BlockColors gives a block with no level to look a biome up in.
    private const uint DefaultFoliage = 0x48B518;
    private const uint DefaultDryFoliage = 0xA0A069;
    private const uint DefaultWater = 0x3F76E4;

    private readonly ResourcePackSource? _pack;
    private readonly EntityTextures _textures;
    private readonly uint _defaultGrass;
    private readonly Dictionary<IBlock, (BakedBlockModel? Model, TintSource[] Tints)> _models = new();
    private readonly Dictionary<string, BakedBlockModel?> _fakeModels = new();

    public BlockModelRenderer(ResourcePackSource? pack, EntityTextures textures) {
        _pack = pack;
        _textures = textures;
        // GrassColor.getDefaultColor: the grass colour map at temperature 0.5 and downfall 1.
        _defaultGrass = pack?.ColourMaps().Grass is { } grass && grass.Width * grass.Height > 0x7F7F
            ? (uint)(grass.Rgba[0x7F7F * 4] << 16 | grass.Rgba[0x7F7F * 4 + 1] << 8 | grass.Rgba[0x7F7F * 4 + 2])
            : 0x91BD59;
    }

    /// <summary>
    /// False when there is no model for it, so the caller can leave it out. <paramref name="whiteOverlay"/> is
    /// what a primed TNT flashes with, <c>OverlayTexture.u(whiteOverlay)</c>.
    /// </summary>
    public bool Render(IBlock state, PoseStack pose, IModelSink sink, float skyLight, float blockLight, uint argb = 0xFFFFFFFF, float whiteOverlay = 0) {
        if (_pack == null || state.Air) {
            return false;
        }
        if (!_models.TryGetValue(state, out (BakedBlockModel? Model, TintSource[] Tints) entry)) {
            entry = (_pack.BlockModel(state), BlockTints.For(state));
            _models[state] = entry;
        }
        return entry.Model is { } model && Draw(model, entry.Tints, pose, sink, skyLight, blockLight, argb, whiteOverlay);
    }

    /// <summary>
    /// A variant of a blockstate file no registered block owns, as <c>BlockStateDefinitions</c> fakes the
    /// item frames' states; false when the pack has no such file.
    /// </summary>
    public bool Render(Identifier blockstate, IReadOnlyDictionary<string, string> properties, PoseStack pose, IModelSink sink, float skyLight, float blockLight) {
        if (_pack == null) {
            return false;
        }
        string key = blockstate + "[" + string.Join(",", properties.Select(p => p.Key + "=" + p.Value)) + "]";
        if (!_fakeModels.TryGetValue(key, out BakedBlockModel? model)) {
            model = _pack.BlockModel(blockstate, properties);
            _fakeModels[key] = model;
        }
        return model != null && Draw(model, [], pose, sink, skyLight, blockLight, 0xFFFFFFFF, 0);
    }

    private bool Draw(BakedBlockModel model, TintSource[] tints, PoseStack pose, IModelSink sink, float skyLight, float blockLight, uint argb, float whiteOverlay) {
        ResourcePackSource pack = _pack!;
        BakedOption[] chosen = new BakedOption[model.Parts.Length];
        // renderSingleBlock seeds the variant draw with 42 rather than from a position; this draws as the
        // block at the origin would, which differs only for a state with weighted variants.
        model.Choose(0, 0, 0, chosen);
        Matrix4x4 matrix = pose.Matrix;
        Span<Vector3> corners = stackalloc Vector3[4];
        foreach (BakedOption option in chosen) {
            foreach (BakedQuad quad in option.Quads) {
                string? id = quad.Texture;
                EntityTexture texture = _textures.Get("model:" + id, () => pack.ModelTexture(id)) ?? _textures.Missing;
                uint tint = quad.TintIndex >= 0 && quad.TintIndex < tints.Length ? Colour(tints[quad.TintIndex]) : 0xFFFFFF;
                for (int i = 0; i < 4; i++) {
                    corners[i] = Vector3.Transform(quad.Positions[i], matrix);
                }
                uint colour = Argb.Multiply(argb, 0xFF000000 | tint);
                float block = quad.LightEmission > 0 ? Math.Max(blockLight, quad.LightEmission) : blockLight;
                sink.Quad(corners, quad.Uvs, pose.TransformNormal(Directions.Normals[quad.Direction]), new ModelDrawState(texture, colour, skyLight, block, 0, whiteOverlay));
            }
        }
        return true;
    }

    private uint Colour(TintSource source) => source.Kind switch {
        TintKind.Grass => _defaultGrass,
        TintKind.Foliage => DefaultFoliage,
        TintKind.DryFoliage => DefaultDryFoliage,
        TintKind.Water => DefaultWater,
        _ => source.Rgb
    };
}
