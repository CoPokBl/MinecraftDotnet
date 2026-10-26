using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ManagedServer.Entities;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Types;
using ManagedServer.Features.Basic;
using ManagedServer.Features;
using ManagedServer.Fluids;
using ManagedServer.Pathfinding;
using ManagedServer.Viewables;
using Minecraft.Lighting;
using ManagedServer.Worlds.Saving;
using Minecraft;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Data.DimensionType;
using Minecraft.Data.Generated;
using Minecraft.Implementations;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Registry.SubRegistries;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using NBT;
using Minecraft.Placement;
using Minecraft.Placement.Helpers;
using Minecraft.Fluids;
using Minecraft.Registry;

// ReSharper disable MemberCanBePrivate.Global

namespace ManagedServer.Worlds;

/// <summary>
/// A Minecraft world. Owns a chunk store, a set of players, and the streaming/broadcast
/// plumbing that keeps clients in sync.
/// <p/>
/// Thread-safety contract: everything here is callable from any thread, which it has to be, because
/// <see cref="AddPlayer"/> is reached from the network thread during login and a minigame moves players
/// between worlds from timer and pool threads. Block writes go through <c>ChunkStore.Write</c>, which
/// holds the chunk's own lock, so they are safe against each other and against a chunk being
/// serialised. Broadcast and audience queries iterate a lock-free snapshot of the player list.
/// <p/>
/// Chunk streaming is a reconcile, not a push. A player's view holds the chunks they should end up
/// with; <see cref="HandlePlayerMove"/> only records where they are, and the tick diffs that against
/// what they have and sends as much as is ready. A chunk that is not loaded yet stays queued and is
/// tried again, so nothing is lost by arriving at an awkward moment. Building and writing happen off
/// the tick, one flight per player.
/// </summary>
public class World : MappedTaggable, IAudience, IFeatureScope, IPlacementLevel {
    #region public_properties

    public SnapshotList<Player> Players { get; } = new();
    public EventNode<IServerEvent> Events { get; }
    public IEntityManager Entities { get; }
    public ManagedMinecraftServer Server { get; init; }
    public FeatureHandler FeatureHandler { get; }
    public Identifier DimensionId { get; }
    public IDimensionType Dimension => Server.Registry.DimensionTypes[DimensionId];
    public bool Immutable { get; set; }

    /// <summary>
    /// Where <see cref="SaveAsync(SaveOptions?)"/> writes, and the store the dirty flags answer for.
    /// Null until a consumer sets it, however the world was made.
    /// </summary>
    /// <remarks>
    /// Never taken from the terrain provider, even one that could be written to. A provider is chosen
    /// for where terrain comes from: a map loader shared between a game's rounds, or a read only copy of
    /// someone's world, would otherwise be written into by the first save policy registered on the
    /// server.
    /// <p/>
    /// Holding one does not make the world save. A save happens when a consumer asks, or when a feature
    /// registered to ask on their behalf does.
    /// </remarks>
    public IChunkSink? Sink { get; set; }

    /// <summary>
    /// <c>Level.getRandom</c>, the world's own source. What anything not acting on behalf of an
    /// entity rolls against: where a dropped item lands, what a loot table gives when nothing broke
    /// the block.
    /// <p/>
    /// Vanilla seeds the per level sequences a loot table rolls on
    /// (<c>RandomSequences</c>, over <c>XoroshiroRandomSource</c>) and only this one is ported, so a
    /// roll here has the same distribution as vanilla's and not the same sequence.
    /// </summary>
    public RandomSource Random { get; set; } = LegacyRandomSource.Create();

    public int Time {
        get => _time;
        set {
            _time = value;
            SendPacket(BuildTimePacket());
        }
    }

    #endregion

    #region public_tags

    /// <summary>
    /// Set to <see cref="DateTime.Now"/> on item entities when they are dropped via <see cref="DropItem"/>.
    /// <p/>
    /// Superseded by <see cref="ItemEntity.PickupDelay"/>, which is vanilla's tick counter and is what
    /// <c>ItemPickupFeature</c> now reads. Still stamped so anything outside the framework that keyed
    /// off it keeps working.
    /// </summary>
    public static readonly Tag<DateTime> ItemDropTimeTag = new("minecraftdotnet:world:item_drop_time");

    #endregion

    #region config

    private readonly ITerrainProvider _provider;
    private readonly ILightingProvider _lighting;
    private readonly int _viewDistance;
    private readonly int _packetsPerTick;
    private readonly int _tickDelayMs;
    private readonly int _minY;
    private readonly int _maxY;

    /// <summary>The lowest block a position can be at, the dimension's <c>MinY</c>.</summary>
    public int MinY => _minY;

    /// <summary>One past the highest block a position can be at.</summary>
    public int MaxY => _maxY;

    /// <summary>
    /// What the pathfinder made of each block position, vanilla's <c>ServerLevel.getPathTypeCache</c>.
    /// One per world because it is keyed by position and invalidated by block changes; the per state
    /// half of the same answer is in <c>BlockPathData</c> and is global.
    /// </summary>
    public PathTypeCache PathTypes { get; } = new();

    /// <summary>
    /// The shape update cascade, vanilla's <c>Level.neighborUpdater</c>. Driven from
    /// <see cref="SetBlock(Vec3{int},IBlock,IBlockEntityType?,INbtTag?,int,int)"/> and holds the queue
    /// across a whole cascade, so it is per world and not static.
    /// </summary>
    private readonly NeighbourUpdater _neighbours;

    /// <summary>
    /// Whether a block write tells its neighbours, vanilla's <c>updateNeighbourShapes</c> pass. On by
    /// default, and already inert while <see cref="ManagedMinecraftServer.BlockPlacementRules"/> is
    /// empty, so this is mostly for a world that has rules and wants its writes left alone anyway: a
    /// schematic being streamed in, or a generator writing gameplay blocks.
    /// <p/>
    /// Per write, <see cref="BlockUpdateFlags.KnownShape"/> says the same thing for one call.
    /// </summary>
    public bool ShapeUpdates { get; set; } = true;

    private int UnloadDistance => _viewDistance + UnloadDistanceMod;
    private const int UnloadDistanceMod = 1;  // Reduces packet churn when players travel back and forth.

    #endregion

    #region state

    private int _time;
    private long _lastFlushTickMs;

    // Per-player world state — chunk viewport, packet queues, move-event subscription.
    private readonly ConcurrentDictionary<Player, PlayerChunkView> _views = new();

    // Chunks, their loading, and the packet each one currently serialises to.
    private readonly ChunkStore _chunks;

    private readonly Lock _saveLock = new();

    /// <summary>
    /// The viewport offsets ordered by distance from the centre, computed once because the view
    /// distance cannot change. Nearest first is what puts the chunk the player is standing in on the
    /// wire first, which is what ends their loading screen.
    /// </summary>
    private readonly Vec2<int>[] _viewportOffsets;

    /// <summary>
    /// How far down a player's queue a flush will look for a chunk that is ready. Bounded so a
    /// player waiting on slow terrain cannot make the tick sweep their whole viewport every time;
    /// anything past it simply waits for the next tick.
    /// </summary>
    private const int ScanSlack = 64;

    /// <summary>
    /// Chunks whose light is known to be stale for whoever holds them, and the moment each must be
    /// sent again whatever else has happened by then. Drained by the tick.
    /// </summary>
    private readonly Dictionary<Vec2<int>, long> _lightCorrections = [];

    private readonly Lock _lightCorrectionsLock = new();

    /// <summary>
    /// Held rather than taken off the method group per call, since the tick hands it to every
    /// player's flush and a method group conversion is an allocation each time.
    /// </summary>
    private readonly Func<Vec2<int>, bool> _isChunkLoaded;

    /// <summary>
    /// How long a light correction waits for the rest of a chunk's neighbourhood to arrive before
    /// going out regardless.
    /// </summary>
    /// <remarks>
    /// A chunk's light is decided by the three by three around it, so a chunk on the frontier is
    /// invalidated once per neighbour that loads after it: without a wait, walking into new terrain
    /// costs up to nine full chunk packets per chunk per player, all but the last of them
    /// immediately superseded. Waiting for the neighbourhood collapses that to one.
    /// <p/>
    /// The deadline exists because a neighbourhood is not guaranteed to complete: a chunk at the edge
    /// of what anybody wants loaded would otherwise hold its correction forever. It is set by the
    /// first invalidation and never refreshed, so this is a bound on how late a correction can be and
    /// not a window that a player who keeps walking can push in front of them.
    /// </remarks>
    private const int LightSettleMs = 500;

    #endregion

    #region construction

    internal World(ManagedMinecraftServer server, EventNode<IServerEvent> baseEventNode, ITerrainProvider provider,
        Identifier dimensionId, ILightingProvider? lighting = null, int viewDistance = 8,
        int packetsPerTick = 10, int tickDelayMs = 100) {

        Server = server;
        DimensionId = dimensionId;
        _provider = provider;
        _lighting = lighting ?? new CalculatedLightingProvider();
        _viewDistance = viewDistance;
        _packetsPerTick = packetsPerTick;
        _tickDelayMs = tickDelayMs;

        if (!Server.Registry.DimensionTypes.Contains(DimensionId)) {
            throw new ArgumentException($"Dimension {DimensionId} does not exist in the server's dimensions.");
        }

        // Cached because Dimension resolves through the registry on every access, and the physics loop
        // bounds-checks a lot of block positions.
        _minY = Dimension.MinY;
        _maxY = _minY + Dimension.Height;

        Events = baseEventNode.CreateChild<IWorldEvent>(e => e.World == this);
        Entities = new EntityManager(Events, viewDistance * 16);
        FeatureHandler = new FeatureHandler(this);
        _neighbours = new NeighbourUpdater(this);

        _viewportOffsets = BuildViewportOffsets(viewDistance);
        _chunks = new ChunkStore(_provider, _lighting, Server.Registry, Dimension.Height, _minY,
            Dimension.HasSkyLight, Server.HandleError, Server.ChunkGeneration);
        _chunks.ChunkLoaded += OnChunkLoaded;
        _isChunkLoaded = _chunks.IsLoaded;

        // Last, so the provider cannot be asked for a chunk before the store it would deliver into
        // exists. A provider with nothing to say back ignores this entirely.
        _provider.Attach(new WorldTerrainHost(this, _chunks));

        Events.AddListener<ServerTickEvent>(_ => Tick());
    }

    /// <summary>
    /// The square viewport, ordered by squared distance so the nearest chunk is streamed first. Ties
    /// keep their scan order, which only decides between chunks the client is equally waiting on.
    /// </summary>
    private static Vec2<int>[] BuildViewportOffsets(int viewDistance) {
        List<Vec2<int>> offsets = [];
        for (int dx = -viewDistance; dx <= viewDistance; dx++) {
            for (int dz = -viewDistance; dz <= viewDistance; dz++) {
                offsets.Add(new Vec2<int>(dx, dz));
            }
        }

        return offsets.OrderBy(o => o.X * o.X + o.Y * o.Y).ToArray();
    }

    /// <summary>
    /// Time of day rides on the overworld world clock as of 26.2, so setting it means sending a
    /// state for that clock. A rate of zero holds it where we put it, which is what the server
    /// has always done here.
    /// </summary>
    private ClientBoundUpdateTimePacket BuildTimePacket() {
        // Kept as an id rather than a registry entry so a server that dropped the vanilla clocks
        // just sends no clock update instead of failing to build the packet
        Identifier overworldClock = "minecraft:overworld";
        WorldClockRegistry clocks = Server.Registry.WorldClocks;

        return new ClientBoundUpdateTimePacket {
            GameTime = _time,
            ClockUpdates = clocks.Contains(overworldClock)
                ? [new ClientBoundUpdateTimePacket.ClockUpdate(
                    clocks.GetProtocolId(overworldClock), _time, 0f, 0f)]
                : []
        };
    }

    #endregion

    #region tick

    private void Tick() {
        Player[] snap = Players.Snapshot;

        // Reconcile first, so a move recorded since the last tick decides what this flush carries.
        // Cheap by construction: a diff over the viewport, no building and no I/O.
        foreach (Player player in snap) {
            if (!_views.TryGetValue(player, out PlayerChunkView? view) || view.Disconnected) continue;
            ReconcileViewport(player, view);
        }

        // After the reconcile, so a correction for a chunk the player has just walked out of range of
        // is dropped by the same diff rather than queued and then dropped next tick.
        DrainLightCorrections();

        // Advanced by whole delays rather than snapped to now, so a flush that lands a millisecond
        // early does not push the next one a whole tick out. Clamped so a stalled server catches up
        // once instead of firing a burst.
        long now = Environment.TickCount64;
        if (now - _lastFlushTickMs < _tickDelayMs) return;
        _lastFlushTickMs = _tickDelayMs > 0
            ? Math.Max(_lastFlushTickMs + _tickDelayMs, now - _tickDelayMs)
            : now;

        List<Vec2<int>> toLoad = [];

        foreach (Player player in snap) {
            if (!_views.TryGetValue(player, out PlayerChunkView? view) || view.Disconnected) continue;

            // Only one send flight per player at a time. That keeps every send for a player strictly
            // ordered, and keeps a slow client from stacking up batches.
            if (Interlocked.CompareExchange(ref view.SendInProgress, 1, 0) != 0) continue;

            toLoad.Clear();
            PlayerChunkView.Batch batch = view.TakeBatch(_packetsPerTick, _packetsPerTick + ScanSlack,
                _isChunkLoaded, toLoad);

            // Anything the player is waiting on that nobody has started yet.
            foreach (Vec2<int> pos in toLoad) _chunks.EnsureLoading(pos);

            if (batch.IsEmpty) {
                Interlocked.Exchange(ref view.SendInProgress, 0);
                continue;
            }

            // Building and writing happen off the tick: a chunk packet is a lighting pass and a
            // blocking socket write, neither of which any other player should be waiting behind.
            _ = Task.Run(() => SendBatch(player, view, batch));
        }
    }

    /// <summary>
    /// Writes one flush for one player, building each chunk packet immediately before it goes out so
    /// it carries the newest light available. Builds are shared between players by the chunk store,
    /// so N players owed the same chunk cost one lighting pass rather than N.
    /// </summary>
    private void SendBatch(Player player, PlayerChunkView view, PlayerChunkView.Batch batch) {
        int written = 0;

        try {
            foreach (MinecraftPacket packet in batch.Leading) {
                if (!BatchStillValid(view, batch)) return;
                player.SendPacket(packet);
            }

            for (; written < batch.Chunks.Length; written++) {
                if (!BatchStillValid(view, batch)) return;

                Vec2<int> pos = batch.Chunks[written];

                // The centre can move while a batch is in flight. A chunk that is no longer wanted is
                // dropped and unrecorded, so walking back into range queues it again rather than the
                // client being left without it.
                bool wanted;
                lock (view.Lock) {
                    wanted = pos.IsWithinRadiusOf(view.Centre, _viewDistance);
                    if (!wanted) view.Sent.Remove(pos);
                }
                if (!wanted) continue;

                MinecraftPacket? packet = _chunks.BuildPacket(pos);
                if (packet == null) {
                    // Unloaded underneath us, which only a load failure can do. Put it back rather
                    // than leaving the client short of a chunk it will never be offered again.
                    view.ReturnUnsent(new[] { pos });
                    continue;
                }

                player.SendPacket(packet);
            }

            foreach (MinecraftPacket packet in batch.Trailing) {
                if (!BatchStillValid(view, batch)) return;
                player.SendPacket(packet);
            }
        } catch (Exception e) {
            // Everything from the failure onwards is still owed. Without this the whole tail of the
            // batch is lost while still recorded as delivered, which is a chunk hole for good.
            view.ReturnUnsent(batch.Chunks.AsSpan(written));
            if (!view.Disconnected) Server.HandleError(e);
        } finally {
            Interlocked.Exchange(ref view.SendInProgress, 0);
        }
    }

    private static bool BatchStillValid(PlayerChunkView view, PlayerChunkView.Batch batch) {
        return !view.Disconnected && Volatile.Read(ref view.Epoch) == batch.Epoch;
    }

    /// <summary>
    /// Brings a player's wanted set in line with where they are. The diff itself is under the view's
    /// lock; the entity packets it implies are queued rather than written, because a socket write on
    /// the tick thread stalls every other player behind one slow client.
    /// </summary>
    private void ReconcileViewport(Player player, PlayerChunkView view) {
        PlayerChunkView.Diff diff = view.Reconcile(_viewDistance, UnloadDistance, _viewportOffsets);
        if (diff.Unloaded.Length == 0 && diff.Added.Length == 0) return;

        // Despawns lead, beside the unloads they pair with. Spawns trail, because an entity belongs
        // to a chunk the client should have been given first.
        foreach (Vec2<int> pos in diff.Unloaded) {
            foreach (Entity entity in Entities.GetEntitiesInChunk(pos)) {
                if (entity == player) continue;
                view.EnqueueLeading(Entities.TrackDespawn(entity, player));
            }
        }

        foreach (Vec2<int> pos in diff.Added) {
            _chunks.EnsureLoading(pos);
            foreach (Entity entity in Entities.GetEntitiesInChunk(pos)) {
                if (entity == player) continue;
                view.EnqueueTrailing(Entities.TrackSpawn(entity, player));
            }
        }
    }

    #endregion

    #region player_lifecycle

    public virtual void AddPlayer(Player player) {
        Events.CallEvent(new PlayerEnteringWorldEvent { Player = player, World = this });

        // The centre is known before anything else, and before the player is visible to the
        // streaming loop. This is the whole join fix: the old state had no centre until the end of a
        // long viewport sweep, and every chunk delivered in that window was discarded for good.
        PlayerChunkView view = new() {
            Centre = GetChunkPos(player.Position),
            NeedsReconcile = true
        };

        if (!_views.TryAdd(player, view)) {
            throw new InvalidOperationException($"Player {player.Name} is already in world {DimensionId}.");
        }

        player.SendPacket(BuildTimePacket());
        player.SendPacket(new ClientBoundGameEventPacket {
            Event = GameEvent.StartWaitingForLevelChunks,
            Value = 0f
        });

        view.CancelMoveListener = player.Events.AddListener<EntityMoveEvent>(e => {
            if (view.Disconnected) return;
            if (e.Entity != player) return;
            HandlePlayerMove(player, GetChunkPos(e.NewPos));
        });

        Players.Add(player);

        // Subscribed last, once the view is fully wired. A connection that has already gone runs the
        // handler immediately, and RemovePlayer can only undo what has been done by the time it runs:
        // subscribing earlier meant a player who left mid join had their move listener registered
        // after their own removal, and was added back to Players behind it.
        Action onDisconnect = () => RemovePlayer(player);
        view.DisconnectHandler = onDisconnect;
        player.Connection.Disconnected += onDisconnect;

        // Terrain starts arriving now rather than at the next tick, so it overlaps the rest of the
        // login handshake instead of following it.
        foreach (Vec2<int> offset in _viewportOffsets) {
            _chunks.EnsureLoading(view.Centre + offset);
        }
    }

    public virtual void RemovePlayer(Player player) {
        if (!_views.TryGetValue(player, out PlayerChunkView? view)) return;
        if (Interlocked.Exchange(ref view.RemovedFlag, 1) == 1) return;  // idempotent

        view.Disconnected = true;
        Interlocked.Increment(ref view.Epoch);  // stop any batch already in flight
        Events.CallEvent(new PlayerLeavingWorldEvent { Player = player, World = this });

        view.CancelMoveListener?.Invoke();
        if (view.DisconnectHandler != null) {
            try { player.Connection.Disconnected -= view.DisconnectHandler; }
            catch { /* event may already be detached */ }
        }

        _views.TryRemove(player, out _);

        Players.Remove(player);
    }

    public void ResetPlayer(Player player) {
        if (!_views.TryGetValue(player, out PlayerChunkView? view)) return;

        // Bumps the epoch, so a batch dequeued before this cannot be written after the packet that
        // told the client to throw its world away.
        view.Reset(GetChunkPos(player.Position));

        player.SendPacket(new ClientBoundGameEventPacket {
            Event = GameEvent.StartWaitingForLevelChunks,
            Value = 0f
        });
    }

    public bool DoesPlayerHaveChunkLoaded(Player player, Vec2<int> chunkPos) {
        if (!_views.TryGetValue(player, out PlayerChunkView? view)) return false;
        lock (view.Lock) {
            return view.Sent.Contains(chunkPos);
        }
    }

    #endregion

    #region player_movement

    /// <summary>
    /// Records where a player is. That is all it does: the viewport diff runs on the tick, from
    /// <see cref="ReconcileViewport"/>.
    /// <p/>
    /// A flag rather than a scheduled callback, because it is idempotent, because several moves
    /// inside one tick collapse into a single diff, and because it cannot outlive a player who
    /// leaves. It also means a join no longer streams a whole viewport around wherever the player
    /// object was constructed and then a second one around where the consumer teleports them to
    /// during the login event: both land before the first tick and only the final centre is used.
    /// </summary>
    public void HandlePlayerMove(Player player, Vec2<int> chunkPos) {
        if (!_views.TryGetValue(player, out PlayerChunkView? view)) return;
        if (view.Disconnected) return;

        lock (view.Lock) {
            if (view.Centre == chunkPos) return;
            view.Centre = chunkPos;
            view.NeedsReconcile = true;
        }
    }

    #endregion

    #region block_accessors

    public IBlock GetBlock(Vec3<int> pos) {
        CheckY(pos.Y);
        Vec2<int> chunkPos = GetChunkPos(pos);
        ChunkData? data = TryGetLoadedChunk(chunkPos);
        if (data == null) {
            throw new InvalidOperationException($"Chunk at {chunkPos} is not loaded. Use GetBlockWithLoad or load the chunk first.");
        }
        return data.LookupBlock(ToChunkLocalPos(GameToProtocolPos(pos)), Server.Registry);
    }

    public IBlock GetBlock(Vec3<double> pos) => GetBlock(pos.ToBlockPos());

    public async Task<IBlock> GetBlockWithLoad(Vec3<int> pos) {
        await LoadChunk(GetChunkPos(pos));
        return GetBlock(pos);
    }

    public IBlock GetBlockOr(Vec3<int> pos, IBlock def) {
        return IsInBounds(pos) && IsBlockLoaded(pos) ? GetBlock(pos) : def;
    }

    public IBlock GetBlockOr(Vec3<double> pos, IBlock def) => GetBlockOr(pos.ToBlockPos(), def);

    /// <summary>
    /// The raw block state id at a position, or <paramref name="def"/> when it is out of bounds or its
    /// chunk isn't loaded. Skips materialising an <see cref="IBlock"/>, which allocates a record and
    /// re-parses the block's shape strings on every property read — the collision sweep in
    /// <c>ManagedServer.Physics.EntityPhysics</c> does far too many lookups to afford that.
    /// </summary>
    public uint GetBlockStateIdOr(int x, int y, int z, uint def) {
        if (y < _minY || y >= _maxY) return def;

        ChunkData? data = TryGetLoadedChunk(new Vec2<int>(x >> 4, z >> 4));
        if (data == null) return def;

        return data.GetBlock((x % 16 + 16) % 16, y - _minY, (z % 16 + 16) % 16);
    }

    public BlockEntity? GetBlockData(Vec3<int> pos) {
        CheckY(pos.Y);
        Vec2<int> chunkPos = GetChunkPos(pos);
        ChunkData? data = TryGetLoadedChunk(chunkPos);
        if (data == null) {
            throw new InvalidOperationException($"Chunk at {chunkPos} is not loaded. Load the chunk before reading block entity data.");
        }
        return data.BlockEntities.GetValueOrDefault(ToChunkLocalPos(pos));
    }

    /// <summary>
    /// <c>Level.setBlock</c>. The defaults are <c>setBlockAndUpdate</c>'s: tell the clients and run the
    /// neighbour passes, which is what a caller that just wants a block somewhere means.
    /// <p/>
    /// The shape pass is why a fence lets go when its neighbour is broken, and why the second half of a
    /// two cell block goes with the first. A caller that has already worked out the surrounding states
    /// passes <see cref="BlockUpdateFlags.KnownShape"/> to keep the pass from undoing it.
    /// </summary>
    /// <param name="flags"><see cref="BlockUpdateFlags"/>, vanilla's <c>Block.UpdateFlags</c>.</param>
    /// <param name="updateLimit">
    /// How much further a shape cascade may go. Vanilla's re-entrancy guard, and the only one: leave
    /// it alone unless transcribing something that passes its own.
    /// </param>
    public void SetBlock(Vec3<int> pos, IBlock block, IBlockEntityType? blockEntityType = null,
        INbtTag? blockEntityData = null, int flags = BlockUpdateFlags.Default,
        int updateLimit = BlockUpdateFlags.UpdateLimit) {
        SetBlock(pos, block, blockEntityType, blockEntityData, flags, updateLimit, false);
    }

    private void SetBlock(Vec3<int> pos, IBlock block, IBlockEntityType? blockEntityType,
        INbtTag? blockEntityData, int flags, int updateLimit, bool destroy) {
        if (Immutable) throw new InvalidOperationException("World is immutable, cannot set block.");
        CheckY(pos.Y);

        WorldChangeEvent changeEvent = new() {
            World = this,
            Position = pos,
            OldState = GetBlockOr(pos, Block.Air),
            NewState = block,
            Flags = flags,
            Destroy = destroy
        };
        Events.CallEvent(changeEvent);

        if (changeEvent.Cancelled) {
            SendBlockUpdate(pos, this);
            return;
        }

        Vec2<int> chunkPos = GetChunkPos(pos);
        Vec3<int> localPos = ToChunkLocalPos(GameToProtocolPos(pos));

        // Chunk local x and z with the game y, which is what the record carries, what the wire form
        // wants, and where GetBlockData and SetBlockData look. Keyed by the absolute position instead
        // it is never found and never cleared, so writing air over it leaves it behind.
        Vec3<int> blockEntityKey = ToChunkLocalPos(pos);

        // Through the store, which holds the chunk's write lock for the duration and then marks it
        // and its neighbours stale. Writing the chunk directly races anything serialising it, since
        // serialising repacks the sections in place.
        _chunks.Write(chunkPos, data => {
            data.SetBlock(localPos, block);
            if (blockEntityType == null) {
                data.BlockEntities.Remove(blockEntityKey);
            } else {
                data.BlockEntities[blockEntityKey] = new BlockEntity(
                    localPos.X, pos.Y, localPos.Z, blockEntityType, blockEntityData.ThrowIfNull()
                );
            }
        });

        PathTypes.Invalidate(pos.X, pos.Y, pos.Z);

        if ((flags & BlockUpdateFlags.Clients) != 0) {
            SendBlockUpdate(pos, this);
        }

        // Vanilla clears UPDATE_NEIGHBORS and UPDATE_SUPPRESS_DROPS out of the flags it passes on, so
        // a cascade does not re-run the redstone pass at every step and does not carry a "do not drop"
        // from the write that started it into the blocks it knocks down.
        if (ShapeUpdates && !Server.BlockPlacementRules.IsEmpty
            && (flags & BlockUpdateFlags.KnownShape) == 0 && updateLimit > 0) {
            int cascade = flags & ~(BlockUpdateFlags.SuppressDrops | BlockUpdateFlags.NeighborUpdates);
            _neighbours.UpdateNeighbourShapes(pos, block, cascade, updateLimit - 1);
        }
    }

    /// <summary>
    /// <c>Level.destroyBlock</c>: what a shape update means when a rule answers air. Leaves the fluid
    /// that was in the block behind, so breaking a waterlogged fence leaves water rather than a hole.
    /// <p/>
    /// <paramref name="dropResources"/> is carried on the write as
    /// <see cref="BlockUpdateFlags.SuppressDrops"/> rather than acted on here. Core has no loot layer
    /// and is not meant to: <c>BlockDropsFeature</c> reads the flag off
    /// <see cref="WorldChangeEvent"/> and does the dropping, so a server with no such feature
    /// registered drops nothing whatever this is passed, which is the framework's rule.
    /// </summary>
    public bool DestroyBlock(Vec3<int> pos, bool dropResources,
        int updateLimit = BlockUpdateFlags.UpdateLimit) {
        IBlock existing = GetBlockOr(pos, Block.Air);
        if (existing.Air) {
            return false;
        }

        int flags = dropResources
            ? BlockUpdateFlags.Default
            : BlockUpdateFlags.Default | BlockUpdateFlags.SuppressDrops;

        SetBlock(pos, FluidState.Of(existing).ToBlock(), null, null, flags, updateLimit, true);
        return true;
    }

    public void SetBlock(Vec3<double> pos, IBlock block, IBlockEntityType? blockEntityType = null,
        INbtTag? blockEntityData = null, int flags = BlockUpdateFlags.Default,
        int updateLimit = BlockUpdateFlags.UpdateLimit) =>
        SetBlock(pos.ToBlockPos(), block, blockEntityType, blockEntityData, flags, updateLimit);

    MinecraftRegistry IPlacementLevel.Registry => Server.Registry;
    int IPlacementLevel.MinY => Dimension.MinY;
    int IPlacementLevel.Height => Dimension.Height;
    bool IPlacementLevel.IsInBounds(Vec3<int> pos) => IsInBounds(pos);
    bool IPlacementLevel.IsClientSide => false;
    bool IPlacementLevel.IsInBlockTag(Identifier tag, Identifier block) => PlacementHelpers.InTag(Server.Registry, tag, block);
    IBlockPlacementRule? IPlacementLevel.PlacementRuleFor(IBlock block) => Server.BlockPlacementRules.For(block, this);

    void IPlacementLevel.SetBlock(Vec3<int> pos, IBlock block, int flags, int updateLimit) =>
        SetBlock(pos, block, null, null, flags, updateLimit);

    public void SetBlockData(Vec3<int> pos, BlockEntity? data) {
        if (Immutable) throw new InvalidOperationException("World is immutable, cannot set block data.");
        CheckY(pos.Y);

        Vec2<int> chunkPos = GetChunkPos(pos);
        Vec3<int> localPos = ToChunkLocalPos(pos);

        _chunks.Write(chunkPos, chunk => {
            if (data == null) chunk.BlockEntities.Remove(localPos);
            else chunk.BlockEntities[localPos] = data;
        });

        SendBlockUpdate(pos, this);
    }

    public async Task SetBlocksAsync(BlockUpdate[] blockUpdates) {
        if (Immutable) throw new InvalidOperationException("World is immutable, cannot set blocks.");

        // Group updates by chunk.
        Dictionary<Vec2<int>, List<int>> byChunk = new();
        Vec3<int>[] localPositions = new Vec3<int>[blockUpdates.Length];

        for (int i = 0; i < blockUpdates.Length; i++) {
            CheckY(blockUpdates[i].Location.Y);
            Vec2<int> chunkPos = GetChunkPos(blockUpdates[i].Location);
            localPositions[i] = ToChunkLocalPos(blockUpdates[i].Location);

            if (!byChunk.TryGetValue(chunkPos, out List<int>? indices)) {
                indices = [];
                byChunk[chunkPos] = indices;
            }
            indices.Add(i);
        }

        // Ensure all target chunks are loaded.
        await Task.WhenAll(byChunk.Keys.Select(LoadChunk));

        // Fire cancellation events.
        bool[] cancelled = new bool[blockUpdates.Length];
        for (int i = 0; i < blockUpdates.Length; i++) {
            WorldChangeEvent e = new() {
                World = this,
                Position = blockUpdates[i].Location,
                OldState = GetBlock(blockUpdates[i].Location),
                NewState = blockUpdates[i].Block
            };
            Events.CallEvent(e);
            cancelled[i] = e.Cancelled;
        }

        // Write and build section-update packets per chunk.
        List<ClientBoundSectionBlocksUpdatePacket> packets = [];

        foreach ((Vec2<int> chunkPos, List<int> indices) in byChunk) {
            indices.Sort((a, b) => localPositions[a].Y.CompareTo(localPositions[b].Y));

            List<BlockUpdate> current = [];
            int? currentSection = null;

            // The whole chunk's worth of writes under one hold of its write lock, rather than one
            // hold each. This method resumes on a pool thread after awaiting its loads, so it is
            // exactly the caller the lock exists for.
            _chunks.Write(chunkPos, data => {
                foreach (int idx in indices) {
                    if (cancelled[idx]) continue;

                    Vec3<int> local = localPositions[idx];
                    data.SetBlock(GameToProtocolPos(local), blockUpdates[idx].Block);
                    PathTypes.Invalidate(local.X, local.Y, local.Z);

                    int section = data.GetYSection(local.Y, out _);
                    currentSection ??= section;
                    if (currentSection != section) {
                        packets.Add(new ClientBoundSectionBlocksUpdatePacket {
                            ChunkSectionPosition = new Vec3<int>(chunkPos.X, currentSection.Value, chunkPos.Y),
                            BlockUpdates = current.ToArray()
                        });
                        currentSection = section;
                        current = [];
                    }

                    current.Add(blockUpdates[idx]);
                }
            });

            if (currentSection != null && current.Count > 0) {
                packets.Add(new ClientBoundSectionBlocksUpdatePacket {
                    ChunkSectionPosition = new Vec3<int>(chunkPos.X, currentSection.Value, chunkPos.Y),
                    BlockUpdates = current.ToArray()
                });
            }
        }

        // Broadcast updates.
        foreach (ClientBoundSectionBlocksUpdatePacket p in packets) {
            GetAudienceOf(p.ChunkSectionPosition.XZ).SendPacket(p);
        }
    }

    #endregion

    #region entity_utilities

    public void Spawn(Entity entity, int? id = null) {
        if (id != null) entity.NetId = id.Value;
        entity.SetWorld(this);
    }

    public void StrikeLightning(Vec3<double> pos) {
        Entity lightning = new(EntityType.LightningBolt) {
            Position = pos,
            Yaw = Angle.Zero,
            Pitch = Angle.Zero
        };
        lightning.SetWorld(this);
        Server.Scheduler.ScheduleTask(Server.TargetTicksPerSecond * 2, lightning.Despawn);
    }

    /// <summary>
    /// Spawns a dropped stack. Returns an <see cref="ItemEntity"/>, which is still an
    /// <see cref="Entity"/>, so a caller that only wanted somewhere for the item to go is unaffected.
    /// <p/>
    /// The pickup delay starts at vanilla's default rather than at zero, so a stack cannot be
    /// collected on the tick it appears. Nothing counts it down until <c>ItemEntityFeature</c> is
    /// registered, and <c>ItemPickupFeature</c> falls back to the wall clock tag when it is not.
    /// </summary>
    public ItemEntity DropItem(Vec3<double> pos, ItemStack item) {
        ItemEntity itemEntity = new(item) {
            Position = pos,
            PickupDelay = ItemEntity.DefaultPickupDelay
        };
        itemEntity.SetTag(ItemDropTimeTag, DateTime.Now);
        Spawn(itemEntity);
        itemEntity.Item = item;
        return itemEntity;
    }

    #endregion

    #region predicates

    /// <summary>
    /// Whether nothing stands between a position and the sky, vanilla's <c>canSeeSky</c>.
    /// <p/>
    /// Upstream this is <c>getBrightness(SKY, pos) &gt;= 15</c>, read out of the light arrays.
    /// Computed directly here instead, because it is the same question: a sky source column stops at
    /// the first block that dampens at all, so an undimmed column and a sky level of fifteen are the
    /// same condition. Doing it this way avoids driving the lighting provider, which works a chunk
    /// at a time and would recompute a nine chunk region to answer one position.
    /// <p/>
    /// Time of day does not come into it, upstream either: stored sky light is what the sky would
    /// give at noon.
    /// </summary>
    public bool CanSeeSky(Vec3<int> pos) {
        if (!Dimension.HasSkyLight || !IsInBounds(pos)) {
            return false;
        }

        for (int y = pos.Y + 1; y < _maxY; y++) {
            if (GetBlockOr(new Vec3<int>(pos.X, y, pos.Z), Block.Air).LightDampening > 0) {
                return false;
            }
        }

        return true;
    }

    public bool IsBlockLoaded(Vec3<int> pos) {
        CheckY(pos.Y);
        return IsChunkLoaded(GetChunkPos(pos));
    }

    public bool IsChunkLoaded(Vec2<int> pos) {
        return _chunks.IsLoaded(pos);
    }

    public bool IsInBounds(Vec3<double> pos) {
        return pos.Y >= _minY && pos.Y < _maxY;
    }

    private void CheckY(int y) {
        if (y < _minY || y > _maxY) {
            throw new ArgumentOutOfRangeException(nameof(y), "Y position is out of bounds for this dimension.");
        }
    }

    #endregion

    #region chunk_loading

    public Task LoadChunk(Vec2<int> pos) {
        return _chunks.Load(pos);
    }

    public Task LoadChunks(Vec2<int>[] poses) {
        Task[] tasks = new Task[poses.Length];
        for (int i = 0; i < poses.Length; i++) tasks[i] = LoadChunk(poses[i]);
        return Task.WhenAll(tasks);
    }

    /// <summary>
    /// A chunk has arrived. Light crosses chunk borders, so the eight around it are now lit wrongly
    /// for anyone already holding them, and have to be sent again.
    /// <p/>
    /// The order matters and is not incidental. Versions are bumped first, inside
    /// <c>InvalidateLightAround</c>, so that a build already running for any of these chunks can no
    /// longer publish its result. Only then is anything queued. A player holding a neighbour gets it
    /// queued again, at the tail, behind the copy it is correcting; a player who merely has it
    /// pending needs nothing, because the build that eventually happens reads the new light for free.
    /// That is what collapses a join from thousands of lighting passes into one per chunk.
    /// <p/>
    /// The correction itself is recorded rather than sent, and released by
    /// <see cref="DrainLightCorrections"/> once the rest of the chunk's neighbourhood has arrived.
    /// See <see cref="LightSettleMs"/>.
    /// </summary>
    private void OnChunkLoaded(Vec2<int> pos) {
        _chunks.InvalidateLightAround(pos);

        long deadline = Environment.TickCount64 + LightSettleMs;
        lock (_lightCorrectionsLock) {
            for (int dz = -1; dz <= 1; dz++) {
                for (int dx = -1; dx <= 1; dx++) {
                    if (dx == 0 && dz == 0) continue;

                    // TryAdd, so the deadline is the first invalidation's. Overwriting it would let a
                    // chunk whose neighbours keep arriving postpone its own correction indefinitely.
                    _lightCorrections.TryAdd(new Vec2<int>(pos.X + dx, pos.Y + dz), deadline);
                }
            }
        }
    }

    /// <summary>
    /// Queues the light corrections whose chunks have settled, meaning the whole three by three
    /// around them is loaded and no later arrival can move their light, or whose deadline has passed.
    /// </summary>
    private void DrainLightCorrections() {
        List<Vec2<int>>? ready = null;
        long now = Environment.TickCount64;

        lock (_lightCorrectionsLock) {
            if (_lightCorrections.Count == 0) return;

            foreach ((Vec2<int> pos, long deadline) in _lightCorrections) {
                if (now < deadline && !_chunks.NeighbourhoodLoaded(pos)) continue;
                (ready ??= []).Add(pos);
            }

            if (ready == null) return;
            foreach (Vec2<int> pos in ready) _lightCorrections.Remove(pos);
        }

        ReadOnlySpan<Vec2<int>> positions = CollectionsMarshal.AsSpan(ready);
        foreach (Player player in Players.Snapshot) {
            if (!_views.TryGetValue(player, out PlayerChunkView? view) || view.Disconnected) continue;
            view.Requeue(positions);
        }
    }

    /// <summary>
    /// Sends a chunk again to everyone already holding it, because its contents changed wholesale.
    /// Terrain generation forking into an already delivered chunk is what this is for.
    /// </summary>
    /// <remarks>
    /// Through the same per player queue as a light correction, and for the same reason: the queue
    /// releases <c>WorldPacketsPerTick</c> a tick, so a direct send would arrive ahead of chunks the
    /// client is still waiting on. See <see cref="PlayerChunkView.Requeue"/>.
    /// </remarks>
    public void ResendChunk(Vec2<int> pos) {
        ReadOnlySpan<Vec2<int>> one = [pos];

        foreach (Player player in Players.Snapshot) {
            if (!_views.TryGetValue(player, out PlayerChunkView? view) || view.Disconnected) continue;
            view.Requeue(one);
        }
    }

    private ChunkData? TryGetLoadedChunk(Vec2<int> pos) {
        return _chunks.TryGet(pos);
    }

    #endregion

    #region saving

    /// <summary>
    /// Raised off the tick when a chunk's own contents change. What an incremental saver watches, as
    /// opposed to sweeping the loaded set on a timer.
    /// </summary>
    /// <remarks>
    /// A block write only, never a light change in a neighbour, and never a chunk arriving. It fires
    /// once per <see cref="SetBlock(Vec3{int},IBlock,IBlockEntityType?,INbtTag?,int,int)"/> and so on
    /// the thread that made the write; a handler doing anything slow has to hand it off.
    /// </remarks>
    public event Action<Vec2<int>>? ChunkChanged {
        add => _chunks.ChunkChanged += value;
        remove => _chunks.ChunkChanged -= value;
    }

    /// <summary>
    /// Whether this chunk has been written to, or generated, since <see cref="Sink"/> last stored it.
    /// </summary>
    public bool IsChunkDirty(Vec2<int> pos) => _chunks.IsDirty(pos);

    /// <summary>Every chunk currently in memory.</summary>
    public IEnumerable<Vec2<int>> LoadedChunks() => _chunks.LoadedChunks();

    /// <summary>
    /// Writes this world's chunks to <see cref="Sink"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">The world has no sink to write to.</exception>
    public Task<SaveReport> SaveAsync(SaveOptions? options = null) {
        IChunkSink sink = Sink ?? throw new InvalidOperationException(
            "This world has no Sink, so there is nowhere to save it. Set World.Sink, register a " +
            "WorldPersistenceFeature, or pass a sink to the other overload.");

        return SaveAsync(sink, options);
    }

    /// <summary>
    /// Writes this world's chunks to <paramref name="sink"/>.
    /// </summary>
    /// <remarks>
    /// Every chunk goes over as a snapshot, which is the same immutable copy the send path builds, so
    /// capture costs nothing for a chunk anybody has been sent recently and encoding never holds a
    /// lock against the tick.
    /// <p/>
    /// The tick is not stopped, so this is consistent per chunk and not across the world: a chunk is
    /// whatever it was when its snapshot was taken. A write landing while its own chunk is being
    /// encoded leaves that chunk dirty and it goes out again on the next save rather than being lost.
    /// <p/>
    /// Only a save to <see cref="Sink"/> marks chunks clean. A copy made to anywhere else leaves them
    /// owed to the sink, which would otherwise never be sent what the copy took.
    /// <p/>
    /// One save of a world runs at a time and a second waits for the first. Two overlapping would each
    /// mark a chunk against its own snapshot in whichever order they finished, and could leave the
    /// older one on disk with the chunk marked clean.
    /// </remarks>
    public Task<SaveReport> SaveAsync(IChunkSink sink, SaveOptions? options = null) {
        return Task.Run(() => Save(sink, options));
    }

    /// <summary>
    /// <see cref="SaveAsync(IChunkSink,SaveOptions?)"/> without handing the work off, for a shutdown
    /// path that has to finish before the process goes away.
    /// </summary>
    public SaveReport Save(IChunkSink sink, SaveOptions? options = null) {
        options ??= SaveOptions.Default;

        lock (_saveLock) {
            return SaveCore(sink, ReferenceEquals(sink, Sink), options);
        }
    }

    private SaveReport SaveCore(IChunkSink sink, bool marksSaved, SaveOptions options) {
        long started = Stopwatch.GetTimestamp();
        List<Vec2<int>> candidates = [];
        int skipped = 0;

        foreach (Vec2<int> pos in _chunks.LoadedChunks()) {
            if (options.Chunks?.Invoke(pos) == false || (options.Scope == SaveScope.Changed && !_chunks.IsDirty(pos))) {
                skipped++;
                continue;
            }

            candidates.Add(pos);
        }

        ConcurrentBag<ChunkSaveFailure> failures = [];
        int written = 0;

        // A failure is recorded and the sweep goes on, so one unwritable chunk costs that chunk rather
        // than everything after it. StopOnError instead lets it out of here, and out of the task.
        ParallelOptions parallel = new() { MaxDegreeOfParallelism = Math.Max(1, options.MaxConcurrency) };
        Parallel.ForEach(candidates, parallel, pos => {
            try {
                // Marked with the version the snapshot holds rather than the one now, so a block placed
                // while this chunk was being encoded leaves it dirty for the next pass.
                ChunkData? snapshot = _chunks.SnapshotFor(pos, out long version);
                if (snapshot == null) {
                    return;
                }

                sink.PutChunk(snapshot);
                if (marksSaved) {
                    _chunks.MarkSaved(pos, version);
                }
                Interlocked.Increment(ref written);
            } catch (Exception e) {
                failures.Add(new ChunkSaveFailure(pos, e));
                if (options.StopOnError) {
                    throw;
                }
            }
        });

        if (options.Flush) {
            try {
                sink.Flush();
            } catch (Exception e) {
                failures.Add(new ChunkSaveFailure(null, e));
            }
        }

        return new SaveReport {
            Written = written,
            Skipped = skipped,
            Duration = Stopwatch.GetElapsedTime(started),
            Failures = failures.ToArray()
        };
    }

    #endregion

    #region viewers_and_audience

    public IAudience GetAudienceOf(Vec2<int> chunkPos) {
        // ReSharper disable once CoVariantArrayConversion
        return new AudiencesList(GetViewersOf(chunkPos));
    }

    public IAudience GetAudienceOf(Vec3<int> pos) {
        // ReSharper disable once CoVariantArrayConversion
        return new AudiencesList(GetViewersOf(pos));
    }

    public Player[] GetViewersOf(Vec2<int> chunkPos) {
        Player[] snap = Players.Snapshot;
        if (snap.Length == 0) return [];

        Player[] buffer = new Player[snap.Length];
        int count = 0;
        for (int i = 0; i < snap.Length; i++) {
            Player p = snap[i];
            if (GetChunkPos(p.Position).IsWithinRadiusOf(chunkPos, _viewDistance)) buffer[count++] = p;
        }

        if (count == buffer.Length) return buffer;
        Player[] result = new Player[count];
        Array.Copy(buffer, result, count);
        return result;
    }

    public Player[] GetViewersOf(Vec3<double> pos) => GetViewersOf(GetChunkPos(pos));

    public void SendBlockUpdate(Vec3<int> pos, IAudience audience) {
        audience.SendPacket(new ClientBoundBlockUpdatePacket {
            Block = GetBlock(pos),
            Location = pos
        });

        BlockEntity? data = GetBlockData(pos);
        if (data == null) return;

        Server.Scheduler.ScheduleNextTick(() => {
            BlockEntity? updated = GetBlockData(pos);
            if (updated == null) return;
            audience.SendPacket(new ClientBoundBlockEntityDataPacket {
                Position = pos,
                Data = updated.Data,
                Type = updated.Type
            });
        });
    }

    /// <summary>
    /// Sends a chunk straight to an audience, outside the per player queue. The packet is the shared,
    /// snapshotted one, so this no longer races a block write, but it can still overtake chunks the
    /// streaming loop already owes those players. Normal streaming does not go through here.
    /// </summary>
    public void SendChunkUpdate(Vec2<int> pos, IAudience audience) {
        MinecraftPacket? packet = _chunks.BuildPacket(pos);
        if (packet == null) {
            throw new InvalidOperationException($"Chunk at {pos} is not loaded.");
        }
        audience.SendPacket(packet);
    }

    public void SendPacket(MinecraftPacket packet) {
        Player[] snap = Players.Snapshot;
        for (int i = 0; i < snap.Length; i++) snap[i].SendPacket(packet);
    }

    #endregion

    #region conversions

    public static Vec2<int> GetChunkPos(Vec3<double> pos) {
        return new Vec2<int>((int)Math.Floor(pos.X / 16), (int)Math.Floor(pos.Z / 16));
    }

    private static Vec3<int> ToChunkLocalPos(Vec3<int> pos) {
        return new Vec3<int>((pos.X % 16 + 16) % 16, pos.Y, (pos.Z % 16 + 16) % 16);
    }

    private Vec3<int> GameToProtocolPos(Vec3<int> pos) {
        return new Vec3<int>(pos.X, pos.Y - _minY, pos.Z);
    }

    #endregion
}
