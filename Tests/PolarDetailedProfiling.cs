using System.Diagnostics;
using System.Reflection;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;
using PolarWorlds;

namespace Tests;

public class PolarDetailedProfiling {
    
    [Test]
    public void ProfileSectionWriting() {
        Console.WriteLine("=== Profiling Section Writing ===");
        
        ChunkData chunk = new ChunkData(384) {
            ChunkX = 0,
            ChunkZ = 0
        };
        chunk.FillRandom();
        
        // Get the WriteSection method via reflection
        var writerType = typeof(PolarLoader);
        var dataWriterType = Assembly.Load("Minecraft").GetType("Minecraft.DataWriter");
        var chunkSectionType = Assembly.Load("Minecraft").GetType("Minecraft.Schemas.Chunks.ChunkSection");
        
        // Warm up
        for (int i = 0; i < 3; i++) {
            _ = PolarLoader.CreateWorld([chunk]);
        }
        
        // Measure just the section writing part (all sections)
        Stopwatch sw = Stopwatch.StartNew();
        int sectionCount = 0;
        foreach (var section in chunk.Sections) {
            sectionCount++;
        }
        sw.Stop();
        
        Console.WriteLine($"Chunk has {sectionCount} sections");
        Console.WriteLine($"Time to iterate sections: {sw.ElapsedMilliseconds}ms");
        
        // Now measure full creation
        sw.Restart();
        byte[] result = PolarLoader.CreateWorld([chunk]);
        sw.Stop();
        
        Console.WriteLine($"Full creation time (1 chunk): {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Output size: {result.Length / 1024.0:F2} KB");
    }
    
    [Test]
    public void ProfileCompressionOnly() {
        Console.WriteLine("=== Profiling Compression ===");
        
        // Create some data to compress
        byte[] testData = new byte[10 * 1024 * 1024]; // 10MB of random data
        Random rand = new Random(42);
        rand.NextBytes(testData);
        
        // Test Zstd compression
        Stopwatch sw = Stopwatch.StartNew();
        var compressor = new ZstdSharp.Compressor();
        byte[] compressed = compressor.Wrap(testData).ToArray();
        sw.Stop();
        
        Console.WriteLine($"Compressed {testData.Length / 1024.0 / 1024.0:F2} MB in {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Compression ratio: {testData.Length / (double)compressed.Length:F2}x");
        Console.WriteLine($"Throughput: {testData.Length / 1024.0 / 1024.0 / (sw.ElapsedMilliseconds / 1000.0):F2} MB/s");
        
        // Test decompression
        sw.Restart();
        var decompressor = new ZstdSharp.Decompressor();
        byte[] decompressed = new byte[testData.Length];
        decompressor.Unwrap(compressed, decompressed);
        sw.Stop();
        
        Console.WriteLine($"Decompressed in {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Throughput: {testData.Length / 1024.0 / 1024.0 / (sw.ElapsedMilliseconds / 1000.0):F2} MB/s");
    }
}
