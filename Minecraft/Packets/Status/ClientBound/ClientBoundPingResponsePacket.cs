using Minecraft.Schemas;

namespace Minecraft.Packets.Status.ClientBound;

public class ClientBoundPingResponsePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:pong_response";
    
    public required long Payload;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteLong(Payload)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPingResponsePacket {
        Payload = r.ReadLong()
    };
}
