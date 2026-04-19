using System.Collections.Concurrent;
using ManagedServer.Entities;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Types;
using ManagedServer.Features;
using ManagedServer.Viewables;
using ManagedServer.Worlds.Lighting;
using Minecraft;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Data.DimensionType;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using NBT;

// ReSharper disable MemberCanBePrivate.Global

namespace ManagedServer.Worlds;

/// <summary>
/// A Minecraft world. Owns a chunk store, a set of players, and the streaming/broadcast
/// plumbing that keeps clients in sync.
/// <p/>
/// Thread-safety contract: block mutations (<see cref="SetBlock(Vec3{int},IBlock,IBlockEntityType?,INbtTag?)"/>,
/// <see cref="SetBlockData"/>) and player lifecycle (<see cref="AddPlayer"/>, <see cref="RemovePlayer"/>) are
/// expected to happen on the server tick thread. Block reads are safe from any thread provided no concurrent
/// write is in flight on the same chunk. Packet broadcast (<see cref="SendPacket"/>) and audience queries are
/// thread-safe; they iterate a lock-free snapshot of the player list.
/// </summary>
public class World : MappedTaggable, IAudience, IFeatureScope {
    #region public_properties

    public List<Player> Players { get; } = [];
    public EventNode<IServerEvent> Events { get; }
    public IEntityManager Entities { get; }
    public ManagedMinecraftServer Server { get; init; }
    public FeatureHandler FeatureHandler { get; }
    public Identifier DimensionId { get; }
    public IDimensionType Dimension => Server.Registry.DimensionTypes[DimensionId];
    public bool Immutable { get; set; }

    public int Time {
        get => _time;
        set {
            _time = value;
            SendPacket(new ClientBoundUpdateTimePacket {
                ClientAdvanceTime = false,
                TimeOfDay = value,
                WorldAge = value
            });
        }
    }

    #endregion

    #region public_tags

    /// <summary>
    /// Set to <see cref="DateTime.Now"/> on item entities when they are dropped via <see cref="DropItem"/>.
    /// </summary>
    public static readonly Tag<DateTime> ItemDropTimeTag = new("minecraftdotnet:world:item_drop_time");

    #endregion

    #region config

    private readonly ITerrainProvider _provider;
    private readonly ILightingProvider _lighting;
    private readonly int _viewDistance;
    private readonly int _packetsPerTick;
    private readonly int _tickDelayMs;
    private readonly int _maxY;

    private int UnloadDistance => _viewDistance + UnloadDistanceMod;
    private const int UnloadDistanceMod = 1;  // Reduces packet churn when players travel back and forth.

    #endregion

    #region state

    private int _time;
    private long _lastFlushTickMs;

    // Players list is exposed via IFeatureScope; we keep a snapshot for lock-free internal iteration.
    private readonly Lock _playersLock = new();
    private volatile Player[] _playersSnapshot = [];

    // Per-player world state — chunk viewport, packet queue, move-event subscription.
    private readonly ConcurrentDictionary<Player, PlayerWorldState> _playerStates = new();

    // Unified chunk store. A chunk is loaded iff its task IsCompletedSuccessfully.
    private readonly ConcurrentDictionary<Vec2<int>, Task<ChunkData>> _chunkTasks = new();

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

        _maxY = Dimension.MinY + Dimension.Height;

        Events = baseEventNode.CreateChild<IWorldEvent>(e => e.World == this);
        Entities = new EntityManager(Events, viewDistance * 16);
        FeatureHandler = new FeatureHandler(this);

        Events.AddListener<ServerTickEvent>(_ => Tick());
    }

    #endregion

    #region tick

    private void Tick() {
        long now = Environment.TickCount64;
        if (now - _lastFlushTickMs < _tickDelayMs) return;
        _lastFlushTickMs = now;

        Player[] snap = _playersSnapshot;
        foreach (Player player in snap) {
            if (!_playerStates.TryGetValue(player, out PlayerWorldState? state) || state.Disconnected) continue;

            // Only one send flight per player at a time — prevents socket races and
            // controls memory pressure. If the previous batch hasn't finished being
            // written to the socket yet, skip this flush cycle for that player.
            if (Interlocked.CompareExchange(ref state.SendInProgress, 1, 0) != 0) continue;

            MinecraftPacket[]? batch = null;
            lock (state.Lock) {
                int n = Math.Min(state.PendingPackets.Count, _packetsPerTick);
                if (n > 0) {
                    batch = new MinecraftPacket[n];
                    for (int i = 0; i < n; i++) batch[i] = state.PendingPackets.Dequeue();
                }
            }

            if (batch == null) {
                Interlocked.Exchange(ref state.SendInProgress, 0);
                continue;
            }

            // Serialise and write to the socket off the tick thread.
            _ = Task.Run(() => {
                try {
                    player.SendPackets(batch);
                } catch {
                    // Player disconnected mid-send; RemovePlayer handles cleanup.
                } finally {
                    Interlocked.Exchange(ref state.SendInProgress, 0);
                }
            });
        }
    }

    #endregion

    #region player_lifecycle

    public virtual void AddPlayer(Player player) {
        Events.CallEvent(new PlayerEnteringWorldEvent { Player = player, World = this });

        PlayerWorldState state = new();
        if (!_playerStates.TryAdd(player, state)) {
            throw new InvalidOperationException($"Player {player.Name} is already in world {DimensionId}.");
        }

        player.SendPacket(new ClientBoundUpdateTimePacket {
            ClientAdvanceTime = false,
            TimeOfDay = _time,
            WorldAge = _time
        });
        player.SendPacket(new ClientBoundGameEventPacket {
            Event = GameEvent.StartWaitingForLevelChunks,
            Value = 0f
        });

        Action onDisconnect = () => RemovePlayer(player);
        player.Connection.Disconnected += onDisconnect;
        state.DisconnectHandler = onDisconnect;

        state.CancelMoveListener = player.Events.AddListener<EntityMoveEvent>(e => {
            if (state.Disconnected) return;
            if (e.Entity != player) return;
            HandlePlayerMove(player, GetChunkPos(e.NewPos));
        });

        lock (_playersLock) {
            if (!Players.Contains(player)) {
                Players.Add(player);
                _playersSnapshot = Players.ToArray();
            }
        }

        HandlePlayerMove(player, GetChunkPos(player.Position));
    }

    public virtual void RemovePlayer(Player player) {
        if (!_playerStates.TryGetValue(player, out PlayerWorldState? state)) return;
        if (Interlocked.Exchange(ref state.RemovedFlag, 1) == 1) return;  // idempotent

        state.Disconnected = true;
        Events.CallEvent(new PlayerLeavingWorldEvent { Player = player, World = this });

        state.CancelMoveListener?.Invoke();
        if (state.DisconnectHandler != null) {
            try { player.Connection.Disconnected -= state.DisconnectHandler; }
            catch { /* event may already be detached */ }
        }

        _playerStates.TryRemove(player, out _);

        lock (_playersLock) {
            if (Players.Remove(player)) {
                _playersSnapshot = Players.ToArray();
            }
        }
    }

    public void ResetPlayer(Player player) {
        if (!_playerStates.TryGetValue(player, out PlayerWorldState? state)) return;

        lock (state.Lock) {
            state.LoadedChunks.Clear();
            state.CurrentChunk = null;
            state.PendingPackets.Clear();
        }

        player.SendPacket(new ClientBoundGameEventPacket {
            Event = GameEvent.StartWaitingForLevelChunks,
            Value = 0f
        });

        HandlePlayerMove(player, GetChunkPos(player.Position));
    }

    public bool DoesPlayerHaveChunkLoaded(Player player, Vec2<int> chunkPos) {
        if (!_playerStates.TryGetValue(player, out PlayerWorldState? state)) return false;
        lock (state.Lock) {
            return state.LoadedChunks.Contains(chunkPos);
        }
    }

    #endregion

    #region player_movement

    public void HandlePlayerMove(Player player, Vec2<int> chunkPos) {
        if (!_playerStates.TryGetValue(player, out PlayerWorldState? state)) return;
        if (state.Disconnected) return;

        HashSet<Vec2<int>> loadedSnapshot;
        lock (state.Lock) {
            if (state.CurrentChunk == chunkPos) return;
            loadedSnapshot = new HashSet<Vec2<int>>(state.LoadedChunks);
        }

        // Phase 1: compute the diff without holding state.Lock.
        // Entity spawn/despawn and chunk-data retrieval may take their own locks; keep them outside our lock.

        List<Vec2<int>> toUnload = [];
        foreach (Vec2<int> loaded in loadedSnapshot) {
            if (!loaded.IsWithinRadiusOf(chunkPos, UnloadDistance)) toUnload.Add(loaded);
        }

        List<MinecraftPacket> packets = [
            new ClientBoundSetCenterChunkPacket { X = chunkPos.X, Z = chunkPos.Y }
        ];

        foreach (Vec2<int> pos in toUnload) {
            packets.Add(new ClientBoundUnloadChunkPacket { X = pos.X, Z = pos.Y });
            foreach (Entity entity in Entities.GetEntitiesInChunk(pos)) {
                if (entity == player) continue;
                Entities.SendDespawnPackets(entity, player);
            }
        }

        for (int dx = -_viewDistance; dx <= _viewDistance; dx++) {
            for (int dz = -_viewDistance; dz <= _viewDistance; dz++) {
                Vec2<int> chunk = new(chunkPos.X + dx, chunkPos.Y + dz);
                if (loadedSnapshot.Contains(chunk)) continue;

                foreach (Entity entity in Entities.GetEntitiesInChunk(chunk)) {
                    if (entity == player) continue;
                    Entities.SendSpawnPackets(entity, player);
                }

                ChunkData? data = TryGetLoadedChunk(chunk);
                if (data != null) {
                    // Already loaded but not yet streamed to this player. BuildChunkPacket
                    // involves expensive lighting computation, so run it off this thread and
                    // enqueue via the normal async path. EnqueueChunkToPlayers owns the
                    // LoadedChunks update, so we don't add to toAdd here.
                    Vec2<int> capturedChunk = chunk;
                    ChunkData capturedData = data;
                    _ = Task.Run(() => {
                        MinecraftPacket pkt = BuildChunkPacket(capturedChunk, capturedData);
                        Server.Scheduler.ScheduleNextTick(() => EnqueueChunkToPlayers(capturedChunk, pkt));
                    });
                } else {
                    // Not yet loaded; kick off an async load. The completion handler will enqueue
                    // the chunk packet to any player still in range (including this one).
                    _ = LoadChunk(chunk);
                }
            }
        }

        // packets now only contains SetCenterChunk + UnloadChunk — always send SetCenter first.
        packets.Sort((a, b) => PacketOrderKey(a, chunkPos).CompareTo(PacketOrderKey(b, chunkPos)));

        // Phase 2: commit under state.Lock.
        lock (state.Lock) {
            if (state.Disconnected) return;
            // If another move raced us to the same chunk, drop this batch.
            if (state.CurrentChunk == chunkPos) return;
            state.CurrentChunk = chunkPos;
            foreach (Vec2<int> c in toUnload) state.LoadedChunks.Remove(c);
            foreach (MinecraftPacket p in packets) state.PendingPackets.Enqueue(p);
        }
    }

    private static double PacketOrderKey(MinecraftPacket p, Vec2<int> center) => p switch {
        ClientBoundSetCenterChunkPacket => -1d,
        ClientBoundChunkDataAndUpdateLightPacket c => new Vec2<int>(c.ChunkX, c.ChunkZ).DistanceTo(center),
        _ => 1000d  // unload packets last
    };

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

    public BlockEntity? GetBlockData(Vec3<int> pos) {
        CheckY(pos.Y);
        Vec2<int> chunkPos = GetChunkPos(pos);
        ChunkData? data = TryGetLoadedChunk(chunkPos);
        if (data == null) {
            throw new InvalidOperationException($"Chunk at {chunkPos} is not loaded. Load the chunk before reading block entity data.");
        }
        return data.BlockEntities.GetValueOrDefault(ToChunkLocalPos(pos));
    }

    public void SetBlock(Vec3<int> pos, IBlock block, IBlockEntityType? blockEntityType = null, INbtTag? blockEntityData = null) {
        if (Immutable) throw new InvalidOperationException("World is immutable, cannot set block.");
        CheckY(pos.Y);

        WorldChangeEvent changeEvent = new() {
            World = this,
            Position = pos,
            OldState = GetBlockOr(pos, Block.Air),
            NewState = block
        };
        Events.CallEvent(changeEvent);

        if (changeEvent.Cancelled) {
            SendBlockUpdate(pos, this);
            return;
        }

        Vec2<int> chunkPos = GetChunkPos(pos);
        ChunkData data = LoadChunkSync(chunkPos);
        Vec3<int> localPos = ToChunkLocalPos(GameToProtocolPos(pos));

        data.SetBlock(localPos, block);
        if (blockEntityType == null) {
            data.BlockEntities.Remove(pos);
        } else {
            data.BlockEntities[pos] = new BlockEntity(
                localPos.X, pos.Y, localPos.Z, blockEntityType, blockEntityData.ThrowIfNull()
            );
        }
        _lighting.Invalidate(chunkPos);

        SendBlockUpdate(pos, this);
    }

    public void SetBlock(Vec3<double> pos, IBlock block, IBlockEntityType? blockEntityType = null, INbtTag? blockEntityData = null) =>
        SetBlock(pos.ToBlockPos(), block, blockEntityType, blockEntityData);

    public void SetBlockData(Vec3<int> pos, BlockEntity? data) {
        if (Immutable) throw new InvalidOperationException("World is immutable, cannot set block data.");
        CheckY(pos.Y);

        Vec2<int> chunkPos = GetChunkPos(pos);
        ChunkData chunk = LoadChunkSync(chunkPos);
        Vec3<int> localPos = ToChunkLocalPos(pos);

        if (data == null) chunk.BlockEntities.Remove(localPos);
        else chunk.BlockEntities[localPos] = data;

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
            ChunkData data = TryGetLoadedChunk(chunkPos)
                ?? throw new InvalidOperationException($"Chunk at {chunkPos} vanished between load and write.");

            indices.Sort((a, b) => localPositions[a].Y.CompareTo(localPositions[b].Y));

            List<BlockUpdate> current = [];
            int? currentSection = null;
            bool anyWritten = false;

            foreach (int idx in indices) {
                if (cancelled[idx]) continue;

                Vec3<int> local = localPositions[idx];
                data.SetBlock(GameToProtocolPos(local), blockUpdates[idx].Block);
                anyWritten = true;

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

            if (currentSection != null && current.Count > 0) {
                packets.Add(new ClientBoundSectionBlocksUpdatePacket {
                    ChunkSectionPosition = new Vec3<int>(chunkPos.X, currentSection.Value, chunkPos.Y),
                    BlockUpdates = current.ToArray()
                });
            }

            if (anyWritten) _lighting.Invalidate(chunkPos);
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

    public Entity DropItem(Vec3<double> pos, ItemStack item) {
        Entity itemEntity = new(EntityType.Item) { Position = pos };
        itemEntity.SetTag(ItemDropTimeTag, DateTime.Now);
        Spawn(itemEntity);
        itemEntity.Meta = new ItemMeta(item);
        return itemEntity;
    }

    #endregion

    #region predicates

    public bool IsBlockLoaded(Vec3<int> pos) {
        CheckY(pos.Y);
        return IsChunkLoaded(GetChunkPos(pos));
    }

    public bool IsChunkLoaded(Vec2<int> pos) {
        return _chunkTasks.TryGetValue(pos, out Task<ChunkData>? t) && t.IsCompletedSuccessfully;
    }

    public bool IsInBounds(Vec3<double> pos) {
        return pos.Y >= Dimension.MinY && pos.Y < _maxY;
    }

    private void CheckY(int y) {
        if (y < Dimension.MinY || y > _maxY) {
            throw new ArgumentOutOfRangeException(nameof(y), "Y position is out of bounds for this dimension.");
        }
    }

    #endregion

    #region chunk_loading

    public Task LoadChunk(Vec2<int> pos) {
        return _chunkTasks.GetOrAdd(pos, static (p, self) => self.BeginLoadAsync(p), this);
    }

    public Task LoadChunks(Vec2<int>[] poses) {
        Task[] tasks = new Task[poses.Length];
        for (int i = 0; i < poses.Length; i++) tasks[i] = LoadChunk(poses[i]);
        return Task.WhenAll(tasks);
    }

    private Task<ChunkData> BeginLoadAsync(Vec2<int> pos) {
        Task<ChunkData> task = Task.Run(() => LoadChunkCore(pos));
        task.ContinueWith(completed => {
            if (completed.IsFaulted) {
                _chunkTasks.TryRemove(pos, out _);
                Exception err = completed.Exception?.InnerException ?? completed.Exception!;
                Server.HandleError(err);
                return;
            }
            OnChunkLoadCompletedOffTick(pos, completed.Result);
        }, TaskContinuationOptions.ExecuteSynchronously);
        return task;
    }

    /// <summary>
    /// Synchronously ensures the chunk is loaded and returns its data. If an async load is already in flight,
    /// blocks on it; otherwise runs the provider inline on the calling thread.
    /// </summary>
    private ChunkData LoadChunkSync(Vec2<int> pos) {
        Task<ChunkData> task = _chunkTasks.GetOrAdd(pos, static (p, self) => self.BeginLoadSync(p), this);
        return task.GetAwaiter().GetResult();
    }

    private Task<ChunkData> BeginLoadSync(Vec2<int> pos) {
        try {
            ChunkData data = LoadChunkCore(pos);
            Task<ChunkData> task = Task.FromResult(data);
            // Schedule the post-load hook off the tick thread so it doesn't run inline under our caller
            // (which is often holding something).
            _ = Task.Run(() => OnChunkLoadCompletedOffTick(pos, data));
            return task;
        } catch {
            // GetOrAdd won't commit on exception, so nothing to clean up.
            throw;
        }
    }

    private ChunkData LoadChunkCore(Vec2<int> pos) {
        ChunkData data = new(Dimension.Height) { ChunkX = pos.X, ChunkZ = pos.Y };
        _provider.GetChunk(ref data);
        if (data == null!) throw new InvalidOperationException($"Terrain provider returned null for chunk {pos}.");
        data.PackData();
        return data;
    }

    /// <summary>
    /// Off-tick completion hook. Builds the chunk packet (including expensive lighting compute) on the
    /// calling (thread-pool) thread, then schedules the enqueue step onto the tick thread so that
    /// interactions with player state are serialized with <see cref="HandlePlayerMove"/>.
    /// Neighbor-lighting resends are run inline on the thread-pool thread: they do more expensive
    /// lighting computations and only touch thread-safe state (chunk store, lighting cache, player
    /// snapshot, connection send), so there's no reason to stall the tick for them.
    /// </summary>
    private void OnChunkLoadCompletedOffTick(Vec2<int> pos, ChunkData data) {
        MinecraftPacket packet = BuildChunkPacket(pos, data);
        Server.Scheduler.ScheduleNextTick(() => EnqueueChunkToPlayers(pos, packet));
        ResendNeighborLighting(pos);
    }

    private void EnqueueChunkToPlayers(Vec2<int> pos, MinecraftPacket packet) {
        Player[] snap = _playersSnapshot;
        foreach (Player player in snap) {
            if (!_playerStates.TryGetValue(player, out PlayerWorldState? state) || state.Disconnected) continue;
            lock (state.Lock) {
                if (state.CurrentChunk == null) continue;
                if (!state.CurrentChunk.Value.IsWithinRadiusOf(pos, _viewDistance)) continue;
                if (!state.LoadedChunks.Add(pos)) continue;  // already sent
                state.PendingPackets.Enqueue(packet);
            }
        }
    }

    private void ResendNeighborLighting(Vec2<int> chunkPos) {
        ReadOnlySpan<Vec2<int>> offsets = [new(1, 0), new(-1, 0), new(0, 1), new(0, -1)];
        foreach (Vec2<int> offset in offsets) {
            Vec2<int> nPos = chunkPos + offset;
            ChunkData? data = TryGetLoadedChunk(nPos);
            if (data == null) continue;

            _lighting.Invalidate(nPos);
            MinecraftPacket packet = BuildChunkPacket(nPos, data);

            foreach (Player viewer in GetViewersOf(nPos)) viewer.SendPacket(packet);
        }
    }

    private ChunkData? TryGetLoadedChunk(Vec2<int> pos) {
        return _chunkTasks.TryGetValue(pos, out Task<ChunkData>? t) && t.IsCompletedSuccessfully ? t.Result : null;
    }

    private MinecraftPacket BuildChunkPacket(Vec2<int> pos, ChunkData data) {
        return new ClientBoundChunkDataAndUpdateLightPacket {
            ChunkX = pos.X,
            ChunkZ = pos.Y,
            Data = data,
            Light = _lighting.GetLighting(pos, data, TryGetLoadedChunk, Server.Registry, Dimension.HasSkyLight)
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
        Player[] snap = _playersSnapshot;
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

    public void SendChunkUpdate(Vec2<int> pos, IAudience audience) {
        ChunkData? data = TryGetLoadedChunk(pos);
        if (data == null) {
            throw new InvalidOperationException($"Chunk at {pos} is not loaded.");
        }
        audience.SendPacket(BuildChunkPacket(pos, data));
    }

    public void SendPacket(MinecraftPacket packet) {
        Player[] snap = _playersSnapshot;
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
        return new Vec3<int>(pos.X, pos.Y - Dimension.MinY, pos.Z);
    }

    #endregion

    #region player_state

    private sealed class PlayerWorldState {
        public Vec2<int>? CurrentChunk;
        public readonly HashSet<Vec2<int>> LoadedChunks = [];
        public readonly Queue<MinecraftPacket> PendingPackets = new();
        public readonly Lock Lock = new();
        public volatile bool Disconnected;
        public Action? CancelMoveListener;
        public Action? DisconnectHandler;
        public int RemovedFlag;    // Interlocked
        public int SendInProgress; // Interlocked — one socket write in flight at a time
    }

    #endregion
}
