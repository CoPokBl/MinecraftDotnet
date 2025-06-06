using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;
using Minecraft.NBT.Text;
using Minecraft.Packets;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Connections;

public abstract class PlayerConnection {
    public PlayerConnectionState State = PlayerConnectionState.None;
    public bool Compression => CompressionThreshold >= 0;
    public int CompressionThreshold = -1;
    public ServerBoundHandshakePacket? Handshake;
    public event Action? Disconnected;
    public readonly Dictionary<string, object?> Data = new();
    public EventNode<ServerEvent> Events = new();  // its parent should be the server's

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

    public abstract Task SendPacket(MinecraftPacket packet);
    public abstract Task HandlePackets();
    public abstract void Disconnect();
}