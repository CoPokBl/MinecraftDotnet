using ManagedServer.Entities.Types;

namespace ManagedServer.Events.Types;

public interface IEntityEvent : IWorldEvent {
    public Entity Entity { get; init; }
}
