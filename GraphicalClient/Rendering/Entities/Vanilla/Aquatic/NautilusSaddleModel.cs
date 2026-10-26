namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class NautilusSaddleModel : NautilusModel {
    public NautilusSaddleModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateSaddleLayer() {
        MeshDefinition meshdefinition = CreateBodyMesh();
        PartDefinition partdefinition = meshdefinition.Root;
        PartDefinition nautilus = partdefinition.AddOrReplaceChild("root", CubeListBuilder.Create(), PartPose.Offset(0.0F, 29.0F, -6.0F));
        nautilus.AddOrReplaceChild("shell", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-7.0F, -10.0F, -7.0F, 14.0F, 10.0F, 16.0F, new CubeDeformation(0.2F)),
            PartPose.Offset(0.0F, -13.0F, 5.0F));
        return LayerDefinition.Create(meshdefinition, 128, 128);
    }
}
