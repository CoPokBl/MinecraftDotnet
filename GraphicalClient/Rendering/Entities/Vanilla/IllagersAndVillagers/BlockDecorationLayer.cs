using Minecraft.Data.Blocks;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BlockDecorationLayer</c>: a block stood on a point of the model.</summary>
public class BlockDecorationLayer<S, M> : RenderLayer<S, M> where S : LivingEntityRenderState, new() where M : EntityModel<S> {
    private readonly Func<S, IBlock?> _blockModel;
    private readonly Action<PoseStack> _transform;
    private readonly BlockModelRenderer _blocks;

    public BlockDecorationLayer(LivingEntityRenderer<S, M> parent, Func<S, IBlock?> blockModel, Action<PoseStack> transform, BlockModelRenderer blocks) : base(parent) {
        _blockModel = blockModel;
        _transform = transform;
        _blocks = blocks;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        if (_blockModel(state) is not { } block) {
            return;
        }
        pose.Push();
        _transform(pose);
        // UNIT_CUBE_BOTTOM_CENTER_TO_ANTENNA_CENTER: a half block across, then half a turn about the cube's centre.
        pose.Translate(-0.5F, 0.0F, -0.5F);
        pose.Translate(0.5F, 0.5F, 0.5F);
        pose.RotateZDegrees(180.0F);
        pose.Translate(-0.5F, -0.5F, -0.5F);
        _blocks.Render(block, pose, context.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }
}
