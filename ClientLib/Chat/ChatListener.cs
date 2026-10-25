using Minecraft.Schemas.Chat;
using Minecraft.Text;

namespace ClientLib.Chat;

/// <summary>
/// <c>ChatListener</c>: what decides whether and when a received message reaches the chat window, holding
/// messages back by the chat delay option and marking each signed one processed for the last seen list.
/// The social manager's block list and friends list are not ported, so nobody is blocked and an account
/// that only chats with friends is taken to have none.
/// </summary>
public sealed class ChatListener(MinecraftClient client) {
    private readonly LinkedList<(MessageSignature? Signature, Func<bool> Handler)> _delayedMessageQueue = [];
    private long _messageDelay;
    private long _previousMessageTime;

    /// <summary>The <c>onlyShowSecureChat</c> option, read as each message arrives.</summary>
    public Func<bool> OnlyShowSecureChat { get; set; } = () => false;

    /// <summary><c>Narrator.sayChatQueued</c>, for a player's message.</summary>
    public event Action<TextComponent>? ChatNarrated;

    /// <summary><c>Narrator.saySystemChatQueued</c>, for a system message in chat.</summary>
    public event Action<TextComponent>? SystemChatNarrated;

    /// <summary><c>Narrator.saySystemQueued</c>, for the action bar.</summary>
    public event Action<TextComponent>? SystemNarrated;

    private static long Millis => Environment.TickCount64;

    /// <summary><c>tick</c>. A multiplayer game never pauses, so the paused branch is left out.</summary>
    public void Tick() {
        if (_messageDelay == 0L) {
            if (_delayedMessageQueue.Count > 0) {
                FlushQueue();
            }
        }
        else if (Millis >= _previousMessageTime + _messageDelay) {
            while (_delayedMessageQueue.First is { } first) {
                _delayedMessageQueue.RemoveFirst();
                if (first.Value.Handler()) {
                    break;
                }
            }
        }
    }

    /// <summary><c>setMessageDelay</c>, the <c>chatDelay</c> option's change action.</summary>
    public void SetMessageDelay(double messageDelaySeconds) {
        long messageDelay = (long)(messageDelaySeconds * 1000.0);
        if (messageDelay == 0L && _messageDelay > 0L) {
            FlushQueue();
        }
        _messageDelay = messageDelay;
    }

    public void AcceptNextDelayedMessage() {
        (MessageSignature? _, Func<bool> handler) = _delayedMessageQueue.First!.Value;
        _delayedMessageQueue.RemoveFirst();
        handler();
    }

    public long QueueSize => _delayedMessageQueue.Count;

    public void FlushQueue() {
        foreach ((MessageSignature? _, Func<bool> handler) in _delayedMessageQueue.ToList()) {
            handler();
        }
        _delayedMessageQueue.Clear();
        _previousMessageTime = 0L;
    }

    public bool RemoveFromDelayedMessageQueue(MessageSignature signature) {
        bool removed = false;
        for (LinkedListNode<(MessageSignature? Signature, Func<bool> Handler)>? node = _delayedMessageQueue.First; node != null;) {
            LinkedListNode<(MessageSignature? Signature, Func<bool> Handler)>? next = node.Next;
            if (signature.Equals(node.Value.Signature)) {
                _delayedMessageQueue.Remove(node);
                removed = true;
            }
            node = next;
        }
        return removed;
    }

    private bool WillDelayMessages => _messageDelay > 0L && Millis < _previousMessageTime + _messageDelay;

    private void HandleMessage(MessageSignature? signature, Func<bool> handler) {
        if (WillDelayMessages) {
            _delayedMessageQueue.AddLast((signature, handler));
        }
        else {
            handler();
        }
    }

    private bool CanReceivePlayerMessages => client.Player != null && client.ChatAbilities.CanReceivePlayerMessages;

    public void HandlePlayerChatMessage(PlayerChatMessage message, PlayerListEntry sender, BoundChatType boundChatType) {
        bool onlyShowSecure = OnlyShowSecureChat();
        PlayerChatMessage displayedMessage = onlyShowSecure ? message.RemoveUnsignedContent() : message;
        TextComponent decoratedMessage = ChatDecoration.Decorate(client.Registry, boundChatType, displayedMessage.DecoratedContent);
        DateTimeOffset received = DateTimeOffset.UtcNow;
        HandleMessage(message.Signature, () => {
            bool wasShown = ShowMessageToPlayer(boundChatType, message, decoratedMessage, onlyShowSecure, received);
            if (message.Signature != null) {
                client.MarkMessageAsProcessed(message.Signature, wasShown);
            }
            return wasShown;
        });
    }

    public void HandleChatMessageError(Guid senderId, MessageSignature? invalidSignature, BoundChatType boundChatType) {
        HandleMessage(null, () => {
            if (invalidSignature != null) {
                client.MarkMessageAsProcessed(invalidSignature, false);
            }
            if (IsFriendOnlyRestricted(senderId) || !CanReceivePlayerMessages) {
                return false;
            }
            TextComponent error = TextComponent.Translatable("chat.validation_error").WithColor(TextColor.Red).WithItalic();
            client.ChatMessages.AddPlayerMessage(ChatDecoration.Decorate(client.Registry, boundChatType, error), null, GuiMessageTag.ChatError);
            SystemChatNarrated?.Invoke(ChatDecoration.DecorateNarration(client.Registry, boundChatType, error));
            _previousMessageTime = Millis;
            return true;
        });
    }

    public void HandleDisguisedChatMessage(TextComponent message, BoundChatType boundChatType) {
        HandleMessage(null, () => {
            if (!CanReceivePlayerMessages) {
                return false;
            }
            client.ChatMessages.AddPlayerMessage(ChatDecoration.Decorate(client.Registry, boundChatType, message), null, GuiMessageTag.System);
            ChatNarrated?.Invoke(ChatDecoration.DecorateNarration(client.Registry, boundChatType, message));
            _previousMessageTime = Millis;
            return true;
        });
    }

    private bool ShowMessageToPlayer(BoundChatType boundChatType, PlayerChatMessage message, TextComponent decoratedMessage, bool onlyShowSecure,
        DateTimeOffset received) {
        ChatTrustLevel trustLevel = EvaluateTrustLevel(message, decoratedMessage, received);
        if (onlyShowSecure && trustLevel.IsNotSecure()) {
            return false;
        }
        if (message.IsFullyFiltered || IsFriendOnlyRestricted(message.Sender) || !CanReceivePlayerMessages) {
            return false;
        }
        GuiMessageTag? tag = trustLevel.CreateTag(message);
        if (message.FilterMask.Type == ChatFilterMask.FilterType.PassThrough) {
            client.ChatMessages.AddPlayerMessage(decoratedMessage, message.Signature, tag);
            ChatNarrated?.Invoke(ChatDecoration.DecorateNarration(client.Registry, boundChatType, message.DecoratedContent));
        }
        else if (ApplyWithFormatting(message.FilterMask, message.SignedContent) is { } filteredContent) {
            client.ChatMessages.AddPlayerMessage(ChatDecoration.Decorate(client.Registry, boundChatType, filteredContent), message.Signature, tag);
            ChatNarrated?.Invoke(ChatDecoration.DecorateNarration(client.Registry, boundChatType, filteredContent));
        }
        _previousMessageTime = Millis;
        return true;
    }

    /// <summary>
    /// <c>evaluateTrustLevel</c>: a message from the local player only counts as secure on its say so in
    /// singleplayer, which this client never plays.
    /// </summary>
    private static ChatTrustLevel EvaluateTrustLevel(PlayerChatMessage message, TextComponent decoratedMessage, DateTimeOffset received) =>
        ChatTrust.Evaluate(message, decoratedMessage, received);

    /// <summary>
    /// <c>handleSystemMessage</c>: <paramref name="remote"/> for one the server sent. The <c>hideMatchedNames</c>
    /// check is left out with the block list it asks.
    /// </summary>
    public void HandleSystemMessage(TextComponent message, bool remote) {
        Guid guessedUuid = GuessChatUuid(message);
        if (guessedUuid != Guid.Empty && IsFriendOnlyRestricted(guessedUuid)) {
            return;
        }
        if (client.Player == null || !client.ChatAbilities.CanReceiveSystemMessages) {
            return;
        }
        if (remote) {
            client.ChatMessages.AddServerSystemMessage(message);
        }
        else {
            client.ChatMessages.AddClientSystemMessage(message);
        }
        SystemChatNarrated?.Invoke(message);
    }

    /// <summary><c>handleOverlay</c>: the action bar, narrated as a system message.</summary>
    public void HandleOverlay(TextComponent message) {
        client.SetActionBar(message);
        SystemNarrated?.Invoke(message);
    }

    /// <summary><c>guessChatUUID</c>: the player named between the first angle brackets, among the names player info has given.</summary>
    private Guid GuessChatUuid(TextComponent message) {
        string text = TextFlattener.Plain(message);
        int open = text.IndexOf('<');
        int close = open < 0 ? -1 : text.IndexOf('>', open + 1);
        if (close < 0) {
            return Guid.Empty;
        }
        string possibleMention = text[(open + 1)..close];
        return client.PlayerList.Values.FirstOrDefault(entry => entry.Name == possibleMention)?.Uuid ?? Guid.Empty;
    }

    /// <summary><c>Minecraft.isFriendOnlyRestricted</c> with no friends list, so any other player.</summary>
    private bool IsFriendOnlyRestricted(Guid uuid) => (client.Options.UserFlags & Profiles.UserFlags.ChatFriendsOnly) != 0 && uuid != client.Profile.Uuid;

    /// <summary><c>FilterMask.applyWithFormatting</c>.</summary>
    internal static TextComponent? ApplyWithFormatting(ChatFilterMask mask, string text) {
        switch (mask.Type) {
            case ChatFilterMask.FilterType.PassThrough:
                return TextComponent.Text(text);
            case ChatFilterMask.FilterType.FullyFiltered:
                return null;
        }
        System.Collections.BitArray bits = mask.Mask!;
        TextComponent result = TextComponent.Empty();
        int previousIndex = 0;
        bool filtered = Get(bits, 0);
        while (true) {
            int nextIndex = filtered ? NextClearBit(bits, previousIndex) : NextSetBit(bits, previousIndex);
            nextIndex = nextIndex < 0 ? text.Length : nextIndex;
            if (nextIndex == previousIndex) {
                return result;
            }
            if (filtered) {
                result.With(TextComponent.Text(new string('#', nextIndex - previousIndex)).WithColor(TextColor.DarkGray)
                    .WithHoverEvent(HoverEvent.ShowText(TextComponent.Translatable("chat.filtered"))));
            }
            else {
                result.With(TextComponent.Text(text[previousIndex..nextIndex]));
            }
            filtered = !filtered;
            previousIndex = nextIndex;
        }
    }

    private static bool Get(System.Collections.BitArray bits, int index) => index < bits.Length && bits[index];

    private static int NextSetBit(System.Collections.BitArray bits, int from) {
        for (int i = from; i < bits.Length; i++) {
            if (bits[i]) {
                return i;
            }
        }
        return -1;
    }

    /// <summary><c>BitSet.nextClearBit</c>, which past the last set bit is the index itself.</summary>
    private static int NextClearBit(System.Collections.BitArray bits, int from) {
        int i = from;
        while (Get(bits, i)) {
            i++;
        }
        return i;
    }
}
