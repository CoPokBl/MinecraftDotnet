using ManagedServer.Entities.Types;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;

namespace ManagedServer.Events;

public class PlayerAttackEntityEvent : IPlayerEvent {
    public required Entity Target;
    public required Player Player { get; init; }
    public required World World { get; init; }

    public Entity Entity {
        get => Player;
        init { }
    }
}
