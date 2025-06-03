using Minecraft.Implementations.Server.Worlds;

namespace Minecraft.Implementations.Server.Features;

public class SpawnWorldFeature(World world) : IFeature {
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
            Console.WriteLine("PLAYER LOGGED IN, ADDING TO WORLD");
            world.AddPlayer(e.Connection);
        });
    }

    public Type[] GetDependencies() {
        return [typeof(PlayerLoginFeature)];
    }
}