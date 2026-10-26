using ManagedServer.Terrain;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Structures;
using Minecraft.Schemas;
using NUnit.Framework;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Prints one chunk per biome, which is where <c>Conformance/structurelayout.sh</c>'s clusters come
/// from.
/// </summary>
/// <remarks>
/// What a structure sample is worth is decided by which biomes it reaches: an ocean monument needs deep
/// ocean and a mansion needs dark forest, so a run over plains says nothing about either. This is how
/// that list is rebuilt on a seed or version change, and it is explicit because its whole output is a
/// list for a human to paste into a shell script.
/// <p/>
/// It searches with this build's own biome source, which decides only <i>where to look</i>. What
/// structure vanilla then starts there is vanilla's answer, so a placement rule that is wrong shows up
/// in the comparison rather than being hidden by the choice of sample.
/// </remarks>
[TestFixture]
[Explicit]
public class FindStructureClusters {
    /// <summary>
    /// The seed every worldgen fixture in the tree uses. <c>SEED</c> overrides it, which is what the
    /// decoration parity scatter needs: that one runs at its own seed and wants its own coordinates.
    /// </summary>
    private static readonly long Seed =
        long.Parse(Environment.GetEnvironmentVariable("SEED") ?? "1234567890");

    /// <summary>
    /// The biomes worth having a cluster in: one per structure set's biome list, plus the surface
    /// biomes whose features the decoration metric wants covered.
    /// </summary>
    private static readonly string[] Wanted = [
        "minecraft:dark_forest", "minecraft:deep_dark", "minecraft:deep_ocean",
        "minecraft:deep_frozen_ocean", "minecraft:warm_ocean", "minecraft:lukewarm_ocean",
        "minecraft:swamp", "minecraft:mangrove_swamp", "minecraft:jungle", "minecraft:bamboo_jungle",
        "minecraft:desert", "minecraft:savanna", "minecraft:snowy_plains", "minecraft:snowy_taiga",
        "minecraft:badlands", "minecraft:beach", "minecraft:snowy_beach", "minecraft:plains",
        "minecraft:taiga", "minecraft:windswept_hills", "minecraft:ice_spikes", "minecraft:cherry_grove",
        "minecraft:dripstone_caves", "minecraft:lush_caves", "minecraft:mushroom_fields",
        "minecraft:old_growth_pine_taiga", "minecraft:sunflower_plains", "minecraft:frozen_ocean",

        // The biomes the decoration metric reaches and whose features it still measures with nothing.
        // A feature that fires only in one rare biome is covered by no run until a chunk of that biome
        // is asked for by name, exactly as mushroom_fields is.
        "minecraft:pale_garden", "minecraft:meadow", "minecraft:windswept_savanna",
        "minecraft:deep_frozen_ocean", "minecraft:eroded_badlands", "minecraft:flower_forest",
        "minecraft:old_growth_spruce_taiga", "minecraft:grove", "minecraft:snowy_slopes"
    ];

    /// <summary>Every eighth chunk, which is two biome cells and finer than any biome is small.</summary>
    private const int Step = 8;

    /// <summary><c>DIMENSION=nether</c> or <c>DIMENSION=end</c> searches that dimension's biome source instead.</summary>
    private static VanillaTerrainGenerator Generator() {
        return Environment.GetEnvironmentVariable("DIMENSION") switch {
            "nether" => VanillaTerrainGenerator.Nether(VanillaPack.Source, Seed),
            "end" => VanillaTerrainGenerator.End(VanillaPack.Source, Seed),
            _ => VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed)
        };
    }

    [Test]
    public void Print() {
        VanillaTerrainGenerator generator = Generator().WithFeatures();

        Dictionary<string, (int, int)> found = [];
        int radius = int.Parse(Environment.GetEnvironmentVariable("SEARCH") ?? "1200");

        // Every biome the climate table can name, not a list to keep up to date. Wanted is then the
        // set that must not be missed rather than the set to look for, so a biome added upstream turns
        // up in the output instead of being silently absent from every sample built off it.
        int possible = generator.PossibleBiomes.Count;

        // Outward in square rings, so the first hit for a biome is the closest one and the clusters
        // stay near enough the origin to be looked at with TestServer.
        for (int ring = 0; ring <= radius && found.Count < possible; ring += Step) {
            for (int chunkX = -ring; chunkX <= ring; chunkX += Step) {
                for (int chunkZ = -ring; chunkZ <= ring; chunkZ += Step) {
                    if (Math.Max(Math.Abs(chunkX), Math.Abs(chunkZ)) != ring) {
                        continue;
                    }

                    // Two heights, since the cave biomes never appear at the surface.
                    Look(generator, found, chunkX, chunkZ, 16);
                    Look(generator, found, chunkX, chunkZ, -12);
                }
            }
        }

        foreach ((string biome, (int cx, int cz)) in found.OrderBy(e => e.Key, StringComparer.Ordinal)) {
            TestContext.Out.WriteLine($"    \"{cx}:{cz}\"   # {biome[10..]}");
        }

        TestContext.Out.WriteLine($"found {found.Count} of {generator.PossibleBiomes.Count} biomes");
        TestContext.Out.WriteLine("never found: "
            + string.Join(", ", generator.PossibleBiomes.Select(biome => biome.ToString())
                .Where(biome => !found.ContainsKey(biome))));
    }

    /// <summary>
    /// Prints a chunk each structure really starts in, which is what the decoration parity sample
    /// needs to measure what a structure writes.
    /// </summary>
    /// <remarks>
    /// <b>This is not <see cref="PrintForStructures"/>, and the difference matters.</b> That one walks
    /// the placement arithmetic and reports where the roll passes and the biome allows, which is cheap
    /// because it builds no layout. Most of those chunks hold nothing: a structure still declines when
    /// it is laid out, on sea level, on its footprint's corners or on the terrain under it, so a dump
    /// built from candidates reaches a handful of structures out of thirty-odd.
    /// <p/>
    /// This asks the pass itself, so a chunk it names really does have a start rooted in it. That
    /// costs a layout per chunk, which is why it is explicit and why it stops at the first hit for
    /// each structure.
    /// <p/>
    /// <b>A chunk it names can still come out empty when that chunk is generated, and that is not a
    /// bug in either.</b> Whether a structure may start is a biome question, and the climate search
    /// starts from the previous answer and uses it as its pruning bound, so asking in ring order and
    /// asking while generating are different query sequences and resolve a tie differently. Vanilla's
    /// search has the same property. What settles where structures really are is
    /// <c>Conformance/structurelayout.sh</c>, against a world the real server generated.
    /// </remarks>
    [Test]
    public void PrintForRealStarts() {
        VanillaTerrainGenerator generator = Generator()
            .WithFeatures()
            .WithStructures();

        HashSet<string> wanted = (Environment.GetEnvironmentVariable("TARGETS")
                ?? string.Join(',', generator.StructurePass!.Data.Structures.Keys))
            .Split(',').ToHashSet();

        // How many chunks to name per structure. One is enough to say a structure is reached at all;
        // measuring what it writes wants several, since a single wreck is one hull on one slope.
        int perStructure = int.Parse(Environment.GetEnvironmentVariable("COUNT") ?? "1");

        Dictionary<string, List<(int, int)>> found = [];
        int radius = int.Parse(Environment.GetEnvironmentVariable("SEARCH") ?? "220");

        bool Complete() {
            return wanted.All(id => found.TryGetValue(id, out List<(int, int)>? at)
                && at.Count >= perStructure);
        }

        for (int ring = 0; ring <= radius && !Complete(); ring++) {
            for (int chunkX = -ring; chunkX <= ring; chunkX++) {
                for (int chunkZ = -ring; chunkZ <= ring; chunkZ++) {
                    if (Math.Max(Math.Abs(chunkX), Math.Abs(chunkZ)) != ring) {
                        continue;
                    }

                    foreach (StructureStart start in generator.StructureStartsAt(chunkX, chunkZ)) {
                        foreach ((Identifier id, Structure structure)
                            in generator.StructurePass!.Data.Structures) {

                            if (!ReferenceEquals(start.Structure, structure)
                                || !wanted.Contains(id.ToString())) {

                                continue;
                            }

                            List<(int, int)> at = found.TryGetValue(id.ToString(), out List<(int, int)>? existing)
                                ? existing
                                : found[id.ToString()] = [];

                            if (at.Count < perStructure) {
                                at.Add((chunkX, chunkZ));
                            }
                        }
                    }
                }
            }
        }

        TestContext.Out.WriteLine(string.Join(",", found.Values.SelectMany(at => at)
            .Select(where => $"{where.Item1}_{where.Item2}").Distinct()));

        foreach ((string id, List<(int, int)> at) in found.OrderBy(e => e.Key, StringComparer.Ordinal)) {
            TestContext.Out.WriteLine(
                $"    {string.Join(' ', at.Select(w => $"{w.Item1}_{w.Item2}"))}   # {id[10..]}");
        }

        TestContext.Out.WriteLine($"found {found.Count} of {wanted.Count} structures");
        TestContext.Out.WriteLine("never found: "
            + string.Join(", ", wanted.Where(id => !found.ContainsKey(id))));
    }

    /// <summary>
    /// Prints a chunk that could hold each named structure, for the ones a biome cluster misses.
    /// </summary>
    /// <remarks>
    /// A village is one candidate chunk in a thousand, so a cluster in the right biome usually does not
    /// contain one. This walks the placement arithmetic instead, which is cheap because it builds no
    /// layout, and reports where the roll passes and the biome allows the structure. It is only a place
    /// to look: what vanilla starts there is still vanilla's answer.
    /// </remarks>
    [Test]
    public void PrintForStructures() {
        VanillaTerrainGenerator generator = Generator()
            .WithFeatures()
            .WithStructures();

        StructureSystem pass = generator.StructurePass!;

        HashSet<string> wanted = (Environment.GetEnvironmentVariable("TARGETS")
            ?? "minecraft:jungle_pyramid,minecraft:mansion,minecraft:pillager_outpost,"
            + "minecraft:village_desert,minecraft:village_savanna,minecraft:village_snowy,"
            + "minecraft:ruined_portal_desert,minecraft:ruined_portal_jungle,"
            + "minecraft:ruined_portal_mountain,minecraft:ruined_portal_swamp").Split(',').ToHashSet();

        Dictionary<string, (int, int)> found = [];
        int radius = int.Parse(Environment.GetEnvironmentVariable("SEARCH") ?? "600");

        for (int ring = 0; ring <= radius && found.Count < wanted.Count; ring++) {
            for (int chunkX = -ring; chunkX <= ring; chunkX++) {
                for (int chunkZ = -ring; chunkZ <= ring; chunkZ++) {
                    if (Math.Max(Math.Abs(chunkX), Math.Abs(chunkZ)) != ring) {
                        continue;
                    }

                    Candidates(generator, pass, wanted, found, chunkX, chunkZ);
                }
            }
        }

        foreach ((string id, (int cx, int cz)) in found.OrderBy(e => e.Key, StringComparer.Ordinal)) {
            TestContext.Out.WriteLine($"    \"{cx}:{cz}\"   # {id[10..]}");
        }

        TestContext.Out.WriteLine("never found: "
            + string.Join(", ", wanted.Where(id => !found.ContainsKey(id))));
    }

    /// <summary>
    /// Prints the first chunks this build generates a named block in, for a feature too rare to be
    /// found by biome: an end gateway is one highlands chunk in seven hundred.
    /// </summary>
    /// <remarks>
    /// <c>BLOCK</c> names it, <c>FROM</c> is the ring to start at, and the dimension's range comes from
    /// <c>MIN_Y</c> and <c>HEIGHT</c>. What a chunk forks into a neighbour is dropped, so a hit is what the
    /// chunk's own decoration wrote.
    /// </remarks>
    [Test]
    public void PrintForBlocks() {
        VanillaTerrainGenerator generator = Generator().WithFeatures();
        Minecraft.Implementations.Server.Terrain.Generation.GeneratorTerrainProvider provider = generator.AsProvider();
        provider.Attach(new StructurePassTest.DiscardingHost());
        Identifier wanted = Identifier.Parse(Environment.GetEnvironmentVariable("BLOCK") ?? "minecraft:end_gateway");
        int count = int.Parse(Environment.GetEnvironmentVariable("COUNT") ?? "3");
        int from = int.Parse(Environment.GetEnvironmentVariable("FROM") ?? "0");
        int radius = int.Parse(Environment.GetEnvironmentVariable("SEARCH") ?? "160");
        int minY = int.Parse(Environment.GetEnvironmentVariable("MIN_Y") ?? "-64");
        int height = int.Parse(Environment.GetEnvironmentVariable("HEIGHT") ?? "384");

        List<(int, int)> found = [];
        for (int ring = from; ring <= radius && found.Count < count; ring++) {
            for (int chunkX = -ring; chunkX <= ring && found.Count < count; chunkX++) {
                for (int chunkZ = -ring; chunkZ <= ring && found.Count < count; chunkZ++) {
                    if (Math.Max(Math.Abs(chunkX), Math.Abs(chunkZ)) != ring) {
                        continue;
                    }

                    Minecraft.Schemas.Chunks.ChunkData chunk = new(height) { ChunkX = chunkX, ChunkZ = chunkZ, MinY = minY };
                    provider.GetChunk(ref chunk);
                    if (Holds(chunk, height, wanted)) {
                        found.Add((chunkX, chunkZ));
                        TestContext.Out.WriteLine($"    \"{chunkX}:{chunkZ}\"   # {wanted.Key}");
                    }
                }
            }
        }

        TestContext.Out.WriteLine($"found {found.Count} of {count}");
    }

    private static bool Holds(Minecraft.Schemas.Chunks.ChunkData chunk, int height, Identifier block) {
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    if (Minecraft.Data.Generated.VanillaRegistry.Data.Blocks.GetByStateId(chunk.GetBlock(x, y, z))
                            .Identifier == block) {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private static void Candidates(VanillaTerrainGenerator generator, StructureSystem pass,
        HashSet<string> wanted, Dictionary<string, (int, int)> found, int chunkX, int chunkZ) {

        foreach (StructureSet set in pass.Data.Sets.Values) {
            if (!set.Placement.IsStructureChunk(pass, chunkX, chunkZ)) {
                continue;
            }

            foreach (StructureSet.Entry entry in set.Structures) {
                string id = entry.Structure.ToString();

                if (!wanted.Contains(id) || found.ContainsKey(id)
                    || !pass.Data.Structures.TryGetValue(entry.Structure, out Structure? structure)) {

                    continue;
                }

                // The biome at the chunk's own middle, which is where onTopOfChunkCenter looks.
                Identifier biome = generator.BiomeAt((chunkX << 2) + 2, 16, (chunkZ << 2) + 2);

                if (structure.AllowsBiome(biome)) {
                    found[id] = (chunkX, chunkZ);
                }
            }
        }
    }

    private static void Look(VanillaTerrainGenerator generator, Dictionary<string, (int, int)> found,
        int chunkX, int chunkZ, int y) {

        Identifier biome = generator.BiomeAt(chunkX << 2, y >> 2, chunkZ << 2);
        found.TryAdd(biome.ToString(), (chunkX, chunkZ));
    }
}
