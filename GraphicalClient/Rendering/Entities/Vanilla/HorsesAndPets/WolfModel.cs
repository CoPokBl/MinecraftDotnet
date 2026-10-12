namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class WolfModel : EntityModel<WolfRenderState> {
    protected readonly ModelPart Head;
    protected readonly ModelPart Body;
    protected readonly ModelPart RightHindLeg;
    protected readonly ModelPart LeftHindLeg;
    protected readonly ModelPart RightFrontLeg;
    protected readonly ModelPart LeftFrontLeg;
    protected readonly ModelPart Tail;

    protected WolfModel(ModelPart root) : base(root) {
        Head = root.GetChild("head");
        Body = root.GetChild("body");
        RightHindLeg = root.GetChild("right_hind_leg");
        LeftHindLeg = root.GetChild("left_hind_leg");
        RightFrontLeg = root.GetChild("right_front_leg");
        LeftFrontLeg = root.GetChild("left_front_leg");
        Tail = root.GetChild("tail");
    }

    public override void SetupAnim(WolfRenderState state) {
        base.SetupAnim(state);
        float animationPos = state.WalkAnimationPos;
        float animationSpeed = state.WalkAnimationSpeed;
        Tail.YRot = state.IsAngry ? 0.0F : Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
        if (state.IsSitting) {
            SetSittingPose(state);
        }
        else {
            RightHindLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
            LeftHindLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
            RightFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
            LeftFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
        }
        ShakeOffWater(state);
        Head.XRot = state.XRot * (float)(Math.PI / 180.0);
        Head.YRot = state.YRot * (float)(Math.PI / 180.0);
        Tail.XRot = state.TailAngle;
    }

    protected virtual void ShakeOffWater(WolfRenderState state) {
        Body.ZRot = state.GetBodyRollAngle(-0.16F);
    }

    protected virtual void SetSittingPose(WolfRenderState state) {
        float ageScale = state.AgeScale;
        Body.Y += 4.0F * ageScale;
        Body.Z -= 2.0F * ageScale;
        Body.XRot = (float)(Math.PI / 4);
        Tail.Y += 9.0F * ageScale;
        Tail.Z -= 2.0F * ageScale;
        RightHindLeg.Y += 6.7F * ageScale;
        RightHindLeg.Z -= 5.0F * ageScale;
        RightHindLeg.XRot = (float)(Math.PI * 3.0 / 2.0);
        LeftHindLeg.Y += 6.7F * ageScale;
        LeftHindLeg.Z -= 5.0F * ageScale;
        LeftHindLeg.XRot = (float)(Math.PI * 3.0 / 2.0);
        RightFrontLeg.XRot = 5.811947F;
        RightFrontLeg.X += 0.01F * ageScale;
        RightFrontLeg.Y += 1.0F * ageScale;
        LeftFrontLeg.XRot = 5.811947F;
        LeftFrontLeg.X -= 0.01F * ageScale;
        LeftFrontLeg.Y += 1.0F * ageScale;
    }
}
