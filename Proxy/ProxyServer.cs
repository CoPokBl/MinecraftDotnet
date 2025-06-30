using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server;

namespace Proxy;

public class ProxyServer {
    public EventNode<ProxyEvent> Events = new();

    public async Task Start() {
        TcpMinecraftListener listener = new(connection => {
            ProxiedConnection proxiedConnection = new(this, connection);
        }, CancellationToken.None);

        await listener.Listen(25577);
    }
}
