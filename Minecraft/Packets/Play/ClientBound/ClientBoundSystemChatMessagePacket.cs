using Minecraft.NBT;
using Minecraft.NBT.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSystemChatMessagePacket(TextComponent content, bool actionBar) : MinecraftPacket {
    public ITag Content = content;
    public bool ActionBar = actionBar;

    public ClientBoundSystemChatMessagePacket() : this(TextComponent.Empty(), true) { }
    
    public override int GetPacketId() {
        return 0x72;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteNbt(Content)
            .WriteBoolean(ActionBar)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        throw new NotImplementedException();
    }
}