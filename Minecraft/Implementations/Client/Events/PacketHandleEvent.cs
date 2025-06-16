using Minecraft.Packets;

namespace Minecraft.Implementations.Client.Events;

/// <summary>
/// Event to process a packet, this event is not cancelable
/// and listeners can use this to handle packets.
/// <p/>
/// This event is effectively readonly.
/// </summary>
/// <remarks>To modify an incoming packet use <see cref="PacketReceiveEvent"/>.</remarks>
public class PacketHandleEvent : ClientEvent {
    public required MinecraftPacket Packet { get; init; }
}