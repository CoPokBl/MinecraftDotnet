using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundStoreCookiePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:store_cookie";
    
    public required Identifier Key;
    public required byte[] Payload;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(Key)
            .WritePrefixedArray(Payload, (b, wr) => wr.Write(b));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundStoreCookiePacket {
        Key = r.ReadString(),
        Payload = r.ReadPrefixedArray(re => re.Read())
    };
}
