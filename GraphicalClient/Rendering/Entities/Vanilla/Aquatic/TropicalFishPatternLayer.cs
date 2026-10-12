namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class TropicalFishPatternLayer : RenderLayer<TropicalFishRenderState, EntityModel<TropicalFishRenderState>> {
    private static readonly CubeDeformation FishPatternDeformation = new(0.008F);

    /// <summary>A small base's patterns are <c>tropical_a</c>, a large one's <c>tropical_b</c>, numbered by the pattern's index from 1.</summary>
    private static readonly Dictionary<TropicalFish.Pattern, string> PatternTextures = Enum.GetValues<TropicalFish.Pattern>().ToDictionary(p => p,
        p => $"minecraft:textures/entity/fish/tropical_{(TropicalFish.BaseOf(p) == TropicalFish.Base.Small ? 'a' : 'b')}_pattern_{((int)p >> 8) + 1}.png");
    private readonly TropicalFishSmallModel _modelSmall;
    private readonly TropicalFishLargeModel _modelLarge;

    public TropicalFishPatternLayer(LivingEntityRenderer<TropicalFishRenderState, EntityModel<TropicalFishRenderState>> parent) : base(parent) {
        _modelSmall = new TropicalFishSmallModel(TropicalFishSmallModel.CreateBodyLayer(FishPatternDeformation).BakeRoot());
        _modelLarge = new TropicalFishLargeModel(TropicalFishLargeModel.CreateBodyLayer(FishPatternDeformation).BakeRoot());
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, TropicalFishRenderState state) {
        TropicalFish.Pattern variant = state.Pattern;
        EntityModel<TropicalFishRenderState> model = TropicalFish.BaseOf(variant) == TropicalFish.Base.Small ? _modelSmall : _modelLarge;
        RenderColoredCutoutModel(model, PatternTextures[variant], pose, context, state, state.PatternColor);
    }
}
