namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundKeepAlivePacket : ClientBoundPacket {
    public required long Id;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteLong(Id)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundKeepAlivePacket {
        Id = r.ReadLong()
    };
}
