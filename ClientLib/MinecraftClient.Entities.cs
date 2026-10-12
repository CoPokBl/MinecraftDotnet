using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Attributes;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ClientLib;

/// <summary>Entities appearing, moving, changing and going.</summary>
public sealed partial class MinecraftClient {
    /// <summary>
    /// <c>take_item_entity</c>: the taken entity and the one taking it, raised before the stack shrinks or
    /// the entity goes, which is where <c>handleTakeItemEntity</c> plays its sound and starts its particle.
    /// </summary>
    public event Action<ClientEntity, ClientEntity>? EntityTaken;

    private bool HandleEntityPacket(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundSpawnEntityPacket spawn:
                HandleSpawn(spawn);
                return true;
            case ClientBoundRemoveEntitiesPacket remove:
                foreach (int id in remove.Entities) {
                    RemoveEntity(id);
                }
                return true;
            case ClientBoundPickupItemPacket take:
                HandleTakeItemEntity(take);
                return true;
            case ClientBoundUpdateEntityPositionPacket move:
                HandleMove(move.EntityId, move.Delta, null, null, move.OnGround);
                return true;
            case ClientBoundUpdateEntityPosAndRotPacket moveRot:
                HandleMove(moveRot.EntityId, moveRot.Delta, moveRot.Yaw.DegreesF, moveRot.Pitch.DegreesF, moveRot.OnGround);
                return true;
            case ClientBoundUpdateEntityRotationPacket rot:
                HandleMove(rot.EntityId, null, rot.Yaw.DegreesF, rot.Pitch.DegreesF, rot.OnGround);
                return true;
            case ClientBoundTeleportEntityPacket teleport:
                HandleEntityTeleport(teleport);
                return true;
            case ClientBoundSynchroniseVehiclePositionPacket teleportEntity:
                HandleTeleportEntity(teleportEntity);
                return true;
            case ClientBoundSetPassengersPacket passengers:
                HandlePassengers(passengers);
                return true;
            case ClientBoundMoveVehiclePacket moveVehicle:
                HandleMoveVehicle(moveVehicle);
                return true;
            case ClientBoundOpenMountScreenPacket mountScreen:
                HandleMountScreenOpen(mountScreen);
                return true;
            case ClientBoundSetEntityVelocityPacket velocity:
                if (Entities.TryGetValue(velocity.EntityId, out ClientEntity? moving)) {
                    moving.DeltaMovement = new Vec3d(velocity.Velocity.X, velocity.Velocity.Y, velocity.Velocity.Z);
                }
                return true;
            case ClientBoundSetHeadRotationPacket head:
                if (Entities.TryGetValue(head.EntityId, out ClientEntity? turning)) {
                    turning.InterpolateHead(head.Yaw.DegreesF, 3);
                }
                return true;
            case ClientBoundSetEntityMetadataPacket metadata:
                if (Entities.TryGetValue(metadata.EntityId, out ClientEntity? described)) {
                    foreach ((int index, MetaField field) in metadata.Meta.Fields) {
                        described.Metadata[index] = field;
                        described.OnSyncedDataUpdated(index);
                    }
                }
                return true;
            case ClientBoundSetEquipmentPacket equipment:
                if (Entities.TryGetValue(equipment.EntityId, out ClientEntity? equipped)) {
                    foreach ((EquipmentSlot slot, ItemStack item) in equipment.Equipment) {
                        equipped.Equipment[slot] = item;
                    }
                }
                return true;
            case ClientBoundUpdateAttributesPacket attributes:
                if (Entities.TryGetValue(attributes.EntityId, out ClientEntity? attributed)) {
                    foreach (AttributeValue value in attributes.Attributes) {
                        attributed.Attributes.Apply(value);
                    }
                }
                return true;
            case ClientBoundEntityEffectPacket effect:
                if (Entities.TryGetValue(effect.EntityId, out ClientEntity? affected) && affected.IsLiving) {
                    HandleUpdateMobEffect(affected, effect);
                }
                return true;
            case ClientBoundRemoveEntityEffectPacket removeEffect:
                if (Entities.TryGetValue(removeEffect.EntityId, out ClientEntity? unaffected) && unaffected.IsLiving) {
                    unaffected.RemoveEffectNoUpdate(removeEffect.Effect);
                }
                return true;
            case ClientBoundDamageEventPacket damage:
                // LivingEntity.handleDamageEvent: the red flash for any living entity that took the hit.
                if (Entities.TryGetValue(damage.EntityId, out ClientEntity? damaged) && damaged.IsLiving) {
                    damaged.HurtTime = 10;
                }
                return true;
            case ClientBoundHurtAnimationPacket hurt:
                if (Entities.TryGetValue(hurt.EntityId, out ClientEntity? hurtEntity)) {
                    hurtEntity.HurtTime = 10;
                    if (hurtEntity is LocalPlayer hurtPlayer) {
                        hurtPlayer.HurtDir = (float)hurt.Yaw.Degrees;
                    }
                }
                return true;
            case ClientBoundEntityAnimationPacket animation:
                if (Entities.TryGetValue(animation.EntityId, out ClientEntity? animated)) {
                    HandleAnimation(animated, animation.Animation);
                }
                return true;
            default:
                return false;
        }
    }

    private void HandleAnimation(ClientEntity entity, ClientBoundEntityAnimationPacket.AnimationType animation) {
        switch (animation) {
            case ClientBoundEntityAnimationPacket.AnimationType.SwingMainArm:
                entity.Swing(Hand.MainHand);
                break;
            case ClientBoundEntityAnimationPacket.AnimationType.SwingOffhand:
                entity.Swing(Hand.OffHand);
                break;
            // Player.stopSleepInBed(false, false), for any player.
            case ClientBoundEntityAnimationPacket.AnimationType.LeaveBed when entity is LocalPlayer waking:
                waking.StopSleepInBed(false);
                break;
            case ClientBoundEntityAnimationPacket.AnimationType.LeaveBed:
                entity.StopSleeping(Level);
                break;
        }
    }

    /// <summary><c>ClientPacketListener.handleUpdateMobEffect</c>.</summary>
    private void HandleUpdateMobEffect(ClientEntity entity, ClientBoundEntityEffectPacket packet) {
        ClientBoundEntityEffectPacket.Flags flags = packet.EffectFlags;
        MobEffectInstance instance = new(packet.Effect, packet.Duration, packet.Amplifier, flags.HasFlag(ClientBoundEntityEffectPacket.Flags.IsAmbient),
            flags.HasFlag(ClientBoundEntityEffectPacket.Flags.ShowParticles), flags.HasFlag(ClientBoundEntityEffectPacket.Flags.ShowIcon));
        if (!flags.HasFlag(ClientBoundEntityEffectPacket.Flags.Blend)) {
            instance.SkipBlending();
        }
        if (CanBeAffected(entity, instance)) {
            entity.ForceAddEffect(instance);
        }
    }

    /// <summary><c>LivingEntity.canBeAffected</c>.</summary>
    private bool CanBeAffected(ClientEntity entity, MobEffectInstance effect) {
        if (InEntityTypeTag(entity.Type, ImmuneToInfested)) {
            return !effect.Effect.Equals(PotionEffectType.Infested);
        }
        if (InEntityTypeTag(entity.Type, ImmuneToOozing)) {
            return !effect.Effect.Equals(PotionEffectType.Oozing);
        }
        return !InEntityTypeTag(entity.Type, IgnoresPoisonAndRegen) || !effect.Effect.Equals(PotionEffectType.Regeneration) && !effect.Effect.Equals(PotionEffectType.Poison);
    }

    private static readonly Identifier ImmuneToInfested = "minecraft:immune_to_infested";
    private static readonly Identifier ImmuneToOozing = "minecraft:immune_to_oozing";
    private static readonly Identifier IgnoresPoisonAndRegen = "minecraft:ignores_poison_and_regen";

    internal void HandleSpawn(ClientBoundSpawnEntityPacket spawn) {
        Vec3d position = new(spawn.Position.X, spawn.Position.Y, spawn.Position.Z);
        ClientEntity entity = EntityKinds.Create(this, spawn.EntityType, spawn.Uuid, spawn.Data);
        entity.Id = spawn.Id;
        entity.DeltaMovement = new Vec3d(spawn.Velocity.X, spawn.Velocity.Y, spawn.Velocity.Z);
        entity.Snap(position, spawn.Yaw.DegreesF, spawn.Pitch.DegreesF);
        entity.YHeadRot = entity.YHeadRotO = spawn.HeadYaw.DegreesF;
        entity.SetCodecBase(position);
        Entities[spawn.Id] = entity;
    }

    /// <summary><c>ClientPacketListener.handleTakeItemEntity</c>.</summary>
    internal void HandleTakeItemEntity(ClientBoundPickupItemPacket packet) {
        if (!Entities.TryGetValue(packet.CollectedEntityId, out ClientEntity? from)) {
            return;
        }
        ClientEntity? to = Entities.GetValueOrDefault(packet.CollectorEntityId) ?? Player;
        if (to != null) {
            EntityTaken?.Invoke(from, to);
        }
        if (from.Is(EntityClass.ItemEntity)) {
            ItemStack? stack = from.Get(EntityDataFields.ItemEntity.Item);
            if (!IsEmpty(stack)) {
                stack = stack!.WithCount(stack.Count - packet.PickupItemCount);
                int index = EntityDataFields.ItemEntity.Item.Index;
                from.Metadata[index] = new MetaField<ItemStack>(from.Metadata[index].Type, stack);
            }
            if (IsEmpty(stack)) {
                Entities.Remove(packet.CollectedEntityId);
            }
        }
        else if (!from.Is(EntityClass.ExperienceOrb)) {
            Entities.Remove(packet.CollectedEntityId);
        }

        // ItemStack.isEmpty: a count shrunk below zero is empty too.
        static bool IsEmpty(ItemStack? stack) => stack == null || stack.IsAir() || stack.Count <= 0;
    }

    internal void HandleMove(int id, Vec3<float>? delta, float? yRot, float? xRot, bool onGround) {
        if (!Entities.TryGetValue(id, out ClientEntity? entity) || entity == Player) {
            return;
        }
        Vec3d? position = delta is { } d
            ? entity.DecodeDelta((long)Math.Round(d.X * 4096.0), (long)Math.Round(d.Y * 4096.0), (long)Math.Round(d.Z * 4096.0))
            : null;
        if (position is { } moved) {
            entity.SetCodecBase(moved);
        }
        if (entity.IsLocalInstanceAuthoritative) {
            return;
        }

        if (position is { } target) {
            if (yRot != null) {
                entity.InterpolateTo(target, yRot.Value, xRot!.Value);
            }
            else {
                entity.InterpolateTo(target);
            }
        }
        else if (yRot != null) {
            entity.InterpolateRotation(yRot.Value, xRot!.Value);
        }
        entity.SetOnGroundFromServer(onGround);
    }
}
