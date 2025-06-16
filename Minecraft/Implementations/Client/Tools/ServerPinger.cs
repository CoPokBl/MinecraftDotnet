using Minecraft.Packets;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Packets.Status.ServerBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Client.Tools;

public class ServerPinger(string host, int port = 25565) {

    public async Task<ClientBoundStatusResponsePacket> Query() {
        Console.WriteLine("a");
        ServerConnection con = await MinecraftClientUtils.ConnectToServer(host, port);
        Console.WriteLine("b");
        await con.SendPacket(new ServerBoundHandshakePacket(host, ServerBoundHandshakePacket.Intention.Status, (ushort)port));
        Console.WriteLine("c");
        con.State = PlayerConnectionState.Status;
        await con.SendPacket(new ServerBoundStatusRequestPacket());
        Console.WriteLine("d");
        MinecraftPacket pingResp = await con.WaitForPacket();
        Console.WriteLine("e");

        if (pingResp is not ClientBoundStatusResponsePacket status) {
            throw new Exception($"Invalid server response, got: {pingResp.GetPacketId()} aka {pingResp.GetType().FullName}");
        }

        return status;
    }

    public static Task<ClientBoundStatusResponsePacket> QueryServer(string host, int port = 25565) {
        return new ServerPinger(host, port).Query();
    }
}