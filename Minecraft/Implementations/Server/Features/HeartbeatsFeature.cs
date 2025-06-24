using System.Diagnostics;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Packets.Play.ClientBound;
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
        while (!_cts.IsCancellationRequested) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            foreach (PlayerConnection connection in _server.Connections.Where(connection => connection.State == PlayerConnectionState.Play)) {
                await connection.SendPacket(new ClientBoundKeepAlivePacketPlay {
                    Id = Random.Shared.Next()
                });
            }

            if (stopwatch.ElapsedMilliseconds < heartbeatDelay) {
                await Task.Delay(heartbeatDelay - (int)stopwatch.ElapsedMilliseconds, _cts.Token);
            }
        }
    }
}