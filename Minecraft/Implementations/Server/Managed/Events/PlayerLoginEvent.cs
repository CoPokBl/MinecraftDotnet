using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Managed.Entities.Types;

namespace Minecraft.Implementations.Server.Managed.Events;

public class PlayerLoginEvent : IServerEvent {
    public required PlayerEntity Player { get; init; }
}