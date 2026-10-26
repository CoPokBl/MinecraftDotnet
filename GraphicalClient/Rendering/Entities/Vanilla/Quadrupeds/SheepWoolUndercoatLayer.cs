using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SheepWoolUndercoatLayer(LivingEntityRenderer<SheepRenderState, SheepModel> parent) : RenderLayer<SheepRenderState, SheepModel>(parent) {
    private readonly SheepFurModel _model = new(SheepModel.CreateBodyLayer().BakeRoot());

    public override void Submit(PoseStack pose, EntityRenderContext context, SheepRenderState state) {
        if (!state.IsInvisible && (state.IsJebSheep || state.WoolColor != DyeColor.White) && !state.IsBaby) {
            RenderColoredCutoutModel(_model, "minecraft:textures/entity/sheep/sheep_wool_undercoat.png", pose, context, state, state.GetWoolColor());
        }
    }
}
