using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>AbstractPiglinModel</c>.</summary>
public abstract class AbstractPiglinModel<S> : HumanoidModel<S> where S : HumanoidRenderState {
    public readonly ModelPart RightEar;
    public readonly ModelPart LeftEar;

    protected AbstractPiglinModel(ModelPart root) : base(root) {
        RightEar = HeadPart.GetChild("right_ear");
        LeftEar = HeadPart.GetChild("left_ear");
    }

    /// <summary><c>entityTranslucent</c>.</summary>
    public override bool Translucent => true;

    public new static ArmorModelSet<MeshDefinition> CreateArmorMeshSet(CubeDeformation innerDeformation, CubeDeformation outerDeformation) =>
        PlayerModel.CreateArmorMeshSet(innerDeformation, outerDeformation).Map(RemoveEars);

    private static MeshDefinition RemoveEars(MeshDefinition mesh) {
        PartDefinition root = mesh.Root;
        PartDefinition head = root.GetChild("head");
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create(), PartPose.Zero);
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create(), PartPose.Zero);
        return mesh;
    }

    public static PartDefinition AddHead(CubeDeformation g, MeshDefinition mesh) {
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head",
            CubeListBuilder.Create()
                .TexOffs(0, 0)
                .AddBox(-5.0F, -8.0F, -4.0F, 10.0F, 8.0F, 8.0F, g)
                .TexOffs(31, 1)
                .AddBox(-2.0F, -4.0F, -5.0F, 4.0F, 4.0F, 1.0F, g)
                .TexOffs(2, 4)
                .AddBox(2.0F, -2.0F, -5.0F, 1.0F, 2.0F, 1.0F, g)
                .TexOffs(2, 0)
                .AddBox(-3.0F, -2.0F, -5.0F, 1.0F, 2.0F, 1.0F, g),
            PartPose.Zero);
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(51, 6).AddBox(0.0F, 0.0F, -2.0F, 1.0F, 5.0F, 4.0F, g),
            PartPose.OffsetAndRotation(4.5F, -6.0F, 0.0F, 0.0F, 0.0F, (float)(-Math.PI / 6)));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(39, 6).AddBox(-1.0F, 0.0F, -2.0F, 1.0F, 5.0F, 4.0F, g),
            PartPose.OffsetAndRotation(-4.5F, -6.0F, 0.0F, 0.0F, 0.0F, (float)(Math.PI / 6)));
        return head;
    }

    public new static ArmorModelSet<MeshDefinition> CreateBabyArmorMeshSet(CubeDeformation innerDeformation, CubeDeformation outerDeformation, PartPose armOffset) =>
        PlayerModel.CreateBabyArmorMeshSet(innerDeformation, outerDeformation, armOffset).Map(RemoveEars);

    public override void SetupAnim(S state) {
        base.SetupAnim(state);
        float animationPos = state.WalkAnimationPos;
        float animationSpeed = state.WalkAnimationSpeed;
        float defaultAngle = GetDefaultEarAngleInDegrees() * (float)(Math.PI / 180.0);
        float frequency = state.AgeInTicks * 0.1F + animationPos * 0.5F;
        float amplitude = 0.08F + animationSpeed * 0.4F;
        LeftEar.ZRot = -defaultAngle - Mth.Cos(frequency * 1.2F) * amplitude;
        RightEar.ZRot = defaultAngle + Mth.Cos(frequency) * amplitude;
    }

    protected abstract float GetDefaultEarAngleInDegrees();
}

/// <summary><c>PiglinModel</c>.</summary>
public abstract class PiglinModel : AbstractPiglinModel<PiglinRenderState> {
    protected PiglinModel(ModelPart root) : base(root) { }

    public override void SetupAnim(PiglinRenderState state) {
        base.SetupAnim(state);
        float attackTime = state.AttackTime;
        PiglinArmPose pose = state.ArmPose;
        if (pose == PiglinArmPose.Dancing) {
            float dancePos = state.AgeInTicks / 60.0F;
            RightEar.ZRot = (float)(Math.PI / 6) + (float)(Math.PI / 180.0) * Mth.Sin(dancePos * 30.0F) * 10.0F;
            LeftEar.ZRot = (float)(-Math.PI / 6) - (float)(Math.PI / 180.0) * Mth.Cos(dancePos * 30.0F) * 10.0F;
            HeadPart.X += Mth.Sin(dancePos * 10.0F);
            HeadPart.Y += Mth.Sin(dancePos * 40.0F) + 0.4F;
            RightArm.ZRot = (float)(Math.PI / 180.0) * (70.0F + Mth.Cos(dancePos * 40.0F) * 10.0F);
            LeftArm.ZRot = RightArm.ZRot * -1.0F;
            RightArm.Y += Mth.Sin(dancePos * 40.0F) * 0.5F - 0.5F;
            LeftArm.Y += Mth.Sin(dancePos * 40.0F) * 0.5F + 0.5F;
            Body.Y += Mth.Sin(dancePos * 40.0F) * 0.35F;
        }
        else if (pose == PiglinArmPose.AttackingWithMeleeWeapon && attackTime == 0.0F) {
            HoldWeaponHigh(state);
        }
        else if (pose == PiglinArmPose.CrossbowHold) {
            AnimationUtils.AnimateCrossbowHold(RightArm, LeftArm, HeadPart, state.MainArm == HumanoidArm.Right);
        }
        else if (pose == PiglinArmPose.CrossbowCharge) {
            AnimationUtils.AnimateCrossbowCharge(RightArm, LeftArm, state.MaxCrossbowChageDuration, state.TicksUsingItemValue, state.MainArm == HumanoidArm.Right);
        }
        else if (pose == PiglinArmPose.AdmiringItem) {
            HeadPart.XRot = 0.5F;
            HeadPart.YRot = 0.0F;
            if (state.MainArm == HumanoidArm.Left) {
                RightArm.YRot = -0.5F;
                RightArm.XRot = -0.9F;
            }
            else {
                LeftArm.YRot = 0.5F;
                LeftArm.XRot = -0.9F;
            }
        }
    }

    protected override void SetupAttackAnimation(PiglinRenderState state) {
        float attackTime = state.AttackTime;
        if (attackTime > 0.0F && state.ArmPose == PiglinArmPose.AttackingWithMeleeWeapon) {
            AnimationUtils.SwingWeaponDown(RightArm, LeftArm, state.MainArm, attackTime, state.AgeInTicks);
        }
        else {
            base.SetupAttackAnimation(state);
        }
    }

    private void HoldWeaponHigh(PiglinRenderState state) {
        if (state.MainArm == HumanoidArm.Left) {
            LeftArm.XRot = -1.8F;
        }
        else {
            RightArm.XRot = -1.8F;
        }
    }
}

/// <summary><c>AdultPiglinModel</c>.</summary>
public sealed class AdultPiglinModel : PiglinModel {
    public AdultPiglinModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = PlayerModel.CreateMesh(CubeDeformation.None, false);
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(16, 16).AddBox(-4.0F, 0.0F, -2.0F, 8.0F, 12.0F, 4.0F), PartPose.Zero);
        PartDefinition head = AddHead(CubeDeformation.None, mesh);
        head.ClearChild("hat");
        return LayerDefinition.Create(mesh, 64, 64);
    }

    protected override float GetDefaultEarAngleInDegrees() => 30.0F;
}

/// <summary><c>BabyPiglinModel</c>.</summary>
public sealed class BabyPiglinModel : PiglinModel {
    public BabyPiglinModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 13).AddBox(-3.0F, -3.0F, -1.0F, 6.0F, 5.0F, 3.0F), PartPose.Offset(0.0F, 18.0F, -0.5F));
        PartDefinition head = root.AddOrReplaceChild("head",
            CubeListBuilder.Create().TexOffs(21, 30).AddBox(-1.5F, -3.0F, -4.5F, 3.0F, 3.0F, 1.0F).TexOffs(0, 0).AddBox(-4.5F, -6.0F, -3.5F, 9.0F, 6.0F, 7.0F),
            PartPose.Offset(0.0F, 15.0F, 0.0F));
        head.AddOrReplaceChild("hat", CubeListBuilder.Create(), PartPose.Offset(0.0F, 0.0F, 0.0F));
        PartDefinition leftear = head.AddOrReplaceChild("left_ear", CubeListBuilder.Create(), PartPose.Offset(4.2F, -4.0F, 0.0F));
        leftear.AddOrReplaceChild("left_ear_r1", CubeListBuilder.Create().TexOffs(0, 21).AddBox(-0.5F, -3.0F, -2.0F, 1.0F, 6.0F, 4.0F),
            PartPose.OffsetAndRotation(1.0F, 1.75F, 0.0F, 0.0F, 0.0F, -0.6109F));
        PartDefinition rightear = head.AddOrReplaceChild("right_ear", CubeListBuilder.Create(), PartPose.Offset(-4.2F, -4.0F, 0.0F));
        rightear.AddOrReplaceChild("right_ear_r1", CubeListBuilder.Create().TexOffs(18, 13).AddBox(-0.5F, -3.0F, -2.0F, 1.0F, 6.0F, 4.0F),
            PartPose.OffsetAndRotation(-1.0F, 1.75F, 0.0F, 0.0F, 0.0F, 0.6109F));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(28, 13).AddBox(-1.0F, 0.0F, -1.5F, 2.0F, 5.0F, 3.0F), PartPose.Offset(4.0F, 15.0F, 0.0F));
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(10, 30).AddBox(-1.0F, 0.0F, -1.5F, 2.0F, 5.0F, 3.0F), PartPose.Offset(-4.0F, 15.0F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(22, 23).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 4.0F, 3.0F), PartPose.Offset(-1.5F, 20.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(10, 23).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 4.0F, 3.0F), PartPose.Offset(1.5F, 20.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    protected override float GetDefaultEarAngleInDegrees() => 5.0F;
}

/// <summary><c>ZombifiedPiglinModel</c>.</summary>
public abstract class ZombifiedPiglinModel : AbstractPiglinModel<ZombifiedPiglinRenderState> {
    protected ZombifiedPiglinModel(ModelPart root) : base(root) { }

    public override void SetupAnim(ZombifiedPiglinRenderState state) {
        base.SetupAnim(state);
        AnimationUtils.AnimateZombieArms(LeftArm, RightArm, state.IsAggressive, state);
    }
}

/// <summary><c>AdultZombifiedPiglinModel</c>.</summary>
public sealed class AdultZombifiedPiglinModel : ZombifiedPiglinModel {
    public AdultZombifiedPiglinModel(ModelPart root) : base(root) { }

    protected override float GetDefaultEarAngleInDegrees() => 30.0F;

    public static LayerDefinition CreateBodyLayer() => AdultPiglinModel.CreateBodyLayer();
}

/// <summary><c>BabyZombifiedPiglinModel</c>.</summary>
public sealed class BabyZombifiedPiglinModel : ZombifiedPiglinModel {
    public BabyZombifiedPiglinModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() => BabyPiglinModel.CreateBodyLayer();

    protected override float GetDefaultEarAngleInDegrees() => 5.0F;
}
