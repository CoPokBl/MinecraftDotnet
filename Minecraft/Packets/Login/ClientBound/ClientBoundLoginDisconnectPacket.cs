using Minecraft.NBT;
using Minecraft.NBT.Text;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundLoginDisconnectPacket : ClientBoundPacket {
    public required TextComponent Reason;  // in JSON for some stupid reason, not in NBT

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Reason.ToJsonString())
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundLoginDisconnectPacket {
        Reason = TextComponent.FromTag(ITag.FromJson(r.ReadString()))
    };
}
