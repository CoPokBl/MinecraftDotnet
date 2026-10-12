namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SnowGolemModel : EntityModel<SnowGolemRenderState> {
    private readonly ModelPart _upperBody, _head, _leftArm, _rightArm;

    public SnowGolemModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _leftArm = root.GetChild("left_arm");
        _rightArm = root.GetChild("right_arm");
        _upperBody = root.GetChild("upper_body");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        CubeDeformation deformation = new(-0.5F);
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, deformation),
            PartPose.Offset(0.0F, 4.0F, 0.0F));
        CubeListBuilder arm = CubeListBuilder.Create().TexOffs(32, 0).AddBox(-1.0F, 0.0F, -1.0F, 12.0F, 2.0F, 2.0F, deformation);
        root.AddOrReplaceChild("left_arm", arm, PartPose.OffsetAndRotation(5.0F, 6.0F, 1.0F, 0.0F, 0.0F, 1.0F));
        root.AddOrReplaceChild("right_arm", arm, PartPose.OffsetAndRotation(-5.0F, 6.0F, -1.0F, 0.0F, MathF.PI, -1.0F));
        root.AddOrReplaceChild("upper_body", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-5.0F, -10.0F, -5.0F, 10.0F, 10.0F, 10.0F, deformation),
            PartPose.Offset(0.0F, 13.0F, 0.0F));
        root.AddOrReplaceChild("lower_body", CubeListBuilder.Create().TexOffs(0, 36).AddBox(-6.0F, -12.0F, -6.0F, 12.0F, 12.0F, 12.0F, deformation),
            PartPose.Offset(0.0F, 24.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(SnowGolemRenderState state) {
        base.SetupAnim(state);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        _upperBody.YRot = state.YRot * (MathF.PI / 180.0F) * 0.25F;
        float sin = Mth.Sin(_upperBody.YRot);
        float cos = Mth.Cos(_upperBody.YRot);
        _leftArm.YRot = _upperBody.YRot;
        _rightArm.YRot = _upperBody.YRot + MathF.PI;
        _leftArm.X = cos * 5.0F;
        _leftArm.Z = -sin * 5.0F;
        _rightArm.X = -cos * 5.0F;
        _rightArm.Z = sin * 5.0F;
    }

    public ModelPart Head => _head;
}
