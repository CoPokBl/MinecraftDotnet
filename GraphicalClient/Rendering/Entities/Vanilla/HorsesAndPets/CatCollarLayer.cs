namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class CatCollarLayer(LivingEntityRenderer<CatRenderState, AbstractFelineModel<CatRenderState>> parent)
    : RenderLayer<CatRenderState, AbstractFelineModel<CatRenderState>>(parent) {
    private readonly AdultCatModel _adultModel =
        new(AdultFelineModel<CatRenderState>.CreateBodyLayer(AdultCatModel.CollarDeformation).Apply(AdultCatModel.CatTransformer).BakeRoot());
    private readonly BabyCatModel _babyModel = new(BabyFelineModel<CatRenderState>.CreateBabyLayer().Apply(BabyCatModel.CollarTransformer).BakeRoot());

    public override void Submit(PoseStack pose, EntityRenderContext context, CatRenderState state) {
        if (state.CollarColor is not { } collarColor) {
            return;
        }
        uint color = TropicalFish.TextureDiffuseColor(collarColor);
        AbstractFelineModel<CatRenderState> model = state.IsBaby ? _babyModel : _adultModel;
        string texture = state.IsBaby ? "minecraft:textures/entity/cat/cat_collar_baby.png" : "minecraft:textures/entity/cat/cat_collar.png";
        RenderColoredCutoutModel(model, texture, pose, context, state, color);
    }
}
