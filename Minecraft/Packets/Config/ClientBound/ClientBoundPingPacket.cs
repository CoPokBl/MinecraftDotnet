namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundPingPacket : ClientBoundPacket {
    public required int Id;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteInteger(Id)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPingPacket {
        Id = r.ReadInteger()
    };
}
