using ManagedServer.Entities.Types;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

public class PlayerEntityInteractEvent : IPlayerEvent {
    public required Entity Target;
    public required PlayerEntity Player { get; init; }
    public required World World { get; init; }
    public required ServerBoundInteractPacket.InteractType Type;
    public FVec3? TargetLocation;
    public Hand? UsedHand;
    public required bool SneakPressed;
    
    public Entity Entity {
        get => Player;
        init { }
    }
}
