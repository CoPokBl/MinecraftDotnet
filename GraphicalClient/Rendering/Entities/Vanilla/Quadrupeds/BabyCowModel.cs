namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>Only <c>BabyCowModel</c>'s layer: the subclass adds nothing to <see cref="CowModel{S}"/>.</summary>
public static class BabyCowModel {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 18).AddBox(-3.0F, -4.569F, -4.8333F, 6.0F, 6.0F, 5.0F)
            .TexOffs(8, 29).AddBox(3.0F, -5.569F, -3.8333F, 1.0F, 2.0F, 1.0F)
            .TexOffs(4, 29).Mirror().AddBox(-4.0F, -5.569F, -3.8333F, 1.0F, 2.0F, 1.0F).Mirror(false)
            .TexOffs(12, 29).AddBox(-2.0F, -1.569F, -5.8333F, 4.0F, 3.0F, 1.0F), PartPose.Offset(0.0F, 13.569F, -5.1667F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-7.0F, -7.0F, -1.0F, 8.0F, 6.0F, 12.0F), PartPose.Offset(3.0F, 19.0F, -5.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(22, 18).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 6.0F, 3.0F),
            PartPose.Offset(-2.5F, 18.0F, -3.5F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(34, 18).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 6.0F, 3.0F),
            PartPose.Offset(2.5F, 18.0F, -3.5F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(22, 27).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 6.0F, 3.0F),
            PartPose.Offset(-2.5F, 18.0F, 3.5F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(34, 27).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 6.0F, 3.0F),
            PartPose.Offset(2.5F, 18.0F, 3.5F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
