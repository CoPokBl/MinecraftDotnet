using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSystemChatMessagePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:system_chat";
    
    public required TextComponent Content;
    public required bool ActionBar;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteNbt(Content)
            .WriteBoolean(ActionBar);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSystemChatMessagePacket {
        Content = r.ReadText(),
        ActionBar = r.ReadBoolean()
    };
}
