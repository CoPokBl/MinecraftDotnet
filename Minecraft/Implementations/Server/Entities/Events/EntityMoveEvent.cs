using Minecraft.Implementations.Server.Events;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Entities.Events;

public class EntityMoveEvent : ServerEvent {
    public required Entity Entity;
    public required Vec3 NewPos;
}