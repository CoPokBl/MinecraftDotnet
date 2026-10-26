namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabySheepModel(ModelPart root) : SheepModel(root) {
    public new static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 10).AddBox(-3.0F, -2.0F, -4.5F, 6.0F, 4.0F, 9.0F), PartPose.Offset(0.0F, 17.0F, 0.5F));
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.5F, -4.5F, -3.5F, 5.0F, 5.0F, 5.0F), PartPose.Offset(0.0F, 15.5F, -2.5F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(0, 23).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 5.0F, 2.0F),
            PartPose.Offset(-2.0F, 19.0F, 3.0F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(24, 12).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 5.0F, 2.0F),
            PartPose.Offset(2.0F, 19.0F, 3.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(8, 23).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 5.0F, 2.0F),
            PartPose.Offset(-2.0F, 19.0F, -2.0F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(24, 5).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 5.0F, 2.0F),
            PartPose.Offset(2.0F, 19.0F, -2.0F));
        return LayerDefinition.Create(mesh, 64, 32);
    }
}
