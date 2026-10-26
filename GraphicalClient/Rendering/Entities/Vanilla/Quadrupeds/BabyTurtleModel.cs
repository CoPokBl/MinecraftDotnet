namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyTurtleModel(ModelPart root) : TurtleModel(root) {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.0F, -1.0F, -2.0F, 4.0F, 2.0F, 4.0F), PartPose.Offset(0.0F, 22.9F, 1.0F));
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 6).AddBox(-1.5F, -2.0F, -3.0F, 3.0F, 3.0F, 3.0F), PartPose.Offset(0.0F, 22.9F, -1.0F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(-1, 0).AddBox(-2.0F, 0.0F, -0.5F, 2.0F, 0.0F, 1.0F),
            PartPose.Offset(-2.0F, 23.9F, 2.5F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(-1, 1).AddBox(0.0F, 0.0F, -0.5F, 2.0F, 0.0F, 1.0F), PartPose.Offset(2.0F, 23.9F, 2.5F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(8, 6).AddBox(-2.0F, 0.0F, -0.5F, 2.0F, 0.0F, 1.0F),
            PartPose.Offset(-2.0F, 23.9F, -0.5F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(8, 7).AddBox(0.0F, 0.0F, -0.5F, 2.0F, 0.0F, 1.0F), PartPose.Offset(2.0F, 23.9F, -0.5F));
        return LayerDefinition.Create(mesh, 16, 16);
    }
}
