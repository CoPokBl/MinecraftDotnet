using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Packets;

namespace Minecraft.Implementations.Server.Events;

public class PacketSendingEvent : IServerEvent, ICancelableEvent {
    public bool Cancelled { get; set; } = false;
    public required PlayerConnection Connection { get; set; }
    public required MinecraftPacket Packet { get; set; }
}