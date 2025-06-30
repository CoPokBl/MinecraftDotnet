using Minecraft.Implementations.Events;
using Minecraft.Packets;

namespace Proxy;

public class ServerPacketEvent : ProxyEvent, ICancelableEvent {
    public required MinecraftPacket Packet;
    public bool Cancelled { get; set; }
}
