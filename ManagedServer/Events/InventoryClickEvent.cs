using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Inventories;
using ManagedServer.Schemas;
using ManagedServer.Worlds;
using Minecraft.Schemas.Items;

namespace ManagedServer.Events;

[NotCalledByDefault]
public class InventoryClickEvent : IPlayerEvent, IInventoryEvent {
    public required World World { get; init; }
    public required Player Player { get; init; }
    public required Inventory Inventory { get; init; }
    public required int Slot { get; init; }
    public required ItemStack? ClickedItem { get; init; }
    public required ItemStack CursorItem { get; init; }
    public required ClickType Type { get; init; }

    public Entity Entity {
        get => Player;
        init { }
    }
}
