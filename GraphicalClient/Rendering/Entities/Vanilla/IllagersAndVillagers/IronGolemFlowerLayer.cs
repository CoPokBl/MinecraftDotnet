namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class IronGolemFlowerLayer : RenderLayer<IronGolemRenderState, IronGolemModel> {
    private readonly BlockModelRenderer _blocks;

    public IronGolemFlowerLayer(LivingEntityRenderer<IronGolemRenderState, IronGolemModel> parent, BlockModelRenderer blocks) : base(parent) {
        _blocks = blocks;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, IronGolemRenderState state) {
        if (state.FlowerBlock is not { } flower) {
            return;
        }
        pose.Push();
        ModelPart arm = Parent.CurrentModel.FlowerHoldingArm;
        arm.TranslateAndRotate(pose);
        pose.Translate(-1.1875F, 1.0625F, -0.9375F);
        pose.Translate(0.5F, 0.5F, 0.5F);
        pose.Scale(0.5F, 0.5F, 0.5F);
        pose.RotateXDegrees(-90.0F);
        pose.Translate(-0.5F, -0.5F, -0.5F);
        _blocks.Render(flower, pose, context.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }
}
