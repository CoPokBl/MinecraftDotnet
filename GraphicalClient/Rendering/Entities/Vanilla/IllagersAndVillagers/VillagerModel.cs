namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>VillagerLikeModel</c>.</summary>
public interface IVillagerLikeModel<in S> where S : EntityRenderState {
    void TranslateToArms(S state, PoseStack pose);
}

public class VillagerModel : EntityModel<VillagerRenderState>, IHeadedModel, IVillagerLikeModel<VillagerRenderState> {
    private readonly ModelPart _head, _rightLeg, _leftLeg, _arms;

    public VillagerModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _rightLeg = root.GetChild("right_leg");
        _leftLeg = root.GetChild("left_leg");
        _arms = root.GetChild("arms");
    }

    public static MeshDefinition CreateBodyModel() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -10.0F, -4.0F, 8.0F, 10.0F, 8.0F), PartPose.Zero);
        PartDefinition hat = head.AddOrReplaceChild("hat", CubeListBuilder.Create().TexOffs(32, 0).AddBox(-4.0F, -10.0F, -4.0F, 8.0F, 10.0F, 8.0F, new CubeDeformation(0.51F)),
            PartPose.Zero);
        hat.AddOrReplaceChild("hat_rim", CubeListBuilder.Create().TexOffs(30, 47).AddBox(-8.0F, -8.0F, -6.0F, 16.0F, 16.0F, 1.0F),
            PartPose.Rotation((float)(-Math.PI / 2), 0.0F, 0.0F));
        head.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(24, 0).AddBox(-1.0F, -1.0F, -6.0F, 2.0F, 4.0F, 2.0F), PartPose.Offset(0.0F, -2.0F, 0.0F));
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(16, 20).AddBox(-4.0F, 0.0F, -3.0F, 8.0F, 12.0F, 6.0F), PartPose.Zero);
        body.AddOrReplaceChild("jacket", CubeListBuilder.Create().TexOffs(0, 38).AddBox(-4.0F, 0.0F, -3.0F, 8.0F, 20.0F, 6.0F, new CubeDeformation(0.5F)), PartPose.Zero);
        root.AddOrReplaceChild("arms", CubeListBuilder.Create()
                .TexOffs(44, 22).AddBox(-8.0F, -2.0F, -2.0F, 4.0F, 8.0F, 4.0F)
                .TexOffs(44, 22).AddBox(4.0F, -2.0F, -2.0F, 4.0F, 8.0F, 4.0F, true)
                .TexOffs(40, 38).AddBox(-4.0F, 2.0F, -2.0F, 8.0F, 4.0F, 4.0F),
            PartPose.OffsetAndRotation(0.0F, 3.0F, -1.0F, -0.75F, 0.0F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 22).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F), PartPose.Offset(-2.0F, 12.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 22).Mirror().AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F),
            PartPose.Offset(2.0F, 12.0F, 0.0F));
        return mesh;
    }

    public static MeshDefinition CreateNoHatModel() {
        MeshDefinition mesh = CreateBodyModel();
        mesh.Root.ClearChild("head").ClearRecursively();
        return mesh;
    }

    public override void SetupAnim(VillagerRenderState state) {
        base.SetupAnim(state);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        if (state.IsUnhappy) {
            _head.ZRot = 0.3F * Mth.Sin(0.45F * state.AgeInTicks);
            _head.XRot = 0.4F;
        }
        else {
            _head.ZRot = 0.0F;
        }

        _rightLeg.XRot = Mth.Cos(state.WalkAnimationPos * 0.6662F) * 1.4F * state.WalkAnimationSpeed * 0.5F;
        _leftLeg.XRot = Mth.Cos(state.WalkAnimationPos * 0.6662F + MathF.PI) * 1.4F * state.WalkAnimationSpeed * 0.5F;
        _rightLeg.YRot = 0.0F;
        _leftLeg.YRot = 0.0F;
    }

    public ModelPart Head => _head;

    public void TranslateToArms(VillagerRenderState state, PoseStack pose) {
        Root.TranslateAndRotate(pose);
        _arms.TranslateAndRotate(pose);
    }
}
