using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Registry;

namespace ManagedServer;

public class ManagedMinecraftServer : MinecraftServer {
    public MinecraftRegistry Registry = VanillaRegistry.Data;
    
    public readonly List<World> Worlds = [];
    public readonly List<PlayerEntity> Players = [];
    
    // Configurable stuff
    public int ViewDistance = 8;
    public int PacketsPerTick = 64;
    public int TickDelayMs = 50;

    public ManagedMinecraftServer(params IServerFeature[] feats) {
        foreach (IServerFeature feat in feats) {
            AddFeature(feat);
        }
        
        // Add our features if they haven't been overriden
        RegisterFeatIfNotPresent(new PlayerInfoFeature());
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

    public World CreateWorld(ITerrainProvider provider) {
        World world = new(Events, provider, ViewDistance, PacketsPerTick, TickDelayMs) {
            Server = this
        };
        Worlds.Add(world);
        return world;
    }

    public Task ListenTcp(int port, CancellationToken cancel) {
        TcpMinecraftListener listener = new(AddConnection, cancel);
        return listener.Listen(port);
    }
}
