using ManagedServer.Features.Basic;
using Minecraft;
using Minecraft.Implementations.Client;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Text;

namespace ManagedServer.Login.Impl;

public class MojangAuthenticationStep(ManagedMinecraftServer server) : LoginStepBase {
    private static readonly Tag<bool> LoggedInTag = new("managedserver:loginstep:mojangauth:logged_in");
    public static readonly Tag<MinecraftClientUtils.JoinedUserResponse> ProfileTag = new("managedserver:loginstep:mojangauth:profile");
    
    public override void HandleLoginPacket(PlayerConnection connection, ServerBoundPacket packet) {
        if (packet is not ServerBoundEncryptionResponsePacket) {
            return;
        }

        (Guid, string) info = connection.GetTag(LoginProcedureFeature.LoginInfoTag);
        try {
            Task<MinecraftClientUtils.JoinedUserResponse> task = MinecraftClientUtils.CheckClientAuthentication(
                info.Item2, 
                server.ServerId,
                connection.SharedSecret.ThrowIfNull(),
                connection.ServerPubKey.ThrowIfNull());

            task.Wait();
            
            connection.SetTag(LoggedInTag, true);
            connection.SetTag(ProfileTag, task.Result);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            Kick(connection, TextComponent.FromLegacyString("&cFailed to authenticate with Mojang."));
        }
    }

    public override bool IsLoggedIn(PlayerConnection connection) {
        return connection.GetTagOrDefault(LoggedInTag, false);
    }
}
