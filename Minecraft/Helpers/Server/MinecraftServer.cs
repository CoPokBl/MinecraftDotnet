using System.Net;
using System.Net.Sockets;

namespace Minecraft.Helpers.Server;

public class MinecraftServer(MinecraftServerConfig config) {
    public MinecraftServerConfig Config { get; } = config;

    public async Task Start() {
        TcpListener listener = new(IPAddress.Any, Config.Port);
        listener.Start();

        while (true) {
            TcpClient client = await listener.AcceptTcpClientAsync();
            PlayerConnection connection = new(client.GetStream(), this);
            _ = connection.HandlePackets();
        }
    }
}