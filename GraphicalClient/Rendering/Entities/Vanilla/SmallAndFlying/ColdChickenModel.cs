namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class ColdChickenModel : AdultChickenModel {
    public ColdChickenModel(ModelPart root) : base(root) { }

    public new static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateBaseChickenModel();
        mesh.Root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 9).AddBox(-3.0F, -4.0F, -3.0F, 6.0F, 8.0F, 6.0F)
                .TexOffs(38, 9).AddBox(0.0F, 3.0F, -1.0F, 0.0F, 3.0F, 5.0F),
            PartPose.OffsetAndRotation(0.0F, 16.0F, 0.0F, MathF.PI / 2, 0.0F, 0.0F));
        mesh.Root.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-2.0F, -6.0F, -2.0F, 4.0F, 6.0F, 3.0F)
                .TexOffs(44, 0).AddBox(-3.0F, -7.0F, -2.015F, 6.0F, 3.0F, 4.0F),
            PartPose.Offset(0.0F, 15.0F, -4.0F));
        return LayerDefinition.Create(mesh, 64, 32);
    }
}
