namespace Minecraft.Data.ChatType;

/// <summary>
/// A slot in a chat type's translation, filled in by the server when it sends a message of that
/// type. The order the parameters are listed in is the order they're substituted in.
/// </summary>
public enum ChatDecorationParameter {
    Sender,
    Target,
    Content
}

public static class ChatDecorationParameterExtensions {
    public static string ToProtocolString(this ChatDecorationParameter parameter) => parameter switch {
        ChatDecorationParameter.Sender => "sender",
        ChatDecorationParameter.Target => "target",
        ChatDecorationParameter.Content => "content",
        _ => throw new ArgumentOutOfRangeException(nameof(parameter), parameter, null)
    };

    public static ChatDecorationParameter ParseChatDecorationParameter(string value) => value switch {
        "sender" => ChatDecorationParameter.Sender,
        "target" => ChatDecorationParameter.Target,
        "content" => ChatDecorationParameter.Content,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown chat decoration parameter")
    };
}
