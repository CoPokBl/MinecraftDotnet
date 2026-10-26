namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SalmonModel : EntityModel<SalmonRenderState> {
    public static readonly MeshTransformer SmallTransformer = MeshTransformers.Scaling(0.5F);
    public static readonly MeshTransformer LargeTransformer = MeshTransformers.Scaling(1.5F);
    private readonly ModelPart _bodyBack;

    public SalmonModel(ModelPart root) : base(root) {
        _bodyBack = root.GetChild("body_back");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition bodyFront = root.AddOrReplaceChild("body_front", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.5F, -2.5F, 0.0F, 3.0F, 5.0F, 8.0F),
            PartPose.Offset(0.0F, 20.0F, -7.2F));
        PartDefinition bodyBack = root.AddOrReplaceChild("body_back", CubeListBuilder.Create().TexOffs(0, 13).AddBox(-1.5F, -2.5F, 0.0F, 3.0F, 5.0F, 8.0F),
            PartPose.Offset(0.0F, 20.0F, 0.8000002F));
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(22, 0).AddBox(-1.0F, -2.0F, -3.0F, 2.0F, 4.0F, 3.0F), PartPose.Offset(0.0F, 20.0F, -7.2F));
        bodyBack.AddOrReplaceChild("back_fin", CubeListBuilder.Create().TexOffs(20, 10).AddBox(0.0F, -2.5F, 0.0F, 0.0F, 5.0F, 6.0F), PartPose.Offset(0.0F, 0.0F, 8.0F));
        bodyFront.AddOrReplaceChild("top_front_fin", CubeListBuilder.Create().TexOffs(2, 1).AddBox(0.0F, 0.0F, 0.0F, 0.0F, 2.0F, 3.0F), PartPose.Offset(0.0F, -4.5F, 5.0F));
        bodyBack.AddOrReplaceChild("top_back_fin", CubeListBuilder.Create().TexOffs(0, 2).AddBox(0.0F, 0.0F, 0.0F, 0.0F, 2.0F, 4.0F), PartPose.Offset(0.0F, -4.5F, -1.0F));
        root.AddOrReplaceChild("right_fin", CubeListBuilder.Create().TexOffs(-4, 0).AddBox(-2.0F, 0.0F, 0.0F, 2.0F, 0.0F, 2.0F),
            PartPose.OffsetAndRotation(-1.5F, 21.5F, -7.2F, 0.0F, 0.0F, (float)(-Math.PI / 4)));
        root.AddOrReplaceChild("left_fin", CubeListBuilder.Create().TexOffs(0, 0).AddBox(0.0F, 0.0F, 0.0F, 2.0F, 0.0F, 2.0F),
            PartPose.OffsetAndRotation(1.5F, 21.5F, -7.2F, 0.0F, 0.0F, (float)(Math.PI / 4)));
        return LayerDefinition.Create(mesh, 32, 32);
    }

    public override void SetupAnim(SalmonRenderState state) {
        base.SetupAnim(state);
        float amplitudeMultiplier = 1.0F;
        float angleMultiplier = 1.0F;
        if (!state.IsInWater) {
            amplitudeMultiplier = 1.3F;
            angleMultiplier = 1.7F;
        }
        _bodyBack.YRot = -amplitudeMultiplier * 0.25F * Mth.Sin(angleMultiplier * 0.6F * state.AgeInTicks);
    }
}
