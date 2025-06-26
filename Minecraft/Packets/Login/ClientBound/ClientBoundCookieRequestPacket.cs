namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundCookieRequestPacket : ClientBoundPacket {
    public required string Key;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Key)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundCookieRequestPacket {
        Key = r.ReadString()
    };
}
