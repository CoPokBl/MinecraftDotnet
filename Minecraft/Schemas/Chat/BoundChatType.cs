using Minecraft.Data;
using Minecraft.Data.ChatType;
using Minecraft.Registry;
using Minecraft.Text;

namespace Minecraft.Schemas.Chat;

/// <summary>
/// A chat type together with the names filling its translation slots. Every chat message the
/// server sends carries one of these so the client knows how to lay the line out.
/// </summary>
public class BoundChatType : INetworkType<BoundChatType> {
    /// <summary>
    /// Either the key of a chat type in the chat type registry, or a chat type sent inline.
    /// </summary>
    public required Or<Identifier, IChatType> ChatType { get; init; }

    /// <summary>Fills the decoration's <see cref="ChatDecorationParameter.Sender"/> slot.</summary>
    public required TextComponent SenderName { get; init; }

    /// <summary>Fills the decoration's <see cref="ChatDecorationParameter.Target"/> slot, if it has one.</summary>
    public TextComponent? TargetName { get; init; }

    /// <summary>
    /// Inline chat types have no registry key, but <see cref="IChatType"/> implementations all
    /// carry one, so deserialised inline chat types get this placeholder.
    /// </summary>
    public static readonly Identifier InlineIdentifier = "minecraft:inline_chat_type";

    public static BoundChatType Reference(Identifier chatType, TextComponent senderName, TextComponent? targetName = null) {
        return new BoundChatType {
            ChatType = Or<Identifier, IChatType>.FromValue1(chatType),
            SenderName = senderName,
            TargetName = targetName
        };
    }

    public DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        Or<int, IChatType> idOr = ChatType.IsValue1
            ? Or<int, IChatType>.FromValue1(reg.ChatTypes.GetProtocolId(ChatType.Value1!))
            : Or<int, IChatType>.FromValue2(ChatType.Value2!);

        return w
            .WriteIdOr(idOr, (chatType, writer) => {
                chatType.Chat.Write(writer);
                chatType.Narration.Write(writer);
            })
            .WriteNbt(SenderName)
            .WritePrefixedOptional(TargetName, (name, writer) => writer.WriteNbt(name));
    }

    public static BoundChatType ReadData(DataReader r, MinecraftRegistry reg) {
        return new BoundChatType {
            ChatType = r.ReadIdOr(
                id => reg.ChatTypes[id].Identifier,
                reader => (IChatType)new SimpleChatType(
                    InlineIdentifier,
                    ChatTypeDecoration.Read(reader),
                    ChatTypeDecoration.Read(reader))),
            SenderName = r.ReadText(),
            TargetName = r.ReadPrefixedOptional(reader => reader.ReadText())
        };
    }
}
