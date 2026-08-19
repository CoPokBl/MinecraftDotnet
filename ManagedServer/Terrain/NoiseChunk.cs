using ManagedServer.Terrain.Biomes;
using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Surface;
using Minecraft.Schemas;

namespace ManagedServer.Terrain;

/// <summary>
/// One chunk's worth of density sampling, vanilla's <c>NoiseChunk</c>.
/// </summary>
/// <remarks>
/// Terrain noise is not evaluated per block. It is evaluated at the corners of <b>cells</b> (4 by 8 by
/// 4 for the overworld) and trilinearly interpolated between them, which is what makes generation
/// affordable and what gives vanilla terrain its characteristic smoothness at that scale.
/// <p/>
/// This class is three things at once, as upstream: the <see cref="IFunctionContext"/> the density
/// functions read their position from, the <see cref="IContextProvider"/> that drives a bulk fill, and
/// the owner of the caches those functions were rewritten into. That is why it is stateful and why the
/// walk over a chunk has to follow the order in
/// <see cref="VanillaTerrainGenerator"/>: initialise the first slice, then for each cell fill it,
/// advance, and swap.
/// <p/>
/// <b>Not thread safe and not reusable.</b> One per chunk generation.
/// </remarks>
public sealed class NoiseChunk : IFunctionContext, IContextProvider, INoiseChunkSurfaceView {
    private readonly int _cellCountXz;
    private readonly int _cellCountY;
    private readonly int _cellNoiseMinY;
    private readonly int _firstCellX;
    private readonly int _firstCellZ;
    private readonly int _firstNoiseX;
    private readonly int _firstNoiseZ;
    private readonly int _noiseSizeXz;
    private readonly int _cellWidth;
    private readonly int _cellHeight;

    private readonly List<NoiseInterpolator> _interpolators = [];
    private readonly List<CacheAllInCell> _cellCaches = [];

    /// <summary>
    /// The one rewrite every tree this chunk uses goes through, so a marker reached from several
    /// router entries becomes a single cache. Kept past the constructor for
    /// <see cref="CachedClimateSampler"/>, which maps six entries the constructor has already mapped.
    /// </summary>
    private readonly DensityFunctionRewrite _rewrite;

    private readonly Dictionary<long, int> _preliminarySurfaceLevelCache = [];
    private readonly IDensityFunction _preliminarySurfaceLevel;
    private readonly IDensityFunction _fullNoiseDensity;
    private readonly IBlockStateFiller _blockStateRule;

    private bool _interpolating;
    private bool _fillingCell;

    private int _cellStartBlockX;
    private int _cellStartBlockY;
    private int _cellStartBlockZ;
    private int _inCellX;
    private int _inCellY;
    private int _inCellZ;

    private long _interpolationCounter;
    private long _arrayInterpolationCounter;
    private int _arrayIndex;

    private readonly SliceFillingContextProvider _sliceFillingContextProvider;

    public NoiseChunk(int cellCountXz, IRandomState randomState, int chunkMinBlockX, int chunkMinBlockZ,
        NoiseSettings noiseSettings, NoiseGeneratorSettings settings, IFluidPicker globalFluidPicker,
        ISimpleDensityFunction? beardifier = null) {

        _cellWidth = noiseSettings.CellWidth;
        _cellHeight = noiseSettings.CellHeight;
        _cellCountXz = cellCountXz;
        _cellCountY = Mth.FloorDiv(noiseSettings.Height, _cellHeight);
        _cellNoiseMinY = Mth.FloorDiv(noiseSettings.MinY, _cellHeight);
        _firstCellX = Mth.FloorDiv(chunkMinBlockX, _cellWidth);
        _firstCellZ = Mth.FloorDiv(chunkMinBlockZ, _cellWidth);
        _firstNoiseX = chunkMinBlockX >> 2;
        _firstNoiseZ = chunkMinBlockZ >> 2;
        _noiseSizeXz = (cellCountXz * _cellWidth) >> 2;

        _sliceFillingContextProvider = new SliceFillingContextProvider(this);

        _rewrite = new DensityFunctionRewrite(new WrapVisitor(this));

        NoiseRouter wrappedRouter = randomState.Router.MapAll(_rewrite);
        _preliminarySurfaceLevel = wrappedRouter.PreliminarySurfaceLevel;

        int chunkX = chunkMinBlockX >> 4;
        int chunkZ = chunkMinBlockZ >> 4;

        Aquifer = settings.AquifersEnabled
            ? new NoiseBasedAquifer(this, chunkX, chunkZ, wrappedRouter, randomState.AquiferRandom,
                noiseSettings.MinY, noiseSettings.Height, globalFluidPicker)
            : new DisabledAquifer(globalFluidPicker);

        // The beardifier term is added and then the sum is cached per cell, so the whole density of a
        // cell is computed in one pass rather than per block. It is null wherever no structure with a
        // terrain adaptation reaches the chunk, which is the great majority of them and also what a
        // generator with the structure pass off always passes.
        _fullNoiseDensity = DensityFunctions
            .CacheAllInCell(DensityFunctions.Add(wrappedRouter.FinalDensity,
                beardifier ?? DensityFunctions.Beardifier.Instance))
            .MapAll(_rewrite);

        List<IBlockStateFiller> fillers = [new AquiferFiller(Aquifer, _fullNoiseDensity)];
        if (settings.OreVeinsEnabled) {
            fillers.Add(new OreVeinifier(wrappedRouter.VeinToggle, wrappedRouter.VeinRidged,
                wrappedRouter.VeinGap, randomState.OreRandom));
        }

        _blockStateRule = new MaterialRuleList(fillers);
    }

    public IAquifer Aquifer { get; }

    public int BlockX => _cellStartBlockX + _inCellX;
    public int BlockY => _cellStartBlockY + _inCellY;
    public int BlockZ => _cellStartBlockZ + _inCellZ;

    /// <summary>The state at the current position, or null for the terrain block.</summary>
    public uint? GetInterpolatedState() => _blockStateRule.Calculate(this);

    public double GetInterpolatedDensity() => _fullNoiseDensity.Compute(this);

    /// <summary>
    /// A climate sampler reading this chunk's caches, which is what makes the six biome noises cost
    /// nothing extra once the terrain has been sampled.
    /// </summary>
    public ClimateSampler CachedClimateSampler(NoiseRouter router) {
        // The unwrapped router, as vanilla passes it. Every one of these six was mapped by the
        // constructor, so the rewrite answers with the caches already built rather than a second set.
        return new ClimateSampler(
            _rewrite.Apply(router.Temperature),
            _rewrite.Apply(router.Vegetation),
            _rewrite.Apply(router.Continents),
            _rewrite.Apply(router.Erosion),
            _rewrite.Apply(router.Depth),
            _rewrite.Apply(router.Ridges));
    }

    /// <summary>
    /// Where the terrain's top is, quantised to a four block grid and cached per column.
    /// </summary>
    /// <remarks>
    /// An estimate from the router rather than a search through the chunk, and it is read before the
    /// chunk exists: the aquifer needs it while deciding fluid levels.
    /// </remarks>
    public int PreliminarySurfaceLevel(int sampleX, int sampleZ) {
        int quantisedX = (sampleX >> 2) << 2;
        int quantisedZ = (sampleZ >> 2) << 2;
        long key = ((long)quantisedX << 32) | (uint)quantisedZ;

        if (_preliminarySurfaceLevelCache.TryGetValue(key, out int level)) {
            return level;
        }

        level = Mth.Floor(_preliminarySurfaceLevel.Compute(new SinglePointContext(quantisedX, 0, quantisedZ)));
        _preliminarySurfaceLevelCache[key] = level;
        return level;
    }

    // --- the interpolation walk --------------------------------------------

    private void FillSlice(bool slice0, int cellX) {
        _cellStartBlockX = cellX * _cellWidth;
        _inCellX = 0;

        for (int cellZIndex = 0; cellZIndex < _cellCountXz + 1; cellZIndex++) {
            _cellStartBlockZ = (_firstCellZ + cellZIndex) * _cellWidth;
            _inCellZ = 0;
            _arrayInterpolationCounter++;

            foreach (NoiseInterpolator interpolator in _interpolators) {
                double[] slice = (slice0 ? interpolator.Slice0 : interpolator.Slice1)[cellZIndex];
                interpolator.FillArray(slice, _sliceFillingContextProvider);
            }
        }

        _arrayInterpolationCounter++;
    }

    public void InitializeForFirstCellX() {
        if (_interpolating) {
            throw new InvalidOperationException("Starting interpolation twice");
        }

        _interpolating = true;
        _interpolationCounter = 0L;
        FillSlice(true, _firstCellX);
    }

    /// <summary>Fills the far slice of the next cell column. The near one is the previous far one.</summary>
    public void AdvanceCellX(int cellXIndex) {
        FillSlice(false, _firstCellX + cellXIndex + 1);
        _cellStartBlockX = (_firstCellX + cellXIndex) * _cellWidth;
    }

    public void SelectCellYZ(int cellYIndex, int cellZIndex) {
        foreach (NoiseInterpolator interpolator in _interpolators) {
            interpolator.SelectCellYz(cellYIndex, cellZIndex);
        }

        _fillingCell = true;
        _cellStartBlockY = (cellYIndex + _cellNoiseMinY) * _cellHeight;
        _cellStartBlockZ = (_firstCellZ + cellZIndex) * _cellWidth;
        _arrayInterpolationCounter++;

        foreach (CacheAllInCell cellCache in _cellCaches) {
            cellCache.Fill(this);
        }

        _arrayInterpolationCounter++;
        _fillingCell = false;
    }

    public void UpdateForY(int posY, double factorY) {
        _inCellY = posY - _cellStartBlockY;
        foreach (NoiseInterpolator interpolator in _interpolators) {
            interpolator.UpdateForY(factorY);
        }
    }

    public void UpdateForX(int posX, double factorX) {
        _inCellX = posX - _cellStartBlockX;
        foreach (NoiseInterpolator interpolator in _interpolators) {
            interpolator.UpdateForX(factorX);
        }
    }

    public void UpdateForZ(int posZ, double factorZ) {
        _inCellZ = posZ - _cellStartBlockZ;
        _interpolationCounter++;

        foreach (NoiseInterpolator interpolator in _interpolators) {
            interpolator.UpdateForZ(factorZ);
        }
    }

    public void StopInterpolation() {
        if (!_interpolating) {
            throw new InvalidOperationException("Stopping interpolation that never started");
        }

        _interpolating = false;
    }

    public void SwapSlices() {
        foreach (NoiseInterpolator interpolator in _interpolators) {
            interpolator.SwapSlices();
        }
    }

    // --- IContextProvider ---------------------------------------------------

    public IFunctionContext ForIndex(int cellIndex) {
        int zInCell = Mth.FloorMod(cellIndex, _cellWidth);
        int xyIndex = Mth.FloorDiv(cellIndex, _cellWidth);
        _inCellX = Mth.FloorMod(xyIndex, _cellWidth);
        _inCellY = _cellHeight - 1 - Mth.FloorDiv(xyIndex, _cellWidth);
        _inCellZ = zInCell;
        _arrayIndex = cellIndex;
        return this;
    }

    /// <summary>
    /// Walks a whole cell, y from the top down and then x and z. The order is the index layout every
    /// cell cache assumes, so it is not free to change.
    /// </summary>
    public void FillAllDirectly(double[] output, IDensityFunction function) {
        _arrayIndex = 0;

        for (int yInCell = _cellHeight - 1; yInCell >= 0; yInCell--) {
            _inCellY = yInCell;

            for (int xInCell = 0; xInCell < _cellWidth; xInCell++) {
                _inCellX = xInCell;

                for (int zInCell = 0; zInCell < _cellWidth; zInCell++) {
                    _inCellZ = zInCell;
                    output[_arrayIndex++] = function.Compute(this);
                }
            }
        }
    }

    // --- rewriting the tree -------------------------------------------------

    /// <summary>
    /// What a marker becomes in a chunk. Called once per distinct node, since
    /// <see cref="DensityFunctionRewrite"/> holds the memo.
    /// </summary>
    private IDensityFunction Wrap(IDensityFunction function) {
        if (function is not DensityFunctions.Marker marker) {
            return function;
        }

        return marker.Type switch {
            MarkerType.Interpolated => new NoiseInterpolator(this, marker.Wrapped),
            MarkerType.FlatCache => new FlatCache(this, marker.Wrapped),
            MarkerType.Cache2D => new Cache2D(marker.Wrapped),
            MarkerType.CacheOnce => new CacheOnce(this, marker.Wrapped),
            MarkerType.CacheAllInCell => new CacheAllInCell(this, marker.Wrapped),

            // Terrain blending against an old world is not implemented, so a blend_density marker is
            // the function under it. That is also vanilla's answer whenever the blender is empty,
            // which for a freshly generated world it always is.
            MarkerType.BlendDensity => marker.Wrapped,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private sealed class WrapVisitor(NoiseChunk chunk) : IDensityFunctionVisitor {
        public IDensityFunction Apply(IDensityFunction input) => chunk.Wrap(input);
    }

    /// <summary>
    /// Drives a slice fill: one sample per cell corner up a column, rather than one per block.
    /// </summary>
    private sealed class SliceFillingContextProvider(NoiseChunk chunk) : IContextProvider {
        public IFunctionContext ForIndex(int cellYIndex) {
            chunk._cellStartBlockY = (cellYIndex + chunk._cellNoiseMinY) * chunk._cellHeight;
            chunk._interpolationCounter++;
            chunk._inCellY = 0;
            chunk._arrayIndex = cellYIndex;
            return chunk;
        }

        public void FillAllDirectly(double[] output, IDensityFunction function) {
            for (int cellYIndex = 0; cellYIndex < chunk._cellCountY + 1; cellYIndex++) {
                chunk._cellStartBlockY = (cellYIndex + chunk._cellNoiseMinY) * chunk._cellHeight;
                chunk._interpolationCounter++;
                chunk._inCellY = 0;
                chunk._arrayIndex = cellYIndex;
                output[cellYIndex] = function.Compute(chunk);
            }
        }
    }

    /// <summary>The aquifer as a state filler: the first thing asked about every position.</summary>
    private sealed class AquiferFiller(IAquifer aquifer, IDensityFunction density) : IBlockStateFiller {
        public uint? Calculate(IFunctionContext context) {
            return aquifer.ComputeSubstance(context, density.Compute(context));
        }
    }

    // --- the caches ---------------------------------------------------------

    /// <summary>
    /// A node the chunk substituted in, which reports the range of what it wrapped since caching
    /// cannot change what a function can produce.
    /// </summary>
    private abstract class ChunkDensityFunction(IDensityFunction wrapped) : IMarkerOrMarked {
        public IDensityFunction Wrapped => wrapped;

        public abstract MarkerType Type { get; }

        public abstract double Compute(IFunctionContext context);

        public abstract void FillArray(double[] output, IContextProvider provider);

        public double MinValue => wrapped.MinValue;
        public double MaxValue => wrapped.MaxValue;
    }

    /// <summary>Holds the last value for one horizontal position, which is all a 2D function needs.</summary>
    private sealed class Cache2D : ChunkDensityFunction {
        private long _lastPos2D = long.MinValue;
        private double _lastValue;

        public Cache2D(IDensityFunction function) : base(function) { }

        public override MarkerType Type => MarkerType.Cache2D;

        public override double Compute(IFunctionContext context) {
            long pos2D = ((long)context.BlockX << 32) | (uint)context.BlockZ;
            if (_lastPos2D == pos2D) {
                return _lastValue;
            }

            _lastPos2D = pos2D;
            _lastValue = Wrapped.Compute(context);
            return _lastValue;
        }

        public override void FillArray(double[] output, IContextProvider provider) {
            // Deliberately not cached: a bulk fill walks a column, so every element would miss.
            Wrapped.FillArray(output, provider);
        }
    }

    /// <summary>
    /// A whole chunk's worth of one 2D function, sampled up front on the four block noise grid.
    /// </summary>
    /// <remarks>
    /// This is what makes the climate noises cheap: continentalness, erosion and the rest are read at
    /// thousands of positions per chunk and vary only per four blocks.
    /// </remarks>
    private sealed class FlatCache : ChunkDensityFunction {
        private readonly IDensityFunction _noiseFiller;
        private readonly double[] _values;
        private readonly int _sizeXz;
        private readonly int _firstNoiseX;
        private readonly int _firstNoiseZ;

        public FlatCache(NoiseChunk chunk, IDensityFunction noiseFiller) : base(noiseFiller) {
            _noiseFiller = noiseFiller;
            _firstNoiseX = chunk._firstNoiseX;
            _firstNoiseZ = chunk._firstNoiseZ;
            _sizeXz = chunk._noiseSizeXz + 1;
            _values = new double[_sizeXz * _sizeXz];

            for (int x = 0; x <= chunk._noiseSizeXz; x++) {
                int blockX = (_firstNoiseX + x) << 2;
                for (int z = 0; z <= chunk._noiseSizeXz; z++) {
                    int blockZ = (_firstNoiseZ + z) << 2;
                    _values[x + z * _sizeXz] = noiseFiller.Compute(new SinglePointContext(blockX, 0, blockZ));
                }
            }
        }

        public override MarkerType Type => MarkerType.FlatCache;

        public override double Compute(IFunctionContext context) {
            int x = (context.BlockX >> 2) - _firstNoiseX;
            int z = (context.BlockZ >> 2) - _firstNoiseZ;

            // A position outside the chunk falls through rather than clamping, which is what lets the
            // aquifer sample surface levels three chunks away.
            return x >= 0 && z >= 0 && x < _sizeXz && z < _sizeXz
                ? _values[x + z * _sizeXz]
                : _noiseFiller.Compute(context);
        }

        public override void FillArray(double[] output, IContextProvider provider) {
            provider.FillAllDirectly(output, this);
        }
    }

    /// <summary>
    /// Holds one value, or one array, until the chunk's counters move. What a subtree read from
    /// several places within one position wants.
    /// </summary>
    private sealed class CacheOnce : ChunkDensityFunction {
        private readonly NoiseChunk _chunk;

        private long _lastCounter = long.MinValue;
        private long _lastArrayCounter = long.MinValue;
        private double _lastValue;
        private double[]? _lastArray;

        public CacheOnce(NoiseChunk chunk, IDensityFunction function) : base(function) {
            _chunk = chunk;
        }

        public override MarkerType Type => MarkerType.CacheOnce;

        public override double Compute(IFunctionContext context) {
            // A context that is not the chunk is a one off sample from outside the walk, so nothing
            // about the cached position applies to it.
            if (!ReferenceEquals(context, _chunk)) {
                return Wrapped.Compute(context);
            }

            if (_lastArray != null && _lastArrayCounter == _chunk._arrayInterpolationCounter) {
                return _lastArray[_chunk._arrayIndex];
            }

            if (_lastCounter == _chunk._interpolationCounter) {
                return _lastValue;
            }

            _lastCounter = _chunk._interpolationCounter;
            _lastValue = Wrapped.Compute(context);
            return _lastValue;
        }

        public override void FillArray(double[] output, IContextProvider provider) {
            if (_lastArray != null && _lastArrayCounter == _chunk._arrayInterpolationCounter) {
                Array.Copy(_lastArray, output, output.Length);
                return;
            }

            Wrapped.FillArray(output, provider);

            if (_lastArray != null && _lastArray.Length == output.Length) {
                Array.Copy(output, _lastArray, output.Length);
            } else {
                _lastArray = (double[])output.Clone();
            }

            _lastArrayCounter = _chunk._arrayInterpolationCounter;
        }
    }

    /// <summary>
    /// Every position of the current cell, sampled in one pass when the cell is selected.
    /// </summary>
    private sealed class CacheAllInCell : ChunkDensityFunction {
        private readonly NoiseChunk _chunk;
        private readonly IDensityFunction _noiseFiller;
        private readonly double[] _values;

        public CacheAllInCell(NoiseChunk chunk, IDensityFunction noiseFiller) : base(noiseFiller) {
            _chunk = chunk;
            _noiseFiller = noiseFiller;
            _values = new double[chunk._cellWidth * chunk._cellWidth * chunk._cellHeight];
            chunk._cellCaches.Add(this);
        }

        public override MarkerType Type => MarkerType.CacheAllInCell;

        public void Fill(IContextProvider provider) {
            _noiseFiller.FillArray(_values, provider);
        }

        public override double Compute(IFunctionContext context) {
            if (!ReferenceEquals(context, _chunk)) {
                return _noiseFiller.Compute(context);
            }

            if (!_chunk._interpolating) {
                throw new InvalidOperationException("Trying to sample a cell cache outside the interpolation loop");
            }

            int x = _chunk._inCellX;
            int y = _chunk._inCellY;
            int z = _chunk._inCellZ;

            // The y index is inverted because the fill walks a cell from the top down.
            return x >= 0 && y >= 0 && z >= 0
                && x < _chunk._cellWidth && y < _chunk._cellHeight && z < _chunk._cellWidth
                ? _values[((_chunk._cellHeight - 1 - y) * _chunk._cellWidth + x) * _chunk._cellWidth + z]
                : _noiseFiller.Compute(context);
        }

        public override void FillArray(double[] output, IContextProvider provider) {
            provider.FillAllDirectly(output, this);
        }
    }

    /// <summary>
    /// The trilinear interpolator, vanilla's <c>NoiseInterpolator</c>: the density at the eight corners
    /// of the current cell, and the partial lerps between them.
    /// </summary>
    /// <remarks>
    /// Two slices of samples are kept, the near and far faces of the current cell column in x. Walking
    /// to the next column swaps them, so each plane of corner samples is computed once rather than
    /// twice.
    /// <p/>
    /// The three <c>UpdateFor</c> calls are a staged lerp, not three independent ones: y collapses the
    /// eight corners to four, x collapses those to two, z to one. They have to be called in that order
    /// and the outer loops are structured around it.
    /// </remarks>
    private sealed class NoiseInterpolator : ChunkDensityFunction {
        private readonly NoiseChunk _chunk;
        private readonly IDensityFunction _noiseFiller;

        private double[][] _slice0;
        private double[][] _slice1;

        private double _noise000, _noise001, _noise100, _noise101;
        private double _noise010, _noise011, _noise110, _noise111;
        private double _valueXz00, _valueXz10, _valueXz01, _valueXz11;
        private double _valueZ0, _valueZ1;
        private double _value;

        public NoiseInterpolator(NoiseChunk chunk, IDensityFunction noiseFiller) : base(noiseFiller) {
            _chunk = chunk;
            _noiseFiller = noiseFiller;
            _slice0 = AllocateSlice(chunk._cellCountY, chunk._cellCountXz);
            _slice1 = AllocateSlice(chunk._cellCountY, chunk._cellCountXz);
            chunk._interpolators.Add(this);
        }

        public double[][] Slice0 => _slice0;
        public double[][] Slice1 => _slice1;

        public override MarkerType Type => MarkerType.Interpolated;

        private static double[][] AllocateSlice(int cellCountY, int cellCountZ) {
            double[][] result = new double[cellCountZ + 1][];
            for (int cellZIndex = 0; cellZIndex < result.Length; cellZIndex++) {
                result[cellZIndex] = new double[cellCountY + 1];
            }

            return result;
        }

        public void SelectCellYz(int cellYIndex, int cellZIndex) {
            _noise000 = _slice0[cellZIndex][cellYIndex];
            _noise001 = _slice0[cellZIndex + 1][cellYIndex];
            _noise100 = _slice1[cellZIndex][cellYIndex];
            _noise101 = _slice1[cellZIndex + 1][cellYIndex];
            _noise010 = _slice0[cellZIndex][cellYIndex + 1];
            _noise011 = _slice0[cellZIndex + 1][cellYIndex + 1];
            _noise110 = _slice1[cellZIndex][cellYIndex + 1];
            _noise111 = _slice1[cellZIndex + 1][cellYIndex + 1];
        }

        public void UpdateForY(double factorY) {
            _valueXz00 = Mth.Lerp(factorY, _noise000, _noise010);
            _valueXz10 = Mth.Lerp(factorY, _noise100, _noise110);
            _valueXz01 = Mth.Lerp(factorY, _noise001, _noise011);
            _valueXz11 = Mth.Lerp(factorY, _noise101, _noise111);
        }

        public void UpdateForX(double factorX) {
            _valueZ0 = Mth.Lerp(factorX, _valueXz00, _valueXz10);
            _valueZ1 = Mth.Lerp(factorX, _valueXz01, _valueXz11);
        }

        public void UpdateForZ(double factorZ) {
            _value = Mth.Lerp(factorZ, _valueZ0, _valueZ1);
        }

        public override double Compute(IFunctionContext context) {
            if (!ReferenceEquals(context, _chunk)) {
                return _noiseFiller.Compute(context);
            }

            if (!_chunk._interpolating) {
                throw new InvalidOperationException("Trying to sample an interpolator outside the interpolation loop");
            }

            // While a cell cache is being filled the staged lerp has not run for this position, so the
            // full trilinear form is used instead.
            return _chunk._fillingCell
                ? Mth.Lerp3((double)_chunk._inCellX / _chunk._cellWidth,
                    (double)_chunk._inCellY / _chunk._cellHeight,
                    (double)_chunk._inCellZ / _chunk._cellWidth,
                    _noise000, _noise100, _noise010, _noise110,
                    _noise001, _noise101, _noise011, _noise111)
                : _value;
        }

        public override void FillArray(double[] output, IContextProvider provider) {
            if (_chunk._fillingCell) {
                provider.FillAllDirectly(output, this);
            } else {
                _noiseFiller.FillArray(output, provider);
            }
        }

        public void SwapSlices() {
            (_slice0, _slice1) = (_slice1, _slice0);
        }
    }
}
