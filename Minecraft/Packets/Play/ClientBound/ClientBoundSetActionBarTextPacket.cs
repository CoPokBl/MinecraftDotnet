using Minecraft.NBT.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetActionBarTextPacket(TextComponent text) : MinecraftPacket {
    public TextComponent Text = text;
    
    public ClientBoundSetActionBarTextPacket() : this(TextComponent.Empty()) { }

    public override int GetPacketId() {
        return 0x50;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteNbt(Text)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        Text = new DataReader(data).ReadText();
        return this;
    }
}