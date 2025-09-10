using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Inventories;
using ManagedServer.Worlds;

namespace ManagedServer.Events;

[NotCalledByDefault]
public class PlayerCloseInventoryEvent : IPlayerEvent {
    public required World World { get; init; }
    public required PlayerEntity Player { get; init; }
    public required Inventory Inventory { get; init; }
    
    public Entity Entity {
        get => Player;
        init { }
    }
}
