using System.Diagnostics;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Worlds;

public class World(ITerrainProvider provider, int viewDistance = 8, int packetsPerTick = 10, int tickDelayMs = 100) {
    private const bool Benchmark = false;
    
    private readonly List<PlayerConnection> _players = [];
    private const int UnloadDistanceMod = 1;
    private const string LoadedChunksDataId = "minecraftdotnet:world:loadedchunks";
    private int UnloadDistance => viewDistance + UnloadDistanceMod;

    public void AddPlayer(PlayerConnection connection) {
        connection.SendPacket(new ClientBoundGameEventPacket(GameEvent.StartWaitingForLevelChunks, 0)).ContinueWith(_2 => {
            Queue<MinecraftPacket> waitingPackets = new();

            bool disconnected = false;
            connection.Disconnected += () => disconnected = true;
            Task.Run(async () => {
                while (!disconnected) {
                    await Task.Delay(tickDelayMs);
                    if (waitingPackets.Count == 0) {
                        continue;
                    }

                    List<MinecraftPacket> packets = [];
                    for (int i = 0; i < packetsPerTick; i++) {
                        waitingPackets.TryDequeue(out MinecraftPacket? result);
                        if (result == null) break;
                        
                        packets.Add(result);
                    }

                    // Console.WriteLine($"Sending {packets.Count} packets for terrain");
                    _ = connection.SendPackets(false, packets.ToArray());
                }
            });
            
            // ON PACKET
            connection.Events.AddListener<PacketHandleEvent>(e => {
                Vec3 pos;
                switch (e.Packet) {
                    case ServerBoundSetPlayerPositionPacket sp:
                        pos = sp.Position;
                        break;
                    case ServerBoundSetPlayerPosAndRotPacket spar:
                        pos = spar.Position;
                        break;
                    default:
                        return;
                }

                Stopwatch sw;
                int unloadingBench;
                if (Benchmark) {
                    sw = Stopwatch.StartNew();
                }

                ChunkPosition chunkPos = new((int)Math.Floor(pos.X / 16), (int)Math.Floor(pos.Z / 16));
                HashSet<ChunkPosition> loaded = GetLoadedChunks(connection);

                List<MinecraftPacket> neededPackets = [];
                List<ChunkPosition> unloaded = [];
                foreach (ChunkPosition loadedChunk in loaded) {
                    if (loadedChunk.IsWithinRadiusOf(chunkPos, UnloadDistance)) continue;
                    
                    neededPackets.Add(new ClientBoundUnloadChunkPacket(loadedChunk));  // not within radius, unload it
                    unloaded.Add(loadedChunk);
                    // Console.WriteLine($"Unloading {loadedChunk.X}, {loadedChunk.Z}");
                }
                foreach (ChunkPosition c in unloaded) {
                    loaded.Remove(c);
                }

                if (Benchmark) unloadingBench = (int)sw.ElapsedMilliseconds;
            
                // Okay, now get everything that should be loaded
                ChunkPosition[] toLoad = new ChunkPosition[(viewDistance*2+1)*(viewDistance*2+1)];
                int i = 0;
                for (int x = 0; x < viewDistance * 2 + 1; x++) {
                    for (int z = 0; z < viewDistance * 2 + 1; z++) {
                        ChunkPosition chunk = new(x + chunkPos.X - viewDistance, z + chunkPos.Z - viewDistance);
                        
                        if (!loaded.Contains(chunk)) {
                            // okay, so we need to load chunk
                            // neededPackets.Add(GetChunkPacket(chunk));
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
                
                neededPackets.Add(new ClientBoundSetCenterChunkPacket(chunkPos));
                IEnumerable<MinecraftPacket> orderedPackets = neededPackets.OrderBy(p => {
                    if (p is ClientBoundSetCenterChunkPacket) return 0;  // always do this first, otherwise we could get issues
                    if (p is not ClientBoundChunkDataAndUpdateLightPacket chunkP) return 100;  // do unload packets last (for faster load, client unloads anyway)
                    return new ChunkPosition(chunkP.ChunkX, chunkP.ChunkZ).DistanceTo(chunkPos);  // do closer chunks first for quicker load
                });
                foreach (MinecraftPacket packet in orderedPackets) {
                    waitingPackets.Enqueue(packet);
                }
            });
        });
        _players.Add(connection);
    }

    public void RemovePlayer(PlayerConnection connection) {
        // idk
        _players.Remove(connection);
    }

    public static HashSet<ChunkPosition> GetLoadedChunks(PlayerConnection connection) {
        if (connection.Data.TryGetValue(LoadedChunksDataId, out object? value)) return (HashSet<ChunkPosition>)value!;
        value = new HashSet<ChunkPosition>();
        connection.Data.Add(LoadedChunksDataId, value);

        return (HashSet<ChunkPosition>)value;
    }

    public static void SetLoadedChunks(PlayerConnection connection, HashSet<ChunkPosition> chunks) {
        connection.Data[LoadedChunksDataId] = chunks;
    }

    public ClientBoundChunkDataAndUpdateLightPacket GetChunkPacket(ChunkPosition pos) {
        ClientBoundChunkDataAndUpdateLightPacket packet = new(pos.X, pos.Z, provider.GetChunk(pos), LightData.FullBright);
        return packet;
    }
    
    public void AddChunkPackets(ChunkPosition[] poses, int count, List<MinecraftPacket> list) {
        foreach (ChunkData data in provider.GetChunks(count, poses)) {
            list.Add(new ClientBoundChunkDataAndUpdateLightPacket(data.ChunkX, data.ChunkZ, data, LightData.FullBright));
        }
    }
}