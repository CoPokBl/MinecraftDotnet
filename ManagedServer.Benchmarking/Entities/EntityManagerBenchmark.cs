using BenchmarkDotNet.Attributes;
using ManagedServer;
using ManagedServer.Entities;
using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Benchmarking.Entities;

public class EntityManagerBenchmark {
    private EntityManager _manager = null!;
    private Random _random = null!;
    
    private Vec3<double> RandomPos() => new(
        _random.Next(-1000, 1000), 
        _random.Next(0, 256), 
        _random.Next(-1000, 1000));
    
    [IterationSetup(Target = "EntityLookupSpeed")]
    public void SetupEntityLookupSpeed() {
        const int amount = 10_000;
        _random = new Random(123456);
        _manager = new EntityManager(new EventNode<IServerEvent>(), 16*16);
        for (int i = 0; i < amount; i++) {
            Entity entity = new(EntityType.AcaciaBoat) {
                Position = RandomPos()
            };
            _manager.Register(entity);
        }
    }
    
    private const int LookupIterations = 20_000;
    [Benchmark(OperationsPerInvoke = LookupIterations)]
    public void EntityLookupSpeed() {
        for (int i = 0; i < LookupIterations; i++) {
            _manager.GetNearbyEntities(RandomPos(), 64);
        }
    }

    private Entity[] _movers = null!;

    /// <summary>
    /// The broadcast every moving entity performs, several times a tick each: who can see this, and
    /// send them a packet. It is the hottest path in the class by a distance, and the one worth
    /// keeping an eye on, because the obvious implementation sweeps the chunk index over the whole
    /// view distance to find what is nearly always a handful of players.
    /// <p/>
    /// At this shape, 20 players and 500 mobs at a view distance of eight, the chunk sweep answered
    /// one broadcast in 5.68us and walking the player list answers it in 0.49us. Per tick over these
    /// 500 movers that is 2.8ms against 0.25ms, before any of them has moved more than once.
    /// </summary>
    [IterationSetup(Target = nameof(ViewerBroadcastSpeed))]
    public void SetupViewerBroadcast() {
        const int mobs = 500;
        const int players = 20;

        _random = new Random(123456);
        _manager = new EntityManager(new EventNode<IServerEvent>(), 8 * 16);

        for (int i = 0; i < players; i++) {
            NullConnection connection = new();
            Player player = new(new ManagedMinecraftServer(), connection, "bench" + i) {
                Position = RandomPos()
            };
            _manager.Register(player);
        }

        _movers = new Entity[mobs];
        for (int i = 0; i < mobs; i++) {
            _movers[i] = new Entity(EntityType.Zombie) {
                Position = RandomPos()
            };
            _manager.Register(_movers[i]);
        }
    }

    [Benchmark(OperationsPerInvoke = 500)]
    public void ViewerBroadcastSpeed() {
        ClientBoundSetEntityVelocityPacket packet = new() {
            EntityId = 1,
            Velocity = Vec3<double>.Zero
        };

        foreach (Entity mover in _movers) {
            _manager.SendPacketsToViewers(mover, packet);
        }
    }

    /// <summary>A player whose packets go nowhere, so the measurement is the lookup and not a socket.</summary>
    private sealed class NullConnection : PlayerConnection {
        protected override void SendPacketInternal(MinecraftPacket packet) { }
        public override void InitialiseEncryption() { }
        public override Task HandlePackets() => Task.CompletedTask;
        public override void Disconnect() { }
    }
}
