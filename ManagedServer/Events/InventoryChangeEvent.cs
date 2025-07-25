using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using Minecraft.Schemas.Items;

namespace ManagedServer.Events;

/// <summary>
/// Called when a slot in an inventory changes.
/// </summary>
[BuiltinEvent]
public class InventoryChangeEvent : IInventoryEvent {
    /// <summary>
    /// The inventory that changed.
    /// </summary>
    public required Inventory.Inventory Inventory { get; init; }
    
    /// <summary>
    /// The slot that changed.
    /// </summary>
    public required int Slot { get; set; }
    
    /// <summary>
    /// The contents of the slot before the change.
    /// </summary>
    public required ItemStack PreviousItem { get; set; }
    
    /// <summary>
    /// The contents of the slot after the change.
    /// </summary>
    public required ItemStack NewItem { get; set; }
}
