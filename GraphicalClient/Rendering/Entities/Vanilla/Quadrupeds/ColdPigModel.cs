namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class ColdPigModel(ModelPart root) : PigModel(root) {
    public new static LayerDefinition CreateBodyLayer(CubeDeformation g) {
        MeshDefinition basePigModel = CreateBasePigModel(g);
        PartDefinition root = basePigModel.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(28, 8).AddBox(-5.0F, -10.0F, -7.0F, 10.0F, 16.0F, 8.0F)
            .TexOffs(28, 32).AddBox(-5.0F, -10.0F, -7.0F, 10.0F, 16.0F, 8.0F, new CubeDeformation(0.5F)),
            PartPose.OffsetAndRotation(0.0F, 11.0F, 2.0F, MathF.PI / 2, 0.0F, 0.0F));
        return LayerDefinition.Create(basePigModel, 64, 64);
    }
}
