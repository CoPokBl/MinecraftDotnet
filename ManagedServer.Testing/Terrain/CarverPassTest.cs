using ManagedServer.Terrain;
using ManagedServer.Terrain.Carvers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// That the carving pass runs, removes stone underground, and does it the same way twice.
/// </summary>
/// <remarks>
/// Deliberately not a conformance fixture, on the feature pass's reasoning: what a cave system looks
/// like is a walk of a few thousand steps whose every turn is a draw, so a fixture would pin the whole
/// pass or nothing. What is pinned here is what a fixture could not tell apart from a wrong walk
/// anyway.
/// <p/>
/// <see cref="TheSameChunkCarvesTheSameWhicheverNeighbourIsAskedFirst"/> is the load bearing one. The
/// pass replays 289 chunks of carvers over every chunk, so a carver whose seed depended on anything
/// beyond the source chunk would give two neighbours different opinions about the tunnel between them
/// and leave a wall down the chunk border.
/// </remarks>
[TestFixture]
public class CarverPassTest {
    private const long Seed = 1234567890L;

    /// <summary>Land rather than ocean, so there is stone above sea level to lose.</summary>
    private static readonly Vec2<int>[] Chunks = [
        new(0, 0), new(1, 0), new(0, 1), new(1, 1), new(4, 4), new(-3, 2)
    ];

    [Test]
    public void TerrainIsUncarvedWithoutTheCarverPass() {
        VanillaTerrainGenerator generator = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed);

        Assert.That(generator.HasCarvers, Is.False,
            "The carver pass has to be opt in, like everything else in this framework.");

        Assert.That(generator.WithCarvers().HasCarvers, Is.True);
    }

    [Test]
    public void CarvingRemovesStone() {
        Dictionary<Identifier, int> bare = Generate(VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed), Chunks);
        Dictionary<Identifier, int> carved =
            Generate(VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed).WithCarvers(), Chunks);

        int bareStone = bare.GetValueOrDefault(Block.Stone.Identifier);
        int carvedStone = carved.GetValueOrDefault(Block.Stone.Identifier);

        Assert.That(bareStone, Is.GreaterThan(0), "The bare terrain should have stone in it at all.");
        Assert.That(carvedStone, Is.LessThan(bareStone),
            "Carving should have taken stone out of the chunks.");

        // A carver reaching a chunk from up to eight away means most of the chunk's carving comes from
        // outside it, so a pass that only ran the chunk's own carvers would still pass the test above.
        // A percentage is what says the replay is happening.
        double removed = 1.0 - (double)carvedStone / bareStone;
        Assert.That(removed, Is.GreaterThan(0.01),
            "Carving removed almost no stone, which is what a pass that never replays its neighbours "
            + "looks like.");
    }

    /// <summary>
    /// The pass must not touch anything above the terrain, since it may only replace what its
    /// <c>replaceable</c> set names.
    /// </summary>
    [Test]
    public void CarvingDoesNotEatBedrock() {
        Dictionary<Identifier, int> bare = Generate(VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed), Chunks);
        Dictionary<Identifier, int> carved =
            Generate(VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed).WithCarvers(), Chunks);

        Assert.That(carved.GetValueOrDefault(Block.Bedrock.Identifier),
            Is.EqualTo(bare.GetValueOrDefault(Block.Bedrock.Identifier)));
    }

    /// <summary>
    /// A chunk's carving is decided by the source chunks around it and their seeds alone, so
    /// generating the same chunk twice, out of two differently ordered runs, has to agree exactly.
    /// </summary>
    [Test]
    public void TheSameChunkCarvesTheSameWhicheverNeighbourIsAskedFirst() {
        VanillaTerrainGenerator generator = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed).WithCarvers();

        uint[] first = Column(generator, new Vec2<int>(3, -2));

        // Generating a spread of other chunks in between is what would catch a carver drawing from
        // anything that outlives one chunk.
        foreach (Vec2<int> other in Chunks) {
            Generate(generator, [other]);
        }

        uint[] second = Column(generator, new Vec2<int>(3, -2));

        Assert.That(second, Is.EqualTo(first));
    }

    [Test]
    public void ADifferentSeedCarvesDifferently() {
        uint[] first = Column(VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed).WithCarvers(), new Vec2<int>(0, 0));
        uint[] second = Column(VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed + 1).WithCarvers(),
            new Vec2<int>(0, 0));

        Assert.That(second, Is.Not.EqualTo(first));
    }

    /// <summary>
    /// Every configured carver in the data has to parse. There is no not-transcribed list here, so a
    /// new carver type upstream fails this rather than silently producing a world missing a shape.
    /// </summary>
    [Test]
    public void EveryConfiguredCarverParses() {
        VanillaCarverData data = VanillaCarverData.Load(VanillaPack.Source);

        Assert.That(data.Ids, Is.Not.Empty);

        foreach (Identifier id in data.Ids) {
            Assert.That(data.Get(id), Is.Not.Null, $"{id} did not parse.");
        }
    }

    /// <summary>
    /// A biome's list is read in its own order, since a carver's index in it is half of the carver's
    /// seed.
    /// </summary>
    [Test]
    public void ABiomeSCarverListIsTheOneTheDatapackNames() {
        VanillaCarverData data = VanillaCarverData.Load(VanillaPack.Source);

        Assert.That(data.For("minecraft:plains"), Has.Count.EqualTo(3),
            "The overworld's biomes carve with cave, cave_extra_underground and canyon.");

        Assert.That(data.For("minecraft:nether_wastes"), Has.Count.EqualTo(1));

        // A biome this data has never heard of answers nothing rather than throwing, since the biome
        // registry is datapack driven and a consumer may have added one.
        Assert.That(data.For("example:nowhere"), Is.Empty);
    }

    /// <summary>A whole chunk of states, in the chunk's own order, for comparing two runs.</summary>
    private static uint[] Column(VanillaTerrainGenerator generator, Vec2<int> pos) {
        ChunkData chunk = new(384) { ChunkX = pos.X, ChunkZ = pos.Y, MinY = -64 };
        generator.AsProvider().GetChunk(ref chunk);

        uint[] states = new uint[16 * 16 * 384];
        int at = 0;

        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                for (int y = 0; y < 384; y++) {
                    states[at++] = chunk.GetBlock(x, y, z);
                }
            }
        }

        return states;
    }

    /// <summary>How many blocks of each kind a set of chunks came out holding.</summary>
    private static Dictionary<Identifier, int> Generate(VanillaTerrainGenerator generator,
        IReadOnlyList<Vec2<int>> chunks) {

        MinecraftRegistry registry = VanillaRegistry.Data;
        GeneratorTerrainProvider provider = generator.AsProvider();

        Dictionary<Identifier, int> counts = [];

        foreach (Vec2<int> pos in chunks) {
            ChunkData chunk = new(384) { ChunkX = pos.X, ChunkZ = pos.Y, MinY = -64 };
            provider.GetChunk(ref chunk);

            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    for (int y = 0; y < 384; y++) {
                        IBlock block = registry.Blocks.GetByStateId(chunk.GetBlock(x, y, z));

                        if (block.Air) {
                            continue;
                        }

                        counts[block.Identifier] = counts.GetValueOrDefault(block.Identifier) + 1;
                    }
                }
            }
        }

        return counts;
    }
}
