namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>Only <c>WarmCowModel</c>'s layer: the subclass adds nothing to <see cref="CowModel{S}"/>.</summary>
public static class WarmCowModel {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CowModel.CreateBaseCowModel();
        mesh.Root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-4.0F, -4.0F, -6.0F, 8.0F, 8.0F, 6.0F)
            .TexOffs(1, 33).AddBox(-3.0F, 1.0F, -7.0F, 6.0F, 3.0F, 1.0F)
            .TexOffs(27, 0).AddBox(-8.0F, -3.0F, -5.0F, 4.0F, 2.0F, 2.0F)
            .TexOffs(39, 0).AddBox(-8.0F, -5.0F, -5.0F, 2.0F, 2.0F, 2.0F)
            .TexOffs(27, 0).Mirror().AddBox(4.0F, -3.0F, -5.0F, 4.0F, 2.0F, 2.0F).Mirror(false)
            .TexOffs(39, 0).Mirror().AddBox(6.0F, -5.0F, -5.0F, 2.0F, 2.0F, 2.0F).Mirror(false), PartPose.Offset(0.0F, 4.0F, -8.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
