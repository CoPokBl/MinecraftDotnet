using ManagedServer.Entities.Types;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

public class PlayerEntityInteractEvent : IPlayerEvent {
    public required Entity Target;
    public required Player Player { get; init; }
    public required World World { get; init; }
    public required Vec3<double> TargetLocation;
    public required Hand UsedHand;
    public required bool SneakPressed;
    
    public Entity Entity {
        get => Player;
        init { }
    }
}
