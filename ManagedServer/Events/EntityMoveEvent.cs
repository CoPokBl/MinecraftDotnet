using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

[BuiltinEvent]
public class EntityMoveEvent : IEntityEvent {
    public required Entity Entity { get; init; }
    public required Vec3 NewPos { get; init; }
    public required World World { get; init; }
}
