using System.Diagnostics;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Features;

public class HeartbeatsFeature(int heartbeatDelay) : IFeature {
    private MinecraftServer _server = null!;
    
    public void Register(MinecraftServer server) {
        _server = server;

        _ = RunHeartbeats();  // Do it async
    }

    public Type[] GetDependencies() {
        return [];
    }

    private async Task RunHeartbeats() {
        while (true) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            foreach (PlayerConnection connection in _server.Connections.Where(connection => connection.State == PlayerConnectionState.Play)) {
                await connection.SendPacket(new ClientBoundKeepAlivePacketPlay(Random.Shared.Next()));
            }

            if (stopwatch.ElapsedMilliseconds < heartbeatDelay) {
                await Task.Delay(heartbeatDelay - (int)stopwatch.ElapsedMilliseconds);
            }
        }
    }
}