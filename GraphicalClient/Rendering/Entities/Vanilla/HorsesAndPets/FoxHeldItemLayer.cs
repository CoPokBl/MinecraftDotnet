namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>FoxHeldItemLayer</c>: the main hand item in the mouth, posed as on the ground.</summary>
public sealed class FoxHeldItemLayer : RenderLayer<FoxRenderState, FoxModel> {
    private readonly ItemRenderer _items;

    public FoxHeldItemLayer(LivingEntityRenderer<FoxRenderState, FoxModel> parent, ItemRenderer items) : base(parent) {
        _items = items;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, FoxRenderState state) {
        if (state.HeldItem is not { } item) {
            return;
        }
        bool sleeping = state.IsSleeping;
        bool isBaby = state.IsBaby;
        ModelPart head = Parent.CurrentModel.Head;
        pose.Push();
        pose.Translate(head.X / 16.0F, head.Y / 16.0F, head.Z / 16.0F);
        if (isBaby) {
            pose.Scale(0.75F, 0.75F, 0.75F);
        }
        pose.RotateZ(state.HeadRollAngle);
        pose.RotateYDegrees(state.YRot);
        pose.RotateXDegrees(state.XRot);
        if (state.IsBaby) {
            if (sleeping) {
                pose.Translate(0.4F, 0.26F, 0.15F);
            }
            else {
                pose.Translate(0.06F, 0.26F, -0.5F);
            }
        }
        else if (sleeping) {
            pose.Translate(0.46F, 0.26F, 0.22F);
        }
        else {
            pose.Translate(0.06F, 0.27F, -0.5F);
        }
        pose.RotateXDegrees(90.0F);
        if (sleeping) {
            pose.RotateZDegrees(90.0F);
        }
        _items.Submit(item, ItemDisplayContext.Ground, pose, context.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }
}
