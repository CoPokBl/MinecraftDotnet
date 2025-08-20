using ManagedServer.Login;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Schemas;

namespace TestServer.Servers.Transferer;

public class HappyCookieLoginStep : CookieValidationStep {
    protected override Identifier CookieId => "happy:happy";
    
    protected override void ValidateCookieValue(PlayerConnection connection, byte[]? data) {
        if (data == null) {
            Kick(connection, "You aren't happy. Leave.");
        }
    }
}
