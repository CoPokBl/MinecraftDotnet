using Minecraft.NBT;
using Minecraft.NBT.Text;
using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundLoginDisconnectPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:login_disconnect";
    
    public required TextComponent Reason;  // in JSON for some stupid reason, not in NBT

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Reason.ToJsonString())
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundLoginDisconnectPacket {
        Reason = TextComponent.FromTag(INbtTag.FromJson(r.ReadString()))
    };
}
