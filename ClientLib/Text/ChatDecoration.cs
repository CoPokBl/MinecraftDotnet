using Minecraft.Data.ChatType;
using Minecraft.Registry;
using Minecraft.Schemas.Chat;
using Minecraft.Text;

namespace ClientLib;

/// <summary><c>ChatType.Bound.decorate</c>: a chat type's translation with its slots filled in.</summary>
public static class ChatDecoration {
    public static TextComponent Decorate(MinecraftRegistry registry, BoundChatType bound, TextComponent content) {
        IChatType? type = bound.ChatType.Value2;
        if (type == null && bound.ChatType.Value1 is { } id) {
            try {
                type = registry.ChatTypes[id];
            }
            catch (KeyNotFoundException) {
                type = null;
            }
        }
        if (type == null) {
            return content;
        }

        ChatTypeDecoration decoration = type.Chat;
        TextComponent[] args = decoration.Parameters.Select(p => p switch {
            ChatDecorationParameter.Sender => bound.SenderName,
            ChatDecorationParameter.Target => bound.TargetName ?? TextComponent.Empty(),
            _ => content
        }).ToArray();
        return TextComponent.Translatable(decoration.TranslationKey, null, args);
    }
}
