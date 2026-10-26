using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Material;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Terrain;

/// <summary>
/// A fluid level and what fluid it is, vanilla's <c>Aquifer.FluidStatus</c>.
/// </summary>
/// <remarks>
/// A level of <see cref="AquiferConstants.WayBelowMinY"/> means a dry pocket, which is what makes most
/// underground cavities air rather than water.
/// </remarks>
public readonly record struct FluidStatus(int FluidLevel, uint FluidType) {
    /// <summary>The state at a height: the fluid below its level, air at or above it.</summary>
    public uint At(int blockY) => blockY < FluidLevel ? FluidType : Block.Air.StateId;
}

/// <summary>Where the world's default fluid is, before any aquifer has an opinion.</summary>
public interface IFluidPicker {
    FluidStatus ComputeFluid(int blockX, int blockY, int blockZ);
}

internal static class AquiferConstants {
    /// <summary><c>DimensionType.WAY_BELOW_MIN_Y</c>, the sentinel for a dry aquifer.</summary>
    public const int WayBelowMinY = -32512;
}

/// <summary>
/// The six density functions an aquifer reads, vanilla's <c>Aquifer.Config</c>: the
/// <c>aquifers</c> object of a noise settings file. A dimension without one has the disabled aquifer.
/// </summary>
public sealed record AquiferConfig(IDensityFunction Barrier, IDensityFunction FluidLevelFloodedness,
    IDensityFunction FluidLevelSpread, IDensityFunction Lava, IDensityFunction Exclusion, IDensityFunction SurfaceLevel) {

    public IAquifer Create(IDensitySamplerSet cachingSamplers, IPositionalRandomFactory positionalRandomFactory,
        DensityVolume volume, IFluidPicker fluidRule) {

        return new NoiseBasedAquifer(cachingSamplers, this, positionalRandomFactory, volume, fluidRule);
    }
}

/// <summary>
/// Decides whether a position with no terrain in it is air, water or lava, vanilla's <c>Aquifer</c>.
/// </summary>
public interface IAquifer {
    /// <summary>The state at a position, or null for the terrain block.</summary>
    uint? ComputeSubstance(int blockX, int blockY, int blockZ, double density);

    /// <summary>Whether the last position computed sits on a boundary worth a fluid tick.</summary>
    bool ShouldScheduleFluidUpdate { get; }
}

/// <summary>
/// The aquifer for a dimension without one: below the global fluid level is that fluid, above it air.
/// The nether's is this, with its sea of lava at 32.
/// </summary>
public sealed class DisabledAquifer(IFluidPicker fluidRule) : IAquifer {
    public uint? ComputeSubstance(int blockX, int blockY, int blockZ, double density) {
        return density > 0.0 ? null : fluidRule.ComputeFluid(blockX, blockY, blockZ).At(blockY);
    }

    public bool ShouldScheduleFluidUpdate => false;
}

/// <summary>
/// Vanilla's <c>NoiseBasedAquifer</c>: the underground lakes, the pockets of air inside a cave system
/// and the barriers of stone that keep them apart.
/// </summary>
/// <remarks>
/// Jittered centres on a 16 by 12 by 16 grid offset from the chunk grid, each with its own level; a
/// position takes the nearest centre's, and where two of different levels are about equally close a
/// pressure term walls them off with stone.
/// <p/>
/// The surface levels it reads are cached per quart column, and the constructor seeds that cache from
/// one volume sample over the grid's footprint, so a later point lookup inside it reads the volume
/// path's value and one outside it reads the point path's.
/// </remarks>
public sealed class NoiseBasedAquifer : IAquifer {
    private const int XRange = 10;
    private const int YRange = 9;
    private const int ZRange = 10;
    private const int YSpacing = 12;
    private const int SampleOffsetX = -5;
    private const int SampleOffsetY = 1;
    private const int SampleOffsetZ = -5;

    private static readonly double FlowingUpdateSimilarity = Similarity(10 * 10, 12 * 12);

    /// <summary>The chunks around a centre whose surface level is consulted. Deliberately not symmetric.</summary>
    private static readonly int[][] SurfaceSamplingOffsetsInChunks = [
        [0, 0], [-2, -1], [-1, -1], [0, -1], [1, -1], [-3, 0], [-2, 0], [-1, 0], [1, 0], [-2, 1], [-1, 1], [0, 1], [1, 1]
    ];

    private readonly BoundSampler _barrierNoise;
    private readonly BoundSampler _fluidLevelFloodednessNoise;
    private readonly BoundSampler _fluidLevelSpreadNoise;
    private readonly BoundSampler _lavaNoise;
    private readonly BoundSampler _exclusion;
    private readonly BoundSampler _surfaceLevel;
    private readonly IPositionalRandomFactory _positionalRandomFactory;
    private readonly FluidStatus?[] _aquiferCache;
    private readonly AquiferCentre?[] _aquiferLocationCache;
    private readonly IFluidPicker _globalFluidPicker;
    private readonly Dictionary<long, int> _surfaceLevelCache = new();
    private readonly int _skipSamplingAboveY;
    private readonly int _minGridX;
    private readonly int _minGridY;
    private readonly int _minGridZ;
    private readonly int _gridSizeX;
    private readonly int _gridSizeZ;

    public NoiseBasedAquifer(IDensitySamplerSet cachingSamplers, AquiferConfig config, IPositionalRandomFactory positionalRandomFactory,
        DensityVolume volume, IFluidPicker globalFluidPicker) {

        _barrierNoise = cachingSamplers.Get(config.Barrier);
        _fluidLevelFloodednessNoise = cachingSamplers.Get(config.FluidLevelFloodedness);
        _fluidLevelSpreadNoise = cachingSamplers.Get(config.FluidLevelSpread);
        _lavaNoise = cachingSamplers.Get(config.Lava);
        _exclusion = cachingSamplers.Get(config.Exclusion);
        _surfaceLevel = cachingSamplers.Get(config.SurfaceLevel);
        _positionalRandomFactory = positionalRandomFactory;
        _globalFluidPicker = globalFluidPicker;

        _minGridX = GridX(volume.MinBlockX + SampleOffsetX);
        int maxGridX = GridX(volume.MaxBlockX + SampleOffsetX) + 1;
        _gridSizeX = maxGridX - _minGridX + 1;
        _minGridY = GridY(volume.MinBlockY + SampleOffsetY) - 1;
        int maxGridY = GridY(volume.MaxBlockY + SampleOffsetY) + 1;
        int gridSizeY = maxGridY - _minGridY + 1;
        _minGridZ = GridZ(volume.MinBlockZ + SampleOffsetZ);
        int maxGridZ = GridZ(volume.MaxBlockZ + SampleOffsetZ) + 1;
        _gridSizeZ = maxGridZ - _minGridZ + 1;

        int totalGridSize = _gridSizeX * gridSizeY * _gridSizeZ;
        _aquiferCache = new FluidStatus?[totalGridSize];
        _aquiferLocationCache = new AquiferCentre?[totalGridSize];

        int maxAdjustedSurfaceLevel = AdjustSurfaceLevel(MaxSurfaceLevel(FromGridX(_minGridX, 0), FromGridZ(_minGridZ, 0),
            FromGridX(maxGridX, YRange), FromGridZ(maxGridZ, YRange)));
        int skipSamplingAboveGridY = GridY(maxAdjustedSurfaceLevel + YSpacing) + 1;
        _skipSamplingAboveY = FromGridY(skipSamplingAboveGridY, 11) - 1;
    }

    public bool ShouldScheduleFluidUpdate { get; private set; }

    /// <summary><c>ChunkPos.pack</c>, the cache key.</summary>
    private static long Pack(int x, int z) => ((long)x & 0xFFFFFFFFL) | (((long)z & 0xFFFFFFFFL) << 32);

    private int SurfaceLevel(int blockX, int blockZ) {
        int quantizedX = (blockX >> 2) << 2;
        int quantizedZ = (blockZ >> 2) << 2;
        long key = Pack(quantizedX, quantizedZ);
        if (!_surfaceLevelCache.TryGetValue(key, out int level)) {
            level = Mth.Floor(_surfaceLevel.SampleValue(quantizedX, 0, quantizedZ));
            _surfaceLevelCache[key] = level;
        }

        return level;
    }

    private int MaxSurfaceLevel(int minBlockX, int minBlockZ, int maxBlockX, int maxBlockZ) {
        int minQuartX = minBlockX >> 2;
        int maxQuartX = maxBlockX >> 2;
        int minQuartZ = minBlockZ >> 2;
        int maxQuartZ = maxBlockZ >> 2;
        DensityVolume volume = new(maxQuartX - minQuartX + 1, 1, maxQuartZ - minQuartZ + 1, minQuartX << 2, 0, minQuartZ << 2, 4, 1, 4);
        using ScopedDensityBuffer buffer = _surfaceLevel.SampleVolume(volume);
        int maxY = int.MinValue;
        for (int z = 0; z < volume.SizeZ; z++) {
            for (int x = 0; x < volume.SizeX; x++) {
                int surfaceLevel = Mth.Floor(buffer[volume.IndexUnchecked(x, 0, z)]);
                _surfaceLevelCache[Pack(volume.BlockX(x), volume.BlockZ(z))] = surfaceLevel;
                if (surfaceLevel > maxY) {
                    maxY = surfaceLevel;
                }
            }
        }

        return maxY;
    }

    private int GetIndex(int gridX, int gridY, int gridZ) {
        return ((gridY - _minGridY) * _gridSizeZ + (gridZ - _minGridZ)) * _gridSizeX + (gridX - _minGridX);
    }

    public uint? ComputeSubstance(int blockX, int blockY, int blockZ, double density) {
        if (density > 0.0) {
            ShouldScheduleFluidUpdate = false;
            return null;
        }

        FluidStatus globalFluid = _globalFluidPicker.ComputeFluid(blockX, blockY, blockZ);
        if (blockY > _skipSamplingAboveY) {
            ShouldScheduleFluidUpdate = false;
            return globalFluid.At(blockY);
        }

        if (IsLava(globalFluid.At(blockY))) {
            ShouldScheduleFluidUpdate = false;
            return Block.Lava.StateId;
        }

        int xAnchor = GridX(blockX + SampleOffsetX);
        int yAnchor = GridY(blockY + SampleOffsetY);
        int zAnchor = GridZ(blockZ + SampleOffsetZ);
        int distanceSqr1 = int.MaxValue;
        int distanceSqr2 = int.MaxValue;
        int distanceSqr3 = int.MaxValue;
        int distanceSqr4 = int.MaxValue;
        int closestIndex1 = 0;
        int closestIndex2 = 0;
        int closestIndex3 = 0;
        int closestIndex4 = 0;

        for (int x1 = 0; x1 <= 1; x1++) {
            for (int y1 = -1; y1 <= 1; y1++) {
                for (int z1 = 0; z1 <= 1; z1++) {
                    int spacedGridX = xAnchor + x1;
                    int spacedGridY = yAnchor + y1;
                    int spacedGridZ = zAnchor + z1;
                    int index = GetIndex(spacedGridX, spacedGridY, spacedGridZ);
                    if (_aquiferLocationCache[index] is not { } location) {
                        RandomSource random = _positionalRandomFactory.At(spacedGridX, spacedGridY, spacedGridZ);
                        location = new AquiferCentre(FromGridX(spacedGridX, random.NextInt(XRange)),
                            FromGridY(spacedGridY, random.NextInt(YRange)), FromGridZ(spacedGridZ, random.NextInt(ZRange)));
                        _aquiferLocationCache[index] = location;
                    }

                    int dx = location.X - blockX;
                    int dy = location.Y - blockY;
                    int dz = location.Z - blockZ;
                    int newDistance = dx * dx + dy * dy + dz * dz;
                    if (distanceSqr1 >= newDistance) {
                        closestIndex4 = closestIndex3;
                        closestIndex3 = closestIndex2;
                        closestIndex2 = closestIndex1;
                        closestIndex1 = index;
                        distanceSqr4 = distanceSqr3;
                        distanceSqr3 = distanceSqr2;
                        distanceSqr2 = distanceSqr1;
                        distanceSqr1 = newDistance;
                    } else if (distanceSqr2 >= newDistance) {
                        closestIndex4 = closestIndex3;
                        closestIndex3 = closestIndex2;
                        closestIndex2 = index;
                        distanceSqr4 = distanceSqr3;
                        distanceSqr3 = distanceSqr2;
                        distanceSqr2 = newDistance;
                    } else if (distanceSqr3 >= newDistance) {
                        closestIndex4 = closestIndex3;
                        closestIndex3 = index;
                        distanceSqr4 = distanceSqr3;
                        distanceSqr3 = newDistance;
                    } else if (distanceSqr4 >= newDistance) {
                        closestIndex4 = index;
                        distanceSqr4 = newDistance;
                    }
                }
            }
        }

        FluidStatus closestStatus1 = GetAquiferStatus(closestIndex1);
        double similarity12 = Similarity(distanceSqr1, distanceSqr2);
        uint fluidState = closestStatus1.At(blockY);
        if (similarity12 <= 0.0) {
            if (similarity12 >= FlowingUpdateSimilarity) {
                FluidStatus closestStatus2 = GetAquiferStatus(closestIndex2);
                ShouldScheduleFluidUpdate = !closestStatus1.Equals(closestStatus2);
            } else {
                ShouldScheduleFluidUpdate = false;
            }

            return fluidState;
        }

        if (IsWater(fluidState) && IsLava(_globalFluidPicker.ComputeFluid(blockX, blockY - 1, blockZ).At(blockY - 1))) {
            ShouldScheduleFluidUpdate = true;
            return fluidState;
        }

        double barrierNoiseValue = double.NaN;
        FluidStatus status2 = GetAquiferStatus(closestIndex2);
        double barrier12 = similarity12 * CalculatePressure(blockX, blockY, blockZ, ref barrierNoiseValue, closestStatus1, status2);
        if (density + barrier12 > 0.0) {
            ShouldScheduleFluidUpdate = false;
            return null;
        }

        FluidStatus status3 = GetAquiferStatus(closestIndex3);
        double similarity13 = Similarity(distanceSqr1, distanceSqr3);
        if (similarity13 > 0.0) {
            double barrier13 = similarity12 * similarity13
                * CalculatePressure(blockX, blockY, blockZ, ref barrierNoiseValue, closestStatus1, status3);
            if (density + barrier13 > 0.0) {
                ShouldScheduleFluidUpdate = false;
                return null;
            }
        }

        double similarity23 = Similarity(distanceSqr2, distanceSqr3);
        if (similarity23 > 0.0) {
            double barrier23 = similarity12 * similarity23
                * CalculatePressure(blockX, blockY, blockZ, ref barrierNoiseValue, status2, status3);
            if (density + barrier23 > 0.0) {
                ShouldScheduleFluidUpdate = false;
                return null;
            }
        }

        bool mayFlow12 = !closestStatus1.Equals(status2);
        bool mayFlow23 = similarity23 >= FlowingUpdateSimilarity && !status2.Equals(status3);
        bool mayFlow13 = similarity13 >= FlowingUpdateSimilarity && !closestStatus1.Equals(status3);
        if (!mayFlow12 && !mayFlow23 && !mayFlow13) {
            ShouldScheduleFluidUpdate = similarity13 >= FlowingUpdateSimilarity
                && Similarity(distanceSqr1, distanceSqr4) >= FlowingUpdateSimilarity
                && !closestStatus1.Equals(GetAquiferStatus(closestIndex4));
        } else {
            ShouldScheduleFluidUpdate = true;
        }

        return fluidState;
    }

    /// <summary>Every fluid an aquifer produces is a default state, so <c>is(Blocks.LAVA)</c> is an equality here.</summary>
    private static bool IsLava(uint state) => state == Block.Lava.StateId;

    private static bool IsWater(uint state) => state == Block.Water.StateId;

    private static double Similarity(int distanceSqr1, int distanceSqr2) {
        return 1.0 - (distanceSqr2 - distanceSqr1) / 25.0;
    }

    /// <summary>The barrier noise is sampled at most once per position, through <paramref name="barrierNoiseValue"/>.</summary>
    private double CalculatePressure(int blockX, int blockY, int blockZ, ref double barrierNoiseValue, FluidStatus statusClosest1,
        FluidStatus statusClosest2) {

        uint type1 = statusClosest1.At(blockY);
        uint type2 = statusClosest2.At(blockY);
        if ((IsLava(type1) && IsWater(type2)) || (IsWater(type1) && IsLava(type2))) {
            return 2.0;
        }

        int fluidYDiff = Math.Abs(statusClosest1.FluidLevel - statusClosest2.FluidLevel);
        if (fluidYDiff == 0) {
            return 0.0;
        }

        double averageFluidY = 0.5 * (statusClosest1.FluidLevel + statusClosest2.FluidLevel);
        double howFarAboveAverageFluidPoint = blockY + 0.5 - averageFluidY;
        double baseValue = fluidYDiff / 2.0;
        double distanceFromBarrierEdgeTowardsMiddle = baseValue - Math.Abs(howFarAboveAverageFluidPoint);
        double gradient;
        if (howFarAboveAverageFluidPoint > 0.0) {
            double centerPoint = 0.0 + distanceFromBarrierEdgeTowardsMiddle;
            gradient = centerPoint > 0.0 ? centerPoint / 1.5 : centerPoint / 2.5;
        } else {
            double centerPoint = 3.0 + distanceFromBarrierEdgeTowardsMiddle;
            gradient = centerPoint > 0.0 ? centerPoint / 3.0 : centerPoint / 10.0;
        }

        double noiseValue;
        if (!(gradient < -2.0) && !(gradient > 2.0)) {
            if (double.IsNaN(barrierNoiseValue)) {
                barrierNoiseValue = _barrierNoise.SampleValue(blockX, blockY, blockZ);
            }

            noiseValue = barrierNoiseValue;
        } else {
            noiseValue = 0.0;
        }

        return 2.0 * (noiseValue + gradient);
    }

    private static int GridX(int blockCoord) => blockCoord >> 4;

    private static int FromGridX(int gridCoord, int blockOffset) => (gridCoord << 4) + blockOffset;

    private static int GridY(int blockCoord) => Mth.FloorDiv(blockCoord, YSpacing);

    private static int FromGridY(int gridCoord, int blockOffset) => gridCoord * YSpacing + blockOffset;

    private static int GridZ(int blockCoord) => blockCoord >> 4;

    private static int FromGridZ(int gridCoord, int blockOffset) => (gridCoord << 4) + blockOffset;

    private FluidStatus GetAquiferStatus(int index) {
        if (_aquiferCache[index] is { } oldStatus) {
            return oldStatus;
        }

        AquiferCentre location = _aquiferLocationCache[index]!.Value;
        FluidStatus status = ComputeFluid(location.X, location.Y, location.Z);
        _aquiferCache[index] = status;
        return status;
    }

    private FluidStatus ComputeFluid(int x, int y, int z) {
        FluidStatus globalFluid = _globalFluidPicker.ComputeFluid(x, y, z);
        int lowestPreliminarySurface = int.MaxValue;
        int topOfAquiferCell = y + YSpacing;
        int bottomOfAquiferCell = y - YSpacing;
        bool surfaceAtCenterIsUnderGlobalFluidLevel = false;

        foreach (int[] offset in SurfaceSamplingOffsetsInChunks) {
            int sampleX = x + (offset[0] << 4);
            int sampleZ = z + (offset[1] << 4);
            int surfaceLevel = SurfaceLevel(sampleX, sampleZ);
            int adjustedSurfaceLevel = AdjustSurfaceLevel(surfaceLevel);
            bool start = offset[0] == 0 && offset[1] == 0;
            if (start && bottomOfAquiferCell > adjustedSurfaceLevel) {
                return globalFluid;
            }

            bool topOfAquiferCellPokesAboveSurface = topOfAquiferCell > adjustedSurfaceLevel;
            if (topOfAquiferCellPokesAboveSurface || start) {
                FluidStatus globalFluidAtSurface = _globalFluidPicker.ComputeFluid(sampleX, adjustedSurfaceLevel, sampleZ);
                if (globalFluidAtSurface.At(adjustedSurfaceLevel) != Block.Air.StateId) {
                    if (start) {
                        surfaceAtCenterIsUnderGlobalFluidLevel = true;
                    }

                    if (topOfAquiferCellPokesAboveSurface) {
                        return globalFluidAtSurface;
                    }
                }
            }

            lowestPreliminarySurface = Math.Min(lowestPreliminarySurface, surfaceLevel);
        }

        int fluidSurfaceLevel = ComputeSurfaceLevel(x, y, z, globalFluid, lowestPreliminarySurface, surfaceAtCenterIsUnderGlobalFluidLevel);
        return new FluidStatus(fluidSurfaceLevel, ComputeFluidType(x, y, z, globalFluid, fluidSurfaceLevel));
    }

    private static int AdjustSurfaceLevel(int preliminarySurfaceLevel) => preliminarySurfaceLevel + 8;

    private int ComputeSurfaceLevel(int x, int y, int z, FluidStatus globalFluid, int lowestSurfaceLevel,
        bool surfaceAtCenterIsUnderGlobalFluidLevel) {

        double partiallyFloodedness;
        double fullyFloodedness;
        if (_exclusion.SampleValue(x, y, z) > 0.0) {
            partiallyFloodedness = -1.0;
            fullyFloodedness = -1.0;
        } else {
            int distanceBelowSurface = AdjustSurfaceLevel(lowestSurfaceLevel) - y;
            double floodednessFactor = surfaceAtCenterIsUnderGlobalFluidLevel
                ? Mth.ClampedMap(distanceBelowSurface, 0.0, 64.0, 1.0, 0.0)
                : 0.0;
            double floodednessNoiseValue = Mth.Clamp((double)_fluidLevelFloodednessNoise.SampleValue(x, y, z), -1.0, 1.0);
            double fullyFloodedThreshold = Mth.Map(floodednessFactor, 1.0, 0.0, -0.3, 0.8);
            double partiallyFloodedThreshold = Mth.Map(floodednessFactor, 1.0, 0.0, -0.8, 0.4);
            partiallyFloodedness = floodednessNoiseValue - partiallyFloodedThreshold;
            fullyFloodedness = floodednessNoiseValue - fullyFloodedThreshold;
        }

        if (fullyFloodedness > 0.0) {
            return globalFluid.FluidLevel;
        }

        return partiallyFloodedness > 0.0
            ? ComputeRandomizedFluidSurfaceLevel(x, y, z, lowestSurfaceLevel)
            : AquiferConstants.WayBelowMinY;
    }

    /// <summary>The spread is a float multiplied by a float, then widened.</summary>
    private int ComputeRandomizedFluidSurfaceLevel(int x, int y, int z, int lowestSurfaceLevel) {
        int fluidLevelCellX = Mth.FloorDiv(x, 16);
        int fluidLevelCellY = Mth.FloorDiv(y, 40);
        int fluidLevelCellZ = Mth.FloorDiv(z, 16);
        int fluidCellMiddleY = fluidLevelCellY * 40 + 20;
        double fluidLevelSpread = _fluidLevelSpreadNoise.SampleValue(fluidLevelCellX, fluidLevelCellY, fluidLevelCellZ) * 10.0F;
        int fluidLevelSpreadQuantized = Mth.Quantize(fluidLevelSpread, 3);
        int targetFluidSurfaceLevel = fluidCellMiddleY + fluidLevelSpreadQuantized;
        return Math.Min(lowestSurfaceLevel, targetFluidSurfaceLevel);
    }

    private uint ComputeFluidType(int x, int y, int z, FluidStatus globalFluid, int fluidSurfaceLevel) {
        uint fluidType = globalFluid.FluidType;
        if (fluidSurfaceLevel <= -10 && fluidSurfaceLevel != AquiferConstants.WayBelowMinY && globalFluid.FluidType != Block.Lava.StateId) {
            int fluidTypeCellX = Mth.FloorDiv(x, 64);
            int fluidTypeCellY = Mth.FloorDiv(y, 40);
            int fluidTypeCellZ = Mth.FloorDiv(z, 64);
            double lavaNoiseValue = _lavaNoise.SampleValue(fluidTypeCellX, fluidTypeCellY, fluidTypeCellZ);
            if (Math.Abs(lavaNoiseValue) > 0.3) {
                fluidType = Block.Lava.StateId;
            }
        }

        return fluidType;
    }

    private readonly record struct AquiferCentre(int X, int Y, int Z);
}
