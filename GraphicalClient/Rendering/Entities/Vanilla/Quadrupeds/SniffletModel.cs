namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>Only <c>SniffletModel</c>'s layer: <c>SnifferRenderer</c> bakes it into a plain <see cref="SnifferModel"/>, so the baby transform never runs.</summary>
public static class SniffletModel {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition bone = root.AddOrReplaceChild("bone", CubeListBuilder.Create(), PartPose.Offset(0.0F, 24.0F, 0.0F));
        PartDefinition body = bone.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(0, 35).AddBox(-13.0F, -14.0F, -0.5F, 14.0F, 14.0F, 20.0F, new CubeDeformation(0.25F))
            .TexOffs(0, 0).AddBox(-13.0F, -14.0F, -0.5F, 14.0F, 15.0F, 20.0F)
            .TexOffs(68, 0).AddBox(-13.0F, 0.0F, -0.5F, 14.0F, 0.0F, 20.0F), PartPose.Offset(6.0F, -3.0F, -9.5F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(68, 20).AddBox(-5.0F, -4.25F, -7.5F, 10.0F, 9.0F, 9.0F)
            .TexOffs(88, 20).AddBox(-5.0F, 3.75F, -7.5F, 10.0F, 0.0F, 9.0F), PartPose.Offset(-6.0F, -4.75F, 0.0F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(104, 38).AddBox(0.0F, 0.0F, -2.0F, 1.0F, 11.0F, 3.0F), PartPose.Offset(5.0F, -4.25F, -1.5F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(96, 38).AddBox(-1.0F, 0.0F, -2.0F, 1.0F, 11.0F, 3.0F),
            PartPose.Offset(-5.0F, -4.25F, -1.5F));
        head.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(68, 47).AddBox(-5.0F, -3.0F, -2.0F, 10.0F, 3.0F, 4.0F), PartPose.Offset(0.0F, -1.25F, -9.5F));
        head.AddOrReplaceChild("lower_beak", CubeListBuilder.Create().TexOffs(68, 38).AddBox(-5.0F, -2.5F, -2.0F, 10.0F, 5.0F, 4.0F),
            PartPose.Offset(0.0F, 1.25F, -9.5F));
        bone.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(0, 69).AddBox(-2.0F, -1.0F, -2.0F, 4.0F, 5.0F, 4.0F),
            PartPose.Offset(-4.0F, -4.0F, -7.0F));
        bone.AddOrReplaceChild("right_mid_leg", CubeListBuilder.Create().TexOffs(0, 78).AddBox(-2.0F, -1.0F, -2.0F, 4.0F, 5.0F, 4.0F),
            PartPose.Offset(-4.0F, -4.0F, 0.0F));
        bone.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(0, 87).AddBox(-2.0F, -1.0F, -2.0F, 4.0F, 5.0F, 4.0F),
            PartPose.Offset(-4.0F, -4.0F, 7.0F));
        bone.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(16, 69).AddBox(-2.0F, -1.0F, -2.0F, 4.0F, 5.0F, 4.0F),
            PartPose.Offset(4.0F, -4.0F, -7.0F));
        bone.AddOrReplaceChild("left_mid_leg", CubeListBuilder.Create().TexOffs(16, 78).AddBox(-2.0F, -1.0F, -2.0F, 4.0F, 5.0F, 4.0F),
            PartPose.Offset(4.0F, -4.0F, 0.0F));
        bone.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(16, 87).AddBox(-2.0F, -1.0F, -2.0F, 4.0F, 5.0F, 4.0F),
            PartPose.Offset(4.0F, -4.0F, 7.0F));
        return LayerDefinition.Create(mesh, 128, 128);
    }
}
