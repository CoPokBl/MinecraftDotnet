using Minecraft.NBT.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSystemChatMessagePacket : ClientBoundPacket {
    public required TextComponent Content;
    public required bool ActionBar;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteNbt(Content)
            .WriteBoolean(ActionBar)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundSystemChatMessagePacket {
        Content = r.ReadText(),
        ActionBar = r.ReadBoolean()
    };
}
