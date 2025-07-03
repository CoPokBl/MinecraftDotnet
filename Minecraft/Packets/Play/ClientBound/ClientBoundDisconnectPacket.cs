using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundDisconnectPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:disconnect";
    
    public required TextComponent Reason;
    
    protected override byte[] GetData() {
        return new DataWriter()
            .WriteNbt(Reason)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundDisconnectPacket {
        Reason = r.ReadText()
    };
}
