using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Surface;
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
/// Decides whether a position with no terrain in it is air, water or lava, vanilla's <c>Aquifer</c>.
/// </summary>
public interface IAquifer {
    /// <summary>
    /// The state at a position, or null for the terrain block. Only called where the terrain density
    /// has already been computed, and the density is passed in rather than recomputed.
    /// </summary>
    uint? ComputeSubstance(IFunctionContext context, double density);

    /// <summary>
    /// Whether the last position computed sits on a boundary between two aquifers of different levels,
    /// which vanilla uses to schedule a fluid tick there.
    /// </summary>
    bool ShouldScheduleFluidUpdate { get; }
}

/// <summary>
/// The aquifer for a world with them turned off: everything below the global fluid level is that
/// fluid and everything above it is air.
/// </summary>
public sealed class DisabledAquifer(IFluidPicker fluidRule) : IAquifer {
    public uint? ComputeSubstance(IFunctionContext context, double density) {
        if (density > 0.0) {
            return null;
        }

        return fluidRule.ComputeFluid(context.BlockX, context.BlockY, context.BlockZ).At(context.BlockY);
    }

    public bool ShouldScheduleFluidUpdate => false;
}

/// <summary>
/// Vanilla's <c>NoiseBasedAquifer</c>: the underground lakes, the pockets of air inside a cave system
/// and the barriers of stone that keep them apart.
/// </summary>
/// <remarks>
/// Scattered aquifer centres on a coarse grid, one per cell at a jittered position, each with its own
/// water level. A position takes the level of the nearest centre. Where two centres of different
/// levels are about equally close, a <b>pressure</b> term is added to the terrain density, which walls
/// the two off with stone rather than letting one drain into the other. That barrier is the whole
/// reason a cave under an underground lake stays dry.
/// <p/>
/// The grid is 16 by 12 by 16 blocks, and it is not aligned with the chunk: the offsets of minus five,
/// plus one and minus five are what stop a chunk boundary and an aquifer boundary coinciding.
/// </remarks>
public sealed class NoiseBasedAquifer : IAquifer {
    private const int XRange = 10;
    private const int YRange = 9;
    private const int ZRange = 10;

    private const int YSpacing = 12;

    private const int SampleOffsetX = -5;
    private const int SampleOffsetY = 1;
    private const int SampleOffsetZ = -5;

    /// <summary>
    /// How close two centres have to be before their boundary is worth a fluid tick. Derived from the
    /// grid spacing rather than picked, so it moves with it.
    /// </summary>
    private static readonly double FlowingUpdateSimilarity = Similarity(10 * 10, 12 * 12);

    /// <summary>
    /// The chunks around a centre whose surface level is consulted, in chunk offsets. Deliberately not
    /// symmetric: this is the list in the jar.
    /// </summary>
    private static readonly int[][] SurfaceSamplingOffsetsInChunks = [
        [0, 0], [-2, -1], [-1, -1], [0, -1], [1, -1], [-3, 0], [-2, 0],
        [-1, 0], [1, 0], [-2, 1], [-1, 1], [0, 1], [1, 1]
    ];

    private readonly INoiseChunkSurfaceView _noiseChunk;
    private readonly IDensityFunction _barrierNoise;
    private readonly IDensityFunction _fluidLevelFloodednessNoise;
    private readonly IDensityFunction _fluidLevelSpreadNoise;
    private readonly IDensityFunction _lavaNoise;
    private readonly IDensityFunction _erosion;
    private readonly IDensityFunction _depth;

    private readonly IPositionalRandomFactory _positionalRandomFactory;
    private readonly IFluidPicker _globalFluidPicker;

    private readonly FluidStatus?[] _aquiferCache;

    /// <summary>The jittered centre of each grid cell, null until the cell is first reached.</summary>
    private readonly AquiferCentre?[] _aquiferCentreCache;

    private readonly int _skipSamplingAboveY;
    private readonly int _minGridX;
    private readonly int _minGridY;
    private readonly int _minGridZ;
    private readonly int _gridSizeX;
    private readonly int _gridSizeZ;

    private readonly uint _water;
    private readonly uint _lava;

    public NoiseBasedAquifer(INoiseChunkSurfaceView noiseChunk, int chunkX, int chunkZ, NoiseRouter router,
        IPositionalRandomFactory positionalRandomFactory, int minBlockY, int yBlockSize,
        IFluidPicker globalFluidPicker) {

        _noiseChunk = noiseChunk;
        _barrierNoise = router.Barrier;
        _fluidLevelFloodednessNoise = router.FluidLevelFloodedness;
        _fluidLevelSpreadNoise = router.FluidLevelSpread;
        _lavaNoise = router.Lava;
        _erosion = router.Erosion;
        _depth = router.Depth;
        _positionalRandomFactory = positionalRandomFactory;
        _globalFluidPicker = globalFluidPicker;

        _water = Block.Water.StateId;
        _lava = Block.Lava.StateId;

        int minBlockX = chunkX * 16;
        int minBlockZ = chunkZ * 16;
        int maxBlockX = minBlockX + 15;
        int maxBlockZ = minBlockZ + 15;

        _minGridX = GridX(minBlockX + SampleOffsetX);
        int maxGridX = GridX(maxBlockX + SampleOffsetX) + 1;
        _gridSizeX = maxGridX - _minGridX + 1;

        _minGridY = GridY(minBlockY + SampleOffsetY) - 1;
        int maxGridY = GridY(minBlockY + yBlockSize + SampleOffsetY) + 1;
        int gridSizeY = maxGridY - _minGridY + 1;

        _minGridZ = GridZ(minBlockZ + SampleOffsetZ);
        int maxGridZ = GridZ(maxBlockZ + SampleOffsetZ) + 1;
        _gridSizeZ = maxGridZ - _minGridZ + 1;

        int totalGridSize = _gridSizeX * gridSizeY * _gridSizeZ;
        _aquiferCache = new FluidStatus?[totalGridSize];
        _aquiferCentreCache = new AquiferCentre?[totalGridSize];

        // Above the highest terrain in range plus a margin nothing is ever underground, so the whole
        // grid search is skipped and the global fluid answers.
        int maxAdjustedSurfaceLevel = AdjustSurfaceLevel(MaxPreliminarySurfaceLevel(
            FromGridX(_minGridX, 0), FromGridZ(_minGridZ, 0), FromGridX(maxGridX, YRange), FromGridZ(maxGridZ, YRange)));
        int skipSamplingAboveGridY = GridY(maxAdjustedSurfaceLevel + YSpacing) + 1;
        _skipSamplingAboveY = FromGridY(skipSamplingAboveGridY, 11) - 1;
    }

    public bool ShouldScheduleFluidUpdate { get; private set; }

    private int MaxPreliminarySurfaceLevel(int minBlockX, int minBlockZ, int maxBlockX, int maxBlockZ) {
        int maxY = int.MinValue;

        for (int blockZ = minBlockZ; blockZ <= maxBlockZ; blockZ += 4) {
            for (int blockX = minBlockX; blockX <= maxBlockX; blockX += 4) {
                maxY = Math.Max(maxY, _noiseChunk.PreliminarySurfaceLevel(blockX, blockZ));
            }
        }

        return maxY;
    }

    private int GetIndex(int gridX, int gridY, int gridZ) {
        return ((gridY - _minGridY) * _gridSizeZ + (gridZ - _minGridZ)) * _gridSizeX + (gridX - _minGridX);
    }

    public uint? ComputeSubstance(IFunctionContext context, double density) {
        if (density > 0.0) {
            ShouldScheduleFluidUpdate = false;
            return null;
        }

        int posX = context.BlockX;
        int posY = context.BlockY;
        int posZ = context.BlockZ;

        FluidStatus globalFluid = _globalFluidPicker.ComputeFluid(posX, posY, posZ);

        if (posY > _skipSamplingAboveY) {
            ShouldScheduleFluidUpdate = false;
            return globalFluid.At(posY);
        }

        if (globalFluid.At(posY) == _lava) {
            // Nothing below the lava level ever becomes an aquifer, so the nether's lava sea is not
            // eight thousand grid searches per chunk.
            ShouldScheduleFluidUpdate = false;
            return _lava;
        }

        int xAnchor = GridX(posX + SampleOffsetX);
        int yAnchor = GridY(posY + SampleOffsetY);
        int zAnchor = GridZ(posZ + SampleOffsetZ);

        // The four nearest centres, kept as an insertion sorted four element list. Four rather than
        // two because the pressure terms compare three of them and the fluid tick check reads a fourth.
        int distance1 = int.MaxValue, distance2 = int.MaxValue;
        int distance3 = int.MaxValue, distance4 = int.MaxValue;
        int closest1 = 0, closest2 = 0, closest3 = 0, closest4 = 0;

        for (int x1 = 0; x1 <= 1; x1++) {
            for (int y1 = -1; y1 <= 1; y1++) {
                for (int z1 = 0; z1 <= 1; z1++) {
                    int spacedGridX = xAnchor + x1;
                    int spacedGridY = yAnchor + y1;
                    int spacedGridZ = zAnchor + z1;
                    int index = GetIndex(spacedGridX, spacedGridY, spacedGridZ);

                    if (_aquiferCentreCache[index] is not { } centre) {
                        // Drawn in x, y, z order: the three calls share one generator, so swapping
                        // them moves every aquifer in the world.
                        RandomSource random = _positionalRandomFactory.At(spacedGridX, spacedGridY, spacedGridZ);
                        centre = new AquiferCentre(
                            FromGridX(spacedGridX, random.NextInt(XRange)),
                            FromGridY(spacedGridY, random.NextInt(YRange)),
                            FromGridZ(spacedGridZ, random.NextInt(ZRange)));
                        _aquiferCentreCache[index] = centre;
                    }

                    int dx = centre.X - posX;
                    int dy = centre.Y - posY;
                    int dz = centre.Z - posZ;
                    int newDistance = dx * dx + dy * dy + dz * dz;

                    if (distance1 >= newDistance) {
                        (closest4, closest3, closest2, closest1) = (closest3, closest2, closest1, index);
                        (distance4, distance3, distance2, distance1) = (distance3, distance2, distance1, newDistance);
                    } else if (distance2 >= newDistance) {
                        (closest4, closest3, closest2) = (closest3, closest2, index);
                        (distance4, distance3, distance2) = (distance3, distance2, newDistance);
                    } else if (distance3 >= newDistance) {
                        (closest4, closest3) = (closest3, index);
                        (distance4, distance3) = (distance3, newDistance);
                    } else if (distance4 >= newDistance) {
                        closest4 = index;
                        distance4 = newDistance;
                    }
                }
            }
        }

        FluidStatus status1 = GetAquiferStatus(closest1);
        double similarity12 = Similarity(distance1, distance2);
        uint fluidState = status1.At(posY);

        if (similarity12 <= 0.0) {
            // Firmly inside one aquifer: no barrier to compute, only whether the boundary is close
            // enough to be worth a fluid tick.
            ShouldScheduleFluidUpdate = similarity12 >= FlowingUpdateSimilarity
                && !status1.Equals(GetAquiferStatus(closest2));
            return fluidState;
        }

        if (fluidState == _water
            && _globalFluidPicker.ComputeFluid(posX, posY - 1, posZ).At(posY - 1) == _lava) {
            ShouldScheduleFluidUpdate = true;
            return fluidState;
        }

        // NaN stands for "not sampled yet": the barrier noise is only worth computing once a pressure
        // term actually needs it, and up to three of them share the one sample.
        double barrierNoiseValue = double.NaN;

        FluidStatus status2 = GetAquiferStatus(closest2);
        double barrier12 = similarity12 * CalculatePressure(context, ref barrierNoiseValue, status1, status2);
        if (density + barrier12 > 0.0) {
            ShouldScheduleFluidUpdate = false;
            return null;
        }

        FluidStatus status3 = GetAquiferStatus(closest3);
        double similarity13 = Similarity(distance1, distance3);
        if (similarity13 > 0.0) {
            double barrier13 = similarity12 * similarity13
                * CalculatePressure(context, ref barrierNoiseValue, status1, status3);
            if (density + barrier13 > 0.0) {
                ShouldScheduleFluidUpdate = false;
                return null;
            }
        }

        double similarity23 = Similarity(distance2, distance3);
        if (similarity23 > 0.0) {
            double barrier23 = similarity12 * similarity23
                * CalculatePressure(context, ref barrierNoiseValue, status2, status3);
            if (density + barrier23 > 0.0) {
                ShouldScheduleFluidUpdate = false;
                return null;
            }
        }

        bool mayFlow12 = !status1.Equals(status2);
        bool mayFlow23 = similarity23 >= FlowingUpdateSimilarity && !status2.Equals(status3);
        bool mayFlow13 = similarity13 >= FlowingUpdateSimilarity && !status1.Equals(status3);

        if (mayFlow12 || mayFlow23 || mayFlow13) {
            ShouldScheduleFluidUpdate = true;
        } else {
            ShouldScheduleFluidUpdate = similarity13 >= FlowingUpdateSimilarity
                && Similarity(distance1, distance4) >= FlowingUpdateSimilarity
                && !status1.Equals(GetAquiferStatus(closest4));
        }

        return fluidState;
    }

    /// <summary>
    /// How close two centres are to being equidistant: one when they are, falling to zero twenty five
    /// squared units apart. Anything at or below zero means the first is clearly the nearer.
    /// </summary>
    private static double Similarity(int distanceSqr1, int distanceSqr2) {
        return 1.0 - (distanceSqr2 - distanceSqr1) / 25.0;
    }

    /// <summary>
    /// How much stone to add between two aquifers, from the difference in their levels and how far the
    /// position sits from the midpoint of that difference.
    /// </summary>
    /// <remarks>
    /// The two branches are deliberately lopsided. Above the average level the barrier tapers over
    /// 1.5 blocks where it is thickening and 2.5 where it is thinning; below it, over 3 and 10 with a
    /// bias of 3 on top. That is what makes a barrier thick underneath an aquifer and thin above it,
    /// so water does not pour down but a cave can open into it from the side.
    /// <p/>
    /// Water against lava always answers the maximum, which is what stops the two ever meeting.
    /// </remarks>
    private double CalculatePressure(IFunctionContext context, ref double barrierNoiseValue,
        FluidStatus status1, FluidStatus status2) {

        int posY = context.BlockY;
        uint type1 = status1.At(posY);
        uint type2 = status2.At(posY);

        if ((type1 == _lava && type2 == _water) || (type1 == _water && type2 == _lava)) {
            return 2.0;
        }

        int fluidYDiff = Math.Abs(status1.FluidLevel - status2.FluidLevel);
        if (fluidYDiff == 0) {
            return 0.0;
        }

        double averageFluidY = 0.5 * (status1.FluidLevel + status2.FluidLevel);
        double howFarAboveAverageFluidPoint = posY + 0.5 - averageFluidY;
        double distanceFromBarrierEdgeTowardsMiddle = fluidYDiff / 2.0 - Math.Abs(howFarAboveAverageFluidPoint);

        double gradient;
        if (howFarAboveAverageFluidPoint > 0.0) {
            double centrePoint = distanceFromBarrierEdgeTowardsMiddle;
            gradient = centrePoint > 0.0 ? centrePoint / 1.5 : centrePoint / 2.5;
        } else {
            double centrePoint = 3.0 + distanceFromBarrierEdgeTowardsMiddle;
            gradient = centrePoint > 0.0 ? centrePoint / 3.0 : centrePoint / 10.0;
        }

        // Well outside the barrier the noise cannot change the outcome, so it is not sampled at all.
        double noiseValue = 0.0;
        if (gradient is >= -2.0 and <= 2.0) {
            if (double.IsNaN(barrierNoiseValue)) {
                barrierNoiseValue = _barrierNoise.Compute(context);
            }

            noiseValue = barrierNoiseValue;
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
        if (_aquiferCache[index] is { } cached) {
            return cached;
        }

        AquiferCentre centre = _aquiferCentreCache[index]!.Value;
        FluidStatus status = ComputeFluid(centre.X, centre.Y, centre.Z);
        _aquiferCache[index] = status;
        return status;
    }

    /// <summary>
    /// Where one grid cell's aquifer sits. Vanilla packs this into a <c>BlockPos</c> long with a
    /// sentinel for "not chosen yet"; three fields and a nullable say the same thing without a
    /// coordinate range to get wrong.
    /// </summary>
    private readonly record struct AquiferCentre(int X, int Y, int Z);

    /// <summary>
    /// The level and fluid of one aquifer centre.
    /// </summary>
    /// <remarks>
    /// The thirteen surrounding chunks are consulted rather than only this one, because an aquifer
    /// whose cell reaches the surface anywhere nearby has to take the global fluid level: otherwise a
    /// pocket of water would be exposed on a hillside with nothing holding it in.
    /// </remarks>
    private FluidStatus ComputeFluid(int x, int y, int z) {
        FluidStatus globalFluid = _globalFluidPicker.ComputeFluid(x, y, z);

        int lowestPreliminarySurface = int.MaxValue;
        int topOfAquiferCell = y + YSpacing;
        int bottomOfAquiferCell = y - YSpacing;
        bool surfaceAtCentreIsUnderGlobalFluidLevel = false;

        foreach (int[] offset in SurfaceSamplingOffsetsInChunks) {
            int sampleX = x + (offset[0] << 4);
            int sampleZ = z + (offset[1] << 4);
            int preliminarySurfaceLevel = _noiseChunk.PreliminarySurfaceLevel(sampleX, sampleZ);
            int adjustedSurfaceLevel = AdjustSurfaceLevel(preliminarySurfaceLevel);
            bool start = offset[0] == 0 && offset[1] == 0;

            if (start && bottomOfAquiferCell > adjustedSurfaceLevel) {
                return globalFluid;
            }

            bool pokesAboveSurface = topOfAquiferCell > adjustedSurfaceLevel;
            if (pokesAboveSurface || start) {
                FluidStatus globalFluidAtSurface = _globalFluidPicker.ComputeFluid(sampleX, adjustedSurfaceLevel, sampleZ);
                if (globalFluidAtSurface.At(adjustedSurfaceLevel) != Block.Air.StateId) {
                    if (start) {
                        surfaceAtCentreIsUnderGlobalFluidLevel = true;
                    }

                    if (pokesAboveSurface) {
                        return globalFluidAtSurface;
                    }
                }
            }

            lowestPreliminarySurface = Math.Min(lowestPreliminarySurface, preliminarySurfaceLevel);
        }

        int fluidSurfaceLevel = ComputeSurfaceLevel(x, y, z, globalFluid, lowestPreliminarySurface,
            surfaceAtCentreIsUnderGlobalFluidLevel);

        return new FluidStatus(fluidSurfaceLevel, ComputeFluidType(x, y, z, globalFluid, fluidSurfaceLevel));
    }

    private static int AdjustSurfaceLevel(int preliminarySurfaceLevel) => preliminarySurfaceLevel + 8;

    private int ComputeSurfaceLevel(int x, int y, int z, FluidStatus globalFluid, int lowestPreliminarySurface,
        bool surfaceAtCentreIsUnderGlobalFluidLevel) {

        SinglePointContext context = new(x, y, z);

        double partiallyFloodedness;
        double fullyFloodedness;

        if (IsDeepDarkRegion(context)) {
            // The deep dark is dry by rule rather than by noise, which is what makes an ancient city
            // buildable.
            partiallyFloodedness = -1.0;
            fullyFloodedness = -1.0;
        } else {
            int distanceBelowSurface = lowestPreliminarySurface + 8 - y;
            double floodednessFactor = surfaceAtCentreIsUnderGlobalFluidLevel
                ? Mth.ClampedMap(distanceBelowSurface, 0.0, 64.0, 1.0, 0.0)
                : 0.0;

            double floodednessNoiseValue = Mth.Clamp(_fluidLevelFloodednessNoise.Compute(context), -1.0, 1.0);
            double fullyFloodedThreshold = Mth.Map(floodednessFactor, 1.0, 0.0, -0.3, 0.8);
            double partiallyFloodedThreshold = Mth.Map(floodednessFactor, 1.0, 0.0, -0.8, 0.4);

            partiallyFloodedness = floodednessNoiseValue - partiallyFloodedThreshold;
            fullyFloodedness = floodednessNoiseValue - fullyFloodedThreshold;
        }

        if (fullyFloodedness > 0.0) {
            return globalFluid.FluidLevel;
        }

        if (partiallyFloodedness > 0.0) {
            return ComputeRandomizedFluidSurfaceLevel(x, y, z, lowestPreliminarySurface);
        }

        return AquiferConstants.WayBelowMinY;
    }

    /// <summary><c>OverworldBiomeBuilder.isDeepDarkRegion</c>: heavily eroded and far underground.</summary>
    private bool IsDeepDarkRegion(IFunctionContext context) {
        return _erosion.Compute(context) < -0.225f && _depth.Compute(context) > 0.9f;
    }

    /// <summary>
    /// A level near the middle of a 40 block tall cell, jittered by a noise quantised to three blocks
    /// and never above the terrain.
    /// </summary>
    private int ComputeRandomizedFluidSurfaceLevel(int x, int y, int z, int lowestPreliminarySurface) {
        int fluidLevelCellX = Mth.FloorDiv(x, 16);
        int fluidLevelCellY = Mth.FloorDiv(y, 40);
        int fluidLevelCellZ = Mth.FloorDiv(z, 16);
        int fluidCellMiddleY = fluidLevelCellY * 40 + 20;

        // Sampled at the cell index, not at the block position, so a whole cell shares one level.
        double fluidLevelSpread = _fluidLevelSpreadNoise.Compute(
            new SinglePointContext(fluidLevelCellX, fluidLevelCellY, fluidLevelCellZ)) * 10.0;

        return Math.Min(lowestPreliminarySurface, fluidCellMiddleY + Mth.Quantize(fluidLevelSpread, 3));
    }

    /// <summary>Deep enough aquifers become lava, on a noise sampled per 64 by 40 by 64 cell.</summary>
    private uint ComputeFluidType(int x, int y, int z, FluidStatus globalFluid, int fluidSurfaceLevel) {
        if (fluidSurfaceLevel > -10 || fluidSurfaceLevel == AquiferConstants.WayBelowMinY
            || globalFluid.FluidType == _lava) {
            return globalFluid.FluidType;
        }

        double lavaNoiseValue = _lavaNoise.Compute(new SinglePointContext(
            Mth.FloorDiv(x, 64), Mth.FloorDiv(y, 40), Mth.FloorDiv(z, 64)));

        return Math.Abs(lavaNoiseValue) > 0.3 ? _lava : globalFluid.FluidType;
    }
}
