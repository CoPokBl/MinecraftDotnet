using Minecraft.Implementations.Server.Connections;

namespace Minecraft.Implementations.Server.Events;

public interface IPacketEvent : IServerEvent {
    public PlayerConnection Connection { get; }
}
