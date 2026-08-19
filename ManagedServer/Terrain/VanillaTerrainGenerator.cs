using ManagedServer.Terrain.Biomes;
using ManagedServer.Terrain.Carvers;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures;
using ManagedServer.Terrain.Surface;
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
/// decide what fills the rest, the ore veins overwrite bands of it, the multi noise biome source
/// decides which biome each cell is, and the surface rules turn the top of the stone into ground.
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
/// <b>What this generates.</b> The noise terrain, the aquifers, the ore veins, the biomes and the
/// surface rules; when <see cref="WithCarvers"/> is asked for, the caves and ravines; when
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
        _randomState = new RandomState(_settings, data.NoiseParameters, seed);
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

    /// <summary>
    /// The nether. Its biome source needs vanilla's legacy nether noise, which is not ported, so the
    /// terrain is right and every biome comes out as the nether wastes.
    /// </summary>
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
    /// The biome at a quart position, from the climate alone.
    /// </summary>
    /// <remarks>
    /// The <b>flattened</b> sampler, so it answers for any position rather than only inside a chunk
    /// being generated: a <c>NoiseChunk</c>'s caches cover its own chunk and nothing else. That is what
    /// lets the stronghold ring search ask about columns thousands of blocks away.
    /// <p/>
    /// This is the grid the chunk stores, not what a player standing there is told: the client and the
    /// server both read that grid through <c>BiomeZoom</c>, which jitters the lookup so beaches have no
    /// visible four block steps.
    /// </remarks>
    public Identifier BiomeAt(int quartX, int quartY, int quartZ) {
        return _biomeSource.GetBiome(quartX, quartY, quartZ, _randomState.Sampler);
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
    /// heightmap: those chunks do not exist yet. It builds a <b>one cell wide</b> noise chunk and
    /// walks it down, which is the same arithmetic the full pass does for that column and costs about
    /// a two hundred and fifty sixth of a chunk.
    /// <p/>
    /// The beardifier is left at zero here, as vanilla's is: the height a structure is placed at must
    /// not depend on the terrain adjustment that structure is about to ask for.
    /// </remarks>
    public int GetBaseHeight(int blockX, int blockZ, HeightmapType type, int minY, int height) {
        NoiseSettings noiseSettings = _settings.NoiseSettings.ClampToWorld(minY, height);

        int cellWidth = noiseSettings.CellWidth;
        int cellHeight = noiseSettings.CellHeight;
        int cellCountY = Mth.FloorDiv(noiseSettings.Height, cellHeight);

        if (cellCountY <= 0) {
            return minY;
        }

        int cellMinY = Mth.FloorDiv(noiseSettings.MinY, cellHeight);
        int firstBlockX = Mth.FloorDiv(blockX, cellWidth) * cellWidth;
        int firstBlockZ = Mth.FloorDiv(blockZ, cellWidth) * cellWidth;
        double factorX = (double)Mth.FloorMod(blockX, cellWidth) / cellWidth;
        double factorZ = (double)Mth.FloorMod(blockZ, cellWidth) / cellWidth;

        NoiseChunk noiseChunk = new(1, _randomState, firstBlockX, firstBlockZ, noiseSettings,
            _settings, _globalFluidPicker);

        noiseChunk.InitializeForFirstCellX();
        noiseChunk.AdvanceCellX(0);

        try {
            for (int cellYIndex = cellCountY - 1; cellYIndex >= 0; cellYIndex--) {
                noiseChunk.SelectCellYZ(cellYIndex, 0);

                for (int yInCell = cellHeight - 1; yInCell >= 0; yInCell--) {
                    int posY = (cellMinY + cellYIndex) * cellHeight + yInCell;
                    noiseChunk.UpdateForY(posY, (double)yInCell / cellHeight);
                    noiseChunk.UpdateForX(blockX, factorX);
                    noiseChunk.UpdateForZ(blockZ, factorZ);

                    uint state = noiseChunk.GetInterpolatedState() ?? _settings.DefaultBlock;

                    if (MatchesHeightmap(type, state)) {
                        return posY + 1;
                    }
                }
            }
        } finally {
            noiseChunk.StopInterpolation();
        }

        return minY;
    }

    /// <summary>
    /// <c>NoiseBasedChunkGenerator.getBaseColumn</c>: a whole column of states worked out from the
    /// noise, for a structure that has to look at what is in a column rather than only how high it is.
    /// </summary>
    /// <remarks>
    /// A nether fossil walks it down looking for air sitting on something it can rest on and a ruined
    /// portal for a height with three of its four corners in solid ground, neither of which a heightmap
    /// answers. Built the same way as <see cref="GetBaseHeight"/> and
    /// with the same beardifier at zero, and the whole column is filled rather than stopping early,
    /// so the caller may walk it in either direction.
    /// </remarks>
    public uint[] GetBaseColumn(int blockX, int blockZ, int minY, int height) {
        NoiseSettings noiseSettings = _settings.NoiseSettings.ClampToWorld(minY, height);

        int cellWidth = noiseSettings.CellWidth;
        int cellHeight = noiseSettings.CellHeight;
        int cellCountY = Mth.FloorDiv(noiseSettings.Height, cellHeight);

        uint[] column = new uint[Math.Max(0, noiseSettings.Height)];

        if (cellCountY <= 0 || column.Length == 0) {
            return column;
        }

        int cellMinY = Mth.FloorDiv(noiseSettings.MinY, cellHeight);
        int firstBlockX = Mth.FloorDiv(blockX, cellWidth) * cellWidth;
        int firstBlockZ = Mth.FloorDiv(blockZ, cellWidth) * cellWidth;
        double factorX = (double)Mth.FloorMod(blockX, cellWidth) / cellWidth;
        double factorZ = (double)Mth.FloorMod(blockZ, cellWidth) / cellWidth;

        NoiseChunk noiseChunk = new(1, _randomState, firstBlockX, firstBlockZ, noiseSettings,
            _settings, _globalFluidPicker);

        noiseChunk.InitializeForFirstCellX();
        noiseChunk.AdvanceCellX(0);

        try {
            // Top down and in vanilla's own order, since this is the same walk getBaseHeight makes and
            // upstream is literally one method serving both.
            for (int cellYIndex = cellCountY - 1; cellYIndex >= 0; cellYIndex--) {
                noiseChunk.SelectCellYZ(cellYIndex, 0);

                for (int yInCell = cellHeight - 1; yInCell >= 0; yInCell--) {
                    int posY = (cellMinY + cellYIndex) * cellHeight + yInCell;
                    noiseChunk.UpdateForY(posY, (double)yInCell / cellHeight);
                    noiseChunk.UpdateForX(blockX, factorX);
                    noiseChunk.UpdateForZ(blockZ, factorZ);

                    int index = cellYIndex * cellHeight + yInCell;

                    if (index >= 0 && index < column.Length) {
                        // A null state is the settings' default block, not air: the rule answers null
                        // where it has no opinion, and the column a structure walks is the terrain
                        // before the surface pass rather than a hole. Reading it as air is a ruined
                        // portal that finds no solid ground anywhere and falls out at the world floor.
                        column[index] = noiseChunk.GetInterpolatedState() ?? _settings.DefaultBlock;
                    }
                }
            }
        } finally {
            noiseChunk.StopInterpolation();
        }

        return column;
    }

    /// <summary>
    /// The two heightmap predicates a structure ever asks for, as <c>Heightmap.Types.isOpaque</c>
    /// resolves them.
    /// </summary>
    private bool MatchesHeightmap(HeightmapType type, uint state) {
        return type switch {
            HeightmapType.OceanFloorWorldgen or HeightmapType.OceanFloor =>
                FeatureBlockData.For(_registry).BlocksMotionAt(state),
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

        NoiseChunk noiseChunk = NewNoiseChunk(chunkX, chunkZ, minY, maxY);

        // Cached per cell so the surface builder, which asks per block, does not re-run the biome
        // search for all sixty four positions of a cell. Off the noise chunk's own caches, which is
        // why the climate sampler is built from it rather than from the random state.
        BiomeCache biomes = new(_biomeSource, noiseChunk.CachedClimateSampler(_randomState.Router),
            _biomeZoom, _registry);

        ChunkColumn column = new(minY, maxY, _airState);

        try {
            // Before the terrain, as vanilla's chunk status order has it: BIOMES runs ahead of NOISE
            // and SURFACE, so the whole grid is decided first and the passes below read a grid that
            // already exists. That is an ordering constraint and not only a convenience, because the
            // region tree search starts from the answer it last gave: a target sitting inside two
            // regions at once is a tie, and a tie goes to whichever of the two the search reached
            // first, which is decided by the order the searches are made in.
            FillBiomes(unit, biomes, chunkX, chunkZ);

            // A neighbour that decorated first has already computed this chunk's terrain, in which case
            // it is put back rather than built again. Either way the snapshot is taken before
            // decoration, since that is the state this chunk's own neighbours have to read.
            if (_terrain.TryGet(new Vec2<int>(chunkX, chunkZ), out TerrainSnapshot kept)) {
                kept.RestoreInto(column);
            } else {
                BuildTerrain(column, noiseChunk, biomes, chunkX, chunkZ, minY, maxY);
                _terrain.Add(new Vec2<int>(chunkX, chunkZ),
                    TerrainSnapshot.Of(column, minY, maxY - minY, _airState));
            }

            // After the snapshot and before the decoration, which is exactly where a neighbour's write
            // reaches a chunk upstream: it is at the carvers step when the neighbour decorates. So the
            // features below read and overwrite what a neighbour put here, rather than the other way
            // round. It is deliberately not in the snapshot, which is this chunk's own terrain and
            // nothing else.
            unit.ReadForkedWrites((x, y, z, state) => column.Write(x & 15, y, z & 15, state));

            // After the terrain and before the commit, which is the only order that works: the
            // features read back what the surface wrote, and the column is what they read it from.
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
            NoiseChunk noiseChunk = NewNoiseChunk(chunkX, chunkZ, minY, maxY);
            BiomeCache biomes = new(_biomeSource,
                noiseChunk.CachedClimateSampler(_randomState.Router), _biomeZoom, _registry);

            ChunkColumn column = new(minY, maxY, _airState);

            try {
                PrimeBiomes(biomes, chunkX, chunkZ, minY, maxY, null);
                BuildTerrain(column, noiseChunk, biomes, chunkX, chunkZ, minY, maxY);
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

    /// <summary>The noise, surface and carver passes, which is a chunk's terrain and nothing else.</summary>
    private void BuildTerrain(ChunkColumn column, NoiseChunk noiseChunk, BiomeCache biomes, int chunkX,
        int chunkZ, int minY, int maxY) {

        // Clipped so a world shallower than the dimension the settings describe generates its own
        // range rather than reaching outside itself.
        NoiseSettings noiseSettings = _settings.NoiseSettings.ClampToWorld(minY, maxY - minY);

        int cellWidth = noiseSettings.CellWidth;
        int cellHeight = noiseSettings.CellHeight;
        int cellCountXz = 16 / cellWidth;
        int cellCountY = noiseSettings.Height / cellHeight;
        int cellMinY = Mth.FloorDiv(noiseSettings.MinY, cellHeight);

        FillFromNoise(noiseChunk, column, noiseSettings, chunkX, chunkZ, cellCountXz, cellCountY,
            cellMinY);

        _randomState.SurfaceSystem.BuildSurface(_registry, _randomState, column, noiseChunk,
            _settings.SurfaceRule, biomes.GetBiomeAtBlock, chunkX, chunkZ, minY, maxY - minY);

        // After the surface, as vanilla's chunk status order has it, because the fix-up a carve runs
        // over the dirt it exposes has nothing to read before the surface exists.
        Carve(column, noiseChunk, biomes, chunkX, chunkZ, minY, maxY);
    }

    /// <summary>
    /// A noise chunk for a chunk that is not being generated, for its climate sampler alone.
    /// </summary>
    /// <remarks>
    /// No beardifier, which is the expensive half: that one replays every structure start within eight
    /// chunks, and nothing about a biome depends on it.
    /// </remarks>
    private NoiseChunk ClimateChunk(int chunkX, int chunkZ, int minY, int maxY) {
        NoiseSettings noiseSettings = _settings.NoiseSettings.ClampToWorld(minY, maxY - minY);

        return new NoiseChunk(16 / noiseSettings.CellWidth, _randomState, chunkX << 4, chunkZ << 4,
            noiseSettings, _settings, _globalFluidPicker);
    }

    private NoiseChunk NewNoiseChunk(int chunkX, int chunkZ, int minY, int maxY) {
        NoiseSettings noiseSettings = _settings.NoiseSettings.ClampToWorld(minY, maxY - minY);

        return new NoiseChunk(16 / noiseSettings.CellWidth, _randomState, chunkX << 4, chunkZ << 4,
            noiseSettings, _settings, _globalFluidPicker,
            BeardifierFor(minY, maxY, chunkX, chunkZ));
    }

    /// <summary>
    /// The noise pass, vanilla's <c>doFill</c>.
    /// </summary>
    /// <remarks>
    /// The loop order is not free: the interpolator holds one column of cells at a time and the three
    /// <c>UpdateFor</c> calls are a staged lerp, so x has to be the outer loop with a slice swap at the
    /// end of it, and y, x, z has to be the order inside a cell.
    /// </remarks>
    private void FillFromNoise(NoiseChunk noiseChunk, ChunkColumn column, NoiseSettings noiseSettings,
        int chunkX, int chunkZ, int cellCountXz, int cellCountY, int cellMinY) {

        int cellWidth = noiseSettings.CellWidth;
        int cellHeight = noiseSettings.CellHeight;
        int chunkStartBlockX = chunkX << 4;
        int chunkStartBlockZ = chunkZ << 4;

        noiseChunk.InitializeForFirstCellX();

        for (int cellXIndex = 0; cellXIndex < cellCountXz; cellXIndex++) {
            noiseChunk.AdvanceCellX(cellXIndex);

            for (int cellZIndex = 0; cellZIndex < cellCountXz; cellZIndex++) {
                for (int cellYIndex = cellCountY - 1; cellYIndex >= 0; cellYIndex--) {
                    noiseChunk.SelectCellYZ(cellYIndex, cellZIndex);

                    for (int yInCell = cellHeight - 1; yInCell >= 0; yInCell--) {
                        int posY = (cellMinY + cellYIndex) * cellHeight + yInCell;
                        noiseChunk.UpdateForY(posY, (double)yInCell / cellHeight);

                        for (int xInCell = 0; xInCell < cellWidth; xInCell++) {
                            int posX = chunkStartBlockX + cellXIndex * cellWidth + xInCell;
                            noiseChunk.UpdateForX(posX, (double)xInCell / cellWidth);

                            for (int zInCell = 0; zInCell < cellWidth; zInCell++) {
                                int posZ = chunkStartBlockZ + cellZIndex * cellWidth + zInCell;
                                noiseChunk.UpdateForZ(posZ, (double)zInCell / cellWidth);

                                // Null means the aquifer and the ore veins both declined, which is the
                                // ordinary case for solid terrain.
                                uint state = noiseChunk.GetInterpolatedState() ?? _settings.DefaultBlock;
                                if (state == _airState) {
                                    continue;
                                }

                                column.Write(posX & 15, posY, posZ & 15, state);
                            }
                        }
                    }
                }
            }

            noiseChunk.SwapSlices();
        }

        noiseChunk.StopInterpolation();
    }

    /// <summary>
    /// The carving pass, when one is asked for.
    /// </summary>
    /// <remarks>
    /// The two lookups it needs are deliberately different samplers. A <b>source chunk's</b> biome
    /// decides which carvers start there and is up to eight chunks away, so it goes through the random
    /// state's flattened sampler: the noise chunk's caches only cover this chunk, and asking them about
    /// a position outside it is what they cannot answer. The <b>fix-up's</b> biome is inside this
    /// chunk, so it comes off the same cache the surface pass used.
    /// <p/>
    /// The surface rule is bound lazily, since most chunks carve nothing into a grass column and
    /// binding the whole overworld rule tree is not free.
    /// </remarks>
    private void Carve(ChunkColumn column, NoiseChunk noiseChunk, BiomeCache biomes,
        int chunkX, int chunkZ, int minY, int maxY) {

        if (_carvers is null) {
            return;
        }

        SurfaceContext? surfaceContext = null;
        ISurfaceRule? surfaceRule = null;

        _carvers.Carve(column, noiseChunk.Aquifer, chunkX, chunkZ, minY, maxY,
            (sourceChunkX, sourceChunkZ) =>
                _biomeSource.GetBiome(sourceChunkX << 2, 0, sourceChunkZ << 2, _randomState.Sampler),
            (blockX, blockY, blockZ, underFluid) => {
                if (surfaceRule is null) {
                    surfaceContext = new SurfaceContext(_randomState.SurfaceSystem, _randomState, column,
                        noiseChunk, biomes.GetBiomeAtBlock, minY, maxY - minY);
                    surfaceRule = _settings.SurfaceRule.Apply(surfaceContext);
                }

                return SurfaceSystem.TopMaterial(surfaceRule, surfaceContext!, blockX, blockY, blockZ,
                    underFluid);
            });
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
    private Beardifier? BeardifierFor(int minY, int maxY, int chunkX, int chunkZ) {
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

        NoiseChunk noiseChunk = NewNoiseChunk(chunkX, chunkZ, minY, maxY);

        BiomeCache biomes = new(_biomeSource, noiseChunk.CachedClimateSampler(_randomState.Router),
            _biomeZoom, _registry);

        ChunkColumn column = new(minY, maxY, _airState);

        try {
            PrimeBiomes(biomes, chunkX, chunkZ, minY, maxY, null);

            NoiseSettings noiseSettings = _settings.NoiseSettings.ClampToWorld(minY, maxY - minY);

            FillFromNoise(noiseChunk, column, noiseSettings, chunkX, chunkZ,
                16 / noiseSettings.CellWidth, noiseSettings.Height / noiseSettings.CellHeight,
                Mth.FloorDiv(noiseSettings.MinY, noiseSettings.CellHeight));

            uint[] noise = Capture(column, minY, maxY);

            _randomState.SurfaceSystem.BuildSurface(_registry, _randomState, column, noiseChunk,
                _settings.SurfaceRule, biomes.GetBiomeAtBlock, chunkX, chunkZ, minY, maxY - minY);

            uint[] surface = Capture(column, minY, maxY);

            Carve(column, noiseChunk, biomes, chunkX, chunkZ, minY, maxY);

            return (noise, surface, Capture(column, minY, maxY));
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

    private void FillBiomes(IGenerationUnit unit, BiomeCache biomes, int chunkX, int chunkZ) {
        PrimeBiomes(biomes, chunkX, chunkZ, unit.MinY, unit.MaxY, unit);
    }

    /// <summary>
    /// Fills a chunk's biome grid and puts every cell of it into the cache the passes below read.
    /// </summary>
    /// <remarks>
    /// <b>Before the noise pass, for the chunk being generated and for a neighbour alike.</b> The
    /// surface builder asks for a biome at every position of every column, and a cell it asks about
    /// first is a cell searched in the surface pass's order: the region tree search starts from the
    /// answer it last gave, so a tie resolves to whichever region that order reached first. Priming
    /// the whole grid first is what makes the answer the chunk's own rather than its reader's.
    /// </remarks>
    private void PrimeBiomes(BiomeCache biomes, int chunkX, int chunkZ, int minY, int maxY,
        IGenerationUnit? unit) {

        ChunkBiomes grid = GridOf(chunkX, chunkZ, minY, maxY, biomes);

        int minQuartY = minY >> 2;
        int maxQuartY = maxY >> 2;
        int at = 0;

        for (int sectionQuartY = minQuartY; sectionQuartY < maxQuartY; sectionQuartY += 4) {
            for (int quartX = 0; quartX < 4; quartX++) {
                for (int inSection = 0; inSection < 4; inSection++) {
                    int quartY = sectionQuartY + inSection;

                    for (int quartZ = 0; quartZ < 4; quartZ++) {
                        IBiome biome = grid.Grid[at++];

                        // Put back into this cache, since the grid may have been computed by a
                        // neighbour asking first. A cell this cache has not seen would be searched
                        // again from a different starting point.
                        biomes.Put((chunkX << 2) + quartX, quartY, (chunkZ << 2) + quartZ, biome);

                        unit?.Modifier.SetBiome(new Vec3<int>((chunkX << 4) + (quartX << 2), quartY << 2,
                            (chunkZ << 4) + (quartZ << 2)), biome);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Every biome in the three by three, which is the set <c>applyBiomeDecoration</c> decorates from.
    /// </summary>
    /// <remarks>
    /// A neighbour that has not generated is filled here rather than being left out, since leaving it
    /// out is the difference showing up as missing blocks in this chunk. It is a grid of climate
    /// searches and no terrain, and it goes through the <b>flattened sampler</b>: a
    /// <c>NoiseChunk</c>'s caches only cover its own chunk, which is the same reason the carver pass
    /// asks about a source chunk that way.
    /// </remarks>
    private IReadOnlySet<Identifier> BiomesAround(int chunkX, int chunkZ, int minY, int maxY) {
        HashSet<Identifier> union = [];

        for (int dx = -1; dx <= 1; dx++) {
            for (int dz = -1; dz <= 1; dz++) {
                union.UnionWith(GridOf(chunkX + dx, chunkZ + dz, minY, maxY, null).Present);
            }
        }

        return union;
    }

    /// <summary>
    /// One chunk's biome grid, computed once however many of the nine ask for it.
    /// </summary>
    /// <remarks>
    /// The walk is <c>LevelChunkSection.fillBiomesFromNoise</c>'s, section by section from the bottom
    /// and then x, y, z within one, because that order decides which of two regions an exactly tied
    /// climate resolves to. A chunk generating passes its own cache so the answers land there; a
    /// neighbour asked about gets a fresh one over the <b>flattened sampler</b>, since a
    /// <c>NoiseChunk</c>'s caches only cover its own chunk. Both walks are a fresh cache over the same
    /// order, so the two agree.
    /// </remarks>
    private ChunkBiomes GridOf(int chunkX, int chunkZ, int minY, int maxY, BiomeCache? own) {
        Vec2<int> chunk = new(chunkX, chunkZ);

        if (_biomeSets.TryGet(chunk, out ChunkBiomes cached)) {
            return cached;
        }

        // A neighbour gets a noise chunk of its own purely for the climate sampler. The flattened
        // sampler answers the same values and evaluates the five flat cached climate noises per cell
        // rather than per column, which over a grid of 1536 is most of the cost of a chunk.
        BiomeCache biomes = own ?? new BiomeCache(_biomeSource,
            ClimateChunk(chunkX, chunkZ, minY, maxY).CachedClimateSampler(_randomState.Router),
            _biomeZoom, _registry);

        int minQuartY = minY >> 2;
        int maxQuartY = maxY >> 2;

        IBiome[] grid = new IBiome[(maxQuartY - minQuartY) * 16];
        HashSet<Identifier> present = [];
        int at = 0;

        for (int sectionQuartY = minQuartY; sectionQuartY < maxQuartY; sectionQuartY += 4) {
            for (int quartX = 0; quartX < 4; quartX++) {
                for (int inSection = 0; inSection < 4; inSection++) {
                    for (int quartZ = 0; quartZ < 4; quartZ++) {
                        IBiome biome = biomes.GetBiomeAtQuart((chunkX << 2) + quartX,
                            sectionQuartY + inSection, (chunkZ << 2) + quartZ);

                        grid[at++] = biome;
                        present.Add(biome.Identifier);
                    }
                }
            }
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
    /// The biome of a cell, resolved once and reused for the sixty four block positions inside it.
    /// </summary>
    /// <remarks>
    /// <b>A cell that has been answered is never asked again, and that is correctness rather than
    /// speed.</b> The region tree search starts from the previous answer and uses it as its pruning
    /// bound, so a target sitting between two regions goes to whichever the search reached first: the
    /// same cell asked twice, with other queries in between, can come back as a different biome.
    /// Vanilla never runs into it because a chunk's grid is filled once and stored, and everything
    /// afterwards reads the stored container. <see cref="_kept"/> is that container.
    /// <p/>
    /// The R-tree search is also the most expensive thing in a chunk after the noise itself, and the
    /// surface builder asks for a biome at every position it considers, which is what the array in
    /// front of it is for.
    /// </remarks>
    private sealed class BiomeCache(MultiNoiseBiomeSource source, ClimateSampler sampler, BiomeZoom zoom,
        MinecraftRegistry registry) {

        // A chunk has 4x4 quart columns over its whole height, so a world 384 tall touches 1536 cells
        // in the biome pass alone and the surface pass reaches past them.
        private const int CacheSlots = 4096;

        /// <summary>
        /// Direct mapped rather than a dictionary. The surface builder asks tens of thousands of times
        /// per chunk and almost every one is a repeat, so the cost that matters is the hit, and a hit
        /// here is one index and three comparisons rather than hashing a three tuple.
        /// </summary>
        private readonly int[] _keys = new int[CacheSlots * 3];
        private readonly IBiome?[] _values = new IBiome[CacheSlots];

        /// <summary>
        /// Every cell this accessor has answered, which is what makes the answer a function of the
        /// position alone. The array above collides, and a collision there would otherwise mean
        /// searching the same cell a second time from a different starting point.
        /// </summary>
        private readonly Dictionary<(int, int, int), IBiome> _kept = [];

        private readonly BiomeZoom.Resolver _resolver = zoom.NewResolver();

        /// <summary>Records a cell answered elsewhere, so this cache never searches it again.</summary>
        public void Put(int quartX, int quartY, int quartZ, IBiome biome) {
            _kept[(quartX, quartY, quartZ)] = biome;
        }

        public IBiome GetBiomeAtQuart(int quartX, int quartY, int quartZ) {
            int slot = (int)((uint)(quartX * 0x9E3779B1 ^ quartY * 0x85EBCA6B ^ quartZ * -1028477387)
                % CacheSlots);
            int at = slot * 3;

            if (_values[slot] is { } cached && _keys[at] == quartX && _keys[at + 1] == quartY
                && _keys[at + 2] == quartZ) {

                return cached;
            }

            if (!_kept.TryGetValue((quartX, quartY, quartZ), out IBiome? biome)) {
                // The parameter table was filtered against this registry when it was built, so
                // anything that comes out of the search is present.
                biome = registry.Biomes[source.GetBiome(quartX, quartY, quartZ, sampler)];
                _kept[(quartX, quartY, quartZ)] = biome;
            }

            _keys[at] = quartX;
            _keys[at + 1] = quartY;
            _keys[at + 2] = quartZ;
            _values[slot] = biome;
            return biome;
        }

        /// <summary>The biome at a block, through the zoomer, which is what surface rules ask about.</summary>
        public IBiome GetBiomeAtBlock(int blockX, int blockY, int blockZ) {
            (int quartX, int quartY, int quartZ) = _resolver.Resolve(blockX, blockY, blockZ);
            return GetBiomeAtQuart(quartX, quartY, quartZ);
        }
    }
}
