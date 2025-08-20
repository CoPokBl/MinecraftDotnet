using Minecraft.Implementations.Server.Connections;
using Minecraft.Packets;

namespace ManagedServer.Login;

public interface ILoginStep {
    void HandleLoginPacket(PlayerConnection connection, ServerBoundPacket packet);
    
    /// <summary>
    /// Called to initiate the login step.
    /// </summary>
    /// <param name="connection">The connection of the player logging in.</param>
    void Process(PlayerConnection connection);
    
    /// <summary>
    /// Method that is called to check if the player is cleared to log in.
    /// This should return true once the player has passed this login step.
    /// </summary>
    /// <param name="connection">The connection of the player to check.</param>
    /// <returns>True if the player can log in, otherwise false.</returns>
    bool IsLoggedIn(PlayerConnection connection);
}
