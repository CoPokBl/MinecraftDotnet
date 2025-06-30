using System.Net.Sockets;

namespace Minecraft.Implementations.Client;

public static class MinecraftClientUtils {

    public static async Task<ServerConnection> ConnectToServer(string host, int port = 25565, bool packetQueuing = false) {
        TcpClient client = new();
        await client.ConnectAsync(host, port);
        TcpServerConnection con = new(client, packetQueuing);
        _ = con.HandlePackets();
        return con;
    }
}
