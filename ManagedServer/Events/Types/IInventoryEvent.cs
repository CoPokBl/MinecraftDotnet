using Minecraft.Implementations.Server.Events;

namespace ManagedServer.Events.Types;

public interface IInventoryEvent : IServerEvent {
    public Inventory.Inventory Inventory { get; init; }
}
