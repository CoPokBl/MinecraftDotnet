using ClientLib.Entities;
using ClientLib.Entities.Vehicles;
using ClientLib.Inventory;
using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace ClientLib;

/// <summary>Passengers, teleports, the vehicle the player steers, and the order entities tick in.</summary>
public sealed partial class MinecraftClient {
    private static readonly Identifier CanEquipSaddle = "minecraft:can_equip_saddle";
    private static readonly Identifier CanWearHorseArmor = "minecraft:can_wear_horse_armor";

    /// <summary>
    /// <c>ClientPacketListener.removedPlayerVehicleId</c>: the vehicle the player was on when the server
    /// removed it, whose teleport still lands on the player.
    /// </summary>
    private int? _removedPlayerVehicleId;

    /// <summary><c>ClientPacketListener.handleSetEntityPassengersPacket</c>.</summary>
    internal void HandlePassengers(ClientBoundSetPassengersPacket packet) {
        if (!Entities.TryGetValue(packet.VehicleEntityId, out ClientEntity? vehicle)) {
            return;
        }
        bool wasPlayerMounted = Player != null && vehicle.HasIndirectPassenger(Player);
        vehicle.EjectPassengers();
        foreach (int id in packet.PassengerEntityIds) {
            if (!Entities.TryGetValue(id, out ClientEntity? passenger)) {
                continue;
            }
            passenger.StartRiding(vehicle);
            if (passenger != Player) {
                continue;
            }
            _removedPlayerVehicleId = null;
            if (!wasPlayerMounted) {
                if (vehicle is ClientBoat) {
                    Player.YRotO = vehicle.YRot;
                    Player.YRot = vehicle.YRot;
                    Player.YHeadRot = vehicle.YRot;
                }
                // keyShift.getTranslatedKeyMessage: sneaking is bound to left shift and cannot be rebound here.
                SetActionBar(TextComponent.Translatable("mount.onboard", with: [TextComponent.Translatable("key.keyboard.left.shift")]));
            }
        }
    }

    /// <summary><c>ClientPacketListener.handleRemoveEntities</c>.</summary>
    internal void RemoveEntity(int id) {
        if (!Entities.TryGetValue(id, out ClientEntity? entity)) {
            return;
        }
        if (Player != null && entity.HasIndirectPassenger(Player)) {
            _removedPlayerVehicleId = id;
        }
        Discard(entity);
    }

    /// <summary>
    /// <c>Entity.setRemoved</c> through the level's callback, which drops it from the level whether the
    /// server removed it or its own tick discarded it.
    /// </summary>
    internal void Discard(ClientEntity entity) {
        if (Entities.GetValueOrDefault(entity.Id) == entity) {
            Entities.Remove(entity.Id);
        }
        entity.SetRemoved();
    }

    /// <summary><c>ClientPacketListener.handleMovePlayer</c>.</summary>
    private void HandlePlayerPosition(ClientBoundSynchronisePlayerPositionPacket packet) {
        LocalPlayer? player = Player;
        if (player == null) {
            return;
        }
        if (!player.IsPassenger) {
            SetValuesFromPositionPacket(PositionMoveRotation.Change(packet.Position, packet.Velocity, packet.Yaw, packet.Pitch), packet.Flags, player, false);
        }
        Send(new ServerBoundConfirmTeleportPacket {
            TeleportId = packet.TeleportId,
            Position = new Vec3<double>(player.Position.X, player.Position.Y, player.Position.Z),
            Yaw = player.YRot,
            Pitch = player.XRot
        });
        Level?.Predictions.OnTeleport();
        Interactions.StopDestroyBlock();
    }

    private void SendPlayerPosition(LocalPlayer player) {
        Send(new ServerBoundSetPlayerPosAndRotPacket {
            Position = new Vec3<double>(player.Position.X, player.Position.Y, player.Position.Z),
            Yaw = player.YRot,
            Pitch = player.XRot,
            Flags = MovePlayerFlags.None
        });
    }

    /// <summary><c>ClientPacketListener.handleRotatePlayer</c>.</summary>
    private void HandlePlayerRotation(ClientBoundPlayerRotationPacket packet) {
        LocalPlayer? player = Player;
        if (player == null) {
            return;
        }
        float yRot = (packet.RelativeYaw ? player.YRot : 0.0F) + packet.Yaw.DegreesF;
        float xRot = Math.Clamp((packet.RelativePitch ? player.XRot : 0.0F) + packet.Pitch.DegreesF, -90.0F, 90.0F);
        player.YRotO = (packet.RelativeYaw ? player.YRotO : 0.0F) + packet.Yaw.DegreesF;
        player.XRotO = Math.Clamp((packet.RelativePitch ? player.XRotO : 0.0F) + packet.Pitch.DegreesF, -90.0F, 90.0F);
        player.YRot = yRot;
        player.XRot = xRot;
        Send(new ServerBoundSetPlayerRotationPacket {
            Yaw = player.YRot,
            Pitch = player.XRot,
            Flags = MovePlayerFlags.None
        });
    }

    /// <summary><c>ClientPacketListener.handleEntityPositionSync</c>.</summary>
    internal void HandleEntityTeleport(ClientBoundTeleportEntityPacket packet) {
        if (!Entities.TryGetValue(packet.EntityId, out ClientEntity? entity)) {
            return;
        }
        Vec3d position = new(packet.Position.X, packet.Position.Y, packet.Position.Z);
        PositionPath path = packet.Steps is { Count: > 0 } steps
            ? new PositionPath.Stepped(steps.Select(step => new PositionStep(new Vec3d(step.Position.X, step.Position.Y, step.Position.Z), step.TickOffset)).ToArray())
            : PositionPath.Of(position);
        entity.SetCodecBase(position);
        if (entity == Player || entity.IsLocalInstanceAuthoritative) {
            return;
        }
        bool tooBigToInterpolate = entity.Position.DistanceToSqr(position) > 4096.0;
        if (IsTickingEntity(entity) && !tooBigToInterpolate) {
            entity.MoveOrInterpolateTo(path, packet.Yaw.DegreesF, packet.Pitch.DegreesF, true);
        }
        else {
            entity.SnapTo(position, packet.Yaw.DegreesF, packet.Pitch.DegreesF);
        }
        if (!entity.IsInterpolating && Player != null && entity.HasIndirectPassenger(Player)) {
            entity.PositionRider(Player);
            Player.OldPosition = Player.Position;
        }
        entity.SetOnGroundFromServer(packet.OnGround);
    }

    /// <summary>
    /// <c>ClientPacketListener.handleTeleportEntity</c>. A vehicle the player steers takes the teleport at
    /// once, and tells the server where it ended up.
    /// </summary>
    internal void HandleTeleportEntity(ClientBoundSynchroniseVehiclePositionPacket packet) {
        PositionMoveRotation change = PositionMoveRotation.Change(packet.Position, packet.Velocity, packet.Yaw, packet.Pitch);
        if (!Entities.TryGetValue(packet.EntityId, out ClientEntity? entity)) {
            if (_removedPlayerVehicleId == packet.EntityId && Player is { } player) {
                SetValuesFromPositionPacket(change, packet.Flags, player, false);
            }
            return;
        }

        bool hasRelative = (packet.Flags & TeleportFlags.RelativePosition) != 0;
        bool interpolate = IsTickingEntity(entity) || !entity.IsLocalInstanceAuthoritative || hasRelative;
        bool wasInterpolated = SetValuesFromPositionPacket(change, packet.Flags, entity, interpolate);
        entity.SetOnGroundFromServer(packet.OnGround);
        if (!wasInterpolated && Player != null && entity.HasIndirectPassenger(Player)) {
            entity.PositionRider(Player);
            Player.OldPosition = Player.Position;
            if (entity.IsLocalInstanceAuthoritative) {
                SendMoveVehicle(entity);
            }
        }
    }

    /// <summary>
    /// <c>ClientLevel.isTickingEntity</c>: the client ticks what stands in a chunk it holds.
    /// </summary>
    private bool IsTickingEntity(ClientEntity entity) =>
        Level != null && Level.HasChunk((int)Math.Floor(entity.Position.X) >> 4, (int)Math.Floor(entity.Position.Z) >> 4);

    /// <summary>
    /// <c>ClientPacketListener.setValuesFromPositionPacket</c>. <c>PositionMoveRotation.of</c> starts from
    /// where an interpolation in progress is heading, rotation included.
    /// </summary>
    private static bool SetValuesFromPositionPacket(PositionMoveRotation change, TeleportFlags relatives, ClientEntity entity, bool interpolate) {
        PositionAndRotation client = entity.ClientPositionAndRotation;
        PositionMoveRotation current = new(client.Position, entity.DeltaMovement, client.YRot, client.XRot);
        PositionMoveRotation absolute = PositionMoveRotation.CalculateAbsolute(current, change, relatives);
        if (interpolate && !(current.Position.DistanceToSqr(absolute.Position) > 4096.0)) {
            entity.MoveOrInterpolateTo(absolute.Position, absolute.YRot, absolute.XRot);
            entity.DeltaMovement = absolute.DeltaMovement;
            return true;
        }
        entity.Position = absolute.Position;
        entity.DeltaMovement = absolute.DeltaMovement;
        entity.SetYRot(absolute.YRot);
        entity.SetXRot(absolute.XRot);
        PositionMoveRotation old = PositionMoveRotation.CalculateAbsolute(new(entity.OldPosition, Vec3d.Zero, entity.YRotO, entity.XRotO), change, relatives);
        entity.OldPosition = old.Position;
        entity.YRotO = old.YRot;
        entity.XRotO = old.XRot;
        return false;
    }

    private readonly record struct PositionMoveRotation(Vec3d Position, Vec3d DeltaMovement, float YRot, float XRot) {
        public static PositionMoveRotation Change(Vec3<double> position, Vec3<double> velocity, Angle yaw, Angle pitch) =>
            new(new Vec3d(position.X, position.Y, position.Z), new Vec3d(velocity.X, velocity.Y, velocity.Z), yaw.DegreesF, pitch.DegreesF);

        /// <summary><c>PositionMoveRotation.calculateAbsolute</c>.</summary>
        public static PositionMoveRotation CalculateAbsolute(PositionMoveRotation source, PositionMoveRotation change, TeleportFlags relatives) {
            Vec3d absolutePosition = new(
                ((relatives & TeleportFlags.RelativeX) != 0 ? source.Position.X : 0.0) + change.Position.X,
                ((relatives & TeleportFlags.RelativeY) != 0 ? source.Position.Y : 0.0) + change.Position.Y,
                ((relatives & TeleportFlags.RelativeZ) != 0 ? source.Position.Z : 0.0) + change.Position.Z);
            float absoluteYRot = ((relatives & TeleportFlags.RelativeYaw) != 0 ? source.YRot : 0.0F) + change.YRot;
            float absoluteXRot = Math.Clamp(((relatives & TeleportFlags.RelativePitch) != 0 ? source.XRot : 0.0F) + change.XRot, -90.0F, 90.0F);
            Vec3d movement = source.DeltaMovement;
            if ((relatives & TeleportFlags.RotVelWithDeltaVelocity) != 0) {
                movement = ClientEntity.XRotate(movement, (float)(Math.PI / 180.0 * (source.XRot - absoluteXRot)));
                movement = ClientEntity.YRotate(movement, (float)(Math.PI / 180.0 * (source.YRot - absoluteYRot)));
            }
            Vec3d absoluteMovement = new(
                ((relatives & TeleportFlags.RelativeVelocityX) != 0 ? movement.X : 0.0) + change.DeltaMovement.X,
                ((relatives & TeleportFlags.RelativeVelocityY) != 0 ? movement.Y : 0.0) + change.DeltaMovement.Y,
                ((relatives & TeleportFlags.RelativeVelocityZ) != 0 ? movement.Z : 0.0) + change.DeltaMovement.Z);
            return new PositionMoveRotation(absolutePosition, absoluteMovement, absoluteYRot, absoluteXRot);
        }
    }

    /// <summary>
    /// <c>ClientPacketListener.handleMoveVehicle</c>: the server disagreed with where the vehicle went, so
    /// it goes where the server says, and the client confirms.
    /// </summary>
    internal void HandleMoveVehicle(ClientBoundMoveVehiclePacket packet) {
        if (Player == null) {
            return;
        }
        ClientEntity vehicle = Player.RootVehicle;
        if (vehicle == Player || !vehicle.IsLocalInstanceAuthoritative) {
            return;
        }
        Vec3d target = new(packet.Position.X, packet.Position.Y, packet.Position.Z);
        if (Math.Sqrt(target.DistanceToSqr(vehicle.ClientPosition)) > 1.0E-5F) {
            vehicle.Interpolation.Cancel();
            // Entity.absSnapTo.
            Vec3d clamped = new(Math.Clamp(target.X, -3.0E7, 3.0E7), target.Y, Math.Clamp(target.Z, -3.0E7, 3.0E7));
            vehicle.OldPosition = clamped;
            vehicle.Position = clamped;
            vehicle.AbsSnapRotationTo(packet.Yaw.DegreesF, packet.Pitch.DegreesF);
        }
        SendMoveVehicle(vehicle);
    }

    /// <summary><c>ServerboundMoveVehiclePacket.fromEntity</c>.</summary>
    internal void SendMoveVehicle(ClientEntity vehicle) {
        PositionAndRotation current = vehicle.ClientPositionAndRotation;
        Send(new ServerBoundMoveVehiclePacket {
            Position = new Vec3<double>(current.Position.X, current.Position.Y, current.Position.Z),
            Yaw = Angle.FromDegrees(current.YRot),
            Pitch = Angle.FromDegrees(current.XRot),
            OnGround = vehicle.OnGround
        });
    }

    /// <summary>
    /// <c>ClientPacketListener.handleMountScreenOpen</c>: the inventory of the horse or nautilus the player
    /// rides, which the server opens in answer to the inventory key.
    /// </summary>
    internal void HandleMountScreenOpen(ClientBoundOpenMountScreenPacket packet) {
        if (!Entities.TryGetValue(packet.EntityId, out ClientEntity? entity) || entity is not (ClientHorse or ClientNautilus)) {
            return;
        }
        ClientRideableMob mount = (ClientRideableMob)entity;
        bool nautilus = mount is ClientNautilus;
        bool saddleActive = mount.CanUseSlot(EquippableComponent.Slot.Saddle) && (nautilus || InEntityTypeTag(mount.Type, CanEquipSaddle));
        bool armorActive = mount.CanUseSlot(EquippableComponent.Slot.Body)
                           && (nautilus || InEntityTypeTag(mount.Type, CanWearHorseArmor) || mount.Is(EntityClass.Llama));
        TextComponent title = mount.Get(EntityDataFields.Entity.CustomName) is { Present: true } name
            ? name.Value
            : TextComponent.Translatable($"entity.{mount.Type.Identifier.Namespace}.{mount.Type.Identifier.Key}");
        MountInventoryMenu menu = new(packet.WindowId, title, Inventory, Inventory.Data, packet.InventoryColumns, nautilus, saddleActive, armorActive,
            (stack, slot) => !stack.IsEmpty && mount.IsEquippableInSlot(stack.Template, slot)) { Mount = mount };
        Inventory.ActiveMenu = menu;
        OpenContainer = menu;
        ContainerOpened?.Invoke(menu);
    }

    /// <summary>
    /// <c>ClientLevel.tickEntities</c>: everything that rides nothing ticks, then its passengers ride
    /// along through <c>tickPassenger</c>. The player is ticked last. While the server is frozen only
    /// players and what carries one tick.
    /// </summary>
    private void TickEntities() {
        // An entity's tick may discard it; removing from a Dictionary leaves its enumerator valid.
        foreach (ClientEntity entity in Entities.Values) {
            if (entity == Player || entity.IsPassenger || Level?.TickRateManager.IsEntityFrozen(entity) == true) {
                continue;
            }
            entity.Tick();
            TickPassengers(entity);
        }
        if (Player is { IsPassenger: false } player) {
            player.ClientTick();
            TickPassengers(player);
            player.BoostFromRockets();
        }
        if (Player is { } pushed && Level != null) {
            EntityCollisions.PushPlayer(this, pushed);
        }
    }

    private static void TickPassengers(ClientEntity vehicle) {
        if (!vehicle.IsVehicle) {
            return;
        }
        foreach (ClientEntity passenger in vehicle.PassengerList.ToArray()) {
            TickPassenger(vehicle, passenger);
        }
    }

    /// <summary><c>ClientLevel.tickPassenger</c>.</summary>
    private static void TickPassenger(ClientEntity vehicle, ClientEntity entity) {
        if (entity.IsRemoved || entity.Vehicle != vehicle) {
            entity.StopRiding();
            return;
        }
        entity.RideTick();
        TickPassengers(entity);
    }
}
