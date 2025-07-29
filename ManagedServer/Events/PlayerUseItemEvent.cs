using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ManagedServer.Events;

[NotCalledByDefault]
public class PlayerUseItemEvent : IPlayerEvent {
    public required World World { get; init; }
    public required PlayerEntity Player { get; init; }
    public required ItemStack Item { get; init; }
    public required Hand Hand { get; init; }
    public bool StopsBlockPlacement { get; set; } = false;
    
    public Entity Entity {
        get => Player;
        init { }
    }
}
