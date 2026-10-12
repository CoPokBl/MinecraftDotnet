namespace GraphicalClient.Rendering.Entities.Vanilla;

public class DolphinModel : EntityModel<DolphinRenderState> {
    public static readonly MeshTransformer BabyTransformer = MeshTransformers.Scaling(0.5F);
    private readonly ModelPart _body, _tail, _tailFin;

    public DolphinModel(ModelPart root) : base(root) {
        _body = root.GetChild("body");
        _tail = _body.GetChild("tail");
        _tailFin = _tail.GetChild("tail_fin");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(22, 0).AddBox(-4.0F, -7.0F, 0.0F, 8.0F, 7.0F, 13.0F),
            PartPose.Offset(0.0F, 22.0F, -5.0F));
        body.AddOrReplaceChild("back_fin", CubeListBuilder.Create().TexOffs(51, 0).AddBox(-0.5F, 0.0F, 8.0F, 1.0F, 4.0F, 5.0F),
            PartPose.Rotation((float)(Math.PI / 3), 0.0F, 0.0F));
        body.AddOrReplaceChild("left_fin", CubeListBuilder.Create().TexOffs(48, 20).Mirror().AddBox(-0.5F, -4.0F, 0.0F, 1.0F, 4.0F, 7.0F),
            PartPose.OffsetAndRotation(2.0F, -2.0F, 4.0F, (float)(Math.PI / 3), 0.0F, (float)(Math.PI * 2.0 / 3.0)));
        body.AddOrReplaceChild("right_fin", CubeListBuilder.Create().TexOffs(48, 20).AddBox(-0.5F, -4.0F, 0.0F, 1.0F, 4.0F, 7.0F),
            PartPose.OffsetAndRotation(-2.0F, -2.0F, 4.0F, (float)(Math.PI / 3), 0.0F, (float)(-Math.PI * 2.0 / 3.0)));
        PartDefinition tail = body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(0, 19).AddBox(-2.0F, -2.5F, 0.0F, 4.0F, 5.0F, 11.0F),
            PartPose.OffsetAndRotation(0.0F, -2.5F, 11.0F, -0.10471976F, 0.0F, 0.0F));
        tail.AddOrReplaceChild("tail_fin", CubeListBuilder.Create().TexOffs(19, 20).AddBox(-5.0F, -0.5F, 0.0F, 10.0F, 1.0F, 6.0F), PartPose.Offset(0.0F, 0.0F, 9.0F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -3.0F, -3.0F, 8.0F, 7.0F, 6.0F),
            PartPose.Offset(0.0F, -4.0F, -3.0F));
        head.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(0, 13).AddBox(-1.0F, 2.0F, -7.0F, 2.0F, 2.0F, 4.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(DolphinRenderState state) {
        base.SetupAnim(state);
        _body.XRot = state.XRot * (float)(Math.PI / 180.0);
        _body.YRot = state.YRot * (float)(Math.PI / 180.0);
        if (state.IsMoving) {
            _body.XRot = _body.XRot + (-0.05F - 0.05F * Mth.Cos(state.AgeInTicks * 0.3F));
            _tail.XRot = -0.1F * Mth.Cos(state.AgeInTicks * 0.3F);
            _tailFin.XRot = -0.2F * Mth.Cos(state.AgeInTicks * 0.3F);
        }
    }
}
