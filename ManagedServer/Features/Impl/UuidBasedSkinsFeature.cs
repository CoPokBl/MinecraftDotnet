using ManagedServer.Events;
using Minecraft.Implementations.Utils;

namespace ManagedServer.Features.Impl;

public class UuidBasedSkinsFeature : ScopedFeature {
    
    public override void Register() {
        AddEventHandler<PlayerLoginEvent>(e => {
            // Load skin asynchronously
            _ = SkinFetcher.GetPlayerSkin(e.Player.Uuid).ContinueWith(skin => {
                try {
                    e.Player.Skin = skin.Result;
                }
                catch (Exception exception) {
                    Scope.Server.HandleError(exception);
                }
            });
        });
    }
}
