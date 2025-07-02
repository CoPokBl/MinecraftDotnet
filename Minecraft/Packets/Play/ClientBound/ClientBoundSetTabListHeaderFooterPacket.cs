using Minecraft.NBT.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetTabListHeaderFooterPacket : ClientBoundPacket {
    public required TextComponent Header;
    public required TextComponent Footer;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteNbt(Header)
            .WriteNbt(Footer)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetTabListHeaderFooterPacket {
        Header = r.ReadText(),
        Footer = r.ReadText()
    };
}
