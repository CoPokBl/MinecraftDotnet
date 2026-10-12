namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class FrogModel : EntityModel<FrogRenderState> {
    private const float MaxWalkAnimationSpeed = 1.5F;
    private const float MaxSwimAnimationSpeed = 1.0F;
    private const float WalkAnimationScaleFactor = 2.5F;
    private readonly ModelPart _body, _head, _eyes, _tongue, _leftArm, _rightArm, _leftLeg, _rightLeg, _croakingBody;
    private readonly KeyframeAnimation _jumpAnimation, _croakAnimation, _tongueAnimation, _swimAnimation, _walkAnimation, _idleWaterAnimation;

    /// <remarks>The model is the "root" child; the animations bake against the whole tree.</remarks>
    public FrogModel(ModelPart root) : base(root.GetChild("root")) {
        _body = Root.GetChild("body");
        _head = _body.GetChild("head");
        _eyes = _head.GetChild("eyes");
        _tongue = _body.GetChild("tongue");
        _leftArm = _body.GetChild("left_arm");
        _rightArm = _body.GetChild("right_arm");
        _leftLeg = Root.GetChild("left_leg");
        _rightLeg = Root.GetChild("right_leg");
        _croakingBody = _body.GetChild("croaking_body");
        _jumpAnimation = FrogAnimation.FrogJump.Bake(root);
        _croakAnimation = FrogAnimation.FrogCroak.Bake(root);
        _tongueAnimation = FrogAnimation.FrogTongue.Bake(root);
        _swimAnimation = FrogAnimation.FrogSwim.Bake(root);
        _walkAnimation = FrogAnimation.FrogWalk.Bake(root);
        _idleWaterAnimation = FrogAnimation.FrogIdleWater.Bake(root);
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition modelRoot = root.AddOrReplaceChild("root", CubeListBuilder.Create(), PartPose.Offset(0.0F, 24.0F, 0.0F));
        PartDefinition body = modelRoot.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(3, 1).AddBox(-3.5F, -2.0F, -8.0F, 7.0F, 3.0F, 9.0F)
                .TexOffs(23, 22).AddBox(-3.5F, -1.0F, -8.0F, 7.0F, 0.0F, 9.0F),
            PartPose.Offset(0.0F, -2.0F, 4.0F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(23, 13).AddBox(-3.5F, -1.0F, -7.0F, 7.0F, 0.0F, 9.0F)
                .TexOffs(0, 13).AddBox(-3.5F, -2.0F, -7.0F, 7.0F, 3.0F, 9.0F),
            PartPose.Offset(0.0F, -2.0F, -1.0F));
        PartDefinition eyes = head.AddOrReplaceChild("eyes", CubeListBuilder.Create(), PartPose.Offset(-0.5F, 0.0F, 2.0F));
        eyes.AddOrReplaceChild("right_eye", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.5F, -1.0F, -1.5F, 3.0F, 2.0F, 3.0F), PartPose.Offset(-1.5F, -3.0F, -6.5F));
        eyes.AddOrReplaceChild("left_eye", CubeListBuilder.Create().TexOffs(0, 5).AddBox(-1.5F, -1.0F, -1.5F, 3.0F, 2.0F, 3.0F), PartPose.Offset(2.5F, -3.0F, -6.5F));
        body.AddOrReplaceChild("croaking_body", CubeListBuilder.Create().TexOffs(26, 5).AddBox(-3.5F, -0.1F, -2.9F, 7.0F, 2.0F, 3.0F, new CubeDeformation(-0.1F)),
            PartPose.Offset(0.0F, -1.0F, -5.0F));
        body.AddOrReplaceChild("tongue", CubeListBuilder.Create().TexOffs(17, 13).AddBox(-2.0F, 0.0F, -7.1F, 4.0F, 0.0F, 7.0F), PartPose.Offset(0.0F, -1.01F, 1.0F));
        PartDefinition leftArm = body.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(0, 32).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 3.0F, 3.0F),
            PartPose.Offset(4.0F, -1.0F, -6.5F));
        leftArm.AddOrReplaceChild("left_hand", CubeListBuilder.Create().TexOffs(18, 40).AddBox(-4.0F, 0.01F, -4.0F, 8.0F, 0.0F, 8.0F),
            PartPose.Offset(0.0F, 3.0F, -1.0F));
        PartDefinition rightArm = body.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(0, 38).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 3.0F, 3.0F),
            PartPose.Offset(-4.0F, -1.0F, -6.5F));
        rightArm.AddOrReplaceChild("right_hand", CubeListBuilder.Create().TexOffs(2, 40).AddBox(-4.0F, 0.01F, -5.0F, 8.0F, 0.0F, 8.0F),
            PartPose.Offset(0.0F, 3.0F, 0.0F));
        PartDefinition leftLeg = modelRoot.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(14, 25).AddBox(-1.0F, 0.0F, -2.0F, 3.0F, 3.0F, 4.0F),
            PartPose.Offset(3.5F, -3.0F, 4.0F));
        leftLeg.AddOrReplaceChild("left_foot", CubeListBuilder.Create().TexOffs(2, 32).AddBox(-4.0F, 0.01F, -4.0F, 8.0F, 0.0F, 8.0F), PartPose.Offset(2.0F, 3.0F, 0.0F));
        PartDefinition rightLeg = modelRoot.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 25).AddBox(-2.0F, 0.0F, -2.0F, 3.0F, 3.0F, 4.0F),
            PartPose.Offset(-3.5F, -3.0F, 4.0F));
        rightLeg.AddOrReplaceChild("right_foot", CubeListBuilder.Create().TexOffs(18, 32).AddBox(-4.0F, 0.01F, -4.0F, 8.0F, 0.0F, 8.0F),
            PartPose.Offset(-2.0F, 3.0F, 0.0F));
        return LayerDefinition.Create(mesh, 48, 48);
    }

    public override void SetupAnim(FrogRenderState state) {
        base.SetupAnim(state);
        _jumpAnimation.Apply(state.JumpAnimationState, state.AgeInTicks);
        _croakAnimation.Apply(state.CroakAnimationState, state.AgeInTicks);
        _tongueAnimation.Apply(state.TongueAnimationState, state.AgeInTicks);
        if (state.IsSwimming) {
            _swimAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, 1.0F, 2.5F);
        }
        else {
            _walkAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, 1.5F, 2.5F);
        }
        _idleWaterAnimation.Apply(state.SwimIdleAnimationState, state.AgeInTicks);
        _croakingBody.Visible = state.CroakAnimationState.IsStarted;
    }
}
