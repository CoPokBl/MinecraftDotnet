using System.Net;
using System.Net.Sockets;
using Minecraft.Implementations.Server.Connections;

namespace Minecraft.Implementations.Server;

public class TcpMinecraftListener(Action<PlayerConnection> connectionConsumer, CancellationToken cancel) : ConnectionProvider(connectionConsumer) {

    public async Task Listen(int port = 25565) {
        TcpListener listener = new(IPAddress.Any, port);
        listener.Start();

        try {
            while (!cancel.IsCancellationRequested) {
                TcpClient client = await listener.AcceptTcpClientAsync(cancel);
                client.NoDelay = true;
                PlayerConnection connection = new TcpPlayerConnection(client);
                ConnectionConsumer(connection);

                // Observed rather than dropped on the floor. The read loop ends by tearing the
                // connection down, so a failure in somebody's disconnect handler faults this task, and
                // with nothing watching it the whole teardown went missing in silence.
                _ = connection.HandlePackets().ContinueWith(
                    t => Console.WriteLine($"Connection handler failed: {t.Exception}"),
                    TaskContinuationOptions.OnlyOnFaulted);
            }
        }
        catch (OperationCanceledException) {
            // this is normal
        }
        
        listener.Stop();
        listener.Dispose();
    }
}