namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>SlimeOuterLayer</c>.</summary>
public sealed class SlimeOuterLayer : RenderLayer<SlimeRenderState, SlimeModel> {
    private readonly SlimeModel _model = new(SlimeModel.CreateOuterBodyLayer().BakeRoot());

    public SlimeOuterLayer(LivingEntityRenderer<SlimeRenderState, SlimeModel> parent) : base(parent) { }

    public override void Submit(PoseStack pose, EntityRenderContext context, SlimeRenderState state) {
        // A glowing invisible slime's outer cube is still outlined.
        IModelSink? sink = !state.IsInvisible ? context.TranslucentBatch : state.AppearsGlowing ? context.Outline : null;
        if (sink == null) {
            return;
        }
        _model.SetupAnim(state);
        EntityTexture texture = context.Textures.Get(SlimeRenderer.SlimeLocation) ?? context.Textures.Missing;
        _model.RenderToBuffer(pose, sink, new ModelDrawState(texture, 0xFFFFFFFF, state.SkyLight, state.BlockLight, state.HasRedOverlay ? 1 : 0));
    }
}
