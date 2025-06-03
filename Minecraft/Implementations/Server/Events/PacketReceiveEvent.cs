using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Packets;

namespace Minecraft.Implementations.Server.Events;

/// <summary>
/// Event for when a packet is received, this is cancelable.
/// The packet SHOULD NOT be handled from this event.
/// This event should only be used to cancel packets.
/// </summary>
public class PacketReceiveEvent : ServerEvent, ICancelableEvent {
    public bool Cancelled { get; set; } = false;
    public required PlayerConnection Connection { get; set; }
    public required MinecraftPacket Packet { get; set; }
}