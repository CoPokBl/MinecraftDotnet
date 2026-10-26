namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>SheepWoolLayer</c>.</summary>
public sealed class SheepWoolLayer(LivingEntityRenderer<SheepRenderState, SheepModel> parent) : RenderLayer<SheepRenderState, SheepModel>(parent) {
    private readonly SheepFurModel _adultModel = new(SheepFurModel.CreateFurLayer().BakeRoot());
    private readonly SheepFurModel _babyModel = new(BabySheepModel.CreateBodyLayer().BakeRoot());

    public override void Submit(PoseStack pose, EntityRenderContext context, SheepRenderState state) {
        if (state.IsSheared) {
            return;
        }
        SheepFurModel model = state.IsBaby ? _babyModel : _adultModel;
        string location = state.IsBaby ? "minecraft:textures/entity/sheep/sheep_wool_baby.png" : "minecraft:textures/entity/sheep/sheep_wool.png";
        if (!state.IsInvisible) {
            RenderColoredCutoutModel(model, location, pose, context, state, state.GetWoolColor());
        }
        else if (state.AppearsGlowing && context.Outline is { } outline) {
            // RenderTypes.outline: the wool's silhouette alone.
            model.SetupAnim(state);
            model.RenderToBuffer(pose, outline, new ModelDrawState(context.Texture(location), 0xFFFFFFFF, 15, 15, 0));
        }
    }
}
