using Minecraft;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Schemas;

namespace ManagedServer.Login;

public abstract class CookieValidationStep : LoginStepBase {
    protected abstract Identifier CookieId { get; }
    private Tag<bool> LoggedInTag => new("managedserver:loginstep:cookievalidation:logged_in:" + CookieId);
    
    protected abstract void ValidateCookieValue(PlayerConnection connection, byte[]? data);
    
    public override void HandleLoginPacket(PlayerConnection connection, ServerBoundPacket packet) {
        if (packet is not ServerBoundCookieResponsePacket response) {
            return;
        }

        if (response.Key != CookieId) {
            return;  // Ignore responses for different cookies
        }

        ValidateCookieValue(connection, response.Data);
        connection.SetTag(LoggedInTag, true);  // If the check fails then the handler can kick them
    }

    public override void Process(PlayerConnection connection) {
        connection.SendPacket(new ClientBoundCookieRequestPacket {
            Key = CookieId
        });
    }

    public override bool IsLoggedIn(PlayerConnection connection) {
        return connection.GetTagOrDefault(LoggedInTag, false);
    }
}
