using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundDisconnectPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:disconnect";
    
    public required TextComponent Reason { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteNbt(Reason);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundDisconnectPacket {
        Reason = r.ReadText()
    };
}
