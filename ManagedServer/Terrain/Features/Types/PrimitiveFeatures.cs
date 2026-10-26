using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Placement;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>OverlayFeature</c>: every placed feature in the list at the same origin, in order.
/// </summary>
/// <remarks>
/// Unlike <c>sequence</c> a feature that places nothing does not stop the rest.
/// </remarks>
public sealed record OverlayFeature(IReadOnlyList<PlacedFeature> Features) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        PlacementContext nested = context.Placement.Nested();
        bool placedAny = false;

        foreach (PlacedFeature feature in Features) {
            placedAny |= feature.Place(nested, context.Random, context.Origin);
        }

        return placedAny;
    }
}

/// <summary>
/// <c>SingleBlockPillarFeature</c>: a column grown up or down while each block is replaceable and a
/// roll comes up, with an optional feature placed on its last block.
/// </summary>
/// <remarks>
/// The predicate is tested before the roll, so a column stopped by what is in the way does not spend
/// one. The cap goes where the last block was set, or one step back from the origin when none was.
/// </remarks>
public sealed record SingleBlockPillarFeature(BlockStateProvider Block, BlockPredicate CanReplace,
    BlockFace Direction, float ChanceToContinue, PlacedFeature? CapFeature) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> step = PlacementParser.Step(Direction);
        Vec3<int> pos = context.Origin;

        while (CanReplace.Test(level, pos.X, pos.Y, pos.Z) && random.NextFloat() < ChanceToContinue
            && level.InWorld(pos.Y)) {

            level.SetState(pos.X, pos.Y, pos.Z, Block.GetState(level, random, pos.X, pos.Y, pos.Z).StateId);
            pos += step;
        }

        pos -= step;
        CapFeature?.Place(context.Placement.Nested(), random, pos);
        return true;
    }
}

/// <summary>
/// <c>ProjectedRandomPatchySquare</c>: a square of blocks thinning towards its corners, each dropped
/// down through what <see cref="ProjectThrough"/> accepts.
/// </summary>
/// <remarks>
/// One <c>nextInt</c> per position whatever it decides, and a position whose provider returns nothing
/// is skipped after its own draws. A position drops at least once whenever the block below it passes,
/// even with a <see cref="MaxProjectionHeight"/> of zero, because the count is checked after the move.
/// </remarks>
public sealed record ProjectedRandomPatchySquareFeature(BlockStateProvider Block, BlockPredicate ProjectThrough,
    IIntProvider Size, int MaxProjectionHeight) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        int size = Size.Sample(random);
        int bound = size * size + 1;

        for (int dx = -size; dx <= size; dx++) {
            for (int dz = -size; dz <= size; dz++) {
                int probability = Math.Abs(dx) * Math.Abs(dz);
                if (random.NextInt(bound) >= bound - probability) {
                    continue;
                }

                int x = origin.X + dx;
                int y = origin.Y;
                int z = origin.Z + dz;
                int drop = MaxProjectionHeight;

                while (ProjectThrough.Test(level, x, y - 1, z)) {
                    y--;
                    if (--drop <= 0) {
                        break;
                    }
                }

                IBlock? state = Block.GetOptionalState(level, random, x, y, z);
                if (state is not null) {
                    level.SetState(x, y, z, state.StateId);
                }
            }
        }

        return true;
    }
}

/// <summary>
/// <c>RandomNeighborSpreadFeature</c>: a block at the origin, then attempts around it that each
/// place only where exactly one neighbour is already accepted, which grows a ragged blob.
/// </summary>
/// <remarks>
/// An attempt's offset is drawn x, then y, then z, all before the replace test. The neighbour count
/// runs in <c>Direction.values()</c> order and stops at the second hit; nothing in it draws.
/// </remarks>
public sealed record RandomNeighborSpreadFeature(BlockStateProvider Block, IReadOnlySet<Identifier> AcceptedNeighbors,
    BlockPredicate CanReplace, IIntProvider Attempts, IIntProvider XzOffset, IIntProvider YOffset)
    : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        level.SetState(origin.X, origin.Y, origin.Z,
            Block.GetState(level, random, origin.X, origin.Y, origin.Z).StateId);

        int attempts = Attempts.Sample(random);

        for (int i = 0; i < attempts; i++) {
            int x = origin.X + XzOffset.Sample(random);
            int y = origin.Y + YOffset.Sample(random);
            int z = origin.Z + XzOffset.Sample(random);

            if (!CanReplace.Test(level, x, y, z)) {
                continue;
            }

            int neighbours = 0;

            foreach (BlockFace face in Directions.All) {
                Vec3<int> step = PlacementParser.Step(face);
                Identifier neighbour = level.Registry.Blocks
                    .GetByStateId(level.GetState(x + step.X, y + step.Y, z + step.Z)).Identifier;

                if (AcceptedNeighbors.Contains(neighbour)) {
                    neighbours++;
                }

                if (neighbours > 1) {
                    break;
                }
            }

            if (neighbours == 1) {
                level.SetState(x, y, z, Block.GetState(level, random, x, y, z).StateId);
            }
        }

        return true;
    }
}

/// <summary>
/// <c>SteppedColumnClusterFeature</c>: a cluster of columns whose height falls off with manhattan
/// distance from the origin, each column a small square whose height falls off again across it.
/// </summary>
/// <remarks>
/// The column positions come from <c>BlockPos.randomBetweenClosed</c>, which is lazy: each position's
/// three draws, the y one included although the range is a single value, happen just before that
/// column is built, and its <see cref="ColumnReach"/> draw only when it is close enough to be built.
/// The square inside a column walks <c>BlockPos.betweenClosed</c>, x innermost.
/// </remarks>
public sealed record SteppedColumnClusterFeature(BlockStateProvider Block, BlockPredicate ContinueThrough,
    BlockPredicate CanReplace, IReadOnlySet<Identifier> CannotPlaceOn, IIntProvider ClusterReach,
    IIntProvider ColumnCount, IIntProvider ColumnReach, IIntProvider Height) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (!CanPlaceAt(level, origin.X, origin.Y, origin.Z)) {
            return false;
        }

        int columnHeight = Height.Sample(random);
        int clusterReach = Math.Min(columnHeight, ClusterReach.Sample(random));
        int count = ColumnCount.Sample(random);
        int width = clusterReach * 2 + 1;
        bool placed = false;

        for (int i = 0; i < count; i++) {
            int x = origin.X - clusterReach + random.NextInt(width);
            int y = origin.Y + random.NextInt(1);
            int z = origin.Z - clusterReach + random.NextInt(width);

            int blocksToPlaceY = columnHeight - Manhattan(x - origin.X, y - origin.Y, z - origin.Z);
            if (blocksToPlaceY >= 0) {
                placed |= PlaceColumn(level, random, x, y, z, blocksToPlaceY, ColumnReach.Sample(random));
            }
        }

        return placed;
    }

    private bool PlaceColumn(IFeatureLevel level, RandomSource random, int originX, int originY, int originZ,
        int columnHeight, int reach) {

        bool placedAny = false;

        for (int z = originZ - reach; z <= originZ + reach; z++) {
            for (int x = originX - reach; x <= originX + reach; x++) {
                int stepLimit = Manhattan(x - originX, 0, z - originZ);
                int? start = CanReplace.Test(level, x, originY, z)
                    ? FindSurface(level, x, originY, z, stepLimit)
                    : FindAir(level, x, originY, z, stepLimit);

                if (start is not { } y) {
                    continue;
                }

                for (int blocksY = columnHeight - stepLimit / 2; blocksY >= 0; blocksY--) {
                    if (CanReplace.Test(level, x, y, z)) {
                        level.SetState(x, y, z, Block.GetState(level, random, x, y, z).StateId);
                        y++;
                        placedAny = true;
                    } else {
                        if (!ContinueThrough.Test(level, x, y, z)) {
                            break;
                        }

                        y++;
                    }
                }
            }
        }

        return placedAny;
    }

    private int? FindSurface(IFeatureLevel level, int x, int y, int z, int limit) {
        while (y > level.MinY + 1 && limit > 0) {
            limit--;
            if (CanPlaceAt(level, x, y, z)) {
                return y;
            }

            y--;
        }

        return null;
    }

    private bool CanPlaceAt(IFeatureLevel level, int x, int y, int z) {
        if (!CanReplace.Test(level, x, y, z)) {
            return false;
        }

        uint below = level.GetState(x, y - 1, z);
        return !level.Blocks.IsAir(below)
            && !CannotPlaceOn.Contains(level.Registry.Blocks.GetByStateId(below).Identifier);
    }

    /// <summary>
    /// <c>level.getMaxY()</c> is the highest block, one below <see cref="IFeatureLevel.MaxY"/>, so the
    /// bound is exclusive here.
    /// </summary>
    private int? FindAir(IFeatureLevel level, int x, int y, int z, int limit) {
        while (y < level.MaxY && limit > 0) {
            limit--;
            uint state = level.GetState(x, y, z);

            if (CannotPlaceOn.Contains(level.Registry.Blocks.GetByStateId(state).Identifier)) {
                return null;
            }

            if (level.Blocks.IsAir(state)) {
                return y;
            }

            y++;
        }

        return null;
    }

    private static int Manhattan(int dx, int dy, int dz) {
        return Math.Abs(dx) + Math.Abs(dy) + Math.Abs(dz);
    }
}
