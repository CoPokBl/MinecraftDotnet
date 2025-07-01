using System.Net;
using System.Net.Sockets;
using Minecraft.Implementations.Server.Connections;

namespace Minecraft.Implementations.Server;

public class TcpMinecraftListener(Action<PlayerConnection> connectionConsumer, CancellationToken cancel) : ConnectionProvider(connectionConsumer) {

    public async Task Listen(int port = 25565) {
        TcpListener listener = new(IPAddress.Any, port);
        listener.Start();

        while (!cancel.IsCancellationRequested) {
            TcpClient client = await listener.AcceptTcpClientAsync(cancel);
            client.NoDelay = true;
            PlayerConnection connection = new TcpPlayerConnection(client);
            ConnectionConsumer(connection);
            _ = connection.HandlePackets();
        }
        
        listener.Stop();
    }
}