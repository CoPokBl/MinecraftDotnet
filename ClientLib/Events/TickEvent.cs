using Minecraft.Implementations.Client.Events;

namespace ClientLib.Events;

public class TickEvent : IClientEvent {
    /// <summary>
    /// The time the previous tick took to complete.
    /// </summary>
    public required TimeSpan Delta { get; init; }
    public required TimeSpan TargetDelta { get; init; }
}
