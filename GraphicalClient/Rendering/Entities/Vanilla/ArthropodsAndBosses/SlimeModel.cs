namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SlimeModel : EntityModel<SlimeRenderState> {
    public SlimeModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateOuterBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("cube", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, 16.0F, -4.0F, 8.0F, 8.0F, 8.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public static LayerDefinition CreateInnerBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("cube", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-3.0F, 17.0F, -3.0F, 6.0F, 6.0F, 6.0F), PartPose.Zero);
        root.AddOrReplaceChild("right_eye", CubeListBuilder.Create().TexOffs(32, 0).AddBox(-3.25F, 18.0F, -3.5F, 2.0F, 2.0F, 2.0F), PartPose.Zero);
        root.AddOrReplaceChild("left_eye", CubeListBuilder.Create().TexOffs(32, 4).AddBox(1.25F, 18.0F, -3.5F, 2.0F, 2.0F, 2.0F), PartPose.Zero);
        root.AddOrReplaceChild("mouth", CubeListBuilder.Create().TexOffs(32, 8).AddBox(0.0F, 21.0F, -3.5F, 1.0F, 1.0F, 1.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 32);
    }
}
