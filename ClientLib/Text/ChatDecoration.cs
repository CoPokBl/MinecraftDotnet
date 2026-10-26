using Minecraft.Data.ChatType;
using Minecraft.Registry;
using Minecraft.Schemas.Chat;
using Minecraft.Text;

namespace ClientLib;

/// <summary><c>ChatType.Bound.decorate</c>: a chat type's translation with its slots filled in.</summary>
public static class ChatDecoration {
    public static TextComponent Decorate(MinecraftRegistry registry, BoundChatType bound, TextComponent content) =>
        TypeOf(registry, bound) is { } type ? Decorate(type.Chat, bound, content) : content;

    /// <summary><c>ChatType.Bound.decorateNarration</c>.</summary>
    public static TextComponent DecorateNarration(MinecraftRegistry registry, BoundChatType bound, TextComponent content) =>
        TypeOf(registry, bound) is { } type ? Decorate(type.Narration, bound, content) : content;

    private static IChatType? TypeOf(MinecraftRegistry registry, BoundChatType bound) {
        IChatType? type = bound.ChatType.Value2;
        if (type == null && bound.ChatType.Value1 is { } id) {
            try {
                type = registry.ChatTypes[id];
            }
            catch (KeyNotFoundException) {
                type = null;
            }
        }
        return type;
    }

    /// <summary><c>ChatTypeDecoration.decorate</c>: the translation, then the decoration's style over it.</summary>
    private static TextComponent Decorate(ChatTypeDecoration decoration, BoundChatType bound, TextComponent content) {
        TextComponent[] args = decoration.Parameters.Select(p => p switch {
            ChatDecorationParameter.Sender => bound.SenderName,
            ChatDecorationParameter.Target => bound.TargetName ?? TextComponent.Empty(),
            _ => content
        }).ToArray();
        TextComponent decorated = TextComponent.Translatable(decoration.TranslationKey, null, args);
        TextStyle style = decoration.Style;
        decorated.Color = style.Color ?? decorated.Color;
        decorated.ShadowColor = style.ShadowColor ?? decorated.ShadowColor;
        decorated.Bold = style.Bold ?? decorated.Bold;
        decorated.Italic = style.Italic ?? decorated.Italic;
        decorated.Underlined = style.Underlined ?? decorated.Underlined;
        decorated.Strikethrough = style.Strikethrough ?? decorated.Strikethrough;
        decorated.Obfuscated = style.Obfuscated ?? decorated.Obfuscated;
        decorated.Font = style.Font ?? decorated.Font;
        decorated.Insertion = style.Insertion ?? decorated.Insertion;
        return decorated;
    }
}
