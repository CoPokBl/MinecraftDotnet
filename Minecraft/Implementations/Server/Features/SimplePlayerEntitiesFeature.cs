using Minecraft.Implementations.Server.Entities;

namespace Minecraft.Implementations.Server.Features;

public class SimplePlayerEntitiesFeature : IFeature {
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
            Console.WriteLine("SPAWNING PLAYER");
            PlayerEntity entity = new(e.Connection, PlayerInfoFeature.GetInfo(e.Connection).Username ?? "BobTheUnnamed");
            server.Feature<SimpleEntitiesFeature>()!.Spawn(entity);
        });
    }

    public Type[] GetDependencies() {
        return [typeof(SimpleEntitiesFeature)];
    }
}