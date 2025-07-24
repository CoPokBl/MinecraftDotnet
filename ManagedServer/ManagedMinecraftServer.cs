using System.Diagnostics;
using System.Reflection;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Scheduling;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Registry;

namespace ManagedServer;

public partial class ManagedMinecraftServer : MinecraftServer, IViewable, IAudience, IFeatureScope {
    public List<World> Worlds { get; } = [];
    public List<PlayerEntity> Players { get; } = [];
    public ManagedMinecraftServer Server => this;
    public FeatureHandler FeatureHandler { get; }
    public ServerScheduler Scheduler { get; }
    public ulong CurrentTick { get; private set; } = 0;
    
    private Thread _ticker = null!;
    private bool _started;
    private readonly CancellationTokenSource _cts = new();
    
    // Configurable stuff
    public int ViewDistance = 8;
    public int WorldPacketsPerTick = 3000;
    public int WorldTickDelayMs = 50;
    public bool AllowListeningToUnCalledEvents = false;
    public int TargetTicksPerSecond = 20;
    public readonly Dictionary<string, Dimension> Dimensions = new() {
        { "minecraft:overworld", new Dimension() }
    };
    public MinecraftRegistry Registry = VanillaRegistry.Data;
    
    private TimeSpan TargetTickTime => TimeSpan.FromSeconds(1.0 / TargetTicksPerSecond);

    public ManagedMinecraftServer(params IServerFeature[] feats) {
        FeatureHandler = new FeatureHandler(this);
        Scheduler = new ServerScheduler(this);
        
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

    public void Start() {
        _ticker = new Thread(Ticker) {
            Name = "ManagedMinecraftServer Ticker",
            IsBackground = false
        };
        _ticker.Start();
        _started = true;
    }

    public void WaitForExit() {
        if (!_started) {
            throw new InvalidOperationException("Server has not been started. Call Start() before WaitForExit().");
        }
        if (_cts.IsCancellationRequested) {
            return;
        }
        _ticker.Join();
    }

    public void Stop() {
        _cts.Cancel();
    }

    private void Ticker() {
        Stopwatch tickTimer = Stopwatch.StartNew();
        TimeSpan elapsed = TimeSpan.Zero;  // the amount of time that is supposed to have passed since the start of the tick
        TimeSpan tickTime = TimeSpan.Zero;
        while (!_cts.IsCancellationRequested) {
            TimeSpan tickStart = tickTimer.Elapsed;
            ServerTickEvent tickEvent = new() {
                Delta = tickTime,
                TargetDelta = TargetTickTime,
                Server = this
            };
            Exception? exception = Events.CallEventCatchErrors(tickEvent);
            if (exception != null) {
                HandleError(exception);
            }
            TimeSpan realTickDuration = tickTimer.Elapsed - tickStart;
            
            tickTime = tickTimer.Elapsed - elapsed;
            
            elapsed += TargetTickTime;
            if (tickTime < TargetTickTime) {
                // Sleep for the remaining time to maintain the target tick rate
                Thread.Sleep(TargetTickTime - tickTime);
            }
            else {
                // If we took too long, log a warning
                Console.WriteLine($"WARNING: Tick took {realTickDuration.TotalMilliseconds}ms, exceeding target of {TargetTickTime.TotalMilliseconds}ms." +
                                  $"Running behind by {elapsed - tickTimer.Elapsed - TargetTickTime}");
            }
            
            CurrentTick++;
        }
    }

    public void HandleError(Exception exception) {
        Console.WriteLine("An error occurred in the server:");
        Console.WriteLine(exception);
    }

    public World CreateWorld(ITerrainProvider provider, string dimension = "minecraft:overworld") {
        if (!Dimensions.ContainsKey(dimension)) {
            throw new ArgumentException($"Dimension '{dimension}' does not exist. Please add it to the Dimensions dictionary.");
        }
        World world = new(this, Events, provider, dimension, ViewDistance, WorldPacketsPerTick, WorldTickDelayMs) {
            Server = this
        };
        Worlds.Add(world);
        return world;
    }

    public Task ListenTcp(int port, CancellationToken cancel) {
        if (!_started) {
            throw new InvalidOperationException("Server has not been started. Call Start() before ListenTcp().");
        }
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
        Events.AddChild<IPacketEvent>(connection.Events, pe => pe.Connection == connection);
        connection.Disconnected += () => Connections.Remove(connection);
    }
}
