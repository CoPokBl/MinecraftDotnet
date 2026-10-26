using Minecraft.Data.Blocks;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>The mushrooms do not take the hurt overlay, which the block renderer has no input for.</summary>
public sealed class MushroomCowMushroomLayer(LivingEntityRenderer<MushroomCowRenderState, CowModel<MushroomCowRenderState>> parent, BlockModelRenderer blocks)
    : RenderLayer<MushroomCowRenderState, CowModel<MushroomCowRenderState>>(parent) {
    public override void Submit(PoseStack pose, EntityRenderContext context, MushroomCowRenderState state) {
        // A glowing invisible mooshroom's mushrooms are still outlined.
        IModelSink? sink = !state.IsInvisible ? context.Batch : state.AppearsGlowing ? context.Outline : null;
        if (!state.IsBaby && !state.MushroomModel.Air && sink != null) {
            pose.Push();
            pose.Translate(0.2F, -0.35F, 0.5F);
            pose.RotateYDegrees(-48.0F);
            pose.Scale(-1.0F, -1.0F, 1.0F);
            pose.Translate(-0.5F, -0.5F, -0.5F);
            SubmitMushroomBlock(pose, sink, state);
            pose.Pop();
            pose.Push();
            pose.Translate(0.2F, -0.35F, 0.5F);
            pose.RotateYDegrees(42.0F);
            pose.Translate(0.1F, 0.0F, -0.6F);
            pose.RotateYDegrees(-48.0F);
            pose.Scale(-1.0F, -1.0F, 1.0F);
            pose.Translate(-0.5F, -0.5F, -0.5F);
            SubmitMushroomBlock(pose, sink, state);
            pose.Pop();
            pose.Push();
            Parent.CurrentModel.GetHead().TranslateAndRotate(pose);
            pose.Translate(0.0F, -0.7F, -0.2F);
            pose.RotateYDegrees(-78.0F);
            pose.Scale(-1.0F, -1.0F, 1.0F);
            pose.Translate(-0.5F, -0.5F, -0.5F);
            SubmitMushroomBlock(pose, sink, state);
            pose.Pop();
        }
    }

    private void SubmitMushroomBlock(PoseStack pose, IModelSink sink, MushroomCowRenderState state) =>
        blocks.Render(state.MushroomModel, pose, sink, state.SkyLight, state.BlockLight);
}
