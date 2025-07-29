using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Implementations.Events;
using Minecraft.Schemas.Items;

namespace ManagedServer.Events;

[NotCalledByDefault]
public class InventoryClickEvent : IPlayerEvent, IInventoryEvent, ICancelableEvent {
    public required World World { get; init; }
    public required PlayerEntity Player { get; init; }
    public required Inventory.Inventory Inventory { get; init; }
    public required int Slot { get; init; }
    public required ItemStack? ClickedItem { get; init; }
    public required ItemStack CursorItem { get; init; }
    
    /// <summary>
    /// Whether to do nothing and inform the client that the block break was cancelled.
    /// </summary>
    public bool Cancelled { get; set; }

    public Entity Entity {
        get => Player;
        init { }
    }
}
