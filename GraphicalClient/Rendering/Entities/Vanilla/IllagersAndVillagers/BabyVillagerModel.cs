namespace GraphicalClient.Rendering.Entities.Vanilla;

public class BabyVillagerModel : VillagerModel {
    public BabyVillagerModel(ModelPart root) : base(root) { }

    public new static MeshDefinition CreateNoHatModel() {
        MeshDefinition mesh = CreateBodyModel();
        mesh.Root.ClearChild("head").ClearRecursively();
        return mesh;
    }

    public new static MeshDefinition CreateBodyModel() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition arms = root.AddOrReplaceChild("arms", CubeListBuilder.Create(), PartPose.Offset(0.0F, 17.5F, 0.0F));
        arms.AddOrReplaceChild("right_hand", CubeListBuilder.Create()
                .TexOffs(36, 15).AddBox(-1.0F, -2.4925F, -1.8401F, 2.0F, 4.0F, 2.0F)
                .TexOffs(16, 15).AddBox(5.0F, -2.4925F, -1.8401F, 2.0F, 4.0F, 2.0F),
            PartPose.OffsetAndRotation(-3.0F, 1.4025F, -0.9599F, -1.0472F, 0.0F, 0.0F));
        arms.AddOrReplaceChild("middlearm_r1", CubeListBuilder.Create().TexOffs(24, 17).AddBox(-2.0F, -0.9924F, -0.9825F, 4.0F, 2.0F, 2.0F),
            PartPose.OffsetAndRotation(0.0F, 0.9024F, -1.8175F, -1.0472F, 0.0F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(8, 23).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 3.0F, 2.0F), PartPose.Offset(-1.0F, 21.5F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 23).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 3.0F, 2.0F), PartPose.Offset(1.0F, 21.5F, 0.0F));
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -8.0F, -3.5F, 8.0F, 8.0F, 7.0F),
            PartPose.Offset(0.0F, 16.0F, 0.0F));
        head.AddOrReplaceChild("hat", CubeListBuilder.Create().TexOffs(0, 30).AddBox(-4.0F, -4.0F, -3.5F, 8.0F, 8.0F, 7.0F, new CubeDeformation(0.3F)),
            PartPose.Offset(0.0F, -4.0F, 0.0F));
        head.AddOrReplaceChild("hat_rim", CubeListBuilder.Create().TexOffs(0, 45).AddBox(-7.0F, -0.5F, -6.0F, 14.0F, 1.0F, 12.0F), PartPose.Offset(0.0F, -4.5F, 0.0F));
        head.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(23, 0).AddBox(-1.0F, 0.0F, -0.5F, 2.0F, 2.0F, 1.0F), PartPose.Offset(0.0F, -2.0F, -4.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 15).AddBox(-2.0F, -2.75F, -1.5F, 4.0F, 5.0F, 3.0F), PartPose.Offset(0.0F, 18.75F, 0.0F));
        root.AddOrReplaceChild("bb_main", CubeListBuilder.Create().TexOffs(16, 21).AddBox(-2.5F, -8.0F, -1.5F, 4.0F, 6.0F, 3.0F, new CubeDeformation(0.2F)),
            PartPose.Offset(0.5F, 24.0F, 0.0F));
        return mesh;
    }
}
