namespace GraphicalClient.Rendering.Entities.Vanilla;

public class SnifferModel : EntityModel<SnifferRenderState> {
    private const float WalkAnimationSpeedMax = 9.0F;
    private const float WalkAnimationScaleFactor = 100.0F;

    private readonly ModelPart _head;
    private readonly KeyframeAnimation _sniffSearchAnimation;
    private readonly KeyframeAnimation _walkAnimation;
    private readonly KeyframeAnimation _digAnimation;
    private readonly KeyframeAnimation _longSniffAnimation;
    private readonly KeyframeAnimation _standUpAnimation;
    private readonly KeyframeAnimation _happyAnimation;
    private readonly KeyframeAnimation _sniffSniffAnimation;

    public SnifferModel(ModelPart root) : base(root) {
        _head = root.GetChild("bone").GetChild("body").GetChild("head");
        _sniffSearchAnimation = SnifferAnimation.SnifferSniffSearch.Bake(root);
        _walkAnimation = SnifferAnimation.SnifferWalk.Bake(root);
        _digAnimation = SnifferAnimation.SnifferDig.Bake(root);
        _longSniffAnimation = SnifferAnimation.SnifferLongsniff.Bake(root);
        _standUpAnimation = SnifferAnimation.SnifferStandUp.Bake(root);
        _happyAnimation = SnifferAnimation.SnifferHappy.Bake(root);
        _sniffSniffAnimation = SnifferAnimation.SnifferSniffsniff.Bake(root);
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition bone = root.AddOrReplaceChild("bone", CubeListBuilder.Create(), PartPose.Offset(0.0F, 5.0F, 0.0F));
        PartDefinition body = bone.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(62, 68).AddBox(-12.5F, -14.0F, -20.0F, 25.0F, 29.0F, 40.0F, new CubeDeformation(0.0F))
            .TexOffs(62, 0).AddBox(-12.5F, -14.0F, -20.0F, 25.0F, 24.0F, 40.0F, new CubeDeformation(0.5F))
            .TexOffs(87, 68).AddBox(-12.5F, 12.0F, -20.0F, 25.0F, 0.0F, 40.0F, new CubeDeformation(0.0F)), PartPose.Offset(0.0F, 0.0F, 0.0F));
        bone.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(32, 87).AddBox(-3.5F, -1.0F, -4.0F, 7.0F, 10.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-7.5F, 10.0F, -15.0F));
        bone.AddOrReplaceChild("right_mid_leg", CubeListBuilder.Create().TexOffs(32, 105).AddBox(-3.5F, -1.0F, -4.0F, 7.0F, 10.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-7.5F, 10.0F, 0.0F));
        bone.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(32, 123).AddBox(-3.5F, -1.0F, -4.0F, 7.0F, 10.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-7.5F, 10.0F, 15.0F));
        bone.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(0, 87).AddBox(-3.5F, -1.0F, -4.0F, 7.0F, 10.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(7.5F, 10.0F, -15.0F));
        bone.AddOrReplaceChild("left_mid_leg", CubeListBuilder.Create().TexOffs(0, 105).AddBox(-3.5F, -1.0F, -4.0F, 7.0F, 10.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(7.5F, 10.0F, 0.0F));
        bone.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(0, 123).AddBox(-3.5F, -1.0F, -4.0F, 7.0F, 10.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(7.5F, 10.0F, 15.0F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(8, 15).AddBox(-6.5F, -7.5F, -11.5F, 13.0F, 18.0F, 11.0F, new CubeDeformation(0.0F))
            .TexOffs(8, 4).AddBox(-6.5F, 7.5F, -11.5F, 13.0F, 0.0F, 11.0F, new CubeDeformation(0.0F)), PartPose.Offset(0.0F, 6.5F, -19.48F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(2, 0).AddBox(0.0F, 0.0F, -3.0F, 1.0F, 19.0F, 7.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(6.51F, -7.5F, -4.51F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(48, 0).AddBox(-1.0F, 0.0F, -3.0F, 1.0F, 19.0F, 7.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-6.51F, -7.5F, -4.51F));
        head.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(10, 45).AddBox(-6.5F, -2.0F, -9.0F, 13.0F, 2.0F, 9.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -4.5F, -11.5F));
        head.AddOrReplaceChild("lower_beak", CubeListBuilder.Create().TexOffs(10, 57).AddBox(-6.5F, -7.0F, -8.0F, 13.0F, 12.0F, 9.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 2.5F, -12.5F));
        return LayerDefinition.Create(mesh, 192, 192);
    }

    public override void SetupAnim(SnifferRenderState state) {
        base.SetupAnim(state);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        if (state.IsSearching) {
            _sniffSearchAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, WalkAnimationSpeedMax, WalkAnimationScaleFactor);
        }
        else {
            _walkAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, WalkAnimationSpeedMax, WalkAnimationScaleFactor);
        }
        _digAnimation.Apply(state.DiggingAnimationState, state.AgeInTicks);
        _longSniffAnimation.Apply(state.SniffingAnimationState, state.AgeInTicks);
        _standUpAnimation.Apply(state.RisingAnimationState, state.AgeInTicks);
        _happyAnimation.Apply(state.FeelingHappyAnimationState, state.AgeInTicks);
        _sniffSniffAnimation.Apply(state.ScentingAnimationState, state.AgeInTicks);
    }
}
