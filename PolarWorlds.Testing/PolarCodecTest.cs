using Minecraft;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Storage;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT.Tags;

namespace PolarWorlds.Testing;

/// <summary>
/// What a Polar file has to preserve beyond blocks: biomes, block entities, and the section shapes
/// either side of the one an average chunk is in.
/// </summary>
public class PolarCodecTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    private static readonly IBlock[] Band = [
        Block.Stone, Block.Dirt, Block.GrassBlock, Block.Sand, Block.OakLog, Block.Water
    ];

    private static ChunkData Sample(int chunkX, int chunkZ) {
        ChunkData chunk = new(384) { ChunkX = chunkX, ChunkZ = chunkZ, MinY = -64 };
        Random random = new(chunkX * 17 + chunkZ);

        for (int y = 0; y < 16; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    chunk.SetBlock(x, y, z, Block.Stone);
                    chunk.SetBlock(x, y + 16, z, Band[random.Next(Band.Length)]);
                }
            }
        }

        chunk.SetBiome(0, 20, 0, Biome.Desert, Registry);
        chunk.SetBiome(8, 20, 8, Biome.Taiga, Registry);

        chunk.BlockEntities[new Vec3<int>(2, 30, 11)] = new BlockEntity(2, 30, 11, BlockEntityType.Chest,
            new CompoundTag(("Marker", new StringTag("kept"))));

        chunk.PackData(Registry);
        return chunk;
    }

    private static void AssertSame(ChunkData expected, ChunkData actual) {
        for (int y = 0; y < expected.WorldHeight; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    if (expected.GetBlock(x, y, z) != actual.GetBlock(x, y, z)) {
                        Assert.Fail($"block at {x}, {y}, {z}");
                    }
                }
            }
        }

        for (int y = 0; y < expected.WorldHeight; y += 4) {
            for (int z = 0; z < 16; z += 4) {
                for (int x = 0; x < 16; x += 4) {
                    if (expected.GetBiome(x, y, z) != actual.GetBiome(x, y, z)) {
                        Assert.Fail($"biome at {x}, {y}, {z}");
                    }
                }
            }
        }

        Assert.That(actual.BlockEntities, Has.Count.EqualTo(expected.BlockEntities.Count));
        foreach ((Vec3<int> pos, BlockEntity entity) in expected.BlockEntities) {
            Assert.That(actual.BlockEntities.ContainsKey(pos), Is.True, $"block entity at {pos}");
            Assert.That(actual.BlockEntities[pos].Data, Is.EqualTo(entity.Data));
        }
    }

    [Test]
    public void ACodecRoundTripKeepsBlocksBiomesAndBlockEntities() {
        PolarChunkCodec codec = new(Registry);
        ChunkData chunk = Sample(2, -3);

        DataWriter writer = new();
        codec.Encode(chunk, writer);
        ChunkData read = codec.Decode(new DataReader(writer.ToArray()), ChunkCodecContext.Of(chunk));

        AssertSame(chunk, read);
    }

    /// <summary>
    /// A bundle stores its chunks back to back with no length in front of any of them, so opening one
    /// depends on being able to walk a record without decoding it. A walk that stops in the wrong place
    /// hands the next chunk somebody else's bytes.
    /// </summary>
    [Test]
    public void ABundleSplitsChunksBackApart() {
        ChunkData[] chunks = [Sample(0, 0), Sample(1, 0), Sample(-4, 9)];

        byte[] file = PolarLoader.CreateWorld(chunks, Registry);
        PolarLoader loaded = new(file, Registry);

        Assert.That(loaded.Chunks, Has.Count.EqualTo(chunks.Length));
        foreach (ChunkData chunk in chunks) {
            AssertSame(chunk, loaded.Chunks[new Vec2<int>(chunk.ChunkX, chunk.ChunkZ)]);
        }
    }

    /// <summary>Chunks written back into a loaded map are in the file it saves.</summary>
    [Test]
    public void AMapSavesWhatWasPutIntoIt() {
        PolarLoader loader = new(PolarLoader.CreateWorld([Sample(0, 0)], Registry), Registry);

        ChunkData added = Sample(5, 5);
        loader.PutChunk(added);

        PolarLoader reloaded = new(loader.Save(), Registry);
        Assert.That(reloaded.Chunks, Has.Count.EqualTo(2));
        AssertSame(added, reloaded.Chunks[new Vec2<int>(5, 5)]);
    }

    /// <summary>
    /// The header's section range is what places a map's sections, so a file has to record the floor
    /// it was written with and a reader has to take it from there.
    /// </summary>
    [Test]
    public void AMapKeepsTheFloorItWasWrittenWith() {
        byte[] file = PolarLoader.CreateWorld([Sample(0, 0)], Registry);

        PolarBundle bundle = new(file);
        Assert.That(bundle.MinSection, Is.EqualTo(-4));
        Assert.That(bundle.MaxSection, Is.EqualTo(19));

        PolarLoader loaded = new(file, Registry);
        Assert.That(loaded.Chunks[new Vec2<int>(0, 0)].MinY, Is.EqualTo(-64));
    }

    /// <summary>
    /// A flush rewrites the whole file, and a save ends in one whether it wrote anything or not, so a
    /// bundle nothing has changed must leave the disk alone.
    /// </summary>
    [Test]
    public void AFlushWithNothingChangedLeavesTheFileAlone() {
        string directory = Path.Join(Path.GetTempPath(), "polar-test-" + Guid.NewGuid().ToString("N")[..12]);
        Directory.CreateDirectory(directory);
        string path = Path.Join(directory, "world.polar");

        try {
            PolarBundle bundle = new(384, -64) { Path = path };
            CodecTerrainStore store = new(new PolarChunkCodec(Registry), bundle);

            store.PutChunk(Sample(0, 0));
            store.Flush();
            Assert.That(File.Exists(path), Is.True);

            File.Delete(path);
            store.Flush();
            Assert.That(File.Exists(path), Is.False, "a flush with nothing written since rewrote the file");

            store.PutChunk(Sample(1, 0));
            store.Flush();
            Assert.That(File.Exists(path), Is.True);

            PolarBundle opened = PolarBundle.Open(path);
            File.Delete(path);
            opened.Flush();
            Assert.That(File.Exists(path), Is.False, "a bundle just opened from disk was written straight back");
        } finally {
            Directory.Delete(directory, true);
        }
    }

    /// <summary>
    /// An air section with the default biome is stored as nothing at all, which is most of a world.
    /// </summary>
    [Test]
    public void AnEmptyWorldIsSmall() {
        ChunkData empty = new(384) { ChunkX = 0, ChunkZ = 0, MinY = -64 };
        empty.PackData(Registry);

        byte[] file = PolarLoader.CreateWorld([empty], Registry);
        Assert.That(file.Length, Is.LessThan(256));

        PolarLoader loaded = new(file, Registry);
        AssertSame(empty, loaded.Chunks[new Vec2<int>(0, 0)]);
    }
}
