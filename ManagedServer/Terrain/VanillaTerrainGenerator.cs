using ManagedServer.Terrain.Biomes;
using ManagedServer.Terrain.Carvers;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Material;
using ManagedServer.Terrain.Structures;
using Minecraft.Data.Biomes;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain;

/// <summary>
/// Vanilla's noise terrain, as an <see cref="IGenerator"/>.
/// </summary>
/// <remarks>
/// A port of <c>NoiseBasedChunkGenerator</c>: the density functions decide what is solid, the aquifers
/// decide what fills the rest, the multi noise biome source decides which biome each cell is, and the
/// material rules turn the stone into ground and put the ore veins in it.
/// <p/>
/// <b>Not registered anywhere by default.</b> Like everything else in this framework it is a thing a
/// consumer asks for:
/// <code>
/// World world = server.CreateWorld(DimensionType.Overworld,
///     VanillaTerrainGenerator.Overworld(seed).AsProvider());
/// </code>
/// <p/>
/// One instance per world. It holds that world's seeded noises and its biome table, both of which are
/// expensive to build and neither of which depends on the chunk, so sharing one between worlds of
/// different seeds is what the seed argument exists to prevent.
/// <p/>
/// <b>What this generates.</b> The noise terrain, the aquifers, the biomes and the material rules,
/// ore veins included; when <see cref="WithCarvers"/> is asked for, the caves and ravines; when
/// <see cref="WithFeatures"/> is asked for, the decoration pass: trees, grass, flowers, ores and the
/// rest of a biome's feature list; and when <see cref="WithStructures"/> is asked for, the structures,
/// both the code-built ones and everything assembled out of NBT templates.
/// <p/>
/// All three extra passes are <b>off by default</b>, on the same rule as everything else here: a
/// consumer who wants bare terrain gets it without asking, and one who wants caves says so.
/// </remarks>
public sealed class VanillaTerrainGenerator : IGenerator {
    /// <summary>Vanilla's lava level below the sea, from <c>createFluidPicker</c>.</summary>
    private const int LavaLevel = -54;

    private readonly MinecraftRegistry _registry;
    private readonly IDatapackSource _source;
    private readonly NoiseGeneratorSettings _settings;
    private readonly RandomState _randomState;
    private readonly MultiNoiseBiomeSource _biomeSource;
    private readonly BiomeZoom _biomeZoom;
    private readonly IFluidPicker _globalFluidPicker;

    /// <summary>
    /// The terrain of chunks generated recently, which is what a feature reading into a neighbour is
    /// answered from.
    /// </summary>
    private readonly TerrainStore _terrain = new();

    /// <summary>
    /// Which biomes each chunk holds, for the union the feature pass decorates from.
    /// </summary>
    /// <remarks>
    /// <c>applyBiomeDecoration</c> collects the biomes of every section of the <b>three by three</b>,
    /// so a chunk runs the features of a biome that only its neighbour holds. Those features write
    /// nothing outside that biome, because the per candidate biome filter still guards each one, but
    /// they do write inside it: a jungle across the border puts grass in the corner of this chunk.
    /// <p/>
    /// Kept per chunk because eight of the nine are somebody else's, and a viewport generates the ring
    /// anyway: a set computed once is read by nine chunks. A miss costs a grid of climate searches,
    /// which is the biome pass for one chunk and no terrain.
    /// </remarks>
    private readonly ChunkBiomeStore _biomeSets = new();

    private readonly uint _airState;

    private FeatureSystem? _features;
    private CarverSystem? _carvers;
    private StructureSystem? _structures;

    /// <summary>The parsed feature data, which the structure pass needs for its pool elements.</summary>
    private VanillaFeatureData? _featureData;

    public VanillaTerrainGenerator(IDatapackSource source, Identifier noiseSettings,
        Identifier biomePreset, long seed, MinecraftRegistry? registry = null) {

        _registry = registry ?? VanillaRegistry.Data;
        _source = source;

        VanillaWorldgenData data = VanillaWorldgenData.Load(source, _registry);
        _settings = data.GetNoiseSettings(noiseSettings);
        _randomState = new RandomState(_registry, _settings, data.ResolveNoise, seed);
        _biomeSource = new MultiNoiseBiomeSource(data.GetBiomeParameters(biomePreset));
        _biomeZoom = new BiomeZoom(BiomeZoom.ObfuscateSeed(seed));

        _globalFluidPicker = new GlobalFluidPicker(_settings.SeaLevel, _settings.DefaultFluid);
        _airState = Block.Air.StateId;

        Seed = seed;
    }

    public long Seed { get; }

    public NoiseGeneratorSettings Settings => _settings;

    public int SeaLevel => _settings.SeaLevel;

    /// <summary>The ordinary overworld.</summary>
    public static VanillaTerrainGenerator Overworld(IDatapackSource source, long seed,
        MinecraftRegistry? registry = null) {

        return new VanillaTerrainGenerator(source, "minecraft:overworld", "minecraft:overworld", seed, registry);
    }

    /// <summary>The overworld with the <c>amplified</c> world type's exaggerated terrain.</summary>
    public static VanillaTerrainGenerator Amplified(IDatapackSource source, long seed,
        MinecraftRegistry? registry = null) {

        return new VanillaTerrainGenerator(source, "minecraft:amplified", "minecraft:overworld", seed, registry);
    }

    /// <summary>The overworld with the <c>large_biomes</c> world type's stretched climate noise.</summary>
    public static VanillaTerrainGenerator LargeBiomes(IDatapackSource source, long seed,
        MinecraftRegistry? registry = null) {

        return new VanillaTerrainGenerator(source, "minecraft:large_biomes", "minecraft:overworld", seed, registry);
    }

    /// <summary>The nether.</summary>
    public static VanillaTerrainGenerator Nether(IDatapackSource source, long seed,
        MinecraftRegistry? registry = null) {

        return new VanillaTerrainGenerator(source, "minecraft:nether", "minecraft:nether", seed, registry);
    }

    /// <summary>
    /// Turns the decoration pass on: trees, grass, flowers, ores and everything else a biome's feature
    /// list asks for.
    /// </summary>
    /// <remarks>
    /// Returns this generator, so it reads as part of the chain that builds one. Building the feature
    /// table parses the whole feature datapack and sorts it, which is why it happens here rather than
    /// in the constructor: a consumer who never asks never pays for it.
    /// <p/>
    /// Not every vanilla feature type is transcribed, and the ones that are not are named on
    /// <see cref="FeatureParser.NotTranscribed"/> with their reasons.
    /// <see cref="VanillaFeatureData.Skipped"/> is what a consumer can print to see the gap in the
    /// world it is actually generating.
    /// </remarks>
    public VanillaTerrainGenerator WithFeatures() {
        _featureData = VanillaFeatureData.Load(_source, _registry);
        _features = new FeatureSystem(_featureData.TableFor(_biomeSource.PossibleBiomes), _registry, Seed,
            _randomState.GetOrCreateRandomFactory(FeatureSystem.LevelRandomName));
        return this;
    }

    /// <summary>Whether the decoration pass runs.</summary>
    public bool HasFeatures => _features is not null;

    /// <summary>
    /// Turns the carving pass on: the cave systems and the ravines.
    /// </summary>
    /// <remarks>
    /// Returns this generator, so it reads as part of the chain that builds one.
    /// <p/>
    /// The caves the density functions already cut through <c>final_density</c> are there either way;
    /// these are the ones on top of them, and the ravines, which nothing else produces.
    /// <p/>
    /// It is the most expensive of the optional passes by a wide margin, because a carver that reaches
    /// this chunk may have started eight chunks away and the only way to know is to replay all 289 of
    /// them. See <see cref="Carvers.CarverSystem"/>.
    /// </remarks>
    public VanillaTerrainGenerator WithCarvers() {
        _carvers = new CarverSystem(VanillaCarverData.Load(_source, _registry), _registry, Seed);
        return this;
    }

    /// <summary>Whether the carving pass runs.</summary>
    public bool HasCarvers => _carvers is not null;

    /// <summary>
    /// Turns the structure pass on: the code-built structures, placed where the vanilla structure
    /// sets space them out.
    /// </summary>
    /// <remarks>
    /// Returns this generator, so it reads as part of the chain that builds one.
    /// <p/>
    /// It requires the feature pass, because vanilla interleaves the two by decoration step and this
    /// hooks into that loop. Asking for structures alone is a mistake rather than a configuration, so
    /// it throws rather than quietly doing nothing.
    /// <p/>
    /// Not every vanilla structure is transcribed. <see cref="Structures.StructureParser.NotTranscribed"/>
    /// names the ones that need the structure template loader and
    /// <see cref="Structures.StructureParser.NotYetTranscribed"/> the code-built ones still to do;
    /// <see cref="VanillaStructureData.Skipped"/> is what a consumer can print to see the gap in the
    /// world it is actually generating.
    /// </remarks>
    public VanillaTerrainGenerator WithStructures() {
        if (_features is null) {
            throw new InvalidOperationException(
                "WithStructures() needs the feature pass, because structures are placed inside its "
                + "per step loop. Call WithFeatures() first.");
        }

        _structures = new StructureSystem(
            VanillaStructureData.Load(_source, _featureData!, _registry), _registry, Seed, BiomeAt);

        return this;
    }

    /// <summary>
    /// The biome at a quart position, from the climate alone, <c>createUncachedResolver</c>.
    /// </summary>
    /// <remarks>
    /// Point samples with no cache, so it answers for any position. A chunk's stored biomes come from
    /// a volume sample instead and can differ from this where the two paths round differently.
    /// </remarks>
    public Identifier BiomeAt(int quartX, int quartY, int quartZ) {
        return _biomeSource.GetBiome(quartX, quartY, quartZ, _randomState.UncachedClimateSampler());
    }

    /// <summary>
    /// A climate sampler over a fresh caching context, which is what vanilla's structure checks sample
    /// through. Its cache state carries between calls, so one is meant for one batch of queries.
    /// </summary>
    public ClimateSampler CreateCachingClimateSampler() {
        return _randomState.CreateClimateSampler(SamplerContext.CreateBuilder().EnableCaches().Build());
    }

    /// <summary>
    /// <c>BiomeSource.possibleBiomes</c>: every biome the climate table can name.
    /// </summary>
    /// <remarks>
    /// A superset of what a given world contains rather than a survey of one, since a region of the
    /// table small enough may have no position anywhere that lands in it. In the climate table's own
    /// order, which is what the feature sorter breaks its ties by.
    /// </remarks>
    public IReadOnlyList<Identifier> PossibleBiomes => _biomeSource.PossibleBiomes;

    /// <summary>Whether the structure pass runs.</summary>
    public bool HasStructures => _structures is not null;

    /// <summary>The structure pass, or null when it is off.</summary>
    /// <remarks>
    /// What a consumer looking for a structure needs beyond <see cref="StructureStartsAt"/>: the sets
    /// and their placements say which chunks are worth asking about at all, and the pass is itself the
    /// <see cref="IStructurePlacementState"/> those placements are answered against.
    /// </remarks>
    public StructureSystem? StructurePass => _structures;

    /// <summary>
    /// Every structure that starts in one chunk, which is the question a search for a structure asks.
    /// </summary>
    /// <remarks>
    /// The y range is the noise settings' own rather than a world's, because a caller looking for a
    /// structure has no chunk in hand to take one from. For every vanilla preset the two are the same:
    /// a dimension is as deep as the noise settings written for it.
    /// <p/>
    /// Answers off the same cache the pass fills, so a search followed by generating what it found
    /// builds each start once.
    /// </remarks>
    public IReadOnlyList<StructureStart> StructureStartsAt(int chunkX, int chunkZ) {
        NoiseSettings noise = _settings.NoiseSettings;

        return _structures?.StartsAt(chunkX, chunkZ, ContextFactory(noise.MinY, noise.Height)) ?? [];
    }

    /// <summary>
    /// <c>NoiseBasedChunkGenerator.getBaseHeight</c>: one past the highest block of a column that
    /// matches the heightmap, worked out from the noise alone.
    /// </summary>
    /// <remarks>
    /// A structure asks this about columns up to eight chunks away, which is why it cannot come off a
    /// heightmap. The beardifier is left out, as vanilla's is: the height a structure is placed at must
    /// not depend on the terrain adjustment that structure is about to ask for.
    /// </remarks>
    public int GetBaseHeight(int blockX, int blockZ, HeightmapType type, int minY, int height) {
        return IterateNoiseColumn(blockX, blockZ, minY, height, null, state => MatchesHeightmap(type, state)) ?? minY;
    }

    /// <summary>
    /// <c>NoiseBasedChunkGenerator.getBaseColumn</c>: a whole column of states worked out from the
    /// noise, before the surface pass, for a structure that has to look at what is in a column.
    /// </summary>
    public uint[] GetBaseColumn(int blockX, int blockZ, int minY, int height) {
        NoiseSettings noiseSettings = _settings.NoiseSettings.ClampToWorld(minY, height);
        uint[] column = new uint[Math.Max(0, noiseSettings.Height)];
        IterateNoiseColumn(blockX, blockZ, minY, height, column, null);
        return column;
    }

    /// <summary>
    /// <c>iterateNoiseColumn</c>: the column as one 1 by height by 1 volume sample, walked top down.
    /// A null state is the settings' default block, not air.
    /// </summary>
    private int? IterateNoiseColumn(int blockX, int blockZ, int minY, int height, uint[]? writeTo, Func<uint, bool>? tester) {
        NoiseSettings noiseSettings = _settings.NoiseSettings.ClampToWorld(minY, height);
        if (noiseSettings.Height <= 0) {
            return null;
        }

        DensityVolume volume = new(1, noiseSettings.Height, 1, blockX, noiseSettings.MinY, blockZ);
        using NoiseChunk noiseChunk = new(_randomState, null, _settings, _globalFluidPicker, volume);
        IAquifer aquifer = noiseChunk.Aquifer;
        BoundSampler finalDensity = noiseChunk.CachingSamplers.Get(_settings.NoiseRouter.FinalDensity);
        using ScopedDensityBuffer densityBuffer = finalDensity.SampleVolume(volume);
        for (int y = volume.SizeY - 1; y >= 0; y--) {
            float density = densityBuffer[volume.IndexUnchecked(0, y, 0)];
            int blockY = volume.BlockY(y);
            uint state = aquifer.ComputeSubstance(blockX, blockY, blockZ, density) ?? _settings.DefaultBlock;
            if (writeTo != null) {
                writeTo[y] = state;
            }

            if (tester != null && tester(state)) {
                return blockY + 1;
            }
        }

        return null;
    }

    /// <summary>
    /// The two heightmap predicates a structure ever asks for, as <c>Heightmap.Types.isOpaque</c>
    /// resolves them.
    /// </summary>
    private bool MatchesHeightmap(HeightmapType type, uint state) {
        return type switch {
            HeightmapType.OceanFloorWorldgen or HeightmapType.OceanFloor =>
                FeatureBlockData.For(_registry).BlocksMotionInHeightmapAt(state),
            _ => !FeatureBlockData.For(_registry).IsAir(state)
        };
    }

    /// <summary>Wraps this generator into a provider a world can be given.</summary>
    public GeneratorTerrainProvider AsProvider() {
        return new GeneratorTerrainProvider(this, _registry);
    }

    public void Generate(IGenerationUnit unit) {
        int chunkX = unit.AbsoluteStart.X >> 4;
        int chunkZ = unit.AbsoluteStart.Z >> 4;
        int minY = unit.MinY;
        int maxY = unit.MaxY;

        BiomeLookup biomes = new(this, minY, maxY);
        ChunkColumn column = new(minY, maxY, _airState);

        try {
            // Before the terrain, as vanilla's chunk status order has it: BIOMES runs ahead of the
            // terrain, and the climate search's warm start makes the grid depend on query order.
            FillBiomes(unit, chunkX, chunkZ);

            // A neighbour that decorated first has already computed this chunk's terrain, in which case
            // it is put back rather than built again. Either way the snapshot is taken before
            // decoration, since that is the state this chunk's own neighbours have to read.
            if (_terrain.TryGet(new Vec2<int>(chunkX, chunkZ), out TerrainSnapshot kept)) {
                kept.RestoreInto(column);
            } else {
                BuildTerrain(column, biomes, chunkX, chunkZ, minY, maxY);
                _terrain.Add(new Vec2<int>(chunkX, chunkZ), TerrainSnapshot.Of(column, minY, maxY - minY, _airState));
            }

            // After the snapshot and before the decoration, which is exactly where a neighbour's write
            // reaches a chunk upstream. It is deliberately not in the snapshot, which is this chunk's
            // own terrain and nothing else.
            unit.ReadForkedWrites((x, y, z, state) => column.Write(x & 15, y, z & 15, state));

            _features?.Decorate(unit, column, biomes.GetBiomeAtBlock,
                BiomesAround(chunkX, chunkZ, unit.MinY, unit.MaxY), _settings.SeaLevel,
                NeighbourTerrain(minY, maxY), StructureHook(unit, chunkX, chunkZ),
                biomes.GetBiomeAtQuart);

            Commit(unit, column);
        } finally {
            // Even on a throwing rule, so a bad one costs a chunk rather than the pooled buffer for
            // the rest of the run.
            column.Release();
        }
    }

    /// <summary>
    /// The terrain of a chunk as the carvers left it, computing it if nothing has yet.
    /// </summary>
    /// <remarks>
    /// Only reached for a neighbour: the chunk being generated builds its terrain into the column it
    /// is about to decorate, rather than into one of its own and back out again.
    /// </remarks>
    private TerrainSnapshot TerrainOf(int chunkX, int chunkZ, int minY, int maxY) {
        return _terrain.GetOrBuild(new Vec2<int>(chunkX, chunkZ), () => {
            BiomeLookup biomes = new(this, minY, maxY);
            ChunkColumn column = new(minY, maxY, _airState);

            try {
                BuildTerrain(column, biomes, chunkX, chunkZ, minY, maxY);
                return TerrainSnapshot.Of(column, minY, maxY - minY, _airState);
            } finally {
                column.Release();
            }
        });
    }

    /// <summary>
    /// What a feature reads when it looks into a neighbouring chunk, or null outside the three by
    /// three the pass is allowed to reach.
    /// </summary>
    private NeighbourTerrain NeighbourTerrain(int minY, int maxY) {
        return (chunkX, chunkZ) => TerrainOf(chunkX, chunkZ, minY, maxY);
    }

    /// <summary>
    /// <c>buildTerrain</c>: the fill, the surface pass and the carvers, over one noise chunk.
    /// </summary>
    private void BuildTerrain(ChunkColumn column, BiomeLookup biomes, int chunkX, int chunkZ, int minY, int maxY) {
        RunTerrainPasses(column, biomes, chunkX, chunkZ, minY, maxY, null);
    }

    /// <summary>The three passes, with a hook after each for <see cref="TerrainStages"/>.</summary>
    private void RunTerrainPasses(ChunkColumn column, BiomeLookup biomes, int chunkX, int chunkZ, int minY, int maxY,
        Action<int>? afterPass) {

        NoiseSettings noiseSettings = _settings.NoiseSettings.ClampToWorld(minY, maxY - minY);
        if (noiseSettings.Height <= 0) {
            return;
        }

        DensityVolume volume = new(16, noiseSettings.Height, 16, chunkX << 4, noiseSettings.MinY, chunkZ << 4);
        using NoiseChunk noiseChunk = new(_randomState, BeardifierFor(minY, maxY, chunkX, chunkZ), _settings, _globalFluidPicker, volume);

        DoFill(noiseChunk, column);
        afterPass?.Invoke(0);

        GenerationHeightContext heightContext = HeightContext(minY, maxY);
        _randomState.MaterialSystem.BuildSurface(_randomState, column, noiseChunk.CachingSamplers, volume,
            column.HighestFilledSectionTopY(), _settings.MaterialRule, biomes.GetBiomeAtBlock,
            BiomesAround(chunkX, chunkZ, minY, maxY), heightContext, chunkX, chunkZ, minY, maxY - 1);
        afterPass?.Invoke(1);

        Carve(column, noiseChunk, chunkX, chunkZ, minY, maxY);
        afterPass?.Invoke(2);
    }

    /// <summary>
    /// <c>WorldGenerationContext</c>: the smaller of the world's range and the generator's.
    /// </summary>
    private GenerationHeightContext HeightContext(int minY, int maxY) {
        int minGenY = Math.Max(minY, _settings.NoiseSettings.MinY);
        int genDepth = Math.Min(maxY - minY, _settings.NoiseSettings.Height);
        return new GenerationHeightContext(minGenY, genDepth, _settings.SeaLevel);
    }

    /// <summary>
    /// The noise pass, vanilla's <c>doFill</c>: the final density as one volume over the chunk, then
    /// z, x and y from the top down through the aquifer.
    /// </summary>
    private void DoFill(NoiseChunk noiseChunk, ChunkColumn column) {
        IAquifer aquifer = noiseChunk.Aquifer;
        DensityVolume volume = noiseChunk.Volume;
        BoundSampler finalDensity = noiseChunk.CachingSamplers.Get(_settings.NoiseRouter.FinalDensity);
        using ScopedDensityBuffer densityBuffer = finalDensity.SampleVolume(volume);

        for (int z = 0; z < volume.SizeZ; z++) {
            int blockZ = volume.BlockZ(z);
            for (int x = 0; x < volume.SizeX; x++) {
                int blockX = volume.BlockX(x);
                for (int y = volume.SizeY - 1; y >= 0; y--) {
                    int blockY = volume.BlockY(y);
                    float density = densityBuffer[volume.IndexUnchecked(x, y, z)];
                    uint state = aquifer.ComputeSubstance(blockX, blockY, blockZ, density) ?? _settings.DefaultBlock;
                    if (state != _airState) {
                        column.Write(x, blockY, z, state);
                    }
                }
            }
        }
    }

    /// <summary>
    /// The carving pass, when one is asked for.
    /// </summary>
    /// <remarks>
    /// A source chunk's biome, which decides which carvers start there, is an uncached point sample at
    /// its minimum corner, and so is the biome the exposed dirt fix-up reads through the zoom: vanilla
    /// hands the carvers <c>createUncachedResolver</c> for both, not the stored grid.
    /// </remarks>
    private void Carve(ChunkColumn column, NoiseChunk noiseChunk, int chunkX, int chunkZ, int minY, int maxY) {
        if (_carvers is null) {
            return;
        }

        ClimateSampler uncached = _randomState.UncachedClimateSampler();
        BiomeZoom.Resolver zoom = _biomeZoom.NewResolver();
        Func<int, int, int, IBiome> uncachedBiomeAt = (blockX, blockY, blockZ) => {
            (int quartX, int quartY, int quartZ) = zoom.Resolve(blockX, blockY, blockZ);
            return _registry.Biomes[_biomeSource.GetBiome(quartX, quartY, quartZ, uncached)];
        };
        GenerationHeightContext heightContext = HeightContext(minY, maxY);

        _carvers.Carve(column, noiseChunk.Aquifer, chunkX, chunkZ, heightContext,
            (sourceChunkX, sourceChunkZ) => _biomeSource.GetBiome(sourceChunkX << 2, 0, sourceChunkZ << 2, uncached),
            (blockX, blockY, blockZ, underFluid) => _randomState.MaterialSystem.TopMaterial(_settings.MaterialRule, _randomState,
                heightContext, uncachedBiomeAt, column, noiseChunk.CachingSamplers, blockX, blockY, blockZ, underFluid));
    }

    /// <summary>
    /// The terrain adjustment for a chunk, or null where nothing adjusts it.
    /// </summary>
    /// <remarks>
    /// This is the one thing the structure pass does <b>before</b> the noise rather than after it: a
    /// beard is a term in the terrain density, not a pass over blocks. That is only sound because a
    /// structure's own position never depends on it, which is what keeps <see cref="GetBaseHeight"/>
    /// at a flat zero.
    /// </remarks>
    private IDensitySampler? BeardifierFor(int minY, int maxY, int chunkX, int chunkZ) {
        if (_structures is null) {
            return null;
        }

        Beardifier beardifier = Beardifier.ForStructuresInChunk(
            _structures.StartsAdjustingTerrain(chunkX, chunkZ,
                ContextFactory(minY, maxY - minY)), chunkX, chunkZ);

        return ReferenceEquals(beardifier, Beardifier.Empty) ? null : beardifier;
    }

    /// <summary>
    /// Builds a generation context per source chunk, seeded from the world seed and that chunk.
    /// </summary>
    /// <remarks>
    /// So a start built while generating one chunk is the same start built while generating its
    /// neighbour, which is what makes the two halves of a structure across a border agree.
    /// </remarks>
    private StructureGenerationContext.Factory ContextFactory(int minY, int height) {
        return (sourceChunkX, sourceChunkZ) => {
            WorldgenRandom random = new(new LegacyRandomSource(0L));
            random.SetLargeFeatureSeed(Seed, sourceChunkX, sourceChunkZ);

            return new StructureGenerationContext(_registry,
                (blockX, blockZ, type) => GetBaseHeight(blockX, blockZ, type, minY, height),
                (blockX, blockZ) => GetBaseColumn(blockX, blockZ, minY, height),
                BiomeAt, random, Seed, sourceChunkX, sourceChunkZ, minY, height,
                _settings.SeaLevel);
        };
    }

    /// <summary>
    /// The structure half of the decoration loop, or null when the pass is off.
    /// </summary>
    /// <remarks>
    /// The writable area is the chunk over the world's whole height, vanilla's <c>getWritableArea</c>,
    /// and it starts one above the bottom so a structure cannot replace the void barrier. Every piece
    /// clips to it, which is what keeps the pass free of forks.
    /// </remarks>
    private FeatureSystem.StepHook? StructureHook(IGenerationUnit unit, int chunkX, int chunkZ) {
        if (_structures is null) {
            return null;
        }

        StructureSystem structures = _structures;

        BoundingBox writable = new(chunkX << 4, unit.MinY + 1, chunkZ << 4,
            (chunkX << 4) + 15, unit.MaxY, (chunkZ << 4) + 15);

        StructureGenerationContext.Factory factory = ContextFactory(unit.MinY, unit.MaxY - unit.MinY);

        return (step, level, features, random, decorationSeed) =>
            structures.PlaceStep((DecorationStep)step, level, features, random, decorationSeed,
                chunkX, chunkZ, writable, factory);
    }

    /// <summary>Hands the finished column buffer to the generation API, one column at a time.</summary>
    private static void Commit(IGenerationUnit unit, ChunkColumn column) {
        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                unit.Modifier.SetColumnStates(unit.AbsoluteStart.X + x, unit.AbsoluteStart.Z + z,
                    unit.MinY, column.Span(x, z));
            }
        }
    }

    /// <summary>
    /// Writes the biome grid: one entry per 4x4x4 cell, from the cell's own climate rather than
    /// through the zoomer.
    /// </summary>
    /// <remarks>
    /// The zoomer is a client and server side read of this grid, not something baked into it, so
    /// applying it here as well would wobble the biomes twice.
    /// <p/>
    /// <b>The loop order is <c>LevelChunkSection.fillBiomesFromNoise</c>'s</b>, section by section from
    /// the bottom and then x, y, z within one. It decides which of two regions an exactly tied climate
    /// resolves to, since the region tree search starts from the answer it last gave.
    /// </remarks>
    /// <summary>
    /// One chunk as each of the noise, surface and carver passes left it, which is what
    /// <c>Conformance/terrainstage.sh</c> compares against vanilla's own three.
    /// </summary>
    /// <remarks>
    /// <b>All three are pure functions of the world seed and the chunk position</b>, so this reads no
    /// neighbour's blocks, draws from no random shared with another chunk and does not care what order
    /// chunks were asked for. That is what lets the fixture be a pass rather than a baseline: the order
    /// dependence that stops whole-world parity reaching zero does not exist here, and a difference is
    /// the port.
    /// <p/>
    /// The carver pass replays every chunk within eight of this one, which looks like a dependence on
    /// them and is not: a source chunk's carvers are seeded from the world seed, the carver's index in
    /// that source chunk's biome's list and the source chunk position, and nothing about what has been
    /// generated there. <c>CarverPassTest</c> is the property.
    /// </remarks>
    public (uint[] Noise, uint[] Surface, uint[] Carved) TerrainStages(int chunkX, int chunkZ,
        int minY, int maxY) {

        if (_carvers is null) {
            throw new InvalidOperationException(
                "TerrainStages compares all three passes, so the generator needs WithCarvers().");
        }

        BiomeLookup biomes = new(this, minY, maxY);
        ChunkColumn column = new(minY, maxY, _airState);
        uint[][] captured = new uint[3][];

        try {
            RunTerrainPasses(column, biomes, chunkX, chunkZ, minY, maxY, pass => captured[pass] = Capture(column, minY, maxY));
            return (captured[0], captured[1], captured[2]);
        } finally {
            column.Release();
        }
    }

    /// <summary>Every block of a column, in the y then z then x order the fixture holds.</summary>
    private static uint[] Capture(ChunkColumn column, int minY, int maxY) {
        uint[] states = new uint[(maxY - minY) * 256];
        int at = 0;

        for (int y = minY; y < maxY; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    states[at++] = column.Read(x, y, z);
                }
            }
        }

        return states;
    }

    /// <summary>Writes a chunk's biome grid into the unit.</summary>
    private void FillBiomes(IGenerationUnit unit, int chunkX, int chunkZ) {
        ChunkBiomes grid = GridOf(chunkX, chunkZ, unit.MinY, unit.MaxY);
        int minQuartY = unit.MinY >> 2;
        int maxQuartY = unit.MaxY >> 2;
        for (int quartY = minQuartY; quartY < maxQuartY; quartY++) {
            for (int quartX = 0; quartX < 4; quartX++) {
                for (int quartZ = 0; quartZ < 4; quartZ++) {
                    unit.Modifier.SetBiome(new Vec3<int>((chunkX << 4) + (quartX << 2), quartY << 2, (chunkZ << 4) + (quartZ << 2)),
                        grid.Grid[GridIndex(quartY - minQuartY, quartX, quartZ)]);
                }
            }
        }
    }

    private static int GridIndex(int quartYInChunk, int quartX, int quartZ) => (quartYInChunk * 4 + quartX) * 4 + quartZ;

    /// <summary>
    /// Every biome in the three by three, which is both the set <c>applyBiomeDecoration</c> decorates
    /// from and the possible biomes the material rules fold their biome conditions against.
    /// </summary>
    private IReadOnlySet<Identifier> BiomesAround(int chunkX, int chunkZ, int minY, int maxY) {
        HashSet<Identifier> union = [];
        for (int dx = -1; dx <= 1; dx++) {
            for (int dz = -1; dz <= 1; dz++) {
                union.UnionWith(GridOf(chunkX + dx, chunkZ + dz, minY, maxY).Present);
            }
        }

        return union;
    }

    /// <summary>
    /// <c>ChunkGenerator.doCreateBiomes</c>: one chunk's biome grid, computed once however many of the
    /// nine around it ask.
    /// </summary>
    /// <remarks>
    /// The six climate functions are sampled as volumes over the chunk's quart grid through a fresh
    /// caching context, then the cells are resolved in <c>fillBiomesFromNoise</c>'s order, section by
    /// section from the bottom and then x, y, z within one, because the climate search starts from the
    /// answer it last gave and an exact tie goes to whichever region that order reached first.
    /// </remarks>
    private ChunkBiomes GridOf(int chunkX, int chunkZ, int minY, int maxY) {
        Vec2<int> chunk = new(chunkX, chunkZ);
        if (_biomeSets.TryGet(chunk, out ChunkBiomes cached)) {
            return cached;
        }

        int minQuartY = minY >> 2;
        int quartHeight = (maxY - minY) >> 2;
        IBiome[] grid = new IBiome[quartHeight * 16];
        HashSet<Identifier> present = [];

        DensityBufferPool pool = _randomState.AcquireDensityBufferPool();
        try {
            ClimateSampler sampler = _randomState.CreateClimateSampler(SamplerContext.CreateBuilder().EnableCaches().UseBufferArena(pool).Build());
            Func<int, int, int, Identifier> resolver = _biomeSource.ResolverForChunk(sampler, chunkX << 2, minQuartY, chunkZ << 2, 4, quartHeight, 4);

            for (int sectionQuartY = 0; sectionQuartY < quartHeight; sectionQuartY += 4) {
                for (int quartX = 0; quartX < 4; quartX++) {
                    for (int inSection = 0; inSection < 4; inSection++) {
                        int quartY = sectionQuartY + inSection;
                        for (int quartZ = 0; quartZ < 4; quartZ++) {
                            IBiome biome = _registry.Biomes[resolver((chunkX << 2) + quartX, minQuartY + quartY, (chunkZ << 2) + quartZ)];
                            grid[GridIndex(quartY, quartX, quartZ)] = biome;
                            present.Add(biome.Identifier);
                        }
                    }
                }
            }
        } finally {
            _randomState.ReleaseDensityBufferPool(pool);
        }

        ChunkBiomes built = new(grid, present);
        _biomeSets.Add(chunk, built);
        return built;
    }

    /// <summary>
    /// Where the world's fluid is before any aquifer, vanilla's <c>createFluidPicker</c>: lava below
    /// y -54 and the dimension's own fluid up to sea level.
    /// </summary>
    private sealed class GlobalFluidPicker(int seaLevel, uint defaultFluid) : IFluidPicker {
        private readonly FluidStatus _lava = new(LavaLevel, Block.Lava.StateId);
        private readonly FluidStatus _sea = new(seaLevel, defaultFluid);
        private readonly int _lavaThreshold = Math.Min(LavaLevel, seaLevel);

        public FluidStatus ComputeFluid(int blockX, int blockY, int blockZ) {
            return blockY < _lavaThreshold ? _lava : _sea;
        }
    }

    /// <summary>
    /// The stored biomes as a chunk's passes read them, <c>WorldGenRegion.getNoiseBiome</c> and
    /// <c>BiomeManager.getBiome</c>: a cell is read off the grid of the chunk it is in, with its y
    /// clamped into the world, and a block goes through the zoom first.
    /// </summary>
    /// <remarks>
    /// The zoom near a chunk edge reaches into the neighbour's grid, which is that neighbour's own
    /// volume sample, so a border reads the same from either side.
    /// </remarks>
    private sealed class BiomeLookup(VanillaTerrainGenerator generator, int minY, int maxY) {
        private readonly BiomeZoom.Resolver _resolver = generator._biomeZoom.NewResolver();
        private readonly int _minQuartY = minY >> 2;
        private readonly int _maxQuartY = (minY >> 2) + ((maxY - minY) >> 2) - 1;
        private Vec2<int> _lastChunk = new(int.MinValue, int.MinValue);
        private ChunkBiomes? _lastGrid;

        public IBiome GetBiomeAtQuart(int quartX, int quartY, int quartZ) {
            Vec2<int> chunk = new(quartX >> 2, quartZ >> 2);
            if (_lastGrid is null || chunk != _lastChunk) {
                _lastGrid = generator.GridOf(chunk.X, chunk.Y, minY, maxY);
                _lastChunk = chunk;
            }

            int clampedY = Math.Clamp(quartY, _minQuartY, _maxQuartY);
            return _lastGrid.Grid[GridIndex(clampedY - _minQuartY, quartX & 3, quartZ & 3)];
        }

        public IBiome GetBiomeAtBlock(int blockX, int blockY, int blockZ) {
            (int quartX, int quartY, int quartZ) = _resolver.Resolve(blockX, blockY, blockZ);
            return GetBiomeAtQuart(quartX, quartY, quartZ);
        }
    }
}
