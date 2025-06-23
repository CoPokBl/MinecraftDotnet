using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Tags;
using Minecraft.NBT.Text;
using Minecraft.Packets;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Connections;

public abstract class PlayerConnection : ITaggable {
    public PlayerConnectionState State = PlayerConnectionState.None;
    public bool Compression => CompressionThreshold >= 0;
    public int CompressionThreshold = -1;
    public ServerBoundHandshakePacket? Handshake;
    public event Action? Disconnected;
    public readonly Dictionary<string, object?> Data = new();
    public EventNode<IServerEvent> Events = new();  // its parent should be the server's

    protected static readonly MinecraftPacket[] DontLog = [
        new ServerBoundClientTickEndPacket(),
        new ServerBoundKeepAlivePacketPlay(),
        new ServerBoundSetPlayerPositionPacket(),
        new ServerBoundSetPlayerRotationPacket(),
        new ServerBoundSetPlayerPosAndRotPacket()
    ];

    protected void Log(string s) {
        Console.WriteLine($"[{State}] {s}");
    }

    public void HandlePacket(MinecraftPacket packet) {
        // Handle connection state changes. Do this before handling because client will have already updated.
        switch (packet) {
            // handshake
            case ServerBoundHandshakePacket hs:
                Handshake = hs;
                Log($"Got handshake from {hs.ProtocolVersion} client, intent: {hs.Intent}");

                State = hs.Intent switch {
                    ServerBoundHandshakePacket.Intention.Status => PlayerConnectionState.Status,
                    ServerBoundHandshakePacket.Intention.Login => PlayerConnectionState.Login,
                    ServerBoundHandshakePacket.Intention.Transfer => throw new NotImplementedException(
                        "Transfer is not yet supported"),
                    _ => throw new ArgumentOutOfRangeException()
                };
                break;

            // LOGIN
            case ServerBoundLoginAcknowledgedPacket: {
                State = PlayerConnectionState.Configuration; // we are done login now
                break;
            }
                        
            // CONFIG
            case ServerBoundAcknowledgeFinishConfigurationPacket: {
                // okay so they're ready to continue
                Log("Client acknowledged finish configuration, switching to play state");
                State = PlayerConnectionState.Play;
                break;
            }
        }
        
        PacketReceiveEvent receiveEvent = new() {
            Connection = this,
            Packet = packet
        };
        Events.CallEventCatchErrors(receiveEvent);

        if (receiveEvent.Cancelled) {
            return;
        }

        // Now send the cancelable handle event
        PacketHandleEvent handleEvent = new() {
            Connection = this,
            Packet = packet
        };
        Events.CallEventCatchErrors(handleEvent);
    }

    protected void InvokeDisconnected() {
        Disconnected?.Invoke();
    }

    public async Task Kick(TextComponent msg) {
        if (State != PlayerConnectionState.Play) {
            Disconnect();
            return;
        }
        await SendPacket(new ClientBoundDisconnectPacketPlay(msg));
        Disconnect();
    }

    public async Task SetCompression(int minSize) {
        if (State != PlayerConnectionState.Login) {
            throw new Exception("Connection must be in login state to enable compression.");
        }

        await SendPacket(new ClientBoundSetCompressionPacket(minSize));
        CompressionThreshold = minSize;
    }

    public async Task SendPackets(bool sequentially, params MinecraftPacket[] packets) {
        foreach (MinecraftPacket packet in packets) {
            if (sequentially) {
                await SendPacket(packet);
            }
            else {
                _ = SendPacket(packet);
            }
        }
    }
        
    public Task SendPackets(params MinecraftPacket[] packets) {
        return SendPackets(true, packets);
    }

    public Task SendPacket(MinecraftPacket packet) {
        PacketSendingEvent e = new() {
            Connection = this,
            Packet = packet
        };
        Events.CallEvent(e);

        if (e.Cancelled) {
            return Task.CompletedTask;
        }
        
        // Send it
        return SendPacketInternal(packet);
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

    protected abstract Task SendPacketInternal(MinecraftPacket packet);
    public abstract Task HandlePackets();
    public abstract void Disconnect();
}