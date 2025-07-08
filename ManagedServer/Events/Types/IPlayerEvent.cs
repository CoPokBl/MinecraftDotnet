using ManagedServer.Entities.Types;

namespace ManagedServer.Events.Types;

public interface IPlayerEvent : IEntityEvent {
    public PlayerEntity Player { get; init; }
}
