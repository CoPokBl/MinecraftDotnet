namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>NautilusArmorModel</c>: the body mesh with its root and shell replaced, so the body keeps swimming under the armour.</summary>
public sealed class NautilusArmorModel : NautilusModel {
    public NautilusArmorModel(ModelPart root) : base(root) { }

    public static new LayerDefinition CreateBodyLayer() {
        MeshDefinition meshdefinition = CreateBodyMesh();
        PartDefinition partdefinition = meshdefinition.Root;
        PartDefinition nautilus = partdefinition.AddOrReplaceChild("root", CubeListBuilder.Create(), PartPose.Offset(0.0F, 29.0F, -6.0F));
        nautilus.AddOrReplaceChild("shell", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-7.0F, -10.0F, -7.0F, 14.0F, 10.0F, 16.0F, new CubeDeformation(0.01F))
                .TexOffs(0, 26).AddBox(-7.0F, 0.0F, -7.0F, 14.0F, 8.0F, 20.0F, new CubeDeformation(0.01F))
                .TexOffs(48, 26).AddBox(-7.0F, 0.0F, 6.0F, 14.0F, 8.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -13.0F, 5.0F));
        return LayerDefinition.Create(meshdefinition, 128, 128);
    }
}
