namespace GraphicalClient.Rendering.Entities.Vanilla;

public class PigModel(ModelPart root) : QuadrupedModel<PigRenderState>(root) {
    public static LayerDefinition CreateBodyLayer(CubeDeformation g) => LayerDefinition.Create(CreateBasePigModel(g), 64, 64);

    protected static MeshDefinition CreateBasePigModel(CubeDeformation g) {
        MeshDefinition mesh = CreateBodyMesh(6, true, false, g);
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-4.0F, -4.0F, -8.0F, 8.0F, 8.0F, 8.0F, g)
            .TexOffs(16, 16).AddBox(-2.0F, 0.0F, -9.0F, 4.0F, 3.0F, 1.0F, g), PartPose.Offset(0.0F, 12.0F, -6.0F));
        return mesh;
    }
}
