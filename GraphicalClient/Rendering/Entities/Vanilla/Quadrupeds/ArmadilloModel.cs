namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class ArmadilloModel : EntityModel<ArmadilloRenderState> {
    private const float MaxDownHeadRotationExtent = 25.0F;
    private const float MaxUpHeadRotationExtent = 22.5F;
    private const float MaxWalkAnimationSpeed = 16.5F;
    private const float WalkAnimationScaleFactor = 2.5F;

    private readonly ModelPart _body;
    private readonly ModelPart _rightHindLeg;
    private readonly ModelPart _leftHindLeg;
    private readonly ModelPart _cube;
    private readonly ModelPart _head;
    private readonly ModelPart _tail;
    private readonly KeyframeAnimation _walkAnimation;
    private readonly KeyframeAnimation _rollOutAnimation;
    private readonly KeyframeAnimation _rollUpAnimation;
    private readonly KeyframeAnimation _peekAnimation;

    protected ArmadilloModel(ModelPart root, AnimationDefinition walk, AnimationDefinition rollOut, AnimationDefinition rollUp, AnimationDefinition peek) : base(root) {
        _body = root.GetChild("body");
        _rightHindLeg = root.GetChild("right_hind_leg");
        _leftHindLeg = root.GetChild("left_hind_leg");
        _head = _body.GetChild("head");
        _tail = _body.GetChild("tail");
        _cube = root.GetChild("cube");
        _walkAnimation = walk.Bake(root);
        _rollOutAnimation = rollOut.Bake(root);
        _rollUpAnimation = rollUp.Bake(root);
        _peekAnimation = peek.Bake(root);
    }

    public override void SetupAnim(ArmadilloRenderState state) {
        base.SetupAnim(state);
        if (state.IsHidingInShell) {
            _body.SkipDraw = true;
            _leftHindLeg.Visible = false;
            _rightHindLeg.Visible = false;
            _tail.Visible = false;
            _cube.Visible = true;
        }
        else {
            _body.SkipDraw = false;
            _leftHindLeg.Visible = true;
            _rightHindLeg.Visible = true;
            _tail.Visible = true;
            _cube.Visible = false;
            _head.XRot = Mth.Clamp(state.XRot, -MaxUpHeadRotationExtent, MaxDownHeadRotationExtent) * (MathF.PI / 180.0F);
            _head.YRot = Mth.Clamp(state.YRot, -32.5F, 32.5F) * (MathF.PI / 180.0F);
        }
        if (!state.IsHidingInShell) {
            _walkAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, MaxWalkAnimationSpeed, WalkAnimationScaleFactor);
        }
        _rollOutAnimation.Apply(state.RollOutAnimationState, state.AgeInTicks);
        _rollUpAnimation.Apply(state.RollUpAnimationState, state.AgeInTicks);
        _peekAnimation.Apply(state.PeekAnimationState, state.AgeInTicks);
    }
}
