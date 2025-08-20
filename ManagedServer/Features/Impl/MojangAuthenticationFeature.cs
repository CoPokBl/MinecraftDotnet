using ManagedServer.Events;
using ManagedServer.Login.Impl;
using Minecraft;
using Minecraft.Implementations.Client;
using Minecraft.Schemas;

namespace ManagedServer.Features.Impl;

public class MojangAuthenticationFeature : ScopedFeature {
    
    public override void Register() {
        Scope.Server.LoginSteps.Add(new MojangAuthenticationStep(Scope.Server));
        
        AddEventHandler<PlayerLoginEvent>(e => {
            MinecraftClientUtils.JoinedUserResponse data = e.Player.Connection.GetTag(MojangAuthenticationStep.ProfileTag);

            ProfileProperty? skinProp = data.Properties.FirstOrDefault(p => p.Name == "textures");
            if (skinProp == null) {
                return;
            }
            
            e.Player.Skin = new PlayerSkin(skinProp.Value, skinProp.Signature.ThrowIfNull());
        });
    }
}
