using Minecraft.Implementations.Server.Managed.Entities;

namespace Minecraft.Implementations.Server.Features;

public class SimpleEntitiesFeature(int viewDistanceBlocks = 16*8) : EntityManager(null!, viewDistanceBlocks), IServerFeature {
    
    public void Register(MinecraftServer server) {
        BaseEventNode = server.Events;
        server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
            _ = InformNewPlayer(e.Connection);
        });
    }
    
    public void Unregister() {
        
    }

    public Type[] GetDependencies() {
        return [];
    }
}