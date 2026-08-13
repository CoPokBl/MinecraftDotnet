using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Implementations.Events;

namespace ManagedServer.Events;

/// <summary>
/// Called by <see cref="LivingEntity.Damage(DamageSource, float)"/> when a hit gets past the
/// invulnerable window, before anything reduces it. This is the hook for deciding whether a hit
/// happens at all: immunity, a game that has already ended, a spectator.
/// <p/>
/// Cancelling drops the hit entirely, and the entity is left exactly as it was, including its
/// invulnerable window, so a cancelled hit does not protect it from the next one.
/// <p/>
/// <see cref="Amount"/> is the raw damage and is settable, but changing it here is a blunt
/// instrument: it runs before the reductions and outside their order. Anything that reduces damage
/// as a rule belongs in the <see cref="DamagePipeline"/> as an <see cref="IDamageModifier"/>, which
/// is what makes it compose with armour and resistance instead of fighting them.
/// </summary>
[BuiltinEvent]
public class EntityDamageEvent : ICancelableEvent, IEntityEvent {
    /// <summary>The entity being hit.</summary>
    public required LivingEntity LivingEntity { get; init; }

    /// <summary>What the hit is, and who dealt it.</summary>
    public required DamageSource Source { get; init; }

    /// <summary>The damage before the pipeline, already past the invulnerable window.</summary>
    public required float Amount { get; set; }

    public required World World { get; init; }

    /// <summary>Whether to drop the hit, leaving the entity untouched.</summary>
    public bool Cancelled { get; set; }

    public Entity Entity {
        get => LivingEntity;
        init { }
    }
}
