using System.Security.Cryptography;
using System.Text;
using ClientLib.Network;
using ClientLib.World;
using Minecraft;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Client;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Handshake;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Registry;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using Minecraft.Text;

namespace ClientLib;

public enum ClientPhase {
    Idle,
    Connecting,
    Login,
    Configuration,
    Play,
    Disconnected
}

/// <summary>
/// A connection to a server and everything the server has told it, driven from one thread.
/// <p/>
/// The host calls <see cref="ProcessPackets"/> once per frame and <see cref="Tick"/> twenty times a
/// second, both from the same thread, which is how <c>Minecraft.runTick</c> drives the vanilla
/// client. Nothing here locks: the network threads only ever hand packets over through the
/// connection's queue, apart from the login phase, which vanilla also runs on the network thread.
/// </summary>
public sealed partial class MinecraftClient {
    public ClientOptions Options { get; }
    public ClientConnection? Connection { get; private set; }
    public ClientPhase Phase { get; private set; } = ClientPhase.Idle;
    public string? DisconnectReason { get; private set; }

    /// <summary>The server's own reason with its formatting, when it gave one; <see cref="DisconnectReason"/> is its plain text.</summary>
    public Minecraft.Text.TextComponent? DisconnectReasonText { get; private set; }

    /// <summary>The registries as the server synchronised them, rebuilt at the end of every configuration phase.</summary>
    public MinecraftRegistry Registry { get; private set; } = VanillaRegistry.Data;

    /// <summary>Tag contents as the server sent them, by registry and then tag, as protocol ids.</summary>
    public Dictionary<Identifier, Dictionary<Identifier, int[]>> Tags { get; private set; } = new();

    public GameProfile Profile { get; private set; }
    public string? ServerBrand { get; private set; }
    public Identifier[] EnabledFeatures { get; private set; } = [];
    public Dictionary<Identifier, byte[]> Cookies { get; } = new();

    /// <summary>Set when a server sends <c>transfer</c>. The host is expected to connect there next, carrying <see cref="Cookies"/>.</summary>
    public (string Host, int Port)? PendingTransfer { get; private set; }

    /// <summary>Set by a host reconnecting after a transfer, so the handshake says so.</summary>
    public bool PendingTransferIntent { get; set; }

    /// <summary>The dialog the server asked to show, if any. Shown by whatever host draws dialogs.</summary>
    public ClientBoundShowDialogPacket? ActiveDialog { get; set; }

    public long ClientTicks { get; private set; }

    public event Action<MinecraftPacket>? PacketReceived;
    public event Action<MinecraftPacket>? PacketSent;
    public event Action<string>? Disconnected;
    public event Action<string>? Log;

    private string _host = "";
    private int _port;
    private readonly Dictionary<Identifier, Dictionary<string, NBT.INbtTag?>> _pendingRegistries = new();
    private readonly Dictionary<Identifier, Dictionary<Identifier, int[]>> _pendingTags = new();
    private readonly ChunkBatchSizeCalculator _batchSize = new();

    public MinecraftClient(ClientOptions options) {
        Options = options;
        Profile = new GameProfile(options.Account?.Username ?? options.Username,
            options.Account != null ? Guid.Parse(options.Account.Uuid) : OfflineUuid(options.Username));
        Interactions = new Interaction.MultiPlayerGameMode(this);
        SpectatorGui = new Interaction.SpectatorGui(this);
    }

    /// <summary><c>UUIDUtil.createOfflinePlayerUUID</c>: a version 3 UUID of <c>OfflinePlayer:name</c>.</summary>
    public static Guid OfflineUuid(string name) {
        byte[] hash = MD5.HashData(Encoding.UTF8.GetBytes("OfflinePlayer:" + name));
        hash[6] = (byte)(hash[6] & 0x0f | 0x30);
        hash[8] = (byte)(hash[8] & 0x3f | 0x80);
        return new Guid(hash, bigEndian: true);
    }

    private void Info(string message) => Log?.Invoke(message);

    /// <summary>A tag's members as protocol ids, as the server synchronised them, or null for a tag it never sent.</summary>
    internal int[]? TagMembers(Identifier registry, Identifier tag) =>
        Tags.TryGetValue(registry, out Dictionary<Identifier, int[]>? tags) && tags.TryGetValue(tag, out int[]? members) ? members : null;

    internal bool InEntityTypeTag(IEntityType type, Identifier tag) =>
        TagMembers(EntityTypeRegistry, tag) is { } members && Array.IndexOf(members, Registry.EntityTypes.GetProtocolId(type)) >= 0;

    private static readonly Identifier EntityTypeRegistry = "minecraft:entity_type";

    public async Task Connect(string host, int port, CancellationToken ct = default) {
        if (Phase is not (ClientPhase.Idle or ClientPhase.Disconnected)) {
            throw new InvalidOperationException($"Already {Phase}");
        }

        _host = host;
        _port = port;
        DisconnectReason = null;
        DisconnectReasonText = null;
        PendingTransfer = null;
        Phase = ClientPhase.Connecting;

        ClientConnection connection;
        try {
            connection = await ClientConnection.Connect(host, port, ct);
        }
        catch (Exception e) {
            Phase = ClientPhase.Disconnected;
            DisconnectReason = $"Could not connect: {e.Message}";
            Disconnected?.Invoke(DisconnectReason);
            throw;
        }

        connection.Registry = VanillaRegistry.Data;
        connection.Warn = message => Info($"[network] {message}");
        connection.ReaderHook = HandleOnReader;
        connection.Disconnected += reason => DisconnectReason ??= reason;
        Connection = connection;

        // The handshake and login start go out before the reader exists, so nothing can race them.
        connection.OutboundState = ConnectionState.None;
        connection.Send(new ServerBoundHandshakePacket {
            Hostname = host,
            Port = (ushort)port,
            ProtocolVersion = ProtocolConstants.ProtocolVersion,
            Intent = PendingTransferIntent ? ServerBoundHandshakePacket.Intention.Transfer : ServerBoundHandshakePacket.Intention.Login
        });
        connection.OutboundState = ConnectionState.Login;
        connection.InboundState = ConnectionState.Login;
        connection.Send(new ServerBoundLoginStartPacket {
            Name = Profile.Username,
            Uuid = Profile.Uuid
        });
        Phase = ClientPhase.Login;
        connection.Start();
    }

    public void Disconnect(string reason = "Disconnected") {
        Connection?.Close(reason);
        FinishDisconnect(reason);
    }

    private void FinishDisconnect(string reason) {
        if (Phase == ClientPhase.Disconnected) {
            return;
        }
        Phase = ClientPhase.Disconnected;
        DisconnectReason = reason;
        Info($"Disconnected: {reason}");
        Disconnected?.Invoke(reason);
    }

    public void Send(MinecraftPacket packet) {
        PacketSent?.Invoke(packet);
        Connection?.Send(packet);
    }

    /// <summary>
    /// Handles everything the network threads have queued. Vanilla's
    /// <c>packetProcessor.processQueuedPackets</c>, run once per frame before the frame's ticks.
    /// </summary>
    public void ProcessPackets() {
        ClientConnection? connection = Connection;
        if (connection == null) {
            return;
        }

        while (connection.TryDequeue(out MinecraftPacket packet)) {
            try {
                Dispatch(packet);
            }
            catch (Exception e) {
                // Vanilla's onPacketError disconnects: state after a half applied packet is anyone's guess.
                Info($"Failed to handle {packet.GetType().Name}: {e}");
                Disconnect($"Packet handling error in {packet.GetType().Name}: {e.Message}");
                return;
            }
            if (connection != Connection) {
                return;
            }
        }

        if (!connection.Connected && Phase != ClientPhase.Disconnected) {
            FinishDisconnect(connection.DisconnectReason ?? "Connection lost");
        }
    }

    internal void Dispatch(MinecraftPacket packet) {
        PacketReceived?.Invoke(packet);
        switch (Phase) {
            case ClientPhase.Login:
                HandleLoginOnGameThread(packet);
                break;
            case ClientPhase.Configuration:
                HandleConfiguration(packet);
                break;
            case ClientPhase.Play:
                HandlePlay(packet);
                break;
        }
    }

    /// <summary>One client tick, <c>Minecraft.tick</c>.</summary>
    public void Tick() {
        ClientTicks++;
        if (Phase == ClientPhase.Play) {
            TickPlay();
        }
    }

    #region Reader thread

    /// <returns>True when the packet is fully handled here and should not be queued.</returns>
    private bool HandleOnReader(MinecraftPacket packet) {
        ClientConnection connection = Connection!;
        switch (packet) {
            case ClientBoundChunkDataAndUpdateLightPacket chunk:
                PrepareChunk(chunk);
                return false;

            case ClientBoundEncryptionRequestPacket request:
                HandleEncryptionRequest(connection, request);
                return true;

            case ClientBoundSetCompressionPacket compression:
                connection.CompressionThreshold = compression.Threshold;
                return true;

            case ClientBoundLoginPluginRequestPacket plugin:
                connection.Send(new ServerBoundLoginPluginResponsePacket {
                    MessageId = plugin.MessageId,
                    Data = null
                });
                return true;

            case ClientBoundCookieRequestPacket cookie when connection.InboundState == ConnectionState.Login:
                connection.Send(new ServerBoundCookieResponsePacket {
                    Key = cookie.Key,
                    Data = Cookies.GetValueOrDefault(cookie.Key)
                });
                return true;

            case ClientBoundLoginSuccessPacket success:
                // ClientHandshakePacketListenerImpl.handleLoginFinished: the switch happens here, on
                // the network thread, because the very next frame is a configuration packet.
                Profile = new GameProfile(success.Username, success.Uuid);
                connection.InboundState = ConnectionState.Configuration;
                connection.Send(new ServerBoundLoginAcknowledgedPacket());
                connection.OutboundState = ConnectionState.Configuration;
                connection.Send(new ServerBoundPluginMessagePacket {
                    Channel = "minecraft:brand",
                    Data = new DataWriter().WriteString(Options.Brand).ToArray()
                });
                connection.Send(Options.BuildInformation());
                return false;

            case ClientBoundChunkBatchStartPacket:
                _batchSize.OnBatchStart();
                return true;

            case ClientBoundChunkBatchFinishedPacket finished:
                // Also on the network thread in vanilla, so the time measured is arrival time.
                _batchSize.OnBatchFinished(finished.BatchSize);
                connection.Send(new ServerBoundChunkBatchReceivedPacket {
                    ChunksPerTick = _batchSize.DesiredChunksPerTick
                });
                return true;
        }
        return false;
    }

    private void HandleEncryptionRequest(ClientConnection connection, ClientBoundEncryptionRequestPacket request) {
        byte[] secret = RandomNumberGenerator.GetBytes(16);
        using RSA rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(request.PublicKey, out _);

        if (request.ShouldAuthenticate) {
            if (Options.Account == null) {
                connection.Close("This server is in online mode and needs a Microsoft account (--microsoft)");
                return;
            }
            try {
                MinecraftClientUtils.AuthenticateToJoin(Options.Account.AccessToken, Options.Account.Uuid.Replace("-", ""),
                    request.ServerId, secret, request.PublicKey).GetAwaiter().GetResult();
            }
            catch (Exception e) {
                connection.Close($"Failed to log in: {e.Message}");
                return;
            }
        }

        connection.Send(new ServerBoundEncryptionResponsePacket {
            SharedSecret = rsa.Encrypt(secret, RSAEncryptionPadding.Pkcs1),
            VerifyToken = rsa.Encrypt(request.VerifyToken, RSAEncryptionPadding.Pkcs1)
        });
        connection.EnableEncryption(secret);
    }

    #endregion

    #region Login and configuration

    private void HandleLoginOnGameThread(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundLoginSuccessPacket:
                Phase = ClientPhase.Configuration;
                _pendingRegistries.Clear();
                _pendingTags.Clear();
                Info($"Logged in as {Profile.Username} ({Profile.Uuid})");
                break;

            case ClientBoundLoginDisconnectPacket disconnect:
                DisconnectReasonText = disconnect.Reason;
                Disconnect(TextFlattener.Plain(disconnect.Reason));
                break;
        }
    }

    private void HandleConfiguration(MinecraftPacket packet) {
        if (HandleCommon(packet)) {
            return;
        }

        switch (packet) {
            case ClientBoundRegistryDataPacket registry:
                if (!_pendingRegistries.TryGetValue(registry.RegistryId, out Dictionary<string, NBT.INbtTag?>? entries)) {
                    entries = new Dictionary<string, NBT.INbtTag?>();
                    _pendingRegistries.Add(registry.RegistryId, entries);
                }
                foreach ((string key, NBT.INbtTag? value) in registry.Entries) {
                    entries[key] = value;
                }
                break;

            case ClientBoundUpdateTagsPacket tags:
                ApplyTags(_pendingTags, tags);
                break;

            case ClientBoundFeatureFlagsPacket features:
                EnabledFeatures = features.Flags;
                break;

            case ClientBoundKnownPacksPacket known:
                // KnownPacksManager.trySelectingPacks: only the vanilla core pack is known locally.
                Send(new ServerBoundKnownPacksPacket {
                    Packs = known.Packs
                        .Where(p => p.Namespace == "minecraft" && p.Id == "core" && p.Version == ProtocolConstants.CurrentVersionString)
                        .ToArray()
                });
                break;

            case ClientBoundCodeOfConductPacket conduct:
                Info($"Server code of conduct (accepted automatically):\n{conduct.CodeOfConduct}");
                Send(new ServerBoundAcceptCodeOfConductPacket());
                break;

            case ClientBoundFinishConfigurationPacket:
                FinishConfiguration();
                break;
        }
    }

    /// <summary>The packets every phase after login shares, <c>ClientCommonPacketListenerImpl</c>.</summary>
    private bool HandleCommon(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundKeepAlivePacket keepAlive:
                Send(new ServerBoundKeepAlivePacket { Id = keepAlive.Id });
                return true;

            case ClientBoundPingPacket ping:
                Send(new ServerBoundPongPacket { Id = ping.Id });
                return true;

            case ClientBoundDisconnectPacket disconnect:
                DisconnectReasonText = disconnect.Reason;
                Disconnect(TextFlattener.Plain(disconnect.Reason));
                return true;

            case ClientBoundPluginMessagePacket plugin:
                if (plugin.Channel == "minecraft:brand") {
                    ServerBrand = new DataReader(plugin.Data).ReadString();
                }
                return true;

            case ClientBoundAddResourcePackPacket pack:
                Info($"Server offered resource pack {pack.Url} (required: {pack.Forced}), declining");
                Send(new ServerBoundResourcePackResponsePacket {
                    PackId = pack.Uuid,
                    Result = ServerBoundResourcePackResponsePacket.PackResponse.Declined
                });
                return true;

            case ClientBoundCookieRequestPacket cookie:
                Send(new ServerBoundCookieResponsePacket {
                    Key = cookie.Key,
                    Data = Cookies.GetValueOrDefault(cookie.Key)
                });
                return true;

            case ClientBoundStoreCookiePacket store:
                Cookies[store.Key] = store.Payload;
                return true;

            case ClientBoundTransferPacket transfer:
                PendingTransfer = (transfer.Host, transfer.Port);
                Disconnect($"Transferred to {transfer.Host}:{transfer.Port}");
                return true;

            case ClientBoundRemoveResourcePackPacket or ClientBoundCustomReportDetailsPacket or ClientBoundServerLinksPacket:
                return true;

            case ClientBoundShowDialogPacket dialog:
                ActiveDialog = dialog;
                return true;

            case ClientBoundClearDialogPacket:
                ActiveDialog = null;
                return true;
        }
        return false;
    }

    private static void ApplyTags(Dictionary<Identifier, Dictionary<Identifier, int[]>> into, ClientBoundUpdateTagsPacket packet) {
        foreach (ClientBoundUpdateTagsPacket.TagSet set in packet.Tags) {
            Dictionary<Identifier, int[]> tags = new();
            foreach (ClientBoundUpdateTagsPacket.Tag tag in set.Tags) {
                tags[tag.Name] = tag.Entries;
            }
            into[set.Registry] = tags;
        }
    }

    /// <summary><c>ClientConfigurationPacketListenerImpl.handleConfigurationFinished</c>.</summary>
    private void FinishConfiguration() {
        Registry = BuildRegistry();
        Tags = new Dictionary<Identifier, Dictionary<Identifier, int[]>>(_pendingTags);
        ClientConnection connection = Connection!;
        connection.Registry = Registry;

        Send(new ServerBoundAcknowledgeFinishConfigurationPacket());
        connection.OutboundState = ConnectionState.Play;
        Phase = ClientPhase.Play;
        connection.SetInboundState(ConnectionState.Play);
    }

    /// <summary>
    /// <c>RegistryDataCollector.collectGameRegistries</c>. An entry the server sends without data is
    /// one it expects the client to have from a known pack, which here means the vanilla registry;
    /// the server's order is kept either way, because protocol ids are positions in it.
    /// </summary>
    private MinecraftRegistry BuildRegistry() {
        MinecraftRegistry registry = VanillaRegistry.Data.Clone();
        foreach ((Identifier id, Dictionary<string, NBT.INbtTag?> entries) in _pendingRegistries) {
            ISubRegistry? sub = registry.SubRegistries.FirstOrDefault(r => r.RegistryId == id);
            if (sub is not INbtSerialisableRegistry target) {
                Info($"Server sent registry {id}, which this client does not synchronise");
                continue;
            }

            Dictionary<string, NBT.INbtTag>? vanilla = null;
            Dictionary<string, NBT.INbtTag> resolved = new();
            foreach ((string key, NBT.INbtTag? value) in entries) {
                if (value != null) {
                    resolved[key] = value;
                    continue;
                }
                vanilla ??= ((INbtSerialisableRegistry)VanillaRegistry.Data.SubRegistries.First(r => r.RegistryId == id)).ToNbt();
                if (vanilla.TryGetValue(key, out NBT.INbtTag? known)) {
                    resolved[key] = known;
                }
                else {
                    throw new InvalidOperationException($"Server referenced {key} in {id} from a known pack, and this client has no such entry");
                }
            }
            target.LoadNbt(resolved, registry);
        }
        return registry;
    }

    #endregion

    public override string ToString() => $"MinecraftClient({_host}:{_port}, {Phase})";
}
