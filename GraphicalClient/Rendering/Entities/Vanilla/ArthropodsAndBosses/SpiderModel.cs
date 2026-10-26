namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SpiderModel : EntityModel<LivingEntityRenderState> {
    private readonly ModelPart _head, _rightHindLeg, _leftHindLeg, _rightMiddleHindLeg, _leftMiddleHindLeg;
    private readonly ModelPart _rightMiddleFrontLeg, _leftMiddleFrontLeg, _rightFrontLeg, _leftFrontLeg;

    public SpiderModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _rightHindLeg = root.GetChild("right_hind_leg");
        _leftHindLeg = root.GetChild("left_hind_leg");
        _rightMiddleHindLeg = root.GetChild("right_middle_hind_leg");
        _leftMiddleHindLeg = root.GetChild("left_middle_hind_leg");
        _rightMiddleFrontLeg = root.GetChild("right_middle_front_leg");
        _leftMiddleFrontLeg = root.GetChild("left_middle_front_leg");
        _rightFrontLeg = root.GetChild("right_front_leg");
        _leftFrontLeg = root.GetChild("left_front_leg");
    }

    public static LayerDefinition CreateSpiderBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(32, 4).AddBox(-4.0F, -4.0F, -8.0F, 8.0F, 8.0F, 8.0F), PartPose.Offset(0.0F, 15.0F, -3.0F));
        root.AddOrReplaceChild("body0", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.0F, -3.0F, -3.0F, 6.0F, 6.0F, 6.0F), PartPose.Offset(0.0F, 15.0F, 0.0F));
        root.AddOrReplaceChild("body1", CubeListBuilder.Create().TexOffs(0, 12).AddBox(-5.0F, -4.0F, -6.0F, 10.0F, 8.0F, 12.0F), PartPose.Offset(0.0F, 15.0F, 9.0F));
        CubeListBuilder rightLeg = CubeListBuilder.Create().TexOffs(18, 0).AddBox(-15.0F, -1.0F, -1.0F, 16.0F, 2.0F, 2.0F);
        CubeListBuilder leftLeg = CubeListBuilder.Create().TexOffs(18, 0).Mirror().AddBox(-1.0F, -1.0F, -1.0F, 16.0F, 2.0F, 2.0F);
        const float quarter = (float)(Math.PI / 4), eighth = (float)(Math.PI / 8);
        root.AddOrReplaceChild("right_hind_leg", rightLeg, PartPose.OffsetAndRotation(-4.0F, 15.0F, 2.0F, 0.0F, quarter, -quarter));
        root.AddOrReplaceChild("left_hind_leg", leftLeg, PartPose.OffsetAndRotation(4.0F, 15.0F, 2.0F, 0.0F, -quarter, quarter));
        root.AddOrReplaceChild("right_middle_hind_leg", rightLeg, PartPose.OffsetAndRotation(-4.0F, 15.0F, 1.0F, 0.0F, eighth, -0.58119464F));
        root.AddOrReplaceChild("left_middle_hind_leg", leftLeg, PartPose.OffsetAndRotation(4.0F, 15.0F, 1.0F, 0.0F, -eighth, 0.58119464F));
        root.AddOrReplaceChild("right_middle_front_leg", rightLeg, PartPose.OffsetAndRotation(-4.0F, 15.0F, 0.0F, 0.0F, -eighth, -0.58119464F));
        root.AddOrReplaceChild("left_middle_front_leg", leftLeg, PartPose.OffsetAndRotation(4.0F, 15.0F, 0.0F, 0.0F, eighth, 0.58119464F));
        root.AddOrReplaceChild("right_front_leg", rightLeg, PartPose.OffsetAndRotation(-4.0F, 15.0F, -1.0F, 0.0F, -quarter, -quarter));
        root.AddOrReplaceChild("left_front_leg", leftLeg, PartPose.OffsetAndRotation(4.0F, 15.0F, -1.0F, 0.0F, quarter, quarter));
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(LivingEntityRenderState state) {
        base.SetupAnim(state);
        _head.YRot = state.YRot * (float)(Math.PI / 180.0);
        _head.XRot = state.XRot * (float)(Math.PI / 180.0);
        float animationPos = state.WalkAnimationPos * 0.6662F;
        float animationSpeed = state.WalkAnimationSpeed;
        float swingHind = -(Mth.Cos(animationPos * 2.0F + 0.0F) * 0.4F) * animationSpeed;
        float swingMiddleHind = -(Mth.Cos(animationPos * 2.0F + (float)Math.PI) * 0.4F) * animationSpeed;
        float swingMiddleFront = -(Mth.Cos(animationPos * 2.0F + (float)(Math.PI / 2)) * 0.4F) * animationSpeed;
        float swingFront = -(Mth.Cos(animationPos * 2.0F + (float)(Math.PI * 3.0 / 2.0)) * 0.4F) * animationSpeed;
        float stepHind = Math.Abs(Mth.Sin(animationPos + 0.0F) * 0.4F) * animationSpeed;
        float stepMiddleHind = Math.Abs(Mth.Sin(animationPos + (float)Math.PI) * 0.4F) * animationSpeed;
        float stepMiddleFrontHind = Math.Abs(Mth.Sin(animationPos + (float)(Math.PI / 2)) * 0.4F) * animationSpeed;
        float stepFront = Math.Abs(Mth.Sin(animationPos + (float)(Math.PI * 3.0 / 2.0)) * 0.4F) * animationSpeed;
        _rightHindLeg.YRot += swingHind;
        _leftHindLeg.YRot -= swingHind;
        _rightMiddleHindLeg.YRot += swingMiddleHind;
        _leftMiddleHindLeg.YRot -= swingMiddleHind;
        _rightMiddleFrontLeg.YRot += swingMiddleFront;
        _leftMiddleFrontLeg.YRot -= swingMiddleFront;
        _rightFrontLeg.YRot += swingFront;
        _leftFrontLeg.YRot -= swingFront;
        _rightHindLeg.ZRot += stepHind;
        _leftHindLeg.ZRot -= stepHind;
        _rightMiddleHindLeg.ZRot += stepMiddleHind;
        _leftMiddleHindLeg.ZRot -= stepMiddleHind;
        _rightMiddleFrontLeg.ZRot += stepMiddleFrontHind;
        _leftMiddleFrontLeg.ZRot -= stepMiddleFrontHind;
        _rightFrontLeg.ZRot += stepFront;
        _leftFrontLeg.ZRot -= stepFront;
    }
}
