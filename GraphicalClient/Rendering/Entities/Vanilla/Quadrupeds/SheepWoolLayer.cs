namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>The outline a glowing invisible sheep's wool draws is left out.</summary>
public sealed class SheepWoolLayer(LivingEntityRenderer<SheepRenderState, SheepModel> parent) : RenderLayer<SheepRenderState, SheepModel>(parent) {
    private readonly SheepFurModel _adultModel = new(SheepFurModel.CreateFurLayer().BakeRoot());
    private readonly SheepFurModel _babyModel = new(BabySheepModel.CreateBodyLayer().BakeRoot());

    public override void Submit(PoseStack pose, EntityRenderContext context, SheepRenderState state) {
        if (!state.IsSheared && !state.IsInvisible) {
            SheepFurModel model = state.IsBaby ? _babyModel : _adultModel;
            string location = state.IsBaby ? "minecraft:textures/entity/sheep/sheep_wool_baby.png" : "minecraft:textures/entity/sheep/sheep_wool.png";
            RenderColoredCutoutModel(model, location, pose, context, state, state.GetWoolColor());
        }
    }
}
