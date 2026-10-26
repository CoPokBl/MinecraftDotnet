namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class TropicalFishLargeModel(ModelPart root) : TropicalFishModel(root) {
    public static LayerDefinition CreateBodyLayer(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 20).AddBox(-1.0F, -3.0F, -3.0F, 2.0F, 6.0F, 6.0F, g), PartPose.Offset(0.0F, 19.0F, 0.0F));
        root.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(21, 16).AddBox(0.0F, -3.0F, 0.0F, 0.0F, 6.0F, 5.0F, g), PartPose.Offset(0.0F, 19.0F, 3.0F));
        root.AddOrReplaceChild("right_fin", CubeListBuilder.Create().TexOffs(2, 16).AddBox(-2.0F, 0.0F, 0.0F, 2.0F, 2.0F, 0.0F, g),
            PartPose.OffsetAndRotation(-1.0F, 20.0F, 0.0F, 0.0F, (float)(Math.PI / 4), 0.0F));
        root.AddOrReplaceChild("left_fin", CubeListBuilder.Create().TexOffs(2, 12).AddBox(0.0F, 0.0F, 0.0F, 2.0F, 2.0F, 0.0F, g),
            PartPose.OffsetAndRotation(1.0F, 20.0F, 0.0F, 0.0F, (float)(-Math.PI / 4), 0.0F));
        root.AddOrReplaceChild("top_fin", CubeListBuilder.Create().TexOffs(20, 11).AddBox(0.0F, -4.0F, 0.0F, 0.0F, 4.0F, 6.0F, g), PartPose.Offset(0.0F, 16.0F, -3.0F));
        root.AddOrReplaceChild("bottom_fin", CubeListBuilder.Create().TexOffs(20, 21).AddBox(0.0F, 0.0F, 0.0F, 0.0F, 4.0F, 6.0F, g), PartPose.Offset(0.0F, 22.0F, -3.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }
}
