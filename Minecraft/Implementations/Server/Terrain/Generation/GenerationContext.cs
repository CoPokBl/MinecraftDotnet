using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain.Generation;

/// <summary>Where a unit sends a write that lands outside itself.</summary>
internal interface IForkSink {
    IGenerationUnit Fork(Vec3<int> start, Vec3<int> end);
    void Fork(Action<IBlockSetter> build);
    bool ReadForkedWrites(ForkedBlock into);
    ChunkData? ReadNeighbour(int chunkX, int chunkZ, ForkedBlock forked);
}

/// <summary>
/// One chunk's generation: the sections being filled, and everything the generator wrote outside them.
/// </summary>
/// <remarks>
/// Per call rather than per provider, because a provider is shared and several chunks are generated
/// at once on the pool. Nothing here is thread safe and nothing needs to be: a context is only ever
/// touched by the thread generating its chunk.
/// <p/>
/// Forks are collected as sparse sections keyed by the chunk they belong to. That is the same
/// structure whichever way a fork was asked for, so <see cref="Fork(Vec3{int},Vec3{int})"/> and
/// <see cref="Fork(Action{IBlockSetter})"/> differ only in how they find the section for a write.
/// </remarks>
internal sealed class GenerationContext : IForkSink {
    private readonly int _minY;
    private readonly int _maxY;
    private readonly MinecraftRegistry _registry;

    /// <summary>Chunk position, then section index from the bottom of the world, then the overlay.</summary>
    private readonly Dictionary<Vec2<int>, Dictionary<int, GenerationSection>> _forks = [];

    /// <summary>What neighbours forked into this chunk before it existed, or null if nothing did.</summary>
    private List<ForkedSection>? _forkedIn;
    private Vec2<int> _forkedInChunk;

    /// <summary>What <see cref="ReadNeighbour"/> asks, or null for a context with no world behind it.</summary>
    private readonly Func<Vec2<int>, ChunkData?>? _generated;
    private readonly Func<Vec2<int>, Action<ForkedSection>, bool>? _parked;

    public GenerationContext(int minY, int maxY, MinecraftRegistry registry,
        Func<Vec2<int>, ChunkData?>? generated = null,
        Func<Vec2<int>, Action<ForkedSection>, bool>? parked = null) {

        _minY = minY;
        _maxY = maxY;
        _registry = registry;
        _generated = generated;
        _parked = parked;
    }

    /// <summary>
    /// A neighbour as the world holds it: a frozen copy if it has been generated, and otherwise null
    /// after replaying what other chunks have forked into it so far.
    /// </summary>
    public ChunkData? ReadNeighbour(int chunkX, int chunkZ, ForkedBlock forked) {
        Vec2<int> chunk = new(chunkX, chunkZ);

        if (_generated?.Invoke(chunk) is { } generated) {
            return generated;
        }

        _parked?.Invoke(chunk, fork => {
            int sectionMinY = _minY + fork.SectionIndex * ChunkSection.Size;
            fork.Overlay.ForEachWrite((x, y, z, state) =>
                forked((chunkX << 4) | x, sectionMinY + y, (chunkZ << 4) | z, state));
        });

        return null;
    }

    /// <summary>
    /// The terrain neighbours parked for this chunk before it existed, handed over by the provider
    /// before generation starts.
    /// </summary>
    public void SetForkedIn(Vec2<int> chunk, List<ForkedSection>? forks) {
        _forkedInChunk = chunk;
        _forkedIn = forks;
    }

    /// <summary>What is still parked once the generator has had its chance to read it.</summary>
    public List<ForkedSection>? UnreadForkedIn => _forkedIn;

    /// <summary>
    /// Replays what a neighbour forked into this chunk, in absolute coordinates, and gives up
    /// ownership of it.
    /// </summary>
    public bool ReadForkedWrites(ForkedBlock into) {
        if (_forkedIn == null) {
            return false;
        }

        foreach (ForkedSection fork in _forkedIn) {
            int sectionMinY = _minY + fork.SectionIndex * ChunkSection.Size;
            fork.Overlay.ForEachWrite((x, y, z, state) =>
                into((_forkedInChunk.X << 4) | x, sectionMinY + y, (_forkedInChunk.Y << 4) | z, state));
            fork.Overlay.Release();
        }

        _forkedIn = null;
        return true;
    }

    public IReadOnlyDictionary<Vec2<int>, Dictionary<int, GenerationSection>> Forks => _forks;

    public bool HasForks => _forks.Count > 0;

    /// <summary>
    /// The overlay for a section, created on first write so a fork that never touches a section it
    /// declared does not cost one.
    /// </summary>
    public GenerationSection SectionFor(Vec2<int> chunk, int sectionIndex) {
        if (!_forks.TryGetValue(chunk, out Dictionary<int, GenerationSection>? sections)) {
            _forks[chunk] = sections = [];
        }

        if (!sections.TryGetValue(sectionIndex, out GenerationSection? section)) {
            sections[sectionIndex] = section = new GenerationSection(sparse: true);
        }

        return section;
    }

    public IGenerationUnit Fork(Vec3<int> start, Vec3<int> end) {
        // Snapped outwards to whole sections, since a unit is always made of them, and clamped to the
        // world so a fork off the top or bottom is trimmed rather than throwing.
        int x0 = FloorSection(start.X), x1 = CeilSection(end.X);
        int z0 = FloorSection(start.Z), z1 = CeilSection(end.Z);
        int y0 = Math.Max(FloorSection(start.Y), _minY);
        int y1 = Math.Min(CeilSection(end.Y), _maxY);

        if (x0 >= x1 || y0 >= y1 || z0 >= z1) {
            throw new ArgumentException(
                $"A fork from {start} to {end} covers nothing once snapped to sections and clamped to " +
                $"the world's {_minY} to {_maxY}.");
        }

        int width = (x1 - x0) / ChunkSection.Size;
        int height = (y1 - y0) / ChunkSection.Size;
        int depth = (z1 - z0) / ChunkSection.Size;

        SectionUnit[] units = new SectionUnit[width * height * depth];
        for (int sz = 0; sz < depth; sz++) {
            for (int sy = 0; sy < height; sy++) {
                for (int sx = 0; sx < width; sx++) {
                    Vec3<int> sectionStart = new(x0 + sx * ChunkSection.Size, y0 + sy * ChunkSection.Size,
                        z0 + sz * ChunkSection.Size);

                    units[sz * width * height + sy * width + sx] = new SectionUnit(
                        SectionAt(sectionStart), sectionStart, _minY, _maxY, _registry, this);
                }
            }
        }

        return new AreaUnit(units, width, height, depth, new Vec3<int>(x0, y0, z0), _minY, _maxY,
            _registry, this);
    }

    public void Fork(Action<IBlockSetter> build) {
        build(new DynamicFork(this));
    }

    /// <summary>The overlay covering an absolute position.</summary>
    public GenerationSection SectionAt(Vec3<int> pos) {
        return SectionFor(new Vec2<int>(pos.X >> 4, pos.Z >> 4), (pos.Y - _minY) >> 4);
    }

    public bool InWorld(int y) => y >= _minY && y < _maxY;

    private static int FloorSection(int value) => value & ~15;

    private static int CeilSection(int value) => (value + ChunkSection.Size - 1) & ~15;

    /// <summary>
    /// A fork whose extent comes from what gets written rather than from what was declared, which is
    /// what a tree or an ore vein wants.
    /// </summary>
    /// <remarks>
    /// Resolves the section per write, three shifts and two dictionary lookups, rather than keeping a
    /// grid that grows to fit. The things this is for place a few hundred blocks, so a grid would be
    /// bookkeeping against a cost nobody pays.
    /// <p/>
    /// Writes outside the world are dropped, not thrown: a tree near the build limit is a normal thing
    /// for a generator to attempt.
    /// </remarks>
    private sealed class DynamicFork(GenerationContext context) : IBlockSetter {
        public void SetBlock(int x, int y, int z, Data.Blocks.IBlock block) {
            SetBlockState(x, y, z, block.StateId);
        }

        public void SetBlock(Vec3<int> pos, Data.Blocks.IBlock block) {
            SetBlockState(pos.X, pos.Y, pos.Z, block.StateId);
        }

        public void SetBlockState(int x, int y, int z, uint stateId) {
            if (!context.InWorld(y)) {
                return;
            }

            context.SectionAt(new Vec3<int>(x, y, z)).SetBlock(x & 15, y & 15, z & 15, stateId);
        }

        public void SetBlockState(Vec3<int> pos, uint stateId) {
            SetBlockState(pos.X, pos.Y, pos.Z, stateId);
        }
    }
}
