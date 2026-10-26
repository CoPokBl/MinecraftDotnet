using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Features.Basic;
using ManagedServer.Worlds;
using Minecraft.Implementations.Events;

namespace ManagedServer.Events;

/// <summary>
/// Called when a living entity's health reaches zero, by <see cref="DeathFeature"/>, which is also what
/// removes the entity afterwards.
/// <p/>
/// Cancelling skips that default handling, it does not bring the entity back: its health is still zero
/// and <see cref="LivingEntity.IsDead"/> is still set, so a listener that cancels owns what happens to
/// the entity next and is the one that has to heal it. Until something does, the same zero is not
/// reported again.
/// </summary>
[NotCalledByDefault]
public class EntityDeathEvent : ICancelableEvent, IEntityEvent {
    /// <summary>
    /// The entity that died. Its health is already zero by the time this is called.
    /// </summary>
    public required LivingEntity LivingEntity { get; init; }

    public required World World { get; init; }

    /// <summary>
    /// Whether to skip the default handling, which is the death animation and then removing the entity.
    /// </summary>
    public bool Cancelled { get; set; }

    public Entity Entity {
        get => LivingEntity;
        init { }
    }
}
