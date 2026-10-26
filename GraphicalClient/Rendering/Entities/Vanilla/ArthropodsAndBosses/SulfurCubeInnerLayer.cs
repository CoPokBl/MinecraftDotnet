using System.Numerics;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SulfurCubeInnerLayer : RenderLayer<SulfurCubeRenderState, SulfurCubeModel> {
    private const string SulfurCubeInnerLocation = "minecraft:textures/entity/sulfur_cube/sulfur_cube_inner.png";
    private const string SulfurCubeSmallInnerLocation = "minecraft:textures/entity/sulfur_cube/sulfur_cube_inner_small.png";

    private readonly SulfurCubeModel _normalModel = new(SulfurCubeModel.CreateInnerBodyLayer().BakeRoot());
    private readonly SulfurCubeModel _smallModel = new(SmallSulfurCubeModel.CreateInnerBodyLayer().BakeRoot());
    private readonly BlockModelRenderer _blocks;

    public SulfurCubeInnerLayer(LivingEntityRenderer<SulfurCubeRenderState, SulfurCubeModel> parent, BlockModelRenderer blocks) : base(parent) {
        _blocks = blocks;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, SulfurCubeRenderState state) {
        // OverlayTexture.pack(u(1.0F), 10) while lit: full white, no red.
        bool lit = state.FuseRemainingTicks > 0.0F && SulfurCubeRenderer.IsLit(state.FuseRemainingTicks);
        float red = lit ? 0 : state.HasRedOverlay ? 1 : 0;
        float white = lit ? 1 : 0;
        if (state.ContainedBlock != null) {
            pose.Push();
            pose.RotateXDegrees(180.0F);
            if (state.IsBaby) {
                pose.Scale(0.5F, 0.5F, 0.5F);
            }
            pose.Translate(-0.5F, -0.518F, -0.5F);
            _blocks.Render(state.ContainedBlock, pose, new OverlaySink(context.Batch, red, white), state.SkyLight, state.BlockLight);
            pose.Pop();
        }
        else if (!state.IsInvisible) {
            string location = state.IsBaby ? SulfurCubeSmallInnerLocation : SulfurCubeInnerLocation;
            SulfurCubeModel model = state.IsBaby ? _smallModel : _normalModel;
            model.SetupAnim(state);
            EntityTexture texture = context.Textures.Get(location) ?? context.Textures.Missing;
            model.RenderToBuffer(pose, context.TranslucentBatch, new ModelDrawState(texture, 0xFFFFFFFF, state.SkyLight, state.BlockLight, red, white));
        }
    }

    /// <summary>The overlay a block model's quads carry, which <see cref="BlockModelRenderer"/> leaves at none.</summary>
    private sealed class OverlaySink(IModelSink inner, float red, float white) : IModelSink {
        public void Quad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, Vector3 normal, ModelDrawState draw) =>
            inner.Quad(corners, uvs, normal, draw with { RedOverlay = red, WhiteOverlay = white });
    }
}
