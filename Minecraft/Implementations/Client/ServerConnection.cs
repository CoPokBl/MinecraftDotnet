using Minecraft.Implementations.Client.Events;
using Minecraft.Implementations.Events;
using Minecraft.Packets;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Client;

public abstract class ServerConnection {
    public PlayerConnectionState State = PlayerConnectionState.None;
    public bool Compression => CompressionThreshold >= 0;
    public int CompressionThreshold = -1;
    public event Action? Disconnected;
    public EventNode<ClientEvent> Events = new();

    protected static readonly MinecraftPacket[] DontLog = [];

    protected void Log(string s) {
        Console.WriteLine($"[{State}] {s}");
    }

    public void HandlePacket(MinecraftPacket packet) {
        PacketReceiveEvent receiveEvent = new() {
            Packet = packet
        };
        Events.CallEventCatchErrors(receiveEvent);

        if (receiveEvent.Cancelled) {
            return;
        }

        // Now send the cancelable handle event
        PacketHandleEvent handleEvent = new() {
            Packet = packet
        };
        Events.CallEventCatchErrors(handleEvent);
    }

    public Task<MinecraftPacket> WaitForPacket() {
        TaskCompletionSource<MinecraftPacket> tcs = new();
        Events.OnFirst<PacketHandleEvent>(e => tcs.SetResult(e.Packet));
        return tcs.Task;
    }

    protected void InvokeDisconnected() {
        Disconnected?.Invoke();
    }

    public async Task SetCompression(int minSize) {
        if (State != PlayerConnectionState.Login) {
            throw new Exception("Connection must be in login state to enable compression.");
        }

        await SendPacket(new ClientBoundSetCompressionPacket {
            Threshold = minSize
        });
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
            Packet = packet
        };
        Events.CallEvent(e);

        if (e.Cancelled) {
            return Task.CompletedTask;
        }
        
        // Send it
        return SendPacketInternal(packet);
    }

    protected abstract Task SendPacketInternal(MinecraftPacket packet);
    public abstract Task HandlePackets();
    public abstract void Disconnect();
}