using System.Numerics;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>SnowGolemHeadLayer</c>.</summary>
public sealed class SnowGolemHeadLayer : RenderLayer<SnowGolemRenderState, SnowGolemModel> {
    private readonly BlockModelRenderer _blocks;

    public SnowGolemHeadLayer(LivingEntityRenderer<SnowGolemRenderState, SnowGolemModel> parent, BlockModelRenderer blocks) : base(parent) {
        _blocks = blocks;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, SnowGolemRenderState state) {
        // A glowing invisible golem's head is still outlined.
        IModelSink? sink = !state.IsInvisible ? new OverlaySink(context.Batch, state.HasRedOverlay ? 1 : 0) : state.AppearsGlowing ? context.Outline : null;
        if (state.HeadBlock is not { } headBlock || sink == null) {
            return;
        }
        pose.Push();
        Parent.CurrentModel.Head.TranslateAndRotate(pose);
        pose.Translate(0.0F, -0.34375F, 0.0F);
        pose.RotateYDegrees(180.0F);
        pose.Scale(0.625F, -0.625F, -0.625F);
        pose.Translate(-0.5F, -0.5F, -0.5F);
        _blocks.Render(headBlock, pose, sink, state.SkyLight, state.BlockLight);
        pose.Pop();
    }

    /// <summary><c>LivingEntityRenderer.getOverlayCoords(state, 0)</c>: the hurt flash on a block that is drawn without one.</summary>
    private sealed class OverlaySink(IModelSink inner, float redOverlay) : IModelSink {
        public void Quad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, Vector3 normal, ModelDrawState draw) =>
            inner.Quad(corners, uvs, normal, draw with { RedOverlay = redOverlay });
    }
}
