using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;
using PolarWorlds;

namespace Tests;

public class PolarTest {

    [Test]
    public void TestPolarConverter() {
        Console.WriteLine("asd");
        // AnvilLoader anvil = new("ramen", VanillaRegistry.Data);
        const int amount = 3;
        ChunkData[] chunks = new ChunkData[amount];
        for (int i = 0; i < amount; i++) {
            chunks[i] = new ChunkData(384) {
                ChunkX = i*32,
                ChunkZ = i*32
            };
            // chunks[i].Fill(11);
            // chunks[i].SetBlock(0, 0, 0, 19);
            // chunks[i].SetBlock(1, 0, 0, 20);
            // chunks[i].SetBlock(2, 0, 0, 21);
            // chunks[i].SetBlock(3, 0, 0, 22);
            // chunks[i].SetBlock(4, 0, 0, 23);
            // chunks[i].SetBlock(5, 0, 0, 24);
            // chunks[i].SetBlock(6, 0, 0, 25);
            // chunks[i].SetBlock(7, 0, 0, 26);
            // chunks[i].SetBlock(0, 1, 0, 20);
            // chunks[i].SetBlock(0, 2, 0, 21);
            // chunks[i].SetBlock(0, 3, 0, 22);
            // chunks[i].SetBlock(0, 4, 0, 23);
            // chunks[i].SetBlock(0, 5, 0, 24);
            // chunks[i].SetBlock(0, 6, 0, 25);
            // chunks[i].SetBlock(0, 7, 0, 26);
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

    [Test]
    public void TestCoordIndexes() {
        for (int x = 0; x < 16; x++) {
            for (int y = -256; y < 256; y++) {
                for (int z = 0; z < 16; z++) {
                    TestIndex(x, y, z);
                }
            }
        }
    }

    private static void TestIndex(int x, int y, int z) {
        int index = PolarLoader.GetIndexFromCoords(x, y, z);
        int x2 = PolarLoader.GetXFromIndex(index);
        int y2 = PolarLoader.GetYFromIndex(index);
        int z2 = PolarLoader.GetZFromIndex(index);
        Assert.That(x2, Is.EqualTo(x));
        Assert.That(y2, Is.EqualTo(y));
        Assert.That(z2, Is.EqualTo(z));
    }
}
