using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Registry;

namespace ManagedServer;

public partial class ManagedMinecraftServer : MinecraftServer, IViewable, IAudience, IFeatureScope {
    public MinecraftRegistry Registry = VanillaRegistry.Data;
    public readonly Dictionary<string, Dimension> Dimensions = new() {
        { "minecraft:overworld", new Dimension() }
    };
    
    public List<World> Worlds { get; } = [];
    public List<PlayerEntity> Players { get; } = [];
    public ManagedMinecraftServer Server => this;
    public FeatureHandler FeatureHandler { get; }

    // Used to stop the tasks from being garbage collected
    // ReSharper disable once CollectionNeverQueried.Local
    private readonly List<Timer> _timers = [];
    
    // Configurable stuff
    public int ViewDistance = 8;
    public int WorldPacketsPerTick = 3000;
    public int WorldTickDelayMs = 50;
    public bool AllowListeningToUnCalledEvents = false;

    public ManagedMinecraftServer(params IServerFeature[] feats) {
        FeatureHandler = new FeatureHandler(this);
        
        foreach (IServerFeature feat in feats) {
            AddFeature(feat);
        }
        
        // Add our features if they haven't been overriden
        RegisterFeatIfNotPresent(new PlayerInfoFeature());
        RegisterFeatIfNotPresent(new HeartbeatsFeature(3000));

        Events.OnListenerAdded += type => {
            if (AllowListeningToUnCalledEvents) {
                return;
            }
            
            NotCalledByDefaultAttribute? attribute = type.GetCustomAttribute<NotCalledByDefaultAttribute>();
            if (attribute == null) {
                return;
            }
            
            // it's not called by default, so let's make sure that it gets called
            if (FeatureHandler.CallableEventTypes.Contains(type)) return;
            
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

    public World CreateWorld(ITerrainProvider provider, string dimension = "minecraft:overworld") {
        if (!Dimensions.ContainsKey(dimension)) {
            throw new ArgumentException($"Dimension '{dimension}' does not exist. Please add it to the Dimensions dictionary.");
        }
        World world = new(Events, provider, dimension, ViewDistance, WorldPacketsPerTick, WorldTickDelayMs) {
            Server = this
        };
        Worlds.Add(world);
        return world;
    }
    
    /// <summary>
    /// Schedule a task to run after <paramref name="delay"/>.
    /// </summary>
    /// <param name="delay">The delay before this task is executed.</param>
    /// <param name="action">The task to execute after the delay.</param>
    /// <returns>
    /// An action that cancels task. If the returned action is invoked, then the task will not be executed.
    /// </returns>
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
    
    /// <summary>
    /// Schedule a task that repeats every <paramref name="delay"/> until
    /// the provided function returns false.
    /// </summary>
    /// <param name="delay">The time between each execution of the method.</param>
    /// <param name="action">
    /// The method to execute every <paramref name="delay"/>,
    /// it should return true to continue running or false to stop repeating.</param>
    /// <returns>An action that can be used</returns>
    public Action ScheduleRepeatingTask(TimeSpan delay, Func<bool> action) {
        Timer timer = null!;

        // timer is supposed to be modified in the outer scope. that's the point.
        [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
        void Stop() {
            timer.Dispose();
            _timers.Remove(timer);
        }

        timer = new Timer(_ => {
            if (action()) return;
            Stop();
        }, null, delay, delay);
        _timers.Add(timer);

        return Stop;
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

    public override void AddConnection(PlayerConnection connection) {
        connection.Registry = Registry;
        Connections.Add(connection);
        connection.Disconnected += () => Connections.Remove(connection);
    }
}
