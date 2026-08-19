using System.Buffers.Binary;
using System.IO.Compression;
using ManagedServer.Terrain;
using ManagedServer.Terrain.Data;
using Minecraft.Data.Blocks;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Replays every block the real vanilla noise, surface and carver passes left in a chunk, from the
/// fixture <c>Conformance/terrainstage.sh</c> produced.
/// </summary>
/// <remarks>
/// <b>This is the step <see cref="TerrainConformanceTest"/> stops short of.</b> That one pins all
/// fifteen entries of the noise router, the climate sample and the biome the parameter list picks, at
/// exact zero tolerance, and says nothing about what those numbers become. The aquifer turning
/// <c>barrier</c> and the two <c>fluid_level</c> noises into water, lava or stone; <c>OreVeinifier</c>
/// turning the three <c>vein</c> noises into ore; the interpolation walk over the cells; and the whole
/// surface rule tree with the badlands spires and the frozen ocean icebergs around it, were visible
/// only through <see cref="WorldParityConformanceTest"/>, whose error bar is about a third of its own
/// value and which therefore cannot settle any of them.
/// <p/>
/// <b>It is a pass rather than a baseline, and it can be because of what these passes are.</b> All
/// three are pure functions of the world seed and the chunk position: none reads a neighbour's blocks,
/// none draws from a random shared with another chunk, and none depends on the order chunks were asked
/// for. So the order dependence that stops whole-world parity ever reaching zero does not exist here,
/// and a single differing block is the port being wrong.
/// <p/>
/// The carver pass replaying every chunk within eight looks like a dependence on those chunks and is
/// not: a source chunk's carvers are seeded from the world seed, the carver's index in that chunk's
/// biome's list and the source chunk position, and from nothing about what has been generated there.
/// <c>CarverPassTest</c> is that as a property, and this is the values.
/// <p/>
/// <b>The carve is the one stage the harness reaches by transcribing vanilla's loop rather than by
/// calling it.</b> <c>ChunkGenerator.applyCarvers</c> takes a <c>WorldGenRegion</c>, which is concrete
/// and needs a <c>ServerLevel</c>, while everything under it takes a <c>ChunkAccess</c>. So what is
/// measured is the whole of the carve: the walk, the ellipsoid, the block decisions, the aquifer's
/// answer and the surface fix-up. What is not is which chunks the loop replays and how it seeds them,
/// which stays pinned by <c>CarverPassTest</c> alone.
/// </remarks>
[TestFixture]
public class TerrainStageConformanceTest {
    /// <summary>The range the harness generated over, which is the overworld's own.</summary>
    private const int MinY = -64;
    private const int Height = 384;

    /// <summary>An iceberg's own block, which no surface rule writes.</summary>
    private static uint PackedIce => Minecraft.Data.Generated.Block.PackedIce.StateId;

    /// <summary>The badlands banding, which the spires pass moves the heightmap for.</summary>
    private static uint Terracotta => Minecraft.Data.Generated.Block.Terracotta.StateId;

    private static string FixturePath =>
        Path.Combine(TestContext.CurrentContext.TestDirectory, "Terrain", "vanilla-terrainstage.bin.gz");

    private sealed record Scene(int ChunkX, int ChunkZ, int MinY, int Height, uint[] Noise,
        uint[] Surface, uint[] Carved);

    private sealed record Fixture(long Seed, IReadOnlyList<Scene> Scenes);

    private static Fixture Read() {
        using FileStream file = File.OpenRead(FixturePath);
        using GZipStream gzip = new(file, CompressionMode.Decompress);
        using MemoryStream buffer = new();
        gzip.CopyTo(buffer);

        byte[] bytes = buffer.ToArray();
        int at = 0;

        long seed = BinaryPrimitives.ReadInt64BigEndian(bytes.AsSpan(at));
        at += 8;

        int count = BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(at));
        at += 4;

        List<Scene> scenes = [];

        for (int scene = 0; scene < count; scene++) {
            int chunkX = BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(at));
            int chunkZ = BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(at + 4));
            int minY = BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(at + 8));
            int height = BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(at + 12));
            at += 16;

            uint[] noise = ReadStates(bytes, ref at, height);
            uint[] surface = ReadStates(bytes, ref at, height);
            uint[] carved = ReadStates(bytes, ref at, height);

            scenes.Add(new Scene(chunkX, chunkZ, minY, height, noise, surface, carved));
        }

        return new Fixture(seed, scenes);
    }

    private static uint[] ReadStates(byte[] bytes, ref int at, int height) {
        uint[] states = new uint[height * 256];

        for (int i = 0; i < states.Length; i++) {
            states[i] = (uint)BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(at));
            at += 4;
        }

        return states;
    }

    [Test]
    public void EveryBlockOfAllThreePassesMatchesVanilla() {
        Fixture fixture = Read();

        VanillaTerrainGenerator generator = VanillaTerrainGenerator
            .Overworld(VanillaPack.Source, fixture.Seed)
            .WithCarvers();

        List<string> failures = [];

        // A fixture that decoded to nothing would compare clean against a port that also generates
        // nothing, so the sample is checked for content before it is trusted. Fifty six chunks: one
        // per biome the overworld climate table can name, which is what the surface rule tree branches
        // on before anything else, plus one picked for the iceberg on it.
        Assert.That(fixture.Scenes, Has.Count.EqualTo(56));

        foreach (Scene scene in fixture.Scenes) {
            // Per chunk the noise pass is a short list, since all it writes is the default block, the
            // aquifer's fluids and whatever the ore veins put in: a badlands chunk is air, stone,
            // deepslate and water and nothing else. What says the chunk is real is that the surface
            // pass then changed a good part of it.
            Assert.That(scene.Noise.Distinct().Count(), Is.GreaterThan(1),
                $"chunk {scene.ChunkX},{scene.ChunkZ} decoded to one block");
            Assert.That(scene.Noise.Zip(scene.Surface).Count(pair => pair.First != pair.Second),
                Is.GreaterThan(64), $"chunk {scene.ChunkX},{scene.ChunkZ} has no surface pass in it");
        }

        // The carve is the one pass that can legitimately do nothing to a given chunk, since whether a
        // tunnel reaches here is what it decides, and 51 of the 56 have one. A fixture whose third
        // array were a copy of its second would compare clean against a build with no carvers at all.
        Assert.That(fixture.Scenes.Count(scene => !scene.Surface.SequenceEqual(scene.Carved)),
            Is.GreaterThan(40), "the sample holds almost no carving, so it is not measuring the pass");

        // Across the sample it has to be rich, or 56 chunks are 56 of the same place. It holds 34
        // distinct blocks, and which 34 is what the sample is worth: raw_copper_block and copper_ore
        // say OreVeinifier ran, water and lava say the aquifer did, the four terracottas are the
        // badlands banding, and mycelium, podzol, snow_block, sand, sandstone and gravel are six more
        // surface rules.
        Assert.That(fixture.Scenes.SelectMany(scene => scene.Surface).Distinct().Count(),
            Is.GreaterThan(30), "the sample holds too few distinct blocks to be measuring much");

        // Both of the passes SurfaceSystem runs around the rule pass, since neither is a rule and
        // neither would be missed by the count above. The badlands spires move the heightmap the rules
        // then re-read, and the icebergs write over water the rules never see.
        Assert.That(fixture.Scenes.Any(scene => scene.Surface.Contains(PackedIce)), Is.True,
            "no chunk in the sample has an iceberg on it, so nothing covers that pass");
        Assert.That(fixture.Scenes.Any(scene => scene.Surface.Contains(Terracotta)), Is.True,
            "no chunk in the sample has badlands banding in it");

        foreach (Scene scene in fixture.Scenes) {
            Assert.That(scene.MinY, Is.EqualTo(MinY), "fixture generated over a different range");
            Assert.That(scene.Height, Is.EqualTo(Height), "fixture generated over a different range");

            (uint[] noise, uint[] surface, uint[] carved) =
                generator.TerrainStages(scene.ChunkX, scene.ChunkZ, MinY, MinY + Height);

            Compare(failures, scene, "noise", scene.Noise, noise);
            Compare(failures, scene, "surface", scene.Surface, surface);
            Compare(failures, scene, "carver", scene.Carved, carved);
        }

        Assert.That(failures, Is.Empty, string.Join("\n", failures.Take(40)));
    }

    /// <summary>
    /// Reports the first differing block of a pass and how many there were, since a wrong rule is
    /// thousands of blocks and the first one is what says which rule.
    /// </summary>
    private static void Compare(List<string> failures, Scene scene, string pass, uint[] expected,
        uint[] actual) {

        int differing = 0;
        string? first = null;

        for (int i = 0; i < expected.Length; i++) {
            if (expected[i] == actual[i]) {
                continue;
            }

            differing++;

            if (first is not null) {
                continue;
            }

            int y = MinY + (i / 256);
            int z = (i % 256) / 16;
            int x = i % 16;

            first = $"first at {(scene.ChunkX << 4) + x} {y} {(scene.ChunkZ << 4) + z}: "
                + $"ours {Name(actual[i])}, vanilla {Name(expected[i])}";
        }

        if (differing > 0) {
            failures.Add($"chunk {scene.ChunkX},{scene.ChunkZ} after the {pass} pass: "
                + $"{differing} of {expected.Length} blocks differ, {first}");
        }
    }

    private static string Name(uint stateId) {
        IBlock block = Minecraft.Data.Generated.VanillaRegistry.Data.Blocks.GetByStateId(stateId);
        return $"{block.Identifier}#{stateId}";
    }
}
