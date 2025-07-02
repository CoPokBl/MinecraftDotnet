namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundStoreCookiePacket : ClientBoundPacket {
    public required string Key;
    public required byte[] Payload;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Key)
            .WritePrefixedArray(Payload, (b, wr) => wr.Write(b))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundStoreCookiePacket {
        Key = r.ReadString(),
        Payload = r.ReadPrefixedArray(re => re.Read())
    };
}
