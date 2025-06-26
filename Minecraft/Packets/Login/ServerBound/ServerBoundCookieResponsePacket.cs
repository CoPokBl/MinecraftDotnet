namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundCookieResponsePacket : ServerBoundPacket {
    public required string Key;
    public required byte[]? Data;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Key)
            .WritePrefixedOptional(Data, (bs, wr) => 
                wr.WritePrefixedArray(bs, (b, writer) => 
                    writer.Write(b)))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundCookieResponsePacket {
        Key = r.ReadString(),
        Data = r.ReadPrefixedOptional(re => re.ReadPrefixedArray(re2 => re2.Read()))
    };
}
