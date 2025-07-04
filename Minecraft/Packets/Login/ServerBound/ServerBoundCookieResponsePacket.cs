using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundCookieResponsePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:cookie_response";
    
    public required string Key;
    public required byte[]? Data;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(Key)
            .WritePrefixedOptional(Data, (bs, wr) => 
                wr.WritePrefixedArray(bs, (b, writer) => 
                    writer.Write(b)));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundCookieResponsePacket {
        Key = r.ReadString(),
        Data = r.ReadPrefixedOptional(re => re.ReadPrefixedArray(re2 => re2.Read()))
    };
}
