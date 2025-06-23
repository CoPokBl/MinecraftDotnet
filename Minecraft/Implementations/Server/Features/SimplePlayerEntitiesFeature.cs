using Minecraft.Implementations.Server.Managed.Entities.Types;

namespace Minecraft.Implementations.Server.Features;

public class SimplePlayerEntitiesFeature : IServerFeature {
    public List<PlayerEntity> Players = [];
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
            PlayerEntity entity = new(e.Connection, PlayerInfoFeature.GetInfo(e.Connection).Username ?? "BobTheUnnamed");
            SimpleEntitiesFeature entities = server.Feature<SimpleEntitiesFeature>()!;
            entities.Spawn(entity);
            Players.Add(entity);

            e.Connection.Disconnected += () => {
                Players.Remove(entity);
                entities.Despawn(entity);
            };
        });
    }
    
    public void Unregister() {
        
    }

    public Type[] GetDependencies() {
        return [typeof(SimpleEntitiesFeature)];
    }
}