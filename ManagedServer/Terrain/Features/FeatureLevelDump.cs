using System.Buffers.Binary;
using System.IO.Compression;
using System.Text;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Schemas.Chunks;
using NBT;

namespace ManagedServer.Terrain.Features;

/// <summary>
/// Writes down what the decoration pass had in front of it and what it left behind, as the input
/// <c>Conformance/decorationparity.sh</c> and <c>Conformance/featuretrace.sh</c> drive the real vanilla
/// code over.
/// </summary>
/// <remarks>
/// <b>Every measurement against a recorded world is contaminated by the order its chunks were
/// generated in.</b> A chunk decorates through a region spanning its neighbours, so what one forked in
/// before a chunk started sits in front of that chunk's own features and what it forks in later sits on
/// top; the recording was made in the real server's order and this build generates in its own. Varying
/// only that order moves <c>WorldParityConformanceTest</c>'s count by about a third, which is more than
/// most fixes are worth.
/// <p/>
/// This is how that variable is removed. Both states of the three by three are written, so vanilla can
/// be run over the <b>same bytes</b> this build started from and its writes compared against this
/// build's. What is left is the port and nothing else.
/// <p/>
/// Off unless one of two variables is set. <c>FEATURE_PARITY_DUMP</c> names a directory and writes
/// every chunk that decorates; <c>FEATURE_LEVEL_DUMP</c> is
/// <c>chunkX,chunkZ,step,index,path</c> and writes one chunk, tracing one feature's candidates on the
/// way past.
/// </remarks>
public static class FeatureLevelDump {
    /// <summary>Where every decorating chunk is written, or null.</summary>
    public static readonly string? Directory = Environment.GetEnvironmentVariable("FEATURE_PARITY_DUMP");

    /// <summary>Which single feature to trace, or null.</summary>
    public static readonly (int ChunkX, int ChunkZ, int Step, int Index, string Path)? Target = Parse();

    /// <summary>
    /// Whether the feature running right now is printing a line per candidate. Per thread, because
    /// several chunks decorate at once and only one of them is the one being traced.
    /// </summary>
    [ThreadStatic]
    public static bool Tracing;

    private static readonly List<string> Writers = [];
    private static readonly Lock WriterGate = new();

    /// <summary>One structure start a chunk placed, as the harness needs to lay the same one out.</summary>
    /// <param name="Id">The structure's registry id, which is what vanilla is looked up by.</param>
    /// <param name="SourceChunkX">Where the start is rooted, which is not this chunk in general.</param>
    /// <param name="Step">The decoration step it was placed in.</param>
    /// <param name="Index">
    /// Its position among that step's structures, which is what the placement random is seeded from.
    /// Recorded rather than recomputed, so the harness measures what a piece <b>writes</b> given a
    /// seed and leaves the seed's derivation to `StructureSeedIndexTest`.
    /// </param>
    public readonly record struct Placement(string Id, int SourceChunkX, int SourceChunkZ, int Step,
        int Index);

    /// <summary>
    /// The starts the chunk being decorated on this thread has placed.
    /// </summary>
    /// <remarks>
    /// Per thread because a chunk decorates whole on one thread while several chunks decorate at once,
    /// so one shared list would interleave two chunks' placements and neither would replay.
    /// </remarks>
    [ThreadStatic]
    private static List<Placement>? _placements;

    /// <summary>Starts collecting placements for the chunk about to decorate on this thread.</summary>
    public static void BeginPlacements() => _placements = [];

    /// <summary>Records a start, or does nothing when this chunk is not being written down.</summary>
    public static void RecordPlacement(Placement placement) => _placements?.Add(placement);

    /// <summary>What was collected, and stops collecting.</summary>
    public static IReadOnlyList<Placement> TakePlacements() {
        List<Placement> placements = _placements ?? [];
        _placements = null;
        return placements;
    }

    /// <summary>
    /// The index a feature's writes are recorded under. Shared across chunks so the table is written
    /// once per file and the same feature has the same index in all of them.
    /// </summary>
    public static int WriterFor(string feature) {
        lock (WriterGate) {
            int at = Writers.IndexOf(feature);

            if (at < 0) {
                at = Writers.Count;
                Writers.Add(feature);
            }

            return at;
        }
    }

    /// <summary>Whether this chunk is one of the ones being written down.</summary>
    public static bool Wanted(int chunkX, int chunkZ) {
        return Directory != null
            || (Target is { } target && target.ChunkX == chunkX && target.ChunkZ == chunkZ);
    }

    private static (int, int, int, int, string)? Parse() {
        string[]? parts = Environment.GetEnvironmentVariable("FEATURE_LEVEL_DUMP")?.Split(',');

        return parts is { Length: 5 }
            ? (int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]),
                parts[4])
            : null;
    }

    /// <summary>Where a chunk's pair of states goes.</summary>
    public static string PathFor(int chunkX, int chunkZ) {
        return Directory != null
            ? Path.Combine(Directory, $"{chunkX}_{chunkZ}.bin.gz")
            : Target!.Value.Path;
    }

    /// <summary>
    /// Every block of the three by three, in the order the file stores them: chunk by chunk from the
    /// low corner, then y, then z, then x.
    /// </summary>
    public static uint[] Capture(IFeatureLevel level, int chunkX, int chunkZ) {
        int height = level.MaxY - level.MinY;
        uint[] states = new uint[9 * height * 256];
        int at = 0;

        for (int dx = -1; dx <= 1; dx++) {
            for (int dz = -1; dz <= 1; dz++) {
                for (int y = level.MinY; y < level.MaxY; y++) {
                    for (int z = 0; z < 16; z++) {
                        for (int x = 0; x < 16; x++) {
                            states[at++] = level.GetState(((chunkX + dx) << 4) + x, y,
                                ((chunkZ + dz) << 4) + z);
                        }
                    }
                }
            }
        }

        return states;
    }

    /// <summary>Java's <c>DataInputStream</c> reads big endian throughout, which is what reads this.</summary>
    public static void Write(string path, IFeatureLevel level, BiomeAtQuart biomes, uint[] before,
        uint[] after, long seed, int chunkX, int chunkZ, int structureWrites,
        Dictionary<Vec3<int>, int> writers, IReadOnlyList<Placement> placements) {

        string? folder = Path.GetDirectoryName(Path.GetFullPath(path));
        if (folder != null) {
            System.IO.Directory.CreateDirectory(folder);
        }

        using FileStream file = File.Create(path);
        using GZipStream gzip = new(file, CompressionLevel.Optimal);

        int height = level.MaxY - level.MinY;

        WriteInt64(gzip, seed);
        WriteInt32(gzip, chunkX);
        WriteInt32(gzip, chunkZ);
        WriteInt32(gzip, level.MinY);
        WriteInt32(gzip, height);
        WriteInt32(gzip, structureWrites);

        // One palette over both states, since a chunk holds a handful of distinct blocks repeated a
        // million times and the runs below are what actually make this small.
        List<string> palette = [];
        Dictionary<uint, int> indexOf = [];

        int[] Resolve(uint[] states) {
            int[] indices = new int[states.Length];

            for (int i = 0; i < states.Length; i++) {
                if (!indexOf.TryGetValue(states[i], out int slot)) {
                    indexOf[states[i]] = slot = palette.Count;
                    palette.Add(Describe(level.Registry.Blocks.GetByStateId(states[i])));
                }

                indices[i] = slot;
            }

            return indices;
        }

        int[] beforeIndices = Resolve(before);
        int[] afterIndices = Resolve(after);

        WriteInt32(gzip, palette.Count);
        foreach (string name in palette) {
            WriteJavaUtf(gzip, name);
        }

        WriteRuns(gzip, beforeIndices);
        WriteRuns(gzip, afterIndices);

        // All nine biome grids, because vanilla decorates from the union over the three by three and
        // this build decorates from the chunk's own. That difference is one of the things worth
        // measuring, so the harness is given what it needs to apply vanilla's rule.
        //
        // The cell's own value, not the biome at a block inside it. A level answers a block position
        // through the zoomer, so writing that here and letting the harness read it as a grid puts the
        // zoomer in twice and moves every biome border by a few blocks.
        List<string> biomePalette = [];
        Dictionary<Identifier, int> biomeIndexOf = [];
        List<int> cells = [];

        for (int dx = -1; dx <= 1; dx++) {
            for (int dz = -1; dz <= 1; dz++) {
                for (int cellY = 0; cellY < height / 4; cellY++) {
                    for (int cellZ = 0; cellZ < 4; cellZ++) {
                        for (int cellX = 0; cellX < 4; cellX++) {
                            Identifier id = biomes(((chunkX + dx) << 2) + cellX,
                                (level.MinY >> 2) + cellY,
                                ((chunkZ + dz) << 2) + cellZ).Identifier;

                            if (!biomeIndexOf.TryGetValue(id, out int slot)) {
                                biomeIndexOf[id] = slot = biomePalette.Count;
                                biomePalette.Add(id.ToString());
                            }

                            cells.Add(slot);
                        }
                    }
                }
            }
        }

        WriteInt32(gzip, biomePalette.Count);
        foreach (string name in biomePalette) {
            WriteJavaUtf(gzip, name);
        }

        WriteRuns(gzip, cells);

        // The two frozen heightmaps over all nine chunks, because the harness cannot rescan for them.
        // They are the terrain as the carvers left it, and the state it starts from is this pass's
        // starting column, which already holds what a neighbour forked in: a rescan there answers the
        // ground with those blocks on top, and every ore blob is judged against the wrong surface.
        foreach (HeightmapType type in (HeightmapType[])[HeightmapType.WorldSurfaceWorldgen,
            HeightmapType.OceanFloorWorldgen]) {

            for (int dx = -1; dx <= 1; dx++) {
                for (int dz = -1; dz <= 1; dz++) {
                    for (int z = 0; z < 16; z++) {
                        for (int x = 0; x < 16; x++) {
                            WriteInt32(gzip, level.GetHeight(type, ((chunkX + dx) << 4) + x,
                                ((chunkZ + dz) << 4) + z));
                        }
                    }
                }
            }
        }

        // Which feature on this side wrote each position, so a difference vanilla's own writers cannot
        // account for still names something. Sparse, since a pass writes a few thousand of a million.
        string[] names;
        lock (WriterGate) {
            names = Writers.ToArray();
        }

        WriteInt32(gzip, names.Length);
        foreach (string name in names) {
            WriteJavaUtf(gzip, name);
        }

        WriteInt32(gzip, writers.Count);
        foreach ((Vec3<int> pos, int writer) in writers) {
            WriteInt32(gzip, pos.X);
            WriteInt32(gzip, pos.Y);
            WriteInt32(gzip, pos.Z);
            WriteInt32(gzip, writer);
        }

        // Which structure starts reached this chunk, so the harness can lay the same ones out with
        // vanilla rather than skipping the chunk whole. The source chunk is what a start is a function
        // of, and it is not this chunk: a start is replayed by every chunk its pieces reach.
        WriteInt32(gzip, placements.Count);
        foreach (Placement placement in placements) {
            WriteJavaUtf(gzip, placement.Id);
            WriteInt32(gzip, placement.SourceChunkX);
            WriteInt32(gzip, placement.SourceChunkZ);
            WriteInt32(gzip, placement.Step);
            WriteInt32(gzip, placement.Index);
        }
    }

    /// <summary>The state as <c>BlockStateParser</c> writes it, which is what the harness parses.</summary>
    private static string Describe(IBlock block) {
        StringBuilder written = new(block.Identifier.ToString());
        List<string> properties = [];

        // Sorted by name, which is what BlockStateParser.serialize writes: a StateDefinition keys its
        // properties by name in a sorted map. The harness compares these as text, so a state written
        // in the record's own order reads as a different block from the same state written in
        // vanilla's.
        foreach ((string key, INbtTag value) in block.ToStateNbt().Children.OrderBy(entry => entry.key,
            StringComparer.Ordinal)) {

            properties.Add($"{key}={value.GetString()}");
        }

        if (properties.Count > 0) {
            written.Append('[').Append(string.Join(',', properties)).Append(']');
        }

        return written.ToString();
    }

    private static void WriteRuns(Stream to, IReadOnlyList<int> values) {
        List<(int Length, int Value)> runs = [];

        foreach (int value in values) {
            if (runs.Count > 0 && runs[^1].Value == value) {
                runs[^1] = (runs[^1].Length + 1, value);
                continue;
            }

            runs.Add((1, value));
        }

        WriteInt32(to, runs.Count);
        foreach ((int length, int value) in runs) {
            WriteInt32(to, length);
            WriteInt32(to, value);
        }
    }

    private static void WriteInt32(Stream to, int value) {
        Span<byte> bytes = stackalloc byte[4];
        BinaryPrimitives.WriteInt32BigEndian(bytes, value);
        to.Write(bytes);
    }

    private static void WriteInt64(Stream to, long value) {
        Span<byte> bytes = stackalloc byte[8];
        BinaryPrimitives.WriteInt64BigEndian(bytes, value);
        to.Write(bytes);
    }

    private static void WriteJavaUtf(Stream to, string value) {
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        Span<byte> length = stackalloc byte[2];
        BinaryPrimitives.WriteUInt16BigEndian(length, (ushort)bytes.Length);
        to.Write(length);
        to.Write(bytes);
    }
}
