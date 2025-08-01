using System.Text;
using Minecraft;
using Minecraft.Implementations.Client;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Handshake;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Packets.Status.ServerBound;
using Minecraft.Schemas;
using Minecraft.Text;
using Newtonsoft.Json;

namespace Proxy;

public class ProxiedConnection : MappedTaggable {
    public ProxyServer Proxy { get; }
    public readonly PlayerConnection Player;
    public ServerConnection? Server;  // the server that this player is connected to
    public int EntityId = -1;
    private readonly Dictionary<string, byte[]> _cookies = [];
    
    private ServerBoundLoginStartPacket? _loginStartPacket;  // the login start packet sent by the player
    private Action? _cancelServerPacketListener;
    
    // constants
    private const string ProxiedServer = "michael-endy";
    private const int ProxiedPort = 25565;  // default Minecraft port, can be changed if needed
    private const bool LogPackets = false;  // whether to log packets or not
    private readonly KnownDataPack[] _knownPacks = [ new("minecraft", "core", "1.21.7") ];

    public ProxiedConnection(ProxyServer proxy, PlayerConnection player) {
        Proxy = proxy;
        Player = player;

        player.AllowUnknownPackets = true;

        // Log the player in
        Action cancelLoginListener = null!;
        cancelLoginListener = Player.Events.AddListener<PacketHandleEvent>(async void (e) => {
            try {
                switch (e.Packet) {
                    // STATUS
                    case ServerBoundStatusRequestPacket: {
                        Player.SendPacket(new ClientBoundStatusResponsePacket {
                            Description = TextComponent.Text("PROXY LESSGO"),
                            MaxPlayers = 20,
                            OnlinePlayers = 1,
                            VersionName = "Proxy",
                            VersionProtocol = Player.Handshake!.ProtocolVersion,
                        });
                        break;
                    }
                    
                    // LOGIN
                    case ServerBoundLoginStartPacket ls: {
                        _loginStartPacket = ls;
                        e.Connection.SetCompression(64);
                        e.Connection.SendPackets(new ClientBoundLoginSuccessPacket {
                            Uuid = ls.Uuid,
                            Username = ls.Name
                        });
                        break;
                    }

                    // case ClientBoundSetCompressionPacket sc: {
                    //     Server!.SetCompression(sc.Threshold);
                    //     break;
                    // }
                    //
                    // case ClientBoundEncryptionRequestPacket:
                    //     throw new Exception("Encryption is not supported in the proxy.");
                    
                    // At this point we can enter config (which involves contacting the server)
                    case ServerBoundLoginAcknowledgedPacket: {
                        Player.State = ConnectionState.Configuration;
                        
                        cancelLoginListener();
                        await JoinServer(ProxiedServer, ProxiedPort);
                        
                        Player.Disconnected += LeaveServer;

                        Player.Events.AddListener<PacketHandleEvent>(phe => OnPlayerPacket(phe.Packet));
                        break;
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                throw; // TODO handle exception
            }
        });
    }

    private void LeaveServer() {
        Server?.Disconnect();
        _cancelServerPacketListener?.Invoke();
    }

    public async Task JoinServer(string ip, int port = 25565, bool transfer = false) {
        LeaveServer();
        
        PreServerJoinEvent preJoinEvent = new() {
            Connection = this
        };
        Proxy.Events.CallEvent(preJoinEvent);

        if (Player.State != ConnectionState.Configuration) {
            Console.WriteLine("Reconfiguring player connection to join server...");
            
            // Wait for the player to acknowledge the configuration before continuing
            Player.Events.OnFirstWhere<PacketHandleEvent>(e => 
                e.Packet is ServerBoundAcknowledgeConfigurationPacket, e => {
                Console.WriteLine("Player acknowledged configuration, continuing...");
                _ = PerformServerConnection(ip, port, transfer);
            });
            
            // We need to be in configuration state to join a server
            Player.SendPacket(new ClientBoundStartConfigurationPacket());
            
            Console.WriteLine("Waiting for player to acknowledge configuration...");
            return;
        }

        await PerformServerConnection(ip, port);
    }

    private async Task PerformServerConnection(string ip, int port, bool transfer = false) {
        Server = await MinecraftClientUtils.ConnectToServer(ip, port);
        Server.SendPacket(new ServerBoundHandshakePacket {
            Hostname = ip,
            Intent = transfer ? ServerBoundHandshakePacket.Intention.Transfer : ServerBoundHandshakePacket.Intention.Login,
            Port = (ushort)port,
            ProtocolVersion = Player.Handshake!.ProtocolVersion
        });

        Server.State = ConnectionState.Login;
        Server.SendPacket(_loginStartPacket.ThrowIfNull());
        
        Server.Disconnected += () => {
            Console.WriteLine("Server disconnected, leaving server...");
            Player.SendSystemMessage("You have been disconnected from the server.");
        };

        Action cancelServerLoginListener = null!;
        Action finishedLogin = () => {
            cancelServerLoginListener();
            _cancelServerPacketListener = Server.Events.AddListener<Minecraft.Implementations.Client.Events.PacketHandleEvent>(e =>
                OnServerPacket(e.Packet));
        };
        
        cancelServerLoginListener = Server.Events.AddListener<Minecraft.Implementations.Client.Events.PacketHandleEvent>(e =>
            HandleServerLoginPacket(e.Packet, finishedLogin));
    }

    private void HandleServerLoginPacket(MinecraftPacket packet, Action finished) {
        switch (packet) {
            case ClientBoundEncryptionRequestPacket er: {
                MinecraftPacket resp = Server!.EnableEncryption(er, false);
                Server!.EncryptionEnabled = false;
                ServerPacketEvent e = new() {
                    Connection = this,
                    Packet = packet,
                    Cancelled = false
                };
                Proxy.Events.CallEvent(e);

                Server!.SendPacket(resp);
                Console.WriteLine("Send encryption response");
                Server!.EncryptionEnabled = true;
                break;
            }

            case ClientBoundSetCompressionPacket sc: {
                Server!.SetCompression(sc.Threshold);
                break;
            }

            case ClientBoundLoginSuccessPacket: {
                Server!.SendPacket(new ServerBoundLoginAcknowledgedPacket());
                Server.State = ConnectionState.Configuration;

                Console.WriteLine("Player logged in successfully, switching to configuration state and starting to forward packets");
                finished();
                break;
            }

            case ClientBoundLoginDisconnectPacket dc: {
                JoinServer(ProxiedServer, ProxiedPort);
                Task.Delay(2000).ContinueWith(_ => {
                    Player.SendSystemMessage(dc.Reason);
                });
                break;
            }

            case ClientBoundCookieRequestPacket cr: {
                _cookies.TryGetValue(cr.Key, out byte[]? value);
                MinecraftPacket resp = new ServerBoundCookieResponsePacket {
                    Key = cr.Key,
                    Data = value
                };
                Console.WriteLine("Responding to cookie request: " + cr.Key + $", had value: {Encoding.UTF8.GetString(value!)}");
                Server!.SendPacket(resp);
                break;
            }
        }
    }
    
    // packet from player to server
    private void OnPlayerPacket(MinecraftPacket packet) {
        PlayerPacketEvent e = new() {
            Connection = this,
            Packet = packet,
            Cancelled = false
        };
        Proxy.Events.CallEvent(e);

        if (e.Cancelled) {
            return;
        }
        
        if (Server == null) {
            Console.WriteLine("Dropping packet because server is null: " + packet.GetType().Name);
            return;
        }

        if (LogPackets) {
            Console.WriteLine("Sending packet to server: " + packet.GetType().Name);
        }
        Server.SendPacket(packet);
        // if (Player.State == Server.State) {
        //     Console.WriteLine("Sending packet to server: " + packet.GetType().Name);
        //     Server.SendPacket(packet);
        // }
        // else {
        //     Console.WriteLine("NOT Sending packet to server: " + packet.GetType().Name);
        // }
        
        switch (packet) {
            case ServerBoundAcknowledgeConfigurationPacket: {
                Player.State = ConnectionState.Configuration;
                break;
            }

            case ServerBoundAcknowledgeFinishConfigurationPacket: {
                Player.State = ConnectionState.Play;
                Server!.State = ConnectionState.Play;
                break;
            }
        }
    }

    // packet from server to player
    private void OnServerPacket(MinecraftPacket packet) {
        if (LogPackets) {
            Console.WriteLine("SERVER PACKET: " + packet.GetType().Name);
        }
        if (packet is ClientBoundLoginPacket lp) {
            EntityId = lp.EntityId;
        }

        if (packet is ClientBoundStoreCookiePacket sk) {
            _cookies.Add(sk.Key, sk.Payload);
        }

        if (packet is ClientBoundTransferPacket tp) {
            Console.WriteLine("TRANSFERING PLAYER TO SERVER: " + tp.Host + ":" + tp.Port);
            
            // Override and switch to the new server
            JoinServer(tp.Host, tp.Port, true);
            return;
        }

        if (packet is ClientBoundDisconnectPacket dc) {
            Player.SendSystemMessage(TextComponent.Text("You have been disconnected from your server: ").With(dc.Reason));
            Player.SendSystemMessage("You can rejoin by using .join <host> <port>");
            Console.WriteLine("Disconnecting player from server: " + dc.Reason);
            return;
        }

        if (packet is ClientBoundStoreCookiePacket sc) {
            Console.WriteLine("Got store cookie packet, storing cookie: " + sc.Key);
            Console.WriteLine(Encoding.UTF8.GetString(sc.Payload));
        }
        
        // if (packet is ClientBoundFinishConfigurationPacket) {
        //     Server!.State = ConnectionState.Play;
        //     Console.WriteLine("Set state to play, we have logged in");
        // }
        
        ServerPacketEvent e = new() {
            Connection = this,
            Packet = packet,
            Cancelled = false
        };
        Proxy.Events.CallEvent(e);

        if (e.Cancelled) {
            return;
        }

        if (e.Packet is ClientBoundLoginPacket lg) {
            // lg.DimensionType = 0;
        }

        // if (e.Packet is ClientBoundChunkDataAndUpdateLightPacket ucal) {
        //     Console.WriteLine($"Loading chunk: {ucal.ChunkX}, {ucal.ChunkZ}");
        // }
        //
        // if (e.Packet is ClientBoundUnloadChunkPacket uc) {
        //     Console.WriteLine("Unloading chunk: " + uc.X + ", " + uc.Z);
        // }
            
        
        if (Player.State != Server!.State) {
            Console.WriteLine("NOT Sending packet to player: " + packet.GetType().Name);
            return;
        }

        Type[] ignoredPackets = [
            typeof(ClientBoundSetHeadRotationPacket),
            typeof(ClientBoundUpdateTimePacket),
            typeof(ClientBoundUpdateEntityPositionPacket),
            typeof(ClientBoundBlockUpdatePacket),
            typeof(ClientBoundUpdateEntityPosAndRotPacket),
            typeof(ClientBoundSoundEffectPacket),
            typeof(ClientBoundTeleportEntityPacket)
        ];
        if (!ignoredPackets.Contains(packet.GetType())) {
            Console.WriteLine("Sending packet to player: " + packet.GetType().Name);
            try {
                if (packet is ClientBoundParticlePacket) {
                    Console.WriteLine(JsonConvert.SerializeObject(packet, Formatting.Indented));
                }
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                throw;
            }
        }
        
        Player.SendPacket(packet);
    }
}