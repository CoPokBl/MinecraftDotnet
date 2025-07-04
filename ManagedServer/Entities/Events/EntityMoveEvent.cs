using ManagedServer.Entities.Types;
using Minecraft.Implementations.Server.Events;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities.Events;

public class EntityMoveEvent : IServerEvent {
    public required Entity Entity;
    public required Vec3 NewPos;
}