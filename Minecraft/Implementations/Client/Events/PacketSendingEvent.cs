using Minecraft.Implementations.Events;
using Minecraft.Packets;

namespace Minecraft.Implementations.Client.Events;

public class PacketSendingEvent : ClientEvent, ICancelableEvent {
    public bool Cancelled { get; set; } = false;
    public required MinecraftPacket Packet { get; set; }
}