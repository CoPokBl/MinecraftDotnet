using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Features.Basic;
using ManagedServer.Worlds;
using Minecraft.Schemas;

namespace ManagedServer.Events;

/// <summary>
/// Called by <see cref="EffectsFeature"/> when a status effect's duration runs out. The effect is
/// already off the entity by the time this is called, so this is a report rather than a decision;
/// putting it back is a matter of adding it again.
/// <p/>
/// An effect taken off by hand does not come through here, since whatever took it off already knows.
/// </summary>
[NotCalledByDefault]
public class EntityEffectExpireEvent : IEntityEvent {
    /// <summary>The entity the effect was on.</summary>
    public required LivingEntity LivingEntity { get; init; }

    /// <summary>The effect as it was on its last tick, so its amplifier is still readable.</summary>
    public required PotionEffect Effect { get; init; }

    public required World World { get; init; }

    public Entity Entity {
        get => LivingEntity;
        init { }
    }
}
