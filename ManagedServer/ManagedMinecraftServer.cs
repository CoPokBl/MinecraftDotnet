using System.Diagnostics;
using System.Reflection;
using ManagedServer.Commands;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Features;
using ManagedServer.Login;
using ManagedServer.Scheduling;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Registry;

namespace ManagedServer;

// TODO: Remove MinecraftServer inheritance
public partial class ManagedMinecraftServer : MinecraftServer, IViewable, IAudience, IFeatureScope {
    public List<World> Worlds { get; } = [];
    public List<PlayerEntity> Players { get; } = [];
    public ManagedMinecraftServer Server => this;
    public FeatureHandler FeatureHandler { get; }
    public ServerScheduler Scheduler { get; }
    public ulong CurrentTick { get; private set; }
    public string ServerId { get; set; } = Random.Shared.Next(int.MaxValue).ToString();  // must be <=20 chars
    
    /// <summary>
    /// Lists of steps that must be completed before a player can log in.
    /// <b>These do nothing by default without features.</b>
    /// Please add <see cref="ManagedServer.Features.Basic.LoginProcedureFeature"/>
    /// or implement your own logic to handle these steps.
    /// The above-mentioned feature is available in the
    /// <see cref="BasicsBundle"/>.
    /// </summary>
    public List<ILoginStep> LoginSteps { get; } = [];
    
    private Thread _ticker = null!;
    private bool _started;
    private readonly CancellationTokenSource _cts = new();
    
    // Configurable stuff
    public List<Command> Commands { get; set; } = [];
    public int ViewDistance { get; set; } = 8;
    public int WorldPacketsPerTick { get; set; } = 3000;
    public int WorldTickDelayMs { get; set; } = 50;
    public bool AllowListeningToUnCalledEvents { get; set; } = false;
    public int TargetTicksPerSecond { get; set; } = 20;
    public Dictionary<string, Dimension> Dimensions { get; } = new() {
        { "minecraft:overworld", new Dimension() },
        { "minecraft:dummy_world", new Dimension() }  // Dummy world for respawning players
    };
    public MinecraftRegistry Registry { get; set; } = VanillaRegistry.Data;
    public Action<string> LogAction { get; set; } = Console.WriteLine;
    public event Action? ServerStopped;
    
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
            LogAction("WARNING: Overwritten feature");
        }
    }

    public void Start() {
        if (_cts.IsCancellationRequested) {
            throw new InvalidOperationException("Server has already been started and stopped. Create a new instance to start again.");
        }
        
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
    
    public Task WaitForExitAsync(CancellationToken cancellationToken = default) {
        if (!_started) {
            throw new InvalidOperationException("Server has not been started. Call Start() before WaitForExitAsync().");
        }
        if (_cts.IsCancellationRequested) {
            return Task.CompletedTask;
        }
        
        return Task.Run(() => _ticker.Join(), cancellationToken);
    }

    public void Stop() {
        _cts.Cancel();

        foreach (ScopedFeature feat in FeatureHandler.Features) {
            feat.Unregister();
        }
        foreach (IServerFeature feat in Features) {
            feat.Unregister();
        }
        
        // TODO: Unregister other scope features (e.g. entities, worlds)
        
        ServerStopped?.Invoke();
        LogAction("Server stopped.");
    }
    
    public void StopAfterCancellation(CancellationToken token) {
        token.Register(() => {
            LogAction("Cancellation requested from dependent token, stopping server...");
            Stop();
        });
    }

    public void StopAfter(Task task) {
        task.ContinueWith(_ => {
            Stop();
        });
    }

    private void Ticker() {
        Stopwatch tickTimer = new();
        TimeSpan lastTickTime = TimeSpan.Zero;
        while (!_cts.IsCancellationRequested) {
            tickTimer.Restart();
            ServerTickEvent tickEvent = new() {
                Delta = lastTickTime,
                TargetDelta = TargetTickTime,
                Server = this
            };
            Exception? exception = Events.CallEventCatchErrors(tickEvent);
            if (exception != null) {
                HandleError(exception);
            }
            TimeSpan tickTime = tickTimer.Elapsed;
            lastTickTime = tickTime;
            
            if (tickTime < TargetTickTime) {
                // Sleep for the remaining time to maintain the target tick rate
                Thread.Sleep(TargetTickTime - tickTime);
            }
            else {
                // If we took too long, log a warning
                LogAction($"WARNING: Tick took {tickTime.TotalMilliseconds}ms, " + 
                          $"exceeding target of {TargetTickTime.TotalMilliseconds}ms.");
            }
            
            CurrentTick++;
        }
    }

    public void HandleError(Exception? exception) {
        if (exception == null) {
            return;
        }
        
        LogAction("An error occurred in the server:");
        LogAction(exception.ToString());
    }

    public World CreateWorld(ITerrainProvider provider, string dimension = "minecraft:overworld", ILightingProvider? lightingProvider = null) {
        if (!Dimensions.ContainsKey(dimension)) {
            throw new ArgumentException($"Dimension '{dimension}' does not exist. Please add it to the Dimensions dictionary.");
        }
        World world = new(this, Events, provider, dimension, lightingProvider, ViewDistance, 
            WorldPacketsPerTick, WorldTickDelayMs) {
            Server = this
        };
        Worlds.Add(world);
        return world;
    }

    public Task ListenTcp(int port, CancellationToken? cancel = null) {
        if (!_started) {
            throw new InvalidOperationException("Server has not been started. Call Start() before ListenTcp().");
        }
        TcpMinecraftListener listener = new(AddConnection, cancel ?? _cts.Token);
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
        if (!_started) {
            throw new InvalidOperationException("Server has not been started. Call Start() before adding connections.");
        }
        connection.Registry = Registry;
        Connections.Add(connection);
        Events.AddChild<IPacketEvent>(connection.Events, pe => pe.Connection == connection);
        connection.Disconnected += () => Connections.Remove(connection);
    }
}
