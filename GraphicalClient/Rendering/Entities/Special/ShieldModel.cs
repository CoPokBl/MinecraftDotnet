namespace GraphicalClient.Rendering.Entities.Special;

/// <summary><c>ShieldModel</c>, a plain <c>Model</c> in vanilla, posed by nothing.</summary>
public sealed class ShieldModel : EntityModel<EntityRenderState> {
    public ShieldModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("plate", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-6.0F, -11.0F, -2.0F, 12.0F, 22.0F, 1.0F), PartPose.Zero);
        root.AddOrReplaceChild("handle", CubeListBuilder.Create().TexOffs(26, 0).AddBox(-1.0F, -3.0F, -1.0F, 2.0F, 6.0F, 6.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
