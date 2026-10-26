using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>HumanoidMobRenderer</c>.</summary>
public abstract class HumanoidMobRenderer<S, M> : AgeableMobRenderer<S, M>
    where S : HumanoidRenderState, new()
    where M : HumanoidModel<S> {
    protected readonly ItemRenderer Items;
    protected readonly EquipmentLayerRenderer EquipmentRenderer;

    protected HumanoidMobRenderer(EntityRendererContext context, M model, float shadow) : this(context, model, model, shadow) { }

    protected HumanoidMobRenderer(EntityRendererContext context, M model, M babyModel, float shadow)
        : this(context, model, babyModel, shadow, CustomHeadLayer.Transforms.Default) { }

    protected HumanoidMobRenderer(EntityRendererContext context, M model, M babyModel, float shadow, CustomHeadLayer.Transforms customHeadTransforms)
        : base(model, babyModel, shadow) {
        Items = context.Items;
        EquipmentRenderer = EquipmentLayerRenderer.For(context);
        AddLayer(new CustomHeadLayer<S, M>(this, context.Items, customHeadTransforms));
        AddLayer(new WingsLayer<S, M>(this, EquipmentRenderer));
        AddLayer(new ItemInHandLayer<S, M>(this, context.Items));
    }

    public override void Tick(ClientEntity entity) => HumanoidEntityData.TickFor<HumanoidEntityData>(entity);

    protected virtual ArmPose GetArmPose(ClientEntity mob, HumanoidArm arm, EntityRenderContext context) {
        ItemStack itemHeldByArm = ArmedEntityRenderState.ItemHeldByArm(mob, arm);
        return HumanoidMobRenderer.UsesSpearPose(itemHeldByArm, arm, mob, context) ? ArmPose.Spear : ArmPose.Empty;
    }

    public override void ExtractRenderState(ClientEntity entity, S state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        HumanoidMobRenderer.ExtractHumanoidRenderState(entity, state, partialTick, Items, context);
        state.LeftArmPose = GetArmPose(entity, HumanoidArm.Left, context);
        state.RightArmPose = GetArmPose(entity, HumanoidArm.Right, context);
    }
}

/// <summary><c>HumanoidMobRenderer</c>'s statics, for the humanoid renderers that are not mob renderers.</summary>
public static class HumanoidMobRenderer {
    /// <summary><c>usesSpearPose</c>: the arm is part way through a stab, or holds a spear.</summary>
    public static bool UsesSpearPose(ItemStack item, HumanoidArm arm, ClientEntity entity, EntityRenderContext context) {
        HumanoidArm mainArm = ArmedEntityRenderState.MainArmOf(entity);
        return entity.CurrentSwing is { } swing && (swing.Hand == Hand.MainHand ? mainArm : ArmedEntityRenderState.Opposite(mainArm)) == arm
                                                && swing.Animation.Type == SwingAnimationType.Stab
               || HumanoidEntityData.IsSpear(item, context);
    }

    /// <summary><c>extractHumanoidRenderState</c>.</summary>
    public static void ExtractHumanoidRenderState(ClientEntity entity, HumanoidRenderState state, float partialTick, ItemRenderer items, EntityRenderContext context) {
        ArmedEntityRenderState.ExtractArmedEntityRenderState(entity, state, items, partialTick);
        HumanoidEntityData data = HumanoidEntityData.Of(entity);
        state.IsCrouching = HumanoidEntityData.IsCrouching(entity);
        state.IsFallFlying = HumanoidEntityData.IsFallFlying(entity);
        state.IsVisuallySwimming = HumanoidEntityData.PoseOf(entity) == EntityPose.Swimming;
        state.IsPassenger = entity.VehicleId != null;
        state.SpeedValue = 1.0F;
        if (state.IsFallFlying) {
            state.SpeedValue = (float)entity.DeltaMovement.LengthSqr();
            state.SpeedValue /= 0.2F;
            state.SpeedValue = state.SpeedValue * (state.SpeedValue * state.SpeedValue);
        }
        if (state.SpeedValue < 1.0F) {
            state.SpeedValue = 1.0F;
        }
        state.SwimAmount = data.GetSwimAmount(partialTick);
        state.AttackArm = GetAttackArm(entity);
        state.UseItemHand = HumanoidEntityData.UsedItemHand(entity);
        state.MaxCrossbowChargeDuration = HumanoidEntityData.CrossbowChargeDuration(HumanoidEntityData.UseItem(entity));
        state.TicksUsingItemValue = data.GetTicksUsingItem(entity, partialTick);
        state.IsUsingItem = HumanoidEntityData.IsUsingItem(entity);
        state.ElytraRotX = data.Elytra.GetRotX(partialTick);
        state.ElytraRotY = data.Elytra.GetRotY(partialTick);
        state.ElytraRotZ = data.Elytra.GetRotZ(partialTick);
        state.HeadEquipment = GetEquipmentIfRenderable(entity, EquipmentSlot.Helmet, context);
        state.ChestEquipment = GetEquipmentIfRenderable(entity, EquipmentSlot.Chestplate, context);
        state.LegsEquipment = GetEquipmentIfRenderable(entity, EquipmentSlot.Leggings, context);
        state.FeetEquipment = GetEquipmentIfRenderable(entity, EquipmentSlot.Boots, context);
    }

    private static ItemStack GetEquipmentIfRenderable(ClientEntity entity, EquipmentSlot slot, EntityRenderContext context) {
        ItemStack itemStack = HumanoidEntityData.ItemBySlot(entity, slot, context);
        return HumanoidArmorLayer.ShouldRender(itemStack, slot) ? itemStack : ItemStack.Air;
    }

    private static HumanoidArm GetAttackArm(ClientEntity entity) {
        HumanoidArm mainArm = ArmedEntityRenderState.MainArmOf(entity);
        return entity.CurrentSwing?.Hand != Hand.OffHand ? mainArm : ArmedEntityRenderState.Opposite(mainArm);
    }
}
