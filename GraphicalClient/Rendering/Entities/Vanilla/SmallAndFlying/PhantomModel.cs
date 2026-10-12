namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class PhantomModel : EntityModel<PhantomRenderState> {
    private readonly ModelPart _leftWingBase, _leftWingTip, _rightWingBase, _rightWingTip, _tailBase, _tailTip;

    public PhantomModel(ModelPart root) : base(root) {
        ModelPart body = root.GetChild("body");
        _tailBase = body.GetChild("tail_base");
        _tailTip = _tailBase.GetChild("tail_tip");
        _leftWingBase = body.GetChild("left_wing_base");
        _leftWingTip = _leftWingBase.GetChild("left_wing_tip");
        _rightWingBase = body.GetChild("right_wing_base");
        _rightWingTip = _rightWingBase.GetChild("right_wing_tip");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 8).AddBox(-3.0F, -2.0F, -8.0F, 5.0F, 3.0F, 9.0F),
            PartPose.Rotation(-0.1F, 0.0F, 0.0F));
        PartDefinition tailBase = body.AddOrReplaceChild("tail_base", CubeListBuilder.Create().TexOffs(3, 20).AddBox(-2.0F, 0.0F, 0.0F, 3.0F, 2.0F, 6.0F),
            PartPose.Offset(0.0F, -2.0F, 1.0F));
        tailBase.AddOrReplaceChild("tail_tip", CubeListBuilder.Create().TexOffs(4, 29).AddBox(-1.0F, 0.0F, 0.0F, 1.0F, 1.0F, 6.0F), PartPose.Offset(0.0F, 0.5F, 6.0F));
        PartDefinition leftWingBase = body.AddOrReplaceChild("left_wing_base", CubeListBuilder.Create().TexOffs(23, 12).AddBox(0.0F, 0.0F, 0.0F, 6.0F, 2.0F, 9.0F),
            PartPose.OffsetAndRotation(2.0F, -2.0F, -8.0F, 0.0F, 0.0F, 0.1F));
        leftWingBase.AddOrReplaceChild("left_wing_tip", CubeListBuilder.Create().TexOffs(16, 24).AddBox(0.0F, 0.0F, 0.0F, 13.0F, 1.0F, 9.0F),
            PartPose.OffsetAndRotation(6.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.1F));
        PartDefinition rightWingBase = body.AddOrReplaceChild("right_wing_base", CubeListBuilder.Create().TexOffs(23, 12).Mirror().AddBox(-6.0F, 0.0F, 0.0F, 6.0F, 2.0F, 9.0F),
            PartPose.OffsetAndRotation(-3.0F, -2.0F, -8.0F, 0.0F, 0.0F, -0.1F));
        rightWingBase.AddOrReplaceChild("right_wing_tip", CubeListBuilder.Create().TexOffs(16, 24).Mirror().AddBox(-13.0F, 0.0F, 0.0F, 13.0F, 1.0F, 9.0F),
            PartPose.OffsetAndRotation(-6.0F, 0.0F, 0.0F, 0.0F, 0.0F, -0.1F));
        body.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -2.0F, -5.0F, 7.0F, 3.0F, 5.0F),
            PartPose.OffsetAndRotation(0.0F, 1.0F, -7.0F, 0.2F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(PhantomRenderState state) {
        base.SetupAnim(state);
        float anim = state.FlapTime * 7.448451F * (MathF.PI / 180.0F);
        _leftWingBase.ZRot = Mth.Cos(anim) * 16.0F * (MathF.PI / 180.0F);
        _leftWingTip.ZRot = Mth.Cos(anim) * 16.0F * (MathF.PI / 180.0F);
        _rightWingBase.ZRot = -_leftWingBase.ZRot;
        _rightWingTip.ZRot = -_leftWingTip.ZRot;
        _tailBase.XRot = -(5.0F + Mth.Cos(anim * 2.0F) * 5.0F) * (MathF.PI / 180.0F);
        _tailTip.XRot = -(5.0F + Mth.Cos(anim * 2.0F) * 5.0F) * (MathF.PI / 180.0F);
    }
}
