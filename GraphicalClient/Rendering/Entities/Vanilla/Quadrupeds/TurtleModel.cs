namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class TurtleModel : QuadrupedModel<TurtleRenderState> {
    protected TurtleModel(ModelPart root) : base(root) { }

    public override void SetupAnim(TurtleRenderState state) {
        base.SetupAnim(state);
        float animationPos = state.WalkAnimationPos;
        float animationSpeed = state.WalkAnimationSpeed;
        if (state.IsOnLand) {
            float layEgg = state.IsLayingEgg ? 4.0F : 1.0F;
            float layEggAmplitude = state.IsLayingEgg ? 2.0F : 1.0F;
            float swingPos = animationPos * 5.0F;
            float frontSwing = Mth.Cos(layEgg * swingPos);
            float hindSwing = Mth.Cos(swingPos);
            RightFrontLeg.YRot = -frontSwing * 8.0F * animationSpeed * layEggAmplitude;
            LeftFrontLeg.YRot = frontSwing * 8.0F * animationSpeed * layEggAmplitude;
            RightHindLeg.YRot = -hindSwing * 3.0F * animationSpeed;
            LeftHindLeg.YRot = hindSwing * 3.0F * animationSpeed;
        }
        else {
            float swingScale = 0.5F * animationSpeed;
            float swing = Mth.Cos(animationPos * 0.6662F * 0.6F) * swingScale;
            RightHindLeg.XRot = swing;
            LeftHindLeg.XRot = -swing;
            RightFrontLeg.ZRot = -swing;
            LeftFrontLeg.ZRot = swing;
        }
    }
}
