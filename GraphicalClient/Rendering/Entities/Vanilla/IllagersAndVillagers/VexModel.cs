using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>VexModel</c>: its root is the mesh's <c>root</c> part, not the mesh root.</summary>
public sealed class VexModel : EntityModel<VexRenderState>, IArmedModel<VexRenderState> {
    private readonly ModelPart _body, _rightArm, _leftArm, _rightWing, _leftWing, _head;

    public VexModel(ModelPart root) : base(root.GetChild("root")) {
        _body = Root.GetChild("body");
        _rightArm = _body.GetChild("right_arm");
        _leftArm = _body.GetChild("left_arm");
        _rightWing = _body.GetChild("right_wing");
        _leftWing = _body.GetChild("left_wing");
        _head = Root.GetChild("head");
    }

    public override bool Translucent => true;

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition meshdefinition = new();
        PartDefinition partdefinition = meshdefinition.Root;
        PartDefinition root = partdefinition.AddOrReplaceChild("root", CubeListBuilder.Create(), PartPose.Offset(0.0F, -2.5F, 0.0F));
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.5F, -5.0F, -2.5F, 5.0F, 5.0F, 5.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 20.0F, 0.0F));
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 10).AddBox(-1.5F, 0.0F, -1.0F, 3.0F, 4.0F, 2.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 16).AddBox(-1.5F, 1.0F, -1.0F, 3.0F, 5.0F, 2.0F, new CubeDeformation(-0.2F)),
            PartPose.Offset(0.0F, 20.0F, 0.0F));
        body.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(23, 0).AddBox(-1.25F, -0.5F, -1.0F, 2.0F, 4.0F, 2.0F, new CubeDeformation(-0.1F)),
            PartPose.Offset(-1.75F, 0.25F, 0.0F));
        body.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(23, 6).AddBox(-0.75F, -0.5F, -1.0F, 2.0F, 4.0F, 2.0F, new CubeDeformation(-0.1F)),
            PartPose.Offset(1.75F, 0.25F, 0.0F));
        body.AddOrReplaceChild("left_wing", CubeListBuilder.Create().TexOffs(16, 14).Mirror().AddBox(0.0F, 0.0F, 0.0F, 0.0F, 5.0F, 8.0F, new CubeDeformation(0.0F)).Mirror(false),
            PartPose.Offset(0.5F, 1.0F, 1.0F));
        body.AddOrReplaceChild("right_wing", CubeListBuilder.Create().TexOffs(16, 14).AddBox(0.0F, 0.0F, 0.0F, 0.0F, 5.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-0.5F, 1.0F, 1.0F));
        return LayerDefinition.Create(meshdefinition, 32, 32);
    }

    public override void SetupAnim(VexRenderState state) {
        base.SetupAnim(state);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        float movingArmZBob = Mth.Cos(state.AgeInTicks * 5.5F * (MathF.PI / 180.0F)) * 0.1F;
        _rightArm.ZRot = (float)(Math.PI / 5) + movingArmZBob;
        _leftArm.ZRot = -((float)(Math.PI / 5) + movingArmZBob);
        if (state.IsCharging) {
            _body.XRot = 0.0F;
            SetArmsCharging(state.RightHandItemState != null, state.LeftHandItemState != null, movingArmZBob);
        }
        else {
            _body.XRot = (float)(Math.PI / 20);
        }

        _leftWing.YRot = 1.0995574F + Mth.Cos(state.AgeInTicks * 45.836624F * (MathF.PI / 180.0F)) * (MathF.PI / 180.0F) * 16.2F;
        _rightWing.YRot = -_leftWing.YRot;
        _leftWing.XRot = 0.47123888F;
        _leftWing.ZRot = -0.47123888F;
        _rightWing.XRot = 0.47123888F;
        _rightWing.ZRot = 0.47123888F;
    }

    private void SetArmsCharging(bool hasItemInRightHand, bool hasItemInLeftHand, float movingArmZBob) {
        if (!hasItemInRightHand && !hasItemInLeftHand) {
            _rightArm.XRot = -1.2217305F;
            _rightArm.YRot = (float)(Math.PI / 12);
            _rightArm.ZRot = -0.47123888F - movingArmZBob;
            _leftArm.XRot = -1.2217305F;
            _leftArm.YRot = (float)(-Math.PI / 12);
            _leftArm.ZRot = 0.47123888F + movingArmZBob;
        }
        else {
            if (hasItemInRightHand) {
                _rightArm.XRot = (float)(Math.PI * 7.0 / 6.0);
                _rightArm.YRot = (float)(Math.PI / 12);
                _rightArm.ZRot = -0.47123888F - movingArmZBob;
            }
            if (hasItemInLeftHand) {
                _leftArm.XRot = (float)(Math.PI * 7.0 / 6.0);
                _leftArm.YRot = (float)(-Math.PI / 12);
                _leftArm.ZRot = 0.47123888F + movingArmZBob;
            }
        }
    }

    public void TranslateToHand(VexRenderState state, HumanoidArm arm, PoseStack pose) {
        bool mainArm = arm == HumanoidArm.Right;
        ModelPart activeArm = mainArm ? _rightArm : _leftArm;
        Root.TranslateAndRotate(pose);
        _body.TranslateAndRotate(pose);
        activeArm.TranslateAndRotate(pose);
        pose.Scale(0.55F, 0.55F, 0.55F);
        OffsetStackPosition(pose, mainArm);
    }

    private static void OffsetStackPosition(PoseStack pose, bool mainArm) {
        if (mainArm) {
            pose.Translate(0.046875F, -0.15625F, 0.078125F);
        }
        else {
            pose.Translate(-0.046875F, -0.15625F, 0.078125F);
        }
    }
}
