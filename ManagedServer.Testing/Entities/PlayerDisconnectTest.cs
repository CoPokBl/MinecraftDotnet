using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Entities;

/// <summary>
/// Leaving is noticed by whichever thread happens to touch the socket first, and that is very often
/// not the network thread. A broadcast on the tick thread writes to every viewer of an entity, and
/// the write to somebody who has already gone is where the server finds out.
/// <p/>
/// So a disconnect is a piece of teardown reached re-entrantly, from the middle of an unrelated
/// entity's tick, possibly at the same moment as the read loop reaching it too. The invariant these
/// pin is that it happens exactly once and completely: the second pass has no manager and no world to
/// work with, and the first crash on that path took the rest of the teardown with it and left the
/// player in the world's list being sent packets forever.
/// </summary>
[TestFixture]
public class PlayerDisconnectTest {
    /// <summary>
    /// A connection whose socket can be killed. Once dead, a write tears the connection down from
    /// inside the send, which is exactly what <c>TcpPlayerConnection.SendPacketInternal</c> does when
    /// <c>Stream.Write</c> throws.
    /// <p/>
    /// <see cref="Disconnect"/> deliberately does not guard itself, so what is being measured is the
    /// guarantee in <c>MinecraftConnection.InvokeDisconnected</c> rather than one in the fixture.
    /// </summary>
    private sealed class KillableConnection : PlayerConnection {
        public readonly List<MinecraftPacket> Sent = [];
        public volatile bool Dead;

        protected override void SendPacketInternal(MinecraftPacket packet) {
            if (Dead) {
                Disconnect();
                return;
            }

            lock (Sent) Sent.Add(packet);
        }

        public override void InitialiseEncryption() { }
        public override Task HandlePackets() => Task.CompletedTask;
        public override void Disconnect() => InvokeDisconnected();
    }

    private ManagedMinecraftServer _server = null!;
    private World _world = null!;
    private Player _player = null!;
    private KillableConnection _connection = null!;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { };
        _world = _server.CreateWorld(new VoidProvider(), "minecraft:overworld", new FullBrightLightingProvider());
        _world.LoadChunk(new Vec2<int>(0, 0)).Wait();

        _connection = new KillableConnection();
        _player = new Player(_server, _connection, "tester") {
            Position = new Vec3<double>(8.5, 64, 8.5)
        };
        _player.SetWorld(_world);
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    /// <summary>Something else in the world, close enough that the player is one of its viewers.</summary>
    private Entity SpawnNeighbour() {
        Entity entity = new(EntityType.AcaciaBoat) {
            Position = new Vec3<double>(10.5, 64, 8.5)
        };
        entity.SetWorld(_world);
        return entity;
    }

    /// <summary>
    /// The reported crash, from the reported thread. An entity's tick broadcasts to its viewers, one
    /// of those viewers has gone, and the failed write runs the whole of that player's teardown before
    /// the broadcast has finished. The next packet the same broadcast tries reaches the dead socket
    /// again, and the second teardown used to be a null dereference on a manager the first one cleared.
    /// </summary>
    [Test]
    public void ABroadcastToADeadSocketTearsThePlayerDownOnce() {
        Entity neighbour = SpawnNeighbour();
        _connection.Dead = true;

        Assert.DoesNotThrow(() => neighbour.SendToViewers(
            new ClientBoundSetEntityVelocityPacket { EntityId = neighbour.NetId, Velocity = Vec3<double>.Zero },
            new ClientBoundSetEntityVelocityPacket { EntityId = neighbour.NetId, Velocity = Vec3<double>.Zero }));

        Assert.Multiple(() => {
            Assert.That(_player.Manager, Is.Null);
            Assert.That(_player.World, Is.Null);
            Assert.That(_world.Players, Does.Not.Contain(_player));
        });
    }

    /// <summary>
    /// The teardown is a chain of handlers registered by different owners, and it used to be one
    /// multicast delegate: the player's despawn throwing meant the world never let go of them, so the
    /// streaming loop kept building chunks for a socket that was gone.
    /// </summary>
    [Test]
    public void AFailedHandlerDoesNotStopTheRest() {
        bool ran = false;
        _connection.Disconnected += () => throw new InvalidOperationException("handler blew up");
        _connection.Disconnected += () => ran = true;

        Assert.Throws<AggregateException>(() => _connection.Disconnect());

        Assert.Multiple(() => {
            Assert.That(ran, Is.True);
            Assert.That(_world.Players, Does.Not.Contain(_player));
        });
    }

    /// <summary>
    /// Registration races the socket. A consumer subscribing from a login event is on the network
    /// thread while the connection may already be dead, and a handler quietly added to a list nothing
    /// will call again is how a lobby keeps a player in its queue after they have left.
    /// </summary>
    [Test]
    public void AHandlerAddedAfterTheDisconnectRunsImmediately() {
        _connection.Disconnect();

        bool ran = false;
        _connection.Disconnected += () => ran = true;

        Assert.Multiple(() => {
            Assert.That(ran, Is.True);
            Assert.That(_connection.IsDisconnected, Is.True);
        });
    }

    /// <summary>Two threads noticing the same dead socket still tear it down once.</summary>
    [Test]
    public void ConcurrentDisconnectsFireTheEventOnce() {
        int count = 0;
        _connection.Disconnected += () => Interlocked.Increment(ref count);

        Parallel.For(0, 16, _ => _connection.Disconnect());

        Assert.That(count, Is.EqualTo(1));
    }

    /// <summary>
    /// Despawning is reached from the teardown and from a consumer, and an entity that never made it
    /// into a world (a connection that died mid login) has no manager to despawn from.
    /// </summary>
    [Test]
    public void DespawningTwiceOrNeverSpawnedIsSafe() {
        Entity neighbour = SpawnNeighbour();

        Assert.DoesNotThrow(() => {
            neighbour.Despawn();
            neighbour.Despawn();
            new Entity(EntityType.AcaciaBoat).Despawn();
        });

        Assert.That(_world.Entities.GetEntity(neighbour.NetId), Is.Null);
    }

    /// <summary>
    /// The despawn packet goes to the clients that were actually shown the entity. Leaving them
    /// recorded as viewing a net id that no longer exists is silent until something is registered with
    /// an explicit id that collides, and then that entity simply never spawns for them.
    /// </summary>
    [Test]
    public void DespawningUntracksTheEntity() {
        Entity neighbour = SpawnNeighbour();
        lock (_connection.Sent) _connection.Sent.Clear();

        neighbour.Despawn();

        MinecraftPacket[] sent;
        lock (_connection.Sent) sent = _connection.Sent.ToArray();

        Assert.That(sent.OfType<ClientBoundRemoveEntitiesPacket>().Count(), Is.EqualTo(1));

        // Registered again under the same id: the player has to be told to spawn it, which only
        // happens if the first despawn took the id back out of their visible set.
        Entity replacement = new(EntityType.AcaciaBoat) {
            Position = new Vec3<double>(10.5, 64, 8.5)
        };
        _world.Spawn(replacement, neighbour.NetId);

        lock (_connection.Sent) sent = _connection.Sent.ToArray();
        Assert.That(sent.OfType<ClientBoundSpawnEntityPacket>().Count(), Is.EqualTo(1));
    }
}
