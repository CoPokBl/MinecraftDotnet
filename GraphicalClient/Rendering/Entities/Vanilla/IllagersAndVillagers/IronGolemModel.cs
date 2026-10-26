namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class IronGolemModel : EntityModel<IronGolemRenderState> {
    private readonly ModelPart _head, _rightArm, _leftArm, _rightLeg, _leftLeg;

    public IronGolemModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _rightArm = root.GetChild("right_arm");
        _leftArm = root.GetChild("left_arm");
        _rightLeg = root.GetChild("right_leg");
        _leftLeg = root.GetChild("left_leg");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-4.0F, -12.0F, -5.5F, 8.0F, 10.0F, 8.0F)
                .TexOffs(24, 0).AddBox(-1.0F, -5.0F, -7.5F, 2.0F, 4.0F, 2.0F),
            PartPose.Offset(0.0F, -7.0F, -2.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 40).AddBox(-9.0F, -2.0F, -6.0F, 18.0F, 12.0F, 11.0F)
                .TexOffs(0, 70).AddBox(-4.5F, 10.0F, -3.0F, 9.0F, 5.0F, 6.0F, new CubeDeformation(0.5F)),
            PartPose.Offset(0.0F, -7.0F, 0.0F));
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(60, 21).AddBox(-13.0F, -2.5F, -3.0F, 4.0F, 30.0F, 6.0F), PartPose.Offset(0.0F, -7.0F, 0.0F));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(60, 58).AddBox(9.0F, -2.5F, -3.0F, 4.0F, 30.0F, 6.0F), PartPose.Offset(0.0F, -7.0F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(37, 0).AddBox(-3.5F, -3.0F, -3.0F, 6.0F, 16.0F, 5.0F), PartPose.Offset(-4.0F, 11.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(60, 0).Mirror().AddBox(-3.5F, -3.0F, -3.0F, 6.0F, 16.0F, 5.0F),
            PartPose.Offset(5.0F, 11.0F, 0.0F));
        return LayerDefinition.Create(mesh, 128, 128);
    }

    public override void SetupAnim(IronGolemRenderState state) {
        base.SetupAnim(state);
        float attackTick = state.AttackTicksRemaining;
        float animationSpeed = state.WalkAnimationSpeed;
        float animationPos = state.WalkAnimationPos;
        if (attackTick > 0.0F) {
            _rightArm.XRot = -2.0F + 1.5F * Mth.TriangleWave(attackTick, 10.0F);
            _leftArm.XRot = -2.0F + 1.5F * Mth.TriangleWave(attackTick, 10.0F);
        }
        else {
            int offerFlowerTick = state.OfferFlowerTick;
            if (offerFlowerTick > 0) {
                _rightArm.XRot = -0.8F + 0.025F * Mth.TriangleWave(offerFlowerTick, 70.0F);
                _leftArm.XRot = 0.0F;
            }
            else {
                _rightArm.XRot = (-0.2F + 1.5F * Mth.TriangleWave(animationPos, 13.0F)) * animationSpeed;
                _leftArm.XRot = (-0.2F - 1.5F * Mth.TriangleWave(animationPos, 13.0F)) * animationSpeed;
            }
        }

        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        _rightLeg.XRot = -1.5F * Mth.TriangleWave(animationPos, 13.0F) * animationSpeed;
        _leftLeg.XRot = 1.5F * Mth.TriangleWave(animationPos, 13.0F) * animationSpeed;
        _rightLeg.YRot = 0.0F;
        _leftLeg.YRot = 0.0F;
    }

    public ModelPart FlowerHoldingArm => _rightArm;
}
