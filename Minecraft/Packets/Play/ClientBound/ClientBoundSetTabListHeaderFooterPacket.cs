using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetTabListHeaderFooterPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:tab_list";
    
    public required TextComponent Header;
    public required TextComponent Footer;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteNbt(Header)
            .WriteNbt(Footer);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetTabListHeaderFooterPacket {
        Header = r.ReadText(),
        Footer = r.ReadText()
    };
}
