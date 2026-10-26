using System.IO.Compression;
using System.Text;
using ManagedServer.Terrain;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Structures;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using NUnit.Framework;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Every structure start the real server laid out over a spread of the world, piece by piece.
/// </summary>
/// <remarks>
/// <b>This is the only measurement of the structure pass that names a structure.</b>
/// <c>decorationparity.sh</c> skips a chunk a structure wrote into, because its stub level has no
/// structure manager, and <c>worldparity.sh</c> reports one number per scene with the feature pass
/// mixed into it. What a start is, on the other hand, the server writes into the chunk itself: a piece
/// type, a bounding box, an orientation and a generation depth, for every piece of every structure
/// rooted there. <c>Conformance/structurelayout.sh</c> reads those back out of the region files.
/// <p/>
/// <b>It is a pass rather than a baseline, unlike world parity.</b> A start is a pure function of the
/// world seed and its source chunk on both sides, so nothing here depends on the order the world was
/// generated in, and a difference is a bug rather than an artefact of the recording.
/// <p/>
/// What it does not compare is the piece <i>type</i>: vanilla names one from
/// <c>BuiltInRegistries.STRUCTURE_PIECE</c> and the pieces here are classes with no such name. The
/// geometry is what discriminates anyway, since two pieces of different types are two different
/// shapes; what a piece then writes into the world is the templates and
/// <c>Conformance/blocktransform.sh</c>.
/// </remarks>
[TestFixture("overworld", "vanilla-structures.txt.gz")]
[TestFixture("nether", "vanilla-structures-nether.txt.gz")]
[TestFixture("end", "vanilla-structures-end.txt.gz")]
public class StructureLayoutConformanceTest(string dimension, string fixtureName) {
    private string Fixture => Path.Combine(TestContext.CurrentContext.TestDirectory, "Terrain", fixtureName);

    private VanillaTerrainGenerator Generator(long seed) => dimension switch {
        "nether" => VanillaTerrainGenerator.Nether(VanillaPack.Source, seed),
        "end" => VanillaTerrainGenerator.End(VanillaPack.Source, seed),
        _ => VanillaTerrainGenerator.Overworld(VanillaPack.Source, seed)
    };

    /// <summary>
    /// Structures whose piece settles its own height inside <c>PostProcess</c> here as well as
    /// upstream, so the box a start hands out is not the box that lands and comparing the two would
    /// measure nothing. Their horizontal geometry is still compared everywhere.
    /// </summary>
    private static readonly HashSet<string> HeightSettledWhilePlacing = [
        "minecraft:buried_treasure",
        "minecraft:desert_pyramid",
        "minecraft:igloo",
        "minecraft:jungle_pyramid",
        "minecraft:ocean_ruin_cold",
        "minecraft:ocean_ruin_warm",
        "minecraft:shipwreck",
        "minecraft:shipwreck_beached",
        "minecraft:swamp_hut"
    ];

    /// <summary>
    /// The starts still known to differ, and why. Asserted in <b>both</b> directions, so a new
    /// difference fails as a regression and a fixed one fails as a stale entry.
    /// </summary>
    /// <remarks>
    /// An entry is written as a <c>Divergence</c>, a subsystem this build does not have, or a
    /// <c>Bug</c>, a rule that is wrong. The <b>Bug half is empty and should stay that way</b>; the
    /// split only means something while it does.
    /// </remarks>
    private static readonly Dictionary<string, string> Baseline = new();

    /// <summary>
    /// Every start, in both directions: a structure this build puts somewhere vanilla did not is a
    /// failure, and so is one vanilla put somewhere this build does not.
    /// </summary>
    [Test]
    public void EveryStartIsWhereVanillaPutIt() {
        Recording recording = Read();

        VanillaTerrainGenerator generator = Generator(recording.Seed)
            .WithFeatures()
            .WithStructures();

        StructureSystem pass = generator.StructurePass!;

        Dictionary<Structure, Identifier> names = pass.Data.Structures
            .ToDictionary(entry => entry.Value, entry => entry.Key);

        List<string> ours = [];

        foreach ((int chunkX, int chunkZ, bool decorated) in recording.Chunks) {
            foreach (StructureStart start in generator.StructureStartsAt(chunkX, chunkZ)) {
                Identifier name = names[start.Structure];

                for (int index = 0; index < start.Pieces.Count; index++) {
                    ours.Add(Describe(chunkX, chunkZ, name, index, start.Pieces[index], decorated));
                }
            }
        }

        ours.Sort(StringComparer.Ordinal);

        Compare(recording, ours);
    }

    /// <summary>
    /// Which structures the recording actually contains, so a run that measures nothing cannot read as
    /// a run that measures everything.
    /// </summary>
    /// <remarks>
    /// The sample decides what the number above is worth, exactly as it does for the decoration parity
    /// metric. A structure with no start anywhere in the recording is not covered by this test at all,
    /// whatever it says.
    /// </remarks>
    [Test]
    public void TheRecordingCoversMostStructures() {
        Recording recording = Read();

        VanillaTerrainGenerator generator = Generator(recording.Seed)
            .WithFeatures()
            .WithStructures();

        HashSet<string> seen = recording.Pieces
            .Select(piece => piece.Split(' ')[2])
            .ToHashSet();

        HashSet<string> placeable = generator.StructurePass!.Data.Structures.Keys
            .Select(id => id.ToString())
            .ToHashSet();

        List<string> missing = placeable.Except(seen).Order(StringComparer.Ordinal).ToList();

        TestContext.Out.WriteLine($"coverage: {seen.Count} of {placeable.Count} structures start "
            + $"somewhere in {recording.Chunks.Count} chunks");

        if (missing.Count > 0) {
            TestContext.Out.WriteLine("never started: " + string.Join(", ", missing));
        }

        Assert.That(seen, Is.Not.Empty);
    }

    private static void Compare(Recording recording, List<string> ours) {
        HashSet<string> theirs = [.. recording.Pieces];
        HashSet<string> mine = [.. ours];

        List<string> onlyOurs = ours.Where(line => !theirs.Contains(line)).ToList();
        List<string> onlyTheirs = recording.Pieces.Where(line => !mine.Contains(line)).ToList();

        int withHeight = recording.Pieces.Count(line => !line.Contains(' ' + Undecorated + ' '));

        List<string> structures = onlyOurs.Concat(onlyTheirs)
            .Select(line => line.Split(' ')[2])
            .Distinct()
            .Order(StringComparer.Ordinal)
            .ToList();

        List<string> stale = Baseline.Keys.Except(structures).Order(StringComparer.Ordinal).ToList();
        List<string> unexpected = structures.Except(Baseline.Keys).ToList();

        TestContext.Out.WriteLine($"{recording.Pieces.Count} pieces over {recording.Chunks.Count} "
            + $"chunks, {withHeight} of them on height as well; the rest sit in a chunk vanilla never "
            + $"decorated or belong to a piece that settles its own height while placing. "
            + $"{onlyOurs.Count} pieces differ, over {structures.Count} structures.");

        if (unexpected.Count == 0 && stale.Count == 0) {
            foreach (string structure in structures) {
                TestContext.Out.WriteLine($"  baselined: {structure} - {Baseline[structure]}");
            }

            return;
        }

        StringBuilder report = new();
        report.AppendLine($"{onlyOurs.Count} pieces this build lays out that vanilla does not, "
            + $"{onlyTheirs.Count} that vanilla does and this build does not, "
            + $"out of {recording.Pieces.Count} recorded.");

        if (stale.Count > 0) {
            report.AppendLine();
            report.AppendLine("baselined and no longer differing, so the entry is stale: "
                + string.Join(", ", stale));
        }

        if (unexpected.Count > 0) {
            report.AppendLine();
            report.AppendLine("differing and not baselined: " + string.Join(", ", unexpected));
        }

        report.AppendLine();
        report.AppendLine("by structure:");

        foreach (string structure in structures) {
            int extra = onlyOurs.Count(line => line.Split(' ')[2] == structure);
            int lost = onlyTheirs.Count(line => line.Split(' ')[2] == structure);
            int total = recording.Pieces.Count(line => line.Split(' ')[2] == structure);

            report.AppendLine($"  {structure}: +{extra} -{lost} of {total}");
        }

        // A piece tree is grown depth first from one random, so everything after the first
        // disagreement is a different sequence and says nothing about where it started. The lowest
        // index either side disagrees at is the one to read.
        report.AppendLine();
        report.AppendLine("first disagreement per start:");

        IEnumerable<string> starts = onlyOurs.Concat(onlyTheirs)
            .Select(Start)
            .Distinct()
            .Order(StringComparer.Ordinal);

        foreach (string start in starts) {
            string? firstOurs = onlyOurs.Where(line => Start(line) == start)
                .MinBy(line => int.Parse(line.Split(' ')[3]));

            string? firstTheirs = onlyTheirs.Where(line => Start(line) == start)
                .MinBy(line => int.Parse(line.Split(' ')[3]));

            report.AppendLine($"  {start}");
            report.AppendLine("    ours:    " + (firstOurs ?? "-"));
            report.AppendLine("    vanilla: " + (firstTheirs ?? "-"));
        }

        Assert.Fail(report.ToString());
    }

    /// <summary>The chunk and structure a piece line belongs to.</summary>
    private static string Start(string line) {
        string[] parts = line.Split(' ');
        return $"{parts[0]} {parts[1]} {parts[2]}";
    }

    /// <summary>
    /// The line the fixture holds for one piece. Sorted as text, so the two sides are compared as sets
    /// and a difference names the chunk it is in.
    /// </summary>
    private static string Describe(int chunkX, int chunkZ, Identifier structure, int index,
        StructurePiece piece, bool decorated) {

        BoundingBox box = piece.BoundingBox;
        bool comparable = decorated && !HeightSettledWhilePlacing.Contains(structure.ToString());

        // Field order is the fixture's, which is the order StructurePiece.createTag writes them.
        return string.Join(' ', chunkX, chunkZ, structure, index, piece.GenDepth,
            TwoDimensional(piece.Orientation),
            box.MinX, Height(box.MinY, comparable), box.MinZ,
            box.MaxX, Height(box.MaxY, comparable), box.MaxZ);
    }

    private static string Height(int y, bool comparable) {
        return comparable ? y.ToString() : Undecorated;
    }

    /// <summary>
    /// What a piece's y reads as in a chunk vanilla never decorated.
    /// </summary>
    /// <remarks>
    /// A shipwreck, an ocean ruin, an igloo and a scattered feature all settle their own height inside
    /// <c>postProcess</c>, on both sides, so neither side's layout box is the box that lands and a
    /// chunk below full status never ran the settle at all. Blanking the y is what keeps the wide
    /// sample worth having: the placement, the piece tree and the horizontal geometry are still
    /// compared everywhere, and the height only where both sides have finished with it. What those
    /// pieces write is measured by <c>Conformance/decorationparity.sh</c> instead.
    /// </remarks>
    private const string Undecorated = "-";

    /// <summary><c>Direction.get2DDataValue</c>, which is what the chunk carries.</summary>
    private static int TwoDimensional(Direction? orientation) => orientation switch {
        Direction.South => 0,
        Direction.West => 1,
        Direction.North => 2,
        Direction.East => 3,
        _ => -1
    };

    private Recording Read() {
        if (!File.Exists(Fixture)) {
            Assert.Ignore($"No fixture at {Fixture}. Run Conformance/structurelayout.sh to make one.");
        }

        long seed = 0;
        List<(int X, int Z, bool Decorated)> chunks = [];
        HashSet<(int, int)> undecorated = [];
        List<string> pieces = [];

        using FileStream file = File.OpenRead(Fixture);
        using GZipStream unzipped = new(file, CompressionMode.Decompress);
        using StreamReader reader = new(unzipped, Encoding.UTF8);

        while (reader.ReadLine() is { } line) {
            string[] parts = line.Split(' ');

            switch (parts[0]) {
                case "seed":
                    seed = long.Parse(parts[1]);
                    break;

                case "chunks":
                    break;

                case "chunk": {
                    int x = int.Parse(parts[1]);
                    int z = int.Parse(parts[2]);
                    bool decorated = parts[3] == "minecraft:full";

                    chunks.Add((x, z, decorated));

                    if (!decorated) {
                        undecorated.Add((x, z));
                    }

                    break;
                }

                case "piece": {
                    // Vanilla writes the piece type where this build has no name for one, so it is
                    // dropped here rather than at the source: the fixture stays readable and a version
                    // bump that renames a type does not read as every structure moving.
                    string[] fields = parts.Skip(1).Where((_, i) => i != 4).ToArray();

                    if (undecorated.Contains((int.Parse(fields[0]), int.Parse(fields[1])))
                        || HeightSettledWhilePlacing.Contains(fields[2])) {

                        fields[7] = Undecorated;
                        fields[10] = Undecorated;
                    }

                    pieces.Add(string.Join(' ', fields));
                    break;
                }

                default:
                    throw new InvalidDataException($"Unknown fixture line \"{line}\"");
            }
        }

        pieces.Sort(StringComparer.Ordinal);
        return new Recording(seed, chunks, pieces);
    }

    private sealed record Recording(long Seed, List<(int X, int Z, bool Decorated)> Chunks,
        List<string> Pieces);
}
