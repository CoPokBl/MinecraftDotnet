using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>PlayerModel</c>.</summary>
public class PlayerModel : HumanoidModel<AvatarRenderState> {
    public readonly ModelPart LeftSleeve;
    public readonly ModelPart RightSleeve;
    public readonly ModelPart LeftPants;
    public readonly ModelPart RightPants;
    public readonly ModelPart Jacket;
    private readonly bool _slim;

    public PlayerModel(ModelPart root, bool slim) : base(root) {
        _slim = slim;
        LeftSleeve = LeftArm.GetChild("left_sleeve");
        RightSleeve = RightArm.GetChild("right_sleeve");
        LeftPants = LeftLeg.GetChild("left_pants");
        RightPants = RightLeg.GetChild("right_pants");
        Jacket = Body.GetChild("jacket");
    }

    /// <summary><c>entityTranslucent</c>.</summary>
    public override bool Translucent => true;

    public static MeshDefinition CreateMesh(CubeDeformation scale, bool slim) {
        MeshDefinition mesh = HumanoidModel<AvatarRenderState>.CreateMesh(scale, 0.0F);
        PartDefinition root = mesh.Root;
        if (slim) {
            PartDefinition leftArm = root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(32, 48).AddBox(-1.0F, -2.0F, -2.0F, 3.0F, 12.0F, 4.0F, scale),
                PartPose.Offset(5.0F, 2.0F, 0.0F));
            PartDefinition rightArm = root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(40, 16).AddBox(-2.0F, -2.0F, -2.0F, 3.0F, 12.0F, 4.0F, scale),
                PartPose.Offset(-5.0F, 2.0F, 0.0F));
            leftArm.AddOrReplaceChild("left_sleeve", CubeListBuilder.Create().TexOffs(48, 48).AddBox(-1.0F, -2.0F, -2.0F, 3.0F, 12.0F, 4.0F, scale.Extend(0.25F)),
                PartPose.Zero);
            rightArm.AddOrReplaceChild("right_sleeve", CubeListBuilder.Create().TexOffs(40, 32).AddBox(-2.0F, -2.0F, -2.0F, 3.0F, 12.0F, 4.0F, scale.Extend(0.25F)),
                PartPose.Zero);
        }
        else {
            PartDefinition leftArm = root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(32, 48).AddBox(-1.0F, -2.0F, -2.0F, 4.0F, 12.0F, 4.0F, scale),
                PartPose.Offset(5.0F, 2.0F, 0.0F));
            PartDefinition rightArm = root.GetChild("right_arm");
            leftArm.AddOrReplaceChild("left_sleeve", CubeListBuilder.Create().TexOffs(48, 48).AddBox(-1.0F, -2.0F, -2.0F, 4.0F, 12.0F, 4.0F, scale.Extend(0.25F)),
                PartPose.Zero);
            rightArm.AddOrReplaceChild("right_sleeve", CubeListBuilder.Create().TexOffs(40, 32).AddBox(-3.0F, -2.0F, -2.0F, 4.0F, 12.0F, 4.0F, scale.Extend(0.25F)),
                PartPose.Zero);
        }
        PartDefinition leftLeg = root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(16, 48).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, scale),
            PartPose.Offset(1.9F, 12.0F, 0.0F));
        PartDefinition rightLeg = root.GetChild("right_leg");
        leftLeg.AddOrReplaceChild("left_pants", CubeListBuilder.Create().TexOffs(0, 48).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, scale.Extend(0.25F)), PartPose.Zero);
        rightLeg.AddOrReplaceChild("right_pants", CubeListBuilder.Create().TexOffs(0, 32).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, scale.Extend(0.25F)), PartPose.Zero);
        PartDefinition body = root.GetChild("body");
        body.AddOrReplaceChild("jacket", CubeListBuilder.Create().TexOffs(16, 32).AddBox(-4.0F, 0.0F, -2.0F, 8.0F, 12.0F, 4.0F, scale.Extend(0.25F)), PartPose.Zero);
        return mesh;
    }

    public new static ArmorModelSet<MeshDefinition> CreateArmorMeshSet(CubeDeformation innerDeformation, CubeDeformation outerDeformation) =>
        HumanoidModel<AvatarRenderState>.CreateArmorMeshSet(innerDeformation, outerDeformation).Map(mesh => {
            PartDefinition root = mesh.Root;
            PartDefinition leftArm = root.GetChild("left_arm");
            PartDefinition rightArm = root.GetChild("right_arm");
            leftArm.AddOrReplaceChild("left_sleeve", CubeListBuilder.Create(), PartPose.Zero);
            rightArm.AddOrReplaceChild("right_sleeve", CubeListBuilder.Create(), PartPose.Zero);
            PartDefinition leftLeg = root.GetChild("left_leg");
            PartDefinition rightLeg = root.GetChild("right_leg");
            leftLeg.AddOrReplaceChild("left_pants", CubeListBuilder.Create(), PartPose.Zero);
            rightLeg.AddOrReplaceChild("right_pants", CubeListBuilder.Create(), PartPose.Zero);
            PartDefinition body = root.GetChild("body");
            body.AddOrReplaceChild("jacket", CubeListBuilder.Create(), PartPose.Zero);
            return mesh;
        });

    /// <summary>
    /// <c>PlayerModel.createBabyArmorMeshSet</c>, which is <c>HumanoidModel</c>'s inherited unchanged; the
    /// baby piglin's armour reaches it through this name.
    /// </summary>
    public new static ArmorModelSet<MeshDefinition> CreateBabyArmorMeshSet(CubeDeformation innerDeformation, CubeDeformation outerDeformation, PartPose armOffset) =>
        HumanoidModel<AvatarRenderState>.CreateBabyArmorMeshSet(innerDeformation, outerDeformation, armOffset);

    public override void SetupAnim(AvatarRenderState state) {
        bool showBody = !state.IsSpectator;
        Body.Visible = showBody;
        RightArm.Visible = showBody;
        LeftArm.Visible = showBody;
        RightLeg.Visible = showBody;
        LeftLeg.Visible = showBody;
        Hat.Visible = state.ShowHat;
        Jacket.Visible = state.ShowJacket;
        LeftPants.Visible = state.ShowLeftPants;
        RightPants.Visible = state.ShowRightPants;
        LeftSleeve.Visible = state.ShowLeftSleeve;
        RightSleeve.Visible = state.ShowRightSleeve;
        base.SetupAnim(state);
    }

    public override void TranslateToHand(AvatarRenderState state, HumanoidArm arm, PoseStack pose) {
        Root.TranslateAndRotate(pose);
        ModelPart part = GetArm(arm);
        if (_slim) {
            float offset = 0.5F * (arm == HumanoidArm.Right ? 1 : -1);
            part.X += offset;
            part.TranslateAndRotate(pose);
            part.X -= offset;
        }
        else {
            part.TranslateAndRotate(pose);
        }
    }
}
