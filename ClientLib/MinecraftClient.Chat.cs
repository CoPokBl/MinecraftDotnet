using System.Security.Cryptography;
using ClientLib.Brigadier;
using ClientLib.Chat;
using ClientLib.Commands;
using ClientLib.Profiles;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chat;
using Minecraft.Text;
using PlayerData = Minecraft.Packets.Play.ClientBound.ClientBoundPlayerInfoUpdatePacket.PlayerData;

namespace ClientLib;

/// <summary><c>ClientPacketListener.CommandCheckResult</c>: what stops a command a click runs from going straight out.</summary>
public enum CommandCheckResult {
    NoIssues,
    ParseErrors,
    SignatureRequired,
    PermissionsRequired
}

/// <summary>Secure chat: the player's chat session, signing what they send, and checking what others sent.</summary>
public sealed partial class MinecraftClient {
    private ChatMessages? _chatMessages;
    private ChatListener? _chatListener;
    private ProfileKeyPairManager? _accountKeyPairManager;
    private ClientSuggestionProvider? _restrictedSuggestionsProvider;

    private LocalChatSession? _chatSession;
    private SignedMessageChain.Encoder _signedMessageEncoder = SignedMessageChain.Unsigned;
    private int _nextChatIndex;
    private LastSeenMessagesTracker _lastSeenMessages = new(LastSeenMessages.MaxLength);
    private MessageSignatureCache _messageSignatureCache = MessageSignatureCache.CreateDefault();
    private Task<ProfileKeyPair?>? _keyPairFuture;

    /// <summary>What the chat window holds, which outlives a connection as vanilla's <c>Gui</c> does.</summary>
    public ChatMessages ChatMessages => _chatMessages ??= new ChatMessages(() => (int)ClientTicks);

    public ChatListener ChatListener => _chatListener ??= new ChatListener(this);

    /// <summary>
    /// <c>Minecraft.getProfileKeyPairManager</c>: the account's chat keys, or none without an account or with
    /// <see cref="ClientOptions.ChatSigning"/> off, which is then exactly vanilla's empty manager: nothing is asked of
    /// the services and no session goes to the server.
    /// </summary>
    public ProfileKeyPairManager ProfileKeyPairManager => Options.ChatSigning ? AccountKeyPairManager : ProfileKeyPairManager.Empty;

    /// <summary>The account's own manager, kept when signing is off so a key fetched before that is not fetched twice.</summary>
    internal ProfileKeyPairManager AccountKeyPairManager {
        get => _accountKeyPairManager ??= Options.Account is { } account
            ? new AccountProfileKeyPairManager(new UserApiService(account.AccessToken), Info)
            : ProfileKeyPairManager.Empty;
        set => _accountKeyPairManager = value;
    }

    /// <summary>The services' keys that sign players' chat keys; empty when none could be fetched.</summary>
    public Func<IReadOnlyList<RSAParameters>> ProfileKeySignatureKeys { get; set; } = () => MojangServices.PlayerCertificateKeys;

    /// <summary><c>LocalPlayer.chatAbilities</c>, worked out when the player is made and when the chat visibility changes.</summary>
    public ChatAbilities ChatAbilities { get; private set; } = ChatAbilities.NoRestrictions;

    /// <summary>The login packet's <c>onlineMode</c>: whether this connection authenticated, and so wants a chat session.</summary>
    public bool OnlineMode { get; private set; }

    /// <summary>The session the player signs with, once the key pair has arrived.</summary>
    public LocalChatSession? ChatSession => _chatSession;

    /// <summary><c>ClientPacketListener.enforcesSecureChat</c>: the server's flag, if the client can check keys at all.</summary>
    public bool EnforcesSecureChat => ServerEnforcesSecureChat && ProfileKeySignatureKeys().Count > 0;

    /// <summary><c>Minecraft.prepareForMultiplayer</c>'s part: the key pair is asked for as the connection starts.</summary>
    private void PrepareForMultiplayer() {
        MojangServices.PrefetchKeys();
        ProfileKeyPairManager.PrepareKeyPair();
    }

    /// <summary><c>Minecraft.computeChatAbilities</c>, for a multiplayer server.</summary>
    private ChatAbilities ComputeChatAbilities() {
        List<ChatRestriction> restrictions = [];
        switch (Options.ChatMode) {
            case ChatMode.Hidden:
                restrictions.Add(ChatRestriction.ChatAndCommandsDisabledByOptions);
                break;
            case ChatMode.CommandsOnly:
                restrictions.Add(ChatRestriction.ChatDisabledByOptions);
                break;
        }
        if ((Options.UserFlags & UserFlags.ChatAllowed) == 0) {
            restrictions.Add(ChatRestriction.DisabledByProfile);
        }
        return ChatAbilities.Of(restrictions);
    }

    /// <summary><c>LocalPlayer.refreshChatAbilities</c>, the chat visibility option's change action.</summary>
    public void RefreshChatAbilities() {
        if (Player == null) {
            return;
        }
        ChatAbilities = ComputeChatAbilities();
        ChatMessages.SetVisibleMessageFilter(ChatAbilities.IsVisible);
    }

    /// <summary>A new <c>LocalPlayer</c> takes its abilities from the options without touching the chat window's filter.</summary>
    private void OnPlayerCreated() => ChatAbilities = ComputeChatAbilities();

    /// <summary>The chat part of <c>ClientPacketListener.handleLogin</c>.</summary>
    private void ResetChatForLogin(ClientBoundLoginPacket login) {
        _chatSession = null;
        _signedMessageEncoder = SignedMessageChain.Unsigned;
        _nextChatIndex = 0;
        _lastSeenMessages = new LastSeenMessagesTracker(LastSeenMessages.MaxLength);
        _messageSignatureCache = MessageSignatureCache.CreateDefault();
        OnlineMode = login.OnlineMode;
        if (login.OnlineMode) {
            PrepareKeyPair();
        }
        ServerEnforcesSecureChat = login.EnforcesSecureChat;
        if (InsecureChatToast == null && !EnforcesSecureChat) {
            InsecureChatToast = (TextComponent.Translatable("multiplayer.unsecureserver.toast.title"), TextComponent.Translatable("multiplayer.unsecureserver.toast"));
        }
    }

    /// <summary>
    /// The toast <c>handleLogin</c> raises once a connection, the first time it finds the server not enforcing secure
    /// chat: messages there may be changed and cannot be reported.
    /// </summary>
    public (TextComponent Title, TextComponent? Message)? InsecureChatToast { get; private set; }

    private void PrepareKeyPair() => _keyPairFuture = ProfileKeyPairManager.PrepareKeyPair();

    /// <summary>
    /// Turns chat signing on or off mid connection. On, the key pair is asked for as <c>handleLogin</c> would have,
    /// so the session goes out on a later tick as a refreshed one does in vanilla. Off, a key pair still on its way
    /// is dropped, as a failed fetch leaves vanilla with none, but a session the server already has stays in use
    /// until the connection ends: a client cannot take a session back, and once it has one, vanilla servers refuse
    /// its unsigned chat. No further key is fetched for it, so it keeps the key it has.
    /// </summary>
    public void SetChatSigning(bool enabled) {
        if (Options.ChatSigning == enabled) {
            return;
        }
        Options.ChatSigning = enabled;
        if (!enabled) {
            _keyPairFuture = null;
        }
        else if (Phase == ClientPhase.Play && OnlineMode && _chatSession == null) {
            PrepareKeyPair();
        }
    }

    /// <summary>The key pair part of <c>ClientPacketListener.tick</c>, which runs from <c>MultiPlayerGameMode.tick</c>.</summary>
    internal void TickChatSession() {
        if (_chatSession != null && ProfileKeyPairManager.ShouldRefreshKeyPair()) {
            PrepareKeyPair();
        }
        if (_keyPairFuture is { IsCompleted: true } future) {
            _keyPairFuture = null;
            if (future.IsCompletedSuccessfully && future.Result is { } keyPair) {
                SetKeyPair(keyPair);
            }
        }
    }

    /// <summary><c>setKeyPair</c>: a new session goes to the server whenever the key pair changes.</summary>
    private void SetKeyPair(ProfileKeyPair keyPair) {
        if (Options.Account == null || Guid.Parse(Options.Account.Uuid) != Profile.Uuid) {
            return;
        }
        if (_chatSession != null && _chatSession.KeyPair.Equals(keyPair)) {
            return;
        }
        _chatSession = LocalChatSession.Create(keyPair);
        _signedMessageEncoder = _chatSession.CreateMessageEncoder(Profile.Uuid);
        Send(SessionPacket(_chatSession));
    }

    /// <summary><c>ServerboundChatSessionUpdatePacket</c> with <c>asRemote().asData()</c>.</summary>
    internal static ServerBoundPlayerSessionPacket SessionPacket(LocalChatSession session) {
        ProfilePublicKey.KeyData data = session.KeyPair.PublicKey.Data;
        return new ServerBoundPlayerSessionPacket {
            SessionId = session.SessionId,
            ExpiresAt = data.ExpiresAt,
            PublicKey = data.Key,
            KeySignature = data.KeySignature
        };
    }

    /// <summary>Signs with this session from now on, without announcing it, for driving the client in tests.</summary>
    internal void UseChatSession(LocalChatSession session) {
        _chatSession = session;
        _signedMessageEncoder = session.CreateMessageEncoder(Profile.Uuid);
    }

    /// <summary><c>markMessageAsProcessed</c>.</summary>
    internal void MarkMessageAsProcessed(MessageSignature signature, bool wasShown) {
        if (_lastSeenMessages.AddPending(signature, wasShown) && _lastSeenMessages.Offset > 64) {
            SendChatAcknowledgement();
        }
    }

    private void SendChatAcknowledgement() {
        int offset = _lastSeenMessages.GetAndClearOffset();
        if (offset > 0) {
            Send(new ServerBoundAcknowledgeMessagePacket { MessageCount = offset });
        }
    }

    /// <summary>The chat part of <c>handleConfigurationStart</c>, before the acknowledgement goes out.</summary>
    private void FlushChatForConfiguration() {
        ChatListener.FlushQueue();
        SendChatAcknowledgement();
    }

    /// <summary><c>ChatScreen.handleChatInput</c>'s send: a line starting with a slash is a command.</summary>
    public void SendChat(string message) {
        if (message.StartsWith('/')) {
            SendCommand(message[1..]);
        }
        else {
            SendChatMessage(message);
        }
    }

    /// <summary><c>ClientPacketListener.sendChat</c>.</summary>
    public void SendChatMessage(string content) {
        DateTimeOffset timeStamp = DateTimeOffset.UtcNow;
        long salt = Signatures.Salt();
        (LastSeenMessages lastSeen, LastSeenMessages.Update update) = _lastSeenMessages.GenerateAndApplyUpdate();
        MessageSignature? signature = _signedMessageEncoder(new SignedMessageBody(content, timeStamp, salt, lastSeen));
        Send(new ServerBoundChatMessagePacket {
            Message = content,
            Timestamp = timeStamp.ToUnixTimeMilliseconds(),
            Salt = salt,
            Signature = signature?.Data,
            MessageCount = update.Offset,
            Acknowledged = update.Acknowledged,
            Checksum = update.Checksum
        });
    }

    /// <summary>
    /// <c>ClientPacketListener.sendCommand</c>: a command with a message argument goes as a signed command even
    /// with no session to sign it, carrying the salt and the last seen update without signatures.
    /// </summary>
    public void SendCommand(string command) {
        SignableCommand<ClientSuggestionProvider> signableCommand = SignableCommand<ClientSuggestionProvider>.Of(Commands.Parse(command, SuggestionsProvider));
        if (signableCommand.Arguments.Count == 0) {
            Send(new ServerBoundChatCommandPacket { Command = command });
            return;
        }
        DateTimeOffset timeStamp = DateTimeOffset.UtcNow;
        long salt = Signatures.Salt();
        (LastSeenMessages lastSeen, LastSeenMessages.Update update) = _lastSeenMessages.GenerateAndApplyUpdate();
        (string Name, MessageSignature Signature)[] argumentSignatures = ArgumentSignatures.SignCommand(signableCommand,
            argument => _signedMessageEncoder(new SignedMessageBody(argument, timeStamp, salt, lastSeen)));
        Send(new ServerBoundSignedChatCommandPacket {
            Command = command,
            Timestamp = timeStamp.ToUnixTimeMilliseconds(),
            Salt = salt,
            ArgumentSignatures = argumentSignatures.Select(entry => (entry.Name, entry.Signature.Data)).ToArray(),
            MessageCount = update.Offset,
            Acknowledged = update.Acknowledged,
            Checksum = update.Checksum
        });
    }

    /// <summary><c>verifyCommand</c>, which decides whether <see cref="SendUnattendedCommand"/> may send without asking.</summary>
    public CommandCheckResult VerifyCommand(string command) {
        ParseResults<ClientSuggestionProvider> parseWithCurrentPermissions = Commands.Parse(command, SuggestionsProvider);
        if (!IsValidCommand(parseWithCurrentPermissions)) {
            return CommandCheckResult.ParseErrors;
        }
        if (SignableCommand<ClientSuggestionProvider>.HasSignableArguments(parseWithCurrentPermissions)) {
            return CommandCheckResult.SignatureRequired;
        }
        _restrictedSuggestionsProvider ??= new ClientSuggestionProvider(this, NoPermissions.Instance);
        return IsValidCommand(Commands.Parse(command, _restrictedSuggestionsProvider)) ? CommandCheckResult.NoIssues : CommandCheckResult.PermissionsRequired;
    }

    private static bool IsValidCommand(ParseResults<ClientSuggestionProvider> parseResults) =>
        !parseResults.Reader.CanRead() && parseResults.Exceptions.Count == 0 && parseResults.Context.LastChild.Command != null;

    /// <summary>The send <c>sendUnattendedCommand</c> makes once nothing needs confirming: always unsigned.</summary>
    public void SendUnattendedCommand(string command) => Send(new ServerBoundChatCommandPacket { Command = command });

    private void HandlePlayerChat(ClientBoundPlayerChatMessagePacket packet) {
        int expectedChatIndex = _nextChatIndex++;
        if (packet.GlobalIndex != expectedChatIndex) {
            Info($"Missing or out-of-order chat message from server, expected index {expectedChatIndex} but got {packet.GlobalIndex}");
            DisconnectWith(TextComponent.Translatable("multiplayer.disconnect.bad_chat_index"));
            return;
        }
        LastSeenMessages? lastSeen = LastSeenMessages.Unpack(packet.LastSeen, _messageSignatureCache);
        if (lastSeen == null) {
            Info($"Message from player with ID {packet.Sender} referenced unrecognized signature id");
            DisconnectWith(TextComponent.Translatable("multiplayer.disconnect.invalid_packet"));
            return;
        }
        SignedMessageBody body = new(packet.Content, packet.Timestamp, packet.Salt, lastSeen);
        MessageSignature? signature = packet.Signature is { } bytes ? new MessageSignature(bytes) : null;
        _messageSignatureCache.Push(body, signature);
        if (!PlayerList.TryGetValue(packet.Sender, out PlayerListEntry? sender)) {
            Info($"Received player chat packet for unknown player with ID: {packet.Sender}");
            ChatListener.HandleChatMessageError(packet.Sender, signature, packet.ChatType);
            return;
        }
        SignedMessageLink link = sender.ChatSession is { } chatSession
            ? new SignedMessageLink(packet.Index, packet.Sender, chatSession.SessionId)
            : SignedMessageLink.Unsigned(packet.Sender);
        PlayerChatMessage? message = sender.MessageValidator.UpdateAndValidate(
            new PlayerChatMessage(link, signature, body, packet.UnsignedContent, packet.FilterMask));
        if (message != null) {
            ChatListener.HandlePlayerChatMessage(message, sender, packet.ChatType);
        }
        else {
            ChatListener.HandleChatMessageError(packet.Sender, signature, packet.ChatType);
        }
    }

    private void HandleDeleteChat(ClientBoundDeleteMessagePacket packet) {
        if (MessageSignature.Unpack(packet.Signature, _messageSignatureCache) is not { } signature) {
            DisconnectWith(TextComponent.Translatable("multiplayer.disconnect.invalid_packet"));
            return;
        }
        _lastSeenMessages.IgnorePending(signature);
        if (!ChatListener.RemoveFromDelayedMessageQueue(signature)) {
            ChatMessages.DeleteMessage(signature);
        }
    }

    private void DisconnectWith(TextComponent reason) {
        DisconnectReasonText = reason;
        Disconnect(TextFlattener.Plain(reason));
    }

    /// <summary><c>initializeChatSession</c>.</summary>
    private void InitializeChatSession(PlayerData.InitializeChat chat, PlayerListEntry info) {
        IReadOnlyList<RSAParameters> servicesKeys = ProfileKeySignatureKeys();
        if (servicesKeys.Count == 0) {
            Info($"Ignoring chat session from {info.Name} due to missing Services public key");
            info.ClearChatSession(EnforcesSecureChat);
            return;
        }
        if (!chat.HasData) {
            info.ClearChatSession(EnforcesSecureChat);
            return;
        }
        ProfilePublicKey.KeyData data = new(DateTimeOffset.FromUnixTimeMilliseconds(chat.PublicKeyExpiryTime!.Value), chat.EncodedPublicKey!,
            chat.PublicKeySignature!);
        if (ProfilePublicKey.CreateValidated(servicesKeys, info.Uuid, data) is { } publicKey) {
            info.SetChatSession(new RemoteChatSession(chat.ChatSessionId!.Value, publicKey));
        }
        else {
            Info($"Failed to validate profile key for player: '{info.Name}'");
            info.ClearChatSession(EnforcesSecureChat);
        }
    }
}
