using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Experience orbs drifting to a nearby player and being absorbed, vanilla's
/// <c>ExperienceOrb.followNearbyPlayer</c> and <c>playerTouch</c>.
/// <p/>
/// Separate from <see cref="BlockExperienceFeature"/> so a minigame can hand experience out without
/// orbs on the floor, or have orbs that nobody can collect.
/// </summary>
public class ExperiencePickupFeature : ScopedFeature {
    /// <summary>How far an orb looks for someone to drift towards, <c>getNearestPlayer(this, 8.0)</c>.</summary>
    private const double FollowRange = 8.0;

    /// <summary>Vanilla absorbs on the bounding boxes touching; a plain radius stands in for that.</summary>
    private const double PickupRange = 1.0;

    /// <summary><c>ExperienceOrb</c>'s own five minute lifetime, the same as an item's.</summary>
    private const int Lifetime = 6000;

    public override void Register() {
        AddEventHandler<ServerTickEvent>(_ => {
            foreach (World world in ScopedWorlds()) {
                TickWorld(world);
            }
        });
    }

    private World[] ScopedWorlds() {
        return Scope is World world ? [world] : Scope.Server.Worlds.ToArray();
    }

    private static void TickWorld(World world) {
        foreach (Entity orb in world.Entities.GetEntities()) {
            if (orb.Type.Identifier != EntityType.ExperienceOrb.Identifier) {
                continue;
            }

            if (orb.Meta is not ExperienceOrbMeta { Experience: { } value }) {
                continue;
            }

            // Entity.Tick already counts this, so the orb needs no age of its own the way an item
            // does: an item's age is reset by a merge and this one never is.
            if (orb.TickCount >= Lifetime) {
                orb.Despawn();
                continue;
            }

            Player? target = Nearest(world, orb);
            if (target == null) {
                continue;
            }

            if (orb.Position.DistanceSquaredTo(target.Position) <= PickupRange * PickupRange) {
                Absorb(orb, target, value);
                continue;
            }

            Follow(orb, target);
        }
    }

    /// <summary>
    /// <c>followNearbyPlayer</c>'s pull: an acceleration towards the player's chest that falls off with
    /// the square of how far away they are, so an orb accelerates as it closes rather than tracking at
    /// a fixed speed.
    /// </summary>
    private static void Follow(Entity orb, Player target) {
        Vec3<double> delta = new(
            target.Position.X - orb.Position.X,
            target.Position.Y + target.EyeHeight / 2.0 - orb.Position.Y,
            target.Position.Z - orb.Position.Z);

        double lengthSquared = delta.DistanceSquaredTo(Vec3<double>.Zero);
        if (lengthSquared <= 0.0) {
            return;
        }

        double power = 1.0 - Math.Sqrt(lengthSquared) / FollowRange;
        orb.Velocity += delta.Normalize().Multiply(power * power * 0.1);
    }

    /// <summary>
    /// <c>playerTouch</c>. Mending is not applied: repairing an item first needs the
    /// <c>repair_with_xp</c> enchantment effect, and only two effect kinds are parsed at registry load,
    /// so the whole amount goes to the player.
    /// </summary>
    private static void Absorb(Entity orb, Player target, int value) {
        target.SendToSelfAndViewers(new ClientBoundPickupItemPacket {
            CollectedEntityId = orb.NetId,
            CollectorEntityId = target.NetId,
            PickupItemCount = 1
        });
        target.PlaySound(SoundType.ExperienceOrbPickup, orb);

        target.GiveExperiencePoints(value);
        orb.Despawn();
    }

    private static Player? Nearest(World world, Entity orb) {
        Player? nearest = null;
        double best = FollowRange * FollowRange;

        foreach (Player player in world.Players) {
            if (player.GameMode == GameMode.Spectator) {
                continue;
            }

            double distance = player.Position.DistanceSquaredTo(orb.Position);
            if (distance < best) {
                best = distance;
                nearest = player;
            }
        }

        return nearest;
    }
}
