using System.Reflection;
using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Registry;

namespace ManagedServer;

public partial class ManagedMinecraftServer : MinecraftServer, IViewable, IAudience, IFeatureScope {
    public MinecraftRegistry Registry = VanillaRegistry.Data;  // TODO: use this
    
    public List<World> Worlds { get; } = [];
    public List<PlayerEntity> Players { get; } = [];
    public ManagedMinecraftServer Server => this;
    public HashSet<Type> CallableEventTypes { get; } = [];

    // Used to stop the tasks from being garbage collected
    // ReSharper disable once CollectionNeverQueried.Local
    private readonly List<Timer> _timers = [];
    
    // Configurable stuff
    public int ViewDistance = 8;
    public int WorldPacketsPerTick = 3000;
    public int WorldTickDelayMs = 50;
    public bool AllowListeningToUnCalledEvents = false;

    public ManagedMinecraftServer(params IServerFeature[] feats) {
        foreach (IServerFeature feat in feats) {
            AddFeature(feat);
        }
        
        // Add our features if they haven't been overriden
        RegisterFeatIfNotPresent(new PlayerInfoFeature());
        RegisterFeatIfNotPresent(new HeartbeatsFeature(3000));
        RegisterFeatIfNotPresent(new LoginProcedureFeature());

        Events.OnListenerAdded += type => {
            if (AllowListeningToUnCalledEvents) {
                return;
            }
            
            NotCalledByDefaultAttribute? attribute = type.GetCustomAttribute<NotCalledByDefaultAttribute>();
            if (attribute == null) {
                return;
            }
            
            // it's not called by default, so let's make sure that it gets called
            if (CallableEventTypes.Contains(type)) return;
            
            // TODO: Make it a warning and make it work for child event nodes
            throw new Exception("Event " + type.FullName +
                                " is not called by default, but you are trying to add a listener for it. If it is called" +
                                " then please add the [CallsEvent()] attribute to the feature calling it or" +
                                " add it to the CallableEventTypes property in the ManagedMinecraftServer object.");
        };
    }

    protected void RegisterFeatIfNotPresent(IServerFeature feat) {
        if (Feature(feat.GetType()) == null) {
            AddFeature(feat);
        }
        else {
            Console.WriteLine("WARNING: Overwritten feature");
        }
    }
    
    public void AddFeature(ScopedFeature feature) {
        feature.Scope = this;
        feature.Register();
        
        CallsEventAttribute? callsEventAttribute = feature.GetType().GetCustomAttribute<CallsEventAttribute>();
        if (callsEventAttribute == null) return;
        lock (CallableEventTypes) foreach (Type eventType in callsEventAttribute.EventTypes) {
            CallableEventTypes.Add(eventType);
        }
    }

    public void AddFeatures(params ScopedFeature[] features) {
        foreach (ScopedFeature feat in features) {
            AddFeature(feat);
        }
    }

    public World CreateWorld(ITerrainProvider provider) {
        World world = new(Events, provider, ViewDistance, WorldPacketsPerTick, WorldTickDelayMs) {
            Server = this
        };
        Worlds.Add(world);
        return world;
    }
    
    public Action ScheduleTask(TimeSpan delay, Action action) {
        Timer timer = null!;
        timer = new Timer(_ => {
            action();
            // ReSharper disable once AccessToModifiedClosure
            _timers.Remove(timer);
        }, null, delay, Timeout.InfiniteTimeSpan);
        _timers.Add(timer);

        return () => {
            timer.Dispose();
            _timers.Remove(timer);
        };
    }

    // return true to continue repeating, false to stop
    public Action ScheduleRepeatingTask(TimeSpan delay, Func<bool> action) {
        Timer timer = null!;
        timer = new Timer(_ => {
            if (action()) return;
            _timers.Remove(timer);
            timer.Dispose();
        }, null, delay, delay);
        _timers.Add(timer);
        
        return () => {
            timer.Dispose();
            _timers.Remove(timer);
        };
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
