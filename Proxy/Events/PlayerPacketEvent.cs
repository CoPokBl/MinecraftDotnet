using Minecraft.Implementations.Events;
using Minecraft.Packets;

namespace Proxy.Events;

public class PlayerPacketEvent : ProxyEvent, ICancelableEvent {
    public required MinecraftPacket Packet;
    public bool Cancelled { get; set; }
}
