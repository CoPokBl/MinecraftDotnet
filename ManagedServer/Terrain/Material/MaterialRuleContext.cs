using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Noise;
using Minecraft.Data.Biomes;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Material;

/// <summary>Density functions bound to one sampler context, vanilla's <c>DensitySamplerSet</c>.</summary>
public interface IDensitySamplerSet {
    BoundSampler Get(IDensityFunction function);

    float SampleValue(IDensityFunction function, int blockX, int blockY, int blockZ) => Get(function).SampleValue(blockX, blockY, blockZ);
}

/// <summary>Where a named noise and a named random factory come from, as the material rules see it.</summary>
public interface IMaterialRandomState {
    INoise GetOrCreateNoise(Identifier id);

    IPositionalRandomFactory GetOrCreateRandomFactory(Identifier name);
}

/// <summary>
/// The mutable state a compiled material rule reads, vanilla's <c>MaterialRuleContext</c>.
/// </summary>
/// <remarks>
/// One per chunk, walked column by column and down each column. The two counters are what make that
/// safe: a lazy condition compares the counter it last ran at against the current one, and every
/// move of the column also moves the y counter.
/// </remarks>
public sealed class MaterialRuleContext {
    private const int HowFarBelowPreliminarySurfaceLevelToBuildSurface = 8;

    private readonly MaterialSystem _system;
    private readonly IMaterialRandomState _randomState;
    private readonly DensityVolume _expectedVolume;
    private readonly IDensitySamplerSet _densitySamplers;
    private readonly Func<int, int, int, IBiome> _biomeGetter;
    private readonly GenerationHeightContext _heightContext;
    private readonly DensityVolume _preliminarySurfaceVolume;
    private DensityBuffer? _preliminarySurfaceBuffer;

    private readonly Dictionary<Identifier, Func<double>> _noiseSamplers2D = [];
    private readonly Dictionary<Identifier, Func<double>> _noiseSamplers3D = [];

    private long _lastSurfaceDepth2Update;
    private double _surfaceSecondary;
    private long _lastMinSurfaceLevelUpdate;
    private int _minSurfaceLevel;
    private IBiome? _biome;

    internal MaterialRuleContext(MaterialSystem system, IMaterialRandomState randomState, DensityVolume expectedVolume,
        IDensitySamplerSet densitySamplers, Func<int, int, int, IBiome> biomeGetter, GenerationHeightContext heightContext,
        IReadOnlySet<Identifier>? possibleBiomes) {

        _system = system;
        _randomState = randomState;
        _expectedVolume = expectedVolume;
        _densitySamplers = densitySamplers;
        _biomeGetter = biomeGetter;
        _heightContext = heightContext;
        PossibleBiomes = possibleBiomes;
        _preliminarySurfaceVolume = new DensityVolume(expectedVolume.SizeX, 1, expectedVolume.SizeZ, expectedVolume.MinBlockX, 0,
            expectedVolume.MinBlockZ);
        _lastSurfaceDepth2Update = LastUpdateXz - 1L;
        _lastMinSurfaceLevelUpdate = LastUpdateXz - 1L;
    }

    public long LastUpdateXz { get; private set; } = long.MinValue + 1;

    public long LastUpdateY { get; private set; } = long.MinValue + 1;

    public int BlockX { get; private set; }

    public int BlockY { get; private set; }

    public int BlockZ { get; private set; }

    public int SurfaceGradientX { get; private set; }

    public int SurfaceGradientZ { get; private set; }

    public int SurfaceDepth { get; private set; }

    public int WaterHeight { get; private set; }

    public int StoneDepthBelow { get; private set; }

    public int StoneDepthAbove { get; private set; }

    public IReadOnlySet<Identifier>? PossibleBiomes { get; }

    public int SeaLevel => _system.SeaLevel;

    internal void UpdateXz(int blockX, int blockZ, int surfaceGradientX, int surfaceGradientZ) {
        LastUpdateXz++;
        LastUpdateY++;
        BlockX = blockX;
        BlockZ = blockZ;
        SurfaceGradientX = surfaceGradientX;
        SurfaceGradientZ = surfaceGradientZ;
        SurfaceDepth = _system.GetSurfaceDepth(blockX, blockZ);
    }

    internal void UpdateY(int stoneDepthAbove, int stoneDepthBelow, int waterHeight, int blockY) {
        LastUpdateY++;
        _biome = null;
        BlockY = blockY;
        WaterHeight = waterHeight;
        StoneDepthBelow = stoneDepthBelow;
        StoneDepthAbove = stoneDepthAbove;
    }

    public double GetSurfaceSecondary() {
        if (_lastSurfaceDepth2Update != LastUpdateXz) {
            _lastSurfaceDepth2Update = LastUpdateXz;
            _surfaceSecondary = _system.GetSurfaceSecondary(BlockX, BlockZ);
        }

        return _surfaceSecondary;
    }

    public IBiome GetBiome() => _biome ??= _biomeGetter(BlockX, BlockY, BlockZ);

    /// <summary>
    /// The preliminary surface level less eight and plus the surface depth. Read from one 16 by 1 by 16
    /// volume sample of <c>chunk_surface_level</c>, so it is the volume path's interpolation, and from a
    /// point sample only outside that volume.
    /// </summary>
    public int GetMinSurfaceLevel() {
        if (_lastMinSurfaceLevelUpdate != LastUpdateXz) {
            _lastMinSurfaceLevelUpdate = LastUpdateXz;
            int index = _preliminarySurfaceVolume.IndexOfBlock(BlockX, 0, BlockZ);
            float preliminarySurfaceLevel;
            if (index != DensityVolume.NoBlock) {
                if (_preliminarySurfaceBuffer == null) {
                    _preliminarySurfaceBuffer = DensityBuffer.CreateUnpooled(_preliminarySurfaceVolume.Size);
                    _densitySamplers.Get(_system.PreliminarySurfaceFunction).SampleVolume(_preliminarySurfaceBuffer, _preliminarySurfaceVolume);
                }

                preliminarySurfaceLevel = _preliminarySurfaceBuffer[index];
            } else {
                preliminarySurfaceLevel = _densitySamplers.SampleValue(_system.PreliminarySurfaceFunction, BlockX, 0, BlockZ);
            }

            _minSurfaceLevel = Mth.Floor(preliminarySurfaceLevel) + SurfaceDepth - HowFarBelowPreliminarySurfaceLevelToBuildSurface;
        }

        return _minSurfaceLevel;
    }

    /// <summary>A noise sampled once per column in two dimensions, or once per position in three, widened from float.</summary>
    public Func<double> GetNoiseSampler(Identifier noiseId, bool is3D) {
        Dictionary<Identifier, Func<double>> samplers = is3D ? _noiseSamplers3D : _noiseSamplers2D;
        if (samplers.TryGetValue(noiseId, out Func<double>? existing)) {
            return existing;
        }

        INoise noise = _randomState.GetOrCreateNoise(noiseId);
        long lastUpdate = (is3D ? LastUpdateY : LastUpdateXz) - 1L;
        double lastNoise = 0.0;
        Func<double> sampler = is3D
            ? () => {
                if (lastUpdate != LastUpdateY) {
                    lastNoise = noise.Get(BlockX, BlockY, BlockZ);
                    lastUpdate = LastUpdateY;
                }

                return lastNoise;
            }
            : () => {
                if (lastUpdate != LastUpdateXz) {
                    lastNoise = noise.Get(BlockX, 0.0, BlockZ);
                    lastUpdate = LastUpdateXz;
                }

                return lastNoise;
            };

        samplers[noiseId] = sampler;
        return sampler;
    }

    public IPositionalRandomFactory GetOrCreateRandomFactory(Identifier name) => _randomState.GetOrCreateRandomFactory(name);

    /// <summary>
    /// A density function at the current position. Prefilled, it is one volume sample over the chunk
    /// up to its highest filled section, read back wherever the position lies on it.
    /// </summary>
    public Func<float> GetDensitiesInChunk(IDensityFunction function, bool prefill) {
        BoundSampler sampler = _densitySamplers.Get(function);
        if (!prefill) {
            return () => sampler.SampleValue(BlockX, BlockY, BlockZ);
        }

        DensityBuffer buffer = DensityBuffer.CreateUnpooled(_expectedVolume.Size);
        sampler.SampleVolume(buffer, _expectedVolume);
        DensityVolume volume = _expectedVolume;
        return () => {
            int index = volume.IndexOfBlock(BlockX, BlockY, BlockZ);
            return index == DensityVolume.NoBlock ? sampler.SampleValue(BlockX, BlockY, BlockZ) : buffer[index];
        };
    }

    public int ResolveAnchorY(VerticalAnchor anchor) => anchor.ResolveY(_heightContext);

    public uint GetBand(int x, int y, int z) => _system.GetBand(x, y, z);

    /// <summary>A condition recomputed when the column moves, vanilla's <c>LazyXZCondition</c>.</summary>
    public abstract class LazyXzCondition : IConditionEvaluator {
        protected readonly MaterialRuleContext Context;
        private long _lastUpdate;
        private bool _result;

        protected LazyXzCondition(MaterialRuleContext context) {
            Context = context;
            _lastUpdate = context.LastUpdateXz - 1L;
        }

        public bool Test() {
            long update = Context.LastUpdateXz;
            if (update != _lastUpdate) {
                _lastUpdate = update;
                _result = Compute();
            }

            return _result;
        }

        protected abstract bool Compute();
    }

    /// <summary>A condition recomputed when the position moves, vanilla's <c>LazyYCondition</c>.</summary>
    public abstract class LazyYCondition : IConditionEvaluator {
        protected readonly MaterialRuleContext Context;
        private long _lastUpdate;
        private bool _result;

        protected LazyYCondition(MaterialRuleContext context) {
            Context = context;
            _lastUpdate = context.LastUpdateY - 1L;
        }

        public bool Test() {
            long update = Context.LastUpdateY;
            if (update != _lastUpdate) {
                _lastUpdate = update;
                _result = Compute();
            }

            return _result;
        }

        protected abstract bool Compute();
    }
}
