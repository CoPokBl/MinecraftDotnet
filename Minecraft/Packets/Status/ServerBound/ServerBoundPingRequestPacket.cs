using Minecraft.Packets.Status.ClientBound;

namespace Minecraft.Packets.Status.ServerBound;

public class ServerBoundPingRequestPacket : ServerBoundPacket {
    public required long Payload;

    protected override byte[] GetData() {
        return new DataWriter().WriteLong(Payload).ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundPingRequestPacket {
        Payload = r.ReadLong()
    };

    public ClientBoundPingResponsePacket CreateResponse() {
        return new ClientBoundPingResponsePacket {
            Payload = Payload
        };
    }
}
