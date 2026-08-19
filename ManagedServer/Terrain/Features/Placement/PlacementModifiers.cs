using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Noise;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Placement;

/// <summary>
/// What a placed feature runs its origin through: how many, where in the chunk, how far up, and
/// whether at all.
/// </summary>
/// <remarks>
/// A modifier takes one position and answers a list of them, so the chain is a tree rather than a
/// pipeline. Vanilla builds it out of lazy <c>Stream.flatMap</c> calls, which means the walk is
/// <b>depth first</b>: the whole rest of the chain runs for the first position a modifier produces
/// before the second one is looked at. Since every modifier draws from the shared random, that order
/// decides every number after it, and a breadth first walk of the same modifiers generates a
/// different world.
/// </remarks>
public abstract record PlacementModifier {
    public abstract IReadOnlyList<Vec3<int>> GetPositions(PlacementContext context, RandomSource random,
        Vec3<int> origin);

    /// <summary>A modifier that either keeps its position or drops it, vanilla's <c>PlacementFilter</c>.</summary>
    public abstract record Filter : PlacementModifier {
        protected abstract bool ShouldPlace(PlacementContext context, RandomSource random, Vec3<int> origin);

        public sealed override IReadOnlyList<Vec3<int>> GetPositions(PlacementContext context,
            RandomSource random, Vec3<int> origin) {

            return ShouldPlace(context, random, origin) ? [origin] : [];
        }
    }

    /// <summary>
    /// A modifier that repeats its position, vanilla's <c>RepeatingPlacement</c>. The count is drawn
    /// once, before any of the copies goes on down the chain.
    /// </summary>
    public abstract record Repeating : PlacementModifier {
        protected abstract int Count(RandomSource random, Vec3<int> origin);

        public sealed override IReadOnlyList<Vec3<int>> GetPositions(PlacementContext context,
            RandomSource random, Vec3<int> origin) {

            int count = Count(random, origin);
            if (count <= 0) {
                return [];
            }

            Vec3<int>[] positions = new Vec3<int>[count];
            Array.Fill(positions, origin);
            return positions;
        }
    }

    /// <summary><c>CountPlacement</c>.</summary>
    public sealed record CountTimes(IIntProvider Amount) : Repeating {
        protected override int Count(RandomSource random, Vec3<int> origin) => Amount.Sample(random);
    }

    /// <summary>
    /// <c>InSquarePlacement</c>: scatter within the chunk. Two draws, x then z, and the y is left
    /// alone.
    /// </summary>
    public sealed record InSquare : PlacementModifier {
        public static readonly InSquare Instance = new();

        public override IReadOnlyList<Vec3<int>> GetPositions(PlacementContext context, RandomSource random,
            Vec3<int> origin) {

            int x = random.NextInt(16) + origin.X;
            int z = random.NextInt(16) + origin.Z;
            return [new Vec3<int>(x, origin.Y, z)];
        }
    }

    /// <summary>
    /// <c>HeightmapPlacement</c>: move the position to the top of the ground.
    /// </summary>
    /// <remarks>
    /// A height at or below the bottom of the world drops the position, which is what makes this the
    /// filter for a column that has nothing in it.
    /// </remarks>
    public sealed record Heightmap(HeightmapType Type) : PlacementModifier {
        public override IReadOnlyList<Vec3<int>> GetPositions(PlacementContext context, RandomSource random,
            Vec3<int> origin) {

            int height = context.Level.GetHeight(Type, origin.X, origin.Z);
            return height > context.Level.MinY ? [new Vec3<int>(origin.X, height, origin.Z)] : [];
        }
    }

    /// <summary><c>HeightRangePlacement</c>: replace the y outright.</summary>
    public sealed record HeightRange(HeightProvider Height) : PlacementModifier {
        public override IReadOnlyList<Vec3<int>> GetPositions(PlacementContext context, RandomSource random,
            Vec3<int> origin) {

            return [new Vec3<int>(origin.X, Height.Sample(random, context.Heights), origin.Z)];
        }
    }

    /// <summary>
    /// <c>RandomOffsetPlacement</c>. The horizontal provider is sampled <b>twice</b>, once for x and
    /// once for z, and the y draw sits between them.
    /// </summary>
    public sealed record RandomOffset(IIntProvider XzSpread, IIntProvider YSpread) : PlacementModifier {
        public override IReadOnlyList<Vec3<int>> GetPositions(PlacementContext context, RandomSource random,
            Vec3<int> origin) {

            int x = origin.X + XzSpread.Sample(random);
            int y = origin.Y + YSpread.Sample(random);
            int z = origin.Z + XzSpread.Sample(random);
            return [new Vec3<int>(x, y, z)];
        }
    }

    /// <summary><c>RarityFilter</c>: one in <c>chance</c>, drawn as a float.</summary>
    public sealed record RarityFilter(int Chance) : Filter {
        protected override bool ShouldPlace(PlacementContext context, RandomSource random, Vec3<int> origin) {
            return random.NextFloat() < 1.0f / Chance;
        }
    }

    /// <summary>
    /// <c>BiomeFilter</c>: whether the biome at the position lists this feature.
    /// </summary>
    /// <remarks>
    /// This is what keeps a jungle tree out of the plains beside it, and it is asked per position
    /// rather than per chunk, so a feature scattered across a biome border is placed only on its own
    /// side.
    /// </remarks>
    public sealed record BiomeFilter : Filter {
        public static readonly BiomeFilter Instance = new();

        protected override bool ShouldPlace(PlacementContext context, RandomSource random, Vec3<int> origin) {
            if (context.TopFeature is not { } feature) {
                throw new InvalidOperationException(
                    "A placed feature with a biome filter was placed without one, which means it was " +
                    "run as a nested feature rather than off a biome's list.");
            }

            return context.BiomeHasFeature(context.Level.GetBiome(origin.X, origin.Y, origin.Z), feature);
        }
    }

    /// <summary><c>BlockPredicateFilter</c>.</summary>
    public sealed record BlockPredicateFilter(BlockPredicate Predicate) : Filter {
        protected override bool ShouldPlace(PlacementContext context, RandomSource random, Vec3<int> origin) {
            return Predicate.Test(context.Level, origin);
        }
    }

    /// <summary>
    /// <c>SurfaceWaterDepthFilter</c>: how much water stands over the ground at this column.
    /// </summary>
    public sealed record SurfaceWaterDepthFilter(int MaxWaterDepth) : Filter {
        protected override bool ShouldPlace(PlacementContext context, RandomSource random, Vec3<int> origin) {
            int floor = context.Level.GetHeight(HeightmapType.OceanFloor, origin.X, origin.Z);
            int surface = context.Level.GetHeight(HeightmapType.WorldSurface, origin.X, origin.Z);
            return surface - floor <= MaxWaterDepth;
        }
    }

    /// <summary>
    /// <c>SurfaceRelativeThresholdFilter</c>: keep the position only if its y is within a window of
    /// the surface.
    /// </summary>
    public sealed record SurfaceRelativeThresholdFilter(HeightmapType Type, int MinInclusive, int MaxInclusive)
        : Filter {

        protected override bool ShouldPlace(PlacementContext context, RandomSource random, Vec3<int> origin) {
            // Widened, because the defaults are the extremes of int and the addition would overflow.
            long surface = context.Level.GetHeight(Type, origin.X, origin.Z);
            return surface + MinInclusive <= origin.Y && origin.Y <= surface + MaxInclusive;
        }
    }

    /// <summary>
    /// <c>NoiseThresholdCountPlacement</c>: one of two counts, chosen by a fixed noise.
    /// </summary>
    /// <remarks>
    /// The noise is <see cref="FeatureNoise.BiomeInfo"/>, which is seeded from a literal and not from
    /// the world, so the same coordinates give the same grass density in every world.
    /// </remarks>
    public sealed record NoiseThresholdCount(double NoiseLevel, int BelowNoise, int AboveNoise) : Repeating {
        protected override int Count(RandomSource random, Vec3<int> origin) {
            double value = FeatureNoise.BiomeInfo.GetValue(origin.X / 200.0, origin.Z / 200.0, false);
            return value < NoiseLevel ? BelowNoise : AboveNoise;
        }
    }

    /// <summary><c>NoiseBasedCountPlacement</c>: the count scales with the same noise.</summary>
    public sealed record NoiseBasedCount(int NoiseToCountRatio, double NoiseFactor, double NoiseOffset)
        : Repeating {

        protected override int Count(RandomSource random, Vec3<int> origin) {
            double value = FeatureNoise.BiomeInfo.GetValue(origin.X / NoiseFactor, origin.Z / NoiseFactor, false);
            return (int)Math.Ceiling((value + NoiseOffset) * NoiseToCountRatio);
        }
    }

    /// <summary>
    /// <c>CountOnEveryLayerPlacement</c>: keep going down the column placing on every floor there is,
    /// which is how the nether's vegetation covers ledges under ledges.
    /// </summary>
    /// <remarks>
    /// The outer loop repeats until a whole round finds nothing, and the count is redrawn on every
    /// round, so the number of draws depends on how many layers the terrain has.
    /// </remarks>
    public sealed record CountOnEveryLayer(IIntProvider Amount) : PlacementModifier {
        public override IReadOnlyList<Vec3<int>> GetPositions(PlacementContext context, RandomSource random,
            Vec3<int> origin) {

            List<Vec3<int>> positions = [];
            int layer = 0;
            bool foundAny;

            do {
                foundAny = false;
                int count = Amount.Sample(random);

                for (int i = 0; i < count; i++) {
                    int x = random.NextInt(16) + origin.X;
                    int z = random.NextInt(16) + origin.Z;
                    int startY = context.Level.GetHeight(HeightmapType.MotionBlocking, x, z);
                    int y = FindOnGroundY(context, x, startY, z, layer);

                    if (y != int.MaxValue) {
                        positions.Add(new Vec3<int>(x, y, z));
                        foundAny = true;
                    }
                }

                layer++;
            } while (foundAny);

            return positions;
        }

        /// <summary>
        /// The y of the <paramref name="layer"/>th floor below <paramref name="yStart"/>, or
        /// <see cref="int.MaxValue"/> when there are not that many.
        /// </summary>
        /// <remarks>
        /// A floor is an empty block over a non empty one, where empty counts water and lava as well
        /// as air, and bedrock is never a floor.
        /// </remarks>
        private static int FindOnGroundY(PlacementContext context, int x, int yStart, int z, int layer) {
            IFeatureLevel level = context.Level;
            uint current = level.GetState(x, yStart, z);
            int currentLayer = 0;

            for (int y = yStart; y >= level.MinY + 1; y--) {
                uint below = level.GetState(x, y - 1, z);

                if (!IsEmpty(level, below) && IsEmpty(level, current) && !IsBedrock(level, below)) {
                    if (currentLayer == layer) {
                        return y;
                    }

                    currentLayer++;
                }

                current = below;
            }

            return int.MaxValue;
        }

        private static bool IsEmpty(IFeatureLevel level, uint state) {
            return level.Blocks.IsAir(state) || FeatureFluids.IsWater(level, state)
                || FeatureFluids.IsLava(level, state);
        }

        private static bool IsBedrock(IFeatureLevel level, uint state) {
            return level.Registry.Blocks.GetByStateId(state).Identifier
                .Equals(Minecraft.Data.Generated.Block.Bedrock.Identifier);
        }
    }

    /// <summary>
    /// <c>EnvironmentScanPlacement</c>: walk in a direction until something matches, which is how a
    /// cave vine finds the ceiling over it.
    /// </summary>
    public sealed record EnvironmentScan(Vec3<int> Direction, BlockPredicate TargetCondition,
        BlockPredicate AllowedSearchCondition, int MaxSteps) : PlacementModifier {

        public override IReadOnlyList<Vec3<int>> GetPositions(PlacementContext context, RandomSource random,
            Vec3<int> origin) {

            IFeatureLevel level = context.Level;
            Vec3<int> pos = origin;

            if (!AllowedSearchCondition.Test(level, pos)) {
                return [];
            }

            for (int step = 0; step < MaxSteps; step++) {
                if (TargetCondition.Test(level, pos)) {
                    return [pos];
                }

                pos += Direction;
                if (!level.InWorld(pos.Y)) {
                    return [];
                }

                if (!AllowedSearchCondition.Test(level, pos)) {
                    break;
                }
            }

            // The last position is tested again on the way out, which is what makes a scan of one
            // step mean "here or the next one" rather than "here".
            return TargetCondition.Test(level, pos) ? [pos] : [];
        }
    }

    /// <summary>
    /// <c>FixedPlacement</c>: exact positions, kept only when they are in the chunk being decorated.
    /// </summary>
    public sealed record Fixed(IReadOnlyList<Vec3<int>> Positions) : PlacementModifier {
        public override IReadOnlyList<Vec3<int>> GetPositions(PlacementContext context, RandomSource random,
            Vec3<int> origin) {

            int chunkX = origin.X >> 4;
            int chunkZ = origin.Z >> 4;

            List<Vec3<int>> here = [];
            foreach (Vec3<int> position in Positions) {
                if ((position.X >> 4) == chunkX && (position.Z >> 4) == chunkZ) {
                    here.Add(position);
                }
            }

            return here;
        }
    }
}

/// <summary>
/// Noises the feature pass reads that are not seeded from the world.
/// </summary>
/// <remarks>
/// <c>Biome.BIOME_INFO_NOISE</c> is a static in the jar built from the literal seed 2345, so it is
/// one instance for the whole game rather than one per world. That is what makes the patchiness of
/// grass and flowers a property of the coordinates alone.
/// </remarks>
public static class FeatureNoise {
    public static readonly PerlinSimplexNoise BiomeInfo = new(new LegacyRandomSource(2345L), [0]);
}
