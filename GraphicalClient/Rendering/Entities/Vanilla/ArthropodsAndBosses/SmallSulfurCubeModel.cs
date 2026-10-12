namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SmallSulfurCubeModel : SulfurCubeModel {
    public SmallSulfurCubeModel(ModelPart root) : base(root) { }

    public new static LayerDefinition CreateOuterBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("cube", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-5.0F, -5.0F, -5.0F, 10.0F, 10.0F, 10.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public new static LayerDefinition CreateInnerBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("cube", CubeListBuilder.Create().TexOffs(0, 20).AddBox(-4.0F, -4.0F, -4.0F, 8.0F, 8.0F, 8.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
