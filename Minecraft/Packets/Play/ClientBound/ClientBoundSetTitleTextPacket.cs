using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetTitleTextPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_title_text";
    
    public required TextComponent Text;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteNbt(Text)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetTitleTextPacket {
        Text = r.ReadText()
    };
}
