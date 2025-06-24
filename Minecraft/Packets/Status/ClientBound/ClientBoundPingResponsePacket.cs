namespace Minecraft.Packets.Status.ClientBound;

public class ClientBoundPingResponsePacket : ClientBoundPacket {
    public required long Payload;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteLong(Payload)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundPingResponsePacket {
        Payload = r.ReadLong()
    };
}
