using System.Numerics;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// One quad of a block model, baked: corners in block space (0 to 1 across the block), texture
/// coordinates in texture space (0 to 1 across the texture), in vanilla's corner order.
/// </summary>
/// <param name="Texture">The texture's identifier, <c>minecraft:block/stone</c>, or null for the missing texture.</param>
/// <param name="CullFace">The neighbour whose face hides this quad, already turned by the variant's rotation.</param>
/// <param name="Direction">The direction the quad faces, <c>FaceBakery.calculateFacing</c>.</param>
public sealed record BakedQuad(Vector3[] Positions, Vector2[] Uvs, string? Texture, bool ForceTranslucent, int? CullFace,
    int Direction, int TintIndex, bool Shade, int LightEmission);

/// <summary><c>ItemTransform</c>: how a model is posed for one display context, translation already in blocks.</summary>
public sealed record ItemTransform(Vector3 Rotation, Vector3 Translation, Vector3 Scale) {
    public static readonly ItemTransform None = new(Vector3.Zero, Vector3.Zero, Vector3.One);
}

/// <summary>
/// An item model: either the sprite layers of <c>builtin/generated</c>, or quads. <see cref="Display"/>
/// holds the pose for each display context by its <c>display</c> key, each from the nearest model up
/// the parent chain that names it, as <c>ResolvedModel.findTopTransform</c> looks.
/// </summary>
public sealed record ItemModel(BakedQuad[] Quads, string?[] Layers, IReadOnlyDictionary<string, ItemTransform> Display, bool SideLit) {
    /// <summary>
    /// The item definition's <c>transformation</c>, applied in model space after the display transform,
    /// as <c>LayerRenderState.setLocalTransform</c>: how a bed's foot is moved a block from its head.
    /// Already applied to <see cref="Quads"/>; sprite layers are extruded later and take it then.
    /// </summary>
    public Matrix4x4 Local { get; init; } = Matrix4x4.Identity;

    /// <summary>
    /// <c>SpecialModelWrapper</c>'s renderer, which draws in place of quads; the model is then the
    /// wrapper's <c>base</c>, read only for its display transforms and lighting.
    /// </summary>
    public Rendering.Entities.Special.ISpecialModelUnbaked? Special { get; init; }

    public ItemTransform Gui => Transform("gui");

    public ItemTransform Transform(string context) => Display.TryGetValue(context, out ItemTransform? transform) ? transform : ItemTransform.None;
}

/// <summary>One choice a block state can make, and how often it is made relative to the others.</summary>
/// <param name="Particle">The model's <c>particle</c> texture, null for the missing one.</param>
public sealed record BakedOption(BakedQuad[] Quads, int Weight, bool AmbientOcclusion, string? Particle = null);

/// <summary>A set of alternatives of which one is drawn, a weighted variant list or one part of a multipart.</summary>
public sealed record BakedPart(BakedOption[] Options) {
    public int TotalWeight { get; } = Options.Sum(o => o.Weight);
}

/// <summary>
/// What a block state draws: one part for a plain variant, one per matching selector for a
/// multipart. <see cref="Multipart"/> matters for the random draw, which vanilla makes differently.
/// </summary>
/// <param name="Particle">
/// <c>BlockStateModel.particleMaterial</c>: the first model's <c>particle</c> texture, of the variant's list or
/// of the multipart's first selector whether or not it applies; null for the missing one.
/// </param>
public sealed record BakedBlockModel(BakedPart[] Parts, bool Multipart, string? Particle = null) {
    /// <summary>
    /// The options drawn at a position: <c>ModelBlockRenderer.tesselateBlock</c> seeds the random from
    /// the position, a weighted list draws one entry, and a multipart draws a long that it reseeds
    /// with before each of its parts.
    /// </summary>
    public void Choose(int x, int y, int z, Span<BakedOption> chosen) {
        bool any = false;
        foreach (BakedPart part in Parts) {
            any |= part.Options.Length > 1;
        }
        if (!any) {
            for (int i = 0; i < Parts.Length; i++) {
                chosen[i] = Parts[i].Options[0];
            }
            return;
        }
        JavaRandom random = new(JavaRandom.PositionSeed(x, y, z));
        long partSeed = Multipart ? random.NextLong() : 0;
        for (int i = 0; i < Parts.Length; i++) {
            if (Multipart) {
                random.SetSeed(partSeed);
            }
            chosen[i] = Pick(Parts[i], ref random);
        }
    }

    private static BakedOption Pick(BakedPart part, ref JavaRandom random) {
        if (part.Options.Length == 1) {
            return part.Options[0];
        }
        int selection = random.NextInt(part.TotalWeight);
        foreach (BakedOption option in part.Options) {
            selection -= option.Weight;
            if (selection < 0) {
                return option;
            }
        }
        return part.Options[^1];
    }
}
