using Minecraft.Schemas;

namespace Minecraft.Data.ChatType;

public record SimpleChatType(
    Identifier Identifier,
    ChatTypeDecoration Chat,
    ChatTypeDecoration Narration) : IChatType;
