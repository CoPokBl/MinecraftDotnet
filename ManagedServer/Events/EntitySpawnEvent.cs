using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;

namespace ManagedServer.Events;

/// <summary>
/// Called when an entity enters a world, from <see cref="Entity.SetWorld"/> once the entity is
/// registered and its event node is attached. A feature that has to set something up per entity
/// hangs off this rather than sweeping every entity on every tick.
/// <p/>
/// It fires on every move between worlds, not only on the first spawn, because that is what the
/// entity did: <see cref="Entity.World"/> is already the new world when a listener runs. Anything
/// wanting to act once has to keep track of that itself.
/// </summary>
[BuiltinEvent]
public class EntitySpawnEvent : IEntityEvent {
    public required Entity Entity { get; init; }
    public required World World { get; init; }
}
