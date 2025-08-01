using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Implementations.Events;
using Minecraft.Schemas.Items;

namespace ManagedServer.Events;

[NotCalledByDefault]
public class PlayerDropItemEvent : IPlayerEvent, ICancelableEvent {
    public required World World { get; init; }
    public required PlayerEntity Player { get; init; }
    public required ItemStack Item { get; set; }
    
    public Entity Entity {
        get => Player;
        init { }
    }

    public bool Cancelled { get; set; }
}