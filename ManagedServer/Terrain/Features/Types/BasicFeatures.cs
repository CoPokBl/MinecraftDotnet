using Minecraft.Placement.Helpers;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Fluids;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary><c>NoneFeature</c>: places nothing and reports success.</summary>
/// <remarks>
/// It has to report success rather than failure: a <c>sequence</c> stops at the first feature that
/// says it placed nothing, and <c>no_op</c> is used to fill a slot in one.
/// </remarks>
public sealed record NoOpFeature : ConfiguredFeature {
    public static readonly NoOpFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) => true;
}

/// <summary>
/// <c>SimpleBlockFeature</c>: one block, if it would survive there.
/// </summary>
/// <remarks>
/// This is what grass, flowers and most single block vegetation are placed by. The scattering is not
/// here: it is the <c>count</c> and <c>offset</c> modifiers on the placed feature, which is why the
/// configured feature is just a state provider.
/// <p/>
/// A two block tall plant writes both halves, since placing only the lower one gives a plant the
/// client draws with no top.
/// </remarks>
public sealed record SimpleBlockFeature(BlockStateProvider ToPlace) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;

        IBlock? state = ToPlace.GetOptionalState(level, context.Random, origin.X, origin.Y, origin.Z);
        if (state is null) {
            return false;
        }

        if (!FeatureSurvival.CanSurvive(state, level, origin.X, origin.Y, origin.Z)) {
            return false;
        }

        if (state is IDoubleHalved doubled) {
            Vec3<int> above = origin.WithY(origin.Y + 1);
            uint aboveState = level.GetState(above.X, above.Y, above.Z);

            // Air, or something replaceable holding the same fluid, so tall seagrass places under
            // water and a tall flower over short grass.
            if (!level.Blocks.IsAir(aboveState)
                && (FluidState.Of(state) != FluidState.Of(level.Registry.Blocks.GetByStateId(aboveState))
                    || !level.Blocks.IsReplaceable(aboveState))) {
                return false;
            }

            // DoublePlantBlock.placeAt: each half takes its waterlogging from the block it replaces.
            level.SetState(origin.X, origin.Y, origin.Z,
                CopyWaterloggedFrom(level, origin, doubled.WithHalf(BlockHalf.Lower)).StateId);
            level.SetState(above.X, above.Y, above.Z,
                CopyWaterloggedFrom(level, above, doubled.WithHalf(BlockHalf.Upper)).StateId);
            return true;
        }

        level.SetState(origin.X, origin.Y, origin.Z, state.StateId);
        return true;
    }

    /// <summary><c>DoublePlantBlock.copyWaterloggedFrom</c>, which asks <c>isWaterAt</c>, flowing or not.</summary>
    private static IBlock CopyWaterloggedFrom(IFeatureLevel level, Vec3<int> pos, IBlock state) {
        return state is IWaterlogged waterlogged
            ? waterlogged.WithWaterlogged(FeatureFluids.IsWater(level, level.GetState(pos.X, pos.Y, pos.Z)))
            : state;
    }
}

/// <summary>
/// <c>RandomSelectorFeature</c>: the first entry whose roll comes up, else the default.
/// </summary>
/// <remarks>
/// The rolls stop at the first hit, so an entry late in the list is only reached when every earlier
/// one missed. That is what makes a tree set's chances cumulative rather than independent.
/// </remarks>
public sealed record RandomSelectorFeature(IReadOnlyList<(float Chance, PlacedFeature Feature)> Features,
    PlacedFeature Default) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        PlacementContext nested = context.Placement.Nested();

        foreach ((float chance, PlacedFeature feature) in Features) {
            if (context.Random.NextFloat() < chance) {
                return feature.Place(nested, context.Random, context.Origin);
            }
        }

        return Default.Place(nested, context.Random, context.Origin);
    }
}

/// <summary><c>SimpleRandomSelectorFeature</c>: one of the list, flat.</summary>
public sealed record SimpleRandomSelectorFeature(IReadOnlyList<PlacedFeature> Features) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        int index = context.Random.NextInt(Features.Count);
        return Features[index].Place(context.Placement.Nested(), context.Random, context.Origin);
    }
}

/// <summary><c>RandomBooleanSelectorFeature</c>: a coin flip between two.</summary>
public sealed record RandomBooleanSelectorFeature(PlacedFeature IfTrue, PlacedFeature IfFalse)
    : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        PlacedFeature chosen = context.Random.NextBoolean() ? IfTrue : IfFalse;
        return chosen.Place(context.Placement.Nested(), context.Random, context.Origin);
    }
}

/// <summary>
/// <c>SequenceFeature</c>: every feature in order, stopping at the first that places nothing.
/// </summary>
public sealed record SequenceFeature(IReadOnlyList<PlacedFeature> Features) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        PlacementContext nested = context.Placement.Nested();

        foreach (PlacedFeature feature in Features) {
            if (!feature.Place(nested, context.Random, context.Origin)) {
                return false;
            }
        }

        return true;
    }
}

/// <summary>One of an ore feature's target and replacement pairs.</summary>
public sealed record OreTarget(BlockPredicate Target, IBlock State);

/// <summary>
/// <c>OreFeature</c>: a blob of ore, built as a line of overlapping spheres.
/// </summary>
/// <remarks>
/// The shape is a segment between two points spread either side of the origin, with the sphere radius
/// peaking in the middle. Spheres that swallow one another are cancelled first, which is what stops
/// the middle of a big vein being written several times.
/// <p/>
/// <c>discard_chance_on_air_exposure</c> is what keeps coal out of the walls of a cave: a candidate
/// beside air is dropped with that probability. The roll happens per position and only when the chance
/// is strictly between zero and one, so the ordinary case costs nothing.
/// </remarks>
public sealed record OreFeature(int Size, float DiscardChanceOnAirExposure, IReadOnlyList<OreTarget> Targets)
    : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;
        IFeatureLevel level = context.Level;

        float direction = random.NextFloat() * (float)Math.PI;
        float spreadXz = Size / 8.0f;
        int maxRadius = Mth.Ceil((Size / 16.0f * 2.0f + 1.0f) / 2.0f);

        double x0 = origin.X + Math.Sin(direction) * spreadXz;
        double x1 = origin.X - Math.Sin(direction) * spreadXz;
        double z0 = origin.Z + Math.Cos(direction) * spreadXz;
        double z1 = origin.Z - Math.Cos(direction) * spreadXz;

        double y0 = origin.Y + random.NextInt(3) - 2;
        double y1 = origin.Y + random.NextInt(3) - 2;

        int xStart = origin.X - Mth.Ceil(spreadXz) - maxRadius;
        int yStart = origin.Y - 2 - maxRadius;
        int zStart = origin.Z - Mth.Ceil(spreadXz) - maxRadius;
        int sizeXz = 2 * (Mth.Ceil(spreadXz) + maxRadius);
        int sizeY = 2 * (2 + maxRadius);

        // A vein whose whole box is above the terrain is skipped before any of the shape is built.
        for (int x = xStart; x <= xStart + sizeXz; x++) {
            for (int z = zStart; z <= zStart + sizeXz; z++) {
                if (yStart <= level.GetHeight(HeightmapType.OceanFloorWorldgen, x, z)) {
                    return DoPlace(level, random, x0, x1, z0, z1, y0, y1, xStart, yStart, zStart, sizeXz,
                        sizeY);
                }
            }
        }

        return false;
    }

    private bool DoPlace(IFeatureLevel level, RandomSource random, double x0, double x1, double z0,
        double z1, double y0, double y1, int xStart, int yStart, int zStart, int sizeXz, int sizeY) {

        int placed = 0;
        bool[] tested = new bool[sizeXz * sizeY * sizeXz];
        double[] data = new double[Size * 4];

        for (int i = 0; i < Size; i++) {
            float step = (float)i / Size;
            double scale = random.NextDouble() * Size / 16.0;

            data[i * 4] = Mth.Lerp(step, x0, x1);
            data[i * 4 + 1] = Mth.Lerp(step, y0, y1);
            data[i * 4 + 2] = Mth.Lerp(step, z0, z1);
            data[i * 4 + 3] = ((Mth.Sin((float)Math.PI * step) + 1.0f) * scale + 1.0) / 2.0;
        }

        // A sphere entirely inside another is given a negative radius, which is the marker for "skip".
        for (int a = 0; a < Size - 1; a++) {
            if (data[a * 4 + 3] <= 0.0) {
                continue;
            }

            for (int b = a + 1; b < Size; b++) {
                if (data[b * 4 + 3] <= 0.0) {
                    continue;
                }

                double dx = data[a * 4] - data[b * 4];
                double dy = data[a * 4 + 1] - data[b * 4 + 1];
                double dz = data[a * 4 + 2] - data[b * 4 + 2];
                double dr = data[a * 4 + 3] - data[b * 4 + 3];

                if (dr * dr > dx * dx + dy * dy + dz * dz) {
                    if (dr > 0.0) {
                        data[b * 4 + 3] = -1.0;
                    } else {
                        data[a * 4 + 3] = -1.0;
                    }
                }
            }
        }

        for (int i = 0; i < Size; i++) {
            double radius = data[i * 4 + 3];
            if (radius < 0.0) {
                continue;
            }

            double centreX = data[i * 4];
            double centreY = data[i * 4 + 1];
            double centreZ = data[i * 4 + 2];

            int xMin = Math.Max(Mth.Floor(centreX - radius), xStart);
            int yMin = Math.Max(Mth.Floor(centreY - radius), yStart);
            int zMin = Math.Max(Mth.Floor(centreZ - radius), zStart);
            int xMax = Math.Max(Mth.Floor(centreX + radius), xMin);
            int yMax = Math.Max(Mth.Floor(centreY + radius), yMin);
            int zMax = Math.Max(Mth.Floor(centreZ + radius), zMin);

            for (int x = xMin; x <= xMax; x++) {
                double xd = (x + 0.5 - centreX) / radius;
                if (xd * xd >= 1.0) {
                    continue;
                }

                for (int y = yMin; y <= yMax; y++) {
                    double yd = (y + 0.5 - centreY) / radius;
                    if (xd * xd + yd * yd >= 1.0) {
                        continue;
                    }

                    for (int z = zMin; z <= zMax; z++) {
                        double zd = (z + 0.5 - centreZ) / radius;
                        if (xd * xd + yd * yd + zd * zd >= 1.0 || !level.InWorld(y)) {
                            continue;
                        }

                        int index = x - xStart + (y - yStart) * sizeXz + (z - zStart) * sizeXz * sizeY;
                        if (index < 0 || index >= tested.Length || tested[index]) {
                            continue;
                        }

                        tested[index] = true;

                        if (TryPlaceOre(level, random, x, y, z)) {
                            placed++;
                        }
                    }
                }
            }
        }

        return placed > 0;
    }

    private bool TryPlaceOre(IFeatureLevel level, RandomSource random, int x, int y, int z) {
        uint existing = level.GetState(x, y, z);

        foreach (OreTarget target in Targets) {
            if (!target.Target.Test(level, x, y, z)) {
                continue;
            }

            if (!ShouldSkipAirCheck(random) && IsAdjacentToAir(level, x, y, z)) {
                continue;
            }

            level.SetState(x, y, z, target.State.StateId);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Whether the air check can be skipped. Zero means always, one means never, and only a value
    /// between the two draws.
    /// </summary>
    private bool ShouldSkipAirCheck(RandomSource random) {
        if (DiscardChanceOnAirExposure <= 0.0f) {
            return true;
        }

        if (DiscardChanceOnAirExposure >= 1.0f) {
            return false;
        }

        return random.NextFloat() >= DiscardChanceOnAirExposure;
    }

    internal static bool IsAdjacentToAir(IFeatureLevel level, int x, int y, int z) {
        return level.Blocks.IsAir(level.GetState(x - 1, y, z))
            || level.Blocks.IsAir(level.GetState(x + 1, y, z))
            || level.Blocks.IsAir(level.GetState(x, y - 1, z))
            || level.Blocks.IsAir(level.GetState(x, y + 1, z))
            || level.Blocks.IsAir(level.GetState(x, y, z - 1))
            || level.Blocks.IsAir(level.GetState(x, y, z + 1));
    }
}

/// <summary>
/// <c>ScatteredOreFeature</c>: single blocks rather than a blob, which is what the small copper and
/// the nether gold veins are.
/// </summary>
/// <remarks>
/// The spread grows with the attempt index up to seven, so the first few land near the origin and the
/// rest fan out. Each axis is a triangular draw, which is what clusters them towards the middle.
/// </remarks>
public sealed record ScatteredOreFeature(int Size, float DiscardChanceOnAirExposure,
    IReadOnlyList<OreTarget> Targets) : ConfiguredFeature {

    private const int MaxDistanceFromOrigin = 7;

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        int tries = random.NextInt(Size + 1);

        for (int i = 0; i < tries; i++) {
            int spread = Math.Min(i, MaxDistanceFromOrigin);
            Vec3<int> pos = origin + new Vec3<int>(Offset(random, spread), Offset(random, spread),
                Offset(random, spread));

            foreach (OreTarget target in Targets) {
                if (!target.Target.Test(level, pos)) {
                    continue;
                }

                if (!ShouldSkipAirCheck(random) && OreFeature.IsAdjacentToAir(level, pos.X, pos.Y, pos.Z)) {
                    continue;
                }

                level.SetState(pos.X, pos.Y, pos.Z, target.State.StateId);
                break;
            }
        }

        return true;
    }

    private static int Offset(RandomSource random, int maxDistance) {
        return Mth.JavaRound((random.NextFloat() - random.NextFloat()) * maxDistance);
    }

    private bool ShouldSkipAirCheck(RandomSource random) {
        if (DiscardChanceOnAirExposure <= 0.0f) {
            return true;
        }

        if (DiscardChanceOnAirExposure >= 1.0f) {
            return false;
        }

        return random.NextFloat() >= DiscardChanceOnAirExposure;
    }
}

/// <summary>
/// <c>DiskFeature</c>: the sand, gravel and clay patches in a river bed.
/// </summary>
/// <remarks>
/// Each column is walked top down, and the run of replaceable blocks is what gets written, so a disc
/// follows the shape of the bed rather than being a flat slab.
/// </remarks>
public sealed record DiskFeature(BlockStateProvider StateProvider, BlockPredicate Target, IIntProvider Radius,
    int HalfHeight) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        Vec3<int> origin = context.Origin;
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;

        bool placedAny = false;
        int top = origin.Y + HalfHeight;
        int bottom = origin.Y - HalfHeight - 1;
        int radius = Radius.Sample(random);

        for (int x = origin.X - radius; x <= origin.X + radius; x++) {
            for (int z = origin.Z - radius; z <= origin.Z + radius; z++) {
                int dx = x - origin.X;
                int dz = z - origin.Z;

                if (dx * dx + dz * dz <= radius * radius) {
                    placedAny |= PlaceColumn(level, random, top, bottom, x, z);
                }
            }
        }

        return placedAny;
    }

    private bool PlaceColumn(IFeatureLevel level, RandomSource random, int top, int bottom, int x, int z) {
        bool placedAny = false;

        for (int y = top; y > bottom; y--) {
            if (!Target.Test(level, x, y, z)) {
                continue;
            }

            IBlock? state = StateProvider.GetOptionalState(level, random, x, y, z);
            if (state is null) {
                continue;
            }

            level.SetState(x, y, z, state.StateId);
            placedAny = true;
        }

        return placedAny;
    }
}

/// <summary>
/// <c>BlockPileFeature</c>: a low heap, which is what a hay or melon pile in a village is and what
/// the snow and ice piles in a snowy biome are.
/// </summary>
/// <remarks>
/// The radius test is against a fresh pair of draws per position rather than a fixed radius, so the
/// edge of the pile is ragged. The <c>0.031</c> second chance is what scatters a few blocks beyond it.
/// </remarks>
public sealed record BlockPileFeature(BlockStateProvider StateProvider) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        Vec3<int> origin = context.Origin;
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;

        if (origin.Y < level.MinY + 5) {
            return false;
        }

        int xRadius = 2 + random.NextInt(2);
        int zRadius = 2 + random.NextInt(2);

        // The box is walked as BlockPos.betweenClosed walks one, x fastest and z slowest. Every
        // position takes a draw, so any other nesting spends the same numbers on different blocks.
        for (int z = origin.Z - zRadius; z <= origin.Z + zRadius; z++) {
            for (int y = origin.Y; y <= origin.Y + 1; y++) {
                for (int x = origin.X - xRadius; x <= origin.X + xRadius; x++) {
                    int dx = origin.X - x;
                    int dz = origin.Z - z;

                    if (dx * dx + dz * dz <= random.NextFloat() * 10.0f - random.NextFloat() * 6.0f) {
                        TryPlace(level, random, new Vec3<int>(x, y, z));
                    } else if (random.NextFloat() < 0.031) {
                        TryPlace(level, random, new Vec3<int>(x, y, z));
                    }
                }
            }
        }

        return true;
    }

    private void TryPlace(IFeatureLevel level, RandomSource random, Vec3<int> pos) {
        if (!level.Blocks.IsAir(level.GetState(pos.X, pos.Y, pos.Z)) || !MayPlaceOn(level, random, pos)) {
            return;
        }

        level.SetState(pos.X, pos.Y, pos.Z,
            StateProvider.GetState(level, random, pos.X, pos.Y, pos.Z).StateId);
    }

    /// <summary>
    /// A pile settles on anything with a sturdy top, and on a dirt path only half the time, which is
    /// what leaves a village's paths visible under the hay.
    /// </summary>
    private static bool MayPlaceOn(IFeatureLevel level, RandomSource random, Vec3<int> pos) {
        Vec3<int> below = pos.WithY(pos.Y - 1);
        IBlock belowState = level.Registry.Blocks.GetByStateId(level.GetState(below.X, below.Y, below.Z));

        if (belowState.Identifier.Equals(Block.DirtPath.Identifier)) {
            return random.NextBoolean();
        }

        return ShapeSupport.IsFaceSturdy(belowState, BlockFace.PosY);
    }
}
