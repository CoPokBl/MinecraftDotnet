using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chat;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Sends a message that is laid out like player chat but carries no signature, which is how
/// commands such as <c>/me</c> and <c>/say</c> reach the chat window.
/// </summary>
public class ClientBoundDisguisedChatMessagePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:disguised_chat";

    public required TextComponent Message { get; init; }
    public required BoundChatType ChatType { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteNbt(Message)
            .Write(ChatType, reg);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundDisguisedChatMessagePacket {
        Message = r.ReadText(),
        ChatType = r.Read<BoundChatType>(reg)
    };
}
