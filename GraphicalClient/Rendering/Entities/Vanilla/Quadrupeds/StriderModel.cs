namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class StriderModel : EntityModel<StriderRenderState> {
    protected readonly ModelPart RightLeg;
    protected readonly ModelPart LeftLeg;
    protected readonly ModelPart Body;

    protected StriderModel(ModelPart root) : base(root) {
        RightLeg = root.GetChild("right_leg");
        LeftLeg = root.GetChild("left_leg");
        Body = root.GetChild("body");
    }

    public override void SetupAnim(StriderRenderState state) {
        base.SetupAnim(state);
        float animationPos = state.WalkAnimationPos;
        float animationSpeed = Math.Min(state.WalkAnimationSpeed, 0.25F);
        if (!state.IsRidden) {
            Body.XRot = state.XRot * (MathF.PI / 180.0F);
            Body.YRot = state.YRot * (MathF.PI / 180.0F);
        }
        else {
            Body.XRot = 0.0F;
            Body.YRot = 0.0F;
        }
        Body.ZRot = 0.1F * Mth.Sin(animationPos * 1.5F) * 4.0F * animationSpeed;
        LeftLeg.XRot = Mth.Sin(animationPos * 1.5F * 0.5F) * 2.0F * animationSpeed;
        RightLeg.XRot = Mth.Sin(animationPos * 1.5F * 0.5F + MathF.PI) * 2.0F * animationSpeed;
        LeftLeg.ZRot = MathF.PI / 18 * Mth.Cos(animationPos * 1.5F * 0.5F) * animationSpeed;
        RightLeg.ZRot = MathF.PI / 18 * Mth.Cos(animationPos * 1.5F * 0.5F + MathF.PI) * animationSpeed;
        CustomAnimations(animationPos, animationSpeed, state.AgeInTicks);
    }

    protected abstract void CustomAnimations(float animationPos, float animationSpeed, float ageInTicks);

    public void AnimateBristle(float ageInTicks, float bristleFlow, ModelPart firstBristle, ModelPart secondBristle, ModelPart thirdBristle,
        Action<ModelPart, float> addRotationFunction) {
        addRotationFunction(firstBristle, bristleFlow * 0.6F);
        addRotationFunction(secondBristle, bristleFlow * 1.2F);
        addRotationFunction(thirdBristle, bristleFlow * 1.3F);
        addRotationFunction(firstBristle, 0.1F * Mth.Sin(ageInTicks * 0.4F));
        addRotationFunction(secondBristle, 0.1F * Mth.Sin(ageInTicks * 0.2F));
        addRotationFunction(thirdBristle, 0.05F * Mth.Sin(ageInTicks * -0.4F));
    }
}
