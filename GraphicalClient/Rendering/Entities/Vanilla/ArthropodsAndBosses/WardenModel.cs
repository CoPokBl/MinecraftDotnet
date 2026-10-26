namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class WardenModel : EntityModel<WardenRenderState> {
    private readonly ModelPart _bone, _body, _head, _rightTendril, _leftTendril, _leftLeg, _leftArm, _leftRibcage, _rightArm, _rightLeg, _rightRibcage;
    private readonly KeyframeAnimation _attackAnimation, _sonicBoomAnimation, _diggingAnimation, _emergeAnimation, _roarAnimation, _sniffAnimation;

    public WardenModel(ModelPart root) : base(root) {
        _bone = root.GetChild("bone");
        _body = _bone.GetChild("body");
        _head = _body.GetChild("head");
        _rightLeg = _bone.GetChild("right_leg");
        _leftLeg = _bone.GetChild("left_leg");
        _rightArm = _body.GetChild("right_arm");
        _leftArm = _body.GetChild("left_arm");
        _rightTendril = _head.GetChild("right_tendril");
        _leftTendril = _head.GetChild("left_tendril");
        _rightRibcage = _body.GetChild("right_ribcage");
        _leftRibcage = _body.GetChild("left_ribcage");
        _attackAnimation = WardenAnimation.WardenAttack.Bake(root);
        _sonicBoomAnimation = WardenAnimation.WardenSonicBoom.Bake(root);
        _diggingAnimation = WardenAnimation.WardenDig.Bake(root);
        _emergeAnimation = WardenAnimation.WardenEmerge.Bake(root);
        _roarAnimation = WardenAnimation.WardenRoar.Bake(root);
        _sniffAnimation = WardenAnimation.WardenSniff.Bake(root);
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition bone = root.AddOrReplaceChild("bone", CubeListBuilder.Create(), PartPose.Offset(0.0F, 24.0F, 0.0F));
        PartDefinition body = bone.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-9.0F, -13.0F, -4.0F, 18.0F, 21.0F, 11.0F),
            PartPose.Offset(0.0F, -21.0F, 0.0F));
        body.AddOrReplaceChild("right_ribcage", CubeListBuilder.Create().TexOffs(90, 11).AddBox(-2.0F, -11.0F, -0.1F, 9.0F, 21.0F, 0.0F),
            PartPose.Offset(-7.0F, -2.0F, -4.0F));
        body.AddOrReplaceChild("left_ribcage", CubeListBuilder.Create().TexOffs(90, 11).Mirror().AddBox(-7.0F, -11.0F, -0.1F, 9.0F, 21.0F, 0.0F).Mirror(false),
            PartPose.Offset(7.0F, -2.0F, -4.0F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 32).AddBox(-8.0F, -16.0F, -5.0F, 16.0F, 16.0F, 10.0F),
            PartPose.Offset(0.0F, -13.0F, 0.0F));
        head.AddOrReplaceChild("right_tendril", CubeListBuilder.Create().TexOffs(52, 32).AddBox(-16.0F, -13.0F, 0.0F, 16.0F, 16.0F, 0.0F),
            PartPose.Offset(-8.0F, -12.0F, 0.0F));
        head.AddOrReplaceChild("left_tendril", CubeListBuilder.Create().TexOffs(58, 0).AddBox(0.0F, -13.0F, 0.0F, 16.0F, 16.0F, 0.0F),
            PartPose.Offset(8.0F, -12.0F, 0.0F));
        body.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(44, 50).AddBox(-4.0F, 0.0F, -4.0F, 8.0F, 28.0F, 8.0F),
            PartPose.Offset(-13.0F, -13.0F, 1.0F));
        body.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(0, 58).AddBox(-4.0F, 0.0F, -4.0F, 8.0F, 28.0F, 8.0F), PartPose.Offset(13.0F, -13.0F, 1.0F));
        bone.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(76, 48).AddBox(-3.1F, 0.0F, -3.0F, 6.0F, 13.0F, 6.0F), PartPose.Offset(-5.9F, -13.0F, 0.0F));
        bone.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(76, 76).AddBox(-2.9F, 0.0F, -3.0F, 6.0F, 13.0F, 6.0F), PartPose.Offset(5.9F, -13.0F, 0.0F));
        return LayerDefinition.Create(mesh, 128, 128);
    }

    private static LayerDefinition Retaining(params string[] parts) =>
        CreateBodyLayer().Apply(mesh => {
            mesh.Root.RetainExactParts(new HashSet<string>(parts));
            return mesh;
        });

    public static LayerDefinition CreateTendrilsLayer() => Retaining("left_tendril", "right_tendril");

    public static LayerDefinition CreateHeartLayer() => Retaining("body");

    public static LayerDefinition CreateBioluminescentLayer() => Retaining("head", "left_arm", "right_arm", "left_leg", "right_leg");

    public static LayerDefinition CreatePulsatingSpotsLayer() => Retaining("body", "head", "left_arm", "right_arm", "left_leg", "right_leg");

    public override void SetupAnim(WardenRenderState state) {
        base.SetupAnim(state);
        AnimateHeadLookTarget(state.YRot, state.XRot);
        AnimateWalk(state.WalkAnimationPos, state.WalkAnimationSpeed);
        AnimateIdlePose(state.AgeInTicks);
        AnimateTendrils(state, state.AgeInTicks);
        _attackAnimation.Apply(state.AttackAnimationState, state.AgeInTicks);
        _sonicBoomAnimation.Apply(state.SonicBoomAnimationState, state.AgeInTicks);
        _diggingAnimation.Apply(state.DiggingAnimationState, state.AgeInTicks);
        _emergeAnimation.Apply(state.EmergeAnimationState, state.AgeInTicks);
        _roarAnimation.Apply(state.RoarAnimationState, state.AgeInTicks);
        _sniffAnimation.Apply(state.SniffAnimationState, state.AgeInTicks);
    }

    private void AnimateHeadLookTarget(float yRot, float xRot) {
        _head.XRot = xRot * (float)(Math.PI / 180.0);
        _head.YRot = yRot * (float)(Math.PI / 180.0);
    }

    private void AnimateIdlePose(float ageInTicks) {
        float scaledAge = ageInTicks * 0.1F;
        float wobbleCosine = Mth.Cos(scaledAge);
        float wobbleSine = Mth.Sin(scaledAge);
        _head.ZRot += 0.06F * wobbleCosine;
        _head.XRot += 0.06F * wobbleSine;
        _body.ZRot += 0.025F * wobbleSine;
        _body.XRot += 0.025F * wobbleCosine;
    }

    private void AnimateWalk(float animationPos, float animationSpeed) {
        float speedModifier = Math.Min(0.5F, 3.0F * animationSpeed);
        float adjustedPos = animationPos * 0.8662F;
        float adjustedPosCosine = Mth.Cos(adjustedPos);
        float adjustedPosSine = Mth.Sin(adjustedPos);
        float speedModifierWithMin = Math.Min(0.35F, speedModifier);
        _head.ZRot += 0.3F * adjustedPosSine * speedModifier;
        _head.XRot = _head.XRot + 1.2F * Mth.Cos(adjustedPos + (float)(Math.PI / 2)) * speedModifierWithMin;
        _body.ZRot = 0.1F * adjustedPosSine * speedModifier;
        _body.XRot = 1.0F * adjustedPosCosine * speedModifierWithMin;
        _leftLeg.XRot = 1.0F * adjustedPosCosine * speedModifier;
        _rightLeg.XRot = 1.0F * Mth.Cos(adjustedPos + (float)Math.PI) * speedModifier;
        _leftArm.XRot = -(0.8F * adjustedPosCosine * speedModifier);
        _leftArm.ZRot = 0.0F;
        _rightArm.XRot = -(0.8F * adjustedPosSine * speedModifier);
        _rightArm.ZRot = 0.0F;
        ResetArmPoses();
    }

    private void ResetArmPoses() {
        _leftArm.YRot = 0.0F;
        _leftArm.Z = 1.0F;
        _leftArm.X = 13.0F;
        _leftArm.Y = -13.0F;
        _rightArm.YRot = 0.0F;
        _rightArm.Z = 1.0F;
        _rightArm.X = -13.0F;
        _rightArm.Y = -13.0F;
    }

    private void AnimateTendrils(WardenRenderState state, float ageInTicks) {
        float tendrilXRot = state.TendrilAnimation * (float)(Math.Cos(ageInTicks * 2.25) * Math.PI * 0.1F);
        _leftTendril.XRot = tendrilXRot;
        _rightTendril.XRot = -tendrilXRot;
    }
}
