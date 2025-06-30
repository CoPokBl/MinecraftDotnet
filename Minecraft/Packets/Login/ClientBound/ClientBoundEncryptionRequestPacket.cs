namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundEncryptionRequestPacket : ClientBoundPacket {
    public required string ServerId;
    public required byte[] PublicKey;
    public required byte[] VerifyToken;
    public required bool ShouldAuthenticate;

    protected override byte[] GetData() {
        Assert(ServerId.Length <= 20, "ServerId must be 20 characters or less.");
        
        return new DataWriter()
            .WriteString(ServerId)
            .WritePrefixedArray(PublicKey, (b, wr) => wr.Write(b))
            .WritePrefixedArray(VerifyToken, (b, wr) => wr.Write(b))
            .WriteBoolean(ShouldAuthenticate)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundEncryptionRequestPacket {
        ServerId = r.ReadString(),
        PublicKey = r.ReadPrefixedArray(re => re.Read()),
        VerifyToken = r.ReadPrefixedArray(re => re.Read()),
        ShouldAuthenticate = r.ReadBoolean(),
    };
}