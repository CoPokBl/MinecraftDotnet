using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>SpearAnimations</c>: a kinetic weapon's raise, sway and lowering while used, and the stab.</summary>
public static class SpearAnimations {
    private const float DegToRad = (float)(Math.PI / 180.0);

    /// <summary><c>progress</c>, with <c>Mth.clamp</c>'s treatment of NaN: an empty range stays NaN.</summary>
    private static float Progress(float time, float start, float end) {
        float value = (time - start) / (end - start);
        return value < 0.0F ? 0.0F : Math.Min(value, 1.0F);
    }

    /// <summary><c>PoseStack.rotateAround</c> about the X axis.</summary>
    private static void RotateXAround(PoseStack pose, float degrees, float x, float y, float z) {
        pose.Translate(x, y, z);
        pose.RotateXDegrees(degrees);
        pose.Translate(-x, -y, -z);
    }

    private static void RotateYAround(PoseStack pose, float degrees, float x, float y, float z) {
        pose.Translate(x, y, z);
        pose.RotateYDegrees(degrees);
        pose.Translate(-x, -y, -z);
    }

    public static void ThirdPersonHandUse<S>(ModelPart arm, ModelPart head, bool holdingInRightArm, ItemStack item, S state) where S : HumanoidRenderState {
        int invert = holdingInRightArm ? 1 : -1;
        arm.YRot = -0.1F * invert + head.YRot;
        arm.XRot = (float)(-Math.PI / 2) + head.XRot + 0.8F;
        if (state.IsFallFlying || state.SwimAmount > 0.0F) {
            arm.XRot -= 0.9599311F;
        }
        arm.YRot = DegToRad * Math.Clamp(180.0F / (float)Math.PI * arm.YRot, -60.0F, 60.0F);
        arm.XRot = DegToRad * Math.Clamp(180.0F / (float)Math.PI * arm.XRot, -120.0F, 30.0F);
        if (!(state.TicksUsingItemValue <= 0.0F) && (!state.IsUsingItem || state.UseItemHand == (holdingInRightArm ? Hand.MainHand : Hand.OffHand))
            && item.GetOrNull(DataComponent.KineticWeapon) is { } kineticWeapon) {
            UseParams p = UseParams.FromKineticWeapon(kineticWeapon, state.TicksUsingItemValue);
            arm.YRot = arm.YRot + -invert * p.SwayScaleFast * DegToRad * p.SwayIntensity * 1.0F;
            arm.ZRot = arm.ZRot + -invert * p.SwayScaleSlow * DegToRad * p.SwayIntensity * 0.5F;
            arm.XRot = arm.XRot + DegToRad * (-40.0F * p.RaiseProgressStart + 30.0F * p.RaiseProgressMiddle + -20.0F * p.RaiseProgressEnd
                + 20.0F * p.LowerProgress + 10.0F * p.RaiseBackProgress + 0.6F * p.SwayScaleSlow * p.SwayIntensity);
        }
    }

    public static void ThirdPersonUseItem(ArmedEntityRenderState state, PoseStack pose, float timeHeld, HumanoidArm arm, ItemStack actualItem) {
        if (actualItem.GetOrNull(DataComponent.KineticWeapon) is not { } kineticWeapon || timeHeld == 0.0F) {
            return;
        }
        float attack = Ease.InQuad(Progress(state.AttackTime, 0.05F, 0.2F));
        float retract = Ease.InOutExpo(Progress(state.AttackTime, 0.4F, 1.0F));
        UseParams p = UseParams.FromKineticWeapon(kineticWeapon, timeHeld);
        int invert = arm == HumanoidArm.Right ? 1 : -1;
        float raiseProgressModified = 1.0F - Ease.OutBack(1.0F - p.RaiseProgress);
        float hitFeedback = HitFeedbackAmount(state.TicksSinceKineticHitFeedback);
        pose.Translate(0.0F, (float)(-hitFeedback * 0.4), -kineticWeapon.ForwardMovement * (raiseProgressModified - p.RaiseBackProgress) + hitFeedback);
        // Axis.XN: about the negative X axis.
        RotateXAround(pose, -(70.0F * (p.RaiseProgress - p.RaiseBackProgress) - 40.0F * (attack - retract)), 0.0F, -0.03125F, 0.125F);
        RotateYAround(pose, invert * 90 * (p.RaiseProgress - p.SwayProgress + 3.0F * retract + attack), 0.0F, 0.0F, 0.125F);
    }

    public static void ThirdPersonAttackHand<S>(HumanoidModel<S> model, S state) where S : HumanoidRenderState {
        float attackTime = state.AttackTime;
        model.RightArm.YRot = model.RightArm.YRot - model.Body.YRot;
        model.LeftArm.YRot = model.LeftArm.YRot - model.Body.YRot;
        model.LeftArm.XRot = model.LeftArm.XRot - model.Body.YRot;
        float prepare = Ease.InOutSine(Progress(attackTime, 0.0F, 0.05F));
        float attack = Ease.InQuad(Progress(attackTime, 0.05F, 0.2F));
        float retract = Ease.InOutExpo(Progress(attackTime, 0.4F, 1.0F));
        model.GetArm(state.AttackArm).XRot += (90.0F * prepare - 120.0F * attack + 30.0F * retract) * DegToRad;
    }

    public static void ThirdPersonAttackItem(ArmedEntityRenderState state, PoseStack pose) {
        if (state.AttackTime <= 0.0F) {
            return;
        }
        float jetForward = state.MainHandItemStack.GetOrNull(DataComponent.KineticWeapon)?.ForwardMovement ?? 0.0F;
        float attackTime = state.AttackTime;
        float attack = Ease.InQuad(Progress(attackTime, 0.05F, 0.2F));
        float retract = Ease.InOutExpo(Progress(attackTime, 0.4F, 1.0F));
        RotateXAround(pose, -(70.0F * (attack - retract)), 0.0F, -0.125F, 0.125F);
        pose.Translate(0.0F, jetForward * (attack - retract), 0.0F);
    }

    public static float HitFeedbackAmount(float ticksSinceFeedbackStart) =>
        0.4F * (Ease.OutQuart(Progress(ticksSinceFeedbackStart, 1.0F, 3.0F)) - Ease.InOutSine(Progress(ticksSinceFeedbackStart, 3.0F, 10.0F)));

    public static void FirstPersonUse(float ticksSinceKineticHitFeedback, PoseStack pose, float timeHeld, HumanoidArm arm, ItemStack itemStack) {
        if (itemStack.GetOrNull(DataComponent.KineticWeapon) is not { } kineticWeapon) {
            return;
        }
        UseParams p = UseParams.FromKineticWeapon(kineticWeapon, timeHeld);
        int invert = arm == HumanoidArm.Right ? 1 : -1;
        pose.Translate(invert * (p.RaiseProgress * 0.15F + p.RaiseProgressEnd * -0.05F + p.SwayProgress * -0.1F + p.SwayScaleSlow * 0.005F),
            p.RaiseProgress * -0.075F + p.RaiseProgressMiddle * 0.075F + p.SwayScaleFast * 0.01F,
            (float)(p.RaiseProgressStart * 0.05 + p.RaiseProgressEnd * -0.05 + p.SwayScaleSlow * 0.005F));
        RotateXAround(pose, -65.0F * Ease.InOutBack(p.RaiseProgress) - 35.0F * p.LowerProgress + 100.0F * p.RaiseBackProgress + -0.5F * p.SwayScaleFast,
            0.0F, 0.1F, 0.0F);
        // Axis.YN: about the negative Y axis.
        RotateYAround(pose, -(invert * (-90.0F * Progress(p.RaiseProgress, 0.5F, 0.55F) + 90.0F * p.SwayProgress + 2.0F * p.SwayScaleSlow)),
            invert * 0.15F, 0.0F, 0.0F);
        pose.Translate(0.0F, -HitFeedbackAmount(ticksSinceKineticHitFeedback), 0.0F);
    }

    public static void FirstPersonAttack(float attack, PoseStack pose, int invert) {
        float startingAmount = Ease.InOutSine(Progress(attack, 0.0F, 0.05F));
        float middleAmount = Ease.OutBack(Progress(attack, 0.05F, 0.2F));
        float endingAmount = Ease.InOutExpo(Progress(attack, 0.4F, 1.0F));
        pose.Translate(invert * 0.1F * (startingAmount - middleAmount), -0.075F * (startingAmount - endingAmount), 0.65F * (startingAmount - middleAmount));
        pose.RotateXDegrees(-70.0F * (startingAmount - endingAmount));
        pose.Translate(0.0F, 0.0F, (float)(-0.25 * (endingAmount - middleAmount)));
    }

    /// <summary><c>SpearAnimations.UseParams</c>.</summary>
    public readonly record struct UseParams(float RaiseProgress, float RaiseProgressStart, float RaiseProgressMiddle, float RaiseProgressEnd,
        float SwayProgress, float LowerProgress, float RaiseBackProgress, float SwayIntensity, float SwayScaleSlow, float SwayScaleFast) {
        public static UseParams FromKineticWeapon(KineticWeaponComponent.Data kineticWeapon, float time) {
            int finishRaisingTick = kineticWeapon.DelayTicks;
            int finishSwayingTick = (kineticWeapon.DismountConditions?.MaxDurationTicks ?? 0) + finishRaisingTick;
            int startSwayingTick = finishSwayingTick - 20;
            int finishLoweringTick = (kineticWeapon.KnockbackConditions?.MaxDurationTicks ?? 0) + finishRaisingTick;
            int startLoweringTick = finishLoweringTick - 40;
            int finishRaisingBackTick = (kineticWeapon.DamageConditions?.MaxDurationTicks ?? 0) + finishRaisingTick;
            float raiseProgress = Progress(time, 0.0F, finishRaisingTick);
            float raiseProgressStart = Progress(raiseProgress, 0.0F, 0.5F);
            float raiseProgressMiddle = Progress(raiseProgress, 0.5F, 0.8F);
            float raiseProgressEnd = Progress(raiseProgress, 0.8F, 1.0F);
            float swayProgress = Progress(time, startSwayingTick, finishSwayingTick);
            float lowerProgress = Ease.OutCubic(Ease.InOutElastic(Progress(time - 20.0F, startLoweringTick, finishLoweringTick)));
            float raiseBackProgress = Progress(time, finishRaisingBackTick - 5, finishRaisingBackTick);
            float swayIntensity = 2.0F * Ease.OutCirc(swayProgress) - 2.0F * Ease.InCirc(raiseBackProgress);
            float swayScaleSlow = Mth.Sin(time * 19.0F * DegToRad) * swayIntensity;
            float swayScaleFast = Mth.Sin(time * 30.0F * DegToRad) * swayIntensity;
            return new UseParams(raiseProgress, raiseProgressStart, raiseProgressMiddle, raiseProgressEnd, swayProgress, lowerProgress, raiseBackProgress,
                swayIntensity, swayScaleSlow, swayScaleFast);
        }
    }
}
