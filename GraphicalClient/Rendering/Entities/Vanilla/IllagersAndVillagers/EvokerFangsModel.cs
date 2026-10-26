namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class EvokerFangsModel : EntityModel<EvokerFangsRenderState> {
    private readonly ModelPart _base, _upperJaw, _lowerJaw;

    public EvokerFangsModel(ModelPart root) : base(root) {
        _base = root.GetChild("base");
        _upperJaw = _base.GetChild("upper_jaw");
        _lowerJaw = _base.GetChild("lower_jaw");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition @base = root.AddOrReplaceChild("base", CubeListBuilder.Create().TexOffs(0, 0).AddBox(0.0F, 0.0F, 0.0F, 10.0F, 12.0F, 10.0F),
            PartPose.Offset(-5.0F, 24.0F, -5.0F));
        CubeListBuilder jaw = CubeListBuilder.Create().TexOffs(40, 0).AddBox(0.0F, 0.0F, 0.0F, 4.0F, 14.0F, 8.0F);
        @base.AddOrReplaceChild("upper_jaw", jaw, PartPose.OffsetAndRotation(6.5F, 0.0F, 1.0F, 0.0F, 0.0F, 2.042035F));
        @base.AddOrReplaceChild("lower_jaw", jaw, PartPose.OffsetAndRotation(3.5F, 0.0F, 9.0F, 0.0F, MathF.PI, 4.2411504F));
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(EvokerFangsRenderState state) {
        base.SetupAnim(state);
        float biteProgress = state.BiteProgress;
        float biteAmount = Math.Min(biteProgress * 2.0F, 1.0F);
        biteAmount = 1.0F - biteAmount * biteAmount * biteAmount;
        _upperJaw.ZRot = MathF.PI - biteAmount * 0.35F * MathF.PI;
        _lowerJaw.ZRot = MathF.PI + biteAmount * 0.35F * MathF.PI;
        _base.Y = _base.Y - (biteProgress + Mth.Sin(biteProgress * 2.7F)) * 7.2F;
        float preScale = 1.0F;
        if (biteProgress > 0.9F) {
            preScale *= (1.0F - biteProgress) / 0.1F;
        }

        Root.Y = 24.0F - 20.0F * preScale;
        Root.XScale = preScale;
        Root.YScale = preScale;
        Root.ZScale = preScale;
    }
}
