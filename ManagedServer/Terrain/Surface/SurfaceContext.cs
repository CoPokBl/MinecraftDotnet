using ManagedServer.Terrain.Noise;
using Minecraft.Data.Biomes;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Surface;

/// <summary>
/// The column a surface rule is being applied to, and the chunk under it.
/// </summary>
/// <remarks>
/// An interface rather than the chunk itself because the surface builder is the only part of terrain
/// generation that <b>reads back</b> what it has written, and the generation API writes into a staging
/// buffer rather than into the chunk. <c>GetGenerationHeight</c> is the heightmap vanilla calls
/// <c>WORLD_SURFACE_WG</c>: the top of the terrain before the surface is built.
/// </remarks>
public interface ISurfaceColumn {
    /// <summary>The state at a height in the current column.</summary>
    uint GetBlock(int blockY);

    /// <summary>Writes a state at a height in the current column, ignoring anything outside the world.</summary>
    void SetBlock(int blockY, uint stateId);

    /// <summary>Points the column at a horizontal position, which the block accessors then work in.</summary>
    void SetColumn(int blockX, int blockZ);

    /// <summary>One above the highest non air block of a chunk local column, vanilla's <c>WORLD_SURFACE_WG</c>.</summary>
    int GetGenerationHeight(int localX, int localZ);
}

/// <summary>
/// Where a named noise and a named random factory come from, vanilla's <c>RandomState</c> as the
/// surface rules see it.
/// </summary>
public interface ISurfaceRandomState {
    NormalNoise GetOrCreateNoise(Identifier id);

    IPositionalRandomFactory GetOrCreateRandomFactory(Identifier name);
}

/// <summary>
/// The mutable state a bound surface rule reads, vanilla's <c>SurfaceRules.Context</c>.
/// </summary>
/// <remarks>
/// One per chunk, walked column by column and then down each column, so almost every field here is
/// overwritten thousands of times. The two counters are what make that safe: a lazy condition compares
/// the counter it last ran at against the current one, so nothing has to remember which of these
/// fields it read.
/// </remarks>
public sealed class SurfaceContext {
    /// <summary>How far below the estimated surface the rules still apply, vanilla's constant.</summary>
    private const int HowFarBelowPreliminarySurfaceToBuild = 8;

    private readonly Func<int, int, int, IBiome> _biomeGetter;

    private long _lastPreliminarySurfaceCellOrigin = long.MaxValue;
    private readonly int[] _preliminarySurfaceCache = new int[4];

    private readonly Dictionary<Identifier, Func<double>> _noiseSamplers2D = [];
    private readonly Dictionary<Identifier, Func<double>> _noiseSamplers3D = [];

    private long _lastSurfaceSecondaryUpdate = long.MinValue;
    private double _surfaceSecondary;

    private long _lastMinSurfaceLevelUpdate = long.MinValue;
    private int _minSurfaceLevel;

    private IBiome? _biome;

    public SurfaceContext(SurfaceSystem system, ISurfaceRandomState randomState, ISurfaceColumn column,
        INoiseChunkSurfaceView noiseChunk, Func<int, int, int, IBiome> biomeGetter, int minGenY, int genDepth) {

        System = system;
        RandomState = randomState;
        Column = column;
        NoiseChunk = noiseChunk;
        _biomeGetter = biomeGetter;
        MinGenY = minGenY;
        GenDepth = genDepth;

        Temperature = SurfaceRules.MakeTemperature(this);
        Steep = SurfaceRules.MakeSteep(this);
        Hole = SurfaceRules.MakeHole(this);
        AbovePreliminarySurface = SurfaceRules.MakeAbovePreliminarySurface(this);
    }

    public SurfaceSystem System { get; }
    public ISurfaceRandomState RandomState { get; }
    public ISurfaceColumn Column { get; }
    public INoiseChunkSurfaceView NoiseChunk { get; }

    public int MinGenY { get; }
    public int GenDepth { get; }

    internal ISurfaceCondition Temperature { get; }
    internal ISurfaceCondition Steep { get; }
    internal ISurfaceCondition Hole { get; }
    internal ISurfaceCondition AbovePreliminarySurface { get; }

    /// <summary>Bumped by <see cref="UpdateXz"/>, which is what invalidates the per column caches.</summary>
    public long LastUpdateXz { get; private set; }

    /// <summary>Bumped by both updates, since moving column also moves the position within one.</summary>
    public long LastUpdateY { get; private set; }

    public int BlockX { get; private set; }
    public int BlockZ { get; private set; }
    public int BlockY { get; private set; }

    /// <summary>How thick the soil layer is here, from <see cref="SurfaceSystem.GetSurfaceDepth"/>.</summary>
    public int SurfaceDepth { get; private set; }

    /// <summary>One above the topmost fluid in this column, or <see cref="int.MinValue"/> for none.</summary>
    public int WaterHeight { get; private set; }

    /// <summary>Blocks of stone above this position before the nearest cavity.</summary>
    public int StoneDepthAbove { get; private set; }

    /// <summary>Blocks of stone below this position before the nearest cavity.</summary>
    public int StoneDepthBelow { get; private set; }

    public void UpdateXz(int blockX, int blockZ) {
        LastUpdateXz++;
        LastUpdateY++;
        BlockX = blockX;
        BlockZ = blockZ;
        SurfaceDepth = System.GetSurfaceDepth(blockX, blockZ);
    }

    public void UpdateY(int stoneDepthAbove, int stoneDepthBelow, int waterHeight, int blockY) {
        LastUpdateY++;
        _biome = null;
        BlockY = blockY;
        WaterHeight = waterHeight;
        StoneDepthBelow = stoneDepthBelow;
        StoneDepthAbove = stoneDepthAbove;
    }

    public IBiome GetBiome() {
        return _biome ??= _biomeGetter(BlockX, BlockY, BlockZ);
    }

    public double GetSurfaceSecondary() {
        if (_lastSurfaceSecondaryUpdate != LastUpdateXz) {
            _lastSurfaceSecondaryUpdate = LastUpdateXz;
            _surfaceSecondary = System.GetSurfaceSecondary(BlockX, BlockZ);
        }

        return _surfaceSecondary;
    }

    /// <summary>
    /// The lowest height the surface rules still run at, estimated from the density function rather
    /// than from the terrain that was written.
    /// </summary>
    /// <remarks>
    /// Sampled at the four corners of a sixteen block cell and interpolated, not per position: the
    /// estimate walks a whole column of density per sample, so doing it per block would cost more than
    /// building the surface. The cell is <b>not</b> the chunk, so the four corners are shared between
    /// neighbouring columns and cached across them.
    /// </remarks>
    public int GetMinSurfaceLevel() {
        if (_lastMinSurfaceLevelUpdate == LastUpdateXz) {
            return _minSurfaceLevel;
        }

        _lastMinSurfaceLevelUpdate = LastUpdateXz;

        int cornerCellX = BlockX >> 4;
        int cornerCellZ = BlockZ >> 4;
        long cellOrigin = ((long)cornerCellX << 32) | (uint)cornerCellZ;

        if (_lastPreliminarySurfaceCellOrigin != cellOrigin) {
            _lastPreliminarySurfaceCellOrigin = cellOrigin;
            _preliminarySurfaceCache[0] = NoiseChunk.PreliminarySurfaceLevel(cornerCellX << 4, cornerCellZ << 4);
            _preliminarySurfaceCache[1] = NoiseChunk.PreliminarySurfaceLevel((cornerCellX + 1) << 4, cornerCellZ << 4);
            _preliminarySurfaceCache[2] = NoiseChunk.PreliminarySurfaceLevel(cornerCellX << 4, (cornerCellZ + 1) << 4);
            _preliminarySurfaceCache[3] = NoiseChunk.PreliminarySurfaceLevel((cornerCellX + 1) << 4, (cornerCellZ + 1) << 4);
        }

        int preliminarySurfaceLevel = Mth.Floor(Mth.Lerp2((BlockX & 15) / 16.0f, (BlockZ & 15) / 16.0f,
            _preliminarySurfaceCache[0], _preliminarySurfaceCache[1],
            _preliminarySurfaceCache[2], _preliminarySurfaceCache[3]));

        _minSurfaceLevel = preliminarySurfaceLevel + SurfaceDepth - HowFarBelowPreliminarySurfaceToBuild;
        return _minSurfaceLevel;
    }

    /// <summary>
    /// A sampler for a named noise, cached per name and holding its last value until the column or
    /// the position in it moves.
    /// </summary>
    public Func<double> GetNoiseSampler(Identifier noiseId, bool is3D) {
        Dictionary<Identifier, Func<double>> samplers = is3D ? _noiseSamplers3D : _noiseSamplers2D;
        if (samplers.TryGetValue(noiseId, out Func<double>? sampler)) {
            return sampler;
        }

        sampler = is3D ? CreateSampler3D(noiseId) : CreateSampler2D(noiseId);
        samplers[noiseId] = sampler;
        return sampler;
    }

    private Func<double> CreateSampler2D(Identifier noiseId) {
        NormalNoise noise = RandomState.GetOrCreateNoise(noiseId);
        long lastUpdate = long.MinValue;
        double lastNoise = 0.0;

        return () => {
            if (lastUpdate != LastUpdateXz) {
                lastNoise = noise.GetValue(BlockX, 0.0, BlockZ);
                lastUpdate = LastUpdateXz;
            }

            return lastNoise;
        };
    }

    private Func<double> CreateSampler3D(Identifier noiseId) {
        NormalNoise noise = RandomState.GetOrCreateNoise(noiseId);
        long lastUpdate = long.MinValue;
        double lastNoise = 0.0;

        return () => {
            if (lastUpdate != LastUpdateY) {
                lastNoise = noise.GetValue(BlockX, BlockY, BlockZ);
                lastUpdate = LastUpdateY;
            }

            return lastNoise;
        };
    }
}
