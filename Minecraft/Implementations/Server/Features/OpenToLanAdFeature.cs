using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Minecraft.Implementations.Server.Features;

/// <summary>
/// A feature that announces itself on the local network over LAN.
/// </summary>
/// <param name="motd">The MOTD to broadcast.</param>
/// <param name="port">The port to announce that we are on.</param>
public class OpenToLanAdFeature(string motd, int port) : IServerFeature {
    private readonly IPEndPoint _broadcastEndpoint = new(IPAddress.Parse("224.0.2.60"), 4445);  // Weird constant
    
    private readonly CancellationTokenSource _cts = new();
    
    public void Register(MinecraftServer server) {
        _ = AdvertiseTask();
    }

    private async Task AdvertiseTask() {
        UdpClient client = new();
        string packetStr = $"[MOTD]{motd}[/MOTD][AD]{port}[/AD]";
        ReadOnlyMemory<byte> mem = new(Encoding.UTF8.GetBytes(packetStr));
        while (!_cts.IsCancellationRequested) {
            await Task.Delay(TimeSpan.FromSeconds(1.5));  // vanilla uses 1.5 seconds
            await client.SendAsync(mem, _broadcastEndpoint, _cts.Token);
        }
    }

    public void Unregister() {
        _cts.Cancel();
    }

    public Type[] GetDependencies() {
        return [];
    }
}