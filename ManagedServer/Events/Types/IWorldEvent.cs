using ManagedServer.Worlds;
using Minecraft.Implementations.Server.Events;

namespace ManagedServer.Events.Types;

/// <summary>
/// An event that occured in a specific world.
/// </summary>
public interface IWorldEvent : IServerEvent {
    /// <summary>
    /// The world in which the event occurred.
    /// </summary>
    public World World { get; init; }
}
