using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Worlds;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Text;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Notices a living entity running out of health, announces it as an <see cref="EntityDeathEvent"/> (a
/// <see cref="PlayerDeathEvent"/> for a player) and, unless that is cancelled, does what vanilla does
/// with something dead: the death animation for everyone watching, then removal for an entity or the
/// death screen for a player. A player is left in the world at zero health for
/// <see cref="RespawnFeature"/> to pick up when they press the button on it.
/// <p/>
/// Nothing here takes health off an entity through a pipeline this could sit inside, so the zero is
/// found on the tick rather than at the moment of damage and a death is announced at most one tick
/// late. That is also what makes it work whatever did the killing, down to code that just assigns
/// <see cref="LivingEntity.Health"/> itself.
/// <p/>
/// The event is called and its <c>Cancelled</c> read in the same place, so a listener cancels the same
/// way wherever it is registered, and unregistering this feature takes the events away with the
/// handling rather than leaving half of it behind.
/// </summary>
[CallsEvent(typeof(EntityDeathEvent), typeof(PlayerDeathEvent))]
public class DeathFeature : ScopedFeature {
    /// <summary>
    /// How long a dead entity is left for its death animation to play before it is removed, in ticks.
    /// Vanilla's twenty. Zero removes it in the same tick it died. Players are never removed, so this
    /// does not apply to them.
    /// </summary>
    public int RemoveAfterTicks { get; set; } = 20;

    /// <summary>
    /// The message a dead player's death screen starts with. Listeners see it on
    /// <see cref="PlayerDeathEvent.Message"/> and can replace it, so this is only the default.
    /// </summary>
    public Func<Player, TextComponent> DeathMessage { get; set; } =
        _ => TextComponent.FromLegacyString("&7You died.");

    public override void Register() {
        AddEventHandler<ServerTickEvent>(e => {
            foreach (World world in ScopedWorlds(e.Server)) {
                // GetEntities hands back a copy, so removing one from inside the loop is fine.
                foreach (Entity entity in world.Entities.GetEntities()) {
                    if (entity is LivingEntity { IsDead: false, Health: <= 0 } living) {
                        Die(world, living);
                    }
                }
            }
        });
    }

    /// <summary>
    /// The worlds this instance is responsible for. <see cref="ServerTickEvent"/> reaches a world's
    /// event node as well as the server's, so a feature registered on one world has to keep to that
    /// world or every world would be handled once per registration.
    /// </summary>
    private List<World> ScopedWorlds(ManagedMinecraftServer server) {
        return Scope is World world ? [world] : server.Worlds;
    }

    private void Die(World world, LivingEntity entity) {
        // Set before the event so a listener that heals the entity from inside it clears this itself,
        // and so a cancelled death is not announced again on the next tick.
        entity.IsDead = true;

        EntityDeathEvent deathEvent = entity is Player player
            ? new PlayerDeathEvent {
                LivingEntity = player,
                World = world,
                Message = DeathMessage(player)
            }
            : new EntityDeathEvent {
                LivingEntity = entity,
                World = world
            };

        world.Events.CallEvent(deathEvent);
        if (deathEvent.Cancelled) {
            return;
        }

        // Vanilla's entity event 3: falling over and the death sound.
        entity.SendToSelfAndViewers(new ClientBoundEntityEventPacket {
            EntityId = entity.NetId,
            Status = ClientBoundEntityEventPacket.EntityEventType.LivingEntityDie
        });

        if (deathEvent is PlayerDeathEvent playerDeath) {
            playerDeath.Player.SendPacket(new ClientBoundCombatDeathPacket {
                PlayerId = playerDeath.Player.NetId,
                Message = playerDeath.Message
            });
            return;
        }

        if (RemoveAfterTicks <= 0) {
            Remove(world, entity);
            return;
        }

        world.Server.Scheduler.ScheduleTask(RemoveAfterTicks, () => Remove(world, entity));
    }

    /// <summary>
    /// Checked again on the way out, because the delay is long enough for something to have healed the
    /// entity or moved it to another world, and neither of those should still be removed here.
    /// </summary>
    private static void Remove(World world, LivingEntity entity) {
        if (!entity.IsDead || entity.World != world) {
            return;
        }

        entity.Despawn();
    }
}
