using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Data.Blocks;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Worlds;

/// <summary>
/// A player who joins is owed every chunk around them, whatever else the server was doing while
/// they arrived.
/// </summary>
/// <remarks>
/// The failure this pins is a player stuck on "Loading terrain" until somebody else joins.
/// <c>World.AddPlayer</c> runs on the network thread, publishes the player into the world's snapshot
/// with no centre chunk yet, and only commits one at the very end of <c>HandlePlayerMove</c>. Chunk
/// deliveries land on the tick thread in between, find no centre, and were dropped for good: the
/// chunk's load task is already complete so nothing runs again, the player is not recorded as having
/// it, and a client on the loading screen cannot move to trigger a re-diff. The second player is
/// what unstuck it, because delivery walks every player in the world rather than the one that asked.
/// <para>
/// So the invariant is not "the fast path works", it is that a join which outlasts a tick still ends
/// with the client holding every chunk. The first test forces exactly that overlap.
/// </para>
/// </remarks>
[TestFixture]
public class ChunkStreamingJoinTest {
    private const int ViewDistance = 1;

    /// <summary>The player stands here, in chunk (0, 0).</summary>
    private static readonly Vec3<double> Spawn = new(8, 64, 8);

    /// <summary>
    /// Inside chunk (1, 1), which is the <em>last</em> chunk the viewport loop reaches. Holding the
    /// joining thread on this entity's spawn packet means every other chunk has already been
    /// dispatched for building, and the centre chunk has still not been committed.
    /// </summary>
    private static readonly Vec3<double> MarkerPos = new(24, 64, 24);

    /// <summary>
    /// Blocks the thread that is joining, once, on the first entity spawn packet it is asked to
    /// write. That is the only synchronous send inside the viewport loop, and it is a real socket
    /// write on the live path, so this is a delay the server can genuinely experience rather than a
    /// hook invented for the test.
    /// </summary>
    private sealed class GatingConnection : PlayerConnection {
        private readonly List<MinecraftPacket> _sent = [];
        private readonly ManualResetEventSlim _release = new(false);
        private int _gateUsed;

        public volatile bool Gated;

        public List<MinecraftPacket> Sent {
            get {
                lock (_sent) return [.._sent];
            }
        }

        public void Release() => _release.Set();

        protected override void SendPacketInternal(MinecraftPacket packet) {
            if (packet is ClientBoundSpawnEntityPacket && Interlocked.Exchange(ref _gateUsed, 1) == 0) {
                Gated = true;
                _release.Wait(TimeSpan.FromSeconds(30));
            }

            lock (_sent) _sent.Add(packet);
        }

        public override void InitialiseEncryption() { }

        public override Task HandlePackets() => Task.CompletedTask;

        public override void Disconnect() { }
    }

    /// <summary>
    /// Actually turns packets into bytes, the way a real connection does, so a chunk that tears
    /// while it is being written shows up here rather than being recorded intact.
    /// </summary>
    private sealed class SerialisingConnection : PlayerConnection {
        private int _serialised;

        public int Serialised => Volatile.Read(ref _serialised);

        protected override void SendPacketInternal(MinecraftPacket packet) {
            packet.Serialise(ConnectionState.Play, -1, Registry);
            Interlocked.Increment(ref _serialised);
        }

        public override void InitialiseEncryption() { }

        public override Task HandlePackets() => Task.CompletedTask;

        public override void Disconnect() { }
    }

    /// <summary>
    /// The whole viewport at <see cref="ViewDistance"/>, which is the nine around the player. All of
    /// them matter: the client will not leave its loading screen until the chunk it stands in has
    /// the neighbours it needs to build a mesh, so losing any one of the nine hangs it.
    /// </summary>
    private static Vec2<int>[] Viewport(Vec2<int> centre) {
        List<Vec2<int>> chunks = [];
        for (int dx = -ViewDistance; dx <= ViewDistance; dx++) {
            for (int dz = -ViewDistance; dz <= ViewDistance; dz++) {
                chunks.Add(new Vec2<int>(centre.X + dx, centre.Y + dz));
            }
        }
        return chunks.ToArray();
    }

    private static ManagedMinecraftServer NewServer() {
        ManagedMinecraftServer server = ManagedMinecraftServer.New();
        server.ViewDistance = ViewDistance;
        server.WorldTickDelayMs = 0;      // every tick flushes
        server.WorldPacketsPerTick = 100; // the nine fit in one flush
        server.TargetTicksPerSecond = 20;
        return server;
    }

    private static HashSet<Vec2<int>> ChunksSent(GatingConnection connection) {
        return connection.Sent
            .OfType<ClientBoundChunkDataAndUpdateLightPacket>()
            .Select(p => new Vec2<int>(p.ChunkX, p.ChunkZ))
            .ToHashSet();
    }

    private static void AssertViewportArrives(GatingConnection connection, Vec2<int> centre, string what) {
        Vec2<int>[] wanted = Viewport(centre);
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromSeconds(20);

        while (DateTime.UtcNow < deadline) {
            if (wanted.All(ChunksSent(connection).Contains)) return;
            Thread.Sleep(10);
        }

        HashSet<Vec2<int>> got = ChunksSent(connection);
        Vec2<int>[] missing = wanted.Where(c => !got.Contains(c)).ToArray();
        Assert.Fail($"{what}: the client never got {missing.Length} of {wanted.Length} chunks around " +
                    $"{centre}: {string.Join(", ", missing)}");
    }

    /// <summary>
    /// The join is made to straddle several ticks, which is what a real one does on a small map:
    /// the terrain answers instantly, so the load continuations run inline on the joining thread and
    /// the viewport loop does all of its lighting there before it ever commits a centre.
    /// </summary>
    [Test]
    public void EveryChunkArrivesWhenTheJoinOutlastsATick() {
        ManagedMinecraftServer server = NewServer();
        World world = server.CreateWorld(new VoidProvider(), "minecraft:overworld",
            new FullBrightLightingProvider());
        server.Start();

        try {
            // Loaded up front so the viewport loop takes its "already loaded" branch, which builds
            // off the tick and delivers through the scheduler. That is the path that lost chunks.
            Assert.That(world.LoadChunks(Viewport(new Vec2<int>(0, 0))).Wait(TimeSpan.FromSeconds(30)),
                Is.True, "the terrain never loaded");

            Entity marker = new(EntityType.Pig) { Position = MarkerPos };
            marker.SetWorld(world);

            GatingConnection connection = new();
            Player player = new(server, connection, "test") { Position = Spawn };

            // Let three ticks run while the joining thread is held, so the deliveries scheduled by
            // the already-dispatched builds are handed out against a player with no centre.
            int ticksWhileGated = 0;
            server.Events.AddListener<ServerTickEvent>(_ => {
                if (!connection.Gated) return;
                if (Interlocked.Increment(ref ticksWhileGated) >= 3) connection.Release();
            });

            world.AddPlayer(player);

            AssertViewportArrives(connection, new Vec2<int>(0, 0), "after a join that outlasted a tick");
        } finally {
            server.Stop();
        }
    }

    /// <summary>
    /// The shape of a minigame moving someone between worlds: <c>SetWorld</c> and then <c>Teleport</c>,
    /// back to back, off the tick thread. The destination viewport is what the player is owed, and
    /// the chunks queued around where they briefly were are not.
    /// </summary>
    [Test]
    public void EveryChunkArrivesAfterSetWorldThenTeleport() {
        ManagedMinecraftServer server = NewServer();
        World from = server.CreateWorld(new VoidProvider(), "minecraft:overworld",
            new FullBrightLightingProvider());
        World to = server.CreateWorld(new VoidProvider(), "minecraft:overworld",
            new FullBrightLightingProvider());
        server.Start();

        try {
            GatingConnection connection = new();
            Player player = new(server, connection, "test") { Position = Spawn };
            player.SetWorld(from);
            AssertViewportArrives(connection, new Vec2<int>(0, 0), "in the world joined first");

            Vec3<double> far = new(1000.5, 64, 1000.5);
            Vec2<int> farChunk = World.GetChunkPos(far);

            // Off the tick thread, which is where a start timer runs.
            Task.Run(() => {
                player.SetWorld(to);
                player.Teleport(far);
            }).Wait(TimeSpan.FromSeconds(30));

            AssertViewportArrives(connection, farChunk, "after a world change and a teleport");
        } finally {
            server.Stop();
        }
    }

    /// <summary>
    /// Serialising a chunk is not a read: it reaches the sections through the palette getter, which
    /// repacks them in place. So a chunk being written while it is being serialised used to corrupt
    /// the serialiser's state or null the array underneath it, and the throw was swallowed by the
    /// send loop, which silently discarded the rest of that player's batch.
    /// </summary>
    [Test]
    public void ConcurrentBlockWritesDoNotTearTheChunkPacket() {
        ManagedMinecraftServer server = NewServer();
        World world = server.CreateWorld(new VoidProvider(), "minecraft:overworld",
            new FullBrightLightingProvider());
        server.Start();

        try {
            Vec2<int> chunk = new(0, 0);
            Assert.That(world.LoadChunk(chunk).Wait(TimeSpan.FromSeconds(30)), Is.True);

            SerialisingConnection sink = new();
            Player reader = new(server, sink, "reader");

            using CancellationTokenSource cts = new();
            List<Exception> failures = [];

            Task writing = Task.Run(() => {
                Random rng = new(1);
                try {
                    while (!cts.IsCancellationRequested) {
                        world.SetBlock(new Vec3<int>(rng.Next(0, 16), rng.Next(0, 60), rng.Next(0, 16)),
                            rng.Next(2) == 0 ? Block.Stone : Block.Air);
                    }
                } catch (Exception e) {
                    lock (failures) failures.Add(e);
                }
            });

            Task[] reading = Enumerable.Range(0, 4).Select(_ => Task.Run(() => {
                try {
                    while (!cts.IsCancellationRequested) {
                        world.SendChunkUpdate(chunk, reader);
                    }
                } catch (Exception e) {
                    lock (failures) failures.Add(e);
                }
            })).ToArray();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            cts.Cancel();
            Task.WaitAll([writing, ..reading], TimeSpan.FromSeconds(30));

            lock (failures) {
                Assert.That(failures, Is.Empty,
                    failures.Count == 0 ? "" : $"serialising a chunk raced a block write: {failures[0]}");
            }

            Assert.That(sink.Serialised, Is.GreaterThan(0), "nothing was actually serialised");
        } finally {
            server.Stop();
        }
    }

    /// <summary>
    /// Streaming has to come to a stop. Every chunk load invalidates the light in the eight around
    /// it and queues those to be sent again, so a rule that re-queued too eagerly would keep the
    /// nine chunks bouncing off each other for ever.
    /// </summary>
    [Test]
    public void StreamingSettles() {
        ManagedMinecraftServer server = NewServer();
        World world = server.CreateWorld(new VoidProvider(), "minecraft:overworld",
            new FullBrightLightingProvider());
        server.Start();

        try {
            GatingConnection connection = new();
            Player player = new(server, connection, "test") { Position = Spawn };
            world.AddPlayer(player);
            AssertViewportArrives(connection, new Vec2<int>(0, 0), "on join");

            int seen = -1;
            int stable = 0;
            DateTime deadline = DateTime.UtcNow + TimeSpan.FromSeconds(20);

            while (DateTime.UtcNow < deadline) {
                int count = connection.Sent.OfType<ClientBoundChunkDataAndUpdateLightPacket>().Count();
                stable = count == seen ? stable + 1 : 0;
                seen = count;
                if (stable >= 5) break;
                Thread.Sleep(100);
            }

            Assert.That(stable, Is.GreaterThanOrEqualTo(5), "the world never stopped sending chunks");

            // Nine chunks, each sent once plus a bounded number of light corrections as its
            // neighbours arrive. Anything near a loop lands far above this.
            Assert.That(seen, Is.LessThanOrEqualTo(9 * 9),
                $"nine chunks turned into {seen} chunk packets, which is a re-queue loop");
        } finally {
            server.Stop();
        }
    }

    /// <summary>
    /// <c>ResetPlayer</c> throws the client's whole viewport away and streams it again, and is
    /// reached from the <c>Skin</c> setter, so it happens on an arbitrary thread mid-session.
    /// </summary>
    [Test]
    public void ResetPlayerResendsEveryChunk() {
        ManagedMinecraftServer server = NewServer();
        World world = server.CreateWorld(new VoidProvider(), "minecraft:overworld",
            new FullBrightLightingProvider());
        server.Start();

        try {
            GatingConnection connection = new();
            Player player = new(server, connection, "test") { Position = Spawn };
            world.AddPlayer(player);
            AssertViewportArrives(connection, new Vec2<int>(0, 0), "on the first join");

            int before = connection.Sent.OfType<ClientBoundChunkDataAndUpdateLightPacket>().Count();

            Task.Run(() => world.ResetPlayer(player)).Wait(TimeSpan.FromSeconds(30));

            DateTime deadline = DateTime.UtcNow + TimeSpan.FromSeconds(20);
            while (DateTime.UtcNow < deadline) {
                HashSet<Vec2<int>> after = connection.Sent
                    .OfType<ClientBoundChunkDataAndUpdateLightPacket>()
                    .Skip(before)
                    .Select(p => new Vec2<int>(p.ChunkX, p.ChunkZ))
                    .ToHashSet();

                if (Viewport(new Vec2<int>(0, 0)).All(after.Contains)) return;
                Thread.Sleep(10);
            }

            Assert.Fail("the client was not sent its viewport again after a reset");
        } finally {
            server.Stop();
        }
    }
}
