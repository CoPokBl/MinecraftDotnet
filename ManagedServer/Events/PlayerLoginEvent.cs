using ManagedServer.Entities.Types;
using Minecraft.Implementations.Server.Events;

namespace ManagedServer.Events;

public class PlayerLoginEvent : IServerEvent {
    public required PlayerEntity Player { get; init; }
}