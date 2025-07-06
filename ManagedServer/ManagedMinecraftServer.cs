using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Registry;

namespace ManagedServer;

public class ManagedMinecraftServer : MinecraftServer, IViewable, IAudience {
    public MinecraftRegistry Registry = VanillaRegistry.Data;  // TODO: use this
    
    public readonly List<World> Worlds = [];
    public readonly List<PlayerEntity> Players = [];
    
    private readonly List<Timer> _timers = [];
    
    // Configurable stuff
    public int ViewDistance = 8;
    public int PacketsPerTick = 3000;
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
    
    public void ScheduleTask(TimeSpan delay, Action action) {
        Timer timer = null!;
        timer = new Timer(_ => {
            action();
            // ReSharper disable once AccessToModifiedClosure
            _timers.Remove(timer);
        }, null, delay, Timeout.InfiniteTimeSpan);
        _timers.Add(timer);
    }

    public Task ListenTcp(int port, CancellationToken cancel) {
        TcpMinecraftListener listener = new(AddConnection, cancel);
        return listener.Listen(port);
    }

    public PlayerEntity[] GetViewers() {
        return Players.ToArray();
    }

    public void SendPacket(MinecraftPacket packet) {
        foreach (PlayerEntity player in Players) {
            player.SendPacket(packet);
        }
    }
}
