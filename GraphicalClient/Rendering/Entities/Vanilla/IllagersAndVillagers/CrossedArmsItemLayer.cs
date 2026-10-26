namespace GraphicalClient.Rendering.Entities.Vanilla;

public class CrossedArmsItemLayer<S, M> : RenderLayer<S, M>
    where S : HoldingEntityRenderState, new()
    where M : EntityModel<S>, IVillagerLikeModel<S> {
    private readonly ItemRenderer _items;

    public CrossedArmsItemLayer(LivingEntityRenderer<S, M> parent, ItemRenderer items) : base(parent) {
        _items = items;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        if (state.HeldItem is not { } item) {
            return;
        }
        pose.Push();
        ApplyTranslation(state, pose);
        _items.Submit(item, ItemDisplayContext.Ground, pose, context.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }

    protected virtual void ApplyTranslation(S state, PoseStack pose) {
        Parent.CurrentModel.TranslateToArms(state, pose);
        pose.RotateX(0.75F);
        pose.Scale(1.07F, 1.07F, 1.07F);
        pose.Translate(0.0F, 0.13F, -0.34F);
        pose.RotateX(MathF.PI);
    }
}
