using Minecraft.Implementations.Client.Events;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Exceptions;
using Minecraft.Packets;
using Minecraft.Packets.Registry;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Client;

public abstract class ServerConnection : MinecraftConnection {
    public EventNode<ClientEvent> Events = new();

    protected static readonly MinecraftPacket[] DontLog = [];

    public void HandlePacket(MinecraftPacket packet) {
        if (!DontLog.Any(p => p.GetType().FullName!.Equals(packet.GetType().FullName))) {
            Log($"Got full packet: {PacketRegistry.GetPacketId(packet.GetType(), State)}, {packet.GetType().FullName}");
        }
        
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
    
    public Task EnableEncryption() {
        throw new NotImplementedException("Encryption is not yet implemented in the client connection.");
    }

    public Task<MinecraftPacket> WaitForPacket() {
        TaskCompletionSource<MinecraftPacket> tcs = new();
        Events.OnFirst<PacketHandleEvent>(e => tcs.SetResult(e.Packet));
        return tcs.Task;
    }

    public void SetCompression(int minSize) {
        if (State != ConnectionState.Login) {
            throw new ConnectionStateException(ConnectionState.Login, State, "Connection must be in login state to enable compression.");
        }
        CompressionThreshold = minSize;
    }

    public override Task SendPacket(MinecraftPacket packet) {
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
}
