using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Implementations.Events;
using Minecraft.Packets;

namespace ManagedServer.Events;

[BuiltinEvent]
public class PlayerPacketReceiveEvent : IPlayerEvent, ICancelableEvent {
    public required World World { get; init; }
    public required PlayerEntity Player { get; init; }
    public required MinecraftPacket Packet { get; init; }
    public bool Cancelled { get; set; }
    
    public Entity Entity {
        get => Player;
        init { }
    }
}
