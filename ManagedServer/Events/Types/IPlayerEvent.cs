using ManagedServer.Entities.Types;

namespace ManagedServer.Events.Types;

/// <summary>
/// An event that occurred in the context of a specific player.
/// </summary>
public interface IPlayerEvent : IEntityEvent {
    /// <summary>
    /// The player that the event is related to.
    /// </summary>
    public PlayerEntity Player { get; init; }
}
