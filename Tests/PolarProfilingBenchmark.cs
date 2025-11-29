using System.Diagnostics;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;
using PolarWorlds;

namespace Tests;

public class PolarProfilingBenchmark {
    
    [Test]
    public void ProfileWorldCreationSteps() {
        Console.WriteLine("=== Profiling Polar World Creation ===");
        
        const int chunkCount = 10;
        ChunkData[] chunks = new ChunkData[chunkCount];
        for (int i = 0; i < chunkCount; i++) {
            chunks[i] = new ChunkData(384) {
                ChunkX = i * 32,
                ChunkZ = i * 32
            };
            chunks[i].FillRandom();
        }
        
        // Warmup
        _ = PolarLoader.CreateWorld(chunks);
        
        // Now measure with GC tracking
        long memBefore = GC.GetTotalMemory(true);
        Stopwatch sw = Stopwatch.StartNew();
        byte[] polarData = PolarLoader.CreateWorld(chunks);
        sw.Stop();
        long memAfter = GC.GetTotalMemory(false);
        
        Console.WriteLine($"Total time: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Memory allocated: {(memAfter - memBefore) / 1024.0 / 1024.0:F2} MB");
        Console.WriteLine($"Output size: {polarData.Length / 1024.0 / 1024.0:F2} MB");
        Console.WriteLine($"Compression ratio: {(memAfter - memBefore) / (double)polarData.Length:F2}x");
    }
    
    [Test]
    public void ProfileWorldLoadingSteps() {
        Console.WriteLine("=== Profiling Polar World Loading ===");
        
        const int chunkCount = 10;
        ChunkData[] chunks = new ChunkData[chunkCount];
        for (int i = 0; i < chunkCount; i++) {
            chunks[i] = new ChunkData(384) {
                ChunkX = i * 32,
                ChunkZ = i * 32
            };
            chunks[i].FillRandom();
        }
        
        byte[] polarData = PolarLoader.CreateWorld(chunks);
        
        // Warmup
        _ = new PolarLoader(polarData, VanillaRegistry.Data);
        
        long memBefore = GC.GetTotalMemory(true);
        Stopwatch sw = Stopwatch.StartNew();
        PolarLoader loader = new(polarData, VanillaRegistry.Data);
        sw.Stop();
        long memAfter = GC.GetTotalMemory(false);
        
        Console.WriteLine($"Total time: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Memory allocated: {(memAfter - memBefore) / 1024.0 / 1024.0:F2} MB");
        Console.WriteLine($"Chunks loaded: {loader.Chunks.Count}");
    }
}
