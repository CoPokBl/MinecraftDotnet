using ManagedServer.Entities.Types;

namespace ManagedServer.Events.Types;

/// <summary>
/// An event that occurred in the context of a specific entity.
/// </summary>
public interface IEntityEvent : IWorldEvent {
    /// <summary>
    /// The entity that the event is related to.
    /// </summary>
    public Entity Entity { get; init; }
}
