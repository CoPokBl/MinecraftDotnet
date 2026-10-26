namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyPigModel(ModelPart root) : PigModel(root) {
    public new static LayerDefinition CreateBodyLayer(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.5F, -3.0F, -4.5F, 7.0F, 6.0F, 9.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 19.0F, 0.5F));
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 15).AddBox(-3.5F, -5.0F, -5.0F, 7.0F, 6.0F, 6.0F, new CubeDeformation(0.025F))
            .TexOffs(6, 27).AddBox(-1.5F, -1.975F, -6.0F, 3.0F, 2.0F, 1.0F, new CubeDeformation(0.015F)), PartPose.Offset(0.0F, 19.0F, -2.0F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(2.5F, 22.0F, -3.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(23, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-2.5F, 22.0F, -3.0F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(0, 4).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(2.5F, 22.0F, 4.0F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(23, 4).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-2.5F, 22.0F, 4.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }
}
