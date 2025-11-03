using System.Diagnostics;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Features;

public class HeartbeatsFeature(int heartbeatDelay) : IServerFeature {
    private MinecraftServer _server = null!;
    private readonly CancellationTokenSource _cts = new();
    
    public void Register(MinecraftServer server) {
        _server = server;

        _ = RunHeartbeats();  // Do it async
    }

    public void Unregister() {
        _cts.Cancel();
    }

    public Type[] GetDependencies() {
        return [];
    }

    private async Task RunHeartbeats() {
        try {
            while (!_cts.IsCancellationRequested) {
                Stopwatch stopwatch = Stopwatch.StartNew();
            
                // Cache the filtered connections to avoid repeated LINQ evaluation
                PlayerConnection[] playConnections = _server.Connections
                    .Where(connection => connection.State == ConnectionState.Play)
                    .ToArray();
                
                foreach (PlayerConnection connection in playConnections) {
                    connection.SendPacket(new ClientBoundKeepAlivePacket {
                        Id = Random.Shared.Next()
                    });
                }

                if (stopwatch.ElapsedMilliseconds < heartbeatDelay) {
                    await Task.Delay(heartbeatDelay - (int)stopwatch.ElapsedMilliseconds, _cts.Token);
                }
            }
        }
        catch (OperationCanceledException) {
            // This is expected when the cancellation token is triggered
        }
    }
}