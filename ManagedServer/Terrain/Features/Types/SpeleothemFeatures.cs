using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>SpeleothemUtils</c>: how a pointed dripstone or sulfur spike is built out of its four thickness
/// states.
/// </summary>
/// <remarks>
/// The column is written from the <b>base outwards</b> in the tip's direction, which is why the same
/// code builds a stalactite hanging down and a stalagmite standing up: only the direction changes.
/// </remarks>
public static class SpeleothemUtils {
    /// <summary>The tag members a speleothem is allowed to grow out of, and the block it grows from.</summary>
    public static bool IsBase(IFeatureLevel level, int x, int y, int z, uint baseBlock,
        IReadOnlySet<Identifier> replaceable) {

        uint state = level.GetState(x, y, z);
        IBlock block = level.Registry.Blocks.GetByStateId(state);

        return block.Identifier.Equals(level.Registry.Blocks.GetByStateId(baseBlock).Identifier)
            || replaceable.Contains(block.Identifier);
    }

    public static bool IsEmptyOrWater(IFeatureLevel level, int x, int y, int z) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));
        return block.Air || block.Identifier.Equals(Block.Water.Identifier);
    }

    public static bool IsNeitherEmptyNorWater(IFeatureLevel level, int x, int y, int z) {
        return !IsEmptyOrWater(level, x, y, z);
    }

    /// <summary>
    /// Replaces one block with the base block if it is on the replaceable list, and says whether it
    /// did, so a caller laying a layer can stop at the first refusal.
    /// </summary>
    public static bool PlaceBaseBlockIfPossible(IFeatureLevel level, int x, int y, int z, uint baseBlock,
        IReadOnlySet<Identifier> replaceable) {

        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));

        if (!replaceable.Contains(block.Identifier)) {
            return false;
        }

        level.SetState(x, y, z, baseBlock);
        return true;
    }

    /// <summary>
    /// Grows a speleothem of the given length, provided the block behind its base holds it.
    /// </summary>
    /// <remarks>
    /// The thickness sequence is the whole of the shape: base, then middles, then a frustum, then the
    /// tip. A length of one is a bare tip and a length of two skips the middles entirely.
    /// </remarks>
    public static void Grow(IFeatureLevel level, Vec3<int> start, BlockFace tipDirection, int height,
        bool mergedTip, uint baseBlock, uint pointedBlock, IReadOnlySet<Identifier> replaceable) {

        Vec3<int> step = Placement.PlacementParser.Step(tipDirection);
        Vec3<int> behind = start - step;

        if (!IsBase(level, behind.X, behind.Y, behind.Z, baseBlock, replaceable)) {
            return;
        }

        Vec3<int> cursor = start;

        foreach (SpeleothemThickness thickness in Column(height, mergedTip)) {
            IBlock state = level.Registry.Blocks.GetByStateId(pointedBlock);

            if (state is IVerticallyDirected directed) {
                state = directed.WithVerticalDirection(
                    tipDirection == BlockFace.PosY ? VerticalDirection.Up : VerticalDirection.Down);
            }

            if (state is ISpeleothem speleothem) {
                state = speleothem.WithThickness(thickness);
            }

            // Waterlogged from what is already there, so a speleothem grown into a cave pool holds its
            // water rather than draining it.
            if (state is IWaterlogged waterloggable) {
                state = waterloggable.WithWaterlogged(
                    level.Registry.Blocks.GetByStateId(level.GetState(cursor.X, cursor.Y, cursor.Z))
                        .Identifier.Equals(Block.Water.Identifier));
            }

            level.SetState(cursor.X, cursor.Y, cursor.Z, state.StateId);
            cursor += step;
        }
    }

    private static IEnumerable<SpeleothemThickness> Column(int totalLength, bool mergedTip) {
        if (totalLength >= 3) {
            yield return SpeleothemThickness.Base;

            for (int i = 0; i < totalLength - 3; i++) {
                yield return SpeleothemThickness.Middle;
            }
        }

        if (totalLength >= 2) {
            yield return SpeleothemThickness.Frustum;
        }

        if (totalLength >= 1) {
            yield return mergedTip ? SpeleothemThickness.TipMerge : SpeleothemThickness.Tip;
        }
    }

    /// <summary>
    /// <c>Column.scan</c>: the floor and ceiling of the open space a position sits in.
    /// </summary>
    /// <remarks>
    /// Either end may be absent, which means the search ran out of range without meeting one. A cave
    /// taller than the search range therefore reads as open at that end rather than as closed.
    /// </remarks>
    public static (int? Floor, int? Ceiling)? Scan(IFeatureLevel level, int x, int y, int z, int range) {
        if (!IsEmptyOrWater(level, x, y, z)) {
            return null;
        }

        return (ScanDirection(level, x, y, z, range, -1), ScanDirection(level, x, y, z, range, 1));
    }

    private static int? ScanDirection(IFeatureLevel level, int x, int y, int z, int range, int step) {
        int cursor = y;

        for (int i = 1; i < range && IsEmptyOrWater(level, x, cursor, z); i++) {
            cursor += step;
        }

        return IsNeitherEmptyNorWater(level, x, cursor, z) ? cursor : null;
    }
}

/// <summary>
/// <c>SpeleothemFeature</c>: a single pointed dripstone or sulfur spike, and the patch of base block
/// it grows out of.
/// </summary>
/// <remarks>
/// The patch is what makes one look grown rather than stuck on: up to four horizontal spreads from the
/// root, each of which may spread again twice more in a fully random direction, so the dripstone block
/// around the base is an irregular blob.
/// </remarks>
public sealed record SpeleothemFeature(uint BaseBlock, uint PointedBlock,
    IReadOnlySet<Identifier> ReplaceableBlocks, float ChanceOfTallerGeneration,
    float ChanceOfDirectionalSpread, float ChanceOfSpreadRadius2, float ChanceOfSpreadRadius3)
    : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (TipDirection(level, random, origin) is not { } tip) {
            return false;
        }

        Vec3<int> step = Placement.PlacementParser.Step(tip);
        CreatePatchOfBaseBlocks(level, random, origin - step);

        Vec3<int> ahead = origin + step;
        int height = random.NextFloat() < ChanceOfTallerGeneration
            && SpeleothemUtils.IsEmptyOrWater(level, ahead.X, ahead.Y, ahead.Z)
            ? 2
            : 1;

        SpeleothemUtils.Grow(level, origin, tip, height, false, BaseBlock, PointedBlock,
            ReplaceableBlocks);

        return true;
    }

    /// <summary>
    /// Which way the tip points, decided by which side has something to hold it. With both, the coin
    /// flip is what puts stalactites and stalagmites in the same cave.
    /// </summary>
    private BlockFace? TipDirection(IFeatureLevel level, RandomSource random, Vec3<int> origin) {
        bool above = SpeleothemUtils.IsBase(level, origin.X, origin.Y + 1, origin.Z, BaseBlock,
            ReplaceableBlocks);

        bool below = SpeleothemUtils.IsBase(level, origin.X, origin.Y - 1, origin.Z, BaseBlock,
            ReplaceableBlocks);

        if (above && below) {
            return random.NextBoolean() ? BlockFace.NegY : BlockFace.PosY;
        }

        if (above) {
            return BlockFace.NegY;
        }

        return below ? BlockFace.PosY : null;
    }

    private void CreatePatchOfBaseBlocks(IFeatureLevel level, RandomSource random, Vec3<int> root) {
        SpeleothemUtils.PlaceBaseBlockIfPossible(level, root.X, root.Y, root.Z, BaseBlock,
            ReplaceableBlocks);

        foreach (BlockFace face in Directions.Horizontal) {
            if (random.NextFloat() > ChanceOfDirectionalSpread) {
                continue;
            }

            Vec3<int> first = root + Placement.PlacementParser.Step(face);
            SpeleothemUtils.PlaceBaseBlockIfPossible(level, first.X, first.Y, first.Z, BaseBlock,
                ReplaceableBlocks);

            if (random.NextFloat() > ChanceOfSpreadRadius2) {
                continue;
            }

            // Any of the six, not just the horizontal ones, so the patch can climb.
            Vec3<int> second = first + Placement.PlacementParser.Step(RandomFace(random));
            SpeleothemUtils.PlaceBaseBlockIfPossible(level, second.X, second.Y, second.Z, BaseBlock,
                ReplaceableBlocks);

            if (random.NextFloat() > ChanceOfSpreadRadius3) {
                continue;
            }

            Vec3<int> third = second + Placement.PlacementParser.Step(RandomFace(random));
            SpeleothemUtils.PlaceBaseBlockIfPossible(level, third.X, third.Y, third.Z, BaseBlock,
                ReplaceableBlocks);
        }
    }

    private static BlockFace RandomFace(RandomSource random) {
        return FeatureUtil.AllDirections[random.NextInt(FeatureUtil.AllDirections.Length)];
    }
}

/// <summary>
/// <c>SpeleothemClusterFeature</c>: a patch of cave floor and ceiling covered in matched stalagmites
/// and stalactites.
/// </summary>
/// <remarks>
/// Every column of the patch is scanned separately, so a cluster follows the shape of the cave rather
/// than being a block of the same height.
/// <p/>
/// <b>The pair is correlated, not independent.</b> Where a column has both a floor and a ceiling the
/// stalagmite's height is the stalactite's plus a small random difference, which is what makes the two
/// look like halves of one column. Only a column open at one end draws its height freely.
/// <p/>
/// Where the two would overlap they are cut to meet at one randomly chosen height, and a coin flip
/// then decides whether they merge into a single pillar.
/// </remarks>
public sealed record SpeleothemClusterFeature(uint BaseBlock, uint PointedBlock,
    IReadOnlySet<Identifier> ReplaceableBlocks, int FloorToCeilingSearchRange, IIntProvider Height,
    IIntProvider Radius, int MaxStalagmiteStalactiteHeightDiff, IIntProvider SpeleothemBlockLayerThickness,
    IFloatProvider Density, IFloatProvider Wetness, float ChanceOfSpeleothemAtMaxDistanceFromCenter,
    int MaxDistanceFromEdgeAffectingChanceOfSpeleothem, int MaxDistanceFromCenterAffectingHeightBias,
    float HeightDeviation) : ConfiguredFeature {

    private static readonly Identifier BaseStoneOverworld = "minecraft:base_stone_overworld";

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (!SpeleothemUtils.IsEmptyOrWater(level, origin.X, origin.Y, origin.Z)) {
            return false;
        }

        int height = Height.Sample(random);
        float wetness = Wetness.Sample(random);
        float density = Density.Sample(random);
        int radiusX = Radius.Sample(random);
        int radiusZ = Radius.Sample(random);

        for (int dx = -radiusX; dx <= radiusX; dx++) {
            for (int dz = -radiusZ; dz <= radiusZ; dz++) {
                double chance = ChanceOfSpeleothem(radiusX, radiusZ, dx, dz);
                PlaceColumn(level, random, origin.X + dx, origin.Y, origin.Z + dz, dx, dz, wetness,
                    chance, height, density);
            }
        }

        return true;
    }

    private void PlaceColumn(IFeatureLevel level, RandomSource random, int x, int y, int z, int dx,
        int dz, float chanceOfWater, double chanceOfSpeleothem, int clusterHeight, float density) {

        if (SpeleothemUtils.Scan(level, x, y, z, FloorToCeilingSearchRange) is not { } scan) {
            return;
        }

        (int? floor, int? ceiling) = scan;

        if (floor is null && ceiling is null) {
            return;
        }

        // The pool is laid before the speleothems and drops the floor by one, so a stalagmite in a wet
        // column starts under the water rather than in it.
        bool wantPool = random.NextFloat() < chanceOfWater;

        if (wantPool && floor is { } poolY && CanPlacePool(level, x, poolY, z)) {
            level.SetState(x, poolY, z, Block.Water.StateId);
            floor = poolY - 1;
        }

        bool wantStalactite = random.NextDouble() < chanceOfSpeleothem;
        int stalactiteHeight = 0;

        if (ceiling is { } ceilingY && wantStalactite && !IsLava(level, x, ceilingY, z)) {
            ReplaceWithBaseBlocks(level, random, x, ceilingY, z, 1);

            int maxHeight = floor is { } floorY ? Math.Min(clusterHeight, ceilingY - floorY) : clusterHeight;
            stalactiteHeight = SpeleothemHeight(random, dx, dz, density, maxHeight);
        }

        bool wantStalagmite = random.NextDouble() < chanceOfSpeleothem;
        int stalagmiteHeight = 0;

        if (floor is { } floorLevel && wantStalagmite && !IsLava(level, x, floorLevel, z)) {
            ReplaceWithBaseBlocks(level, random, x, floorLevel, z, -1);

            stalagmiteHeight = ceiling is not null
                ? Math.Max(0, stalactiteHeight + Mth.RandomBetweenInclusive(random,
                    -MaxStalagmiteStalactiteHeightDiff, MaxStalagmiteStalactiteHeightDiff))
                : SpeleothemHeight(random, dx, dz, density, clusterHeight);
        }

        int actualStalactite = stalactiteHeight;
        int actualStalagmite = stalagmiteHeight;

        if (ceiling is { } c && floor is { } f && c - stalactiteHeight <= f + stalagmiteHeight) {
            int lowestTop = Math.Max(c - stalactiteHeight, f + 1);
            int highestBottom = Math.Min(f + stalagmiteHeight, c - 1);
            int meeting = Mth.RandomBetweenInclusive(random, lowestTop, highestBottom + 1);

            actualStalactite = c - meeting;
            actualStalagmite = meeting - 1 - f;
        }

        int? columnHeight = ceiling is { } ch && floor is { } fh ? ch - fh - 1 : null;

        bool mergeTips = random.NextBoolean() && actualStalactite > 0 && actualStalagmite > 0
            && columnHeight is { } total && actualStalactite + actualStalagmite == total;

        if (ceiling is { } grow) {
            SpeleothemUtils.Grow(level, new Vec3<int>(x, grow - 1, z), BlockFace.NegY, actualStalactite,
                mergeTips, BaseBlock, PointedBlock, ReplaceableBlocks);
        }

        if (floor is { } growUp) {
            SpeleothemUtils.Grow(level, new Vec3<int>(x, growUp + 1, z), BlockFace.PosY, actualStalagmite,
                mergeTips, BaseBlock, PointedBlock, ReplaceableBlocks);
        }
    }

    /// <summary>
    /// Height falls off towards the middle of the cluster being tallest, with the draw itself biased
    /// rather than uniform, so a cluster has a few long spikes among many short ones.
    /// </summary>
    private int SpeleothemHeight(RandomSource random, int dx, int dz, float density, int maxHeight) {
        if (random.NextFloat() > density) {
            return 0;
        }

        int distance = Math.Abs(dx) + Math.Abs(dz);
        float mean = (float)Mth.ClampedMap(distance, 0.0, MaxDistanceFromCenterAffectingHeightBias,
            maxHeight / 2.0, 0.0);

        return (int)Mth.Clamp(IntProviders.Normal(random, mean, HeightDeviation), 0.0f, maxHeight);
    }

    /// <summary>
    /// A pool needs stone or water all around it and underneath, so it cannot be cut into the side of
    /// a drop and leak.
    /// </summary>
    /// <remarks>
    /// The three blocks it refuses are compared as <b>blocks</b> and not as states, which is what
    /// <c>state.is(block)</c> means. A speleothem already grown here is a pointed block of some other
    /// thickness than the configured one, so matching the exact state instead floods a column that
    /// already has a stalagmite in it, and the draws are identical either way.
    /// </remarks>
    private bool CanPlacePool(IFeatureLevel level, int x, int y, int z) {
        IBlock state = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));

        if (state.Identifier.Equals(Block.Water.Identifier)
            || state.Identifier.Equals(level.Registry.Blocks.GetByStateId(BaseBlock).Identifier)
            || state.Identifier.Equals(level.Registry.Blocks.GetByStateId(PointedBlock).Identifier)) {

            return false;
        }

        if (FeatureFluids.IsWater(level, level.GetState(x, y + 1, z))) {
            return false;
        }

        foreach (BlockFace face in Directions.Horizontal) {
            Vec3<int> step = Placement.PlacementParser.Step(face);

            if (!CanBeAdjacentToWater(level, x + step.X, y + step.Y, z + step.Z)) {
                return false;
            }
        }

        return CanBeAdjacentToWater(level, x, y - 1, z);
    }

    private static bool CanBeAdjacentToWater(IFeatureLevel level, int x, int y, int z) {
        uint state = level.GetState(x, y, z);
        return level.Blocks.IsIn(BaseStoneOverworld, state) || FeatureFluids.IsWater(level, state);
    }

    /// <summary>
    /// Lays the base block into the cave wall so a speleothem has something to grow out of, stopping
    /// at the first block that will not take it.
    /// </summary>
    private void ReplaceWithBaseBlocks(IFeatureLevel level, RandomSource random, int x, int y, int z,
        int step) {

        int thickness = SpeleothemBlockLayerThickness.Sample(random);

        for (int i = 0; i < thickness; i++) {
            if (!SpeleothemUtils.PlaceBaseBlockIfPossible(level, x, y, z, BaseBlock, ReplaceableBlocks)) {
                return;
            }

            y += step;
        }
    }

    /// <summary>
    /// Near certain in the middle of the patch and falling to the configured floor at its edge, which
    /// is what feathers a cluster out instead of ending it in a straight line.
    /// </summary>
    /// <remarks>
    /// The map is taken in <b>float</b> and widened afterwards, which is the overload the arguments
    /// select upstream. Computing it in double instead moves the answer by a few parts in a hundred
    /// million, and it is compared against a <c>nextDouble</c>.
    /// </remarks>
    private double ChanceOfSpeleothem(int radiusX, int radiusZ, int dx, int dz) {
        int fromEdge = Math.Min(radiusX - Math.Abs(dx), radiusZ - Math.Abs(dz));

        return Mth.ClampedMap((float)fromEdge, 0.0f, MaxDistanceFromEdgeAffectingChanceOfSpeleothem,
            ChanceOfSpeleothemAtMaxDistanceFromCenter, 1.0f);
    }

    private static bool IsLava(IFeatureLevel level, int x, int y, int z) {
        return level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier
            .Equals(Block.Lava.Identifier);
    }
}
