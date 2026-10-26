namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BreezeEyesLayer</c>: drawn whether or not the breeze is invisible, as vanilla's is.</summary>
public sealed class BreezeEyesLayer : RenderLayer<BreezeRenderState, BreezeModel> {
    private const string BreezeEyes = "minecraft:textures/entity/breeze/breeze_eyes.png";
    private readonly BreezeModel _model;

    public BreezeEyesLayer(LivingEntityRenderer<BreezeRenderState, BreezeModel> parent) : base(parent) {
        _model = new BreezeModel(BreezeModel.CreateEyesLayer().BakeRoot());
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, BreezeRenderState state) {
        EntityTexture? texture = context.Textures.Get(BreezeEyes);
        if (texture == null) {
            return;
        }
        _model.SetupAnim(state);
        // RenderTypes.breezeEyes is entityTranslucentEmissive without an outline: shaded by direction, not by the lightmap.
        _model.RenderToBuffer(pose, context.TranslucentBatch, new ModelDrawState(texture, 0xFFFFFFFF, 15, 15, 0) { NoOutline = true, Emissive = true });
    }
}
