namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundKeepAlivePacketPlay : ClientBoundPacket {
    public required long Id;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteLong(Id)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundKeepAlivePacketPlay {
        Id = r.ReadLong()
    };
}
