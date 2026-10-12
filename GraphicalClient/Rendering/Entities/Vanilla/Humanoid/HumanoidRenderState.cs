using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>HumanoidRenderState</c>.</summary>
public class HumanoidRenderState : ArmedEntityRenderState {
    public float SwimAmount;
    public float SpeedValue = 1.0F;
    public float MaxCrossbowChargeDuration;
    public float TicksUsingItemValue;
    public Hand UseItemHand = Hand.MainHand;
    public bool IsCrouching;
    public bool IsFallFlying;
    public bool IsVisuallySwimming;
    public bool IsPassenger;
    public bool IsUsingItem;
    public float ElytraRotX;
    public float ElytraRotY;
    public float ElytraRotZ;
    public ItemStack HeadEquipment = ItemStack.Air;
    public ItemStack ChestEquipment = ItemStack.Air;
    public ItemStack LegsEquipment = ItemStack.Air;
    public ItemStack FeetEquipment = ItemStack.Air;

    public override float TicksUsingItem(HumanoidArm arm) =>
        IsUsingItem && (UseItemHand == Hand.MainHand) == (arm == MainArm) ? TicksUsingItemValue : 0.0F;

    /// <summary><c>getUseItemStackForArm</c>.</summary>
    public virtual ItemStack GetUseItemStackForArm(HumanoidArm arm) => UseItemStackForArm(arm);
}

/// <summary><c>UndeadRenderState</c>.</summary>
public class UndeadRenderState : HumanoidRenderState {
    public override ItemStack GetUseItemStackForArm(HumanoidArm arm) => MainHandItemStack;
}
