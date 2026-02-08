using System.Diagnostics;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;
using PolarWorlds;

namespace Tests;

public class PolarBenchmark {
    
    [Test]
    public void BenchmarkPolarWorldCreation() {
        Console.WriteLine("=== Polar World Creation Benchmark ===");
        
        // Create test chunks with random data
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
        Console.WriteLine("Warming up...");
        byte[] warmupData = PolarLoader.CreateWorld(chunks);
        
        // Benchmark
        Stopwatch sw = Stopwatch.StartNew();
        byte[] polarData = PolarLoader.CreateWorld(chunks);
        sw.Stop();
        
        Console.WriteLine($"Time to create world with {chunkCount} chunks: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Output size: {polarData.Length} bytes");
        Console.WriteLine($"Average time per chunk: {sw.ElapsedMilliseconds / (double)chunkCount:F2}ms");
    }
    
    [Test]
    public void BenchmarkPolarWorldLoading() {
        Console.WriteLine("=== Polar World Loading Benchmark ===");
        
        // Create test data
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
        Console.WriteLine("Warming up...");
        PolarLoader warmupLoader = new(polarData, VanillaRegistry.Data);
        
        // Benchmark
        Stopwatch sw = Stopwatch.StartNew();
        PolarLoader loader = new(polarData, VanillaRegistry.Data);
        sw.Stop();
        
        Console.WriteLine($"Time to load world with {chunkCount} chunks: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Average time per chunk: {sw.ElapsedMilliseconds / (double)chunkCount:F2}ms");
    }
    
    [Test]
    public void BenchmarkLargerWorld() {
        Console.WriteLine("=== Large Polar World Benchmark ===");
        
        const int chunkCount = 50;
        ChunkData[] chunks = new ChunkData[chunkCount];
        for (int i = 0; i < chunkCount; i++) {
            chunks[i] = new ChunkData(384) {
                ChunkX = i % 10,
                ChunkZ = i / 10
            };
            chunks[i].FillRandom();
        }
        
        Console.WriteLine("Creating world...");
        Stopwatch sw = Stopwatch.StartNew();
        byte[] polarData = PolarLoader.CreateWorld(chunks);
        sw.Stop();
        long creationTime = sw.ElapsedMilliseconds;
        
        Console.WriteLine("Loading world...");
        sw.Restart();
        PolarLoader loader = new(polarData, VanillaRegistry.Data);
        sw.Stop();
        long loadTime = sw.ElapsedMilliseconds;
        
        Console.WriteLine($"\nResults for {chunkCount} chunks:");
        Console.WriteLine($"  Creation: {creationTime}ms ({creationTime / (double)chunkCount:F2}ms per chunk)");
        Console.WriteLine($"  Loading:  {loadTime}ms ({loadTime / (double)chunkCount:F2}ms per chunk)");
        Console.WriteLine($"  Size:     {polarData.Length} bytes");
    }
}
