using System.Numerics;
using System.Text;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Special;

/// <summary><c>ShieldSpecialRenderer</c>.</summary>
public sealed class ShieldSpecialRenderer : SpecialModelRenderer<ShieldSpecialRenderer.Components> {
    /// <summary><c>DEFAULT_TRANSFORMATION</c>: the model's y and z flipped, as vanilla's shield item definition is generated with.</summary>
    public static readonly Matrix4x4 DefaultTransformation = Matrix4x4.CreateScale(1.0F, -1.0F, -1.0F);

    /// <summary>The two components that change the drawing, where vanilla's argument is the stack's whole component map.</summary>
    public sealed record Components(IReadOnlyList<BannerPatternsComponent.Layer> Patterns, DyeColor? BaseColor);

    private readonly ISpriteGetter _sprites;
    private readonly ShieldModel _model;

    public ShieldSpecialRenderer(ISpriteGetter sprites, ShieldModel model) {
        _sprites = sprites;
        _model = model;
    }

    public override Components ExtractArgument(ItemStack stack) => new(
        stack.GetOrNull(DataComponent.BannerPatterns) ?? [],
        stack.Has(DataComponent.BaseColor) ? stack.Get(DataComponent.BaseColor) : null);

    public override void Submit(Components? components, PoseStack pose, IModelSink sink, float skyLight, float blockLight) {
        IReadOnlyList<BannerPatternsComponent.Layer> patterns = components?.Patterns ?? [];
        DyeColor? baseColor = components?.BaseColor;
        bool hasPatterns = patterns.Count > 0 || baseColor != null;
        SpriteId @base = hasPatterns ? Sheets.ShieldBase : Sheets.ShieldBaseNoPattern;
        EntityTexture texture = hasPatterns
            ? BannerPatternTextures.Patterned(_sprites, @base, false, baseColor ?? DyeColor.White, patterns)
            : _sprites.Get(@base);
        _model.RenderToBuffer(pose, sink, new ModelDrawState(texture, 0xFFFFFFFF, skyLight, blockLight, 0));
    }

    /// <summary>
    /// The base model again with <c>entityGlint</c>, the patterns left bare. Vanilla takes its texture
    /// coordinates through the base sprite's place in its atlas; these run over the texture alone.
    /// </summary>
    public override void SubmitFoil(Components? components, PoseStack pose, IModelSink sink) =>
        _model.RenderToBuffer(pose, new GlintSink(sink, GlintType.Entity), new ModelDrawState(_sprites.Get(Sheets.ShieldBase), 0xFFFFFFFF, 15, 15, 0));

    public override void GetExtents(Action<Vector3> output) => _model.RootPart.GetExtentsForGui(new PoseStack(), output);

    public override string? IdentityOf(Components? components) {
        if (components == null || (components.Patterns.Count == 0 && components.BaseColor == null)) {
            return null;
        }
        StringBuilder identity = new StringBuilder("shield:").Append(components.BaseColor);
        foreach (BannerPatternsComponent.Layer layer in components.Patterns) {
            identity.Append('|').Append(layer.Pattern.AssetId).Append('=').Append(layer.Color);
        }
        return identity.ToString();
    }

    /// <summary><c>ShieldSpecialRenderer.Unbaked</c>, which has no fields.</summary>
    public sealed class Unbaked : ISpecialModelUnbaked {
        public static readonly Unbaked Instance = new();

        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) =>
            new ShieldSpecialRenderer(context.Sprites, new ShieldModel(ShieldModel.CreateLayer().BakeRoot()));
    }
}
