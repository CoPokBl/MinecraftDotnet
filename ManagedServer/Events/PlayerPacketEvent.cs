using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Packets;

namespace ManagedServer.Events;

[BuiltinEvent]
public class PlayerPacketHandleEvent : IPlayerEvent {
    public required PlayerEntity Player { get; init; }
    public required MinecraftPacket Packet { get; init; }
    public required World World { get; init; }
    
    public Entity Entity {
        get => Player;
        init { }
    }
}
