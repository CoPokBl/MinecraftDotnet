using Minecraft.Implementations.Server.Connections;
using Minecraft.Packets;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Text;

namespace ManagedServer.Login;

public abstract class LoginStepBase : ILoginStep {
    
    public virtual void HandleLoginPacket(PlayerConnection connection, ServerBoundPacket packet) {
        
    }

    public virtual void Process(PlayerConnection connection) {
        
    }

    public virtual bool IsLoggedIn(PlayerConnection connection) {
        return true;  // By default assume the player is logged in (aka. passed this step)
    }
    
    protected static void Kick(PlayerConnection connection, TextComponent reason) {
        connection.SendPacket(new ClientBoundLoginDisconnectPacket {
            Reason = reason
        });
    }
}
