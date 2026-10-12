using ClientLib.Interaction;
using ClientLib.Maths;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Mth = Minecraft.Schemas.Mth;

namespace ClientLib.Player;

/// <summary>Elytra flight, which the player starts itself and steers on the client.</summary>
public sealed partial class LocalPlayer {
    private static readonly Identifier CanGlideThroughTag = "minecraft:can_glide_through";

    /// <summary>
    /// <c>LocalPlayer.aiStep</c>'s start of a glide: a fresh jump in the air, which the server hears of
    /// as <c>START_FALL_FLYING</c>.
    /// </summary>
    private void MaybeStartFallFlying(bool wasJumping, bool justToggledCreativeFlight) {
        if (KeyPresses.Jump && !justToggledCreativeFlight && !wasJumping && !OnClimbable() && TryToStartFallFlying()) {
            _client.Send(new ServerBoundPlayerCommandPacket { EntityId = Id, PlayAction = PlayerAction.StartElytraFlight, JumpBoost = 0 });
        }
    }

    /// <summary><c>Player.tryToStartFallFlying</c>.</summary>
    private bool TryToStartFallFlying() {
        if (!IsFallFlying && CanGlide() && !IsInWater) {
            SetSharedFlag(7, true);
            return true;
        }
        return false;
    }

    /// <summary><c>Player.canGlide</c> over <c>LivingEntity.canGlide</c>.</summary>
    private bool CanGlide() {
        if (Flying || OnGround || IsPassenger || HasEffect(PotionEffectType.Levitation)) {
            return false;
        }
        return CanGlideUsing(ItemInHand(Hand.MainHand), EquippableComponent.Slot.MainHand)
               || CanGlideUsing(ItemInHand(Hand.OffHand), EquippableComponent.Slot.OffHand)
               || CanGlideUsing(_client.Inventory.Get(36).ToItemStack(), EquippableComponent.Slot.Feet)
               || CanGlideUsing(_client.Inventory.Get(37).ToItemStack(), EquippableComponent.Slot.Legs)
               || CanGlideUsing(_client.Inventory.Get(38).ToItemStack(), EquippableComponent.Slot.Chest)
               || CanGlideUsing(_client.Inventory.Get(39).ToItemStack(), EquippableComponent.Slot.Head);
    }

    /// <summary><c>LivingEntity.canGlideUsing</c>.</summary>
    private static bool CanGlideUsing(ItemStack stack, EquippableComponent.Slot slot) {
        if (!ItemComponents.Has(stack, DataComponent.Glider)) {
            return false;
        }
        EquippableComponent.Data? equippable = ItemComponents.Get(stack, DataComponent.Equippable);
        return equippable != null && equippable.Slot == slot && !ItemModelProperties.NextDamageWillBreak(stack);
    }

    /// <summary><c>LivingEntity.stopFallFlying</c>.</summary>
    private void StopFallFlying() {
        SetSharedFlag(7, true);
        SetSharedFlag(7, false);
    }

    /// <summary><c>LivingEntity.updateFallFlying</c>: the durability and game events are the server's.</summary>
    private void UpdateFallFlying() {
        // Entity.checkFallDistanceAccumulation.
        if (DeltaMovement.Y > -0.5 && FallDistance > 1.0) {
            FallDistance = 1.0;
        }
    }

    /// <summary><c>LivingEntity.travelFallFlying</c>; hitting a wall hurts on the server.</summary>
    private void TravelFallFlying(Vec3d input) {
        if (OnClimbable()) {
            TravelInAir(input);
            StopFallFlying();
            return;
        }
        DeltaMovement = UpdateFallFlyingMovement(DeltaMovement);
        Move(DeltaMovement);
    }

    /// <summary><c>LivingEntity.updateFallFlyingMovement</c>.</summary>
    private Vec3d UpdateFallFlyingMovement(Vec3d movement) {
        Vec3d lookAngle = Picking.ViewVector(this, 1.0F);
        float leanAngle = XRot * ((float)Math.PI / 180.0F);
        double lookHorLength = Math.Sqrt(lookAngle.X * lookAngle.X + lookAngle.Z * lookAngle.Z);
        double moveHorLength = Math.Sqrt(movement.HorizontalDistanceSqr());
        double gravity = EffectiveGravity();
        double cos = Math.Cos(leanAngle);
        double liftForce = cos * cos;
        movement = movement.Add(0.0, gravity * (-1.0 + liftForce * 0.75), 0.0);
        if (movement.Y < 0.0 && lookHorLength > 0.0) {
            double convert = movement.Y * -0.1 * liftForce;
            movement = movement.Add(lookAngle.X * convert / lookHorLength, convert, lookAngle.Z * convert / lookHorLength);
        }

        if (leanAngle < 0.0F && lookHorLength > 0.0) {
            double convert = moveHorLength * -Mth.Sin(leanAngle) * 0.04;
            movement = movement.Add(-lookAngle.X * convert / lookHorLength, convert * 3.2, -lookAngle.Z * convert / lookHorLength);
        }

        if (lookHorLength > 0.0) {
            movement = movement.Add((lookAngle.X / lookHorLength * moveHorLength - movement.X) * 0.1, 0.0,
                (lookAngle.Z / lookHorLength * moveHorLength - movement.Z) * 0.1);
        }

        return movement.Multiply(0.99F, 0.98F, 0.99F);
    }

    /// <summary>
    /// <c>FireworkRocketEntity.tick</c>'s push on the player it is attached to. A rocket the player
    /// launches spawns after it, so it ticks after it, as <see cref="MinecraftClient"/> calls this.
    /// </summary>
    internal void BoostFromRockets() {
        if (!IsFallFlying) {
            return;
        }
        foreach (Entities.ClientEntity entity in _client.Entities.Values) {
            if (entity.Type != EntityType.FireworkRocket || entity.IsRemoved
                || entity.Get(EntityDataFields.FireworkRocketEntity.AttachedToTarget) is not { Present: true } target || target.Value != Id) {
                continue;
            }
            Vec3d lookAngle = Picking.ViewVector(this, 1.0F);
            Vec3d movement = DeltaMovement;
            DeltaMovement = movement.Add(lookAngle.X * 0.1 + (lookAngle.X * 1.5 - movement.X) * 0.5,
                lookAngle.Y * 0.1 + (lookAngle.Y * 1.5 - movement.Y) * 0.5,
                lookAngle.Z * 0.1 + (lookAngle.Z * 1.5 - movement.Z) * 0.5);
        }
    }

    /// <summary><c>LivingEntity.onClimbable</c>'s exception: gliding goes through what is tagged <c>can_glide_through</c>.</summary>
    private bool GlidesThrough() {
        if (!IsFallFlying || !Level.Registry.Blocks.Tags.Contains(CanGlideThroughTag)) {
            return false;
        }
        Identifier block = Level.GetBlock(BlockX, BlockY, BlockZ).Identifier;
        foreach (Identifier value in Level.Registry.Blocks.Tags[CanGlideThroughTag].GetValueIds(Level.Registry)) {
            if (value.Equals(block)) {
                return true;
            }
        }
        return false;
    }
}
