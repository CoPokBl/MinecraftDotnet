using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using Minecraft.Schemas.Items;

namespace ManagedServer.Events;

[BuiltinEvent]
public class InventoryChangeEvent : IInventoryEvent {
    public required Inventory.Inventory Inventory { get; init; }
    public required int Slot { get; set; }
    public required ItemStack PreviousItem { get; set; }
    public required ItemStack NewItem { get; set; }
}
