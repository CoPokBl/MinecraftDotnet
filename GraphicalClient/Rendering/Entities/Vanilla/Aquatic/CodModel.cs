namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class CodModel : EntityModel<LivingEntityRenderState> {
    private readonly ModelPart _tailFin;

    public CodModel(ModelPart root) : base(root) {
        _tailFin = root.GetChild("tail_fin");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, -2.0F, 0.0F, 2.0F, 4.0F, 7.0F), PartPose.Offset(0.0F, 22.0F, 0.0F));
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(11, 0).AddBox(-1.0F, -2.0F, -3.0F, 2.0F, 4.0F, 3.0F), PartPose.Offset(0.0F, 22.0F, 0.0F));
        root.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, -2.0F, -1.0F, 2.0F, 3.0F, 1.0F), PartPose.Offset(0.0F, 22.0F, -3.0F));
        root.AddOrReplaceChild("right_fin", CubeListBuilder.Create().TexOffs(22, 1).AddBox(-2.0F, 0.0F, -1.0F, 2.0F, 0.0F, 2.0F),
            PartPose.OffsetAndRotation(-1.0F, 23.0F, 0.0F, 0.0F, 0.0F, (float)(-Math.PI / 4)));
        root.AddOrReplaceChild("left_fin", CubeListBuilder.Create().TexOffs(22, 4).AddBox(0.0F, 0.0F, -1.0F, 2.0F, 0.0F, 2.0F),
            PartPose.OffsetAndRotation(1.0F, 23.0F, 0.0F, 0.0F, 0.0F, (float)(Math.PI / 4)));
        root.AddOrReplaceChild("tail_fin", CubeListBuilder.Create().TexOffs(22, 3).AddBox(0.0F, -2.0F, 0.0F, 0.0F, 4.0F, 4.0F), PartPose.Offset(0.0F, 22.0F, 7.0F));
        root.AddOrReplaceChild("top_fin", CubeListBuilder.Create().TexOffs(20, -6).AddBox(0.0F, -1.0F, -1.0F, 0.0F, 1.0F, 6.0F), PartPose.Offset(0.0F, 20.0F, 0.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }

    public override void SetupAnim(LivingEntityRenderState state) {
        base.SetupAnim(state);
        float amplitudeMultiplier = state.IsInWater ? 1.0F : 1.5F;
        _tailFin.YRot = -amplitudeMultiplier * 0.45F * Mth.Sin(0.6F * state.AgeInTicks);
    }
}
