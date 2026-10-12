namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class PufferfishSmallModel(ModelPart root) : PufferfishModel(root, "left_fin", "right_fin") {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 27).AddBox(-1.5F, -2.0F, -1.5F, 3.0F, 2.0F, 3.0F), PartPose.Offset(0.0F, 23.0F, 0.0F));
        root.AddOrReplaceChild("right_eye", CubeListBuilder.Create().TexOffs(24, 6).AddBox(-1.5F, 0.0F, -1.5F, 1.0F, 1.0F, 1.0F), PartPose.Offset(0.0F, 20.0F, 0.0F));
        root.AddOrReplaceChild("left_eye", CubeListBuilder.Create().TexOffs(28, 6).AddBox(0.5F, 0.0F, -1.5F, 1.0F, 1.0F, 1.0F), PartPose.Offset(0.0F, 20.0F, 0.0F));
        root.AddOrReplaceChild("back_fin", CubeListBuilder.Create().TexOffs(-3, 0).AddBox(-1.5F, 0.0F, 0.0F, 3.0F, 0.0F, 3.0F), PartPose.Offset(0.0F, 22.0F, 1.5F));
        root.AddOrReplaceChild("right_fin", CubeListBuilder.Create().TexOffs(25, 0).AddBox(-1.0F, 0.0F, 0.0F, 1.0F, 0.0F, 2.0F), PartPose.Offset(-1.5F, 22.0F, -1.5F));
        root.AddOrReplaceChild("left_fin", CubeListBuilder.Create().TexOffs(25, 0).AddBox(0.0F, 0.0F, 0.0F, 1.0F, 0.0F, 2.0F), PartPose.Offset(1.5F, 22.0F, -1.5F));
        return LayerDefinition.Create(mesh, 32, 32);
    }
}
