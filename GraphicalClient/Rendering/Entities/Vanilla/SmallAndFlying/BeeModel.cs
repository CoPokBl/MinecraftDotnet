namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class BeeModel : EntityModel<BeeRenderState> {
    protected readonly ModelPart Bone;
    private readonly ModelPart _rightWing, _leftWing, _frontLeg, _midLeg, _backLeg, _stinger;

    protected BeeModel(ModelPart root) : base(root) {
        Bone = root.GetChild("bone");
        ModelPart body = Bone.GetChild("body");
        _stinger = body.GetChild("stinger");
        _rightWing = Bone.GetChild("right_wing");
        _leftWing = Bone.GetChild("left_wing");
        _frontLeg = Bone.GetChild("front_legs");
        _midLeg = Bone.GetChild("middle_legs");
        _backLeg = Bone.GetChild("back_legs");
    }

    public override void SetupAnim(BeeRenderState state) {
        base.SetupAnim(state);
        _stinger.Visible = state.HasStinger;
        if (!state.IsOnGround) {
            float speed = state.AgeInTicks * 120.32113F * (MathF.PI / 180.0F);
            _rightWing.YRot = 0.0F;
            _rightWing.ZRot = Mth.Cos(speed) * MathF.PI * 0.15F;
            _leftWing.XRot = _rightWing.XRot;
            _leftWing.YRot = _rightWing.YRot;
            _leftWing.ZRot = -_rightWing.ZRot;
            _frontLeg.XRot = MathF.PI / 4;
            _midLeg.XRot = MathF.PI / 4;
            _backLeg.XRot = MathF.PI / 4;
        }
        if (!state.IsAngry && !state.IsOnGround) {
            float speed = Mth.Cos(state.AgeInTicks * 0.18F);
            BobUpAndDown(speed, state.AgeInTicks);
        }
        float rollAmount = state.RollAmount;
        if (rollAmount > 0.0F) {
            Bone.XRot = Mth.RotLerpRad(rollAmount, Bone.XRot, 3.0915928F);
        }
    }

    protected virtual void BobUpAndDown(float speed, float ageInTicks) {
        Bone.XRot = 0.1F + speed * MathF.PI * 0.025F;
        Bone.Y = Bone.Y - Mth.Cos(ageInTicks * 0.18F) * 0.9F;
        _frontLeg.XRot = -speed * MathF.PI * 0.1F + MathF.PI / 8;
        _backLeg.XRot = -speed * MathF.PI * 0.05F + MathF.PI / 4;
    }
}
