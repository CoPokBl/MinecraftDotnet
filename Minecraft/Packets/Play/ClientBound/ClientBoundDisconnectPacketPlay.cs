using Minecraft.NBT.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundDisconnectPacketPlay(TextComponent reason) : MinecraftPacket {
    public TextComponent Reason = reason;
    
    public ClientBoundDisconnectPacketPlay() : this(TextComponent.Empty()) { }
    
    public override int GetPacketId() {
        return 0x1C;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteNbt(Reason)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Reason = r.ReadText();
        return this;
    }
}