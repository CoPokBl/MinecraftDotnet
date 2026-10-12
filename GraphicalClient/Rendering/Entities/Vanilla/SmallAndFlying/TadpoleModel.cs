namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class TadpoleModel : EntityModel<LivingEntityRenderState> {
    private readonly ModelPart _tail;

    public TadpoleModel(ModelPart root) : base(root) {
        _tail = root.GetChild("tail");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.5F, -1.0F, 0.0F, 3.0F, 2.0F, 3.0F), PartPose.Offset(0.0F, 22.0F, -3.0F));
        root.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(0, 0).AddBox(0.0F, -1.0F, 0.0F, 0.0F, 2.0F, 7.0F), PartPose.Offset(0.0F, 22.0F, 0.0F));
        return LayerDefinition.Create(mesh, 16, 16);
    }

    public override void SetupAnim(LivingEntityRenderState state) {
        base.SetupAnim(state);
        float amplitudeMultiplier = state.IsInWater ? 1.0F : 1.5F;
        _tail.YRot = -amplitudeMultiplier * 0.25F * Mth.Sin(0.3F * state.AgeInTicks);
    }
}
