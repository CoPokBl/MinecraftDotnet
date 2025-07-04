using Minecraft.Schemas;

namespace Minecraft.Packets.Status.ClientBound;

public class ClientBoundPingResponsePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:pong_response";
    
    public required long Payload;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteLong(Payload);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPingResponsePacket {
        Payload = r.ReadLong()
    };
}
