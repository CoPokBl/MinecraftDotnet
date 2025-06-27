using System.Diagnostics;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Managed;
using Minecraft.Implementations.Server.Managed.Entities;
using Minecraft.Implementations.Server.Managed.Entities.Events;
using Minecraft.Implementations.Server.Managed.Entities.Types;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Worlds;

public class World {
    // State stuff
    public readonly List<PlayerEntity> Players = [];
    public EventNode<IServerEvent> Events;
    public readonly EventNode<IServerEvent> PlayerPacketEvents = new();
    public EntityManager Entities;
    
    // Params
    private readonly ITerrainProvider _provider;
    private readonly int _viewDistance;
    private readonly int _packetsPerTick;
    private readonly int _tickDelayMs;

    public World(EventNode<IServerEvent> baseEventNode, ITerrainProvider provider, int viewDistance = 8, int packetsPerTick = 10, int tickDelayMs = 100) {
        _provider = provider;
        _viewDistance = viewDistance;
        _packetsPerTick = packetsPerTick;
        _tickDelayMs = tickDelayMs;
        Events = new EventNode<IServerEvent>(baseEventNode);
        Entities = new EntityManager(Events, viewDistance*16);
    }

    // Data storage tags
    private static readonly Tag<HashSet<ChunkPosition>> LoadedChunksTag = new("minecraftdotnet:world:loadedchunks");
    private static readonly Tag<Queue<MinecraftPacket>> WaitingPacketsTag = new("minecraftdotnet:world:waitingpackets");
    private static readonly Tag<Action> CancelListenersActionTag = new("minecraftdotnet:world:cancellistener");
    
    // Some fun constants
    private int UnloadDistance => _viewDistance + UnloadDistanceMod;
    private const bool Benchmark = true;
    private const int UnloadDistanceMod = 1;  // Used to reduce the number of packets needed when travelling back and forth

    public void AddFeature(IWorldFeature feature) {
        feature.Register(this);
    }
    
    public void AddPlayer(PlayerEntity player) {
        PlayerConnection connection = player.Connection;
        connection.Events.Parents.Add(PlayerPacketEvents);
        
        _ = Entities.InformNewPlayer(connection);
        SetLoadedChunks(connection, []);  // reset, just in case they were in a different world
        connection.SendPacket(new ClientBoundGameEventPacket {
            Event = GameEvent.StartWaitingForLevelChunks,
            Value = 0f
        }).ContinueWith(_2 => {
            Queue<MinecraftPacket> waitingPackets = new();
            connection.SetTag(WaitingPacketsTag, waitingPackets);

            bool disconnected = false;
            connection.Disconnected += () => disconnected = true;
            Task.Run(async () => {
                while (!disconnected) {
                    await Task.Delay(_tickDelayMs);
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
                    _ = connection.SendPackets(false, packets.ToArray());
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
                
                ChunkPosition chunkPos = new((int)Math.Floor(e.NewPos.X / 16), (int)Math.Floor(e.NewPos.Z / 16));
                HandlePlayerMove(pe.Connection, chunkPos);
            });
            player.Connection.SetTag(CancelListenersActionTag, cancelAction);
        });
        Players.Add(player);
    }

    public void HandlePlayerMove(PlayerConnection connection, ChunkPosition chunkPos) {
        Stopwatch sw;
        int unloadingBench;
        if (Benchmark) {
            sw = Stopwatch.StartNew();
        }
        
        HashSet<ChunkPosition> loaded = GetLoadedChunks(connection);
        // Console.WriteLine($"{loaded.Count} chunks are loaded");

        List<MinecraftPacket> neededPackets = [];
        List<ChunkPosition> unloaded = [];
        foreach (ChunkPosition loadedChunk in loaded) {
            if (loadedChunk.IsWithinRadiusOf(chunkPos, UnloadDistance)) continue;
            
            neededPackets.Add(new ClientBoundUnloadChunkPacket {
                X = loadedChunk.X,
                Z = loadedChunk.Z
            });  // not within radius, unload it
            unloaded.Add(loadedChunk);
            // Console.WriteLine($"Unloading {loadedChunk.X}, {loadedChunk.Z}");
        }
        foreach (ChunkPosition c in unloaded) {
            loaded.Remove(c);
        }

        if (Benchmark) unloadingBench = (int)sw.ElapsedMilliseconds;
    
        // Okay, now get everything that should be loaded
        ChunkPosition[] toLoad = new ChunkPosition[(_viewDistance*2+1)*(_viewDistance*2+1)];
        int i = 0;
        for (int x = 0; x < _viewDistance * 2 + 1; x++) {
            for (int z = 0; z < _viewDistance * 2 + 1; z++) {
                ChunkPosition chunk = new(x + chunkPos.X - _viewDistance, z + chunkPos.Z - _viewDistance);
                
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
        
        neededPackets.Add(new ClientBoundSetCenterChunkPacket {
            X = chunkPos.X,
            Z = chunkPos.Z
        });
        // Console.WriteLine("Center changed to " + chunkPos);
        IEnumerable<MinecraftPacket> orderedPackets = neededPackets.OrderBy(p => {
            if (p is ClientBoundSetCenterChunkPacket) return 0;  // always do this first, otherwise we could get issues
            if (p is not ClientBoundChunkDataAndUpdateLightPacket chunkP) return 100;  // do unload packets last (for faster load, client unloads anyway)
            return new ChunkPosition(chunkP.ChunkX, chunkP.ChunkZ).DistanceTo(chunkPos);  // do closer chunks first for quicker load
        });
        
        Queue<MinecraftPacket> waitingPackets = connection.GetTag(WaitingPacketsTag);
        foreach (MinecraftPacket packet in orderedPackets) {
            waitingPackets.Enqueue(packet);
        }
    }

    public void RemovePlayer(PlayerEntity player) {
        Players.Remove(player);
        player.Connection.Events.Parents.Remove(PlayerPacketEvents);
        player.Connection.GetTag(CancelListenersActionTag).Invoke();  // stop listening
    }

    public void Spawn(Entity entity, int? id = null) {
        Entities.Spawn(entity, id);
    }

    private static HashSet<ChunkPosition> GetLoadedChunks(PlayerConnection connection) {
        if (!connection.HasTag(LoadedChunksTag)) {
            throw new Exception("Loaded chunks don't exist");
        }
        return connection.GetTag(LoadedChunksTag);
    }

    private static void SetLoadedChunks(PlayerConnection connection, HashSet<ChunkPosition> chunks) {
        connection.SetTag(LoadedChunksTag, chunks);
    }

    public ClientBoundChunkDataAndUpdateLightPacket GetChunkPacket(ChunkPosition pos) {
        ClientBoundChunkDataAndUpdateLightPacket packet = new() {
            ChunkX = pos.X,
            ChunkZ = pos.Z,
            Data = _provider.GetChunk(pos),
            Light = LightData.FullBright
        };
        return packet;
    }
    
    public void AddChunkPackets(ChunkPosition[] poses, int count, List<MinecraftPacket> list) {
        foreach (ChunkData data in _provider.GetChunks(count, poses)) {
            list.Add(new ClientBoundChunkDataAndUpdateLightPacket{
                ChunkX = data.ChunkX,
                ChunkZ = data.ChunkZ,
                Data = data,
                Light = LightData.FullBright
            });
        }
    }
}