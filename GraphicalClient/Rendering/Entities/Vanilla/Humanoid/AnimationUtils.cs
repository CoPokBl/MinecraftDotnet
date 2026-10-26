using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>HumanoidModel.ArmPose</c>'s behaviour.</summary>
public static class ArmPoseBehaviour {
    public static bool IsTwoHanded(this ArmPose pose) => pose is ArmPose.BowAndArrow or ArmPose.CrossbowCharge or ArmPose.CrossbowHold;

    public static bool AffectsOffhandPose(this ArmPose pose) =>
        pose is ArmPose.BowAndArrow or ArmPose.ThrowTrident or ArmPose.CrossbowCharge or ArmPose.CrossbowHold or ArmPose.Spear;
}

/// <summary><c>AnimationUtils</c>.</summary>
public static class AnimationUtils {
    public static void AnimateCrossbowHold(ModelPart rightArm, ModelPart leftArm, ModelPart head, bool holdingInRightArm) {
        ModelPart holdingArm = holdingInRightArm ? rightArm : leftArm;
        ModelPart shootingArm = holdingInRightArm ? leftArm : rightArm;
        holdingArm.YRot = (holdingInRightArm ? -0.3F : 0.3F) + head.YRot;
        shootingArm.YRot = (holdingInRightArm ? 0.6F : -0.6F) + head.YRot;
        holdingArm.XRot = (float)(-Math.PI / 2) + head.XRot + 0.1F;
        shootingArm.XRot = -1.5F + head.XRot;
    }

    public static void AnimateCrossbowCharge(ModelPart rightArm, ModelPart leftArm, float maxCrossbowChargeDuration, float ticksUsingItem, bool holdingInRightArm) {
        ModelPart holdingArm = holdingInRightArm ? rightArm : leftArm;
        ModelPart pullingArm = holdingInRightArm ? leftArm : rightArm;
        holdingArm.YRot = holdingInRightArm ? -0.8F : 0.8F;
        holdingArm.XRot = -0.97079635F;
        pullingArm.XRot = holdingArm.XRot;
        float useTicks = Mth.Clamp(ticksUsingItem, 0.0F, maxCrossbowChargeDuration);
        float lerpAlpha = useTicks / maxCrossbowChargeDuration;
        pullingArm.YRot = Mth.Lerp(lerpAlpha, 0.4F, 0.85F) * (holdingInRightArm ? 1 : -1);
        pullingArm.XRot = Mth.Lerp(lerpAlpha, pullingArm.XRot, (float)(-Math.PI / 2));
    }

    public static void SwingWeaponDown(ModelPart rightArm, ModelPart leftArm, HumanoidArm mainArm, float attackTime, float ageInTicks) {
        float attack2 = Mth.Sin(attackTime * (float)Math.PI);
        float attack = Mth.Sin((1.0F - (1.0F - attackTime) * (1.0F - attackTime)) * (float)Math.PI);
        rightArm.ZRot = 0.0F;
        leftArm.ZRot = 0.0F;
        rightArm.YRot = (float)(Math.PI / 20);
        leftArm.YRot = (float)(-Math.PI / 20);
        if (mainArm == HumanoidArm.Right) {
            rightArm.XRot = -1.8849558F + Mth.Cos(ageInTicks * 0.09F) * 0.15F;
            leftArm.XRot = -0.0F + Mth.Cos(ageInTicks * 0.19F) * 0.5F;
            rightArm.XRot += attack2 * 2.2F - attack * 0.4F;
            leftArm.XRot += attack2 * 1.2F - attack * 0.4F;
        }
        else {
            rightArm.XRot = -0.0F + Mth.Cos(ageInTicks * 0.19F) * 0.5F;
            leftArm.XRot = -1.8849558F + Mth.Cos(ageInTicks * 0.09F) * 0.15F;
            rightArm.XRot += attack2 * 1.2F - attack * 0.4F;
            leftArm.XRot += attack2 * 2.2F - attack * 0.4F;
        }
        BobArms(rightArm, leftArm, ageInTicks);
    }

    public static void BobModelPart(ModelPart modelPart, float ageInTicks, float scale) {
        modelPart.ZRot += scale * (Mth.Cos(ageInTicks * 0.09F) * 0.05F + 0.05F);
        modelPart.XRot += scale * (Mth.Sin(ageInTicks * 0.067F) * 0.05F);
    }

    public static void BobArms(ModelPart rightArm, ModelPart leftArm, float ageInTicks) {
        BobModelPart(rightArm, ageInTicks, 1.0F);
        BobModelPart(leftArm, ageInTicks, -1.0F);
    }

    public static void AnimateZombieArms<T>(ModelPart leftArm, ModelPart rightArm, bool aggressive, T state) where T : UndeadRenderState {
        bool animateAttack = state.SwingAnimationType != SwingAnimationType.Stab;
        if (animateAttack) {
            // getMainHandItemStack() == ItemStack.EMPTY is an identity test; an empty hand is the one
            // shared empty stack, which IsAir stands in for.
            bool raiseArms = !state.IsBaby || state.MainHandItemStack.IsAir();
            float armDrop = raiseArms ? (float)-Math.PI / (aggressive ? 1.5F : 2.25F) : 0.0F;
            AnimateAttackArms(leftArm, rightArm, state.AttackTime, raiseArms, armDrop);
        }
        BobArms(rightArm, leftArm, state.AgeInTicks);
    }

    private static void AnimateAttackArms(ModelPart leftArm, ModelPart rightArm, float attackTime, bool negateArmRotation, float armDrop) {
        float attackYRotModifier = (negateArmRotation ? 1.0F : -1.0F) * Mth.Sin(attackTime * (float)Math.PI);
        float attackXRotModifier = Mth.Sin((1.0F - (1.0F - attackTime) * (1.0F - attackTime)) * (float)Math.PI);
        float xRot = armDrop + attackYRotModifier * 1.2F - attackXRotModifier * 0.4F;
        float yRot = 0.1F - attackYRotModifier * 0.6F;
        rightArm.XRot = xRot;
        rightArm.YRot = negateArmRotation ? -yRot : yRot;
        rightArm.ZRot = 0.0F;
        leftArm.XRot = xRot;
        leftArm.YRot = negateArmRotation ? yRot : -yRot;
        leftArm.ZRot = 0.0F;
    }
}
