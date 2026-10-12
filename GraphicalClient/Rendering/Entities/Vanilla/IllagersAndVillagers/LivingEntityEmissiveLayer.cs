namespace GraphicalClient.Rendering.Entities.Vanilla;

public class LivingEntityEmissiveLayer<S, M> : RenderLayer<S, M> where S : LivingEntityRenderState, new() where M : EntityModel<S> {
    /// <summary><c>LivingEntityEmissiveLayer.AlphaFunction</c>.</summary>
    public delegate float AlphaFunction(S state, float ageInTicks);

    private readonly Func<S, string> _textureProvider;
    private readonly AlphaFunction _alphaFunction;
    private readonly M _model;
    private readonly bool _translucent, _alwaysVisible;

    /// <param name="translucent">
    /// Whether vanilla's render type for it blends (<c>entityTranslucentEmissive</c>) rather than adds
    /// (<c>eyes</c>); a translucent one goes to the translucent batch.
    /// </param>
    public LivingEntityEmissiveLayer(LivingEntityRenderer<S, M> parent, Func<S, string> textureProvider, AlphaFunction alphaFunction, M model,
        bool translucent, bool alwaysVisible) : base(parent) {
        _textureProvider = textureProvider;
        _alphaFunction = alphaFunction;
        _model = model;
        _translucent = translucent;
        _alwaysVisible = alwaysVisible;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        if (state.IsInvisible && !_alwaysVisible) {
            return;
        }
        float alpha = _alphaFunction(state, state.AgeInTicks);
        if (alpha <= 1.0E-5F) {
            return;
        }
        EntityTexture? texture = context.Textures.Get(_textureProvider(state));
        if (texture == null) {
            return;
        }
        uint color = (uint)Math.Clamp((int)(alpha * 255.0F), 0, 255) << 24 | 0xFFFFFF;
        _model.SetupAnim(state);
        // Full sky and block light is the stand-in for the emissive render types' unlit blending.
        _model.RenderToBuffer(pose, _translucent ? context.TranslucentBatch : context.Batch,
            new ModelDrawState(texture, color, 15, 15, state.HasRedOverlay ? 1 : 0) { NoOutline = !_translucent });
    }
}
