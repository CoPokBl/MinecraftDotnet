namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class ChickenModel : EntityModel<ChickenRenderState> {
    public const float YOffset = 16.0F;
    private readonly ModelPart _rightLeg, _leftLeg, _rightWing, _leftWing;

    protected ChickenModel(ModelPart root) : base(root) {
        _rightLeg = root.GetChild("right_leg");
        _leftLeg = root.GetChild("left_leg");
        _rightWing = root.GetChild("right_wing");
        _leftWing = root.GetChild("left_wing");
    }

    public override void SetupAnim(ChickenRenderState state) {
        base.SetupAnim(state);
        float flapAngle = (Mth.Sin(state.Flap) + 1.0F) * state.FlapSpeed;
        float animationSpeed = state.WalkAnimationSpeed;
        float animationPos = state.WalkAnimationPos;
        _rightLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
        _leftLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
        _rightWing.ZRot = flapAngle;
        _leftWing.ZRot = -flapAngle;
    }
}
