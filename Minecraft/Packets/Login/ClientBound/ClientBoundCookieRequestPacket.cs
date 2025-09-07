using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundCookieRequestPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:cookie_request";
    
    public required Identifier Key { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(Key);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundCookieRequestPacket {
        Key = r.ReadString()
    };
}
