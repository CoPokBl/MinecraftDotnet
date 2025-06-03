using Minecraft.Implementations.Server.Connections;

namespace Minecraft.Implementations.Server;

public abstract class ConnectionProvider(Action<PlayerConnection> connectionConsumer) {
    protected Action<PlayerConnection> ConnectionConsumer { get; } = connectionConsumer;
}