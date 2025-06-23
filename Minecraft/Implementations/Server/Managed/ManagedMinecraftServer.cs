using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Managed.Entities.Types;
using Minecraft.Implementations.Server.Worlds;

namespace Minecraft.Implementations.Server.Managed;

public class ManagedMinecraftServer : MinecraftServer {
    public List<World> Worlds = [];
    public List<PlayerEntity> Players = [];

    public ManagedMinecraftServer(params IServerFeature[] feats) {
        foreach (IServerFeature feat in feats) {
            AddFeature(feat);
        }
        
        // Add our features if they haven't been overriden
        RegisterFeatIfNotPresent(new PlayerInfoFeature());
        // RegisterFeatIfNotPresent(new PlayerLoginFeature());
        RegisterFeatIfNotPresent(new HeartbeatsFeature(3000));
        RegisterFeatIfNotPresent(new LoginProcedureFeature());
    }

    protected void RegisterFeatIfNotPresent(IServerFeature feat) {
        if (Feature(feat.GetType()) == null) {
            AddFeature(feat);
        }
        else {
            Console.WriteLine("WARNING: Overwritten feature");
        }
    }

    public void AddWorld(World world) {
        Worlds.Add(world);
    }

    public Task ListenTcp(int port, CancellationToken cancel) {
        TcpMinecraftListener listener = new(AddConnection, cancel);
        return listener.Listen(port);
    }
}