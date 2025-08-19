using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Handshake;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Packets.Status.ServerBound;
using Minecraft.Text;

namespace TestServer.Servers.Transferer;

public static class TransferTest {

    public static async Task Start() {
        TcpMinecraftListener listener = new(con => {
            _ = HandleConnection(con);
        }, CancellationToken.None);
        await listener.Listen(25566);
    }

    private static T IsPacket<T>(PacketHandleEvent e) where T : ServerBoundPacket {
        if (e.Packet is not T packet) {
            throw new ArgumentException($"Expected packet of type {typeof(T).Name}, but got {e.Packet.GetType().Name}");
        }
        
        return packet;
    }
    
    private static async Task<T> GetPacket<T>(PlayerConnection con) where T : ServerBoundPacket {
        PacketHandleEvent e = await con.Events.GetWaiterFor<PacketHandleEvent>();
        return IsPacket<T>(e);
    }

    public static async Task HandleConnection(PlayerConnection con) {
        ServerBoundHandshakePacket handshake = await GetPacket<ServerBoundHandshakePacket>(con);
        if (handshake.Intent == ServerBoundHandshakePacket.Intention.Status) {
            // status request
            await GetPacket<ServerBoundStatusRequestPacket>(con);

            con.SendPacket(new ClientBoundStatusResponsePacket {
                OnlinePlayers = 1,
                MaxPlayers = 100,
                VersionProtocol = 1,
                VersionName = "Transfer Server",
                Description = TextComponent.FromLegacyString("&a&kaaa &r&bHello there buddy! &a&kaaa")
            });

            ServerBoundPingRequestPacket ping = await GetPacket<ServerBoundPingRequestPacket>(con);
            con.SendPacket(new ClientBoundPingResponsePacket {
                Payload = ping.Payload
            });
        }
        
        await GetPacket<ServerBoundLoginStartPacket>(con);
        
        con.SendPacket(new ClientBoundLoginSuccessPacket {
            Username = "bob",
            Uuid = Guid.NewGuid()
        });

        await GetPacket<ServerBoundLoginAcknowledgedPacket>(con);
        
        // We're in config now
        // transfer them
        con.SendPacket(new ClientBoundTransferPacket {
            Host = "localhost",
            Port = 25565
        });
    }
}
