using Minecraft;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;

namespace ManagedServer.Login;

public abstract class LoginPluginStep : LoginStepBase {
    protected abstract string Channel { get; }
    private Tag<bool> LoggedInTag => new("managedserver:loginstep:loginplugin:logged_in:" + Channel);
    private Tag<int> RequestIdTag => new("managedserver:loginstep:loginplugin:requestid:" + Channel);
    
    protected abstract byte[] GetRequestData(PlayerConnection connection);
    protected abstract void HandleResponseData(PlayerConnection connection, byte[]? data);
    
    public override void HandleLoginPacket(PlayerConnection connection, ServerBoundPacket packet) {
        if (packet is not ServerBoundLoginPluginResponsePacket response) {
            return;
        }

        if (response.MessageId != connection.GetTagOrDefault(RequestIdTag, -1)) {
            return;  // Ignore responses that do not match the request ID
        }

        HandleResponseData(connection, response.Data);
        connection.SetTag(LoggedInTag, true);  // If the check fails then the handler can kick them
    }

    public override void Process(PlayerConnection connection) {
        int messageId = Random.Shared.Next(99999);
        
        connection.SetTag(RequestIdTag, messageId);
        
        connection.SendPacket(new ClientBoundLoginPluginRequestPacket {
            Channel = Channel,
            Data = GetRequestData(connection),
            MessageId = messageId
        });
    }

    public override bool IsLoggedIn(PlayerConnection connection) {
        return connection.GetTagOrDefault(LoggedInTag, false);
    }
}
