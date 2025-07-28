using Minecraft.Implementations.Client.Events;

namespace ClientLib.Events;

public class JoinEvent : IClientEvent {
    public required ClientWorld World { get; init; }
}
