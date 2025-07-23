using System.Collections.Concurrent;
using System.Diagnostics;
using ManagedServer.Entities;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Types;
using ManagedServer.Viewables;
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

namespace ManagedServer.Worlds;

public class World : MappedTaggable, IAudience, IFeatureScope {
    // State stuff
    public List<PlayerEntity> Players { get; } = [];
    public EventNode<IServerEvent> Events { get; }
    public readonly EntityManager Entities;
    public required ManagedMinecraftServer Server { get; init; }
    public FeatureHandler FeatureHandler { get; }
    public bool Immutable { get; set; } = false;
    private readonly Dictionary<string, object?> _data = new();

    private readonly ConcurrentDictionary<IVec2, ChunkData> _chunks = new();
    
    // Params
    private readonly ITerrainProvider _provider;
    private readonly int _viewDistance;
    private readonly int _packetsPerTick;
    private readonly int _tickDelayMs;
    public readonly Identifier DimensionId;
    
    public Dimension Dimension => Server.Dimensions[DimensionId];
    
    // Props
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

    internal World(EventNode<IServerEvent> baseEventNode, ITerrainProvider provider, Identifier dimensionId, int viewDistance = 8, int packetsPerTick = 10, int tickDelayMs = 100) {
        _provider = provider;
        _viewDistance = viewDistance;
        _packetsPerTick = packetsPerTick;
        _tickDelayMs = tickDelayMs;
        DimensionId = dimensionId;
        Events = baseEventNode.CreateChild<IWorldEvent>(e => e.World == this);
        Entities = new EntityManager(Events, viewDistance*16);
        FeatureHandler = new FeatureHandler(this);
    }

    // Data storage tags
    /// <summary>
    /// Should store the time when an item was dropped. It will be set to <see cref="DateTime.Now"/> when the item is dropped.
    /// </summary>
    public static readonly Tag<DateTime> ItemDropTimeTag = new("minecraftdotnet:world:item_drop_time");
    private static readonly Tag<HashSet<IVec2>> LoadedChunksTag = new("minecraftdotnet:world:loadedchunks");
    private static readonly Tag<Queue<MinecraftPacket>> WaitingPacketsTag = new("minecraftdotnet:world:waitingpackets");
    private static readonly Tag<Action> CancelListenersActionTag = new("minecraftdotnet:world:cancellistener");
    
    // Some fun constants
    private int UnloadDistance => _viewDistance + UnloadDistanceMod;
    private const bool Benchmark = true;
    private const bool Debug = false;
    private const int UnloadDistanceMod = 1;  // Used to reduce the number of packets needed when travelling back and forth

    private void Log(string msg) {
        if (Debug) Console.WriteLine("[WORLD] " + msg);
    }
    
    public void AddPlayer(PlayerEntity player) {
        PlayerConnection connection = player.Connection;
        
        player.SendPacket(new ClientBoundUpdateTimePacket {
            ClientAdvanceTime = false,
            TimeOfDay = _time,
            WorldAge = _time
        });
        
        _ = Entities.InformNewPlayer(connection);
        SetPlayerLoadedChunks(connection, []);  // reset, just in case they were in a different world
        connection.SendPacket(new ClientBoundGameEventPacket {
            Event = GameEvent.StartWaitingForLevelChunks,
            Value = 0f
        });
        Queue<MinecraftPacket> waitingPackets = new();
        connection.SetTag(WaitingPacketsTag, waitingPackets);

        bool disconnected = false;
        connection.Disconnected += () => disconnected = true;
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
                connection.SendPackets(false, packets.ToArray());
                Log("Waiting packets: " + waitingPackets.Count + $" (Did in {sw.ElapsedMilliseconds})");
            }
        });
        Action cancelAction = null!;
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
            
            IVec2 chunkPos = new((int)Math.Floor(e.NewPos.X / 16), (int)Math.Floor(e.NewPos.Z / 16));
            HandlePlayerMove(pe.Connection, chunkPos);
        });
        player.Connection.SetTag(CancelListenersActionTag, cancelAction);
        Players.Add(player);
    }

    public void HandlePlayerMove(PlayerConnection connection, IVec2 chunkPos) {
        Stopwatch sw;
        int unloadingBench;
        if (Benchmark) {
            sw = Stopwatch.StartNew();
        }
        
        HashSet<IVec2> loaded = GetPlayerLoadedChunks(connection);
        // Console.WriteLine($"{loaded.Count} chunks are loaded");

        List<MinecraftPacket> neededPackets = [];
        List<IVec2> unloaded = [];
        foreach (IVec2 loadedChunk in loaded) {
            if (loadedChunk.IsWithinRadiusOf(chunkPos, UnloadDistance)) continue;
            
            neededPackets.Add(new ClientBoundUnloadChunkPacket {
                X = loadedChunk.X,
                Z = loadedChunk.Z
            });  // not within radius, unload it
            unloaded.Add(loadedChunk);
            // Console.WriteLine($"Unloading {loadedChunk.X}, {loadedChunk.Z}");
        }
        foreach (IVec2 c in unloaded) {
            loaded.Remove(c);
        }

        if (Benchmark) unloadingBench = (int)sw.ElapsedMilliseconds;
    
        // Okay, now get everything that should be loaded
        IVec2[] toLoad = new IVec2[(_viewDistance*2+1)*(_viewDistance*2+1)];
        int i = 0;
        for (int x = 0; x < _viewDistance * 2 + 1; x++) {
            for (int z = 0; z < _viewDistance * 2 + 1; z++) {
                IVec2 chunk = new(x + chunkPos.X - _viewDistance, z + chunkPos.Z - _viewDistance);
                
                if (!loaded.Contains(chunk)) {
                    // okay, so we need to load chunk
                    toLoad[i++] = chunk;
                    loaded.Add(chunk);
                    // Console.WriteLine($"Loading {chunk.X}, {chunk.Z}");
                }
            }
        }

        if (i != 0) AddChunkPackets(toLoad, i, neededPackets);

        if (neededPackets.Count == 0) return;  // don't bother if nothing changed
        
        if (Benchmark) {
            Log($"Terrain packet generation took {sw.ElapsedMilliseconds}ms, unloading: {unloadingBench}ms");
        }
        
        SetPlayerLoadedChunks(connection, loaded);
        
        neededPackets.Add(new ClientBoundSetCenterChunkPacket {
            X = chunkPos.X,
            Z = chunkPos.Z
        });
        
        IEnumerable<MinecraftPacket> orderedPackets = neededPackets.OrderBy(p => {
            if (p is ClientBoundSetCenterChunkPacket) return 0;  // always do this first, otherwise we could get issues
            if (p is not ClientBoundChunkDataAndUpdateLightPacket chunkP) return 100;  // do unload packets last (for faster load, client unloads anyway)
            return new IVec2(chunkP.ChunkX, chunkP.ChunkZ).DistanceTo(chunkPos);  // do closer chunks first for quicker load
        });
        
        Queue<MinecraftPacket> waitingPackets = connection.GetTag(WaitingPacketsTag);
        foreach (MinecraftPacket packet in orderedPackets) {
            waitingPackets.Enqueue(packet);
        }
    }

    public void RemovePlayer(PlayerEntity player) {
        Players.Remove(player);
        player.Connection.GetTag(CancelListenersActionTag).Invoke();  // stop listening
    }

    public void Spawn(Entity entity, int? id = null) {
        Entities.Spawn(entity, id);
    }

    private static HashSet<IVec2> GetPlayerLoadedChunks(PlayerConnection connection) {
        if (!connection.HasTag(LoadedChunksTag)) {
            throw new Exception("Loaded chunks don't exist");
        }
        return connection.GetTag(LoadedChunksTag);
    }

    private static void SetPlayerLoadedChunks(PlayerConnection connection, HashSet<IVec2> chunks) {
        connection.SetTag(LoadedChunksTag, chunks);
    }

    public void SetBlock(IVec3 pos, IBlock block) {
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
        
        IVec2 chunk = GetChunkPos(pos);
        LoadChunk(chunk);
        RetrieveChunk(chunk)!.SetBlock(ToChunkLocalPos(GameToProtocolPos(pos)), block);
        
        SendBlockUpdate(pos, this);
    }
    
    public void SetBlock(Vec3 pos, IBlock block) {
        // Convert Vec3 to IVec3
        SetBlock(pos.ToBlockPos(), block);
    }
    
    private static IVec3 ToChunkLocalPos(IVec3 pos) {
        return new IVec3((pos.X % 16 + 16) % 16, pos.Y, (pos.Z % 16 + 16) % 16);
    }
    
    public IBlock GetBlock(IVec3 pos) {
        CheckY(pos.Y);
        
        IVec2 chunk = GetChunkPos(pos);
        LoadChunk(chunk);
        IVec3 chunkLocalPos = ToChunkLocalPos(GameToProtocolPos(pos));
        return RetrieveChunk(chunk)!.LookupBlock(chunkLocalPos, Server.Registry);
    }

    private void CheckY(int y) {
        if (y < Dimension.MinY || y > Dimension.MinY + Dimension.Height) {
            throw new ArgumentOutOfRangeException(nameof(y), "Y position is out of bounds for this dimension.");
        }
    }
    
    public IBlock GetBlock(Vec3 pos) {
        // Convert Vec3 to IVec3
        return GetBlock(pos.ToBlockPos());
    }
    
    // get everyone who can see the block at the given position
    public IAudience GetViewersOf(IVec3 pos) {
        int blockRange = _viewDistance * 16;
        List<PlayerEntity> viewers = [];
        viewers.AddRange(Players.Where(player => player.Position.DistanceTo(pos) <= blockRange));
        // ReSharper disable once CoVariantArrayConversion
        return new AudiencesList(viewers.ToArray());
    }
    
    public IVec2 GetChunkPos(Vec3 pos) {
        return new IVec2((int)Math.Floor(pos.X / 16), (int)Math.Floor(pos.Z / 16));
    }

    /// <summary>
    /// Converts a protocol position to a game position.
    /// <p/>
    /// This is used because in the protocol Y=0 is Y=-64 in game.
    /// </summary>
    /// <param name="pos">The position to convert</param>
    /// <returns>The new position.</returns>
    public static IVec3 ProtocolToGamePos(IVec3 pos) {
        return new IVec3(pos.X, pos.Y - 64, pos.Z);
    }
    
    private static IVec3 GameToProtocolPos(IVec3 pos) {
        return new IVec3(pos.X, pos.Y + 64, pos.Z);
    }

    private ChunkData[] GetChunks(IVec2[] poses, int count) {
        lock (_chunks) {
            ChunkData[] chunks = new ChunkData[count];
            IVec2[] needed = new IVec2[count];
            int notFound = 0;
            int cChunksPos = 0;
            for (int i = 0; i < count; i++) {
                ChunkData? data = RetrieveChunk(poses[i]);
                if (data == null) {
                    needed[notFound++] = poses[i];
                    continue;
                }
                chunks[cChunksPos++] = data;
            }
            if (notFound == 0) {
                return chunks;
            }
            
            System.Diagnostics.Debug.Assert(chunks.Length == cChunksPos + notFound);
        
            // We need to load some chunks, fill the null ones with blank data
            for (int i = cChunksPos; i < count; i++) {
                chunks[i] = new ChunkData(Dimension.Height) {
                    ChunkX = poses[i].X,
                    ChunkZ = poses[i].Z
                };
            }
            _provider.GetChunks(cChunksPos, notFound, chunks);
            for (int i = cChunksPos; i < count; i++) {
                chunks[i].PackData();
                _chunks.TryAdd(new IVec2(chunks[i].ChunkX, chunks[i].ChunkZ), chunks[i]);
            }

            return chunks;
        }
    }

    public void SendBlockUpdate(IVec3 pos, IAudience audience) {
        audience.SendPacket(new ClientBoundBlockUpdatePacket {
            Block = GetBlock(pos),
            Location = pos
        });
    }
    
    private ChunkData? RetrieveChunk(IVec2 pos) {
        _chunks.TryGetValue(pos, out ChunkData? data);
        return data;
    }
    
    public void LoadChunk(IVec2 pos) {
        if (_chunks.ContainsKey(pos)) return;  // already loaded

        lock (_chunks) {
            ChunkData data = new(Dimension.Height) {
                ChunkX = pos.X,
                ChunkZ = pos.Z
            };
            _provider.GetChunk(data);
            if (data == null) {
                throw new Exception($"Failed to load chunk at {pos}");
            }
        
            Console.WriteLine("Manually loading chunk at " + pos);
            data.PackData();
            _chunks.TryAdd(pos, data);
        }
    }

    public ClientBoundChunkDataAndUpdateLightPacket GetChunkPacket(IVec2 pos) {
        ClientBoundChunkDataAndUpdateLightPacket packet = new() {
            ChunkX = pos.X,
            ChunkZ = pos.Z,
            Data = GetChunks([pos], 1)[0],
            Light = LightData.FullBright
        };
        return packet;
    }
    
    public void AddChunkPackets(IVec2[] poses, int count, List<MinecraftPacket> list) {
        foreach (ChunkData data in GetChunks(poses, count)) {
            list.Add(new ClientBoundChunkDataAndUpdateLightPacket{
                ChunkX = data.ChunkX,
                ChunkZ = data.ChunkZ,
                Data = data,
                Light = LightData.FullBright
            });
        }
    }

    public void StrikeLightning(Vec3 pos) {
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
    
    public Entity DropItem(Vec3 pos, ItemStack item) {
        Entity itemEntity = new(EntityType.Item) {
            Position = pos
        };
        itemEntity.SetTag(ItemDropTimeTag, DateTime.Now);
        Spawn(itemEntity);

        ItemMeta meta = new(item) {
            NoGravity = true
        };
        itemEntity.Meta = meta;
        return itemEntity;
    }

    public void SendPacket(MinecraftPacket packet) {
        foreach (PlayerEntity player in Players) {
            player.SendPacket(packet);
        }
    }
}
