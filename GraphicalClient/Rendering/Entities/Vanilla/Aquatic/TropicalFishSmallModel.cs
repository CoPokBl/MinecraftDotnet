namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class TropicalFishSmallModel(ModelPart root) : TropicalFishModel(root) {
    public static LayerDefinition CreateBodyLayer(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, -1.5F, -3.0F, 2.0F, 3.0F, 6.0F, g), PartPose.Offset(0.0F, 22.0F, 0.0F));
        root.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(22, -6).AddBox(0.0F, -1.5F, 0.0F, 0.0F, 3.0F, 6.0F, g), PartPose.Offset(0.0F, 22.0F, 3.0F));
        root.AddOrReplaceChild("right_fin", CubeListBuilder.Create().TexOffs(2, 16).AddBox(-2.0F, -1.0F, 0.0F, 2.0F, 2.0F, 0.0F, g),
            PartPose.OffsetAndRotation(-1.0F, 22.5F, 0.0F, 0.0F, (float)(Math.PI / 4), 0.0F));
        root.AddOrReplaceChild("left_fin", CubeListBuilder.Create().TexOffs(2, 12).AddBox(0.0F, -1.0F, 0.0F, 2.0F, 2.0F, 0.0F, g),
            PartPose.OffsetAndRotation(1.0F, 22.5F, 0.0F, 0.0F, (float)(-Math.PI / 4), 0.0F));
        root.AddOrReplaceChild("top_fin", CubeListBuilder.Create().TexOffs(10, -5).AddBox(0.0F, -3.0F, 0.0F, 0.0F, 3.0F, 6.0F, g), PartPose.Offset(0.0F, 20.5F, -3.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }
}
