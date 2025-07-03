using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSystemChatMessagePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:system_chat";
    
    public required TextComponent Content;
    public required bool ActionBar;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteNbt(Content)
            .WriteBoolean(ActionBar)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSystemChatMessagePacket {
        Content = r.ReadText(),
        ActionBar = r.ReadBoolean()
    };
}
