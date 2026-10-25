using Minecraft.Text;

namespace ClientLib.Chat;

/// <summary><c>GuiMessageSource</c>.</summary>
public enum GuiMessageSource {
    Player,
    SystemServer,
    SystemClient
}

/// <summary><c>GuiMessageTag</c>: the bar left of a chat line, what hovering it says, and an icon after it.</summary>
public sealed record GuiMessageTag(int IndicatorColor, GuiMessageTag.TagIcon? Icon, TextComponent? Text, string? LogTag) {
    private const int ChatNotSecureIndicatorColor = 0xD0D0D0, ChatModifiedIndicatorColor = 0x606060;

    public static readonly GuiMessageTag System = new(0xD0D0D0, null, TextComponent.Translatable("chat.tag.system"), "System");
    public static readonly GuiMessageTag SystemSinglePlayer = new(0xD0D0D0, null, TextComponent.Translatable("chat.tag.system_single_player"), "System");
    public static readonly GuiMessageTag ChatNotSecure = new(ChatNotSecureIndicatorColor, null, TextComponent.Translatable("chat.tag.not_secure"), "Not Secure");
    public static readonly GuiMessageTag ChatError = new(0xFF5555, null, TextComponent.Translatable("chat.tag.error"), "Chat Error");

    public static GuiMessageTag ChatModified(string originalContent) {
        TextComponent text = TextComponent.Empty()
            .With(TextComponent.Translatable("chat.tag.modified"))
            .With(TextComponent.Text("\n"))
            .With(TextComponent.Text(originalContent).WithColor(TextColor.Gray));
        return new GuiMessageTag(ChatModifiedIndicatorColor, TagIcon.ChatModified, text, "Modified");
    }

    /// <summary><c>GuiMessageTag.Icon</c>: only <c>icon/chat_modified</c>, 9 by 9.</summary>
    public enum TagIcon {
        ChatModified
    }

    public const int IconWidth = 9, IconHeight = 9;
}

/// <summary><c>GuiMessage</c>: a chat message as the chat window keeps it, before it is cut into lines.</summary>
public sealed record GuiMessage(int AddedTime, TextComponent Content, MessageSignature? Signature, GuiMessageSource Source, GuiMessageTag? Tag);

/// <summary><c>ChatTrustLevel</c>.</summary>
public enum ChatTrustLevel {
    Secure,
    Modified,
    NotSecure
}

public static class ChatTrust {
    public static ChatTrustLevel Evaluate(PlayerChatMessage message, TextComponent decoratedMessage, DateTimeOffset received) {
        if (!message.HasSignature || message.HasExpiredClient(received)) {
            return ChatTrustLevel.NotSecure;
        }
        return IsModified(message, decoratedMessage) ? ChatTrustLevel.Modified : ChatTrustLevel.Secure;
    }

    private static bool IsModified(PlayerChatMessage message, TextComponent decoratedMessage) {
        if (!TextFlattener.Plain(decoratedMessage).Contains(message.SignedContent, StringComparison.Ordinal)) {
            return true;
        }
        return message.UnsignedContent is { } decoratedContent && ContainsModifiedStyle(decoratedContent, null);
    }

    /// <summary><c>containsModifiedStyle</c>: any part drawn in a font other than the default, its own or inherited.</summary>
    private static bool ContainsModifiedStyle(TextComponent component, string? inheritedFont) {
        string? font = component.Font ?? inheritedFont;
        if (font != null && font is not ("minecraft:default" or "default")) {
            return true;
        }
        foreach ((string key, NBT.INbtTag tag) in component.Content.Fields) {
            if (key == "with" && tag is NBT.Tags.ListTag list && list.Tags.ToArray().Any(arg => ContainsModifiedStyle(TextComponent.FromTag(arg), font))) {
                return true;
            }
        }
        return component.Children.Any(child => ContainsModifiedStyle(child, font));
    }

    public static bool IsNotSecure(this ChatTrustLevel level) => level == ChatTrustLevel.NotSecure;

    public static GuiMessageTag? CreateTag(this ChatTrustLevel level, PlayerChatMessage message) => level switch {
        ChatTrustLevel.Modified => GuiMessageTag.ChatModified(message.SignedContent),
        ChatTrustLevel.NotSecure => GuiMessageTag.ChatNotSecure,
        _ => null
    };
}

/// <summary><c>ChatRestriction</c>: why the player cannot chat, and where vanilla sends them to change it.</summary>
public enum ChatRestriction {
    ChatAndCommandsDisabledByOptions,
    ChatDisabledByOptions,
    DisabledByLauncher,
    DisabledByProfile
}

/// <summary><c>ChatAbilities</c>.</summary>
public sealed class ChatAbilities {
    public static readonly ChatAbilities NoRestrictions = new(new HashSet<ChatRestriction>());

    private ChatAbilities(IReadOnlySet<ChatRestriction> restrictions) {
        Restrictions = restrictions;
        bool messages = true, commands = true;
        foreach (ChatRestriction restriction in restrictions) {
            // modifyPermissions: every restriction takes the player messages, the first also the commands.
            messages = false;
            if (restriction == ChatRestriction.ChatAndCommandsDisabledByOptions) {
                commands = false;
            }
        }
        CanSendMessages = CanReceivePlayerMessages = messages;
        CanSendCommands = CanReceiveSystemMessages = commands;
    }

    public IReadOnlySet<ChatRestriction> Restrictions { get; }
    public bool HasAnyRestrictions => Restrictions.Count > 0;
    public bool CanSendMessages { get; }
    public bool CanSendCommands { get; }
    public bool CanReceivePlayerMessages { get; }
    public bool CanReceiveSystemMessages { get; }

    /// <summary><c>selectVisibleMessages</c>: client messages always, the others as the player may receive them.</summary>
    public bool IsVisible(GuiMessage message) => message.Source switch {
        GuiMessageSource.SystemClient => true,
        GuiMessageSource.Player => CanReceivePlayerMessages,
        _ => CanReceiveSystemMessages
    };

    public static ChatAbilities Of(IEnumerable<ChatRestriction> restrictions) {
        HashSet<ChatRestriction> set = [..restrictions];
        return set.Count == 0 ? NoRestrictions : new ChatAbilities(set);
    }

    public static string TranslationKey(ChatRestriction restriction) => restriction switch {
        ChatRestriction.ChatAndCommandsDisabledByOptions => "chat_restriction.chat_and_commands_disabled_by_options",
        ChatRestriction.ChatDisabledByOptions => "chat_restriction.chat_disabled_by_options",
        ChatRestriction.DisabledByLauncher => "chat_restriction.disabled_by_launcher",
        _ => "chat_restriction.disabled_by_profile"
    };
}

/// <summary>
/// The half of vanilla's <c>ChatComponent</c> that needs no font: every message the chat window holds, newest
/// first, and the deletions waiting for a message to be old enough. Whatever draws chat cuts these into
/// lines, as <c>addMessageToDisplayQueue</c> and <c>refreshTrimmedMessages</c> do, when told to.
/// </summary>
public sealed class ChatMessages(Func<int> guiTicks) {
    private const int MaxChatHistory = 100, TimeBeforeMessageDeletion = 60;

    private readonly List<GuiMessage> _allMessages = [];
    private readonly List<(MessageSignature Signature, int DeletableAfter)> _messageDeletionQueue = [];
    private Func<GuiMessage, bool> _visibleMessageFilter = _ => true;

    public IReadOnlyList<GuiMessage> All => _allMessages;

    public bool IsVisible(GuiMessage message) => _visibleMessageFilter(message);

    /// <summary>A message to add to the lines, <c>addMessageToDisplayQueue</c>.</summary>
    public event Action<GuiMessage>? Added;

    /// <summary>The lines are to be rebuilt from <see cref="All"/>, <c>refreshTrimmedMessages</c>.</summary>
    public event Action? Refreshed;

    /// <summary><c>logChatMessage</c>'s line.</summary>
    public event Action<string>? Logged;

    public void Tick() {
        if (_messageDeletionQueue.Count > 0) {
            int time = guiTicks();
            _messageDeletionQueue.RemoveAll(entry => time >= entry.DeletableAfter && DeleteMessageOrDelay(entry.Signature) == null);
        }
    }

    public void SetVisibleMessageFilter(Func<GuiMessage, bool> visibleMessageFilter) {
        _visibleMessageFilter = visibleMessageFilter;
        Refreshed?.Invoke();
    }

    /// <summary><c>clearMessages</c>, without the queue flush and command history the caller owns.</summary>
    public void Clear() {
        _messageDeletionQueue.Clear();
        _allMessages.Clear();
        Refreshed?.Invoke();
    }

    public void AddClientSystemMessage(TextComponent message) => AddMessage(message, null, GuiMessageSource.SystemClient, GuiMessageTag.SystemSinglePlayer);

    public void AddServerSystemMessage(TextComponent message) => AddMessage(message, null, GuiMessageSource.SystemServer, GuiMessageTag.SystemSinglePlayer);

    public void AddPlayerMessage(TextComponent message, MessageSignature? signature, GuiMessageTag? tag) =>
        AddMessage(message, signature, GuiMessageSource.Player, tag);

    private void AddMessage(TextComponent contents, MessageSignature? signature, GuiMessageSource source, GuiMessageTag? tag) {
        GuiMessage message = new(guiTicks(), contents, signature, source, tag);
        if (!_visibleMessageFilter(message)) {
            return;
        }
        string text = TextFlattener.Plain(message.Content).Replace("\r", "\\r").Replace("\n", "\\n");
        Logged?.Invoke(tag?.LogTag is { } logTag ? $"[{logTag}] [CHAT] {text}" : $"[CHAT] {text}");
        Added?.Invoke(message);
        _allMessages.Insert(0, message);
        if (_allMessages.Count > MaxChatHistory) {
            _allMessages.RemoveRange(MaxChatHistory, _allMessages.Count - MaxChatHistory);
        }
    }

    public void DeleteMessage(MessageSignature signature) {
        if (DeleteMessageOrDelay(signature) is { } delayed) {
            _messageDeletionQueue.Add(delayed);
        }
    }

    private (MessageSignature, int)? DeleteMessageOrDelay(MessageSignature signature) {
        int time = guiTicks();
        for (int i = 0; i < _allMessages.Count; i++) {
            GuiMessage message = _allMessages[i];
            if (!signature.Equals(message.Signature)) {
                continue;
            }
            int deletableAfter = message.AddedTime + TimeBeforeMessageDeletion;
            if (time >= deletableAfter) {
                _allMessages[i] = CreateDeletedMarker(message);
                Refreshed?.Invoke();
                return null;
            }
            return (signature, deletableAfter);
        }
        return null;
    }

    private static GuiMessage CreateDeletedMarker(GuiMessage message) =>
        new(message.AddedTime, TextComponent.Translatable("chat.deleted_marker").WithColor(TextColor.Gray).WithItalic(), null,
            GuiMessageSource.SystemServer, GuiMessageTag.System);
}
