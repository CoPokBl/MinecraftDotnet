using System.Buffers.Binary;
using System.IO.Compression;
using System.Text;
using ManagedServer.Terrain;
using ManagedServer.Terrain.Data;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Generates the scenes the real server generated and counts the blocks that came out different, from
/// the fixture <c>Conformance/worldparity.sh</c> produced.
/// </summary>
/// <remarks>
/// Every other conformance fixture here drives one vanilla method over inputs we chose. None of them
/// can see a stage that is right on its own and wired up wrong, because the wiring is what they hold
/// fixed: the router matched vanilla at every position while villages were coming out as roads with
/// nothing on them, and it would have gone on matching if the ore features had never run at all.
/// <p/>
/// So this measures the world instead, and the measurement is a <b>number rather than a pass</b>.
/// Whole-world parity is not something a port arrives at in one go, and a test that can only say "not
/// yet" says nothing about whether last week's change helped. <see cref="Baseline"/> is that number
/// per scene, asserted in both directions on <c>PlacementConformanceTest</c>'s reasoning: a scene that
/// differs more is a regression, and a scene that differs less is a fix nobody wrote down, which
/// leaves the next reader with a number that describes a world that no longer exists.
/// <p/>
/// Set <c>WORLD_PARITY_REPORT=1</c> for the breakdown by block, by band and by scene, which is how the
/// next thing to fix gets found.
/// </remarks>
[TestFixture]
public class WorldParityConformanceTest {
    private const string Fixture = "Terrain/vanilla-world.bin.gz";

    /// <summary>
    /// How many chunks around a scene are generated without being compared.
    /// <para>
    /// One, because that is how far a chunk's decoration reaches: vanilla decorates through a
    /// <c>WorldGenRegion</c> spanning the three by three around the chunk, and ours forks into the
    /// same ring. Without it every scene would be missing whatever its neighbours were owed and the
    /// count would be measuring the margin rather than the port.
    /// </para>
    /// </summary>
    private const int Margin = 1;

    /// <summary>
    /// Blocks per scene that differ from what the real server generated, as of the last time anyone
    /// looked.
    /// <para>
    /// A scene is 9 chunks of 98,304 blocks, so 884,736 each. Zero is the target and none of these is
    /// zero; what they are for is telling a change that helped from a change that did not.
    /// </para>
    /// <para>
    /// <b>These numbers belong to the committed fixture and not to the seed.</b> A chunk decorates
    /// through a region spanning its neighbours, so what a neighbour forked in before a chunk started
    /// sits in front of that chunk's own features and what it forks in later sits on top. The
    /// recording was made in the real server's chunk order and this is made in ours, so the two
    /// disagree wherever that matters, and no port reaches zero against a recording made this way.
    /// </para>
    /// <para>
    /// <b>How much that is worth has been measured rather than guessed, and it is a lot.</b> Varying
    /// only the order these scenes are generated in, through <c>WORLD_PARITY_ORDER</c> and changing
    /// nothing else, moves the total from 29966 to 40735: an error bar of about a third. The jungle
    /// alone spans 17828 to 19398. <b>So a change worth a couple of thousand blocks here is not
    /// measurable here</b>, and a scene count that moved is not on its own evidence of anything.
    /// <c>Conformance/featuretrace.sh</c> is what settles a feature instead: it runs the vanilla
    /// feature over the same bytes this build had in front of it, so the order drops out entirely and
    /// what is left is the port.
    /// </para>
    /// </summary>
    private static readonly Dictionary<string, int> Baseline = new() {
        ["jungle"] = 18045,
        ["desert"] = 537,
        ["badlands"] = 1308,
        ["deep_ocean"] = 1003,
        ["jagged_peaks"] = 3903,
        ["plains_village"] = 656,

        ["taiga_village"] = 1224
    };

    /// <summary>
    /// Biome cells per scene that differ, on <see cref="Baseline"/>'s terms.
    /// <para>
    /// All zero, and unlike the block counts this one really is a pass: the biome grid is a pure
    /// function of the climate router and the region search, with no feature pass on top of it to
    /// carry an order dependence. A non zero entry here is a bug rather than a gap.
    /// </para>
    /// </summary>
    private static readonly Dictionary<string, int> BiomeBaseline = new() {
        ["jungle"] = 0,
        ["desert"] = 0,
        ["badlands"] = 0,
        ["deep_ocean"] = 0,
        ["jagged_peaks"] = 0,
        ["plains_village"] = 0,
        ["taiga_village"] = 0
    };

    /// <summary>
    /// Report every difference broken down rather than only the counts, which is how the next thing to
    /// fix gets found.
    /// </summary>
    private static readonly bool Report = Environment.GetEnvironmentVariable("WORLD_PARITY_REPORT") == "1";

    /// <summary>
    /// The scene whose every differing position is written to <c>&lt;scene&gt;-parity.txt</c>, which is
    /// what turns the counts into something that can be clustered into the features that produced them.
    /// </summary>
    private static readonly string? Dump = Environment.GetEnvironmentVariable("WORLD_PARITY_DUMP");

    private sealed record Scene(string Name, int ChunkX, int ChunkZ, int Size);

    private sealed record Chunk(int X, int Z, int[] Blocks, int[] Biomes);

    private sealed record Fixtures(
        long Seed,
        int MinY,
        int Height,
        string[] BlockPalette,
        string[] BiomePalette,
        Scene[] Scenes,
        Dictionary<Vec2<int>, Chunk> Chunks);

    /// <summary>What one scene's comparison came out at.</summary>
    /// <remarks>
    /// The volumes are what tell the two kinds of wrongness apart. A block that both sides have the
    /// same amount of and disagree about the position of is a feature seeded or ordered differently;
    /// a block one side has more of is a count, a size or a condition. Reading only the pairs makes
    /// both look identical, since either way the pair is symmetric.
    /// </remarks>
    private sealed class Tally {
        public int Blocks { get; set; }
        public int Biomes { get; set; }
        public Dictionary<string, int> ByPair { get; } = [];
        public Dictionary<int, int> ByBand { get; } = [];
        public Dictionary<string, int> OurMisplaced { get; } = [];
        public Dictionary<string, int> TheirMisplaced { get; } = [];

        /// <summary>Every block of the scene, by state id, which is what the misplaced counts are a
        /// fraction of.</summary>
        public int[] OurStates { get; } = new int[VanillaRegistry.Data.Blocks.StatesCount];
        public int[] TheirStates { get; } = new int[VanillaRegistry.Data.Blocks.StatesCount];

        /// <summary>Every differing position, when a scene is being dumped.</summary>
        public List<string> Positions { get; } = [];

        /// <summary>The same counts summed per block rather than per state.</summary>
        public Dictionary<string, (int Ours, int Theirs)> Volumes() {
            Dictionary<string, (int Ours, int Theirs)> volumes = [];

            for (uint state = 0; state < OurStates.Length; state++) {
                if (OurStates[state] == 0 && TheirStates[state] == 0) {
                    continue;
                }

                string name = Name(state);
                (int ours, int theirs) = volumes.GetValueOrDefault(name);
                volumes[name] = (ours + OurStates[state], theirs + TheirStates[state]);
            }

            return volumes;
        }
    }

    private static Fixtures Read() {
        string path = Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);

        using FileStream file = File.OpenRead(path);
        using GZipStream gzip = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(gzip);

        long seed = ReadInt64(reader);
        int minY = ReadInt32(reader);
        int height = ReadInt32(reader);

        string[] blockPalette = ReadPalette(reader);
        string[] biomePalette = ReadPalette(reader);

        Scene[] scenes = new Scene[ReadInt32(reader)];
        for (int i = 0; i < scenes.Length; i++) {
            scenes[i] = new Scene(ReadJavaUtf(reader), ReadInt32(reader), ReadInt32(reader),
                ReadInt32(reader));
        }

        int chunkCount = ReadInt32(reader);
        Dictionary<Vec2<int>, Chunk> chunks = new(chunkCount);

        for (int i = 0; i < chunkCount; i++) {
            int x = ReadInt32(reader);
            int z = ReadInt32(reader);
            chunks[new Vec2<int>(x, z)] = new Chunk(x, z,
                ReadRuns(reader, height * 16 * 16),
                ReadRuns(reader, height / 4 * 4 * 4));
        }

        return new Fixtures(seed, minY, height, blockPalette, biomePalette, scenes, chunks);
    }

    private static string[] ReadPalette(BinaryReader reader) {
        string[] values = new string[ReadInt32(reader)];
        for (int i = 0; i < values.Length; i++) {
            values[i] = ReadJavaUtf(reader);
        }

        return values;
    }

    private static int[] ReadRuns(BinaryReader reader, int cells) {
        int[] values = new int[cells];
        int runs = ReadInt32(reader);
        int at = 0;

        for (int run = 0; run < runs; run++) {
            int length = ReadInt32(reader);
            int value = ReadInt32(reader);

            for (int i = 0; i < length; i++) {
                values[at++] = value;
            }
        }

        if (at != cells) {
            throw new InvalidDataException($"The runs cover {at} cells, not {cells}.");
        }

        return values;
    }

    // Java's DataOutputStream is big endian throughout; BinaryReader is little endian.
    private static int ReadInt32(BinaryReader reader) =>
        BinaryPrimitives.ReadInt32BigEndian(reader.ReadBytes(4));

    private static long ReadInt64(BinaryReader reader) =>
        BinaryPrimitives.ReadInt64BigEndian(reader.ReadBytes(8));

    private static string ReadJavaUtf(BinaryReader reader) {
        int length = BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(2));
        return Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    /// <summary>
    /// A provider for one scene.
    /// </summary>
    /// <remarks>
    /// One per scene rather than one for the lot, because a provider carries the fork queue and the
    /// structure start cache and those are per world.
    /// <para>
    /// Built before anything generates, never alongside: parsing the density function tree walks a
    /// shared set of the ids it has already resolved, so two threads building a generator at once
    /// throw. Generating is what is thread safe, and it is what the time goes on.
    /// </para>
    /// </remarks>
    private static GeneratorTerrainProvider Build(Fixtures fixtures, out CollectingHost host) {
        VanillaTerrainGenerator generator = VanillaTerrainGenerator
            .Overworld(VanillaPack.Source, fixtures.Seed)
            .WithCarvers()
            .WithFeatures()
            .WithStructures();

        GeneratorTerrainProvider provider = generator.AsProvider();
        host = new CollectingHost(fixtures.MinY, fixtures.MinY + fixtures.Height);
        provider.Attach(host);

        return provider;
    }

    /// <summary>
    /// The scene generated by us, keyed by chunk.
    /// </summary>
    /// <remarks>
    /// The margin is generated as well as the scene, so every compared chunk has all eight of its
    /// neighbours decorated before anything is read.
    /// </remarks>
    private static Dictionary<Vec2<int>, ChunkData> Generate(Fixtures fixtures, Scene scene,
        GeneratorTerrainProvider provider, CollectingHost host) {

        foreach ((int x, int z) in Order(scene)) {
            ChunkData chunk = new(fixtures.Height) { ChunkX = x, ChunkZ = z, MinY = fixtures.MinY };
            provider.GetChunk(ref chunk);
            host.Publish(chunk);
        }

        return host.Chunks;
    }

    /// <summary>
    /// The order the scene's chunks are generated in.
    /// </summary>
    /// <remarks>
    /// <b>Which order this is decides part of the count, and that is vanilla's own behaviour rather
    /// than a choice here.</b> A chunk decorates through a region spanning its neighbours, so what a
    /// neighbour forked in before a chunk started is in front of that chunk's own features, and a
    /// neighbour that has not decorated yet forks in afterwards instead. The recording was made in the
    /// real server's order and this is made in ours, so the two cannot agree about the chunks where it
    /// matters. <c>WORLD_PARITY_ORDER</c> varies it, which is how much of the count that is worth gets
    /// measured rather than argued about.
    /// </remarks>
    private static IEnumerable<(int X, int Z)> Order(Scene scene) {
        int from = -Margin, to = scene.Size + Margin;
        List<(int X, int Z)> chunks = [];

        for (int a = from; a < to; a++) {
            for (int b = from; b < to; b++) {
                chunks.Add(Environment.GetEnvironmentVariable("WORLD_PARITY_ORDER") switch {
                    "zmajor" => (scene.ChunkX + b, scene.ChunkZ + a),
                    _ => (scene.ChunkX + a, scene.ChunkZ + b)
                });
            }
        }

        if (Environment.GetEnvironmentVariable("WORLD_PARITY_ORDER") == "reverse") {
            chunks.Reverse();
        }

        return chunks;
    }

    private static Tally Compare(Fixtures fixtures, Scene scene, GeneratorTerrainProvider provider,
        CollectingHost host, uint[] blockStates, uint[] biomeIds) {

        Dictionary<Vec2<int>, ChunkData> ours = Generate(fixtures, scene, provider, host);
        Tally tally = new();

        for (int chunkX = scene.ChunkX; chunkX < scene.ChunkX + scene.Size; chunkX++) {
            for (int chunkZ = scene.ChunkZ; chunkZ < scene.ChunkZ + scene.Size; chunkZ++) {
                Chunk theirs = fixtures.Chunks[new Vec2<int>(chunkX, chunkZ)];
                ChunkData mine = ours[new Vec2<int>(chunkX, chunkZ)];

                for (int y = 0; y < fixtures.Height; y++) {
                    for (int z = 0; z < 16; z++) {
                        for (int x = 0; x < 16; x++) {
                            uint expected = blockStates[theirs.Blocks[(y * 16 + z) * 16 + x]];
                            uint actual = mine.GetBlock(x, y, z);

                            if (Report) {
                                tally.OurStates[actual]++;
                                tally.TheirStates[expected]++;
                            }

                            if (actual == expected) {
                                continue;
                            }

                            tally.Blocks++;
                            tally.ByBand[(fixtures.MinY + y) >> 4] =
                                tally.ByBand.GetValueOrDefault((fixtures.MinY + y) >> 4) + 1;

                            if (!Report && Dump != scene.Name) {
                                continue;
                            }

                            string ourName = Name(actual);
                            string theirName = Name(expected);

                            tally.ByPair[$"{ourName} -> {theirName}"] =
                                tally.ByPair.GetValueOrDefault($"{ourName} -> {theirName}") + 1;
                            tally.OurMisplaced[ourName] = tally.OurMisplaced.GetValueOrDefault(ourName) + 1;
                            tally.TheirMisplaced[theirName] =
                                tally.TheirMisplaced.GetValueOrDefault(theirName) + 1;

                            if (Dump == scene.Name) {
                                // The fixture's palette is written as full state strings, so naming
                                // ours through it is what makes two blocks that differ only in a
                                // property readable.
                                int ourIndex = Array.IndexOf(blockStates, actual);

                                tally.Positions.Add($"{chunkX * 16 + x} {fixtures.MinY + y} "
                                    + $"{chunkZ * 16 + z} "
                                    + $"{(ourIndex < 0 ? ourName : fixtures.BlockPalette[ourIndex])} "
                                    + $"{fixtures.BlockPalette[theirs.Blocks[(y * 16 + z) * 16 + x]]}");
                            }
                        }
                    }
                }

                for (int cellY = 0; cellY < fixtures.Height / 4; cellY++) {
                    for (int cellZ = 0; cellZ < 4; cellZ++) {
                        for (int cellX = 0; cellX < 4; cellX++) {
                            uint expected = biomeIds[theirs.Biomes[(cellY * 4 + cellZ) * 4 + cellX]];
                            uint actual = mine.GetBiome(cellX * 4, cellY * 4, cellZ * 4);

                            if (actual == expected) {
                                continue;
                            }

                            tally.Biomes++;

                            if (Dump == scene.Name) {
                                int ourIndex = Array.IndexOf(biomeIds, actual);

                                tally.Positions.Add($"biome {chunkX * 16 + cellX * 4} "
                                    + $"{fixtures.MinY + cellY * 4} {chunkZ * 16 + cellZ * 4} "
                                    + $"{(ourIndex < 0 ? actual.ToString() : fixtures.BiomePalette[ourIndex])} "
                                    + $"{fixtures.BiomePalette[theirs.Biomes[(cellY * 4 + cellZ) * 4 + cellX]]}");
                            }
                        }
                    }
                }
            }
        }

        return tally;
    }

    /// <summary>The fixture's palettes as our own ids, which is what makes the comparison one integer.</summary>
    private static uint[] Resolve(string[] palette, Func<string, uint> resolve) {
        uint[] ids = new uint[palette.Length];
        for (int i = 0; i < palette.Length; i++) {
            ids[i] = resolve(palette[i]);
        }

        return ids;
    }

    private static string Name(uint state) =>
        VanillaRegistry.Data.Blocks.GetByStateId(state).Identifier.ToString();

    [Test]
    public void TheWorldMatchesVanillaBlockForBlock() {
        Fixtures fixtures = Read();
        MinecraftRegistry registry = VanillaRegistry.Data;

        uint[] blockStates = Resolve(fixtures.BlockPalette,
            written => BlockStateStrings.Parse(registry, written));
        uint[] biomeIds = Resolve(fixtures.BiomePalette,
            written => (uint)registry.Biomes.GetProtocolId(Identifier.Parse(written)));

        // A scene has a provider of its own and touches nothing another scene touches, so they go at
        // once: seven scenes of 25 chunks each is most of a minute in a row.
        List<(Scene Scene, GeneratorTerrainProvider Provider, CollectingHost Host)> work = [];
        foreach (Scene scene in fixtures.Scenes) {
            work.Add((scene, Build(fixtures, out CollectingHost host), host));
        }

        Dictionary<string, Tally> tallies = [];
        Parallel.ForEach(work, entry => {
            Tally tally = Compare(fixtures, entry.Scene, entry.Provider, entry.Host, blockStates,
                biomeIds);

            lock (tallies) {
                tallies[entry.Scene.Name] = tally;
            }
        });

        Dictionary<string, int> blocks = [];
        Dictionary<string, int> biomes = [];
        StringBuilder report = new();

        long perScene = 0;

        foreach (Scene scene in fixtures.Scenes) {
            Tally tally = tallies[scene.Name];
            blocks[scene.Name] = tally.Blocks;
            biomes[scene.Name] = tally.Biomes;
            perScene = scene.Size * scene.Size * (long)fixtures.Height * 256;

            report.AppendLine($"  {scene.Name,-16} {tally.Blocks,9} blocks "
                + $"({tally.Blocks * 100.0 / perScene:F3}%), {tally.Biomes,6} biome cells");

            if (!Report) {
                continue;
            }

            foreach ((int band, int count) in tally.ByBand.OrderBy(entry => entry.Key)) {
                report.AppendLine($"      y {band * 16,5}..{band * 16 + 15,5}: {count,8}");
            }

            foreach ((string pair, int count) in tally.ByPair.OrderByDescending(entry => entry.Value)
                .Take(15)) {

                report.AppendLine($"      {count,8}  {pair}");
            }

            Dictionary<string, (int Ours, int Theirs)> volumes = tally.Volumes();

            foreach (string block in tally.OurMisplaced.Keys.Union(tally.TheirMisplaced.Keys)
                .OrderByDescending(block => tally.OurMisplaced.GetValueOrDefault(block)
                    + tally.TheirMisplaced.GetValueOrDefault(block))
                .Take(15)) {

                int ourCount = tally.OurMisplaced.GetValueOrDefault(block);
                int theirCount = tally.TheirMisplaced.GetValueOrDefault(block);
                (int ourVolume, int theirVolume) = volumes.GetValueOrDefault(block);

                report.AppendLine($"      misplaced {block,-34} ours {ourCount,7} of {ourVolume,8}, "
                    + $"vanilla {theirCount,7} of {theirVolume,8}");
            }
        }

        if (Dump is not null && tallies.TryGetValue(Dump, out Tally? dumped)) {
            File.WriteAllLines(Dump + "-parity.txt", dumped.Positions);
        }

        long total = blocks.Values.Sum(count => (long)count);
        long cells = perScene * fixtures.Scenes.Length;

        report.Insert(0, $"{total} of {cells} blocks differ from vanilla "
            + $"({total * 100.0 / cells:F3}%)" + Environment.NewLine);

        TestContext.Out.Write(report.ToString());

        Assert.Multiple(() => {
            Assert.That(blocks, Is.EqualTo(Baseline),
                "The world differs from vanilla by a different amount than the baseline records. "
                + "Update Baseline if the change was deliberate.\n" + report);

            Assert.That(biomes, Is.EqualTo(BiomeBaseline),
                "The biome grid differs from vanilla by a different amount than the baseline "
                + "records.\n" + report);
        });
    }

    /// <summary>Holds every generated chunk, so a fork into one already generated lands in it.</summary>
    private sealed class CollectingHost(int minY, int maxY) : ITerrainHost {
        public Dictionary<Vec2<int>, ChunkData> Chunks { get; } = [];

        public int MinY => minY;
        public int MaxY => maxY;
        public MinecraftRegistry Registry => VanillaRegistry.Data;

        public event Action<Vec2<int>>? ChunkAvailable;

        public bool TryApplyToLoadedChunk(Vec2<int> chunk, Action<ChunkData> apply) {
            if (!Chunks.TryGetValue(chunk, out ChunkData? data)) {
                return false;
            }

            apply(data);
            return true;
        }

        public void Publish(ChunkData chunk) {
            Vec2<int> pos = new(chunk.ChunkX, chunk.ChunkZ);
            Chunks[pos] = chunk;
            ChunkAvailable?.Invoke(pos);
        }
    }
}
