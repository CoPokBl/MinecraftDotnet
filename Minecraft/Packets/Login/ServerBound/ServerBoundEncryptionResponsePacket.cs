using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundEncryptionResponsePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:key";
    
    public required byte[] SharedSecret;
    public required byte[] VerifyToken;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePrefixedArray(SharedSecret, (b, wr) => wr.Write(b))
            .WritePrefixedArray(VerifyToken, (b, wr) => wr.Write(b));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundEncryptionResponsePacket {
        SharedSecret = r.ReadPrefixedArray(re => re.Read()),
        VerifyToken = r.ReadPrefixedArray(re => re.Read())
    };
}
