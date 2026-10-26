namespace GraphicalClient.Rendering.Entities.Vanilla;

public class BabyLlamaModel(ModelPart root) : LlamaModel(root) {
    public static new LayerDefinition CreateBodyLayer(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-3.0F, -9.0F, -4.0F, 6.0F, 11.0F, 4.0F, g)
            .TexOffs(0, 15).AddBox(-1.5F, -7.0F, -7.0F, 3.0F, 3.0F, 3.0F, g)
            .TexOffs(20, 4).AddBox(0.5F, -11.0F, -3.0F, 2.0F, 2.0F, 2.0F, g)
            .TexOffs(20, 0).AddBox(-2.5F, -11.0F, -3.0F, 2.0F, 2.0F, 2.0F, g), PartPose.Offset(0.0F, 12.0F, -4.0F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(0, 45).AddBox(-1.4F, -0.5F, -1.5F, 3.0F, 8.0F, 3.0F, g),
            PartPose.Offset(-2.5F, 16.5F, 4.5F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(12, 45).AddBox(-1.6F, -0.5F, -1.5F, 3.0F, 8.0F, 3.0F, g),
            PartPose.Offset(2.5F, 16.5F, 4.5F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(0, 34).AddBox(-1.4F, -0.5F, -1.5F, 3.0F, 8.0F, 3.0F, g),
            PartPose.Offset(-2.5F, 16.5F, -3.5F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(12, 34).AddBox(-1.6F, -0.5F, -1.5F, 3.0F, 8.0F, 3.0F, g),
            PartPose.Offset(2.5F, 16.5F, -3.5F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 15).AddBox(-4.0F, -3.0F, -8.5F, 8.0F, 6.0F, 13.0F, g), PartPose.Offset(0.0F, 14.0F, 2.5F));
        root.AddOrReplaceChild("right_chest", CubeListBuilder.Create().TexOffs(45, 28).AddBox(-3.0F, 0.0F, 0.0F, 8.0F, 8.0F, 3.0F, g),
            PartPose.OffsetAndRotation(-8.5F, 4.0F, 3.0F, 0.0F, (float)(Math.PI / 2), 0.0F));
        root.AddOrReplaceChild("left_chest", CubeListBuilder.Create().TexOffs(45, 41).AddBox(-3.0F, 0.0F, 0.0F, 8.0F, 8.0F, 3.0F, g),
            PartPose.OffsetAndRotation(5.5F, 4.0F, 3.0F, 0.0F, (float)(Math.PI / 2), 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
