using ManagedServer.Terrain;
using ManagedServer.Terrain.Data;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NUnit.Framework;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Dumps a wide scatter of decorated chunks for <c>Conformance/decorationparity.sh</c>.
/// </summary>
/// <remarks>
/// <b>What the parity number is worth is decided here, not by the harness.</b> The harness compares
/// whatever chunks it is given, so a run over one corner of one world says nothing about a feature
/// that corner does not contain. <c>WorldParityConformanceTest</c>'s seven scenes reach 20 of the
/// overworld's 55 biomes and about a third of its placed features; this reaches all 55 and most of the
/// features, by asking for chunks spread over millions of blocks rather than for seven
/// neighbourhoods, plus a handful named outright for the one biome a scatter this size still misses.
/// <p/>
/// <b>The structure pass is off unless <c>PARITY_STRUCTURES</c> asks for it.</b> A chunk it wrote into
/// costs the layout to dump and can be unreplayable, which throws that chunk's features away with it,
/// so the run that measures features leaves it off and the run that measures structures turns it on.
/// Where a structure sits is <c>Conformance/structurelayout.sh</c>; what its pieces then write is here.
/// <p/>
/// Only runs when <c>FEATURE_PARITY_DUMP</c> names a directory, since its whole output is that
/// directory: there is nothing for it to assert.
/// </remarks>
[TestFixture]
public class DecorationParityScatterTest {
    private const long Seed = 8675309L;
    private const int MinY = -64;
    private const int Height = 384;

    /// <summary>How many chunks to dump, and how far apart to spread them.</summary>
    /// <remarks>
    /// Spread rather than clustered: neighbouring chunks share biomes, so a thousand chunks in one
    /// place is worth less than a hundred scattered. The spacing is prime-ish and the walk is a fixed
    /// pseudo random sequence, so the same set comes out every run.
    /// </remarks>
    private const int Samples = 900;
    private const int Spread = 60_000;

    /// <summary>
    /// Square patches asked for by name rather than drawn, for the features a scatter this size does
    /// not reach.
    /// </summary>
    /// <remarks>
    /// Two things put a feature out of reach and the second bites hardest. <c>mushroom_fields</c> is
    /// about a thousandth of the overworld, so nine hundred chunks spread at random miss the biome
    /// outright. The pale garden's and the swamp's are the same problem one level down: the biome is
    /// reached, and the feature inside it still is not, because it sits behind a <c>rarity_filter</c>.
    /// <p/>
    /// <b>So a patch is sized by the rarity roll rather than by the biome.</b> An ungated feature needs
    /// one chunk of its biome, a one in thirty-two needs about thirty of them, and a one in a thousand
    /// is out of reach of anything this shape: those stay in the coverage report and want a targeted
    /// search instead. Coordinates come from <see cref="FindStructureClusters"/>, which takes this
    /// fixture's own <c>Seed</c> rather than the one the rest of the tree uses.
    /// </remarks>
    private static readonly (int X, int Z, int Size)[] NamedPatches = [
        (48, -200, 2),   // mushroom fields: the biome itself
        (208, -72, 6),   // pale garden: vegetation and moss patch ungated, flowers one in thirty-two
        (192, 112, 6),   // swamp: sugar cane one in three, flowers one in thirty-two
        (192, -24, 6),   // old growth spruce taiga: berry bushes one in thirty-two
        (240, -160, 4),  // eroded badlands: decorated cactus one in thirteen
        (8, 64, 3),      // flower forest: flowers one in seven
        (-8, 288, 2),    // snowy plains: snowy trees, ungated
        (176, 88, 2),    // windswept hills: its trees, ungated
        (-104, 144, 2)   // windswept savanna: its trees, ungated
    ];

    /// <summary>
    /// Chunks a named structure really starts in, and the ring around each.
    /// </summary>
    /// <remarks>
    /// <b>A structure is about one chunk in a hundred, so the scatter cannot be trusted to cover one.</b>
    /// Nine hundred chunks spread over millions of blocks held a single shipwreck, and everything that
    /// wreck disagreed with vanilla about was hidden behind that one sample. Coordinates come from
    /// <see cref="FindStructureClusters.PrintForStructures"/> at this fixture's own <c>Seed</c>.
    /// <p/>
    /// Three things are being covered and they want different structures. The first five <b>settle their
    /// own height</b> inside <c>PostProcess</c> rather than sitting where the layout put them. The next
    /// ten are the <b>template-heavy</b> ones, which is what makes them worth having: a village, a
    /// mansion and an ancient city are stairs, fences and panes by the thousand, and every one of those
    /// arrives carrying the connections it had where the build was cut from. The rest are
    /// <b>code-built</b>, drawn by <c>PostProcess</c> out of the piece's own primitives rather than
    /// placed from a saved file, which is the half no template exercises, and between them they take
    /// the sample to every structure the overworld generates. What is left unmeasured is the nether's
    /// and the end's.
    /// <p/>
    /// <b>The desert pyramid is here knowing it reads as a difference</b> outside its source chunk,
    /// since its height is decided once for the start and the harness rebuilds the start per scene, so
    /// in a neighbour it decides from that neighbour's draw. What it is here for is the rest of the
    /// pyramid, and for the shape of that difference staying the one <c>ScatteredFeaturePiece</c>
    /// documents rather than growing a second cause.
    /// <p/>
    /// <b>The ring is the point rather than the middle.</b> A wreck is 28 blocks long, so it spans two
    /// chunks and each of them settles it again; the chunk holding the far half is where a settle that
    /// answers differently per chunk shows up, and the chunk the start is rooted in is where it does
    /// not.
    /// </remarks>
    private static readonly (int X, int Z)[] StructureChunks = [
        (17, -15),    // shipwreck
        (-59, -33),   // shipwreck_beached
        (24, 24),     // ocean_ruin_cold
        (5, -20),     // ocean_ruin_warm
        (6, 291),     // igloo

        (-19, -20),   // village_plains
        (-12, -44),   // village_savanna
        (327, 112),   // village_snowy
        (-34, -89),   // village_desert
        (110, 77),    // village_taiga
        (-63, -197),  // mansion
        (564, -478),  // ancient_city
        (12, 11),     // trial_chambers
        (-43, 51),    // pillager_outpost
        (-26, 23),    // ruined_portal

        (-21, -156),  // desert_pyramid
        (34, 11),     // monument
        (205, 107),   // swamp_hut
        (-61, -120),  // jungle_pyramid
        (86, 53),     // stronghold
        (7, 20),      // trail_ruins
        (-108, -56),  // ruined_portal_desert
        (52, -108),   // ruined_portal_jungle
        (15, 15),     // ruined_portal_ocean
        (-97, 160)    // ruined_portal_swamp
    ];

    private static readonly (int X, int Z)[] Named = NamedPatches
        .SelectMany(patch => Enumerable.Range(0, patch.Size)
            .SelectMany(dx => Enumerable.Range(0, patch.Size)
                .Select(dz => (patch.X + dx, patch.Z + dz))))
        .Concat(StructureChunks.SelectMany(at => Enumerable.Range(-1, 3)
            .SelectMany(dx => Enumerable.Range(-1, 3)
                .Select(dz => (at.X + dx, at.Z + dz)))))
        .Distinct()
        .ToArray();

    [Test]
    public void DumpAScatterOfDecoratedChunks() {
        string? directory = Environment.GetEnvironmentVariable("FEATURE_PARITY_DUMP");

        if (directory is null) {
            Assert.Ignore("Set FEATURE_PARITY_DUMP to a directory to dump chunks for the harness.");
            return;
        }

        VanillaTerrainGenerator generator = VanillaTerrainGenerator
            .Overworld(VanillaPack.Source, Seed)
            .WithCarvers()
            .WithFeatures();

        // The structure pass is off by default here, because a chunk it wrote into was skipped whole
        // by the harness and its features went with it. PARITY_STRUCTURES turns it on for the run that
        // measures what a structure writes, which needs the placements the dump then records.
        if (Environment.GetEnvironmentVariable("PARITY_STRUCTURES") == "1") {
            generator = generator.WithStructures();
        }

        GeneratorTerrainProvider provider = generator.AsProvider();
        ParkingHost host = new(MinY, MinY + Height);
        provider.Attach(host);

        // A fixed sequence, so the same chunks come out every run and a number from one run can be
        // compared with the next.
        Random positions = new(1);

        // A comma separated list, since a trace wants one chunk and topping a dump up wants a few.
        HashSet<string>? only = Environment.GetEnvironmentVariable("PARITY_ONLY_CHUNK")?
            .Split(',').ToHashSet();

        // Chunks that are not in the sample at all, for measuring something the sample does not reach.
        // A structure is the case that needs it: a chunk holding one is about one in a hundred, so
        // asking for the ones a search already found beats dumping the whole scatter to catch a few.
        (int, int)[] extra = (Environment.GetEnvironmentVariable("PARITY_EXTRA_CHUNK") ?? "")
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(name => name.Split('_'))
            .Select(parts => (int.Parse(parts[0]), int.Parse(parts[1])))
            .ToArray();

        for (int i = 0; i < Samples + Named.Length + extra.Length; i++) {
            (int chunkX, int chunkZ) = i < Samples
                ? (positions.Next(-Spread, Spread), positions.Next(-Spread, Spread))
                : i < Samples + Named.Length
                    ? Named[i - Samples]
                    : extra[i - Samples - Named.Length];

            // The extras are asked for by name, so the filter is about the sample rather than them.
            if (only is not null && i < Samples + Named.Length
                && !only.Contains($"{chunkX}_{chunkZ}")) {

                continue;
            }

            ChunkData chunk = new(Height) { ChunkX = chunkX, ChunkZ = chunkZ, MinY = MinY };
            provider.GetChunk(ref chunk);
            host.Publish(chunk);
        }
    }

    /// <summary>
    /// A host that keeps nothing. Every chunk here is generated on its own, so a fork crossing a
    /// border has nowhere to go and is parked for a chunk that never arrives, which is what the
    /// dumped pair records either way: what the pass found and what it left.
    /// </summary>
    private sealed class ParkingHost(int minY, int maxY) : ITerrainHost {
        public int MinY => minY;
        public int MaxY => maxY;
        public MinecraftRegistry Registry => Minecraft.Data.Generated.VanillaRegistry.Data;

        public event Action<Vec2<int>>? ChunkAvailable;

        public bool TryApplyToLoadedChunk(Vec2<int> chunk, Action<ChunkData> apply) => false;

        public void Publish(ChunkData chunk) {
            ChunkAvailable?.Invoke(new Vec2<int>(chunk.ChunkX, chunk.ChunkZ));
        }
    }
}
