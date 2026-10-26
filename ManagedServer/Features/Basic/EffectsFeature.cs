using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Worlds;
using Minecraft.Schemas;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Counts status effect durations down and reports the ones that run out, the half of vanilla's
/// <c>LivingEntity.tickEffects</c> that is bookkeeping rather than gameplay. What an effect actually
/// does belongs to whatever feature owns it, which is why nothing here looks at which effect it is.
/// <p/>
/// Effects are held on the entity whether this is registered or not, the same way a fall distance is.
/// Without it nothing counts them down and every effect is permanent.
/// </summary>
[CallsEvent(typeof(EntityEffectExpireEvent))]
public class EffectsFeature : ScopedFeature {
    public override void Register() {
        AddEventHandler<ServerTickEvent>(e => {
            foreach (World world in ScopedWorlds(e.Server)) {
                // GetEntities hands back a copy, so an expiry listener removing an entity is fine.
                foreach (Entity entity in world.Entities.GetEntities()) {
                    if (entity is LivingEntity living) {
                        Tick(world, living);
                    }
                }
            }
        });
    }

    private List<World> ScopedWorlds(ManagedMinecraftServer server) {
        return Scope is World world ? [world] : server.Worlds;
    }

    private static void Tick(World world, LivingEntity entity) {
        foreach (PotionEffect expired in entity.Effects.TickDurations()) {
            world.Events.CallEvent(new EntityEffectExpireEvent {
                LivingEntity = entity,
                Effect = expired,
                World = world
            });
        }
    }
}
