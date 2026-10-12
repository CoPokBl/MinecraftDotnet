namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class RabbitModel : EntityModel<RabbitRenderState> {
    private readonly KeyframeAnimation _hopAnimation;
    private readonly KeyframeAnimation _idleHeadTiltAnimation;
    private readonly ModelPart _head;

    protected RabbitModel(ModelPart root, AnimationDefinition hop, AnimationDefinition idleHeadTilt) : base(root) {
        _head = root.GetChild("body").GetChild("head");
        _hopAnimation = hop.Bake(root);
        _idleHeadTiltAnimation = idleHeadTilt.Bake(root);
    }

    public override void SetupAnim(RabbitRenderState state) {
        base.SetupAnim(state);
        if (!state.IdleHeadTiltAnimationState.IsStarted) {
            _head.YRot = state.YRot * (float)(Math.PI / 180.0);
            _head.XRot = state.XRot * (float)(Math.PI / 180.0);
        }
        _hopAnimation.Apply(state.HopAnimationState, state.AgeInTicks);
        _idleHeadTiltAnimation.Apply(state.IdleHeadTiltAnimationState, state.AgeInTicks);
    }
}
