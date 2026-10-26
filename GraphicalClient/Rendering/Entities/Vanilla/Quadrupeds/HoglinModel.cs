namespace GraphicalClient.Rendering.Entities.Vanilla;

public class HoglinModel : EntityModel<HoglinRenderState> {
    private const float DefaultHeadXRot = 0.87266463F;
    private const float AttackHeadXRotEnd = -MathF.PI / 9;

    protected readonly ModelPart Head;
    private readonly ModelPart _rightEar;
    private readonly ModelPart _leftEar;
    private readonly ModelPart _rightFrontLeg;
    private readonly ModelPart _leftFrontLeg;
    private readonly ModelPart _rightHindLeg;
    private readonly ModelPart _leftHindLeg;

    public HoglinModel(ModelPart root) : base(root) {
        Head = root.GetChild("head");
        _rightEar = Head.GetChild("right_ear");
        _leftEar = Head.GetChild("left_ear");
        _rightFrontLeg = root.GetChild("right_front_leg");
        _leftFrontLeg = root.GetChild("left_front_leg");
        _rightHindLeg = root.GetChild("right_hind_leg");
        _leftHindLeg = root.GetChild("left_hind_leg");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(1, 1).AddBox(-8.0F, -7.0F, -13.0F, 16.0F, 14.0F, 26.0F),
            PartPose.Offset(0.0F, 7.0F, 0.0F));
        body.AddOrReplaceChild("mane", CubeListBuilder.Create().TexOffs(90, 33).AddBox(0.0F, 0.0F, -9.0F, 0.0F, 10.0F, 19.0F, new CubeDeformation(0.001F)),
            PartPose.Offset(0.0F, -14.0F, -7.0F));
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(61, 1).AddBox(-7.0F, -3.0F, -19.0F, 14.0F, 6.0F, 19.0F),
            PartPose.OffsetAndRotation(0.0F, 2.0F, -12.0F, 0.87266463F, 0.0F, 0.0F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(1, 1).AddBox(-6.0F, -1.0F, -2.0F, 6.0F, 1.0F, 4.0F),
            PartPose.OffsetAndRotation(-6.0F, -2.0F, -3.0F, 0.0F, 0.0F, (float)(-Math.PI * 2.0 / 9.0)));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(1, 6).AddBox(0.0F, -1.0F, -2.0F, 6.0F, 1.0F, 4.0F),
            PartPose.OffsetAndRotation(6.0F, -2.0F, -3.0F, 0.0F, 0.0F, (float)(Math.PI * 2.0 / 9.0)));
        head.AddOrReplaceChild("right_horn", CubeListBuilder.Create().TexOffs(10, 13).AddBox(-1.0F, -11.0F, -1.0F, 2.0F, 11.0F, 2.0F),
            PartPose.Offset(-7.0F, 2.0F, -12.0F));
        head.AddOrReplaceChild("left_horn", CubeListBuilder.Create().TexOffs(1, 13).AddBox(-1.0F, -11.0F, -1.0F, 2.0F, 11.0F, 2.0F), PartPose.Offset(7.0F, 2.0F, -12.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(66, 42).AddBox(-3.0F, 0.0F, -3.0F, 6.0F, 14.0F, 6.0F),
            PartPose.Offset(-4.0F, 10.0F, -8.5F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(41, 42).AddBox(-3.0F, 0.0F, -3.0F, 6.0F, 14.0F, 6.0F),
            PartPose.Offset(4.0F, 10.0F, -8.5F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(21, 45).AddBox(-2.5F, 0.0F, -2.5F, 5.0F, 11.0F, 5.0F),
            PartPose.Offset(-5.0F, 13.0F, 10.0F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(0, 45).AddBox(-2.5F, 0.0F, -2.5F, 5.0F, 11.0F, 5.0F),
            PartPose.Offset(5.0F, 13.0F, 10.0F));
        return LayerDefinition.Create(mesh, 128, 64);
    }

    public override void SetupAnim(HoglinRenderState state) {
        base.SetupAnim(state);
        float animationSpeed = state.WalkAnimationSpeed;
        float animationPos = state.WalkAnimationPos;
        _rightEar.ZRot = (float)(-Math.PI * 2.0 / 9.0) - animationSpeed * Mth.Sin(animationPos);
        _leftEar.ZRot = (float)(Math.PI * 2.0 / 9.0) + animationSpeed * Mth.Sin(animationPos);
        Head.YRot = state.YRot * (MathF.PI / 180.0F);
        float headbuttLerpFactor = 1.0F - Math.Abs(10 - 2 * state.AttackAnimationRemainingTicks) / 10.0F;
        AnimateHeadbutt(headbuttLerpFactor);
        _rightFrontLeg.XRot = Mth.Cos(animationPos) * 1.2F * animationSpeed;
        _leftFrontLeg.XRot = Mth.Cos(animationPos + MathF.PI) * 1.2F * animationSpeed;
        _rightHindLeg.XRot = _leftFrontLeg.XRot;
        _leftHindLeg.XRot = _rightFrontLeg.XRot;
    }

    protected virtual void AnimateHeadbutt(float headbuttLerpFactor) => Head.XRot = Mth.Lerp(headbuttLerpFactor, DefaultHeadXRot, AttackHeadXRotEnd);
}
