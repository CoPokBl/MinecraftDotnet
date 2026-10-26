namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>SulfurCubeModel</c>, whose render type is <c>entityTranslucent</c>.</summary>
public class SulfurCubeModel : EntityModel<SulfurCubeRenderState> {
    public SulfurCubeModel(ModelPart root) : base(root) { }

    public override bool Translucent => true;

    public static LayerDefinition CreateOuterBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("cube", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-9.0F, -9.0F, -9.0F, 18.0F, 18.0F, 18.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 128, 128);
    }

    public static LayerDefinition CreateInnerBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("cube", CubeListBuilder.Create().TexOffs(0, 36).AddBox(-8.0F, -8.0F, -8.0F, 16.0F, 16.0F, 16.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 128, 128);
    }
}
