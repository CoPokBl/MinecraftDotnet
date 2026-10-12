namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyPandaModel(ModelPart root) : PandaModel(root) {
    public new static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 11).AddBox(-4.5F, -3.5F, -5.5F, 9.0F, 7.0F, 11.0F), PartPose.Offset(0.0F, 18.5F, 2.5F));
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-3.5F, -3.0F, -5.0F, 7.0F, 6.0F, 5.0F)
            .TexOffs(24, 6).AddBox(-2.0F, 1.0F, -6.0F, 4.0F, 2.0F, 1.0F)
            .TexOffs(24, 0).AddBox(-4.5F, -4.0F, -3.5F, 3.0F, 3.0F, 1.0F)
            .TexOffs(33, 0).AddBox(1.5F, -4.0F, -3.5F, 3.0F, 3.0F, 1.0F), PartPose.Offset(0.0F, 19.0F, -3.0F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(0, 34).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 2.0F, 3.0F),
            PartPose.Offset(-3.0F, 22.0F, 6.5F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(12, 34).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 2.0F, 3.0F),
            PartPose.Offset(3.0F, 22.0F, 6.5F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(0, 29).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 2.0F, 3.0F),
            PartPose.Offset(-3.0F, 22.0F, -1.5F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(12, 29).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 2.0F, 3.0F),
            PartPose.Offset(3.0F, 22.0F, -1.5F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    protected override void AnimateSitting(PandaRenderState state) {
        Body.XRot = Mth.RotLerpRad(state.SitAmount, Body.XRot, MathF.PI / 18);
        Body.Z = Mth.Lerp(state.SitAmount, Body.Z, -1.5F);
        Head.Z = Mth.Lerp(state.SitAmount, Head.Z, -11.5F);
        Head.Y = Mth.Lerp(state.SitAmount, Head.Y, 17.5F);
        RightFrontLeg.Z = Mth.Lerp(state.SitAmount, RightFrontLeg.Z, -5.0F);
        LeftFrontLeg.Z = Mth.Lerp(state.SitAmount, LeftFrontLeg.Z, -5.0F);
        RightHindLeg.Z = Mth.Lerp(state.SitAmount, RightHindLeg.Z, 3.0F);
        LeftHindLeg.Z = Mth.Lerp(state.SitAmount, LeftHindLeg.Z, 3.0F);
        RightFrontLeg.ZRot = -0.27079642F;
        LeftFrontLeg.ZRot = 0.27079642F;
        RightHindLeg.ZRot = 0.5707964F;
        LeftHindLeg.ZRot = -0.5707964F;
    }
}
