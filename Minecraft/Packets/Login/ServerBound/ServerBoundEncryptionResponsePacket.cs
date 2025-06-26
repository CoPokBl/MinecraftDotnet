namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundEncryptionResponsePacket : ServerBoundPacket {
    public required byte[] SharedSecret;
    public required byte[] VerifyToken;

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePrefixedArray(SharedSecret, (b, wr) => wr.Write(b))
            .WritePrefixedArray(VerifyToken, (b, wr) => wr.Write(b))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundEncryptionResponsePacket {
        SharedSecret = r.ReadPrefixedArray(re => re.Read()),
        VerifyToken = r.ReadPrefixedArray(re => re.Read())
    };
}
