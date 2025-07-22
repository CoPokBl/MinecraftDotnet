using System.Diagnostics;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Tests;

public class ChunkSpeed {

    [Test]
    public void GenerateChunksSpeed() {
        // const int viewDistance = 32;
        // World world = new(new TestingProvider());
        //
        // Stopwatch sw = Stopwatch.StartNew();
        // for (int i = 0; i < viewDistance*2; i++) {
        //     for (int j = 0; j < viewDistance*2; j++) {
        //         world.GetChunkPacket(new ChunkPosition(i, j));
        //     }
        // }
        //
        // TimeSpan time = sw.Elapsed;
        // int chunks = 4 * viewDistance * viewDistance;
        // double msPerChunk = time.TotalMilliseconds / chunks;
        // Console.WriteLine($"Took {time} to generate {chunks} chunks ({msPerChunk}ms/chunk)");
    }
    
    [Test]
    public void GenerateMultiChunksSpeed() {
        const int viewDistance = 32;
        ITerrainProvider world = new TestingProvider();
        
        Stopwatch sw = Stopwatch.StartNew();

        ChunkData[] data = new ChunkData[viewDistance * viewDistance * 4];
        int index = 0;
        for (int i = 0; i < viewDistance*2; i++) {
            for (int j = 0; j < viewDistance*2; j++) {
                data[index++] = new ChunkData(ChunkData.VanillaOverworldHeight) {
                    ChunkX = i,
                    ChunkZ = j
                };
            }
        }

        world.GetChunks(0, data.Length, data);

        TimeSpan time = sw.Elapsed;
        int chunks = 4 * viewDistance * viewDistance;
        double msPerChunk = time.TotalMilliseconds / chunks;
        Console.WriteLine($"Took {time} to generate {chunks} chunks ({msPerChunk}ms/chunk)");
    }

    private const bool Benchmark = true;
    private const int UnloadDistance = 32;
    private const int viewDistance = 5;
    private ITerrainProvider provider = new TestingProvider();

    [Test]
    public void MassVsSingle() {
        WorldGenTest(true);
        // WorldGenTest(false);
    }
    
    // this is outdated, TODO: update it to use actual world code (make some method idk)
    public void WorldGenTest(bool massCall) {
        // Vec3 pos = Vec3.Zero;
        //
        // Stopwatch sw;
        // int unloadingBench;
        // int toLoadBench;
        // if (Benchmark) {
        //     sw = Stopwatch.StartNew();
        // }
        //
        // ChunkPosition chunkPos = new((int)Math.Floor(pos.X / 16), (int)Math.Floor(pos.Z / 16));
        // HashSet<ChunkPosition> loaded = [];
        //
        // List<MinecraftPacket> neededPackets = [];
        // List<ChunkPosition> unloaded = [];
        // foreach (ChunkPosition loadedChunk in loaded) {
        //     if (loadedChunk.IsWithinRadiusOf(chunkPos, UnloadDistance)) continue;
        //     
        //     neededPackets.Add(new ClientBoundUnloadChunkPacket(loadedChunk));  // not within radius, unload it
        //     unloaded.Add(loadedChunk);
        //     // Console.WriteLine($"Unloading {loadedChunk.X}, {loadedChunk.Z}");
        // }
        // foreach (ChunkPosition c in unloaded) {
        //     loaded.Remove(c);
        // }
        //
        // if (Benchmark) unloadingBench = (int)sw.ElapsedMilliseconds;
        //
        // // Okay, now get everything that should be loaded
        // if (massCall) {
        //     ChunkPosition[] toLoad = new ChunkPosition[(viewDistance*2+1)*(viewDistance*2+1)];
        //     int i = 0;
        //     for (int x = 0; x < viewDistance * 2 + 1; x++) {
        //         for (int z = 0; z < viewDistance * 2 + 1; z++) {
        //             ChunkPosition chunk = new(x + chunkPos.X - viewDistance, z + chunkPos.Z - viewDistance);
        //         
        //             if (!loaded.Contains(chunk)) {
        //                 // okay, so we need to load chunk
        //                 // neededPackets.Add(GetChunkPacket(chunk));
        //                 toLoad[i++] = chunk;
        //                 loaded.Add(chunk);
        //                 // Console.WriteLine($"Loading {chunk.X}, {chunk.Z}");
        //             }
        //         }
        //     }
        //
        //     AddChunkPackets(toLoad, i, neededPackets);
        // }
        // else {
        //     for (int x = 0; x < viewDistance * 2 + 1; x++) {
        //         for (int z = 0; z < viewDistance * 2 + 1; z++) {
        //             ChunkPosition chunk = new(x + chunkPos.X - viewDistance, z + chunkPos.Z - viewDistance);
        //         
        //             if (!loaded.Contains(chunk)) {
        //                 // okay, so we need to load chunk
        //                 neededPackets.Add(GetChunkPacket(chunk));
        //                 loaded.Add(chunk);
        //                 // Console.WriteLine($"Loading {chunk.X}, {chunk.Z}");
        //             }
        //         }
        //     }
        // }
        //
        //
        // if (Benchmark) toLoadBench = (int)sw.ElapsedMilliseconds;
        //
        // // SetLoadedChunks(connection, loaded);
        //
        //
        //
        // if (neededPackets.Count == 0) return;
        // neededPackets.Add(new ClientBoundSetCenterChunkPacket(chunkPos));
        // IEnumerable<MinecraftPacket> orderedPackets = neededPackets.OrderBy(p => {
        //     if (p is ClientBoundSetCenterChunkPacket) return 0;  // always do this first, otherwise we could get issues
        //     if (p is not ClientBoundChunkDataAndUpdateLightPacket chunkP) return 100;  // do unload packets last (for faster load, client unloads anyway)
        //     return new ChunkPosition(chunkP.ChunkX, chunkP.ChunkZ).DistanceTo(chunkPos);  // do closer chunks first for quicker load
        // });
        //
        // if (Benchmark) {
        //     Console.WriteLine($"[{(massCall ? "MASS" : "SINGLE")}] Terrain packet generation took {sw.ElapsedMilliseconds}ms, unloading: {unloadingBench}ms, toLoad: {toLoadBench}ms");
        // }
        //
        // foreach (MinecraftPacket packet in orderedPackets) {
        //     // waitingPackets.Enqueue(packet);
        // }
    }
    
    // public ClientBoundChunkDataAndUpdateLightPacket GetChunkPacket(ChunkPosition pos) {
    //     ClientBoundChunkDataAndUpdateLightPacket packet = new(pos.X, pos.Z, provider.GetChunk(pos), LightData.FullBright);
    //     return packet;
    // }
    //
    // public IEnumerable<ClientBoundChunkDataAndUpdateLightPacket> GetChunkPackets(List<ChunkPosition> poses) {
    //     List<ClientBoundChunkDataAndUpdateLightPacket> packets = [];
    //     foreach (ChunkData data in provider.GetChunks(0, poses.ToArray())) {
    //         packets.Add(new ClientBoundChunkDataAndUpdateLightPacket(data.ChunkX, data.ChunkZ, data, LightData.FullBright));
    //     }
    //     return packets;
    // }
    //
    // public void AddChunkPackets(ChunkPosition[] poses, int count, List<MinecraftPacket> list) {
    //     Stopwatch sw = Stopwatch.StartNew();
    //     IEnumerable<ChunkData> chunkDatas = provider.GetChunks(count, poses);
    //     Console.WriteLine($"Gen took: {sw.ElapsedMilliseconds}ms");
    //     foreach (ChunkData data in chunkDatas) {
    //         list.Add(new ClientBoundChunkDataAndUpdateLightPacket(data.ChunkX, data.ChunkZ, data, LightData.FullBright));
    //     }
    //     Console.WriteLine($"Packet compilation took: {sw.ElapsedMilliseconds}ms");
    // }
}