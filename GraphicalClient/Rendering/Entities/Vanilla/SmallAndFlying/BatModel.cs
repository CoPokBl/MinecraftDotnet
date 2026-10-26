namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BatModel : EntityModel<BatRenderState> {
    private readonly ModelPart _head, _body, _rightWing, _leftWing, _rightWingTip, _leftWingTip, _feet;
    private readonly KeyframeAnimation _flyingAnimation, _restingAnimation;

    public BatModel(ModelPart root) : base(root) {
        _body = root.GetChild("body");
        _head = root.GetChild("head");
        _rightWing = _body.GetChild("right_wing");
        _rightWingTip = _rightWing.GetChild("right_wing_tip");
        _leftWing = _body.GetChild("left_wing");
        _leftWingTip = _leftWing.GetChild("left_wing_tip");
        _feet = _body.GetChild("feet");
        _flyingAnimation = BatAnimation.BatFlying.Bake(root);
        _restingAnimation = BatAnimation.BatResting.Bake(root);
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition meshdefinition = new();
        PartDefinition partdefinition = meshdefinition.Root;
        PartDefinition body = partdefinition.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.5F, 0.0F, -1.0F, 3.0F, 5.0F, 2.0F),
            PartPose.Offset(0.0F, 17.0F, 0.0F));
        PartDefinition head = partdefinition.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 7).AddBox(-2.0F, -3.0F, -1.0F, 4.0F, 3.0F, 2.0F),
            PartPose.Offset(0.0F, 17.0F, 0.0F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(1, 15).AddBox(-2.5F, -4.0F, 0.0F, 3.0F, 5.0F, 0.0F), PartPose.Offset(-1.5F, -2.0F, 0.0F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(8, 15).AddBox(-0.1F, -3.0F, 0.0F, 3.0F, 5.0F, 0.0F), PartPose.Offset(1.1F, -3.0F, 0.0F));
        PartDefinition rightWing = body.AddOrReplaceChild("right_wing", CubeListBuilder.Create().TexOffs(12, 0).AddBox(-2.0F, -2.0F, 0.0F, 2.0F, 7.0F, 0.0F),
            PartPose.Offset(-1.5F, 0.0F, 0.0F));
        rightWing.AddOrReplaceChild("right_wing_tip", CubeListBuilder.Create().TexOffs(16, 0).AddBox(-6.0F, -2.0F, 0.0F, 6.0F, 8.0F, 0.0F),
            PartPose.Offset(-2.0F, 0.0F, 0.0F));
        PartDefinition leftWing = body.AddOrReplaceChild("left_wing", CubeListBuilder.Create().TexOffs(12, 7).AddBox(0.0F, -2.0F, 0.0F, 2.0F, 7.0F, 0.0F),
            PartPose.Offset(1.5F, 0.0F, 0.0F));
        leftWing.AddOrReplaceChild("left_wing_tip", CubeListBuilder.Create().TexOffs(16, 8).AddBox(0.0F, -2.0F, 0.0F, 6.0F, 8.0F, 0.0F),
            PartPose.Offset(2.0F, 0.0F, 0.0F));
        body.AddOrReplaceChild("feet", CubeListBuilder.Create().TexOffs(16, 16).AddBox(-1.5F, 0.0F, 0.0F, 3.0F, 2.0F, 0.0F), PartPose.Offset(0.0F, 5.0F, 0.0F));
        return LayerDefinition.Create(meshdefinition, 32, 32);
    }

    public override void SetupAnim(BatRenderState state) {
        base.SetupAnim(state);
        if (state.IsResting) {
            ApplyHeadRotation(state.YRot);
        }
        _flyingAnimation.Apply(state.FlyAnimationState, state.AgeInTicks);
        _restingAnimation.Apply(state.RestAnimationState, state.AgeInTicks);
    }

    private void ApplyHeadRotation(float yRot) {
        _head.YRot = yRot * (MathF.PI / 180.0F);
    }
}
