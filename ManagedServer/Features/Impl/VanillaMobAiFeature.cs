using ManagedServer.Ai.Vanilla;
using ManagedServer.Entities.Types;
using ManagedServer.Events;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Gives a mob vanilla's goals when it spawns. It is the whole of the "builtin behaviour" half of the
/// AI system; the engine that runs those goals is core and works without this.
/// <p/>
/// Deliberately not in <c>BasicsBundle</c>, for the same reason <c>LiquidsFeature</c> is not: it
/// decides what every mob in the world does. <c>MobsBundle</c> pairs it with the physics feature it
/// needs, since a mob whose movement is never simulated cannot go anywhere.
/// <p/>
/// A mob that already has goals is left alone, so three ways of getting behaviour compose without a
/// flag: let this install vanilla's, add to <c>mob.Goals</c> before spawning, or subclass
/// <see cref="Mob"/> and override its goal registration.
/// </summary>
public class VanillaMobAiFeature(MobAiRegistry? registry = null) : ScopedFeature {
    /// <summary>
    /// The table applied on spawn. Defaults to a fresh copy of vanilla's; mutate this one rather than
    /// <see cref="MobAiRegistry.Vanilla"/> to change what a type does.
    /// </summary>
    public MobAiRegistry Registry { get; } = registry ?? MobAiRegistry.Vanilla;

    public override void Register() {
        AddEventHandler<EntitySpawnEvent>(e => {
            if (e.Entity is not Mob mob) {
                return;
            }

            // Anything already carrying behaviour keeps it, which is what makes adding a goal by hand
            // an override rather than an addition. Both selectors are checked because a mob given only
            // target goals has still been configured by somebody.
            if (!mob.Goals.IsEmpty || !mob.TargetGoals.IsEmpty) {
                return;
            }

            Registry.Apply(mob);
        });
    }
}
