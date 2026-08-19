using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>WeightedRandomSelectorFeature</c>: one of a weighted list, or nothing.
/// </summary>
/// <remarks>
/// Unlike <c>random_selector</c> there is no fallback: an empty draw places nothing and reports
/// failure, which is what lets a list of low weights leave most positions bare.
/// </remarks>
public sealed record WeightedRandomSelectorFeature(
    IReadOnlyList<(PlacedFeature Feature, int Weight)> Features) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        int total = Features.Sum(entry => entry.Weight);
        if (total <= 0) {
            return false;
        }

        int roll = context.Random.NextInt(total);

        foreach ((PlacedFeature feature, int weight) in Features) {
            roll -= weight;
            if (roll < 0) {
                return feature.Place(context.Placement.Nested(), context.Random, context.Origin);
            }
        }

        return false;
    }
}

/// <summary>
/// <c>NetherForestVegetationFeature</c>: the roots, fungi and sprouts scattered over a nylium floor.
/// </summary>
/// <remarks>
/// The attempt count is the <b>square</b> of the spread width, so widening the patch by one costs
/// several more draws and the density stays roughly even rather than thinning out.
/// </remarks>
public sealed record NetherForestVegetationFeature(BlockStateProvider StateProvider, int SpreadWidth,
    int SpreadHeight) : ConfiguredFeature {

    private static readonly Identifier Nylium = "minecraft:nylium";

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (!level.Blocks.IsIn(Nylium, level.GetState(origin.X, origin.Y - 1, origin.Z))) {
            return false;
        }

        if (origin.Y < level.MinY + 1 || origin.Y + 1 > level.MaxY) {
            return false;
        }

        int placed = 0;

        for (int attempt = 0; attempt < SpreadWidth * SpreadWidth; attempt++) {
            int x = origin.X + random.NextInt(SpreadWidth) - random.NextInt(SpreadWidth);
            int y = origin.Y + random.NextInt(SpreadHeight) - random.NextInt(SpreadHeight);
            int z = origin.Z + random.NextInt(SpreadWidth) - random.NextInt(SpreadWidth);

            // The provider is asked before the position is judged, so a rejected position still costs
            // whatever the provider drew.
            IBlock state = StateProvider.GetState(level, random, x, y, z);

            if (!level.IsEmptyBlock(x, y, z) || y <= level.MinY
                || !FeatureSurvival.CanSurvive(state, level, x, y, z)) {

                continue;
            }

            level.SetState(x, y, z, state.StateId);
            placed++;
        }

        return placed > 0;
    }
}

/// <summary>
/// <c>TwistingVinesFeature</c>: the vines growing up off a warped forest floor.
/// </summary>
/// <remarks>
/// Two rolls after the height is drawn make the lengths lumpy rather than uniform: one in six doubles
/// it and one in five flattens it to a single block, and both are drawn every time so the cost does
/// not depend on the outcome.
/// </remarks>
public sealed record TwistingVinesFeature(int SpreadWidth, int SpreadHeight, int MaxHeight)
    : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (IsInvalidPlacementLocation(level, origin.X, origin.Y, origin.Z)) {
            return false;
        }

        for (int attempt = 0; attempt < SpreadWidth * SpreadWidth; attempt++) {
            int x = origin.X + Mth.NextInt(random, -SpreadWidth, SpreadWidth);
            int y = origin.Y + Mth.NextInt(random, -SpreadHeight, SpreadHeight);
            int z = origin.Z + Mth.NextInt(random, -SpreadWidth, SpreadWidth);

            if (!FindFirstAirBlockAboveGround(level, x, ref y, z)
                || IsInvalidPlacementLocation(level, x, y, z)) {

                continue;
            }

            int height = Mth.NextInt(random, 1, MaxHeight);

            if (random.NextInt(6) == 0) {
                height *= 2;
            }

            if (random.NextInt(5) == 0) {
                height = 1;
            }

            PlaceColumn(level, random, x, y, z, height);
        }

        return true;
    }

    /// <summary>
    /// Walks down to the first solid block and stops one above it, so a vine starts on the floor
    /// rather than wherever the scatter landed.
    /// </summary>
    private static bool FindFirstAirBlockAboveGround(IFeatureLevel level, int x, ref int y, int z) {
        do {
            y--;

            if (!level.InWorld(y)) {
                return false;
            }
        } while (level.IsAir(x, y, z));

        y++;
        return true;
    }

    /// <summary>
    /// Body blocks upwards with a head on top. The head goes on at the last block or at the first one
    /// with something above it, whichever comes first.
    /// </summary>
    private static void PlaceColumn(IFeatureLevel level, RandomSource random, int x, int y, int z,
        int totalHeight) {

        for (int grown = 1; grown <= totalHeight; grown++) {
            if (level.IsEmptyBlock(x, y, z)) {
                if (grown == totalHeight || !level.IsEmptyBlock(x, y + 1, z)) {
                    level.SetState(x, y, z, Head(random).StateId);
                    return;
                }

                level.SetState(x, y, z, Block.TwistingVinesPlant.StateId);
            }

            y++;
        }
    }

    /// <summary>
    /// The tip, aged 17 to 25. Vines stop growing at 25, so a generated one is nearly finished and
    /// does not climb to the ceiling the first time the chunk ticks.
    /// </summary>
    private static IBlock Head(RandomSource random) {
        IBlock vine = Block.TwistingVines;
        return vine is IAged aged ? aged.WithAge(Mth.NextInt(random, 17, 25)) : vine;
    }

    private static bool IsInvalidPlacementLocation(IFeatureLevel level, int x, int y, int z) {
        if (!level.IsEmptyBlock(x, y, z)) {
            return true;
        }

        Identifier below = level.Registry.Blocks.GetByStateId(level.GetState(x, y - 1, z)).Identifier;

        return !below.Equals(Block.Netherrack.Identifier)
            && !below.Equals(Block.WarpedNylium.Identifier)
            && !below.Equals(Block.WarpedWartBlock.Identifier);
    }
}

/// <summary>
/// <c>WeepingVinesFeature</c>: the nether wart ceiling of a crimson forest and the vines hanging off
/// it.
/// </summary>
/// <remarks>
/// The wart goes on first and the vines are hung off it afterwards, so the second pass is looking at a
/// ceiling the first pass just made. The wart grows the way glowstone does, one block per attempt
/// where <b>exactly one</b> neighbour is already part of it, which is what makes the patch ragged.
/// </remarks>
public sealed record WeepingVinesFeature : ConfiguredFeature {
    public static readonly WeepingVinesFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (!level.IsEmptyBlock(origin.X, origin.Y, origin.Z)) {
            return false;
        }

        if (!IsRoof(level, origin.X, origin.Y + 1, origin.Z)) {
            return false;
        }

        PlaceRoofNetherWart(level, random, origin);
        PlaceRoofWeepingVines(level, random, origin);

        return true;
    }

    private static void PlaceRoofNetherWart(IFeatureLevel level, RandomSource random, Vec3<int> origin) {
        uint wart = Block.NetherWartBlock.StateId;
        level.SetState(origin.X, origin.Y, origin.Z, wart);

        for (int attempt = 0; attempt < 200; attempt++) {
            // The vertical offset is lopsided, two up against five down, so the patch hangs below the
            // origin rather than spreading evenly around it.
            int x = origin.X + random.NextInt(6) - random.NextInt(6);
            int y = origin.Y + random.NextInt(2) - random.NextInt(5);
            int z = origin.Z + random.NextInt(6) - random.NextInt(6);

            if (!level.IsEmptyBlock(x, y, z)) {
                continue;
            }

            int neighbours = 0;

            foreach (BlockFace face in FeatureUtil.AllDirections) {
                Vec3<int> step = Placement.PlacementParser.Step(face);

                if (IsRoof(level, x + step.X, y + step.Y, z + step.Z)) {
                    neighbours++;
                }

                if (neighbours > 1) {
                    break;
                }
            }

            if (neighbours == 1) {
                level.SetState(x, y, z, wart);
            }
        }
    }

    private static void PlaceRoofWeepingVines(IFeatureLevel level, RandomSource random, Vec3<int> origin) {
        for (int attempt = 0; attempt < 100; attempt++) {
            int x = origin.X + random.NextInt(8) - random.NextInt(8);
            int y = origin.Y + random.NextInt(2) - random.NextInt(7);
            int z = origin.Z + random.NextInt(8) - random.NextInt(8);

            if (!level.IsEmptyBlock(x, y, z) || !IsRoof(level, x, y + 1, z)) {
                continue;
            }

            int height = Mth.NextInt(random, 1, 8);

            if (random.NextInt(6) == 0) {
                height *= 2;
            }

            if (random.NextInt(5) == 0) {
                height = 1;
            }

            PlaceColumn(level, random, x, y, z, height, 17, 25);
        }
    }

    /// <summary>
    /// Body blocks downwards with a head at the bottom.
    /// </summary>
    /// <remarks>
    /// The loop counts from <b>zero</b>, unlike the twisting vine's, so a height of one is two blocks
    /// rather than one. Both are vanilla's and the asymmetry is not an oversight to tidy up.
    /// </remarks>
    /// <summary>
    /// Reachable from the huge fungus, which hangs vines off its hat with a different age range.
    /// </summary>
    public static void PlaceColumn(IFeatureLevel level, RandomSource random, int x, int y, int z,
        int totalHeight, int minAge, int maxAge) {

        for (int grown = 0; grown <= totalHeight; grown++) {
            if (level.IsEmptyBlock(x, y, z)) {
                if (grown == totalHeight || !level.IsEmptyBlock(x, y - 1, z)) {
                    level.SetState(x, y, z, Head(random, minAge, maxAge).StateId);
                    return;
                }

                level.SetState(x, y, z, Block.WeepingVinesPlant.StateId);
            }

            y--;
        }
    }

    private static IBlock Head(RandomSource random, int minAge, int maxAge) {
        IBlock vine = Block.WeepingVines;
        return vine is IAged aged ? aged.WithAge(Mth.NextInt(random, minAge, maxAge)) : vine;
    }

    private static bool IsRoof(IFeatureLevel level, int x, int y, int z) {
        Identifier block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier;

        return block.Equals(Block.Netherrack.Identifier)
            || block.Equals(Block.NetherWartBlock.Identifier);
    }
}
