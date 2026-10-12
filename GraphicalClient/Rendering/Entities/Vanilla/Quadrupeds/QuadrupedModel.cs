namespace GraphicalClient.Rendering.Entities.Vanilla;

public class QuadrupedModel<S> : EntityModel<S> where S : LivingEntityRenderState {
    protected readonly ModelPart Head;
    protected readonly ModelPart Body;
    protected readonly ModelPart RightHindLeg;
    protected readonly ModelPart LeftHindLeg;
    protected readonly ModelPart RightFrontLeg;
    protected readonly ModelPart LeftFrontLeg;

    protected QuadrupedModel(ModelPart root) : base(root) {
        Head = root.GetChild("head");
        Body = root.GetChild("body");
        RightHindLeg = root.GetChild("right_hind_leg");
        LeftHindLeg = root.GetChild("left_hind_leg");
        RightFrontLeg = root.GetChild("right_front_leg");
        LeftFrontLeg = root.GetChild("left_front_leg");
    }

    public static MeshDefinition CreateBodyMesh(int legSize, bool mirrorLeftLeg, bool mirrorRightLeg, CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -4.0F, -8.0F, 8.0F, 8.0F, 8.0F, g),
            PartPose.Offset(0.0F, 18 - legSize, -6.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(28, 8).AddBox(-5.0F, -10.0F, -7.0F, 10.0F, 16.0F, 8.0F, g),
            PartPose.OffsetAndRotation(0.0F, 17 - legSize, 2.0F, MathF.PI / 2, 0.0F, 0.0F));
        CreateLegs(root, mirrorLeftLeg, mirrorRightLeg, legSize, g);
        return mesh;
    }

    public static void CreateLegs(PartDefinition root, bool mirrorLeftLeg, bool mirrorRightLeg, int legSize, CubeDeformation g) {
        CubeListBuilder rightLeg = CubeListBuilder.Create().Mirror(mirrorRightLeg).TexOffs(0, 16).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, legSize, 4.0F, g);
        CubeListBuilder leftLeg = CubeListBuilder.Create().Mirror(mirrorLeftLeg).TexOffs(0, 16).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, legSize, 4.0F, g);
        root.AddOrReplaceChild("right_hind_leg", rightLeg, PartPose.Offset(-3.0F, 24 - legSize, 7.0F));
        root.AddOrReplaceChild("left_hind_leg", leftLeg, PartPose.Offset(3.0F, 24 - legSize, 7.0F));
        root.AddOrReplaceChild("right_front_leg", rightLeg, PartPose.Offset(-3.0F, 24 - legSize, -5.0F));
        root.AddOrReplaceChild("left_front_leg", leftLeg, PartPose.Offset(3.0F, 24 - legSize, -5.0F));
    }

    public override void SetupAnim(S state) {
        base.SetupAnim(state);
        Head.XRot = state.XRot * (MathF.PI / 180.0F);
        Head.YRot = state.YRot * (MathF.PI / 180.0F);
        float animationPos = state.WalkAnimationPos;
        float animationSpeed = state.WalkAnimationSpeed;
        RightHindLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
        LeftHindLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
        RightFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
        LeftFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
    }
}
