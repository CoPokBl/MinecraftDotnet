using Minecraft.Data.Generated;
using Minecraft.Lighting;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ClientLib.World;

/// <summary>
/// The client's own relighting after a block changes. Vanilla's server sends light updates only to
/// players for whom the chunk sits on the edge of their view (<c>ChunkHolder.broadcastChanges</c>
/// asks for border players); everywhere else the vanilla client relights for itself, and without
/// this a placed torch or a broken roof would keep the old light.
/// <para>
/// A change relights the chunk it is in and the eight around it, since light reaches fifteen blocks.
/// The blocks are copied on the game thread and lit on a worker, and the result is applied on a later
/// tick; changes that arrive meanwhile wait for the next round. A chunk whose own neighbours are not
/// all loaded keeps what the server sent: the engine would light its missing neighbours as void, and
/// those are the border chunks the server does keep up to date.
/// </para>
/// </summary>
public sealed class ClientLight(ClientLevel level) {
    private const int MaxChangedPerRound = 8;

    private readonly CalculatedLightingProvider _engine = new();
    private readonly HashSet<(int X, int Z)> _changed = [];
    private Task<List<Result>>? _job;
    private double _milliseconds, _longest;

    private sealed record Result(ClientChunk Chunk, LightData Light);

    private sealed class Column(LightSection[] sections) : ILightColumn {
        public int SectionCount => sections.Length;
        public LightSection Section(int index) => sections[index];
    }

    /// <summary>
    /// The engine reads nothing of a block but its light class and emission, so a change that keeps both,
    /// as water spreading or a crop growing does, cannot move any light.
    /// </summary>
    public void BlockChanged(int x, int z, uint oldState, uint newState) {
        if (BlockLightTable.ClassOf(oldState) == BlockLightTable.ClassOf(newState)
            && BlockLightTable.EmissionOf(oldState) == BlockLightTable.EmissionOf(newState)) {
            return;
        }
        _changed.Add((x >> 4, z >> 4));
    }

    /// <summary>
    /// Milliseconds the game thread spent on relighting since the last read, and the longest single
    /// tick of it, for profiling.
    /// </summary>
    public (double Total, double Longest) TakeMilliseconds() {
        (double, double) taken = (_milliseconds, _longest);
        _milliseconds = 0;
        _longest = 0;
        return taken;
    }

    public void Tick() {
        long start = System.Diagnostics.Stopwatch.GetTimestamp();
        if (_job is { IsCompleted: true } done) {
            _job = null;
            Apply(done.Result);
        }
        if (_job == null && _changed.Count > 0) {
            Start();
        }
        double elapsed = System.Diagnostics.Stopwatch.GetElapsedTime(start).TotalMilliseconds;
        _milliseconds += elapsed;
        _longest = Math.Max(_longest, elapsed);
    }

    private void Start() {
        HashSet<(int X, int Z)> targets = [];
        // A round takes a few changed chunks at most, so a burst (a tree falling, a wave of leaves
        // decaying) is spread over several ticks instead of one long copy and apply.
        foreach ((int cx, int cz) in _changed.Take(MaxChangedPerRound).ToArray()) {
            _changed.Remove((cx, cz));
            for (int dz = -1; dz <= 1; dz++) {
                for (int dx = -1; dx <= 1; dx++) {
                    targets.Add((cx + dx, cz + dz));
                }
            }
        }

        Dictionary<Vec2<int>, Column> columns = new();
        List<(Vec2<int> Pos, ClientChunk Chunk)> work = [];
        foreach ((int x, int z) in targets) {
            if (level.GetChunk(x, z) is not { } chunk || !NeighboursLoaded(x, z)) {
                continue;
            }
            for (int dz = -1; dz <= 1; dz++) {
                for (int dx = -1; dx <= 1; dx++) {
                    Vec2<int> pos = new(x + dx, z + dz);
                    if (!columns.ContainsKey(pos)) {
                        ClientSection[] sections = level.GetChunk(pos.X, pos.Y)!.Sections;
                        columns[pos] = new Column(Array.ConvertAll(sections, s => s.CopyForLight()));
                    }
                }
            }
            work.Add((new Vec2<int>(x, z), chunk));
        }
        if (work.Count == 0) {
            return;
        }

        bool hasSkyLight = level.DimensionType.HasSkyLight;
        _job = Task.Run(() => {
            List<Result> results = new(work.Count);
            foreach ((Vec2<int> pos, ClientChunk chunk) in work) {
                LightData light = _engine.GetLighting(pos, columns[pos], p => columns.GetValueOrDefault(p), hasSkyLight);
                results.Add(new Result(chunk, light));
            }
            return results;
        });
    }

    private void Apply(List<Result> results) {
        HashSet<(int X, int Y, int Z)> dirty = [];
        foreach ((ClientChunk chunk, LightData light) in results) {
            // A chunk unloaded, or unloaded and sent again, while the job ran has newer light already.
            if (level.GetChunk(chunk.X, chunk.Z) != chunk) {
                continue;
            }
            ulong changed = chunk.ReplaceLight(light);
            for (int section = 0; section < level.SectionCount; section++) {
                if ((changed & 1UL << section) == 0) {
                    continue;
                }
                // Smooth lighting and face shading read light across section edges.
                for (int dx = -1; dx <= 1; dx++) {
                    for (int dy = -1; dy <= 1; dy++) {
                        for (int dz = -1; dz <= 1; dz++) {
                            dirty.Add((chunk.X + dx, section + dy, chunk.Z + dz));
                        }
                    }
                }
            }
        }
        // Neighbouring sections overlap heavily, so each is marked once.
        foreach ((int x, int y, int z) in dirty) {
            level.MarkSectionDirty(x, y, z);
        }
    }

    private bool NeighboursLoaded(int x, int z) {
        for (int dz = -1; dz <= 1; dz++) {
            for (int dx = -1; dx <= 1; dx++) {
                if (!level.HasChunk(x + dx, z + dz)) {
                    return false;
                }
            }
        }
        return true;
    }
}
