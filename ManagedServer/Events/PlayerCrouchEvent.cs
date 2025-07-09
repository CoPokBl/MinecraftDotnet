using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Implementations.Events;

namespace ManagedServer.Events;

[NotCalledByDefault]
public class PlayerCrouchEvent : IPlayerEvent, ICancelableEvent {
    public required World World { get; init; }
    public required PlayerEntity Player { get; init; }
    public required bool IsCrouching { get; init; }
    public bool Cancelled { get; set; }
    
    public Entity Entity {
        get => Player;
        init { }
    }
}