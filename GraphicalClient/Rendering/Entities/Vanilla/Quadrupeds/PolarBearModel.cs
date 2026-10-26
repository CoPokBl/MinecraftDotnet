namespace GraphicalClient.Rendering.Entities.Vanilla;

public class PolarBearModel(ModelPart root) : QuadrupedModel<PolarBearRenderState>(root) {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-3.5F, -3.0F, -3.0F, 7.0F, 7.0F, 7.0F)
            .TexOffs(0, 44).AddBox("mouth", -2.5F, 1.0F, -6.0F, 5.0F, 3.0F, 3.0F)
            .TexOffs(26, 0).AddBox("right_ear", -4.5F, -4.0F, -1.0F, 2.0F, 2.0F, 1.0F)
            .TexOffs(26, 0).Mirror().AddBox("left_ear", 2.5F, -4.0F, -1.0F, 2.0F, 2.0F, 1.0F), PartPose.Offset(0.0F, 10.0F, -16.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(0, 19).AddBox(-5.0F, -13.0F, -7.0F, 14.0F, 14.0F, 11.0F)
            .TexOffs(39, 0).AddBox(-4.0F, -25.0F, -7.0F, 12.0F, 12.0F, 10.0F), PartPose.OffsetAndRotation(-2.0F, 9.0F, 12.0F, MathF.PI / 2, 0.0F, 0.0F));
        CubeListBuilder hindLeg = CubeListBuilder.Create().TexOffs(50, 22).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 10.0F, 8.0F);
        root.AddOrReplaceChild("right_hind_leg", hindLeg, PartPose.Offset(-4.5F, 14.0F, 6.0F));
        root.AddOrReplaceChild("left_hind_leg", hindLeg, PartPose.Offset(4.5F, 14.0F, 6.0F));
        CubeListBuilder frontLeg = CubeListBuilder.Create().TexOffs(50, 40).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 10.0F, 6.0F);
        root.AddOrReplaceChild("right_front_leg", frontLeg, PartPose.Offset(-3.5F, 14.0F, -8.0F));
        root.AddOrReplaceChild("left_front_leg", frontLeg, PartPose.Offset(3.5F, 14.0F, -8.0F));
        return LayerDefinition.Create(mesh, 128, 64).Apply(MeshTransformers.Scaling(1.2F));
    }

    public override void SetupAnim(PolarBearRenderState state) {
        base.SetupAnim(state);
        float standScale = state.StandScale * state.StandScale;
        float bodyAgeScale = state.AgeScale;
        Body.XRot -= standScale * MathF.PI * 0.35F;
        Body.Y += standScale * bodyAgeScale * 2.0F;
        RightFrontLeg.Y -= standScale * bodyAgeScale * 20.0F;
        RightFrontLeg.Z += standScale * bodyAgeScale * 4.0F;
        RightFrontLeg.XRot -= standScale * MathF.PI * 0.45F;
        LeftFrontLeg.Y = RightFrontLeg.Y;
        LeftFrontLeg.Z = RightFrontLeg.Z;
        LeftFrontLeg.XRot -= standScale * MathF.PI * 0.45F;
        Head.Y -= standScale * 24.0F;
        Head.Z += standScale * 13.0F;
        Head.XRot += standScale * MathF.PI * 0.15F;
    }
}
