using Minecraft.Implementations.Server.Events;

namespace ManagedServer.Events;

public class ServerTickEvent : IServerEvent {
    /// <summary>
    /// The time the previous tick took to complete.
    /// </summary>
    public required TimeSpan Delta { get; init; }
    public required TimeSpan TargetDelta { get; init; }
    public required ManagedMinecraftServer Server { get; init; }
}
