using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Handshake;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Packets.Status.ServerBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Client.Tools;

public class ServerPinger(string host, int port = 25565) {

    public async Task<ClientBoundStatusResponsePacket> Query() {
        ServerConnection con = await MinecraftClientUtils.ConnectToServer(host, port);
        con.SendPacket(new ServerBoundHandshakePacket {
            Hostname = host,Intent = ServerBoundHandshakePacket.Intention.Status,
            Port = (ushort)port,
            ProtocolVersion = 770  // 1.21.5
        });
        con.State = ConnectionState.Status;
        con.SendPacket(new ServerBoundStatusRequestPacket());
        MinecraftPacket pingResp = await con.WaitForPacket();

        if (pingResp is not ClientBoundStatusResponsePacket status) {
            throw new Exception($"Invalid server response, got: {VanillaRegistry.Data.Packets.GetPacketId(ConnectionState.Status, pingResp)} aka {pingResp.GetType().FullName}");
        }

        return status;
    }

    public static Task<ClientBoundStatusResponsePacket> QueryServer(string host, int port = 25565) {
        return new ServerPinger(host, port).Query();
    }
}