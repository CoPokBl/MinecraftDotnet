using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>HumanoidModel.ArmPose</c>. Its behaviour (<c>isTwoHanded</c>, <c>animateUseItem</c>) lives with
/// <c>HumanoidModel</c>'s port.
/// </summary>
public enum ArmPose {
    Empty,
    Item,
    Block,
    BowAndArrow,
    ThrowTrident,
    CrossbowCharge,
    CrossbowHold,
    Spyglass,
    TootHorn,
    Brush,
    Spear
}

/// <summary><c>ArmedEntityRenderState</c>.</summary>
public class ArmedEntityRenderState : LivingEntityRenderState {
    public HumanoidArm MainArm = HumanoidArm.Right;
    public HumanoidArm AttackArm = HumanoidArm.Right;
    public ArmPose RightArmPose = ArmPose.Empty;
    public ItemStackModel? RightHandItemState;
    public ItemStack RightHandItemStack = ItemStack.Air;
    public ArmPose LeftArmPose = ArmPose.Empty;
    public ItemStackModel? LeftHandItemState;
    public ItemStack LeftHandItemStack = ItemStack.Air;
    public SwingAnimationType SwingAnimationType = SwingAnimationType.Whack;
    public float AttackTime;

    public ItemStackModel? MainHandItemState => MainArm == HumanoidArm.Right ? RightHandItemState : LeftHandItemState;
    public ItemStack MainHandItemStack => MainArm == HumanoidArm.Right ? RightHandItemStack : LeftHandItemStack;
    public ItemStack UseItemStackForArm(HumanoidArm arm) => arm == HumanoidArm.Right ? RightHandItemStack : LeftHandItemStack;

    public virtual float TicksUsingItem(HumanoidArm arm) => 0.0F;

    /// <summary><c>LivingEntity.getMainArm</c>: an avatar's synced choice, a mob's left handed flag, otherwise right.</summary>
    public static HumanoidArm MainArmOf(ClientEntity entity) {
        if (entity.Is(EntityClass.Avatar)) {
            return entity.Get(EntityDataFields.Avatar.PlayerMainHand, HumanoidArm.Right);
        }
        if (entity.Is(EntityClass.Mob)) {
            // Mob.isLeftHanded: bit 2 of DATA_MOB_FLAGS_ID.
            return (entity.Get(EntityDataFields.Mob.MobFlags) & 2) != 0 ? HumanoidArm.Left : HumanoidArm.Right;
        }
        return HumanoidArm.Right;
    }

    public static HumanoidArm Opposite(HumanoidArm arm) => arm == HumanoidArm.Right ? HumanoidArm.Left : HumanoidArm.Right;

    /// <summary><c>LivingEntity.getItemHeldByArm</c>.</summary>
    public static ItemStack ItemHeldByArm(ClientEntity entity, HumanoidArm arm) =>
        entity.ItemInHand(MainArmOf(entity) == arm ? Hand.MainHand : Hand.OffHand);

    /// <summary><c>ArmedEntityRenderState.extractArmedEntityRenderState</c>.</summary>
    public static void ExtractArmedEntityRenderState(ClientEntity entity, ArmedEntityRenderState state, ItemRenderer items, float partialTick) {
        state.MainArm = MainArmOf(entity);
        state.AttackArm = entity.CurrentSwing?.Hand != Hand.OffHand ? state.MainArm : Opposite(state.MainArm);
        state.SwingAnimationType = entity.CurrentSwing?.Animation.Type ?? SwingAnimationType.Whack;
        state.AttackTime = entity.GetSwingAnimation(partialTick);
        state.RightHandItemStack = ItemHeldByArm(entity, HumanoidArm.Right);
        state.LeftHandItemStack = ItemHeldByArm(entity, HumanoidArm.Left);
        state.RightHandItemState = state.RightHandItemStack.IsAir() ? null
            : items.Resolve(state.RightHandItemStack, ItemDisplayContext.ThirdPersonRightHand, entity, HandOf(entity, HumanoidArm.Right));
        state.LeftHandItemState = state.LeftHandItemStack.IsAir() ? null
            : items.Resolve(state.LeftHandItemStack, ItemDisplayContext.ThirdPersonLeftHand, entity, HandOf(entity, HumanoidArm.Left));
    }

    /// <summary>The hand an arm holds with, which is how a stack an arm holds is told apart from the entity's other stacks.</summary>
    private static Hand HandOf(ClientEntity entity, HumanoidArm arm) => MainArmOf(entity) == arm ? Hand.MainHand : Hand.OffHand;
}

/// <summary><c>ArmedModel</c>.</summary>
public interface IArmedModel<in S> where S : EntityRenderState {
    void TranslateToHand(S state, HumanoidArm arm, PoseStack pose);
}

/// <summary><c>HeadedModel</c>.</summary>
public interface IHeadedModel {
    ModelPart Head { get; }

    void TranslateToHead(PoseStack pose) => Head.TranslateAndRotate(pose);
}
