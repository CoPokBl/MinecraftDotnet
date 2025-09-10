using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Inventories;
using ManagedServer.Schemas;
using ManagedServer.Worlds;
using Minecraft.Implementations.Events;
using Minecraft.Schemas.Items;

namespace ManagedServer.Events;

[NotCalledByDefault]
public class InventoryPreClickEvent : IPlayerEvent, IInventoryEvent, ICancelableEvent {
    public required World World { get; init; }
    public required PlayerEntity Player { get; init; }
    public required Inventory Inventory { get; init; }
    public required int Slot { get; init; }
    public required ItemStack? ClickedItem { get; init; }
    public required ItemStack CursorItem { get; init; }
    public required ClickType Type { get; init; }
    
    /// <summary>
    /// Whether to do nothing and resend the inventory contents to the player.
    /// </summary>
    public bool Cancelled { get; set; }

    public Entity Entity {
        get => Player;
        init { }
    }
}
