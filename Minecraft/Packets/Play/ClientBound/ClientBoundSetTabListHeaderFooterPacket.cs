using Minecraft.NBT.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetTabListHeaderFooterPacket(TextComponent header, TextComponent footer) : MinecraftPacket {
    public TextComponent Header = header;
    public TextComponent Footer = footer;

    public ClientBoundSetTabListHeaderFooterPacket() : this(TextComponent.Empty(), TextComponent.Empty()) { }
    
    public override int GetPacketId() {
        return 0x73;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteNbt(Header)
            .WriteNbt(Footer)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Header = r.ReadText();
        Footer = r.ReadText();
        return this;
    }
}