namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyAxolotlModel : EntityModel<AxolotlRenderState> {
    private const float MaxWalkAnimationSpeed = 15.0F;
    private const float WalkAnimationScaleFactor = 30.0F;
    private readonly KeyframeAnimation _walkAnimation, _walkUnderwaterAnimation, _swimAnimation, _idleOnGroundAnimation, _idleOnGroundUnderWaterAnimation,
        _idleUnderWaterAnimation, _playDeadAnimation;

    public BabyAxolotlModel(ModelPart root) : base(root) {
        _swimAnimation = BabyAxolotlAnimation.BabyAxolotlSwim.Bake(root);
        _walkAnimation = BabyAxolotlAnimation.AxolotlWalkFloor.Bake(root);
        _walkUnderwaterAnimation = BabyAxolotlAnimation.WalkFloorUnderwater.Bake(root);
        _idleUnderWaterAnimation = BabyAxolotlAnimation.IdleUnderwater.Bake(root);
        _idleOnGroundUnderWaterAnimation = BabyAxolotlAnimation.IdleFloorUnderwater.Bake(root);
        _idleOnGroundAnimation = BabyAxolotlAnimation.BabyAxolotlIdleFloor.Bake(root);
        _playDeadAnimation = BabyAxolotlAnimation.BabyAxolotlPlayDead.Bake(root);
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition meshdefinition = new();
        PartDefinition partdefinition = meshdefinition.Root;
        PartDefinition root = partdefinition.AddOrReplaceChild("root", CubeListBuilder.Create(), PartPose.Offset(0.0F, 24.0F, 0.0F));
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-2.0F, -0.75F, -2.75F, 4.0F, 2.0F, 6.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 12).AddBox(0.0F, -1.75F, -2.75F, 0.0F, 3.0F, 5.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -1.25F, 1.75F));
        body.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(20, 16).AddBox(-3.0F, 0.0F, -0.5F, 3.0F, 0.0F, 1.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-2.0F, 0.25F, -1.25F));
        PartDefinition rightLeg = body.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create(),
            PartPose.OffsetAndRotation(-2.0F, 0.25F, 1.75F, 0.0F, 1.5708F, 1.5708F));
        rightLeg.AddOrReplaceChild("right_leg_r1", CubeListBuilder.Create().TexOffs(20, 14).AddBox(0.0F, 0.0F, -0.5F, 3.0F, 0.0F, 1.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 0.0F, -1.5708F, 0.0F, 1.5708F));
        body.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(20, 13).AddBox(0.0F, 0.0F, -0.5F, 3.0F, 0.0F, 1.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(2.0F, 0.25F, -1.25F));
        body.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(20, 14).AddBox(0.0F, 0.0F, -0.5F, 3.0F, 0.0F, 1.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(2.0F, 0.25F, 1.75F));
        body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(10, 9).AddBox(0.0F, -1.5F, -1.0F, 0.0F, 3.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -0.25F, 3.25F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 8).AddBox(-3.0F, -2.0F, -4.0F, 6.0F, 3.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 0.25F, -2.75F));
        head.AddOrReplaceChild("left_gills", CubeListBuilder.Create().TexOffs(20, 8).AddBox(0.0F, -3.5F, 0.0F, 3.0F, 5.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(3.0F, -0.5F, -2.0F));
        head.AddOrReplaceChild("right_gills", CubeListBuilder.Create().TexOffs(20, 3).AddBox(-3.0F, -3.5F, 0.0F, 3.0F, 5.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-3.0F, -0.5F, -2.0F));
        head.AddOrReplaceChild("top_gills", CubeListBuilder.Create().TexOffs(20, 0).AddBox(-3.0F, -3.0F, 0.0F, 6.0F, 3.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -2.0F, -2.0F));
        return LayerDefinition.Create(meshdefinition, 32, 32);
    }

    public override void SetupAnim(AxolotlRenderState state) {
        base.SetupAnim(state);
        if (state.WalkAnimationState.IsStarted) {
            _walkAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, MaxWalkAnimationSpeed, WalkAnimationScaleFactor);
        }
        _swimAnimation.Apply(state.SwimAnimation, state.AgeInTicks);
        // Vanilla drives the underwater walk from walkAnimationState, not walkUnderWaterAnimationState.
        _walkUnderwaterAnimation.Apply(state.WalkAnimationState, state.AgeInTicks);
        _idleOnGroundAnimation.Apply(state.IdleOnGroundAnimationState, state.AgeInTicks);
        _idleUnderWaterAnimation.Apply(state.IdleUnderWaterAnimationState, state.AgeInTicks);
        _idleOnGroundUnderWaterAnimation.Apply(state.IdleUnderWaterOnGroundAnimationState, state.AgeInTicks);
        _playDeadAnimation.Apply(state.PlayDeadAnimationState, state.AgeInTicks);
    }
}
