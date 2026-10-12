namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class HappyGhastHarnessModel : EntityModel<HappyGhastRenderState> {
    private const float GogglesYOffset = 14.0F;
    private readonly ModelPart _goggles;

    public HappyGhastHarnessModel(ModelPart root) : base(root) {
        _goggles = root.GetChild("goggles");
    }

    public static LayerDefinition CreateHarnessLayer(bool baby) {
        MeshDefinition meshdefinition = new();
        PartDefinition root = meshdefinition.Root;
        root.AddOrReplaceChild("harness", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-8.0F, -16.0F, -8.0F, 16.0F, 16.0F, 16.0F), PartPose.Offset(0.0F, 24.0F, 0.0F));
        root.AddOrReplaceChild("goggles", CubeListBuilder.Create().TexOffs(0, 32).AddBox(-8.0F, -2.5F, -2.5F, 16.0F, 5.0F, 5.0F, new CubeDeformation(0.15F)),
            PartPose.Offset(0.0F, 14.0F, -5.5F));
        return LayerDefinition.Create(meshdefinition, 64, 64)
            .Apply(MeshTransformers.Scaling(4.0F))
            .Apply(baby ? HappyGhastModel.BabyTransformer : MeshTransformers.Identity);
    }

    public override void SetupAnim(HappyGhastRenderState state) {
        base.SetupAnim(state);
        if (state.IsRidden) {
            _goggles.XRot = 0.0F;
            _goggles.Y = GogglesYOffset;
        }
        else {
            _goggles.XRot = -0.7854F;
            _goggles.Y = 9.0F;
        }
    }
}
