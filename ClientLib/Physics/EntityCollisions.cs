using ClientLib.Entities;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Physics;
using Minecraft.Schemas;
using SchemaPose = Minecraft.Schemas.Entities.EntityPose;

namespace ClientLib.Physics;

/// <summary>
/// The entities other entities collide with, <c>EntityGetter.getEntityCollisions</c>, and the
/// <c>canBeCollidedWith</c>, <c>canCollideWith</c> and <c>isPushable</c> overrides it asks, by the
/// entity's vanilla class.
/// </summary>
public static class EntityCollisions {
    /// <summary><c>getEntityCollisions</c>: the box of every entity <paramref name="source"/> collides with that reaches the area.</summary>
    public static void Collect(MinecraftClient client, ClientEntity? source, Box testArea, List<Box> into) {
        into.Clear();
        if (((testArea.MaxX - testArea.MinX) + (testArea.MaxY - testArea.MinY) + (testArea.MaxZ - testArea.MinZ)) / 3.0 < 1.0E-7) {
            return;
        }
        Box area = testArea.Inflate(1.0E-7);
        foreach (ClientEntity entity in client.Entities.Values) {
            if (entity == source || entity.IsRemoved || IsSpectator(client, entity)) {
                continue;
            }
            bool collides = source == null ? CanBeCollidedWith(client, entity, null) : CanCollideWith(client, source, entity);
            if (!collides) {
                continue;
            }
            Box box = entity.BoundingBox;
            if (box.Intersects(area)) {
                into.Add(box);
            }
        }
    }

    [ThreadStatic] private static List<Box>? _query;

    /// <summary><c>CollisionGetter.noEntityCollision</c>.</summary>
    public static bool None(MinecraftClient client, ClientEntity? source, Box box) {
        List<Box> found = _query ??= [];
        Collect(client, source, box, found);
        return found.Count == 0;
    }

    /// <summary><c>Entity.canBeCollidedWith</c>.</summary>
    public static bool CanBeCollidedWith(MinecraftClient client, ClientEntity entity, ClientEntity? other) {
        if (entity.Is(EntityClass.AbstractBoat)) {
            return true;
        }
        if (entity.Is(EntityClass.Shulker)) {
            return IsAlive(entity);
        }
        if (entity.Is(EntityClass.HappyGhast)) {
            if (entity.IsBaby || !IsAlive(entity)) {
                return false;
            }
            if (other != null && other.Is(EntityClass.Player) && other.Position.Y >= entity.BoundingBox.MaxY) {
                return true;
            }
            // isOnStillTimeout: the server's own timeout reaches the client as STAYS_STILL.
            return entity.IsVehicle && other != null && other.Is(EntityClass.HappyGhast) || entity.Get(EntityDataFields.HappyGhast.StaysStill);
        }
        return false;
    }

    /// <summary><c>Entity.canCollideWith</c>, and <c>AbstractBoat.canVehicleCollide</c> for boats and minecarts.</summary>
    public static bool CanCollideWith(MinecraftClient client, ClientEntity source, ClientEntity entity) {
        if (source.Is(EntityClass.AbstractBoat) || source.Is(EntityClass.AbstractMinecart)) {
            return (CanBeCollidedWith(client, entity, source) || IsPushable(client, entity)) && !IsPassengerOfSameVehicle(source, entity);
        }
        return CanBeCollidedWith(client, entity, source) && !IsPassengerOfSameVehicle(source, entity);
    }

    /// <summary><c>Entity.isPushable</c>.</summary>
    public static bool IsPushable(MinecraftClient client, ClientEntity entity) {
        if (entity.Is(EntityClass.AbstractBoat) || entity.Is(EntityClass.AbstractMinecart) || entity.Is(EntityClass.Parrot)) {
            return true;
        }
        if (entity.Is(EntityClass.Bat) || entity.Is(EntityClass.ArmorStand)) {
            return false;
        }
        if (entity.Is(EntityClass.AbstractHorse)) {
            return !entity.IsVehicle;
        }
        if (!entity.IsLiving) {
            return false;
        }
        bool pushable = IsAlive(entity) && !IsSpectator(client, entity) && !OnClimbable(client, entity);
        if (entity.Is(EntityClass.Creaking)) {
            return pushable && entity.Get(EntityDataFields.Creaking.CanMove);
        }
        if (entity.Is(EntityClass.Warden)) {
            SchemaPose pose = entity.Get(EntityDataFields.Entity.Pose);
            return pose is not (SchemaPose.Digging or SchemaPose.Emerging) && pushable;
        }
        return pushable;
    }

    /// <summary>
    /// <c>LivingEntity.pushEntities</c> and the push at the end of <c>AbstractBoat.tick</c>, run for every other
    /// entity once the player has moved, as vanilla ticks those after the player that joined before them.
    /// On the client <c>ClientLevel.getPushableEntities</c> only ever finds the local player.
    /// </summary>
    public static void PushPlayer(MinecraftClient client, LocalPlayer player) {
        foreach (ClientEntity pusher in client.Entities.Values) {
            if (pusher == player || pusher.IsRemoved || client.Level?.TickRateManager.IsEntityFrozen(pusher) == true) {
                continue;
            }
            if (pusher.Is(EntityClass.AbstractBoat)) {
                // getBoundingBox().inflate(0.2F, -0.01F, 0.2F)
                if (player.BoundingBox.Intersects(pusher.BoundingBox.Inflate(0.2F, -0.01F, 0.2F)) && PushableBy(client, pusher, player)
                    && player.BoundingBox.MinY <= pusher.BoundingBox.MinY) {
                    Push(client, pusher, player, 1.0);
                }
            }
            // Bat and ArmorStand push nothing on the client, and Parrot.doPush leaves players alone.
            else if (pusher.IsLiving && !pusher.Is(EntityClass.Bat) && !pusher.Is(EntityClass.ArmorStand) && !pusher.Is(EntityClass.Parrot)
                     && player.BoundingBox.Intersects(pusher.BoundingBox) && PushableBy(client, pusher, player)) {
                Push(client, player, pusher, -1.0);
            }
        }
    }

    /// <summary><c>EntitySelector.pushableBy</c>, tested on the local player.</summary>
    private static bool PushableBy(MinecraftClient client, ClientEntity pusher, LocalPlayer player) {
        Team? ownTeam = client.TeamOf(pusher);
        ClientBoundUpdateTeamsPacket.CollisionRule ownRule = ownTeam?.Collision ?? ClientBoundUpdateTeamsPacket.CollisionRule.Always;
        if (ownRule == ClientBoundUpdateTeamsPacket.CollisionRule.Never || player.IsSpectator || !IsPushable(client, player)) {
            return false;
        }
        Team? theirTeam = client.TeamOf(player);
        ClientBoundUpdateTeamsPacket.CollisionRule theirRule = theirTeam?.Collision ?? ClientBoundUpdateTeamsPacket.CollisionRule.Always;
        if (theirRule == ClientBoundUpdateTeamsPacket.CollisionRule.Never) {
            return false;
        }
        bool sameTeam = ownTeam != null && ownTeam == theirTeam;
        if ((ownRule == ClientBoundUpdateTeamsPacket.CollisionRule.PushOwnTeam || theirRule == ClientBoundUpdateTeamsPacket.CollisionRule.PushOwnTeam) && sameTeam) {
            return false;
        }
        return ownRule != ClientBoundUpdateTeamsPacket.CollisionRule.PushOtherTeams && theirRule != ClientBoundUpdateTeamsPacket.CollisionRule.PushOtherTeams || sameTeam;
    }

    /// <summary>
    /// <c>Entity.push(Entity)</c> on <paramref name="self"/> from <paramref name="other"/>, as far as it moves the
    /// local player: away from the other entity, by <paramref name="playerSign"/> times the push.
    /// </summary>
    private static void Push(MinecraftClient client, ClientEntity self, ClientEntity other, double playerSign) {
        LocalPlayer player = (LocalPlayer)(self is LocalPlayer ? self : other);
        if (IsPassengerOfSameVehicle(self, other) || NoPhysics(client, other) || NoPhysics(client, self)) {
            return;
        }
        double xa = other.Position.X - self.Position.X;
        double za = other.Position.Z - self.Position.Z;
        double dd = Math.Max(Math.Abs(xa), Math.Abs(za));
        if (dd < 0.01F) {
            return;
        }
        dd = Math.Sqrt(dd);
        xa /= dd;
        za /= dd;
        double pow = Math.Min(1.0 / dd, 1.0);
        xa *= pow;
        za *= pow;
        xa *= 0.05F;
        za *= 0.05F;
        if (!player.IsVehicle && IsPushable(client, player)) {
            player.Push(playerSign * xa, 0.0, playerSign * za);
        }
    }

    /// <summary>
    /// <c>Entity.noPhysics</c> while it pushes: a spectating player's, and a vex's or the dragon's, which hold it
    /// through their whole tick.
    /// </summary>
    private static bool NoPhysics(MinecraftClient client, ClientEntity entity) =>
        entity is LocalPlayer local ? local.NoPhysics : IsSpectator(client, entity) || entity.Is(EntityClass.Vex) || entity.Is(EntityClass.EnderDragon);

    /// <summary><c>Entity.isPassengerOfSameVehicle</c>.</summary>
    public static bool IsPassengerOfSameVehicle(ClientEntity entity, ClientEntity other) => entity.RootVehicle == other.RootVehicle;

    private static bool IsAlive(ClientEntity entity) => !entity.IsRemoved && (!entity.IsLiving || entity.CurrentHealth > 0.0F);

    internal static bool IsSpectator(MinecraftClient client, ClientEntity entity) {
        if (entity is LocalPlayer local) {
            return local.IsSpectator;
        }
        return entity.Is(EntityClass.Player) && client.PlayerList.TryGetValue(entity.Uuid, out PlayerListEntry? entry) && entry.GameMode == GameMode.Spectator;
    }

    private static bool OnClimbable(MinecraftClient client, ClientEntity entity) {
        if (client.Level is not { } level) {
            return false;
        }
        if (entity is LocalPlayer local) {
            return local.OnClimbable();
        }
        return MovementBlocks.OnClimbable(level, (int)Math.Floor(entity.Position.X), (int)Math.Floor(entity.Position.Y), (int)Math.Floor(entity.Position.Z));
    }
}
