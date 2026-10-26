using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class CopperGolemModel : EntityModel<CopperGolemRenderState>, IArmedModel<CopperGolemRenderState>, IHeadedModel {
    private const float MaxWalkAnimationSpeed = 2.0F;
    private const float WalkAnimationScaleFactor = 2.5F;
    private readonly ModelPart _head, _body, _rightArm, _leftArm;
    private readonly KeyframeAnimation _walkAnimation, _walkWithItemAnimation, _idleAnimation, _interactionGetItem, _interactionGetNoItem, _interactionDropItem;
    private readonly KeyframeAnimation _interactionDropNoItem;

    public CopperGolemModel(ModelPart root) : base(root) {
        _body = root.GetChild("body");
        _head = _body.GetChild("head");
        _rightArm = _body.GetChild("right_arm");
        _leftArm = _body.GetChild("left_arm");
        _walkAnimation = CopperGolemAnimation.CopperGolemWalk.Bake(root);
        _walkWithItemAnimation = CopperGolemAnimation.CopperGolemWalkItem.Bake(root);
        _idleAnimation = CopperGolemAnimation.CopperGolemIdle.Bake(root);
        _interactionGetItem = CopperGolemAnimation.CopperGolemChestInteractionNoitemGet.Bake(root);
        _interactionGetNoItem = CopperGolemAnimation.CopperGolemChestInteractionNoitemNoget.Bake(root);
        _interactionDropItem = CopperGolemAnimation.CopperGolemChestInteractionItemDrop.Bake(root);
        _interactionDropNoItem = CopperGolemAnimation.CopperGolemChestInteractionItemNodrop.Bake(root);
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition meshDefinition = new MeshDefinition().Transformed(p => p.Translated(0.0F, 24.0F, 0.0F));
        PartDefinition root = meshDefinition.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 15).AddBox(-4.0F, -6.0F, -3.0F, 8.0F, 6.0F, 6.0F, CubeDeformation.None),
            PartPose.Offset(0.0F, -5.0F, 0.0F));
        body.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-4.0F, -5.0F, -5.0F, 8.0F, 5.0F, 10.0F, new CubeDeformation(0.015F))
                .TexOffs(56, 0).AddBox(-1.0F, -2.0F, -6.0F, 2.0F, 3.0F, 2.0F, CubeDeformation.None)
                .TexOffs(37, 8).AddBox(-1.0F, -9.0F, -1.0F, 2.0F, 4.0F, 2.0F, new CubeDeformation(-0.015F))
                .TexOffs(37, 0).AddBox(-2.0F, -13.0F, -2.0F, 4.0F, 4.0F, 4.0F, new CubeDeformation(-0.015F)),
            PartPose.Offset(0.0F, -6.0F, 0.0F));
        body.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(36, 16).AddBox(-3.0F, -1.0F, -2.0F, 3.0F, 10.0F, 4.0F, CubeDeformation.None),
            PartPose.Offset(-4.0F, -6.0F, 0.0F));
        body.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(50, 16).AddBox(0.0F, -1.0F, -2.0F, 3.0F, 10.0F, 4.0F, CubeDeformation.None),
            PartPose.Offset(4.0F, -6.0F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 27).AddBox(-4.0F, 0.0F, -2.0F, 4.0F, 5.0F, 4.0F, CubeDeformation.None),
            PartPose.Offset(0.0F, -5.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(16, 27).AddBox(0.0F, 0.0F, -2.0F, 4.0F, 5.0F, 4.0F, CubeDeformation.None),
            PartPose.Offset(0.0F, -5.0F, 0.0F));
        return LayerDefinition.Create(meshDefinition, 64, 64);
    }

    public override void SetupAnim(CopperGolemRenderState state) {
        base.SetupAnim(state);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        if (state.RightHandItemState == null && state.LeftHandItemState == null) {
            _walkAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, MaxWalkAnimationSpeed, WalkAnimationScaleFactor);
        }
        else {
            _walkWithItemAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, MaxWalkAnimationSpeed, WalkAnimationScaleFactor);
            PoseHeldItemArmsIfStill();
        }

        _idleAnimation.Apply(state.IdleAnimationState, state.AgeInTicks);
        _interactionGetItem.Apply(state.InteractionGetItem, state.AgeInTicks);
        _interactionGetNoItem.Apply(state.InteractionGetNoItem, state.AgeInTicks);
        _interactionDropItem.Apply(state.InteractionDropItem, state.AgeInTicks);
        _interactionDropNoItem.Apply(state.InteractionDropNoItem, state.AgeInTicks);
    }

    public void TranslateToHand(CopperGolemRenderState state, HumanoidArm arm, PoseStack pose) {
        Root.TranslateAndRotate(pose);
        _body.TranslateAndRotate(pose);
        ModelPart activeArm = arm == HumanoidArm.Right ? _rightArm : _leftArm;
        activeArm.TranslateAndRotate(pose);
        if (state.CopperGolemState == CopperGolemState.Idle) {
            pose.RotateYDegrees(arm == HumanoidArm.Right ? -90.0F : 90.0F);
            pose.Translate(0.0F, 0.0F, 0.125F);
        }
        else {
            pose.Scale(0.55F, 0.55F, 0.55F);
            pose.Translate(-0.125F, 0.3125F, -0.1875F);
        }
    }

    public ModelPart Head => _head;

    public void TranslateToHead(PoseStack pose) {
        _body.TranslateAndRotate(pose);
        _head.TranslateAndRotate(pose);
        pose.Translate(0.0F, 0.125F, 0.0F);
        pose.Scale(1.0625F, 1.0625F, 1.0625F);
    }

    public void ApplyBlockOnAntennaTransform(PoseStack pose) {
        Root.TranslateAndRotate(pose);
        _body.TranslateAndRotate(pose);
        _head.TranslateAndRotate(pose);
        pose.Translate(0.0F, -1.75F, 0.0F);
    }

    private void PoseHeldItemArmsIfStill() {
        _rightArm.XRot = Math.Min(_rightArm.XRot, -0.87266463F);
        _leftArm.XRot = Math.Min(_leftArm.XRot, -0.87266463F);
        _rightArm.YRot = Math.Min(_rightArm.YRot, -0.1134464F);
        _leftArm.YRot = Math.Max(_leftArm.YRot, 0.1134464F);
        _rightArm.ZRot = Math.Min(_rightArm.ZRot, -0.064577185F);
        _leftArm.ZRot = Math.Max(_leftArm.ZRot, 0.064577185F);
    }
}
