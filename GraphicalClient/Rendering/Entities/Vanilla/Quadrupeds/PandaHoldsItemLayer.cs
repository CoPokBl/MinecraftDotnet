namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class PandaHoldsItemLayer(LivingEntityRenderer<PandaRenderState, PandaModel> parent, ItemRenderer items)
    : RenderLayer<PandaRenderState, PandaModel>(parent) {
    public override void Submit(PoseStack pose, EntityRenderContext context, PandaRenderState state) {
        if (state.HeldItem is { } item && state.IsSitting && !state.IsScared) {
            float z = -0.6F;
            float y = 1.4F;
            if (state.IsEating) {
                z -= 0.2F * Mth.Sin(state.AgeInTicks * 0.6F) + 0.2F;
                y -= 0.09F * Mth.Sin(state.AgeInTicks * 0.6F);
            }
            pose.Push();
            pose.Translate(0.1F, y, z);
            items.Submit(item, ItemDisplayContext.Ground, pose, context.Batch, state.SkyLight, state.BlockLight);
            pose.Pop();
        }
    }
}
