using System.Collections.Concurrent;
using System.Diagnostics;
using ManagedServer.Entities;
using ManagedServer.Entities.Events;
using ManagedServer.Entities.Types;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds;

public class World : IViewable {
    // State stuff
    public readonly List<PlayerEntity> Players = [];
    public readonly EventNode<IServerEvent> Events;
    public readonly EntityManager Entities;
    public required ManagedMinecraftServer? Server;

    private readonly ConcurrentDictionary<IVec2, ChunkData> _chunks = new();
    
    // Params
    private readonly ITerrainProvider _provider;
    private readonly int _viewDistance;
    private readonly int _packetsPerTick;
    private readonly int _tickDelayMs;

    internal World(EventNode<IServerEvent> baseEventNode, ITerrainProvider provider, int viewDistance = 8, int packetsPerTick = 10, int tickDelayMs = 100) {
        _provider = provider;
        _viewDistance = viewDistance;
        _packetsPerTick = packetsPerTick;
        _tickDelayMs = tickDelayMs;
        Events = new EventNode<IServerEvent>(baseEventNode);
        Entities = new EntityManager(Events, viewDistance*16);
    }

    // Data storage tags
    private static readonly Tag<HashSet<IVec2>> LoadedChunksTag = new("minecraftdotnet:world:loadedchunks");
    private static readonly Tag<Queue<MinecraftPacket>> WaitingPacketsTag = new("minecraftdotnet:world:waitingpackets");
    private static readonly Tag<Action> CancelListenersActionTag = new("minecraftdotnet:world:cancellistener");
    
    // Some fun constants
    private int UnloadDistance => _viewDistance + UnloadDistanceMod;
    private const bool Benchmark = true;
    private const int UnloadDistanceMod = 1;  // Used to reduce the number of packets needed when travelling back and forth

    public void EnsureServer() {
        if (Server == null) {
            throw new Exception("Add");
        }
    }
    
    public void AddFeature(IWorldFeature feature) {
        feature.Register(this);
    }
    
    public void AddPlayer(PlayerEntity player) {
        PlayerConnection connection = player.Connection;
        
        _ = Entities.InformNewPlayer(connection);
        SetLoadedChunks(connection, []);  // reset, just in case they were in a different world
        connection.SendPacket(new ClientBoundGameEventPacket {
            Event = GameEvent.StartWaitingForLevelChunks,
            Value = 0f
        }).ContinueWith(_ => {
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
                    await connection.SendPackets(false, packets.ToArray());
                    Console.WriteLine("Waiting packets: " + waitingPackets.Count + $" (Did in {sw.ElapsedMilliseconds})");
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
        });
        Players.Add(player);
    }

    public void HandlePlayerMove(PlayerConnection connection, IVec2 chunkPos) {
        Stopwatch sw;
        int unloadingBench;
        if (Benchmark) {
            sw = Stopwatch.StartNew();
        }
        
        HashSet<IVec2> loaded = GetLoadedChunks(connection);
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
            Console.WriteLine($"Terrain packet generation took {sw.ElapsedMilliseconds}ms, unloading: {unloadingBench}ms");
        }
        
        SetLoadedChunks(connection, loaded);
        
        // neededPackets.Add(new ClientBoundSetCenterChunkPacket {
        //     X = chunkPos.X,
        //     Z = chunkPos.Z
        // });
        connection.SendPacket(new ClientBoundSetCenterChunkPacket {
            X = chunkPos.X,
            Z = chunkPos.Z
        });
        // Console.WriteLine("Center changed to " + chunkPos);
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
        player.Connection.Events.Parents.Remove(Events);
        player.Connection.GetTag(CancelListenersActionTag).Invoke();  // stop listening
    }

    public void Spawn(Entity entity, int? id = null) {
        Entities.Spawn(entity, id);
    }

    private static HashSet<IVec2> GetLoadedChunks(PlayerConnection connection) {
        if (!connection.HasTag(LoadedChunksTag)) {
            throw new Exception("Loaded chunks don't exist");
        }
        return connection.GetTag(LoadedChunksTag);
    }

    private static void SetLoadedChunks(PlayerConnection connection, HashSet<IVec2> chunks) {
        connection.SetTag(LoadedChunksTag, chunks);
    }

    private ChunkData[] GetChunks(IVec2[] poses, int count) {
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
        
        // We need to load some chunks
        foreach (ChunkData newChunk in _provider.GetChunks(notFound, needed)) {
            newChunk.PackData();
            chunks[cChunksPos++] = newChunk;
            _chunks.TryAdd(new IVec2(newChunk.ChunkX, newChunk.ChunkZ), newChunk);
        }

        return chunks;
    }
    
    private ChunkData? RetrieveChunk(IVec2 pos) {
        _chunks.TryGetValue(pos, out ChunkData? data);
        return data;
    }

    public ClientBoundChunkDataAndUpdateLightPacket GetChunkPacket(IVec2 pos) {
        ClientBoundChunkDataAndUpdateLightPacket packet = new() {
            ChunkX = pos.X,
            ChunkZ = pos.Z,
            Data = _provider.GetChunk(pos),
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

    public PlayerEntity[] GetViewers() {
        return Players.ToArray();
    }
}
