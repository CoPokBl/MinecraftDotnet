using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;

namespace PolarWorlds.Testing;

public class PolarConverterTest {

    [Test]
    public void TestPolarConverter() {
        const int amount = 3;
        ChunkData[] chunks = new ChunkData[amount];
        for (int i = 0; i < amount; i++) {
            chunks[i] = new ChunkData(384) {
                ChunkX = i*32,
                ChunkZ = i*32
            };
            chunks[i].FillRandom();
        }
        
        byte[] polarData = PolarLoader.CreateWorld(chunks);
        PolarLoader polar = new(polarData, VanillaRegistry.Data);

        ChunkData chunk2 = new(384) {
            ChunkX = chunks[0].ChunkX,
            ChunkZ = chunks[0].ChunkZ
        };
        polar.GetChunk(ref chunk2);

        for (int x = 0; x < 16; x++) {
            for (int y = 0; y < 384; y++) {
                for (int z = 0; z < 16; z++) {
                    Console.WriteLine("Checking {0}, {1}, {2}", x, y, z);
                    Assert.That(chunk2.GetBlock(x, y, z), Is.EqualTo(chunks[0].GetBlock(x, y, z)));
                }
            }
        }
    }
}
