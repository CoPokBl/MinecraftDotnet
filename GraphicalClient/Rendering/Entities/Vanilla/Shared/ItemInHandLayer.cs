using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ItemInHandLayer</c>.</summary>
public class ItemInHandLayer<S, M> : RenderLayer<S, M>
    where S : ArmedEntityRenderState, new()
    where M : EntityModel<S>, IArmedModel<S> {
    private readonly ItemRenderer _items;

    public ItemInHandLayer(LivingEntityRenderer<S, M> parent, ItemRenderer items) : base(parent) {
        _items = items;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        SubmitArmWithItem(state, state.RightHandItemState, state.RightHandItemStack, HumanoidArm.Right, pose, context);
        SubmitArmWithItem(state, state.LeftHandItemState, state.LeftHandItemStack, HumanoidArm.Left, pose, context);
    }

    protected virtual void SubmitArmWithItem(S state, ItemStackModel? item, ItemStack stack, HumanoidArm arm, PoseStack pose, EntityRenderContext context) {
        if (item == null) {
            return;
        }
        pose.Push();
        Parent.CurrentModel.TranslateToHand(state, arm, pose);
        pose.RotateXDegrees(-90.0F);
        pose.RotateYDegrees(180.0F);
        bool isLeftHand = arm == HumanoidArm.Left;
        bool babyOffset = UseBabyOffset(state);
        float offsetX = babyOffset ? 0.0F : 1.0F;
        float offsetY = babyOffset ? 1.0F : 2.0F;
        float offsetZ = babyOffset ? -4.5F : -10.0F;
        pose.Translate((isLeftHand ? -1 : 1) * offsetX / 16.0F, offsetY / 16.0F, offsetZ / 16.0F);
        if (state.AttackTime > 0.0F && state.AttackArm == arm && state.SwingAnimationType == SwingAnimationType.Stab) {
            SpearAnimations.ThirdPersonAttackItem(state, pose);
        }
        float ticksUsingItem = state.TicksUsingItem(arm);
        // ArmPose.animateUseItem, which only the spear's pose overrides.
        if (ticksUsingItem != 0.0F && (arm == HumanoidArm.Right ? state.RightArmPose : state.LeftArmPose) == ArmPose.Spear) {
            SpearAnimations.ThirdPersonUseItem(state, pose, ticksUsingItem, arm, stack);
        }
        _items.Submit(item, isLeftHand ? ItemDisplayContext.ThirdPersonLeftHand : ItemDisplayContext.ThirdPersonRightHand, pose, context.Batch,
            state.SkyLight, state.BlockLight);
        pose.Pop();
    }

    private static bool UseBabyOffset(S state) => state.IsBaby && !state.EntityType.Equals(EntityType.ArmorStand);
}
