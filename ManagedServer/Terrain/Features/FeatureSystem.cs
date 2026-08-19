using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Biomes;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features;

/// <summary>
/// The decoration pass, vanilla's <c>ChunkGenerator.applyBiomeDecoration</c>.
/// </summary>
/// <remarks>
/// One per world, holding that world's seed and the shared feature table. It is stateless per chunk,
/// so several chunks decorate at once on the pool.
/// <p/>
/// <b>The seeding is the whole of the reproducibility argument.</b> A chunk's decoration seed comes
/// from the world seed and the chunk position alone, and each feature is then seeded from that plus
/// its <b>index in the global feature list</b> and its step. So a feature gets the same seed however
/// many biomes a chunk touches, whichever order the chunks were asked for, and on however many
/// threads.
/// </remarks>
public sealed class FeatureSystem {
    /// <summary>
    /// <c>GenerationStep.Decoration</c> has eleven values, and the loop runs over the larger of that
    /// and the number of steps the biome data has.
    /// </summary>
    private const int DecorationSteps = 11;

    /// <summary>
    /// The name vanilla's <c>WorldGenRegion</c> hashes to seed the random it exposes as
    /// <c>getRandom</c>.
    /// </summary>
    public static readonly Identifier LevelRandomName = new("minecraft", "worldgen_region_random");

    private readonly BiomeFeatureTable _table;
    private readonly MinecraftRegistry _registry;
    private readonly long _seed;
    private readonly IPositionalRandomFactory _levelRandom;

    public FeatureSystem(BiomeFeatureTable table, MinecraftRegistry registry, long seed,
        IPositionalRandomFactory levelRandom) {

        _table = table;
        _registry = registry;
        _seed = seed;
        _levelRandom = levelRandom;
    }

    /// <summary>
    /// Decorates one chunk.
    /// </summary>
    /// <param name="unit">The chunk being generated, for the fork a feature writes outside it through.</param>
    /// <param name="column">The staging column the terrain passes filled, which is read and written.</param>
    /// <param name="biomes">The biome at an absolute block position.</param>
    /// <param name="chunkBiomes">
    /// Every biome in this chunk's own grid. Vanilla takes the union over the <b>three by three</b>
    /// around the chunk, because it has those chunks' biome arrays to hand and this does not. The
    /// difference is a feature that only a neighbouring chunk's biome asks for and whose scattered
    /// position lands inside this one, which needs both a biome border and a <c>random_offset</c> to
    /// reach. It cannot shift any other feature's seed, because those are keyed on the global index
    /// rather than on how many features ran.
    /// </param>
    /// <summary>
    /// Runs at the start of one decoration step, before that step's features.
    /// </summary>
    /// <remarks>
    /// The structure pass hooks in here rather than running before or after the whole of decoration,
    /// because vanilla interleaves the two: <c>applyBiomeDecoration</c>'s loop places every structure
    /// of a step and then every feature of it. A monument placed after the vegetation would have
    /// trees growing inside it.
    /// </remarks>
    public delegate void StepHook(int step, IFeatureLevel level, PlacementContext features,
        WorldgenRandom random, long decorationSeed);

    public void Decorate(IGenerationUnit unit, ChunkColumn column, BiomeAtBlock biomes,
        IReadOnlyCollection<Identifier> chunkBiomes, int seaLevel, NeighbourTerrain? neighbours = null,
        StepHook? beforeStep = null, BiomeAtQuart? cellBiomes = null) {

        int chunkX = unit.AbsoluteStart.X >> 4;
        int chunkZ = unit.AbsoluteStart.Z >> 4;

        unit.Fork(outside => {
            // At the chunk's minimum corner at y zero, which is what a ChunkPos answers for its world
            // position.
            ChunkFeatureLevel level = new(column, outside, biomes, _registry, chunkX, chunkZ, unit.MinY,
                unit.MaxY, seaLevel, _seed, _levelRandom.At(chunkX << 4, 0, chunkZ << 4), neighbours);

            GenerationHeightContext heights = new(unit.MinY, unit.MaxY - unit.MinY);
            PlacementContext context = new(level, heights, HasFeature, null);

            WorldgenRandom random = new(new XoroshiroRandomSource(RandomSupportUniqueSeed()));
            long decorationSeed = random.SetDecorationSeed(_seed, unit.AbsoluteStart.X, unit.AbsoluteStart.Z);

            Vec3<int> origin = new(unit.AbsoluteStart.X, 0, unit.AbsoluteStart.Z);

            // Taken before anything decorates, so vanilla can be run over the same bytes rather than
            // over a world of its own. See FeatureLevelDump.
            bool dumping = FeatureLevelDump.Wanted(chunkX, chunkZ);
            uint[]? before = dumping ? FeatureLevelDump.Capture(level, chunkX, chunkZ) : null;
            int structureWrites = 0;

            if (dumping) {
                FeatureLevelDump.BeginPlacements();
            }

            int steps = Math.Max(DecorationSteps, _table.StepCount);

            for (int step = 0; step < steps; step++) {
                // Before the step's own bounds test, since a structure step can be past the last one
                // any biome has features for.
                int wroteBefore = level.Writes;
                beforeStep?.Invoke(step, level, context, random, decorationSeed);
                structureWrites += level.Writes - wroteBefore;

                if (step >= _table.StepCount) {
                    continue;
                }

                // The set of indices, not of features: two biomes asking for the same feature run it
                // once, and the order is the global one rather than either biome's.
                SortedSet<int> indices = [];
                foreach (Identifier biome in chunkBiomes) {
                    foreach (PlacedFeature feature in _table.For(biome, step)) {
                        indices.Add(_table.IndexOf(step, feature));
                    }
                }

                foreach (int index in indices) {
                    // A feature this build does not transcribe still holds its place in the list, and
                    // the index is what seeds every feature after it. Nothing runs for that slot.
                    if (_table.GlobalStep(step)[index] is not { } feature) {
                        continue;
                    }

                    random.SetFeatureSeed(decorationSeed, index, step);

                    if (dumping) {
                        level.CurrentWriter = FeatureLevelDump.WriterFor(feature.Id?.ToString() ?? "?");
                    }

                    FeatureLevelDump.Tracing = FeatureLevelDump.Target is { } trace
                        && trace.ChunkX == chunkX && trace.ChunkZ == chunkZ && trace.Step == step
                        && trace.Index == index;

                    feature.PlaceWithBiomeCheck(context, random, origin);
                    FeatureLevelDump.Tracing = false;
                }
            }

            if (before != null) {
                FeatureLevelDump.Write(FeatureLevelDump.PathFor(chunkX, chunkZ), level,
                    cellBiomes ?? ((x, y, z) => biomes(x << 2, y << 2, z << 2)), before,
                    FeatureLevelDump.Capture(level, chunkX, chunkZ), _seed, chunkX, chunkZ,
                    structureWrites, level.Writers, FeatureLevelDump.TakePlacements());
            }
        });
    }

    private bool HasFeature(IBiome biome, PlacedFeature feature) {
        return _table.Contains(biome.Identifier, feature);
    }

    /// <summary>
    /// The generator vanilla seeds its <c>WorldgenRandom</c> with before immediately reseeding it from
    /// the world seed and the chunk position.
    /// </summary>
    /// <remarks>
    /// Upstream this is <c>RandomSupport.generateUniqueSeed()</c>, which is genuinely random. It never
    /// reaches anything: <c>setDecorationSeed</c> calls <c>setSeed</c> first, so every draw after it
    /// comes from the world seed. A constant here keeps the same shape without pretending the value
    /// matters.
    /// </remarks>
    private static long RandomSupportUniqueSeed() => 0L;
}

/// <summary>
/// <c>WorldgenRandom</c>: a random source with the worldgen seeding rules on it.
/// </summary>
/// <remarks>
/// <b>It is a bit source over the generator it wraps, not a pass through to it.</b> Upstream it
/// extends <c>LegacyRandomSource</c>, so every value it hands out is derived from
/// <see cref="Next"/> the way <c>BitRandomSource</c> derives it, and the only thing the wrapped
/// generator supplies is the bits. Over a <see cref="XoroshiroRandomSource"/> that changes what
/// almost every draw is worth: a <c>nextInt</c> is the <b>top</b> 32 bits of a long rather than the
/// bottom, a <c>nextLong</c> is two draws rather than one, and a bounded <c>nextInt</c> is the
/// legacy rejection loop rather than Xoroshiro's multiply-shift.
/// <p/>
/// Delegating instead is silent: <c>nextFloat</c> agrees either way, so a chunk still decorates, with
/// every feature in it somewhere else. That is the whole of the decoration pass, since the feature
/// seeds themselves come out of <see cref="SetDecorationSeed"/>'s two <c>nextLong</c> calls.
/// <p/>
/// The wrapped source being legacy is a separate branch upstream and not an optimisation: a
/// <see cref="LegacyRandomSource"/> is asked for <paramref name="bits"/> bits directly, which is one
/// step of its generator, where the general path spends a whole long on them. Structures wrap a
/// legacy source and features a Xoroshiro one, so both paths are live.
/// </remarks>
public sealed class WorldgenRandom(RandomSource source) : RandomSource {
    /// <summary>How many times <see cref="Next"/> has been called, vanilla's <c>getCount</c>.</summary>
    public int Count { get; private set; }

    public override int Next(int bits) {
        Count++;

        return source is LegacyRandomSource legacy
            ? legacy.Next(bits)
            : (int)((ulong)source.NextLong() >> (64 - bits));
    }

    /// <summary>
    /// Reseeds the wrapped generator, and deliberately does not reset the half used gaussian: vanilla
    /// overrides <c>setSeed</c> without calling the superclass, so a spare survives a reseed here
    /// where it does not on the generator itself.
    /// </summary>
    public override void SetSeed(long seed) => source.SetSeed(seed);

    public override RandomSource Fork() => source.Fork();
    public override IPositionalRandomFactory ForkPositional() => source.ForkPositional();

    /// <summary>
    /// <c>setDecorationSeed</c>: the seed every feature in a chunk is derived from.
    /// </summary>
    /// <remarks>
    /// The two multipliers are forced odd, which is what stops a chunk at a multiple of some power of
    /// two sharing a seed with its neighbours.
    /// </remarks>
    public long SetDecorationSeed(long seed, int blockX, int blockZ) {
        SetSeed(seed);

        long xScale = NextLong() | 1L;
        long zScale = NextLong() | 1L;
        long result = blockX * xScale + blockZ * zScale ^ seed;

        SetSeed(result);
        return result;
    }

    /// <summary>
    /// <c>setFeatureSeed</c>: one feature's seed, from the chunk's decoration seed plus where the
    /// feature sits in the global list.
    /// </summary>
    /// <remarks>
    /// The <c>10000</c> separates the steps, and the index is the global one rather than a per biome
    /// position, which is what makes a feature's seed independent of which biomes a chunk holds.
    /// </remarks>
    public void SetFeatureSeed(long seed, int index, int step) {
        SetSeed(seed + index + 10000L * step);
    }

    /// <summary><c>setLargeFeatureSeed</c>, which structures use rather than features.</summary>
    public void SetLargeFeatureSeed(long seed, int chunkX, int chunkZ) {
        SetSeed(seed);

        long xScale = NextLong();
        long zScale = NextLong();

        SetSeed(chunkX * xScale ^ chunkZ * zScale ^ seed);
    }

    /// <summary><c>setLargeFeatureWithSalt</c>: how a structure set spaces itself out.</summary>
    public void SetLargeFeatureWithSalt(long seed, int x, int z, int salt) {
        SetSeed(x * 341873128712L + z * 132897987541L + seed + salt);
    }
}
