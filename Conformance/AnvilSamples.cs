using System.Text;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace Conformance;

/// <summary>
/// A world directory for <c>Conformance/anvil.sh</c>, written through <see cref="AnvilLoader"/>, and
/// what every chunk in it should hold. <c>AnvilHarness.java</c> opens it with vanilla's own
/// <c>RegionFile</c> and <c>SerializableChunkData.parse</c> and diffs the two.
/// </summary>
/// <remarks>
/// Our round trip tests read back through our own reader, which agrees with our writer about every
/// mistake they share: a sector layout vanilla rejects, a palette width it reads differently, a
/// <c>DataVersion</c> it would run fixers over. Only vanilla's reader can say the file is a world.
/// <p/>
/// The region the rewrites land in is written in an order that moves chunks between runs of sectors,
/// so the header vanilla reads is the one allocation left behind rather than a fresh file's.
/// </remarks>
public static class AnvilSamples {
    private const int WorldHeight = ChunkData.VanillaOverworldHeight;
    private const int MinY = -64;

    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    private static readonly IBlock[] Band = [
        Block.Stone, Block.Dirt, Block.GrassBlock, Block.Sand, Block.Gravel,
        Block.OakLog, Block.OakLeaves, Block.Water, Block.Granite, Block.Andesite
    ];

    private static readonly IBiome[] Biomes = [Biome.Plains, Biome.Desert, Biome.Taiga, Biome.Ocean];

    public static int ChunkCount { get; private set; }

    /// <summary>Writes the world into <paramref name="directory"/> and returns what it should read as.</summary>
    public static string Write(string directory) {
        if (Directory.Exists(directory)) {
            Directory.Delete(directory, true);
        }

        Dictionary<Vec2<int>, (string Name, ChunkData Chunk)> expected = [];
        List<Vec2<int>> absent = [];

        using (AnvilLoader world = new(directory, Registry, MinY, true)) {
            void Put(string name, ChunkData chunk) {
                chunk.PackData(Registry);
                world.PutChunk(chunk);
                expected[new Vec2<int>(chunk.ChunkX, chunk.ChunkZ)] = (name, chunk);
            }

            Put("uniform", Uniform(0, 0));
            Put("mixed sections, biomes and a block entity", Mixed(1, 0));
            Put("a section wider than an indirect palette", Wide(2, 0));
            Put("the floor and ceiling, in a negative region", Edges(-1, -1));

            // Two neighbours, one small and grown past its run so it has to move, one large and shrunk
            // into less of what it had, then a third written and taken away again.
            Put("grown", Mixed(5, 0));
            Put("shrunk", Noise(6, 0, 6));
            Put("grown", Noise(5, 0, 5));
            Put("shrunk", Uniform(6, 0));

            ChunkData deleted = Mixed(7, 0);
            deleted.PackData(Registry);
            world.PutChunk(deleted);
            world.DeleteChunk(new Vec2<int>(7, 0));
            absent.Add(new Vec2<int>(7, 0));

            world.Flush();
        }

        ChunkCount = expected.Count;

        StringBuilder json = new();
        json.Append($"{{\n  \"minY\": {MinY}, \"worldHeight\": {WorldHeight}, ");
        json.Append($"\"dataVersion\": {GameVersion.DataVersion},\n");
        json.Append("  \"absent\": [").Append(string.Join(", ", absent.Select(p => $"[{p.X}, {p.Y}]"))).Append("],\n");
        json.Append("  \"chunks\": [\n");
        json.Append(string.Join(",\n", expected.Values.Select(e => ChunkJson(e.Name, e.Chunk))));
        json.Append("\n  ]\n}\n");
        return json.ToString();
    }

    private static ChunkData NewChunk(int chunkX, int chunkZ) {
        return new ChunkData(WorldHeight) { ChunkX = chunkX, ChunkZ = chunkZ, MinY = MinY };
    }

    private static ChunkData Uniform(int chunkX, int chunkZ) {
        ChunkData chunk = NewChunk(chunkX, chunkZ);
        for (int y = 0; y < 64; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    chunk.SetBlock(x, y, z, Block.Stone);
                }
            }
        }

        return chunk;
    }

    private static ChunkData Mixed(int chunkX, int chunkZ) {
        ChunkData chunk = Uniform(chunkX, chunkZ);
        Random random = new(chunkX * 31 + chunkZ);

        for (int y = 64; y < 80; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    chunk.SetBlock(x, y, z, Band[random.Next(Band.Length)]);
                }
            }
        }

        for (int y = 0; y < WorldHeight; y += 4) {
            for (int z = 0; z < 16; z += 4) {
                for (int x = 0; x < 16; x += 4) {
                    chunk.SetBiome(x, y, z, Biomes[random.Next(Biomes.Length)], Registry);
                }
            }
        }

        const int chestY = 70;
        chunk.SetBlock(3, chestY, 9, Block.Chest);
        chunk.BlockEntities[new Vec3<int>(3, chestY + MinY, 9)] = new BlockEntity(3, chestY + MinY, 9,
            BlockEntityType.Chest, new CompoundTag(("marker", new StringTag("kept"))));

        return chunk;
    }

    /// <summary>More distinct states in one section than eight bits can index.</summary>
    private static ChunkData Wide(int chunkX, int chunkZ) {
        ChunkData chunk = NewChunk(chunkX, chunkZ);

        uint state = 1;
        for (int y = 64; y < 80; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    chunk.SetBlock(x, y, z, state);
                    state = (uint)((state + 7) % (Registry.Blocks.StatesCount - 1) + 1);
                }
            }
        }

        return chunk;
    }

    private static ChunkData Edges(int chunkX, int chunkZ) {
        ChunkData chunk = NewChunk(chunkX, chunkZ);
        chunk.SetBlock(0, 0, 0, Block.Bedrock);
        chunk.SetBlock(15, WorldHeight - 1, 15, Block.Glass);
        chunk.SetBiome(0, WorldHeight - 1, 0, Biome.Desert, Registry);
        return chunk;
    }

    /// <summary>Every section random over the whole state table, which compresses to many sectors.</summary>
    private static ChunkData Noise(int chunkX, int chunkZ, int seed) {
        ChunkData chunk = NewChunk(chunkX, chunkZ);
        Random random = new(seed);

        for (int y = 0; y < WorldHeight; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    chunk.SetBlock(x, y, z, (uint)random.Next(1, 200));
                }
            }
        }

        return chunk;
    }

    /// <summary>States and biomes run length encoded in y, z, x order, the order a section indexes.</summary>
    private static string ChunkJson(string name, ChunkData chunk) {
        List<(uint Value, int Count)> states = [];
        for (int y = 0; y < WorldHeight; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    Append(states, chunk.GetBlock(x, y, z));
                }
            }
        }

        List<(uint Value, int Count)> biomes = [];
        for (int y = 0; y < WorldHeight; y += 4) {
            for (int z = 0; z < 16; z += 4) {
                for (int x = 0; x < 16; x += 4) {
                    Append(biomes, chunk.GetBiome(x, y, z));
                }
            }
        }

        string entities = string.Join(", ", chunk.BlockEntities.Select(pair =>
            $"{{\"x\": {chunk.ChunkX * 16 + pair.Key.X}, \"y\": {pair.Key.Y}, \"z\": {chunk.ChunkZ * 16 + pair.Key.Z}, " +
            $"\"id\": \"{pair.Value.Type.Identifier}\", \"marker\": \"{pair.Value.Data.GetCompound()["marker"]?.GetString()}\"}}"));

        return $"    {{\"name\": \"{name}\", \"x\": {chunk.ChunkX}, \"z\": {chunk.ChunkZ},\n" +
               $"     \"states\": [{string.Join(", ", states.Select(s => $"[{s.Value}, {s.Count}]"))}],\n" +
               $"     \"biomes\": [{string.Join(", ", biomes.Select(b => $"[\"{Registry.Biomes[(int)b.Value].Identifier}\", {b.Count}]"))}],\n" +
               $"     \"blockEntities\": [{entities}]}}";
    }

    private static void Append(List<(uint Value, int Count)> runs, uint value) {
        if (runs.Count > 0 && runs[^1].Value == value) {
            runs[^1] = (value, runs[^1].Count + 1);
        } else {
            runs.Add((value, 1));
        }
    }
}
