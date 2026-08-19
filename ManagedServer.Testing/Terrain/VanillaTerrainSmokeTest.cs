using ManagedServer.Terrain;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Generates real chunks and asserts the shape of what comes out.
/// </summary>
/// <remarks>
/// Deliberately weak on exact values, which is what <c>Conformance/terrain.sh</c> is for. What this
/// catches is a whole stage silently doing nothing: an unbound noise reads as flat zero and a dropped
/// surface rule leaves bare stone, and both of those produce a world that generates without error and
/// is obviously wrong to look at.
/// </remarks>
[TestFixture]
public class VanillaTerrainSmokeTest {
    private const long Seed = 1234567890L;
    private const int MinY = -64;
    private const int Height = 384;

    private static ChunkData Generate(VanillaTerrainGenerator generator, int chunkX, int chunkZ) {
        ChunkData chunk = new(Height) { ChunkX = chunkX, ChunkZ = chunkZ, MinY = MinY };
        generator.AsProvider().GetChunk(ref chunk);
        return chunk;
    }

    private static uint StateAt(ChunkData chunk, int localX, int gameY, int localZ) {
        return chunk.GetBlock(localX, gameY - MinY, localZ);
    }

    [Test]
    public void TestTerrainHasAGroundLevel() {
        VanillaTerrainGenerator generator = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed);
        ChunkData chunk = Generate(generator, 0, 0);

        // Every column of an overworld chunk has something solid in it: the world is not a void and
        // the density functions are not all reading zero.
        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                bool foundSolid = false;
                for (int y = MinY; y < MinY + Height; y++) {
                    IBlock block = VanillaRegistry.Data.Blocks.GetByStateId(StateAt(chunk, x, y, z));
                    if (!block.Air && block.Fluid == null) {
                        foundSolid = true;
                        break;
                    }
                }

                Assert.That(foundSolid, Is.True, $"Column {x},{z} is entirely air and fluid.");
            }
        }
    }

    [Test]
    public void TestBedrockAtTheBottomAndAirAtTheTop() {
        VanillaTerrainGenerator generator = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed);
        ChunkData chunk = Generate(generator, 3, -7);

        // The bedrock rule is a vertical gradient, certain at the world floor and impossible five
        // blocks up, so only the floor itself is guaranteed.
        Assert.That(StateAt(chunk, 0, MinY, 0), Is.EqualTo(Block.Bedrock.StateId));

        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                Assert.That(StateAt(chunk, x, MinY, z), Is.EqualTo(Block.Bedrock.StateId));
                Assert.That(StateAt(chunk, x, MinY + Height - 1, z), Is.EqualTo(Block.Air.StateId));
            }
        }
    }

    [Test]
    public void TestSurfaceRulesRan() {
        VanillaTerrainGenerator generator = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed);

        // A wide enough sweep that at least one column lands on dry ground: the surface rules put
        // something other than stone on top of it. Bare stone everywhere means the rules were parsed
        // and then never applied.
        HashSet<uint> topBlocks = [];

        for (int chunkX = 0; chunkX < 3; chunkX++) {
            for (int chunkZ = 0; chunkZ < 3; chunkZ++) {
                ChunkData chunk = Generate(generator, chunkX, chunkZ);

                for (int x = 0; x < 16; x += 4) {
                    for (int z = 0; z < 16; z += 4) {
                        for (int y = MinY + Height - 1; y >= MinY; y--) {
                            uint state = StateAt(chunk, x, y, z);
                            if (state == Block.Air.StateId) {
                                continue;
                            }

                            topBlocks.Add(state);
                            break;
                        }
                    }
                }
            }
        }

        Assert.That(topBlocks, Is.Not.Empty);
        Assert.That(topBlocks, Does.Not.Contain(Block.Stone.StateId).Or.Count.GreaterThan(1),
            "Every column tops out in plain stone, so no surface rule ever matched.");
    }

    [Test]
    public void TestSeaLevelIsWater() {
        VanillaTerrainGenerator generator = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed);

        // Somewhere in this area there is ocean, and its surface is at the settings' sea level rather
        // than at whatever the aquifer decided. Wide enough to be sure of finding some: a seed can put
        // a lot of land in a row.
        bool foundWater = false;

        for (int chunkX = 0; chunkX < 8 && !foundWater; chunkX++) {
            for (int chunkZ = 0; chunkZ < 8 && !foundWater; chunkZ++) {
                ChunkData chunk = Generate(generator, chunkX, chunkZ);

                for (int x = 0; x < 16 && !foundWater; x++) {
                    for (int z = 0; z < 16 && !foundWater; z++) {
                        if (StateAt(chunk, x, generator.SeaLevel - 1, z) == Block.Water.StateId) {
                            foundWater = true;
                        }
                    }
                }
            }
        }

        Assert.That(foundWater, Is.True, "No water at sea level anywhere in sixty four chunks.");
    }

    [Test]
    public void TestBiomesVary() {
        VanillaTerrainGenerator generator = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed);

        // A chunk's biome palette is not all plains, which is what an unbound climate noise or a
        // parameter list that failed to load would produce.
        HashSet<uint> biomes = [];

        for (int chunkX = 0; chunkX < 4; chunkX++) {
            for (int chunkZ = 0; chunkZ < 4; chunkZ++) {
                ChunkData chunk = Generate(generator, chunkX * 8, chunkZ * 8);
                foreach (ChunkSection section in chunk.Sections) {
                    uint[,,] sectionBiomes = section.Biomes;
                    for (int bx = 0; bx < 4; bx++) {
                        for (int by = 0; by < 4; by++) {
                            for (int bz = 0; bz < 4; bz++) {
                                biomes.Add(sectionBiomes[bx, by, bz]);
                            }
                        }
                    }
                }
            }
        }

        Assert.That(biomes.Count, Is.GreaterThan(1), "Every biome cell in the world is the same biome.");
    }

    [Test]
    public void TestTwoSeedsDisagree() {
        ChunkData first = Generate(VanillaTerrainGenerator.Overworld(VanillaPack.Source, 1L), 0, 0);
        ChunkData second = Generate(VanillaTerrainGenerator.Overworld(VanillaPack.Source, 2L), 0, 0);

        bool differs = false;
        for (int y = MinY; y < MinY + Height && !differs; y += 8) {
            for (int x = 0; x < 16 && !differs; x++) {
                for (int z = 0; z < 16 && !differs; z++) {
                    if (StateAt(first, x, y, z) != StateAt(second, x, y, z)) {
                        differs = true;
                    }
                }
            }
        }

        Assert.That(differs, Is.True, "Two different seeds produced the same chunk.");
    }

    [Test]
    public void TestSameSeedRepeats() {
        // Generation runs on a pool and a chunk may be asked for more than once, so the same seed and
        // position has to give the same chunk whatever else has been generated in between.
        VanillaTerrainGenerator generator = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed);

        ChunkData first = Generate(generator, 5, 5);
        Generate(generator, -3, 11);
        ChunkData second = Generate(generator, 5, 5);

        for (int y = MinY; y < MinY + Height; y += 4) {
            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    Assert.That(StateAt(second, x, y, z), Is.EqualTo(StateAt(first, x, y, z)),
                        $"Position {x},{y},{z} differs between two runs of the same chunk.");
                }
            }
        }
    }
}
