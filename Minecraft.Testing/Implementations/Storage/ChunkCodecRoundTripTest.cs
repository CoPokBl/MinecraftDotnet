using Minecraft;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Implementations.Storage;
using Minecraft.Implementations.Storage.Stores;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace Minecraft.Testing.Implementations.Storage;

/// <summary>
/// What a codec has to preserve: every block, every biome, and every block entity, at every palette
/// shape a section can be in.
/// </summary>
/// <remarks>
/// The three shapes are not interchangeable and each has its own path through an encoder: a section
/// holding one state stores no data at all, one holding a few hundred stores indices into a palette,
/// and one past what an indirect palette can hold stores them at a width the palette decides. A round
/// trip that only ever sees the middle one passes while the other two are broken.
/// </remarks>
public class ChunkCodecRoundTripTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    private static readonly IBlock[] Band = [
        Block.Stone, Block.Dirt, Block.GrassBlock, Block.Sand, Block.Gravel,
        Block.OakLog, Block.OakLeaves, Block.Water, Block.Granite, Block.Andesite
    ];

    private static readonly IBiome[] Biomes = [Biome.Plains, Biome.Desert, Biome.Taiga, Biome.Ocean];

    /// <summary>A chunk with a uniform section, a mixed one, and an empty one, plus biomes and a block entity.</summary>
    private static ChunkData Sample(int chunkX, int chunkZ) {
        ChunkData chunk = new(384) { ChunkX = chunkX, ChunkZ = chunkZ, MinY = -64 };
        Random random = new(chunkX * 31 + chunkZ);

        for (int y = 0; y < 16; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    chunk.SetBlock(x, y, z, Block.Stone);              // uniform section
                    chunk.SetBlock(x, y + 16, z, Band[random.Next(Band.Length)]);  // indirect palette
                }
            }
        }

        for (int y = 0; y < 384; y += 4) {
            for (int z = 0; z < 16; z += 4) {
                for (int x = 0; x < 16; x += 4) {
                    chunk.SetBiome(x, y, z, Biomes[random.Next(Biomes.Length)], Registry);
                }
            }
        }

        chunk.BlockEntities[new Vec3<int>(3, 5, 9)] = new BlockEntity(3, 5, 9, BlockEntityType.Chest,
            new CompoundTag(("Custom", new StringTag("kept")), ("Number", new IntegerTag(7))));

        chunk.PackData(Registry);
        return chunk;
    }

    /// <summary>
    /// A section with more distinct states than an indirect palette can hold, which is the one case
    /// where the stored width comes from the palette rather than from a fixed table.
    /// </summary>
    private static ChunkData WideSample() {
        ChunkData chunk = new(64) { ChunkX = 0, ChunkZ = 0, MinY = 0 };

        uint state = 1;
        for (int y = 0; y < 16; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    chunk.SetBlock(x, y, z, state);
                    state = (uint)((state + 7) % (Registry.Blocks.StatesCount - 1) + 1);
                }
            }
        }

        chunk.PackData(Registry);
        return chunk;
    }

    private static void AssertSame(ChunkData expected, ChunkData actual) {
        for (int y = 0; y < expected.WorldHeight; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    if (expected.GetBlock(x, y, z) != actual.GetBlock(x, y, z)) {
                        Assert.Fail($"block at {x}, {y}, {z}: expected {expected.GetBlock(x, y, z)}, " +
                                    $"got {actual.GetBlock(x, y, z)}");
                    }
                }
            }
        }

        for (int y = 0; y < expected.WorldHeight; y += 4) {
            for (int z = 0; z < 16; z += 4) {
                for (int x = 0; x < 16; x += 4) {
                    if (expected.GetBiome(x, y, z) != actual.GetBiome(x, y, z)) {
                        Assert.Fail($"biome at {x}, {y}, {z}: expected {expected.GetBiome(x, y, z)}, " +
                                    $"got {actual.GetBiome(x, y, z)}");
                    }
                }
            }
        }

        Assert.That(actual.BlockEntities, Has.Count.EqualTo(expected.BlockEntities.Count));
        foreach ((Vec3<int> pos, BlockEntity entity) in expected.BlockEntities) {
            Assert.That(actual.BlockEntities.ContainsKey(pos), Is.True, $"block entity at {pos} is missing");

            BlockEntity got = actual.BlockEntities[pos];
            Assert.That(got.Type.Identifier, Is.EqualTo(entity.Type.Identifier));
            Assert.That(got.Data, Is.EqualTo(entity.Data));
        }
    }

    private static ChunkData RoundTrip(IChunkCodec codec, ChunkData chunk) {
        DataWriter writer = new();
        codec.Encode(chunk, writer);
        return codec.Decode(new DataReader(writer.ToArray()), ChunkCodecContext.Of(chunk));
    }

    [Test]
    public void AnvilKeepsEverySectionShape() {
        AnvilChunkCodec codec = new(Registry);
        ChunkData chunk = Sample(3, -5);
        AssertSame(chunk, RoundTrip(codec, chunk));
    }

    [Test]
    public void AnvilKeepsASectionWiderThanAnIndirectPalette() {
        AnvilChunkCodec codec = new(Registry);
        ChunkData chunk = WideSample();
        AssertSame(chunk, RoundTrip(codec, chunk));
    }

    [Test]
    public void AChunkSurvivesAStore() {
        CodecTerrainStore store = new(new AnvilChunkCodec(Registry), new MemoryChunkBlobStore());
        ChunkData chunk = Sample(-2, 7);
        store.PutChunk(chunk);

        ChunkData read = new(384) { ChunkX = chunk.ChunkX, ChunkZ = chunk.ChunkZ, MinY = -64 };
        Assert.That(store.TryGetChunk(ref read), Is.True);
        AssertSame(chunk, read);
    }

    /// <summary>
    /// A whole world directory, which is the layout a vanilla server would open, written and read back
    /// through the loader that serves one.
    /// </summary>
    [Test]
    public void AWorldDirectoryRoundTrips() {
        string directory = Path.Join(Path.GetTempPath(), "anvil-world-" + Guid.NewGuid().ToString("N")[..12]);

        try {
            ChunkData[] chunks = [Sample(0, 0), Sample(1, 0), Sample(-33, 40)];

            using (AnvilLoader writer = new(directory, Registry, -64, true)) {
                foreach (ChunkData chunk in chunks) {
                    writer.PutChunk(chunk);
                }

                writer.Flush();
            }

            using AnvilLoader reader = new(directory, Registry);
            Assert.That(reader.EnumerateChunks().Count(), Is.EqualTo(chunks.Length));

            foreach (ChunkData chunk in chunks) {
                ChunkData read = new(384) { ChunkX = chunk.ChunkX, ChunkZ = chunk.ChunkZ, MinY = -64 };
                Assert.That(reader.TryGetChunk(ref read), Is.True, $"chunk {chunk.ChunkX}, {chunk.ChunkZ}");
                AssertSame(chunk, read);
            }
        } finally {
            Directory.Delete(directory, true);
        }
    }

    /// <summary>
    /// A store that has never held a position says so, rather than answering with an empty chunk. That
    /// is what lets a generator stand behind one.
    /// </summary>
    [Test]
    public void AMissingChunkIsAMissAndNotAnEmptyChunk() {
        CodecTerrainStore store = new(new AnvilChunkCodec(Registry), new MemoryChunkBlobStore());

        ChunkData read = new(384) { ChunkX = 100, ChunkZ = 100, MinY = -64 };
        Assert.That(store.TryGetChunk(ref read), Is.False);
    }
}
