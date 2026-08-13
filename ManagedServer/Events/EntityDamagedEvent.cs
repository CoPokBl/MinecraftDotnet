using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;

namespace ManagedServer.Events;

/// <summary>
/// Called after a hit has landed and the health is already off, so this is what to listen to for
/// anything that reacts to damage rather than decides it: hit markers, aggro, statistics, a kill
/// feed. Use <see cref="EntityDamageEvent"/> to stop a hit instead.
/// <p/>
/// Fired for a hit that came out at zero as well, which is what a hit fully soaked by armour is.
/// <see cref="Amount"/> is what it cost, so that case reads as zero rather than not being reported.
/// <p/>
/// A hit that killed the entity has already taken its health to zero here.
/// <see cref="Features.Basic.DeathFeature"/> announces the death on the following tick.
/// </summary>
[BuiltinEvent]
public class EntityDamagedEvent : IEntityEvent {
    /// <summary>The entity that was hit.</summary>
    public required LivingEntity LivingEntity { get; init; }

    /// <summary>What the hit was, and who dealt it.</summary>
    public required DamageSource Source { get; init; }

    /// <summary>The health actually taken off, after every modifier in the pipeline.</summary>
    public required float Amount { get; init; }

    public required World World { get; init; }

    public Entity Entity {
        get => LivingEntity;
        init { }
    }
}
