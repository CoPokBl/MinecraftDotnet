using Minecraft.Implementations.Client.Events;

namespace ClientLib.Events;

// called after the client acknowledges the login packet
public class LoginEvent : IClientEvent {
    public required GameProfile Profile { get; init; }
}
