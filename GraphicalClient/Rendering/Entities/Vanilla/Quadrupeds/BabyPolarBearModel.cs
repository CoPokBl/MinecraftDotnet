namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BabyPolarBearModel</c>'s layer. <c>PolarBearRenderer</c> bakes it into a plain <see cref="PolarBearModel"/>.</summary>
public static class BabyPolarBearModel {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 9).AddBox(-4.0F, -3.5F, -6.0F, 8.0F, 7.0F, 12.0F), PartPose.Offset(0.0F, 17.5F, 0.0F));
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-3.0F, -2.625F, -4.25F, 6.0F, 5.0F, 4.0F)
            .TexOffs(20, 3).AddBox(-2.0F, 0.375F, -6.25F, 4.0F, 2.0F, 2.0F)
            .TexOffs(20, 0).AddBox(-4.0F, -3.625F, -2.75F, 2.0F, 2.0F, 1.0F)
            .TexOffs(26, 0).AddBox(2.0F, -3.625F, -2.75F, 2.0F, 2.0F, 1.0F), PartPose.Offset(0.0F, 18.625F, -5.75F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(0, 34).AddBox(-1.5F, -0.5F, -1.5F, 3.0F, 3.0F, 3.0F),
            PartPose.Offset(-2.5F, 21.5F, 4.5F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(12, 34).AddBox(-1.5F, -0.5F, -1.5F, 3.0F, 3.0F, 3.0F),
            PartPose.Offset(2.5F, 21.5F, 4.5F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(0, 28).AddBox(-1.5F, -0.5F, -1.5F, 3.0F, 3.0F, 3.0F),
            PartPose.Offset(-2.5F, 21.5F, -4.5F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(12, 28).AddBox(-1.5F, -0.5F, -1.5F, 3.0F, 3.0F, 3.0F),
            PartPose.Offset(2.5F, 21.5F, -4.5F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
