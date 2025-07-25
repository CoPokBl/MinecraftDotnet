using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

/// <summary>
/// Called when an entity moves to a new position.
/// </summary>
[BuiltinEvent]
public class EntityMoveEvent : IEntityEvent {
    /// <summary>
    /// The entity that moved.
    /// </summary>
    public required Entity Entity { get; init; }
    
    /// <summary>
    /// The entity's new position.
    /// <p/>
    /// To see the entity's previous position, use Entity.<see cref="Entity.Position"/>.
    /// </summary>
    public required Vec3<double> NewPos { get; init; }
    
    public required World World { get; init; }
}
