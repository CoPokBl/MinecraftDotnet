using Minecraft.Implementations.Events;
using Minecraft.Packets;

namespace Minecraft.Implementations.Client.Events;

/// <summary>
/// Event for when a packet is received, this is cancelable.
/// The packet SHOULD NOT be handled from this event.
/// This event should only be used to cancel packets.
/// </summary>
public class PacketReceiveEvent : IClientEvent, ICancelableEvent {
    public bool Cancelled { get; set; } = false;
    public required MinecraftPacket Packet { get; set; }
}