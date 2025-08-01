using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundEncryptionRequestPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:hello";
    
    public required string ServerId;
    public required byte[] PublicKey;
    public required byte[] VerifyToken;
    public required bool ShouldAuthenticate;

    protected override DataWriter WriteData(DataWriter w) {
        Assert(ServerId.Length <= 20, "ServerId must be 20 characters or less.");
        
        return w
            .WriteString(ServerId)
            .WritePrefixedArray(PublicKey, (b, wr) => wr.Write(b))
            .WritePrefixedArray(VerifyToken, (b, wr) => wr.Write(b))
            .WriteBoolean(ShouldAuthenticate);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundEncryptionRequestPacket {
        ServerId = r.ReadString(),
        PublicKey = r.ReadPrefixedArray(re => re.Read()),
        VerifyToken = r.ReadPrefixedArray(re => re.Read()),
        ShouldAuthenticate = r.ReadBoolean(),
    };
}