using Minecraft.Schemas;
using Minecraft.Text;
using NBT;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundLoginDisconnectPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:login_disconnect";
    
    public required TextComponent Reason;  // in JSON for some stupid reason, not in NBT

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(Reason.ToJsonString());
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundLoginDisconnectPacket {
        Reason = TextComponent.FromTag(INbtTag.FromJson(r.ReadString()))
    };
}
