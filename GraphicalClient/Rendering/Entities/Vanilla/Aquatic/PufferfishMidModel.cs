namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class PufferfishMidModel(ModelPart root) : PufferfishModel(root, "left_blue_fin", "right_blue_fin") {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(12, 22).AddBox(-2.5F, -5.0F, -2.5F, 5.0F, 5.0F, 5.0F), PartPose.Offset(0.0F, 22.0F, 0.0F));
        root.AddOrReplaceChild("right_blue_fin", CubeListBuilder.Create().TexOffs(24, 0).AddBox(-2.0F, 0.0F, 0.0F, 2.0F, 0.0F, 2.0F), PartPose.Offset(-2.5F, 18.0F, -1.5F));
        root.AddOrReplaceChild("left_blue_fin", CubeListBuilder.Create().TexOffs(24, 3).AddBox(0.0F, 0.0F, 0.0F, 2.0F, 0.0F, 2.0F), PartPose.Offset(2.5F, 18.0F, -1.5F));
        root.AddOrReplaceChild("top_front_fin", CubeListBuilder.Create().TexOffs(19, 17).AddBox(-2.5F, -1.0F, 0.0F, 5.0F, 1.0F, 0.0F),
            PartPose.OffsetAndRotation(0.0F, 17.0F, -2.5F, (float)(Math.PI / 4), 0.0F, 0.0F));
        root.AddOrReplaceChild("top_back_fin", CubeListBuilder.Create().TexOffs(11, 17).AddBox(-2.5F, -1.0F, 0.0F, 5.0F, 1.0F, 0.0F),
            PartPose.OffsetAndRotation(0.0F, 17.0F, 2.5F, (float)(-Math.PI / 4), 0.0F, 0.0F));
        root.AddOrReplaceChild("right_front_fin", CubeListBuilder.Create().TexOffs(5, 17).AddBox(-1.0F, -5.0F, 0.0F, 1.0F, 5.0F, 0.0F),
            PartPose.OffsetAndRotation(-2.5F, 22.0F, -2.5F, 0.0F, (float)(-Math.PI / 4), 0.0F));
        root.AddOrReplaceChild("right_back_fin", CubeListBuilder.Create().TexOffs(9, 17).AddBox(-1.0F, -5.0F, 0.0F, 1.0F, 5.0F, 0.0F),
            PartPose.OffsetAndRotation(-2.5F, 22.0F, 2.5F, 0.0F, (float)(Math.PI / 4), 0.0F));
        root.AddOrReplaceChild("left_back_fin", CubeListBuilder.Create().TexOffs(1, 17).AddBox(0.0F, -5.0F, 0.0F, 1.0F, 5.0F, 0.0F),
            PartPose.OffsetAndRotation(2.5F, 22.0F, 2.5F, 0.0F, (float)(-Math.PI / 4), 0.0F));
        root.AddOrReplaceChild("left_front_fin", CubeListBuilder.Create().TexOffs(1, 17).AddBox(0.0F, -5.0F, 0.0F, 1.0F, 5.0F, 0.0F),
            PartPose.OffsetAndRotation(2.5F, 22.0F, -2.5F, 0.0F, (float)(Math.PI / 4), 0.0F));
        root.AddOrReplaceChild("bottom_back_fin", CubeListBuilder.Create().TexOffs(18, 20).AddBox(0.0F, 0.0F, 0.0F, 5.0F, 1.0F, 0.0F),
            PartPose.OffsetAndRotation(-2.5F, 22.0F, 2.5F, (float)(Math.PI / 4), 0.0F, 0.0F));
        root.AddOrReplaceChild("bottom_front_fin", CubeListBuilder.Create().TexOffs(17, 19).AddBox(-2.5F, 0.0F, 0.0F, 5.0F, 1.0F, 1.0F),
            PartPose.OffsetAndRotation(0.0F, 22.0F, -2.5F, (float)(-Math.PI / 4), 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }
}
