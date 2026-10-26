namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>Only <c>ColdCowModel</c>'s layer: the subclass adds nothing to <see cref="CowModel{S}"/>.</summary>
public static class ColdCowModel {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CowModel.CreateBaseCowModel();
        mesh.Root.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(20, 32).AddBox(-6.0F, -10.0F, -7.0F, 12.0F, 18.0F, 10.0F, new CubeDeformation(0.5F))
            .TexOffs(18, 4).AddBox(-6.0F, -10.0F, -7.0F, 12.0F, 18.0F, 10.0F)
            .TexOffs(52, 0).AddBox(-2.0F, 2.0F, -8.0F, 4.0F, 6.0F, 1.0F), PartPose.OffsetAndRotation(0.0F, 5.0F, 2.0F, MathF.PI / 2, 0.0F, 0.0F));
        PartDefinition head = mesh.Root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-4.0F, -4.0F, -6.0F, 8.0F, 8.0F, 6.0F)
            .TexOffs(9, 33).AddBox(-3.0F, 1.0F, -7.0F, 6.0F, 3.0F, 1.0F), PartPose.Offset(0.0F, 4.0F, -8.0F));
        head.AddOrReplaceChild("right_horn", CubeListBuilder.Create().TexOffs(0, 40).AddBox(-1.5F, -4.5F, -0.5F, 2.0F, 6.0F, 2.0F),
            PartPose.OffsetAndRotation(-4.5F, -2.5F, -3.5F, 1.5708F, 0.0F, 0.0F));
        head.AddOrReplaceChild("left_horn", CubeListBuilder.Create().TexOffs(0, 32).AddBox(-1.5F, -3.0F, -0.5F, 2.0F, 6.0F, 2.0F),
            PartPose.OffsetAndRotation(5.5F, -2.5F, -5.0F, 1.5708F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
