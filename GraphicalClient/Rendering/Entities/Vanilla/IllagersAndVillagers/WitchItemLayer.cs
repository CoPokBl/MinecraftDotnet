namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>WitchItemLayer</c>: a potion is held to the nose rather than across the arms.</summary>
public sealed class WitchItemLayer : CrossedArmsItemLayer<WitchRenderState, WitchModel> {
    public WitchItemLayer(LivingEntityRenderer<WitchRenderState, WitchModel> parent, ItemRenderer items) : base(parent, items) { }

    protected override void ApplyTranslation(WitchRenderState state, PoseStack pose) {
        if (state.IsHoldingPotion) {
            WitchModel model = Parent.CurrentModel;
            model.RootPart.TranslateAndRotate(pose);
            ((IHeadedModel)model).TranslateToHead(pose);
            model.Nose.TranslateAndRotate(pose);
            pose.Translate(0.0625F, 0.25F, 0.0F);
            pose.RotateZDegrees(180.0F);
            pose.RotateXDegrees(140.0F);
            pose.RotateZDegrees(10.0F);
            pose.RotateXDegrees(180.0F);
        }
        else {
            base.ApplyTranslation(state, pose);
        }
    }
}
