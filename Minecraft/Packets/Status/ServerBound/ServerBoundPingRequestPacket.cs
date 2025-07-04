using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;

namespace Minecraft.Packets.Status.ServerBound;

public class ServerBoundPingRequestPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:ping_request";
    
    public required long Payload;

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteLong(Payload);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPingRequestPacket {
        Payload = r.ReadLong()
    };

    public ClientBoundPingResponsePacket CreateResponse() {
        return new ClientBoundPingResponsePacket {
            Payload = Payload
        };
    }
}
