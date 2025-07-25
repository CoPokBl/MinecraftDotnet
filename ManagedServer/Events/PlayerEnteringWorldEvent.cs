using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;

namespace ManagedServer.Events;

[BuiltinEvent]
public class PlayerEnteringWorldEvent : IPlayerEvent {
    public required World World { get; init; }
    public required PlayerEntity Player { get; init; }
    
    public Entity Entity {
        get => Player;
        init { }
    }
}
