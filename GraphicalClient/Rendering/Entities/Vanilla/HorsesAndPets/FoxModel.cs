namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class FoxModel : EntityModel<FoxRenderState> {
    public readonly ModelPart Head;
    protected readonly ModelPart Body;
    protected readonly ModelPart RightHindLeg;
    protected readonly ModelPart LeftHindLeg;
    protected readonly ModelPart RightFrontLeg;
    protected readonly ModelPart LeftFrontLeg;
    protected readonly ModelPart Tail;

    // Kept on the model, not the entity, as vanilla keeps it: every faceplanted fox drawn advances it.
    private float _legMotionPos;

    protected FoxModel(ModelPart root) : base(root) {
        Head = root.GetChild("head");
        Body = root.GetChild("body");
        RightHindLeg = root.GetChild("right_hind_leg");
        LeftHindLeg = root.GetChild("left_hind_leg");
        RightFrontLeg = root.GetChild("right_front_leg");
        LeftFrontLeg = root.GetChild("left_front_leg");
        Tail = Body.GetChild("tail");
    }

    public override void SetupAnim(FoxRenderState state) {
        base.SetupAnim(state);
        SetWalkingPose(state);
        if (state.IsCrouching) {
            SetCrouchingPose(state);
        }
        else if (state.IsSleeping) {
            SetSleepingPose(state);
        }
        else if (state.IsSitting) {
            SetSittingPose(state);
        }
        if (state.IsPouncing) {
            SetPouncingPose(state);
        }
        if (!state.IsSleeping && !state.IsFaceplanted && !state.IsCrouching) {
            Head.XRot = state.XRot * (float)(Math.PI / 180.0);
            Head.YRot = state.YRot * (float)(Math.PI / 180.0);
        }
        if (state.IsSleeping) {
            Head.XRot = 0.0F;
            Head.YRot = (float)(-Math.PI * 2.0 / 3.0);
            Head.ZRot = Mth.Cos(state.AgeInTicks * 0.027F) / 22.0F;
        }
        if (state.IsFaceplanted) {
            _legMotionPos += 0.67F;
            RightHindLeg.XRot = Mth.Cos(_legMotionPos * 0.4662F) * 0.1F;
            LeftHindLeg.XRot = Mth.Cos(_legMotionPos * 0.4662F + MathF.PI) * 0.1F;
            RightFrontLeg.XRot = Mth.Cos(_legMotionPos * 0.4662F + MathF.PI) * 0.1F;
            LeftFrontLeg.XRot = Mth.Cos(_legMotionPos * 0.4662F) * 0.1F;
        }
    }

    protected virtual void SetSittingPose(FoxRenderState state) {
        Head.XRot = 0.0F;
        Head.YRot = 0.0F;
    }

    protected virtual void SetSleepingPose(FoxRenderState state) {
        RightHindLeg.Visible = false;
        LeftHindLeg.Visible = false;
        RightFrontLeg.Visible = false;
        LeftFrontLeg.Visible = false;
    }

    protected virtual void SetWalkingPose(FoxRenderState state) {
        Head.ZRot = state.HeadRollAngle;
        RightHindLeg.Visible = true;
        LeftHindLeg.Visible = true;
        RightFrontLeg.Visible = true;
        LeftFrontLeg.Visible = true;
    }

    protected virtual void SetCrouchingPose(FoxRenderState state) {
        Body.XRot += 0.10471976F;
        Head.Y = Head.Y + state.CrouchAmount * state.AgeScale;
        float wiggleAmount = Mth.Cos(state.AgeInTicks) * 0.05F;
        Body.YRot = wiggleAmount;
        RightHindLeg.ZRot = wiggleAmount;
        LeftHindLeg.ZRot = wiggleAmount;
        RightFrontLeg.ZRot = wiggleAmount / 2.0F;
        LeftFrontLeg.ZRot = wiggleAmount / 2.0F;
    }

    protected virtual void SetPouncingPose(FoxRenderState state) { }
}
