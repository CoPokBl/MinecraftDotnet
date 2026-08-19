using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;

namespace Minecraft.Implementations.Server.Terrain.Generation;

/// <summary>
/// Runs an <see cref="IGenerator"/> over each requested chunk, and routes anything it wrote outside
/// that chunk to where it belongs.
/// </summary>
/// <remarks>
/// One per world. The generator itself can be shared between worlds; this cannot, because the world's
/// bounds and the parked forks are per world, so <see cref="Attach"/> refuses a second one rather than
/// quietly generating terrain for the wrong y range.
/// <p/>
/// A world with no host attached still generates: forks that land in the chunk being generated are
/// applied inline, and only ones aimed at another chunk need somewhere to go.
/// </remarks>
public class GeneratorTerrainProvider : ITerrainProvider {
    private readonly IGenerator _generator;
    private readonly MinecraftRegistry _registry;
    private readonly ForkQueue _forks = new();

    private ITerrainHost? _host;

    public GeneratorTerrainProvider(IGenerator generator, MinecraftRegistry? registry = null) {
        _generator = generator;
        _registry = registry ?? VanillaRegistry.Data;
    }

    public IGenerator Generator => _generator;

    /// <summary>How many chunks are holding terrain forked into them but not yet generated.</summary>
    public int PendingForkChunks => _forks.PendingChunks;

    public void Attach(ITerrainHost host) {
        if (_host != null && !ReferenceEquals(_host, host)) {
            throw new InvalidOperationException(
                "A GeneratorTerrainProvider belongs to one world: it holds that world's bounds and the " +
                "terrain forked into its chunks. Give each world its own, sharing the IGenerator.");
        }

        if (_host != null) {
            return;
        }

        _host = host;
        host.ChunkAvailable += pos => _forks.Drain(pos, _registry.Blocks.StatesCount, host);
    }

    public void GetChunk(ref ChunkData chunk) {
        int minY = chunk.MinY;
        int maxY = minY + chunk.WorldHeight;

        if ((minY & 15) != 0) {
            // Every section boundary is assumed to sit on a multiple of 16 in absolute coordinates,
            // which is what lets a coordinate be masked to its section with a plain "& 15". No vanilla
            // dimension breaks this, and a world that did would misplace every block silently.
            throw new InvalidOperationException(
                $"A world's min y must be a multiple of 16 to be generated into; this one is {minY}.");
        }

        Vec2<int> pos = new(chunk.ChunkX, chunk.ChunkZ);
        GenerationContext context = new(minY, maxY, _registry);

        // Taken before the generator runs, because that is what lets it put them where vanilla does:
        // a neighbour's writes reach a chunk between its carvers and its features, so this chunk's own
        // decoration is entitled to read them and to overwrite them. Anything posted from here on
        // parks and is drained once this chunk is published, which is the other half of vanilla's
        // order and needs nothing else.
        context.SetForkedIn(pos, _forks.Take(pos));

        int sectionCount = chunk.WorldHeight / ChunkSection.Size;
        SectionUnit[] units = new SectionUnit[sectionCount];
        GenerationSection[] buffers = new GenerationSection[sectionCount];

        for (int i = 0; i < sectionCount; i++) {
            buffers[i] = new GenerationSection();
            units[i] = new SectionUnit(buffers[i],
                new Vec3<int>(chunk.ChunkX * ChunkSection.Size, minY + i * ChunkSection.Size,
                    chunk.ChunkZ * ChunkSection.Size),
                minY, maxY, _registry, context);
        }

        AreaUnit unit = new(units, 1, sectionCount, 1,
            new Vec3<int>(chunk.ChunkX * ChunkSection.Size, minY, chunk.ChunkZ * ChunkSection.Size),
            minY, maxY, _registry, context);

        try {
            _generator.Generate(unit);
            Commit(chunk, buffers, minY);
        } finally {
            // Even on a throwing generator, so a bad implementation costs a chunk rather than the
            // pooled buffers for the rest of the run.
            foreach (GenerationSection buffer in buffers) {
                buffer.Release();
            }
        }

        // Straight into the data: nobody can see this chunk yet, so there is nothing to lock and
        // nothing to resend.
        DispatchForks(context, pos, chunk);

        // Whatever the generator declined to read. A generator with no notion of stages has nowhere
        // sensible to put it, so it lands on top of the finished chunk, which is where a fork arriving
        // any later lands too.
        if (context.UnreadForkedIn is { } unread) {
            long stateCount = _registry.Blocks.StatesCount;

            foreach (ForkedSection fork in unread) {
                if (fork.SectionIndex >= 0 && fork.SectionIndex < chunk.Sections.Length) {
                    fork.Overlay.MergeInto(chunk.Sections[fork.SectionIndex], stateCount);
                }
            }

            chunk.InvalidateHeightmaps();
        }
    }

    private void Commit(ChunkData chunk, GenerationSection[] buffers, int minY) {
        long stateCount = _registry.Blocks.StatesCount;
        long biomeCount = _registry.Biomes.Count;

        for (int i = 0; i < buffers.Length; i++) {
            GenerationSection buffer = buffers[i];
            if (!buffer.Touched) {
                continue;
            }

            buffer.CommitTo(chunk.Sections[i], stateCount, biomeCount);

            foreach ((int index, (IBlockEntityType type, INbtTag data)) in buffer.BlockEntities) {
                int localX = index & 15;
                int localZ = (index >> 4) & 15;
                int gameY = minY + i * ChunkSection.Size + (index >> 8);

                // Keyed chunk local in x and z with the game y, which is the convention World's own
                // accessors use and what the wire record carries.
                chunk.BlockEntities[new Vec3<int>(localX, gameY, localZ)] =
                    new BlockEntity(localX, gameY, localZ, type, data);
            }
        }

        // The sections were replaced wholesale rather than through ChunkData.SetBlock, so nothing has
        // told the chunk its heightmaps are stale.
        chunk.InvalidateHeightmaps();
    }

    private void DispatchForks(GenerationContext context, Vec2<int> own, ChunkData chunk) {
        if (!context.HasForks) {
            return;
        }

        long stateCount = _registry.Blocks.StatesCount;

        foreach ((Vec2<int> target, Dictionary<int, GenerationSection> sections) in context.Forks) {
            foreach ((int sectionIndex, GenerationSection overlay) in sections) {
                if (!overlay.HasWrites) {
                    continue;
                }

                if (target == own) {
                    // Landed at home, which is the common case: most of a tree is in the chunk that
                    // grew it. No lock, nothing to announce.
                    if (sectionIndex >= 0 && sectionIndex < chunk.Sections.Length) {
                        overlay.MergeInto(chunk.Sections[sectionIndex], stateCount);
                        chunk.InvalidateHeightmaps();
                    }
                    continue;
                }

                if (_host == null) {
                    // Nothing to route through, so the write has nowhere to go. Silently dropping it
                    // would look like a generator bug, so say what is missing.
                    throw new InvalidOperationException(
                        $"A generator forked terrain into chunk {target} while generating {own}, but " +
                        "this provider has no host to deliver it through. A world attaches one; a " +
                        "provider driven by hand has to call Attach itself.");
                }

                _forks.Post(target, new ForkedSection(sectionIndex, overlay), stateCount, _host);
            }
        }
    }
}
