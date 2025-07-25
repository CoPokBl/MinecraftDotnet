using Minecraft.Implementations.Server.Events;

namespace ManagedServer.Events.Types;

/// <summary>
/// An event that occurred in the context of a specific inventory.
/// </summary>
public interface IInventoryEvent : IServerEvent {
    /// <summary>
    /// The inventory that the event is related to.
    /// </summary>
    public Inventory.Inventory Inventory { get; init; }
}
