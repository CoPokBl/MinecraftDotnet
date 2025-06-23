using Minecraft.Implementations.Server.Connections;
using Minecraft.Packets;

namespace Minecraft.Implementations.Server.Events;

/// <summary>
/// Event to process a packet, this event is not cancelable
/// and listeners can use this to handle packets.
/// <p/>
/// This event is effectively readonly.
/// </summary>
/// <remarks>To modify an incoming packet use <see cref="PacketReceiveEvent"/>.</remarks>
public class PacketHandleEvent : IServerEvent {
    public required PlayerConnection Connection { get; init; }
    public required MinecraftPacket Packet { get; init; }
}