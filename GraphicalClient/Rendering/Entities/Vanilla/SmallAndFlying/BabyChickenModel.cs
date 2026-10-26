namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyChickenModel : ChickenModel {
    public BabyChickenModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-2.0F, -2.25F, -0.75F, 4.0F, 4.0F, 4.0F)
                .TexOffs(10, 8).AddBox(-1.0F, -0.25F, -1.75F, 2.0F, 1.0F, 1.0F),
            PartPose.Offset(0.0F, 20.25F, -1.25F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create()
                .TexOffs(2, 2).AddBox(-0.5F, 0.0F, 0.0F, 1.0F, 2.0F, 0.0F)
                .TexOffs(0, 1).AddBox(-0.5F, 2.0F, -1.0F, 1.0F, 0.0F, 1.0F),
            PartPose.Offset(1.0F, 22.0F, 0.5F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create()
                .TexOffs(0, 2).AddBox(-0.5F, 0.0F, 0.0F, 1.0F, 2.0F, 0.0F)
                .TexOffs(0, 0).AddBox(-0.5F, 2.0F, -1.0F, 1.0F, 0.0F, 1.0F),
            PartPose.Offset(-1.0F, 22.0F, 0.5F));
        root.AddOrReplaceChild("right_wing", CubeListBuilder.Create().TexOffs(6, 8).AddBox(0.0F, 0.0F, -1.0F, 1.0F, 0.0F, 2.0F), PartPose.Offset(2.0F, 20.0F, 0.0F));
        root.AddOrReplaceChild("left_wing", CubeListBuilder.Create().TexOffs(4, 8).AddBox(-1.0F, 0.0F, -1.0F, 1.0F, 0.0F, 2.0F), PartPose.Offset(-2.0F, 20.0F, 0.0F));
        return LayerDefinition.Create(mesh, 16, 16);
    }
}
