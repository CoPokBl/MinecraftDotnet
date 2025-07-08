using ManagedServer.Entities.Types;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Implementations.Events;
using Minecraft.Packets;

namespace ManagedServer.Events;

public class PlayerPacketEvent : ICancelableEvent, IPlayerEvent {
    public required PlayerEntity Player { get; init; }
    public required MinecraftPacket Packet { get; init; }
    public required World World { get; init; }
    
    public Entity Entity {
        get => Player;
        init { }
    }

    public bool Cancelled { get; set; }
}
