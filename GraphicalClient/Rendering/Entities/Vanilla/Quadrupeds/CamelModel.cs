namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class CamelModel : EntityModel<CamelRenderState> {
    private const float MaxWalkAnimationSpeed = 2.0F;
    private const float WalkAnimationScaleFactor = 2.5F;

    protected readonly ModelPart Head;
    private readonly KeyframeAnimation _walkAnimation;
    private readonly KeyframeAnimation _sitAnimation;
    private readonly KeyframeAnimation _sitPoseAnimation;
    private readonly KeyframeAnimation _standupAnimation;
    private readonly KeyframeAnimation _idleAnimation;
    private readonly KeyframeAnimation _dashAnimation;

    protected CamelModel(ModelPart root, AnimationDefinition walk, AnimationDefinition sit, AnimationDefinition sitPose, AnimationDefinition standup,
        AnimationDefinition idle, AnimationDefinition dash) : base(root) {
        ModelPart body = root.GetChild("body");
        Head = body.GetChild("head");
        _walkAnimation = walk.Bake(root);
        _sitAnimation = sit.Bake(root);
        _sitPoseAnimation = sitPose.Bake(root);
        _standupAnimation = standup.Bake(root);
        _idleAnimation = idle.Bake(root);
        _dashAnimation = dash.Bake(root);
    }

    public override void SetupAnim(CamelRenderState state) {
        base.SetupAnim(state);
        ApplyHeadRotation(state, state.YRot, state.XRot);
        _walkAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, MaxWalkAnimationSpeed, WalkAnimationScaleFactor);
        _sitAnimation.Apply(state.SitAnimationState, state.AgeInTicks);
        _sitPoseAnimation.Apply(state.SitPoseAnimationState, state.AgeInTicks);
        _standupAnimation.Apply(state.SitUpAnimationState, state.AgeInTicks);
        _idleAnimation.Apply(state.IdleAnimationState, state.AgeInTicks);
        _dashAnimation.Apply(state.DashAnimationState, state.AgeInTicks);
    }

    private void ApplyHeadRotation(CamelRenderState state, float yRot, float xRot) {
        yRot = Mth.Clamp(yRot, -30.0F, 30.0F);
        xRot = Mth.Clamp(xRot, -25.0F, 45.0F);
        if (state.JumpCooldown > 0.0F) {
            float headRotation = 45.0F * state.JumpCooldown / 55.0F;
            xRot = Mth.Clamp(xRot + headRotation, -25.0F, 70.0F);
        }
        Head.YRot = yRot * (MathF.PI / 180.0F);
        Head.XRot = xRot * (MathF.PI / 180.0F);
    }
}
