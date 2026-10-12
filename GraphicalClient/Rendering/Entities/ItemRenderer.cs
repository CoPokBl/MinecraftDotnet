using System.Numerics;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Quaternion = System.Numerics.Quaternion;

namespace GraphicalClient.Rendering.Entities;

/// <summary><c>ItemDisplayContext</c>, each with the <c>display</c> key a model poses it under.</summary>
public enum ItemDisplayContext {
    None,
    ThirdPersonLeftHand,
    ThirdPersonRightHand,
    FirstPersonLeftHand,
    FirstPersonRightHand,
    Head,
    Gui,
    Ground,
    Fixed,
    OnShelf
}

/// <summary>One quad of an item ready to draw: corners in model space (0 to 1 across the block), its texture and tint.</summary>
public readonly record struct ItemQuad(Vector3[] Positions, Vector2[] Uvs, EntityTexture Texture, uint Argb, Vector3 Normal);

/// <summary>
/// <c>ItemStackRenderState</c>: the layers a stack's model draws, each posed by the display context's
/// transform, with the glint each layer takes and what its special renderer read off the stack.
/// </summary>
public sealed class ItemStackModel {
    public sealed record Layer(ItemQuad[] Quads, ItemTransform Transform) {
        public SpecialLayer? Special { get; init; }
        public FoilType Foil { get; init; }
    }

    /// <summary>
    /// <c>LayerRenderState.setupSpecialModel</c>: a renderer drawing in place of quads, under the item
    /// definition's <paramref name="Local"/> transform, with what it read off the stack.
    /// </summary>
    public sealed record SpecialLayer(ISpecialModelRenderer Renderer, Matrix4x4 Local, object? Argument);

    public required Layer[] Layers { get; init; }

    /// <summary><c>getModelBoundingBox</c>: every corner, through its layer's transform.</summary>
    public (Vector3 Min, Vector3 Max) ModelBoundingBox { get; init; }
}

/// <summary>
/// Items drawn in the world, as <c>ItemModelResolver</c> and the item feature renderer draw them: the
/// layers the stack's definition chose for the display context and owner, sprites extruded as
/// <c>ItemModelGenerator</c> does, or a special renderer, each with its glint. Without a pack the built
/// in art's definitions stand in. An item with no definition, or whose tree reached a model not ported,
/// has its icon extruded as a generated model would be.
/// </summary>
public sealed class ItemRenderer {
    /// <summary>
    /// The atlas a sprite's texels are taken over for its glint. Vanilla scrolls the glint along a quad's
    /// atlas coordinates, so how much of it an item shows depends on the atlas its sprite was stitched into;
    /// this client has none. Vanilla's own item textures and trim permutations come to about 226 thousand
    /// texels, which stitch into 512 by 512, so a 16 texel sprite spans a 32nd of it. Other packs and
    /// block items, which vanilla takes from the larger block atlas, show a different share.
    /// </summary>
    private static readonly Vector2 GlintAtlasSize = new(512.0F, 512.0F);

    private readonly ResourcePackSource? _pack;
    private readonly IResourceSource _art;
    private readonly EntityTextures _textures;
    private readonly ItemModelResolver _resolver;
    private readonly Dictionary<LayerKey, BuiltLayer?> _layers = new();
    private readonly Dictionary<LayerKey, Task<BuiltLayer?>> _building = new();

    /// <summary>What an item last drew in each context, drawn while a layer it moved on to is built, so a turning compass does not blink.</summary>
    private readonly Dictionary<(IItem, ItemDisplayContext), ItemStackModel> _lastDrawn = new();
    private readonly SpecialModelBakingContext _special;

    /// <summary>One build at a time: the built in art the icon fallback reads is not safe to share.</summary>
    private readonly Lock _buildLock = new();

    /// <summary>A leaf drawn with given tints in a display context, or an item's icon standing in when <see cref="Leaf"/> is null.</summary>
    private readonly record struct LayerKey(ItemModelLeaf? Leaf, IItem Item, ItemDisplayContext Context, uint[] Tints) {
        public bool Equals(LayerKey other) =>
            Leaf == other.Leaf && Context == other.Context && (Leaf != null || Item.Identifier == other.Item.Identifier) && Tints.AsSpan().SequenceEqual(other.Tints);

        public override int GetHashCode() {
            HashCode hash = new();
            hash.Add(Leaf?.Id ?? Item.Identifier.GetHashCode());
            hash.Add(Context);
            foreach (uint tint in Tints) {
                hash.Add(tint);
            }
            return hash.ToHashCode();
        }
    }

    /// <summary>A layer built once, with the corners its geometry reaches through its transform.</summary>
    private sealed record BuiltLayer(ItemStackModel.Layer Layer, Vector3 Min, Vector3 Max);

    public ItemRenderer(ResourcePackSource? pack, IResourceSource art, EntityTextures textures, ItemModelResolver resolver) {
        _pack = pack;
        _art = art;
        _textures = textures;
        _resolver = resolver;
        _special = new SpecialModelBakingContext {
            Sprites = new EntityTextureSprites(textures, sprite => pack != null ? pack.LoadFirstFrame(sprite.PackPath) : DevArtSprites.Image(sprite))
        };
    }

    private static readonly string[] DisplayKeys = [
        "none", "thirdperson_lefthand", "thirdperson_righthand", "firstperson_lefthand", "firstperson_righthand", "head", "gui", "ground", "fixed", "on_shelf"
    ];

    public static string DisplayKey(ItemDisplayContext context) => DisplayKeys[(int)context];

    public static bool IsLeftHand(ItemDisplayContext context) => context is ItemDisplayContext.FirstPersonLeftHand or ItemDisplayContext.ThirdPersonLeftHand;

    /// <summary>The model a stack of an item with no components draws in a display context, with no owner.</summary>
    public ItemStackModel? Resolve(IItem item, ItemDisplayContext context) => Resolve(new ItemStack(item), context);

    /// <summary>
    /// <c>ItemModelResolver.updateForTopItem</c>, with <c>updateForLiving</c>'s or <c>updateForNonLiving</c>'s
    /// seed for <paramref name="owner"/>; <paramref name="heldIn"/> is the owner's hand this stack is in.
    /// Null for a stack with nothing to draw, and for the frame or two a layer takes to build on a worker.
    /// </summary>
    public ItemStackModel? Resolve(ItemStack stack, ItemDisplayContext context, ClientLib.Entities.ClientEntity? owner = null, Hand? heldIn = null) {
        if (stack.IsAir()) {
            return null;
        }
        ItemModelOutput output = _resolver.Update(stack, context, owner, ItemModelResolver.SeedFor(owner, context), heldIn);
        if (output.Layers.Count == 0) {
            if (!output.Missing) {
                return null;
            }
            if (!TryLayer(new LayerKey(null, stack.Type, context, []), out BuiltLayer? icon) || icon == null) {
                return null;
            }
            ItemStackModel.Layer layer = ClientLib.Interaction.ItemModelProperties.HasFoil(stack) ? icon.Layer with { Foil = FoilType.Standard } : icon.Layer;
            return new ItemStackModel { Layers = [layer], ModelBoundingBox = (icon.Min, icon.Max) };
        }
        ItemStackModel.Layer[] layers = new ItemStackModel.Layer[output.Layers.Count];
        Vector3 min = new(float.MaxValue), max = new(float.MinValue);
        int count = 0;
        bool pending = false;
        foreach ((ItemModelLeaf leaf, uint[] tints, FoilType foil) in output.Layers) {
            if (!TryLayer(new LayerKey(leaf, stack.Type, context, tints), out BuiltLayer? built)) {
                pending = true;
                continue;
            }
            if (built == null) {
                continue;
            }
            ItemStackModel.Layer layer = built.Layer;
            if (layer.Special is { } special) {
                layer = layer with { Special = special with { Argument = special.Renderer.ExtractArgument(stack) } };
            }
            if (foil != FoilType.None) {
                layer = layer with { Foil = foil };
            }
            layers[count++] = layer;
            min = Vector3.Min(min, built.Min);
            max = Vector3.Max(max, built.Max);
        }
        if (pending) {
            return _lastDrawn.GetValueOrDefault((stack.Type, context));
        }
        if (count == 0) {
            return null;
        }
        ItemStackModel model = new() { Layers = count == layers.Length ? layers : layers[..count], ModelBoundingBox = (min, max) };
        _lastDrawn[(stack.Type, context)] = model;
        return model;
    }

    /// <summary>A layer, built on a worker the first time it is asked for; false until it is ready. Null once ready is a layer with nothing to draw.</summary>
    private bool TryLayer(LayerKey key, out BuiltLayer? built) {
        if (_layers.TryGetValue(key, out built)) {
            return true;
        }
        if (!_building.TryGetValue(key, out Task<BuiltLayer?>? task)) {
            _building[key] = Task.Run(() => {
                lock (_buildLock) {
                    return Build(key);
                }
            });
            return false;
        }
        if (!task.IsCompleted) {
            return false;
        }
        _building.Remove(key);
        built = task.IsCompletedSuccessfully ? task.Result : null;
        _layers[key] = built;
        return true;
    }

    /// <summary><c>ItemStackRenderState.submit</c>: each layer under its transform, through the current pose, and the glint over it.</summary>
    public void Submit(ItemStackModel model, ItemDisplayContext context, PoseStack pose, IModelSink sink, float skyLight, float blockLight) {
        bool leftHand = IsLeftHand(context);
        Span<Vector3> corners = stackalloc Vector3[4];
        Span<Vector2> glintUvs = stackalloc Vector2[4];
        foreach (ItemStackModel.Layer layer in model.Layers) {
            pose.Push();
            Apply(layer.Transform, leftHand, pose);
            if (layer.Special is { } special) {
                pose.MulPose(special.Local);
                special.Renderer.Submit(special.Argument, pose, sink, skyLight, blockLight);
                if (layer.Foil != FoilType.None) {
                    special.Renderer.SubmitFoil(special.Argument, pose, sink);
                }
                pose.Pop();
                continue;
            }
            Matrix4x4 matrix = pose.Matrix;
            foreach (ItemQuad quad in layer.Quads) {
                for (int i = 0; i < 4; i++) {
                    corners[i] = Vector3.Transform(quad.Positions[i], matrix);
                }
                sink.Quad(corners, quad.Uvs, pose.TransformNormal(quad.Normal), new ModelDrawState(quad.Texture, quad.Argb, skyLight, blockLight, 0));
                if (layer.Foil != FoilType.None) {
                    GlintUvs(quad.Positions, quad.Uvs, quad.Normal, quad.Texture.Width, quad.Texture.Height, layer.Foil, context, glintUvs);
                    sink.Glint(corners, glintUvs, GlintType.Item);
                }
            }
            pose.Pop();
        }
    }

    /// <summary>
    /// Where a quad's corners fall on the glint before its texturing. A standard glint runs along the
    /// sprite's texels, as vanilla's runs along its atlas coordinates. A special one is
    /// <c>SheetedDecalTextureGenerator</c> under <c>computeFoilDecalPose</c>: the corner in model space,
    /// grown by half again in first person and doubled in the GUI, turned to face along the face's nearest
    /// direction, a 128th of a texture to the block.
    /// </summary>
    public static void GlintUvs(ReadOnlySpan<Vector3> positions, ReadOnlySpan<Vector2> uvs, Vector3 normal, int textureWidth, int textureHeight,
        FoilType foil, ItemDisplayContext context, Span<Vector2> output) {
        if (foil != FoilType.Special) {
            Vector2 span = new Vector2(textureWidth, textureHeight) / GlintAtlasSize;
            for (int i = 0; i < 4; i++) {
                output[i] = uvs[i] * span;
            }
            return;
        }
        float scale = context == ItemDisplayContext.Gui ? 0.5F
            : context is ItemDisplayContext.FirstPersonLeftHand or ItemDisplayContext.FirstPersonRightHand ? 0.75F : 1.0F;
        Quaternion turn = DirectionRotation(Directions.Nearest(normal)) * Quaternion.CreateFromAxisAngle(Vector3.UnitX, -MathF.PI / 2)
                          * Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.PI);
        for (int i = 0; i < 4; i++) {
            Vector3 world = Vector3.Transform(positions[i] / scale, turn);
            output[i] = new Vector2(-world.X, -world.Y) * 0.0078125F;
        }
    }

    /// <summary><c>Direction.getRotation</c>, by <see cref="Directions"/> index.</summary>
    private static Quaternion DirectionRotation(int direction) {
        Quaternion X(float angle) => Quaternion.CreateFromAxisAngle(Vector3.UnitX, angle);
        Quaternion Z(float angle) => Quaternion.CreateFromAxisAngle(Vector3.UnitZ, angle);
        return direction switch {
            0 => X(MathF.PI),
            1 => Quaternion.Identity,
            2 => X(MathF.PI / 2) * Z(MathF.PI),
            3 => X(MathF.PI / 2),
            4 => X(MathF.PI / 2) * Z(MathF.PI / 2),
            _ => X(MathF.PI / 2) * Z(-MathF.PI / 2)
        };
    }

    /// <summary>A stack in a display context; nothing for an empty one.</summary>
    public void Render(ItemStack? stack, ItemDisplayContext context, PoseStack pose, IModelSink sink, float skyLight, float blockLight,
        ClientLib.Entities.ClientEntity? owner = null, Hand? heldIn = null) {
        if (stack == null || stack.IsAir() || Resolve(stack, context, owner, heldIn) is not { } model) {
            return;
        }
        Submit(model, context, pose, sink, skyLight, blockLight);
    }

    /// <summary><c>ItemTransform.apply</c>: the left hand mirrors x and the y and z turns.</summary>
    public static void Apply(ItemTransform transform, bool leftHand, PoseStack pose) {
        if (transform == ItemTransform.None) {
            pose.Translate(-0.5F, -0.5F, -0.5F);
            return;
        }
        float sign = leftHand ? -1 : 1;
        pose.Translate(transform.Translation.X * sign, transform.Translation.Y, transform.Translation.Z);
        pose.RotateXYZ(transform.Rotation.X * Mth.DegToRad, transform.Rotation.Y * sign * Mth.DegToRad, transform.Rotation.Z * sign * Mth.DegToRad);
        pose.Scale(transform.Scale.X, transform.Scale.Y, transform.Scale.Z);
        pose.Translate(-0.5F, -0.5F, -0.5F);
    }

    private BuiltLayer? Build(LayerKey key) {
        ItemStackModel.Layer? layer = key.Leaf is { } leaf ? BuildLeaf(leaf.Model, key.Context, key.Tints) : BuildIcon(key.Item, key.Context);
        if (layer == null) {
            return null;
        }
        Vector3 min = new(float.MaxValue), max = new(float.MinValue);
        PoseStack pose = new();
        Apply(layer.Transform, false, pose);
        void Include(Vector3 corner) {
            Vector3 at = Vector3.Transform(corner, pose.Matrix);
            min = Vector3.Min(min, at);
            max = Vector3.Max(max, at);
        }
        if (layer.Special is { } special) {
            pose.MulPose(special.Local);
            special.Renderer.GetExtents(Include);
        }
        foreach (ItemQuad quad in layer.Quads) {
            foreach (Vector3 corner in quad.Positions) {
                Include(corner);
            }
        }
        if (min.X > max.X) {
            min = max = Vector3.Zero;
        }
        return new BuiltLayer(layer, min, max);
    }

    private ItemStackModel.Layer? BuildLeaf(ItemModel model, ItemDisplayContext context, uint[] tints) {
        ItemTransform transform = model.Transform(DisplayKey(context));
        if (model.Special != null) {
            return model.Special.Bake(_special) is { } renderer
                ? new ItemStackModel.Layer([], transform) { Special = new ItemStackModel.SpecialLayer(renderer, model.Local, null) }
                : null;
        }
        if (_pack == null) {
            return null;
        }
        List<ItemQuad> quads = [];
        if (model.Layers.Length > 0) {
            for (int i = 0; i < model.Layers.Length; i++) {
                string? id = model.Layers[i];
                EntityTexture? texture = _textures.GetNow("model:" + id, () => _pack.ModelTexture(id));
                if (texture != null) {
                    Extrude(_pack.ModelTexture(id), texture, i < tints.Length ? tints[i] : 0xFFFFFF, quads);
                }
            }
            if (!model.Local.IsIdentity) {
                for (int q = 0; q < quads.Count; q++) {
                    quads[q] = quads[q] with {
                        Positions = quads[q].Positions.Select(p => Vector3.Transform(p, model.Local)).ToArray(),
                        Normal = Vector3.Normalize(Vector3.TransformNormal(quads[q].Normal, model.Local))
                    };
                }
            }
        }
        foreach (BakedQuad quad in model.Quads) {
            string? id = quad.Texture;
            EntityTexture texture = _textures.GetNow("model:" + id, () => _pack.ModelTexture(id)) ?? _textures.Missing;
            uint tint = quad.TintIndex >= 0 && quad.TintIndex < tints.Length ? tints[quad.TintIndex] : 0xFFFFFF;
            quads.Add(new ItemQuad(quad.Positions, quad.Uvs, texture, 0xFF000000 | tint, Directions.Normals[quad.Direction]));
        }
        return quads.Count > 0 ? new ItemStackModel.Layer(quads.ToArray(), transform) : null;
    }

    /// <summary>The icon as a generated model; its ground and hand poses are item/generated's, which a flat sprite needs to read as an item at all.</summary>
    private ItemStackModel.Layer? BuildIcon(IItem item, ItemDisplayContext context) {
        TextureImage icon = ((IResourceSource?)_pack ?? _art).ItemIcon(item);
        EntityTexture? texture = _textures.GetNow("icon:" + item.Identifier, () => icon);
        if (texture == null) {
            return null;
        }
        List<ItemQuad> quads = [];
        Extrude(icon, texture, 0xFFFFFF, quads);
        return new ItemStackModel.Layer(quads.ToArray(), GeneratedTransform(context));
    }

    /// <summary>item/generated's display poses, for an icon standing in for a model.</summary>
    private static ItemTransform GeneratedTransform(ItemDisplayContext context) => context switch {
        ItemDisplayContext.Ground => new ItemTransform(Vector3.Zero, new Vector3(0, 2, 0) / 16, new Vector3(0.5F)),
        ItemDisplayContext.ThirdPersonRightHand or ItemDisplayContext.ThirdPersonLeftHand =>
            new ItemTransform(Vector3.Zero, new Vector3(0, 3, 1) / 16, new Vector3(0.55F)),
        ItemDisplayContext.FirstPersonRightHand or ItemDisplayContext.FirstPersonLeftHand =>
            new ItemTransform(new Vector3(0, -90, 25), new Vector3(1.13F, 3.2F, 1.13F) / 16, new Vector3(0.68F)),
        ItemDisplayContext.Head => new ItemTransform(new Vector3(0, 180, 0), new Vector3(0, 13, 7) / 16, Vector3.One),
        ItemDisplayContext.Fixed => new ItemTransform(new Vector3(0, 180, 0), Vector3.Zero, Vector3.One),
        _ => ItemTransform.None
    };

    /// <summary><c>ItemModelGenerator.bakeExtrudedSprite</c>: a slab one sixteenth thick, walled wherever a texel meets a transparent one.</summary>
    private static void Extrude(TextureImage sprite, EntityTexture texture, uint tint, List<ItemQuad> into) {
        uint argb = 0xFF000000 | tint;
        void Add(BakedQuad quad) => into.Add(new ItemQuad(quad.Positions, quad.Uvs, texture, argb, Directions.Normals[quad.Direction]));

        Vector3 from = new(0, 0, 7.5F), to = new(16, 16, 8.5F);
        Add(BlockModelBaker.BakeFace(from, to, new Vector4(0, 0, 16, 16), 3, null, 0));
        Add(BlockModelBaker.BakeFace(from, to, new Vector4(16, 0, 0, 16), 2, null, 0));

        int width = sprite.Width, height = sprite.Height;
        bool Transparent(int x, int y) => x < 0 || y < 0 || x >= width || y >= height || sprite.Rgba[(y * width + x) * 4 + 3] == 0;
        float xScale = 16.0F / width, yScale = 16.0F / height;
        // SideDirection: UP, DOWN, LEFT and RIGHT face up, down, east and west, and each steps toward
        // the neighbour it is checked against by the opposite of that direction's x and y.
        (int Facing, int StepX, int StepY)[] sides = [(1, 0, 1), (0, 0, -1), (5, 1, 0), (4, -1, 0)];
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                if (Transparent(x, y)) {
                    continue;
                }
                for (int side = 0; side < 4; side++) {
                    (int facing, int stepX, int stepY) = sides[side];
                    if (!Transparent(x - stepX, y - stepY)) {
                        continue;
                    }
                    bool horizontal = side <= 1;
                    float u0 = x + 0.1F, u1 = x + 1.0F - 0.1F;
                    float v0 = horizontal ? y + 0.1F : y + 1.0F - 0.1F;
                    float v1 = horizontal ? y + 1.0F - 0.1F : y + 0.1F;
                    (float startX, float startY, float endX, float endY) = side switch {
                        0 => (x, y, x + 1, y),
                        1 => (x, y + 1, x + 1, y + 1),
                        2 => (x, y, x, y + 1),
                        _ => (x + 1, y, x + 1, y + 1)
                    };
                    startX *= xScale;
                    endX *= xScale;
                    startY = 16 - startY * yScale;
                    endY = 16 - endY * yScale;
                    (Vector3 a, Vector3 b) = side switch {
                        0 => (new Vector3(startX, startY, 7.5F), new Vector3(endX, startY, 8.5F)),
                        1 => (new Vector3(startX, endY, 7.5F), new Vector3(endX, endY, 8.5F)),
                        2 => (new Vector3(startX, startY, 7.5F), new Vector3(startX, endY, 8.5F)),
                        _ => (new Vector3(endX, startY, 7.5F), new Vector3(endX, endY, 8.5F))
                    };
                    Add(BlockModelBaker.BakeFace(a, b, new Vector4(u0 * xScale, v0 * yScale, u1 * xScale, v1 * yScale), facing, null, 0));
                }
            }
        }
    }
}

public static class ItemStackExtensions {
    /// <summary><c>ItemStack.is(Item)</c>.</summary>
    public static bool Is(this ItemStack stack, IItem item) => stack.Type.Identifier == item.Identifier;
}
