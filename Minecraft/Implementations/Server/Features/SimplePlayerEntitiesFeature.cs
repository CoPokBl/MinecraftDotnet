using Minecraft.Implementations.Server.Entities;

namespace Minecraft.Implementations.Server.Features;

public class SimplePlayerEntitiesFeature : IFeature {
    public List<PlayerEntity> Players = [];
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
            Console.WriteLine("SPAWNING PLAYER");
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

    public Type[] GetDependencies() {
        return [typeof(SimpleEntitiesFeature)];
    }
}