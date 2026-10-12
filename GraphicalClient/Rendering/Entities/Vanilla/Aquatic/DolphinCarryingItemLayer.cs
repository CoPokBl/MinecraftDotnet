namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class DolphinCarryingItemLayer : RenderLayer<DolphinRenderState, DolphinModel> {
    private readonly ItemRenderer _items;

    public DolphinCarryingItemLayer(LivingEntityRenderer<DolphinRenderState, DolphinModel> parent, ItemRenderer items) : base(parent) {
        _items = items;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, DolphinRenderState state) {
        if (state.HeldItem is not { } item) {
            return;
        }
        pose.Push();
        float angleXPercent = Mth.Abs(state.XRot) / 60.0F;
        if (state.XRot < 0.0F) {
            pose.Translate(0.0F, 1.0F - angleXPercent * 0.5F, -1.0F + angleXPercent * 0.5F);
        }
        else {
            pose.Translate(0.0F, 1.0F + angleXPercent * 0.8F, -1.0F + angleXPercent * 0.2F);
        }
        _items.Submit(item, ItemDisplayContext.Ground, pose, context.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }
}
