using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetSubtitleTextPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_subtitle_text";
    
    public required TextComponent Text { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteNbt(Text);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetSubtitleTextPacket {
        Text = r.ReadText()
    };
}
