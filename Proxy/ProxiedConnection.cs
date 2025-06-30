using System.Text;
using Minecraft;
using Minecraft.Implementations.Client;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Tags;
using Minecraft.NBT;
using Minecraft.NBT.Text;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Packets.Status.ServerBound;
using Minecraft.Schemas;

namespace Proxy;

public class ProxiedConnection : ITaggable {
    public ProxyServer Proxy { get; }
    public readonly PlayerConnection Player;
    public ServerConnection? Server;  // the server that this player is connected to
    public readonly Dictionary<string, object?> Data = new();
    public int EntityId = -1;
    
    private ServerBoundLoginStartPacket? _loginStartPacket;  // the login start packet sent by the player
    private Action? _cancelServerPacketListener;
    
    // constants
    private const string ProxiedServer = "localhost";
    private const int ProxiedPort = 25565;  // default Minecraft port, can be changed if needed
    private readonly KnownDataPack[] _knownPacks = [ new("minecraft", "core", "1.21.5") ];

    public ProxiedConnection(ProxyServer proxy, PlayerConnection player) {
        Proxy = proxy;
        Player = player;

        // Log the player in
        Action cancelLoginListener = null!;
        cancelLoginListener = Player.Events.AddListener<PacketHandleEvent>(async void (e) => {
            try {
                switch (e.Packet) {
                    // STATUS
                    case ServerBoundStatusRequestPacket: {
                        await Player.SendPacket(new ClientBoundStatusResponsePacket {
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
                        await e.Connection.SetCompression(10);
                        await e.Connection.SendPackets(new ClientBoundLoginSuccessPacket {
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
                throw; // TODO handle exception
            }
        });
    }

    private void LeaveServer() {
        Server?.Disconnect();
        _cancelServerPacketListener?.Invoke();
    }

    public async Task JoinServer(string ip, int port = 25565) {
        LeaveServer();

        if (Player.State != ConnectionState.Configuration) {
            Console.WriteLine("Reconfiguring player connection to join server...");
            
            // Wait for the player to acknowledge the configuration before continuing
            Player.Events.OnFirstWhere<PacketHandleEvent>(e => 
                e.Packet is ServerBoundAcknowledgeConfigurationPacket, e => {
                Console.WriteLine("Player acknowledged configuration, continuing...");
                _ = PerformServerConnection(ip, port);
            });
            
            // We need to be in configuration state to join a server
            await Player.SendPacket(new ClientBoundStartConfigurationPacket());
            
            Console.WriteLine("Waiting for player to acknowledge configuration...");
            return;
        }

        await PerformServerConnection(ip, port);
    }

    private async Task PerformServerConnection(string ip, int port) {
        Server = await MinecraftClientUtils.ConnectToServer(ip, port, false);
        await Server.SendPacket(new ServerBoundHandshakePacket {
            Hostname = ip,
            Intent = ServerBoundHandshakePacket.Intention.Login,
            Port = (ushort)port,
            ProtocolVersion = Player.Handshake!.ProtocolVersion
        });

        Server.State = ConnectionState.Login;
        await Server.SendPacket(_loginStartPacket.ThrowIfNull());

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
                throw new Exception("Encryption is not supported in the proxy.");
            }

            case ClientBoundSetCompressionPacket sc: {
                Server!.SetCompression(sc.Threshold);
                break;
            }

            case ClientBoundLoginSuccessPacket: {
                Server!.SendPacket(new ServerBoundLoginAcknowledgedPacket());
                Server.State = ConnectionState.Configuration;

                finished();
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
        
        // Console.WriteLine("Sending packet to server: " + packet.GetType().Name);
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
        if (packet is ClientBoundLoginPacket lp) {
            EntityId = lp.EntityId;
        }

        if (packet is ClientBoundTransferPacket tp) {
            Console.WriteLine("TRANSFERING PLAYER TO SERVER: " + tp.Host + ":" + tp.Port);
            
            // Override and switch to the new server
            JoinServer(tp.Host, tp.Port);
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
        // Console.WriteLine("Sending packet to player: " + packet.GetType().Name);
        Player.SendPacket(packet);
    }
    
    public T GetTag<T>(Tag<T> tag) {
        return (T)Data[tag.Id]!;
    }

    public bool HasTag<T>(Tag<T> tag) {
        return Data.ContainsKey(tag.Id);
    }

    public void SetTag<T>(Tag<T> tag, T value) {
        Data[tag.Id] = value;
    }
}