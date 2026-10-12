namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>EyesLayer</c>: the parent's model again with a glowing texture, drawn even while invisible, as vanilla's is.</summary>
public abstract class EyesLayer<S, M> : RenderLayer<S, M> where S : LivingEntityRenderState, new() where M : EntityModel<S> {
    protected EyesLayer(LivingEntityRenderer<S, M> parent) : base(parent) { }

    /// <summary>The texture of vanilla's <c>RenderTypes.eyes</c> render type.</summary>
    public abstract string Texture { get; }

    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        EntityTexture? texture = context.Textures.Get(Texture);
        if (texture == null) {
            return;
        }
        // Full sky and block light is the stand-in for the eyes render type's additive, unlit blending.
        Parent.CurrentModel.RenderToBuffer(pose, context.Batch, new ModelDrawState(texture, 0xFFFFFFFF, 15, 15, 0) { NoOutline = true });
    }
}
