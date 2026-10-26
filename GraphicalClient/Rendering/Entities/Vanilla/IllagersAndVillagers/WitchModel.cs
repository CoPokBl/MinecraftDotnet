namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>WitchModel</c>. Built over the villager's mesh, so replacing its head and hat keeps their old
/// children: the witch's hat still carries the villager's <c>hat_rim</c>, as vanilla's does.
/// </summary>
public sealed class WitchModel : EntityModel<WitchRenderState>, IHeadedModel, IVillagerLikeModel<WitchRenderState> {
    private readonly ModelPart _nose, _head, _rightLeg, _leftLeg, _arms;

    public WitchModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _nose = _head.GetChild("nose");
        _rightLeg = root.GetChild("right_leg");
        _leftLeg = root.GetChild("left_leg");
        _arms = root.GetChild("arms");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = VillagerModel.CreateBodyModel();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -10.0F, -4.0F, 8.0F, 10.0F, 8.0F), PartPose.Zero);
        PartDefinition hat = head.AddOrReplaceChild("hat", CubeListBuilder.Create().TexOffs(0, 64).AddBox(0.0F, 0.0F, 0.0F, 10.0F, 2.0F, 10.0F),
            PartPose.Offset(-5.0F, -10.03125F, -5.0F));
        PartDefinition hat2 = hat.AddOrReplaceChild("hat2", CubeListBuilder.Create().TexOffs(0, 76).AddBox(0.0F, 0.0F, 0.0F, 7.0F, 4.0F, 7.0F),
            PartPose.OffsetAndRotation(1.75F, -4.0F, 2.0F, -0.05235988F, 0.0F, 0.02617994F));
        PartDefinition hat3 = hat2.AddOrReplaceChild("hat3", CubeListBuilder.Create().TexOffs(0, 87).AddBox(0.0F, 0.0F, 0.0F, 4.0F, 4.0F, 4.0F),
            PartPose.OffsetAndRotation(1.75F, -4.0F, 2.0F, -0.10471976F, 0.0F, 0.05235988F));
        hat3.AddOrReplaceChild("hat4", CubeListBuilder.Create().TexOffs(0, 95).AddBox(0.0F, 0.0F, 0.0F, 1.0F, 2.0F, 1.0F, new CubeDeformation(0.25F)),
            PartPose.OffsetAndRotation(1.75F, -2.0F, 2.0F, (float)(-Math.PI / 15), 0.0F, 0.10471976F));
        PartDefinition nose = head.GetChild("nose");
        nose.AddOrReplaceChild("mole", CubeListBuilder.Create().TexOffs(0, 0).AddBox(0.0F, 3.0F, -6.75F, 1.0F, 1.0F, 1.0F, new CubeDeformation(-0.25F)),
            PartPose.Offset(0.0F, -2.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 128);
    }

    public override void SetupAnim(WitchRenderState state) {
        base.SetupAnim(state);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        _rightLeg.XRot = Mth.Cos(state.WalkAnimationPos * 0.6662F) * 1.4F * state.WalkAnimationSpeed * 0.5F;
        _leftLeg.XRot = Mth.Cos(state.WalkAnimationPos * 0.6662F + MathF.PI) * 1.4F * state.WalkAnimationSpeed * 0.5F;
        float speed = 0.01F * (state.EntityId % 10);
        _nose.XRot = Mth.Sin(state.AgeInTicks * speed) * 4.5F * (MathF.PI / 180.0F);
        _nose.ZRot = Mth.Cos(state.AgeInTicks * speed) * 2.5F * (MathF.PI / 180.0F);
        if (state.IsHoldingItem) {
            _nose.SetPos(0.0F, 1.0F, -1.5F);
            _nose.XRot = -0.9F;
        }
    }

    public ModelPart Nose => _nose;

    public ModelPart Head => _head;

    public void TranslateToArms(WitchRenderState state, PoseStack pose) {
        Root.TranslateAndRotate(pose);
        _arms.TranslateAndRotate(pose);
    }
}
