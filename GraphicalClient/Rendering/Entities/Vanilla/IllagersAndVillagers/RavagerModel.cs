namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class RavagerModel : EntityModel<RavagerRenderState> {
    private readonly ModelPart _head, _mouth, _rightHindLeg, _leftHindLeg, _rightFrontLeg, _leftFrontLeg, _neck;

    public RavagerModel(ModelPart root) : base(root) {
        _neck = root.GetChild("neck");
        _head = _neck.GetChild("head");
        _mouth = _head.GetChild("mouth");
        _rightHindLeg = root.GetChild("right_hind_leg");
        _leftHindLeg = root.GetChild("left_hind_leg");
        _rightFrontLeg = root.GetChild("right_front_leg");
        _leftFrontLeg = root.GetChild("left_front_leg");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition neck = root.AddOrReplaceChild("neck", CubeListBuilder.Create().TexOffs(68, 73).AddBox(-5.0F, -1.0F, -18.0F, 10.0F, 10.0F, 18.0F),
            PartPose.Offset(0.0F, -7.0F, 5.5F));
        PartDefinition head = neck.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-8.0F, -20.0F, -14.0F, 16.0F, 20.0F, 16.0F)
                .TexOffs(0, 0).AddBox(-2.0F, -6.0F, -18.0F, 4.0F, 8.0F, 4.0F),
            PartPose.Offset(0.0F, 16.0F, -17.0F));
        head.AddOrReplaceChild("right_horn", CubeListBuilder.Create().TexOffs(74, 55).AddBox(0.0F, -14.0F, -2.0F, 2.0F, 14.0F, 4.0F),
            PartPose.OffsetAndRotation(-10.0F, -14.0F, -8.0F, 1.0995574F, 0.0F, 0.0F));
        head.AddOrReplaceChild("left_horn", CubeListBuilder.Create().TexOffs(74, 55).Mirror().AddBox(0.0F, -14.0F, -2.0F, 2.0F, 14.0F, 4.0F),
            PartPose.OffsetAndRotation(8.0F, -14.0F, -8.0F, 1.0995574F, 0.0F, 0.0F));
        head.AddOrReplaceChild("mouth", CubeListBuilder.Create().TexOffs(0, 36).AddBox(-8.0F, 0.0F, -16.0F, 16.0F, 3.0F, 16.0F), PartPose.Offset(0.0F, -2.0F, 2.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 55).AddBox(-7.0F, -10.0F, -7.0F, 14.0F, 16.0F, 20.0F)
                .TexOffs(0, 91).AddBox(-6.0F, 6.0F, -7.0F, 12.0F, 13.0F, 18.0F),
            PartPose.OffsetAndRotation(0.0F, 1.0F, 2.0F, (float)(Math.PI / 2), 0.0F, 0.0F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(96, 0).AddBox(-4.0F, 0.0F, -4.0F, 8.0F, 37.0F, 8.0F),
            PartPose.Offset(-8.0F, -13.0F, 18.0F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(96, 0).Mirror().AddBox(-4.0F, 0.0F, -4.0F, 8.0F, 37.0F, 8.0F),
            PartPose.Offset(8.0F, -13.0F, 18.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(64, 0).AddBox(-4.0F, 0.0F, -4.0F, 8.0F, 37.0F, 8.0F),
            PartPose.Offset(-8.0F, -13.0F, -5.0F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(64, 0).Mirror().AddBox(-4.0F, 0.0F, -4.0F, 8.0F, 37.0F, 8.0F),
            PartPose.Offset(8.0F, -13.0F, -5.0F));
        return LayerDefinition.Create(mesh, 128, 128);
    }

    public override void SetupAnim(RavagerRenderState state) {
        base.SetupAnim(state);
        float stunnedTick = state.StunnedTicksRemaining;
        float attackTick = state.AttackTicksRemaining;
        if (attackTick > 0.0F) {
            float headAnim = Mth.TriangleWave(attackTick, 10.0F);
            float scaled = (1.0F + headAnim) * 0.5F;
            float headPos = scaled * scaled * scaled * 12.0F;
            float yOffset = headPos * Mth.Sin(_neck.XRot);
            _neck.Z = -6.5F + headPos;
            _neck.Y = -7.0F - yOffset;
            if (attackTick > 5.0F) {
                _mouth.XRot = Mth.Sin((-4.0F + attackTick) / 4.0F) * MathF.PI * 0.4F;
            }
            else {
                _mouth.XRot = (float)(Math.PI / 20) * Mth.Sin(MathF.PI * attackTick / 10.0F);
            }
        }
        else {
            float yOffset = -1.0F * Mth.Sin(_neck.XRot);
            _neck.X = 0.0F;
            _neck.Y = -7.0F - yOffset;
            _neck.Z = 5.5F;
            bool isStunned = stunnedTick > 0.0F;
            _neck.XRot = isStunned ? 0.21991149F : 0.0F;
            _mouth.XRot = MathF.PI * (isStunned ? 0.05F : 0.01F);
            if (isStunned) {
                double speed = stunnedTick / 40.0;
                _neck.X = (float)Math.Sin(speed * 10.0) * 3.0F;
            }
            else if (state.RoarAnimation > 0.0) {
                float mouthAnim = Mth.Sin(state.RoarAnimation * MathF.PI * 0.25F);
                _mouth.XRot = (float)(Math.PI / 2) * mouthAnim;
            }
        }

        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        float animationPos = state.WalkAnimationPos;
        float legRot = 0.4F * state.WalkAnimationSpeed;
        _rightHindLeg.XRot = Mth.Cos(animationPos * 0.6662F) * legRot;
        _leftHindLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * legRot;
        _rightFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * legRot;
        _leftFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F) * legRot;
    }
}
