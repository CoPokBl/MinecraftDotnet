using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Managed.Entities.Types;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Managed.Entities.Events;

public class EntityMoveEvent : IServerEvent {
    public required Entity Entity;
    public required Vec3 NewPos;
}