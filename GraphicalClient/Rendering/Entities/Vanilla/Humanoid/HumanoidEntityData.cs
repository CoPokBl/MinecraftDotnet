using ClientLib.Entities;
using ClientLib.Inventory;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using EntityPose = Minecraft.Schemas.Entities.EntityPose;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// What <c>LivingEntity</c> counts on the client that a humanoid's pose reads: <c>swimAmount</c>, the
/// item use timer and <c>elytraAnimationState</c>. Kept in <see cref="ClientEntity.RendererData"/>.
/// </summary>
public class HumanoidEntityData {
    public float SwimAmount, SwimAmountO;
    public int TicksUsingItem;
    public readonly ElytraAnimationState Elytra = new();

    public static HumanoidEntityData Of(ClientEntity entity) => entity.RendererData as HumanoidEntityData ?? new HumanoidEntityData();

    /// <summary>Ticks the entity's data, creating it the first time; a renderer whose data subclasses this passes its own factory.</summary>
    public static T TickFor<T>(ClientEntity entity) where T : HumanoidEntityData, new() {
        T data = entity.RendererData as T ?? new T();
        entity.RendererData = data;
        data.Tick(entity);
        return data;
    }

    public virtual void Tick(ClientEntity entity) {
        // updatingUsingItem: useItemRemaining is set to the use duration when the flag arrives and counts
        // down each tick, so the ticks used are the ticks since it arrived.
        TicksUsingItem = IsUsingItem(entity) ? TicksUsingItem + 1 : 0;
        // updateSwimAmount.
        SwimAmountO = SwimAmount;
        SwimAmount = PoseOf(entity) == EntityPose.Swimming ? Math.Min(1.0F, SwimAmount + 0.09F) : Math.Max(0.0F, SwimAmount - 0.09F);
        Elytra.Tick(entity);
    }

    /// <summary><c>getSwimAmount</c>.</summary>
    public float GetSwimAmount(float partialTick) => Mth.Lerp(partialTick, SwimAmountO, SwimAmount);

    /// <summary><c>getTicksUsingItem(partialTicks)</c>.</summary>
    public float GetTicksUsingItem(ClientEntity entity, float partialTick) => !IsUsingItem(entity) ? 0.0F : TicksUsingItem + partialTick;

    /// <summary>
    /// The entity's pose. The local player's own is the one its movement chose this tick, which the
    /// server's copy of it trails.
    /// </summary>
    public static EntityPose PoseOf(ClientEntity entity) =>
        entity is LocalPlayer local ? (EntityPose)(int)local.Pose : entity.Get(EntityDataFields.Entity.Pose, EntityPose.Standing);

    /// <summary><c>Entity.isCrouching</c>: the crouching pose, not the shift key that <see cref="ClientEntity.IsCrouching"/> reads.</summary>
    public static bool IsCrouching(ClientEntity entity) => PoseOf(entity) == EntityPose.Sneaking;

    /// <summary><c>LivingEntity.isFallFlying</c>: bit 7 of the shared flags.</summary>
    public static bool IsFallFlying(ClientEntity entity) => (entity.SharedFlags & 0x80) != 0;

    /// <summary><c>LivingEntity.isUsingItem</c>: bit 0 of <c>DATA_LIVING_ENTITY_FLAGS</c>.</summary>
    public static bool IsUsingItem(ClientEntity entity) => entity.IsLiving && (entity.Get(EntityDataFields.LivingEntity.LivingEntityFlags) & 1) != 0;

    /// <summary><c>LivingEntity.getUsedItemHand</c>: bit 1 of <c>DATA_LIVING_ENTITY_FLAGS</c>.</summary>
    public static Hand UsedItemHand(ClientEntity entity) =>
        entity.IsLiving && (entity.Get(EntityDataFields.LivingEntity.LivingEntityFlags) & 2) != 0 ? Hand.OffHand : Hand.MainHand;

    /// <summary><c>LivingEntity.isAutoSpinAttack</c>: bit 2 of <c>DATA_LIVING_ENTITY_FLAGS</c>.</summary>
    public static bool IsAutoSpinAttack(ClientEntity entity) => entity.IsLiving && (entity.Get(EntityDataFields.LivingEntity.LivingEntityFlags) & 4) != 0;

    /// <summary>
    /// <c>getUseItem</c>: the client copies the stack in the used hand when the flag arrives; this
    /// reads the hand each frame, which differs only while the held stack changes mid use.
    /// </summary>
    public static ItemStack UseItem(ClientEntity entity) => IsUsingItem(entity) ? entity.ItemInHand(UsedItemHand(entity)) : ItemStack.Air;

    /// <summary><c>Mob.isAggressive</c>: bit 2 of <c>DATA_MOB_FLAGS_ID</c>.</summary>
    public static bool IsAggressive(ClientEntity entity) => entity.Is(EntityClass.Mob) && (entity.Get(EntityDataFields.Mob.MobFlags) & 4) != 0;

    /// <summary>
    /// <c>getItemBySlot</c>. The server never sends the local player its own equipment, which is its
    /// inventory's armour slots instead.
    /// </summary>
    public static ItemStack ItemBySlot(ClientEntity entity, EquipmentSlot slot, EntityRenderContext context) {
        if (entity is LocalPlayer) {
            // Inventory.EQUIPMENT_SLOT_MAPPING.
            int index = slot switch {
                EquipmentSlot.Boots => 36,
                EquipmentSlot.Leggings => 37,
                EquipmentSlot.Chestplate => 38,
                EquipmentSlot.Helmet => 39,
                _ => -1
            };
            if (index >= 0) {
                PlayerInventory inventory = context.Client.Inventory;
                return inventory.Get(index).ToItemStack();
            }
        }
        return entity.GetItemBySlot(slot);
    }

    private static readonly Identifier SpearsTag = "minecraft:spears";

    /// <summary>
    /// <c>is(ItemTags.SPEARS)</c>, against the tags the server synchronised. Item tags have no generated
    /// type, so the tag is named here.
    /// </summary>
    public static bool IsSpear(ItemStack stack, EntityRenderContext context) => context.Client.Inventory.Data.InTag(Stack.Of(stack), SpearsTag);

    /// <summary>
    /// <c>CrossbowItem.getChargeDuration</c>. The charge time is enchantment content; this applies
    /// vanilla's quick charge (a quarter second off per level) and no other enchantment's effect.
    /// </summary>
    public static float CrossbowChargeDuration(ItemStack crossbow) {
        float duration = Math.Max(0.0F, 1.25F - 0.25F * crossbow.GetEnchantmentLevel(Enchantment.QuickCharge));
        return Mth.Floor(duration * 20.0F);
    }
}

/// <summary><c>ElytraAnimationState</c>.</summary>
public sealed class ElytraAnimationState {
    private float _rotX, _rotY, _rotZ;
    private float _rotXOld, _rotYOld, _rotZOld;

    public void Tick(ClientEntity entity) {
        _rotXOld = _rotX;
        _rotYOld = _rotY;
        _rotZOld = _rotZ;
        float targetXRot;
        float targetZRot;
        float targetYRot;
        if (HumanoidEntityData.IsFallFlying(entity)) {
            float ratio = 1.0F;
            ClientLib.Maths.Vec3d movement = entity.DeltaMovement;
            if (movement.Y < 0.0) {
                ClientLib.Maths.Vec3d vec = movement.Normalize();
                ratio = 1.0F - (float)Math.Pow(-vec.Y, 1.5);
            }
            targetXRot = Mth.Lerp(ratio, (float)(Math.PI / 12), (float)(Math.PI / 9));
            targetZRot = Mth.Lerp(ratio, (float)(-Math.PI / 12), (float)(-Math.PI / 2));
            targetYRot = 0.0F;
        }
        else if (HumanoidEntityData.IsCrouching(entity)) {
            targetXRot = (float)(Math.PI * 2.0 / 9.0);
            targetZRot = (float)(-Math.PI / 4);
            targetYRot = 0.08726646F;
        }
        else {
            targetXRot = (float)(Math.PI / 12);
            targetZRot = (float)(-Math.PI / 12);
            targetYRot = 0.0F;
        }
        _rotX += (targetXRot - _rotX) * 0.3F;
        _rotY += (targetYRot - _rotY) * 0.3F;
        _rotZ += (targetZRot - _rotZ) * 0.3F;
    }

    public float GetRotX(float partialTick) => Mth.Lerp(partialTick, _rotXOld, _rotX);
    public float GetRotY(float partialTick) => Mth.Lerp(partialTick, _rotYOld, _rotY);
    public float GetRotZ(float partialTick) => Mth.Lerp(partialTick, _rotZOld, _rotZ);
}
