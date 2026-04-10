using ManagedServer.Events.Types;
using ManagedServer.Inventories;

namespace ManagedServer.Events;

public class InventoryClearEvent : IInventoryEvent
{
    public required Inventory Inventory { get; init; }
}
