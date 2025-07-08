using ManagedServer.Worlds;
using Minecraft.Implementations.Server.Events;

namespace ManagedServer.Events.Types;

public interface IWorldEvent : IServerEvent {
    public World World { get; init; }
}
