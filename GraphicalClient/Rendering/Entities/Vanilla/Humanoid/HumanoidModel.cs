using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>HumanoidModel</c>.</summary>
public class HumanoidModel<S> : EntityModel<S>, IArmedModel<S>, IHeadedModel where S : HumanoidRenderState {
    public static readonly MeshTransformer BabyTransformer = new BabyModelTransform(true, 16.0F, 0.0F, 2.0F, 2.0F, 24.0F, new HashSet<string> { "head" });

    protected static readonly IReadOnlyDictionary<EquipmentSlot, IReadOnlySet<string>> AdultArmorPartsPerSlot = new Dictionary<EquipmentSlot, IReadOnlySet<string>> {
        [EquipmentSlot.Helmet] = new HashSet<string> { "head" },
        [EquipmentSlot.Chestplate] = new HashSet<string> { "body", "left_arm", "right_arm" },
        [EquipmentSlot.Leggings] = new HashSet<string> { "left_leg", "right_leg", "body" },
        [EquipmentSlot.Boots] = new HashSet<string> { "left_leg", "right_leg" }
    };

    protected static readonly IReadOnlyDictionary<EquipmentSlot, IReadOnlySet<string>> BabyArmorPartsPerSlot = new Dictionary<EquipmentSlot, IReadOnlySet<string>> {
        [EquipmentSlot.Helmet] = new HashSet<string> { "head" },
        [EquipmentSlot.Chestplate] = new HashSet<string> { "body", "left_arm", "right_arm" },
        [EquipmentSlot.Leggings] = new HashSet<string> { "left_leg", "right_leg", "waist" },
        [EquipmentSlot.Boots] = new HashSet<string> { "left_foot", "right_foot" }
    };

    public readonly ModelPart HeadPart;
    public readonly ModelPart Hat;
    public readonly ModelPart Body;
    public readonly ModelPart RightArm;
    public readonly ModelPart LeftArm;
    public readonly ModelPart RightLeg;
    public readonly ModelPart LeftLeg;

    public HumanoidModel(ModelPart root) : base(root) {
        HeadPart = root.GetChild("head");
        Hat = HeadPart.GetChild("hat");
        Body = root.GetChild("body");
        RightArm = root.GetChild("right_arm");
        LeftArm = root.GetChild("left_arm");
        RightLeg = root.GetChild("right_leg");
        LeftLeg = root.GetChild("left_leg");
    }

    public ModelPart Head => HeadPart;

    public static MeshDefinition CreateMesh(CubeDeformation g, float yOffset) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, g),
            PartPose.Offset(0.0F, 0.0F + yOffset, 0.0F));
        head.AddOrReplaceChild("hat", CubeListBuilder.Create().TexOffs(32, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, g.Extend(0.5F)), PartPose.Zero);
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(16, 16).AddBox(-4.0F, 0.0F, -2.0F, 8.0F, 12.0F, 4.0F, g),
            PartPose.Offset(0.0F, 0.0F + yOffset, 0.0F));
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(40, 16).AddBox(-3.0F, -2.0F, -2.0F, 4.0F, 12.0F, 4.0F, g),
            PartPose.Offset(-5.0F, 2.0F + yOffset, 0.0F));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(40, 16).Mirror().AddBox(-1.0F, -2.0F, -2.0F, 4.0F, 12.0F, 4.0F, g),
            PartPose.Offset(5.0F, 2.0F + yOffset, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, g),
            PartPose.Offset(-1.9F, 12.0F + yOffset, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 16).Mirror().AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, g),
            PartPose.Offset(1.9F, 12.0F + yOffset, 0.0F));
        return mesh;
    }

    public static ArmorModelSet<MeshDefinition> CreateArmorMeshSet(CubeDeformation innerDeformation, CubeDeformation outerDeformation) =>
        CreateArmorMeshSet(CreateBaseArmorMesh, AdultArmorPartsPerSlot, innerDeformation, outerDeformation);

    public static ArmorModelSet<MeshDefinition> CreateBabyArmorMeshSet(CubeDeformation innerDeformation, CubeDeformation outerDeformation, PartPose armOffset) =>
        CreateArmorMeshSet(cube => CreateBabyArmorMesh(cube, armOffset), BabyArmorPartsPerSlot, innerDeformation, outerDeformation);

    protected static ArmorModelSet<MeshDefinition> CreateArmorMeshSet(Func<CubeDeformation, MeshDefinition> baseFactory,
        IReadOnlyDictionary<EquipmentSlot, IReadOnlySet<string>> partsPerSlot, CubeDeformation innerDeformation, CubeDeformation outerDeformation) {
        MeshDefinition head = baseFactory(outerDeformation);
        head.Root.RetainPartsAndChildren(partsPerSlot[EquipmentSlot.Helmet]);
        MeshDefinition chest = baseFactory(outerDeformation);
        chest.Root.RetainExactParts(partsPerSlot[EquipmentSlot.Chestplate]);
        MeshDefinition legs = baseFactory(innerDeformation);
        legs.Root.RetainExactParts(partsPerSlot[EquipmentSlot.Leggings]);
        MeshDefinition feet = baseFactory(outerDeformation);
        feet.Root.RetainExactParts(partsPerSlot[EquipmentSlot.Boots]);
        return new ArmorModelSet<MeshDefinition>(head, chest, legs, feet);
    }

    private static MeshDefinition CreateBaseArmorMesh(CubeDeformation g) {
        MeshDefinition mesh = CreateMesh(g, 0.0F);
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, g.Extend(-0.1F)),
            PartPose.Offset(-1.9F, 12.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 16).Mirror().AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, g.Extend(-0.1F)),
            PartPose.Offset(1.9F, 12.0F, 0.0F));
        return mesh;
    }

    private static MeshDefinition CreateBabyArmorMesh(CubeDeformation g, PartPose armOffset) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.5F, -7.0F, -4.5F, 9.0F, 8.0F, 8.0F, g),
            PartPose.Offset(0.0F, 15.0F, 0.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 17).AddBox(-3.0F, -3.0F, -1.5F, 6.0F, 5.0F, 3.0F, g), PartPose.Offset(0.0F, 18.0F, 0.0F));
        root.AddOrReplaceChild("waist", CubeListBuilder.Create().TexOffs(0, 36).AddBox(-3.0F, -1.2F, -1.49F, 5.9F, 2.0F, 2.9F, g.Extend(-0.1F)),
            PartPose.Offset(0.0F, 19.0F, 0.0F));
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(30, 25).AddBox(-1.0F, 0.0F, -1.53F, 2.0F, 5.0F, 3.0F, g),
            PartPose.Offset(-3.5F - armOffset.X, 15.5F + armOffset.Y, 0.0F + armOffset.Z));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(30, 17).AddBox(-1.0F, 0.0F, -1.53F, 2.0F, 5.0F, 3.0F, g),
            PartPose.Offset(3.5F + armOffset.X, 15.5F + armOffset.Y, 0.0F + armOffset.Z));
        root.AddOrReplaceChild("inner_body", CubeListBuilder.Create().TexOffs(0, 17).AddBox(-3.0F, -3.0F, -1.5F, 6.0F, 5.0F, 3.0F, g),
            PartPose.Offset(0.0F, 18.0F, 0.0F));
        // Crossed as vanilla crosses them: the variable named for the right leg holds the left.
        PartDefinition rightLeg = root.AddOrReplaceChild("left_leg",
            CubeListBuilder.Create().TexOffs(18, 24).AddBox(-2.0F, -0.2F, -2.0F, 3.0F, 4.0F, 3.0F, g.Extend(-0.1F)), PartPose.Offset(1.5F, 20.0F, 0.5F));
        PartDefinition leftLeg = root.AddOrReplaceChild("right_leg",
            CubeListBuilder.Create().TexOffs(18, 17).AddBox(-1.0F, -0.2F, -2.0F, 3.0F, 4.0F, 3.0F, g.Extend(-0.1F)), PartPose.Offset(-1.5F, 20.0F, 0.5F));
        rightLeg.AddOrReplaceChild("right_foot", CubeListBuilder.Create().TexOffs(0, 25).AddBox(-2.0F, 2.9F, -2.0F, 3.0F, 1.0F, 3.0F, g),
            PartPose.Offset(0.0F, 0.0F, 0.0F));
        leftLeg.AddOrReplaceChild("left_foot", CubeListBuilder.Create().TexOffs(0, 29).Mirror().AddBox(-1.0F, 2.9F, -2.0F, 3.0F, 1.0F, 3.0F, g).Mirror(false),
            PartPose.Offset(0.0F, 0.0F, 0.0F));
        head.AddOrReplaceChild("hat", CubeListBuilder.Create(), PartPose.Zero);
        return mesh;
    }

    public override void SetupAnim(S state) {
        base.SetupAnim(state);
        ArmPose leftArmPose = state.LeftArmPose;
        ArmPose rightArmPose = state.RightArmPose;
        float swimAmount = state.SwimAmount;
        bool fallFlying = state.IsFallFlying;
        HeadPart.XRot = state.XRot * (float)(Math.PI / 180.0);
        HeadPart.YRot = state.YRot * (float)(Math.PI / 180.0);
        if (fallFlying) {
            HeadPart.XRot = (float)(-Math.PI / 4);
        }
        else if (swimAmount > 0.0F) {
            HeadPart.XRot = Mth.RotLerpRad(swimAmount, HeadPart.XRot, (float)(-Math.PI / 4));
        }

        float animationPos = state.WalkAnimationPos;
        float animationSpeed = state.WalkAnimationSpeed;
        RightArm.XRot = Mth.Cos(animationPos * 0.6662F + (float)Math.PI) * 2.0F * animationSpeed * 0.5F / state.SpeedValue;
        LeftArm.XRot = Mth.Cos(animationPos * 0.6662F) * 2.0F * animationSpeed * 0.5F / state.SpeedValue;
        RightLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed / state.SpeedValue;
        LeftLeg.XRot = Mth.Cos(animationPos * 0.6662F + (float)Math.PI) * 1.4F * animationSpeed / state.SpeedValue;
        RightLeg.YRot = 0.005F;
        LeftLeg.YRot = -0.005F;
        RightLeg.ZRot = 0.005F;
        LeftLeg.ZRot = -0.005F;
        if (state.IsPassenger) {
            RightArm.XRot += (float)(-Math.PI / 5);
            LeftArm.XRot += (float)(-Math.PI / 5);
            RightLeg.XRot = -1.4137167F;
            RightLeg.YRot = (float)(Math.PI / 10);
            RightLeg.ZRot = 0.07853982F;
            LeftLeg.XRot = -1.4137167F;
            LeftLeg.YRot = (float)(-Math.PI / 10);
            LeftLeg.ZRot = -0.07853982F;
        }

        bool rightHanded = state.MainArm == HumanoidArm.Right;
        if (state.IsUsingItem) {
            bool mainHandUsed = state.UseItemHand == Hand.MainHand;
            if (mainHandUsed == rightHanded) {
                PoseRightArm(state);
                if (!state.RightArmPose.AffectsOffhandPose()) {
                    PoseLeftArm(state);
                }
            }
            else {
                PoseLeftArm(state);
                if (!state.LeftArmPose.AffectsOffhandPose()) {
                    PoseRightArm(state);
                }
            }
        }
        else {
            bool twoHandedOffhand = rightHanded ? leftArmPose.IsTwoHanded() : rightArmPose.IsTwoHanded();
            if (rightHanded != twoHandedOffhand) {
                PoseLeftArm(state);
                if (!state.LeftArmPose.AffectsOffhandPose()) {
                    PoseRightArm(state);
                }
            }
            else {
                PoseRightArm(state);
                if (!state.RightArmPose.AffectsOffhandPose()) {
                    PoseLeftArm(state);
                }
            }
        }

        SetupAttackAnimation(state);
        if (state.IsCrouching) {
            Body.XRot = 0.5F;
            RightArm.XRot += 0.4F;
            LeftArm.XRot += 0.4F;
            RightLeg.Z += 4.0F;
            LeftLeg.Z += 4.0F;
            HeadPart.Y += 4.2F;
            Body.Y += 3.2F;
            LeftArm.Y += 3.2F;
            RightArm.Y += 3.2F;
        }

        if (rightArmPose != ArmPose.Spyglass) {
            AnimationUtils.BobModelPart(RightArm, state.AgeInTicks, 1.0F);
        }
        if (leftArmPose != ArmPose.Spyglass) {
            AnimationUtils.BobModelPart(LeftArm, state.AgeInTicks, -1.0F);
        }

        if (swimAmount > 0.0F) {
            float swimPos = animationPos % 26.0F;
            HumanoidArm attackArm = state.AttackArm;
            float rightArmSwimAmount = state.RightArmPose != ArmPose.Spear && (attackArm != HumanoidArm.Right || !(state.AttackTime > 0.0F)) ? swimAmount : 0.0F;
            float leftArmSwimAmount = state.LeftArmPose != ArmPose.Spear && (attackArm != HumanoidArm.Left || !(state.AttackTime > 0.0F)) ? swimAmount : 0.0F;
            if (!state.IsUsingItem) {
                if (swimPos < 14.0F) {
                    LeftArm.XRot = Mth.RotLerpRad(leftArmSwimAmount, LeftArm.XRot, 0.0F);
                    RightArm.XRot = Mth.Lerp(rightArmSwimAmount, RightArm.XRot, 0.0F);
                    LeftArm.YRot = Mth.RotLerpRad(leftArmSwimAmount, LeftArm.YRot, (float)Math.PI);
                    RightArm.YRot = Mth.Lerp(rightArmSwimAmount, RightArm.YRot, (float)Math.PI);
                    LeftArm.ZRot = Mth.RotLerpRad(leftArmSwimAmount, LeftArm.ZRot,
                        (float)Math.PI + 1.8707964F * QuadraticArmUpdate(swimPos) / QuadraticArmUpdate(14.0F));
                    RightArm.ZRot = Mth.Lerp(rightArmSwimAmount, RightArm.ZRot,
                        (float)Math.PI - 1.8707964F * QuadraticArmUpdate(swimPos) / QuadraticArmUpdate(14.0F));
                }
                else if (swimPos >= 14.0F && swimPos < 22.0F) {
                    float internalSwimPos = (swimPos - 14.0F) / 8.0F;
                    LeftArm.XRot = Mth.RotLerpRad(leftArmSwimAmount, LeftArm.XRot, (float)(Math.PI / 2) * internalSwimPos);
                    RightArm.XRot = Mth.Lerp(rightArmSwimAmount, RightArm.XRot, (float)(Math.PI / 2) * internalSwimPos);
                    LeftArm.YRot = Mth.RotLerpRad(leftArmSwimAmount, LeftArm.YRot, (float)Math.PI);
                    RightArm.YRot = Mth.Lerp(rightArmSwimAmount, RightArm.YRot, (float)Math.PI);
                    LeftArm.ZRot = Mth.RotLerpRad(leftArmSwimAmount, LeftArm.ZRot, 5.012389F - 1.8707964F * internalSwimPos);
                    RightArm.ZRot = Mth.Lerp(rightArmSwimAmount, RightArm.ZRot, 1.2707963F + 1.8707964F * internalSwimPos);
                }
                else if (swimPos >= 22.0F && swimPos < 26.0F) {
                    float internalSwimPos = (swimPos - 22.0F) / 4.0F;
                    LeftArm.XRot = Mth.RotLerpRad(leftArmSwimAmount, LeftArm.XRot, (float)(Math.PI / 2) - (float)(Math.PI / 2) * internalSwimPos);
                    RightArm.XRot = Mth.Lerp(rightArmSwimAmount, RightArm.XRot, (float)(Math.PI / 2) - (float)(Math.PI / 2) * internalSwimPos);
                    LeftArm.YRot = Mth.RotLerpRad(leftArmSwimAmount, LeftArm.YRot, (float)Math.PI);
                    RightArm.YRot = Mth.Lerp(rightArmSwimAmount, RightArm.YRot, (float)Math.PI);
                    LeftArm.ZRot = Mth.RotLerpRad(leftArmSwimAmount, LeftArm.ZRot, (float)Math.PI);
                    RightArm.ZRot = Mth.Lerp(rightArmSwimAmount, RightArm.ZRot, (float)Math.PI);
                }
            }
            LeftLeg.XRot = Mth.Lerp(swimAmount, LeftLeg.XRot, 0.3F * Mth.Cos(animationPos * 0.33333334F + (float)Math.PI));
            RightLeg.XRot = Mth.Lerp(swimAmount, RightLeg.XRot, 0.3F * Mth.Cos(animationPos * 0.33333334F));
        }
    }

    private void PoseRightArm(S state) {
        switch (state.RightArmPose) {
            case ArmPose.Empty:
                RightArm.YRot = 0.0F;
                break;
            case ArmPose.Item:
                RightArm.XRot = RightArm.XRot * 0.5F - (float)(Math.PI / 10);
                RightArm.YRot = 0.0F;
                break;
            case ArmPose.Block:
                PoseBlockingArm(RightArm, true);
                break;
            case ArmPose.BowAndArrow:
                RightArm.YRot = -0.1F + HeadPart.YRot;
                LeftArm.YRot = 0.1F + HeadPart.YRot + 0.4F;
                RightArm.XRot = (float)(-Math.PI / 2) + HeadPart.XRot;
                LeftArm.XRot = (float)(-Math.PI / 2) + HeadPart.XRot;
                break;
            case ArmPose.ThrowTrident:
                RightArm.XRot = RightArm.XRot * 0.5F - (float)Math.PI;
                RightArm.YRot = 0.0F;
                break;
            case ArmPose.CrossbowCharge:
                AnimationUtils.AnimateCrossbowCharge(RightArm, LeftArm, state.MaxCrossbowChargeDuration, state.TicksUsingItemValue, true);
                break;
            case ArmPose.CrossbowHold:
                AnimationUtils.AnimateCrossbowHold(RightArm, LeftArm, HeadPart, true);
                break;
            case ArmPose.Spyglass:
                RightArm.XRot = Mth.Clamp(HeadPart.XRot - 1.9198622F - (state.IsCrouching ? (float)(Math.PI / 12) : 0.0F), -2.4F, 3.3F);
                RightArm.YRot = HeadPart.YRot - (float)(Math.PI / 12);
                break;
            case ArmPose.TootHorn:
                RightArm.XRot = Mth.Clamp(HeadPart.XRot, -1.2F, 1.2F) - 1.4835298F;
                RightArm.YRot = HeadPart.YRot - (float)(Math.PI / 6);
                break;
            case ArmPose.Brush:
                RightArm.XRot = RightArm.XRot * 0.5F - (float)(Math.PI / 5);
                RightArm.YRot = 0.0F;
                break;
            case ArmPose.Spear:
                SpearAnimations.ThirdPersonHandUse(RightArm, HeadPart, true, state.GetUseItemStackForArm(HumanoidArm.Right), state);
                break;
        }
    }

    private void PoseLeftArm(S state) {
        switch (state.LeftArmPose) {
            case ArmPose.Empty:
                LeftArm.YRot = 0.0F;
                break;
            case ArmPose.Item:
                LeftArm.XRot = LeftArm.XRot * 0.5F - (float)(Math.PI / 10);
                LeftArm.YRot = 0.0F;
                break;
            case ArmPose.Block:
                PoseBlockingArm(LeftArm, false);
                break;
            case ArmPose.BowAndArrow:
                RightArm.YRot = -0.1F + HeadPart.YRot - 0.4F;
                LeftArm.YRot = 0.1F + HeadPart.YRot;
                RightArm.XRot = (float)(-Math.PI / 2) + HeadPart.XRot;
                LeftArm.XRot = (float)(-Math.PI / 2) + HeadPart.XRot;
                break;
            case ArmPose.ThrowTrident:
                LeftArm.XRot = LeftArm.XRot * 0.5F - (float)Math.PI;
                LeftArm.YRot = 0.0F;
                break;
            case ArmPose.CrossbowCharge:
                AnimationUtils.AnimateCrossbowCharge(RightArm, LeftArm, state.MaxCrossbowChargeDuration, state.TicksUsingItemValue, false);
                break;
            case ArmPose.CrossbowHold:
                AnimationUtils.AnimateCrossbowHold(RightArm, LeftArm, HeadPart, false);
                break;
            case ArmPose.Spyglass:
                LeftArm.XRot = Mth.Clamp(HeadPart.XRot - 1.9198622F - (state.IsCrouching ? (float)(Math.PI / 12) : 0.0F), -2.4F, 3.3F);
                LeftArm.YRot = HeadPart.YRot + (float)(Math.PI / 12);
                break;
            case ArmPose.TootHorn:
                LeftArm.XRot = Mth.Clamp(HeadPart.XRot, -1.2F, 1.2F) - 1.4835298F;
                LeftArm.YRot = HeadPart.YRot + (float)(Math.PI / 6);
                break;
            case ArmPose.Brush:
                LeftArm.XRot = LeftArm.XRot * 0.5F - (float)(Math.PI / 5);
                LeftArm.YRot = 0.0F;
                break;
            case ArmPose.Spear:
                SpearAnimations.ThirdPersonHandUse(LeftArm, HeadPart, false, state.GetUseItemStackForArm(HumanoidArm.Left), state);
                break;
        }
    }

    private void PoseBlockingArm(ModelPart arm, bool right) {
        arm.XRot = arm.XRot * 0.5F - 0.9424779F + Mth.Clamp(HeadPart.XRot, (float)(-Math.PI * 4.0 / 9.0), 0.43633232F);
        arm.YRot = (right ? -30.0F : 30.0F) * (float)(Math.PI / 180.0) + Mth.Clamp(HeadPart.YRot, (float)(-Math.PI / 6), (float)(Math.PI / 6));
    }

    protected virtual void SetupAttackAnimation(S state) {
        float attackTime = state.AttackTime;
        if (!(attackTime <= 0.0F)) {
            Body.YRot = Mth.Sin(Mth.Sqrt(attackTime) * (float)(Math.PI * 2)) * 0.2F;
            if (state.AttackArm == HumanoidArm.Left) {
                Body.YRot *= -1.0F;
            }
            float ageScale = state.AgeScale;
            RightArm.Z = Mth.Sin(Body.YRot) * 5.0F * ageScale;
            RightArm.X = -Mth.Cos(Body.YRot) * 5.0F * ageScale;
            LeftArm.Z = -Mth.Sin(Body.YRot) * 5.0F * ageScale;
            LeftArm.X = Mth.Cos(Body.YRot) * 5.0F * ageScale;
            RightArm.YRot += Body.YRot;
            LeftArm.YRot += Body.YRot;
            LeftArm.XRot += Body.YRot;
            switch (state.SwingAnimationType) {
                case SwingAnimationType.Whack:
                    // Ease.outQuart.
                    float swing = 1.0F - Mth.Square(Mth.Square(1.0F - attackTime));
                    float aa = Mth.Sin(swing * (float)Math.PI);
                    float bb = Mth.Sin(attackTime * (float)Math.PI) * -(HeadPart.XRot - 0.7F) * 0.75F;
                    ModelPart attackArm = GetArm(state.AttackArm);
                    attackArm.XRot -= aa * 1.2F + bb;
                    attackArm.YRot += Body.YRot * 2.0F;
                    attackArm.ZRot += Mth.Sin(attackTime * (float)Math.PI) * -0.4F;
                    break;
                case SwingAnimationType.Stab:
                    SpearAnimations.ThirdPersonAttackHand(this, state);
                    break;
            }
        }
    }

    private static float QuadraticArmUpdate(float x) => -65.0F * x + x * x;

    public virtual void TranslateToHand(S state, HumanoidArm arm, PoseStack pose) {
        Root.TranslateAndRotate(pose);
        GetArm(arm).TranslateAndRotate(pose);
    }

    public ModelPart GetArm(HumanoidArm arm) => arm == HumanoidArm.Left ? LeftArm : RightArm;
}
