using System.Collections.Concurrent;
using System.Diagnostics;
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
using Minecraft.Data.Generated;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using NBT;

// Disable warnings: unreachable code is for debugging, and this is an API, so we want to keep the members public
#pragma warning disable CS0162 // Unreachable code detected
// ReSharper disable HeuristicUnreachableCode
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Local

namespace ManagedServer.Worlds;

public class World : MappedTaggable, IAudience, IFeatureScope {
    // Props
    public List<PlayerEntity> Players { get; } = [];
    public EventNode<IServerEvent> Events { get; }
    public EntityManager Entities { get; }
    public ManagedMinecraftServer Server { get; init; }
    public FeatureHandler FeatureHandler { get; }
    public Identifier DimensionId { get; }
    public bool Immutable { get; set; } = false;
    
    private int _time;
    public int Time {
        get => _time;
        set {
            _time = value;
            SendPacket(new ClientBoundUpdateTimePacket {
                ClientAdvanceTime = false,
                TimeOfDay = _time,
                WorldAge = _time
            });
        }
    }
    
    // Params
    private readonly ITerrainProvider _provider;
    private readonly int _viewDistance;
    private readonly int _packetsPerTick;
    private readonly int _tickDelayMs;
    private readonly ILightingProvider _lighting;
    
    // dimension will be set in constructor
    public Dimension Dimension => Server.Dimensions[DimensionId];
    private readonly int _maxY;
    
    // The actual data
    private readonly ConcurrentDictionary<Vec2<int>, ChunkData> _chunks = new();
    private readonly ConcurrentDictionary<Vec2<int>, Task> _chunkLoadingTasks = new();

    // Data storage tags
    /// <summary>
    /// Should store the time when an item was dropped. It will be set to <see cref="DateTime.Now"/> when the item is dropped.
    /// </summary>
    public static readonly Tag<DateTime> ItemDropTimeTag = new("minecraftdotnet:world:item_drop_time");
    private static readonly Tag<HashSet<Vec2<int>>> LoadedChunksTag = new("minecraftdotnet:world:loadedchunks");
    private static readonly Tag<Queue<MinecraftPacket>> WaitingPacketsTag = new("minecraftdotnet:world:waitingpackets");
    private static readonly Tag<Action> CancelListenersActionTag = new("minecraftdotnet:world:cancellistener");
    private static readonly Tag<Vec2<int>> CurrentChunkTag = new("minecraftdotnet:world:currentchunk");
    
    // Some fun constants
    private int UnloadDistance => _viewDistance + UnloadDistanceMod;
    private const bool Benchmark = false;
    private const bool Debug = false;
    private const int UnloadDistanceMod = 1;  // Used to reduce the number of packets needed when travelling back and forth

    // basic log method, can be replaced with something better later
    private static void Log(string msg) {
        if (Debug) Console.WriteLine("[WORLD] " + msg);
    }
    
    internal World(ManagedMinecraftServer server, EventNode<IServerEvent> baseEventNode, ITerrainProvider provider, 
        Identifier dimensionId, ILightingProvider? lighting = null, int viewDistance = 8, int packetsPerTick = 10, int tickDelayMs = 100) {
        
        _provider = provider;
        _viewDistance = viewDistance;
        _packetsPerTick = packetsPerTick;
        _tickDelayMs = tickDelayMs;
        _lighting = lighting ?? new FullBrightLightingProvider();
        Server = server;
        DimensionId = dimensionId;
        Events = baseEventNode.CreateChild<IWorldEvent>(e => e.World == this);
        Entities = new EntityManager(Events, viewDistance*16);
        FeatureHandler = new FeatureHandler(this);

        if (!Server.Dimensions.ContainsKey(DimensionId)) {
            throw new ArgumentException($"Dimension {DimensionId} does not exist in the server's dimensions.");
        }

        _maxY = Dimension.MinY + Dimension.Height;  // precompute this so we don't have to do it every time

        Events.AddListener<ServerTickEvent>(_ => Tick());
    }

    private void Tick() {
        // do nothing for now
        // but maybe handle time and player packet sending here?
    }

    #region player_handling
    
    public virtual void AddPlayer(PlayerEntity player) {
        Log("Adding player " + player.Name + " to world " + DimensionId);
        PlayerEnteringWorldEvent enterEvent = new() {
            Player = player,
            World = this
        };
        Events.CallEvent(enterEvent);
        
        player.SendPacket(new ClientBoundUpdateTimePacket {
            ClientAdvanceTime = false,
            TimeOfDay = _time,
            WorldAge = _time
        });
        
        Entities.InformNewPlayer(player);
        SetPlayerLoadedChunks(player.Connection, []);  // reset, just in case they were in a different world
        player.SendPacket(new ClientBoundGameEventPacket {
            Event = GameEvent.StartWaitingForLevelChunks,
            Value = 0f
        });
        Queue<MinecraftPacket> waitingPackets = new();
        player.Connection.SetTag(WaitingPacketsTag, waitingPackets);

        bool disconnected = false;
        player.Connection.Disconnected += () => disconnected = true;
        
        // TODO: Don't use threads, use the tick system or manage it better (investigate performance)
        Task.Run(async () => {
            Stopwatch sw = Stopwatch.StartNew();
            while (!disconnected) {
                await Task.Delay(Math.Max(_tickDelayMs - (int)sw.ElapsedMilliseconds, 0));
                sw.Restart();
                if (waitingPackets.Count == 0) {
                    continue;
                }

                List<MinecraftPacket> packets = [];
                for (int i = 0; i < _packetsPerTick; i++) {
                    waitingPackets.TryDequeue(out MinecraftPacket? result);
                    if (result == null) break;
                    
                    packets.Add(result);
                }

                // Console.WriteLine($"Sending {packets.Count} packets for terrain");
                player.SendPackets(packets.ToArray());
                Log("Waiting packets: " + waitingPackets.Count + $" (Did in {sw.ElapsedMilliseconds})");
            }
        });
        Action cancelAction = null!;
        Log("Registering player move listener for " + player.Name);
        cancelAction = player.Events.AddListener<EntityMoveEvent>(e => {
            if (e.Entity is not PlayerEntity pe) {
                throw new Exception("Entity is not PlayerEntity (called on PlayerEntity eventnode)");
            }
            
            // are they no longer in this world?
            if (!Players.Contains(pe)) {
                Console.WriteLine("Weird race condition, EXISTING LISTENER");
                cancelAction();
                return;
            }
            
            Vec2<int> chunkPos = new((int)Math.Floor(e.NewPos.X / 16), (int)Math.Floor(e.NewPos.Z / 16));
            HandlePlayerMove(pe.Connection, chunkPos);
        });
        player.Connection.SetTag(CancelListenersActionTag, cancelAction);
        Players.Add(player);
        
        // Start sending chunks
        HandlePlayerMove(player.Connection, GetChunkPos(player.Position));
    }

    public void HandlePlayerMove(PlayerConnection connection, Vec2<int> chunkPos) {
        if (connection.HasTag(CurrentChunkTag) && connection.GetTagOrNull(CurrentChunkTag) == chunkPos) {
            // they haven't moved
            return;
        }
        connection.SetTag(CurrentChunkTag, chunkPos);
        
        Stopwatch sw;
        int unloadingBench;
        if (Benchmark) {
            sw = Stopwatch.StartNew();
        }
        
        Log("Handling player move to chunk " + chunkPos);
        HashSet<Vec2<int>> loaded = GetPlayerLoadedChunks(connection);
        // Console.WriteLine($"{loaded.Count} chunks are loaded");

        List<MinecraftPacket> neededPackets = [];
        List<Vec2<int>> unloaded = [];
        foreach (Vec2<int> loadedChunk in loaded) {
            if (loadedChunk.IsWithinRadiusOf(chunkPos, UnloadDistance)) continue;
            
            neededPackets.Add(new ClientBoundUnloadChunkPacket {
                X = loadedChunk.X,
                Z = loadedChunk.Y
            });  // not within radius, unload it
            unloaded.Add(loadedChunk);
            // Console.WriteLine($"Unloading {loadedChunk.X}, {loadedChunk.Z}");
        }
        foreach (Vec2<int> c in unloaded) {
            loaded.Remove(c);
        }

        if (Benchmark) unloadingBench = (int)sw.ElapsedMilliseconds;
    
        // Okay, now get everything that should be loaded
        Vec2<int>[] toLoad = new Vec2<int>[(_viewDistance*2+1)*(_viewDistance*2+1)];
        int i = 0;
        for (int x = 0; x < _viewDistance * 2 + 1; x++) {
            for (int z = 0; z < _viewDistance * 2 + 1; z++) {
                Vec2<int> chunk = new(x + chunkPos.X - _viewDistance, z + chunkPos.Y - _viewDistance);
                
                if (!loaded.Contains(chunk)) {
                    // okay, so we need to load chunk
                    toLoad[i++] = chunk;
                }
            }
        }

        if (i != 0) AddChunkPackets(toLoad, i, neededPackets);

        if (neededPackets.Count == 0) return;  // don't bother if nothing changed
        
        neededPackets.Add(new ClientBoundSetCenterChunkPacket {
            X = chunkPos.X,
            Z = chunkPos.Y
        });
        
        IEnumerable<MinecraftPacket> orderedPackets = neededPackets.OrderBy(p => {
            if (p is ClientBoundSetCenterChunkPacket) return 0;  // always do this first, otherwise we could get issues
            if (p is not ClientBoundChunkDataAndUpdateLightPacket chunkP) return 100;  // do unload packets last (for faster load, client unloads anyway)
            return new Vec2<int>(chunkP.ChunkX, chunkP.ChunkZ).DistanceTo(chunkPos);  // do closer chunks first for quicker load
        });
        
        Queue<MinecraftPacket> waitingPackets = connection.GetTag(WaitingPacketsTag);
        foreach (MinecraftPacket packet in orderedPackets) {
            if (packet is ClientBoundChunkDataAndUpdateLightPacket chunkDataPacket) {
                loaded.Add(new Vec2<int>(chunkDataPacket.ChunkX, chunkDataPacket.ChunkZ));
            }
            waitingPackets.Enqueue(packet);
        }
        
        SetPlayerLoadedChunks(connection, loaded);
        
        if (Benchmark) {
            Log($"Terrain packet generation took {sw.ElapsedMilliseconds}ms ({neededPackets.Count} packets), unloading: {unloadingBench}ms");
        }
    }

    public virtual void RemovePlayer(PlayerEntity player) {
        PlayerLeavingWorldEvent leaveEvent = new() {
            Player = player,
            World = this
        };
        Events.CallEvent(leaveEvent);
        
        Players.Remove(player);
        player.Connection.GetTag(CancelListenersActionTag).Invoke();  // stop listening
    }

    public void ResetPlayer(PlayerEntity player) {
        SetPlayerLoadedChunks(player.Connection, []);
        
        player.SendPacket(new ClientBoundGameEventPacket {
            Event = GameEvent.StartWaitingForLevelChunks,
            Value = 0f
        });
        
        HandlePlayerMove(player.Connection, GetChunkPos(player.Position));
    }

    private static HashSet<Vec2<int>> GetPlayerLoadedChunks(PlayerConnection connection) {
        if (!connection.HasTag(LoadedChunksTag)) {
            throw new Exception("Loaded chunks don't exist");
        }
        return connection.GetTag(LoadedChunksTag);
    }

    private static void SetPlayerLoadedChunks(PlayerConnection connection, HashSet<Vec2<int>> chunks) {
        connection.SetTag(LoadedChunksTag, chunks);
    }
    
    #endregion

    #region data_accessors

    public IBlock GetBlock(Vec3<int> pos) {
        CheckY(pos.Y);
        
        Vec2<int> chunk = GetChunkPos(pos);
        Vec3<int> chunkLocalPos = ToChunkLocalPos(GameToProtocolPos(pos));

        ChunkData? data = RetrieveChunk(chunk);
        if (data == null) {
            throw new InvalidOperationException($"Chunk at {chunk} is not loaded. Please load the chunk before accessing blocks.");
        }
        
        return data.LookupBlock(chunkLocalPos, Server.Registry);
    }
    
    public IBlock GetBlock(Vec3<double> pos) {
        // Convert Vec3 to IVec3
        return GetBlock(pos.ToBlockPos());
    }

    public async Task<IBlock> GetBlockWithLoad(Vec3<int> pos) {
        await LoadChunk(GetChunkPos(pos));
        return GetBlock(pos);
    }

    public IBlock GetBlockOr(Vec3<int> pos, IBlock def) {
        return IsInBounds(pos) ? IsBlockLoaded(pos) ? GetBlock(pos) : def : def;
    }
    
    public IBlock GetBlockOr(Vec3<double> pos, IBlock def) {
        return GetBlockOr(pos.ToBlockPos(), def);
    }
    
    public BlockEntity? GetBlockData(Vec3<int> pos) {
        CheckY(pos.Y);
        
        Vec2<int> chunk = GetChunkPos(pos);
        LoadChunk(chunk);
        Vec3<int> chunkLocalPos = ToChunkLocalPos(pos);
        return RetrieveChunk(chunk)!.BlockEntities!.GetValueOrDefault(chunkLocalPos, null);
    }
    
    public void SetBlock(Vec3<int> pos, IBlock block, IBlockEntityType? blockEntityType = null, INbtTag? blockEntityData = null) {
        if (Immutable) {
            throw new InvalidOperationException("World is immutable, cannot set block.");
        }
        CheckY(pos.Y);
        
        // event
        WorldChangeEvent changeEvent = new() {
            World = this,
            Position = pos,
            OldState = GetBlock(pos),
            NewState = block
        };
        Events.CallEvent(changeEvent);
        
        if (changeEvent.Cancelled) {
            // don't change the block, send update to client
            SendBlockUpdate(pos, this);
            return;
        }
        
        Vec2<int> chunk = GetChunkPos(pos);
        Vec3<int> localPos = ToChunkLocalPos(GameToProtocolPos(pos));  // local protocol pos (y is 0 indexed)
        
        LoadChunk(chunk);
        ChunkData data = RetrieveChunk(chunk)!;
        data.SetBlock(localPos, block);
        if (blockEntityType == null) {
            data.BlockEntities.Remove(pos);
        }
        else {
            data.BlockEntities[pos] = new BlockEntity(
                // local Y is game coords not protocol coords
                localPos.X, pos.Y, localPos.Z, blockEntityType, blockEntityData.ThrowIfNull()
            );
        }
        
        SendBlockUpdate(pos, this);
    }
    
    public void SetBlock(Vec3<double> pos, IBlock block, IBlockEntityType? blockEntityType = null, INbtTag? blockEntityData = null) {
        // Convert Vec3 to IVec3
        SetBlock(pos.ToBlockPos(), block, blockEntityType, blockEntityData);
    }
    
    public void SetBlockData(Vec3<int> pos, BlockEntity? data) {
        if (Immutable) {
            throw new InvalidOperationException("World is immutable, cannot set block data.");
        }
        CheckY(pos.Y);
        
        Vec2<int> chunk = GetChunkPos(pos);
        LoadChunk(chunk);
        Vec3<int> chunkLocalPos = ToChunkLocalPos(pos);
        ChunkData chunkData = RetrieveChunk(chunk)!;
        
        if (data == null) {
            chunkData.BlockEntities.Remove(chunkLocalPos);
        }
        else {
            chunkData.BlockEntities[chunkLocalPos] = data;
        }
        
        SendBlockUpdate(pos, this);
    }

    #endregion

    #region conversions

    // non-static so that you can use it with the world instance
    // eg. world.GetChunkPos instead of World.GetChunkPos
    // I think it's nicer this way
    public Vec2<int> GetChunkPos(Vec3<double> pos) {
        return new Vec2<int>((int)Math.Floor(pos.X / 16), (int)Math.Floor(pos.Z / 16));
    }
    
    private static Vec3<int> ToChunkLocalPos(Vec3<int> pos) {
        return new Vec3<int>((pos.X % 16 + 16) % 16, pos.Y, (pos.Z % 16 + 16) % 16);
    }

    /// <summary>
    /// Converts a protocol position to a game position.
    /// <p/>
    /// This is used because in the protocol Y=0 is Y=-64 in game.
    /// </summary>
    /// <param name="pos">The position to convert</param>
    /// <returns>The new position.</returns>
    private Vec3<int> ProtocolToGamePos(Vec3<int> pos) {
        return new Vec3<int>(pos.X, pos.Y + Dimension.MinY, pos.Z);
    }
    
    private Vec3<int> GameToProtocolPos(Vec3<int> pos) {
        return new Vec3<int>(pos.X, pos.Y - Dimension.MinY, pos.Z);
    }

    #endregion

    #region public_utilities
    
    public void Spawn(Entity entity, int? id = null) {
        if (id != null) entity.NetId = id.Value;
        entity.SetWorld(this);
    }

    public void StrikeLightning(Vec3<double> pos) {
        Entity lightning = new(EntityType.LightningBolt) {
            Position = pos,
            Yaw = Angle.Zero,
            Pitch = Angle.Zero,
            NetId = Entities.NewNetId
        };
        Spawn(lightning);
        
        Server.Scheduler.ScheduleTask(TimeSpan.FromSeconds(2), () => {
            lightning.Despawn();
        });
    }
    
    public Entity DropItem(Vec3<double> pos, ItemStack item) {
        Entity itemEntity = new(EntityType.Item) {
            Position = pos
        };
        itemEntity.SetTag(ItemDropTimeTag, DateTime.Now);
        Spawn(itemEntity);

        ItemMeta meta = new(item);
        itemEntity.Meta = meta;
        return itemEntity;
    }

    #endregion

    #region checks

    public bool IsBlockLoaded(Vec3<int> pos) {
        CheckY(pos.Y);
        
        Vec2<int> chunk = GetChunkPos(pos);
        return IsChunkLoaded(chunk);
    }
    
    public bool IsChunkLoaded(Vec2<int> pos) {
        return _chunks.ContainsKey(pos);
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

    private Span<ChunkData> GetChunks(Vec2<int>[] poses, int count) {
        ChunkData[] chunks = new ChunkData[count];
        int cChunksPos = 0;
        for (int i = 0; i < count; i++) {
            ChunkData? data = RetrieveChunk(poses[i]);
            if (data == null) {
                LoadChunk(poses[i]);
                continue;
            }
            chunks[cChunksPos++] = data;
        }
        
        return new Span<ChunkData>(chunks, 0, cChunksPos);
    }

    private Task LoadChunks(Vec2<int>[] poses) {
        List<Task> tasks = [];
        foreach (Vec2<int> pos in poses) {
            if (_chunks.ContainsKey(pos)) continue;  // already loaded
            
            if (_chunkLoadingTasks.TryGetValue(pos, out Task? existingTask)) {
                tasks.Add(existingTask);
                continue;  // already loading
            }
            
            // Is doing them all in parallel the best way?
            Task newTask = LoadChunk(pos);
            tasks.Add(newTask);
            AddChunkLoadListener(pos, newTask);
        }
        
        return Task.WhenAll(tasks);
    }

    private Task LoadChunk(Vec2<int> pos) {
        if (_chunks.ContainsKey(pos)) return Task.CompletedTask;  // already loaded

        if (_chunkLoadingTasks.TryGetValue(pos, out Task? existingTask)) {
            return existingTask;  // already loading
        }
        
        Task task = Task.Run(() => {
            ChunkData data = new(Dimension.Height) {
                ChunkX = pos.X,
                ChunkZ = pos.Y
            };
            _provider.GetChunk(ref data);
            if (data == null) {
                throw new Exception($"Failed to load chunk at {pos}");
            }
        
            data.PackData();
            _chunks.TryAdd(pos, data);
        });
        
        AddChunkLoadListener(pos, task);
        return task;
    }

    private void AddChunkLoadListener(Vec2<int> chunkPos, Task task) {
        _chunkLoadingTasks.TryAdd(chunkPos, task);
        task.ContinueWith(_ => {
            GetViewersOf(chunkPos).SendPacket(new ClientBoundChunkDataAndUpdateLightPacket {
                ChunkX = chunkPos.X,
                ChunkZ = chunkPos.Y,
                Data = RetrieveChunk(chunkPos)!,
                Light = _lighting.GenerateLighting(RetrieveChunk(chunkPos)!, this)
            });
        });
    }
    
    private ChunkData? RetrieveChunk(Vec2<int> pos) {
        _chunks.TryGetValue(pos, out ChunkData? data);
        return data;
    }

    #endregion

    #region viewers

    public IAudience GetViewersOf(Vec2<int> chunkPos) {
        int blockRange = _viewDistance * 16;
        List<PlayerEntity> viewers = [];
        viewers.AddRange(Players.Where(player => GetChunkPos(player.Position).IsWithinRadiusOf(chunkPos, blockRange)));
        // ReSharper disable once CoVariantArrayConversion
        return new AudiencesList(viewers.ToArray());
    }
    
    // get everyone who can see the block at the given position
    public IAudience GetViewersOf(Vec3<int> pos) {
        int blockRange = _viewDistance * 16;
        List<PlayerEntity> viewers = [];
        viewers.AddRange(Players.Where(player => player.Position.DistanceTo2D(pos) <= blockRange));
        // ReSharper disable once CoVariantArrayConversion
        return new AudiencesList(viewers.ToArray());
    }

    public void SendBlockUpdate(Vec3<int> pos, IAudience audience) {
        audience.SendPacket(new ClientBoundBlockUpdatePacket {
            Block = GetBlock(pos),
            Location = pos
        });
        
        BlockEntity? data = GetBlockData(pos);
        if (data != null) {
            Server.Scheduler.ScheduleNextTick(() => {
                // Check it again just in case it was changed since the tick
                BlockEntity? updatedData = GetBlockData(pos);
                if (updatedData == null) {
                    return;  // no data, nothing to send
                }
                audience.SendPacket(new ClientBoundBlockEntityDataPacket {
                    Position = pos,
                    Data = updatedData.Data,
                    Type = updatedData.Type
                });
            });
        }
    }
    
    public void SendChunkUpdate(Vec2<int> pos, IAudience audience) {
        if (!IsChunkLoaded(pos)) {
            throw new InvalidOperationException($"Chunk at {pos} is not loaded.");
        }
        
        ChunkData? data = RetrieveChunk(pos);
        if (data == null) {
            throw new InvalidOperationException($"Chunk data for {pos} is null.");
        }
        
        audience.SendPacket(new ClientBoundChunkDataAndUpdateLightPacket {
            ChunkX = pos.X,
            ChunkZ = pos.Y,
            Data = data,
            Light = _lighting.GenerateLighting(data, this)
        });
    }

    #endregion

    #region packets

    private void AddChunkPackets(Vec2<int>[] poses, int count, List<MinecraftPacket> list) {
        foreach (ChunkData data in GetChunks(poses, count)) {
            list.Add(new ClientBoundChunkDataAndUpdateLightPacket {
                ChunkX = data.ChunkX,
                ChunkZ = data.ChunkZ,
                Data = data,
                Light = _lighting.GenerateLighting(data, this)
            });
        }
    }

    public void SendPacket(MinecraftPacket packet) {
        foreach (PlayerEntity player in Players) {
            player.SendPacket(packet);
        }
    }

    #endregion
}
