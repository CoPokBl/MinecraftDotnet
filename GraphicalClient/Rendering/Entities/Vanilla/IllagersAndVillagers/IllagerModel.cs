using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class IllagerModel<S> : EntityModel<S>, IArmedModel<S>, IHeadedModel where S : IllagerRenderState {
    private readonly ModelPart _head, _hat, _arms, _leftLeg, _rightLeg, _rightArm, _leftArm;

    public IllagerModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _hat = _head.GetChild("hat");
        _hat.Visible = false;
        _arms = root.GetChild("arms");
        _leftLeg = root.GetChild("left_leg");
        _rightLeg = root.GetChild("right_leg");
        _leftArm = root.GetChild("left_arm");
        _rightArm = root.GetChild("right_arm");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -10.0F, -4.0F, 8.0F, 10.0F, 8.0F),
            PartPose.Offset(0.0F, 0.0F, 0.0F));
        head.AddOrReplaceChild("hat", CubeListBuilder.Create().TexOffs(32, 0).AddBox(-4.0F, -10.0F, -4.0F, 8.0F, 12.0F, 8.0F, new CubeDeformation(0.45F)), PartPose.Zero);
        head.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(24, 0).AddBox(-1.0F, -1.0F, -6.0F, 2.0F, 4.0F, 2.0F), PartPose.Offset(0.0F, -2.0F, 0.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(16, 20).AddBox(-4.0F, 0.0F, -3.0F, 8.0F, 12.0F, 6.0F)
                .TexOffs(0, 38).AddBox(-4.0F, 0.0F, -3.0F, 8.0F, 20.0F, 6.0F, new CubeDeformation(0.5F)),
            PartPose.Offset(0.0F, 0.0F, 0.0F));
        PartDefinition arms = root.AddOrReplaceChild("arms", CubeListBuilder.Create()
                .TexOffs(44, 22).AddBox(-8.0F, -2.0F, -2.0F, 4.0F, 8.0F, 4.0F)
                .TexOffs(40, 38).AddBox(-4.0F, 2.0F, -2.0F, 8.0F, 4.0F, 4.0F),
            PartPose.OffsetAndRotation(0.0F, 3.0F, -1.0F, -0.75F, 0.0F, 0.0F));
        arms.AddOrReplaceChild("left_shoulder", CubeListBuilder.Create().TexOffs(44, 22).Mirror().AddBox(4.0F, -2.0F, -2.0F, 4.0F, 8.0F, 4.0F), PartPose.Zero);
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 22).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F), PartPose.Offset(-2.0F, 12.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 22).Mirror().AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F),
            PartPose.Offset(2.0F, 12.0F, 0.0F));
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(40, 46).AddBox(-3.0F, -2.0F, -2.0F, 4.0F, 12.0F, 4.0F), PartPose.Offset(-5.0F, 2.0F, 0.0F));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(40, 46).Mirror().AddBox(-1.0F, -2.0F, -2.0F, 4.0F, 12.0F, 4.0F),
            PartPose.Offset(5.0F, 2.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(S state) {
        base.SetupAnim(state);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        if (state.IsRiding) {
            _rightArm.XRot = (float)(-Math.PI / 5);
            _rightArm.YRot = 0.0F;
            _rightArm.ZRot = 0.0F;
            _leftArm.XRot = (float)(-Math.PI / 5);
            _leftArm.YRot = 0.0F;
            _leftArm.ZRot = 0.0F;
            _rightLeg.XRot = -1.4137167F;
            _rightLeg.YRot = (float)(Math.PI / 10);
            _rightLeg.ZRot = 0.07853982F;
            _leftLeg.XRot = -1.4137167F;
            _leftLeg.YRot = (float)(-Math.PI / 10);
            _leftLeg.ZRot = -0.07853982F;
        }
        else {
            float animationSpeed = state.WalkAnimationSpeed;
            float animationPos = state.WalkAnimationPos;
            _rightArm.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 2.0F * animationSpeed * 0.5F;
            _rightArm.YRot = 0.0F;
            _rightArm.ZRot = 0.0F;
            _leftArm.XRot = Mth.Cos(animationPos * 0.6662F) * 2.0F * animationSpeed * 0.5F;
            _leftArm.YRot = 0.0F;
            _leftArm.ZRot = 0.0F;
            _rightLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed * 0.5F;
            _rightLeg.YRot = 0.0F;
            _rightLeg.ZRot = 0.0F;
            _leftLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed * 0.5F;
            _leftLeg.YRot = 0.0F;
            _leftLeg.ZRot = 0.0F;
        }

        IllagerArmPose pose = state.ArmPose;
        if (pose == IllagerArmPose.Attacking) {
            if (state.MainHandItemState == null) {
                AnimationUtils.AnimateZombieArms(_leftArm, _rightArm, true, state);
            }
            else {
                AnimationUtils.SwingWeaponDown(_rightArm, _leftArm, state.MainArm, state.AttackAnim, state.AgeInTicks);
            }
        }
        else if (pose == IllagerArmPose.Spellcasting) {
            _rightArm.Z = 0.0F;
            _rightArm.X = -5.0F;
            _leftArm.Z = 0.0F;
            _leftArm.X = 5.0F;
            _rightArm.XRot = Mth.Cos(state.AgeInTicks * 0.6662F) * 0.25F;
            _leftArm.XRot = Mth.Cos(state.AgeInTicks * 0.6662F) * 0.25F;
            _rightArm.ZRot = (float)(Math.PI * 3.0 / 4.0);
            _leftArm.ZRot = (float)(-Math.PI * 3.0 / 4.0);
            _rightArm.YRot = 0.0F;
            _leftArm.YRot = 0.0F;
        }
        else if (pose == IllagerArmPose.BowAndArrow) {
            _rightArm.YRot = -0.1F + _head.YRot;
            _rightArm.XRot = (float)(-Math.PI / 2) + _head.XRot;
            _leftArm.XRot = -0.9424779F + _head.XRot;
            _leftArm.YRot = _head.YRot - 0.4F;
            _leftArm.ZRot = (float)(Math.PI / 2);
        }
        else if (pose == IllagerArmPose.CrossbowHold) {
            AnimationUtils.AnimateCrossbowHold(_rightArm, _leftArm, _head, true);
        }
        else if (pose == IllagerArmPose.CrossbowCharge) {
            AnimationUtils.AnimateCrossbowCharge(_rightArm, _leftArm, state.MaxCrossbowChargeDuration, state.TicksUsingItemValue, true);
        }
        else if (pose == IllagerArmPose.Celebrating) {
            _rightArm.Z = 0.0F;
            _rightArm.X = -5.0F;
            _rightArm.XRot = Mth.Cos(state.AgeInTicks * 0.6662F) * 0.05F;
            _rightArm.ZRot = 2.670354F;
            _rightArm.YRot = 0.0F;
            _leftArm.Z = 0.0F;
            _leftArm.X = 5.0F;
            _leftArm.XRot = Mth.Cos(state.AgeInTicks * 0.6662F) * 0.05F;
            _leftArm.ZRot = (float)(-Math.PI * 3.0 / 4.0);
            _leftArm.YRot = 0.0F;
        }

        bool crossedArms = pose == IllagerArmPose.Crossed;
        _arms.Visible = crossedArms;
        _leftArm.Visible = !crossedArms;
        _rightArm.Visible = !crossedArms;
    }

    private ModelPart GetArm(HumanoidArm arm) => arm == HumanoidArm.Left ? _leftArm : _rightArm;

    public ModelPart Hat => _hat;

    public ModelPart Head => _head;

    public void TranslateToHand(S state, HumanoidArm arm, PoseStack pose) {
        Root.TranslateAndRotate(pose);
        GetArm(arm).TranslateAndRotate(pose);
    }
}
