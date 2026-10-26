using System.Numerics;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Special;

/// <summary>
/// Special models drawn into GUI icons, as vanilla draws them into its GUI item atlas: the renderer's
/// geometry in item model space, painted straight from the sprites' pixels.
/// </summary>
public sealed class SpecialItemIcons(Func<SpriteId, TextureImage?> images) {
    private readonly Lock _lock = new();
    private readonly ImageSprites _sprites = new(images);
    private readonly Dictionary<ISpecialModelUnbaked, ISpecialModelRenderer?> _baked = new();

    private ISpecialModelRenderer? Renderer(ISpecialModelUnbaked unbaked) {
        if (!_baked.TryGetValue(unbaked, out ISpecialModelRenderer? renderer)) {
            renderer = unbaked.Bake(new SpecialModelBakingContext { Sprites = _sprites });
            _baked[unbaked] = renderer;
        }
        return renderer;
    }

    /// <summary>What a stack draws as under its models' special renderers, joined; null when that is what a stack with no components draws.</summary>
    public string? Identity(IEnumerable<ItemModel> models, ItemStack stack) {
        string? identity = null;
        lock (_lock) {
            foreach (ItemModel model in models) {
                if (model.Special is { } unbaked && Renderer(unbaked) is { } renderer && renderer.IdentityOf(renderer.ExtractArgument(stack)) is { } own) {
                    identity = identity == null ? own : identity + "+" + own;
                }
            }
        }
        return identity == null ? null : stack.Type.Identifier + "#" + identity;
    }

    /// <summary>
    /// The quads a special model draws under its definition's <paramref name="local"/> transform, for a
    /// stack or, without one, for a stack with no components.
    /// </summary>
    public List<IconQuad> Quads(ISpecialModelUnbaked unbaked, Matrix4x4 local, ItemStack? stack) {
        lock (_lock) {
            if (Renderer(unbaked) is not { } renderer) {
                return [];
            }
            Capture sink = new(_sprites);
            PoseStack pose = new();
            pose.MulPose(local);
            renderer.Submit(stack != null ? renderer.ExtractArgument(stack) : null, pose, sink, 15, 15);
            return sink.Quads;
        }
    }

    private sealed class Capture(ImageSprites sprites) : IModelSink {
        public readonly List<IconQuad> Quads = [];

        public void Quad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, Vector3 normal, ModelDrawState draw) =>
            Quads.Add(new IconQuad(corners.ToArray(), uvs.ToArray(), sprites.ImageOf(draw.Texture), draw.Argb & 0xFFFFFF));
    }
}
