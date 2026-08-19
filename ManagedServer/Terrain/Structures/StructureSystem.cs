using System.Collections.Concurrent;
using ManagedServer.Terrain.Features;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// The structure pass, vanilla's <c>createStructures</c>, <c>createReferences</c> and the structure
/// half of <c>applyBiomeDecoration</c>.
/// </summary>
/// <remarks>
/// <b>The shape is the carver pass's.</b> A structure never writes outside the chunk being generated,
/// because <see cref="StructurePiece.PlaceBlock"/> clips to the writable area, so the pass needs no
/// forks. What crosses a chunk border is not writes but <b>replay</b>: every chunk within
/// <see cref="Range"/> is asked what structures start there, and only the parts of those that land
/// inside this chunk are written. That is vanilla's own arrangement, where the same replay is done
/// once and stored as a chunk's references.
/// <p/>
/// <b>A start is cached, unlike a carver's walk.</b> A carver replayed from a source chunk is a few
/// thousand cheap steps; a structure start is a whole piece tree, and a mineshaft's is hundreds of
/// pieces built by a recursive layout. Recomputing that for each of the 289 chunks that replay it is
/// the difference between the pass costing a few percent and costing more than the terrain. The cache
/// is sound because <b>a start is a pure function of the world seed and its source chunk</b> and
/// depends on nothing about the chunk being generated.
/// </remarks>
public sealed class StructureSystem : IStructurePlacementState {
    /// <summary>
    /// How far a structure may reach, in chunks. Vanilla's <c>createReferences</c> uses eight, so a
    /// structure wider than seventeen chunks would lose its ends.
    /// </summary>
    public const int Range = 8;

    /// <summary>
    /// How many source chunks' starts are kept. Sized well past a view distance of 32, whose
    /// viewport is 4225 chunks, so a player exploring never evicts what they are standing in.
    /// </summary>
    private const int CacheLimit = 1 << 16;

    private readonly VanillaStructureData _data;
    private readonly MinecraftRegistry _registry;
    private readonly long _seed;

    /// <summary>Structures grouped by the decoration step they are placed in, in a stable order.</summary>
    /// <remarks>
    /// The id travels with the structure because a placement is written down by id, which is the only
    /// name vanilla shares: the pass itself needs nothing but the order.
    /// </remarks>
    private readonly Dictionary<DecorationStep, (Identifier Id, Structure Structure)[]> _byStep;

    private readonly ConcurrentDictionary<long, IReadOnlyList<StructureStart>> _starts = new();

    private readonly BiomeAtQuart _biomes;

    private readonly ConcurrentDictionary<ConcentricRingsStructurePlacement,
        Lazy<IReadOnlyList<Vec2<int>>>> _rings = new();

    public StructureSystem(VanillaStructureData data, MinecraftRegistry registry, long seed,
        BiomeAtQuart biomes) {

        _data = data;
        _registry = registry;
        _seed = seed;
        _biomes = biomes;

        // Sorted by id, which is the order the datapack directory is read in and therefore the order
        // the vanilla structure registry ends up in. That order is what a structure's per step index
        // is, and the index seeds it, so it is part of the world rather than a detail.
        _byStep = data.Structures
            .OrderBy(entry => entry.Key.ToString(), StringComparer.Ordinal)
            .GroupBy(entry => entry.Value.Step)
            .ToDictionary(group => group.Key,
                group => group.Select(entry => (entry.Key, entry.Value)).ToArray());

        _anyTerrainAdaptation = data.Structures.Values
            .Any(structure => structure.TerrainAdaptation != TerrainAdjustment.None);
    }

    public long LevelSeed => _seed;

    /// <summary>The sets and structures this pass places, and what it could not.</summary>
    public VanillaStructureData Data => _data;

    /// <summary>Whether any structure is placed in the given decoration step.</summary>
    public bool HasStep(DecorationStep step) => _byStep.ContainsKey(step);

    /// <summary>
    /// Places every structure of one decoration step that reaches this chunk.
    /// </summary>
    /// <remarks>
    /// The index the random is seeded with counts structures <b>within the step</b>, as vanilla's
    /// does, and is the same for every chunk a structure spans. So the two halves of a temple split
    /// across a border are drawn from the same sequence.
    /// </remarks>
    public void PlaceStep(DecorationStep step, IFeatureLevel level, PlacementContext features,
        WorldgenRandom random, long decorationSeed, int chunkX, int chunkZ, BoundingBox chunkBox,
        StructureGenerationContext.Factory contextFactory) {

        if (!_byStep.TryGetValue(step, out (Identifier Id, Structure Structure)[]? structures)) {
            return;
        }

        for (int index = 0; index < structures.Length; index++) {
            (Identifier id, Structure structure) = structures[index];
            random.SetFeatureSeed(decorationSeed, index, (int)step);

            foreach (StructureStart start in StartsReaching(chunkX, chunkZ, structure,
                contextFactory)) {

                Features.FeatureLevelDump.RecordPlacement(new Features.FeatureLevelDump.Placement(
                    id.ToString(), start.ChunkX, start.ChunkZ, (int)step, index));

                // A write is attributed to whoever last claimed the level, so a structure claims it
                // as a feature does. Without this a structure's blocks are credited to the feature
                // that ran before it, which reads as that feature writing where it never goes.
                if (level is Features.ChunkFeatureLevel attributed
                    && Features.FeatureLevelDump.Wanted(chunkX, chunkZ)) {

                    attributed.CurrentWriter = Features.FeatureLevelDump.WriterFor(id.ToString());
                }

                start.PlaceInChunk(level, features, random, chunkBox, chunkX, chunkZ);
            }
        }
    }

    /// <summary>
    /// The starts of one structure that overlap the chunk, found by replaying every source chunk in
    /// range.
    /// </summary>
    /// <summary>
    /// The starts reaching the chunk that want the terrain around them adjusted, for
    /// <see cref="Beardifier"/>.
    /// </summary>
    /// <remarks>
    /// This runs <b>before</b> the noise pass rather than during the decoration one, because the beard
    /// is a term in the terrain density. It is the same replay the placement does, so the two share
    /// the start cache and the second of them is 289 dictionary lookups.
    /// <p/>
    /// A start's box is already inflated by the terrain adaptation, so a structure whose beard reaches
    /// this chunk while its pieces do not is still found here.
    /// </remarks>
    public IEnumerable<StructureStart> StartsAdjustingTerrain(int chunkX, int chunkZ,
        StructureGenerationContext.Factory contextFactory) {

        if (!_anyTerrainAdaptation) {
            yield break;
        }

        int minX = chunkX << 4;
        int minZ = chunkZ << 4;

        for (int sourceX = chunkX - Range; sourceX <= chunkX + Range; sourceX++) {
            for (int sourceZ = chunkZ - Range; sourceZ <= chunkZ + Range; sourceZ++) {
                foreach (StructureStart start in StartsAt(sourceX, sourceZ, contextFactory)) {
                    if (start.Structure.TerrainAdaptation == TerrainAdjustment.None) {
                        continue;
                    }

                    if (start.BoundingBox.Intersects(minX, minZ, minX + 15, minZ + 15)) {
                        yield return start;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Whether any registered structure adjusts terrain at all. False means the beardifier is skipped
    /// whole, which saves a 289 chunk replay per chunk before the noise pass has run.
    /// </summary>
    private readonly bool _anyTerrainAdaptation;

    private IEnumerable<StructureStart> StartsReaching(int chunkX, int chunkZ, Structure structure,
        StructureGenerationContext.Factory contextFactory) {

        int minX = chunkX << 4;
        int minZ = chunkZ << 4;

        for (int sourceX = chunkX - Range; sourceX <= chunkX + Range; sourceX++) {
            for (int sourceZ = chunkZ - Range; sourceZ <= chunkZ + Range; sourceZ++) {
                foreach (StructureStart start in StartsAt(sourceX, sourceZ, contextFactory)) {
                    if (!ReferenceEquals(start.Structure, structure)) {
                        continue;
                    }

                    if (start.BoundingBox.Intersects(minX, minZ, minX + 15, minZ + 15)) {
                        yield return start;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Every structure that starts in one source chunk, vanilla's <c>createStructures</c>.
    /// </summary>
    /// <remarks>
    /// A set stops at its first structure that generates, so a nether complex is a fortress or a
    /// bastion and never both. A set with one entry skips the weighted draw entirely, which matters
    /// because the draw consumes from a random seeded per chunk.
    /// </remarks>
    public IReadOnlyList<StructureStart> StartsAt(int sourceChunkX, int sourceChunkZ,
        StructureGenerationContext.Factory contextFactory) {

        long key = ((long)sourceChunkX << 32) | (uint)sourceChunkZ;

        if (_starts.TryGetValue(key, out IReadOnlyList<StructureStart>? cached)) {
            return cached;
        }

        List<StructureStart> found = [];

        foreach (StructureSet set in _data.Sets.Values) {
            if (!set.Placement.IsStructureChunk(this, sourceChunkX, sourceChunkZ)) {
                continue;
            }

            StructureStart? start = set.Structures.Count == 1
                ? TryGenerate(set.Structures[0].Structure, sourceChunkX, sourceChunkZ, contextFactory)
                : TryGenerateWeighted(set, sourceChunkX, sourceChunkZ, contextFactory);

            if (start is not null) {
                found.Add(start);
            }
        }

        // Deterministic, so a race that computes the same source chunk twice stores equal answers and
        // whichever wins is the same world.
        if (_starts.Count >= CacheLimit) {
            _starts.Clear();
        }

        _starts[key] = found;
        return found;
    }

    /// <summary>
    /// The weighted draw for a set with several structures, which retries the rest when one declines.
    /// </summary>
    private StructureStart? TryGenerateWeighted(StructureSet set, int sourceChunkX, int sourceChunkZ,
        StructureGenerationContext.Factory contextFactory) {

        List<StructureSet.Entry> options = [..set.Structures];

        WorldgenRandom random = new(new LegacyRandomSource(0L));
        random.SetLargeFeatureSeed(_seed, sourceChunkX, sourceChunkZ);

        int total = options.Sum(entry => entry.Weight);

        while (options.Count > 0) {
            int choice = random.NextInt(total);
            int index = 0;

            foreach (StructureSet.Entry option in options) {
                choice -= option.Weight;

                if (choice < 0) {
                    break;
                }

                index++;
            }

            StructureSet.Entry selected = options[index];
            StructureStart? start = TryGenerate(selected.Structure, sourceChunkX, sourceChunkZ,
                contextFactory);

            if (start is not null) {
                return start;
            }

            options.RemoveAt(index);
            total -= selected.Weight;
        }

        return null;
    }

    private StructureStart? TryGenerate(Identifier id, int sourceChunkX, int sourceChunkZ,
        StructureGenerationContext.Factory contextFactory) {

        return _data.Structures.TryGetValue(id, out Structure? structure)
            ? structure.Generate(contextFactory(sourceChunkX, sourceChunkZ))
            : null;
    }

    // ------------------------------------------------- IStructurePlacementState

    /// <summary>
    /// Whether another set places anything within range, which is the pillager outpost's exclusion
    /// zone and nothing else.
    /// </summary>
    /// <remarks>
    /// Asks only the <b>placement</b> and never builds a start, so it costs a square of arithmetic
    /// rather than a square of structures.
    /// </remarks>
    public bool HasStructureChunkInRange(Identifier otherSet, int sourceX, int sourceZ, int range) {
        if (!_data.Sets.TryGetValue(otherSet, out StructureSet? set)) {
            return false;
        }

        for (int testX = sourceX - range; testX <= sourceX + range; testX++) {
            for (int testZ = sourceZ - range; testZ <= sourceZ + range; testZ++) {
                if (set.Placement.IsStructureChunk(this, testX, testZ)) {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// The stronghold ring positions, worked out on the first ask and kept.
    /// </summary>
    /// <remarks>
    /// About 416,000 climate samples for the overworld's 128 strongholds, so it is deliberately not
    /// part of building a generator: a world that never reaches the strongholds decoration step never
    /// pays for it. The <see cref="Lazy{T}"/> is what stops several chunks generating at once each
    /// starting their own copy of that.
    /// </remarks>
    public IReadOnlyList<Vec2<int>> RingPositionsFor(ConcentricRingsStructurePlacement placement) {
        return _rings.GetOrAdd(placement, key => new Lazy<IReadOnlyList<Vec2<int>>>(
            () => RingPositions.Generate(key, _seed, _biomes),
            LazyThreadSafetyMode.ExecutionAndPublication)).Value;
    }
}
