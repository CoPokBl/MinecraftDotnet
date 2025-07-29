using System.Collections.Concurrent;
using System.Diagnostics;
using ClientLib.Events;
using ClientLib.Features;
using ClientLib.Features.Basic;
using ClientLib.Scheduling;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Client;
using Minecraft.Implementations.Client.Events;
using Minecraft.Implementations.Client.Tools;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Handshake;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace ClientLib;

public class MinecraftClient : MappedTaggable, IFeatureScope {
    public ServerConnection Connection { get; }
    public EventNode<IClientEvent> Events { get; } = new();
    public FeatureHandler FeatureHandler { get; }
    public MicrosoftAuthenticator.MinecraftProfile? Account { get; set; } = null;
    public Dictionary<string, LoginPluginHandler> LoginPluginHandlers { get; } = [];
    public KnownDataPack[] KnownPacks { get; set; } = [
        new("minecraft", "core", "1.21.7")
    ];
    public GameProfile Profile { get; set; } = new("Bob", Guid.NewGuid());
    public ClientInventory Inventory { get; private set; }
    public ServerInfo ServerInfo { get; private set; } = new();
    public Dictionary<string, Dictionary<string, INbtTag?>> ClientRegistryData { get; } = [];
    public Identifier[] ServerDimensions { get; private set; } = [];
    public ClientWorld World { get; private set; }
    public int EntityId { get; set; } = 0;
    public GameMode GameMode { get; set; } = GameMode.Survival;
    public GameMode PreviousGameMode { get; set; } = GameMode.Undefined;
    public GameRuleSet GameRules { get; private set; } = new();
    public Vec3<double> Position {
        get => _position;
        set {
            _position = value;
            SendPositionUpdate();
        }
    }
    public List<PlayerInfoEntry> PlayerInfoEntries { get; } = [];

    public MinecraftClient Client => this;
    public MinecraftRegistry ProtocolRegistry { get; }
    public ClientScheduler Scheduler { get; }
    public ulong CurrentTick { get; private set; } = 0;
    public volatile bool LoggedIn = false;
    
    private Thread _ticker = null!;
    private bool _started;
    private readonly CancellationTokenSource _cts = new();
    private TimeSpan TargetTickTime => TimeSpan.FromSeconds(1.0 / TargetTicksPerSecond);
    public int TargetTicksPerSecond = 20;
    
    private Vec3<double> _position = new(0, 0, 0);
    
    public static readonly FeatureBundle BasicFeatures = new(
        new GravityFeature()
    );

    private static void Log(string a) {
        Console.WriteLine(a);
    }

    public MinecraftClient(ServerConnection connection, MinecraftRegistry? registry = null) {
        Connection = connection;
        World = ClientWorld.Default(this);
        Inventory = new ClientInventory(this);
        ProtocolRegistry = registry ?? VanillaRegistry.Data;
        Scheduler = new ClientScheduler(this);
        
        FeatureHandler = new FeatureHandler(this);
        
        Events.AddChild(Connection.Events);
    }

    private void Start() {
        _ticker = new Thread(Ticker) {
            Name = "Minecraft Client Ticker",
            IsBackground = false
        };
        _ticker.Start();
        _started = true;
    }
    
    private void Ticker() {
        Stopwatch tickTimer = new();
        TimeSpan lastTickTime = TimeSpan.Zero;
        while (!_cts.IsCancellationRequested) {
            tickTimer.Restart();
            TickEvent tickEvent = new() {
                Delta = lastTickTime,
                TargetDelta = TargetTickTime
            };
            Exception? exception = Events.CallEventCatchErrors(tickEvent);
            if (exception != null) {
                HandleError(exception);
            }
            TimeSpan tickTime = tickTimer.Elapsed;
            lastTickTime = tickTime;
            
            if (tickTime < TargetTickTime) {
                // Sleep for the remaining time to maintain the target tick rate
                Thread.Sleep(TargetTickTime - tickTime);
            }
            else {
                // If we took too long, log a warning
                Log($"WARNING: Tick took {tickTime.TotalMilliseconds}ms, " + 
                          $"exceeding target of {TargetTickTime.TotalMilliseconds}ms.");
            }
            
            CurrentTick++;
        }
    }
    
    public void HandleError(Exception exception) {
        Console.WriteLine(exception);
    }

    // TODO: Clean up this mess (Login and LoginPhasePacket)
    public void Login(string hostname, ushort port, int protocolVersion) {
        Start();
        
        SendPacket(new ServerBoundHandshakePacket {
            Hostname = hostname,
            Port = port,
            ProtocolVersion = protocolVersion,
            Intent = ServerBoundHandshakePacket.Intention.Login
        });
        
        Connection.State = ConnectionState.Login;
        SendPacket(new ServerBoundLoginStartPacket {
            Name = Profile.Username,
            Uuid = Profile.Uuid
        });
        
        Action cancelAction = null!;
        cancelAction = Events.AddListener<PacketHandleEvent>(async void (e) => {
            try {
                await LoginPhasePacket(e.Packet, cancelAction);
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                throw;
            }
        });

        Events.AddListener<PacketHandleEvent>(e => {
            if (Connection.State != ConnectionState.Play) {
                return;
            }
            HandlePlayPacket(e.Packet);
        });
    }

    private async Task LoginPhasePacket(MinecraftPacket packet, Action stop) {
        Log("Got packet in login phase: " + packet.GetType().FullName);
        
        switch (packet) {
            case ClientBoundEncryptionRequestPacket er: {
                Log("Received encryption request from server, should authenticate? " + er.ShouldAuthenticate);
                ServerBoundEncryptionResponsePacket response = Connection.EnableEncryption(er, false);
                Connection.EncryptionEnabled = false;
                if (er.ShouldAuthenticate) {
                    if (Account == null) {
                        Console.WriteLine("WARNING: Server requested encryption, but no account is set. Skipping authentication.");
                    }
                    else {
                        Log("Authenticating to join the server with account: " + Account.Username);
                        await MinecraftClientUtils.AuthenticateToJoin(Account.AccessToken, Account.Uuid, er.ServerId,
                            Connection.SharedSecret!, er.PublicKey);
                    }
                }
                
                Log("Sending encryption response to server.");
                SendPacket(response);
                Connection.EncryptionEnabled = true;
                Log("Sent encryption response to server.");
                break;
            }
            
            case ClientBoundSetCompressionPacket scp: {
                Log("Enabling compression with threshold: " + scp.Threshold);
                Connection.SetCompression(scp.Threshold);
                break;
            }
            
            case ClientBoundLoginPluginRequestPacket lpr: {
                string channel = lpr.Channel;
                byte[]? response = LoginPluginHandlers.TryGetValue(channel, out LoginPluginHandler? handler) 
                    ? handler.Invoke(lpr.Data) 
                    : null;
                
                SendPacket(new ServerBoundLoginPluginResponsePacket {
                    MessageId = lpr.MessageId,
                    Data = response
                });
                break;
            }
            
            case ClientBoundLoginSuccessPacket success: {
                Profile = new GameProfile(success.Username, success.Uuid);
                
                SendPacket(new ServerBoundLoginAcknowledgedPacket());
                Connection.State = ConnectionState.Configuration;
                
                LoginEvent loginEvent = new() {
                    Profile = Profile
                };
                Events.CallEvent(loginEvent);

                break;  // login successful
            }
            
            // CONFIG ======================================
            case ClientBoundFeatureFlagsPacket ff: {
                ServerInfo = ServerInfo with {
                    FeatureFlags = ff.Flags
                };
                break;
            }
                
            case ClientBoundKnownPacksPacket kp: {
                ServerInfo = ServerInfo with {
                    KnownPacks = kp.Packs
                };

                Log("Received known packs from server (" + kp.Packs.Length + " packs).");
                // We need to respond with ours where they overlap
                KnownDataPack[] overlappingPacks = KnownPacks
                    .Where(kp1 => kp.Packs.Any(kp2 => 
                        kp1.Id == kp2.Id && kp1.Version == kp2.Version && kp1.Namespace == kp2.Namespace))
                    .ToArray();
                
                SendPacket(new ServerBoundKnownPacksPacket {
                    Packs = overlappingPacks
                });
                    
                Log("Sent overlapping packs to server (" + overlappingPacks.Length + " packs).");
                break;
            }

            case ClientBoundRegistryDataPacket rd: {
                ClientRegistryData.Add(rd.RegistryId, rd.Entries);
                break;
            }

            case ClientBoundFinishConfigurationPacket: {
                SendPacket(new ServerBoundAcknowledgeFinishConfigurationPacket());
                Connection.State = ConnectionState.Play;
                break;
            }
            
            // PLAY ======================================
            case ClientBoundLoginPacket loginPacket: {
                ServerDimensions = loginPacket.Dimensions;
                World = new ClientWorld(
                    this,
                    loginPacket.DimensionName, 
                    loginPacket.DimensionType, 
                    loginPacket.SeaLevel,
                    loginPacket.IsFlat,
                    loginPacket.HashedSeed);
                EntityId = loginPacket.EntityId;
                GameMode = loginPacket.GameMode;
                PreviousGameMode = loginPacket.PreviousGameMode;

                GameRules = GameRules with {
                    EnableRespawnScreen = loginPacket.EnableRespawnScreen,
                    LimitedCrafting = loginPacket.DoLimitedCrafting
                };
        
                ServerInfo = ServerInfo with {
                    SimulationDistance = loginPacket.SimulationDistance,
                    ViewDistance = loginPacket.ViewDistance,
                    EnforcesSecureChat = loginPacket.EnforcesSecureChat
                };
        
                JoinEvent joinEvent = new() {
                    World = World
                };
                Events.CallEvent(joinEvent);

                Events.AddListener<PacketHandleEvent>(e => {
                    HandlePlayPacket(e.Packet);
                });

                LoggedIn = true;
                Log("Logged in!");
                stop();
                break;
            }
        }
    }
    
    private void SendPositionUpdate() {
        SendPacket(new ServerBoundSetPlayerPositionPacket {
            Position = Position,
            Flags = MovePlayerFlags.None
        });
    }

    private void HandlePlayPacket(MinecraftPacket packet) {
        Inventory.HandlePacket(packet);
        World.HandlePacket(packet);
        
        switch (packet) {
            case ClientBoundSynchronisePlayerPositionPacket spp: {
                SendPacket(new ServerBoundConfirmTeleportPacket {
                    TeleportId = spp.TeleportId
                });
                Position = spp.Position;
                break;
            }

            case ClientBoundPlayerInfoUpdatePacket updatePacket: {
                foreach ((Guid playerId, ClientBoundPlayerInfoUpdatePacket.PlayerData.IPlayerAction[] playerActions) in updatePacket.Data.Data) {
                    foreach (ClientBoundPlayerInfoUpdatePacket.PlayerData.IPlayerAction action in playerActions) {
                        switch (action) {
                            case ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer add: {
                                Dictionary<string, (string Value, string? Signature)> props = [];
                                foreach (ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer.Property prop in add.Properties) {
                                    props.Add(prop.Name, (prop.Value, prop.Signature));
                                }
                                PlayerInfoEntries.Add(new PlayerInfoEntry(playerId, add.Name, props));
                                break;
                            }
                            
                            case ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateGameMode updateGameMode: {
                                PlayerInfoEntry? entry = PlayerInfoEntries.FirstOrDefault(e => e.Uuid == playerId);
                                if (entry != null) {
                                    PlayerInfoEntries.Remove(entry);
                                    PlayerInfoEntries.Add(entry with { GameMode = updateGameMode.GameMode });
                                }
                                else {
                                    Console.WriteLine($"WARNING: Player {playerId} does not exist, cannot update GameMode.");
                                }
                                break;
                            }
                            
                            case ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateLatency updateLatency: {
                                PlayerInfoEntry? entry = PlayerInfoEntries.FirstOrDefault(e => e.Uuid == playerId);
                                if (entry != null) {
                                    PlayerInfoEntries.Remove(entry);
                                    PlayerInfoEntries.Add(entry with { Latency = updateLatency.Latency });
                                }
                                else {
                                    Console.WriteLine($"WARNING: Player {playerId} does not exist, cannot update Latency.");
                                }
                                break;
                            }
                            
                            case ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateDisplayName updateDisplayName: {
                                PlayerInfoEntry? entry = PlayerInfoEntries.FirstOrDefault(e => e.Uuid == playerId);
                                if (entry != null) {
                                    PlayerInfoEntries.Remove(entry);
                                    PlayerInfoEntries.Add(entry with { DisplayName = updateDisplayName.DisplayName });
                                }
                                else {
                                    Console.WriteLine($"WARNING: Player {playerId} does not exist, cannot update DisplayName.");
                                }
                                break;
                            }
                            
                            case ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateListPriority updateListPriority: {
                                PlayerInfoEntry? entry = PlayerInfoEntries.FirstOrDefault(e => e.Uuid == playerId);
                                if (entry != null) {
                                    PlayerInfoEntries.Remove(entry);
                                    PlayerInfoEntries.Add(entry with { ListPriority = updateListPriority.Priority });
                                }
                                else {
                                    Console.WriteLine($"WARNING: Player {playerId} does not exist, cannot update ListPriority.");
                                }
                                break;
                            }
                            
                            case ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateHat updateHat: {
                                PlayerInfoEntry? entry = PlayerInfoEntries.FirstOrDefault(e => e.Uuid == playerId);
                                if (entry != null) {
                                    PlayerInfoEntries.Remove(entry);
                                    PlayerInfoEntries.Add(entry with { HatVisible = updateHat.Visible });
                                }
                                else {
                                    Console.WriteLine($"WARNING: Player {playerId} does not exist, cannot update Hat visibility.");
                                }
                                break;
                            }
                        }
                        
                    }
                }
                break;
            }
        }
    }
    
    public Dimension? GetDimension(Identifier dimensionId) {
        if (!ServerDimensions.Contains(dimensionId)) {
            return null;
        }

        if (!ClientRegistryData.TryGetValue("minecraft:dimension_type", out Dictionary<string, INbtTag?>? value)) {
            return null;
        }

        if (!value.TryGetValue(dimensionId.ToString(), out INbtTag? tag)) {
            return null;
        }
        
        if (tag is not CompoundTag ct) {
            Console.WriteLine($"WARNING: Dimension type for {dimensionId} is not a CompoundTag, but {tag?.GetType().Name}");
            return null;
        }
        
        return Dimension.FromNbt(ct);
    }

    public void SendPacket(MinecraftPacket packet) {
        Connection.SendPacket(packet);
    }
    
    public void SendPackets(params MinecraftPacket[] packets) {
        foreach (MinecraftPacket packet in packets) {
            SendPacket(packet);
        }
    }
}
