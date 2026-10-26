using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Trees;

/// <summary><c>AboveRootPlacement</c>: what sometimes sits on top of a root.</summary>
public sealed record AboveRootPlacement(BlockStateProvider Provider, float Chance);

/// <summary>
/// Shared root placing: whether a root fits, writing one, and waterlogging it if it lands in water.
/// </summary>
public abstract record RootPlacerBase(Values.IIntProvider TrunkOffsetY, BlockStateProvider RootProvider,
    AboveRootPlacement? AbovePlacement) : RootPlacer(TrunkOffsetY, RootProvider) {

    public virtual bool CanPlaceRoot(IFeatureLevel level, Vec3<int> pos) {
        return TreeFeature.ValidTreePos(level, pos);
    }

    protected virtual void PlaceRoot(IFeatureLevel level, ITreeWriter writer, RandomSource random,
        Vec3<int> pos, TreeConfiguration config) {

        if (!CanPlaceRoot(level, pos)) {
            return;
        }

        writer.SetRoot(pos, Waterlogged(level, pos,
            RootProvider.GetState(level, random, pos.X, pos.Y, pos.Z)));

        if (AbovePlacement is not { } above) {
            return;
        }

        Vec3<int> abovePos = pos.WithY(pos.Y + 1);
        if (random.NextFloat() < above.Chance && level.Blocks.IsAir(level.GetState(abovePos.X, abovePos.Y, abovePos.Z))) {
            writer.SetRoot(abovePos, Waterlogged(level, abovePos,
                above.Provider.GetState(level, random, abovePos.X, abovePos.Y, abovePos.Z)));
        }
    }

    /// <summary>
    /// The state with <c>waterlogged</c> set from what is really there. Unlike a leaf, a root reads
    /// the <b>tag</b>, so it waterlogs in flowing water as well as in a source.
    /// </summary>
    protected static IBlock Waterlogged(IFeatureLevel level, Vec3<int> pos, IBlock state) {
        if (state is not IWaterlogged waterloggable) {
            return state;
        }

        return waterloggable.WithWaterlogged(FeatureFluids.IsWater(level, level.GetState(pos.X, pos.Y, pos.Z)));
    }
}

/// <summary>
/// <c>MangroveRootPlacer</c>: the stilts a mangrove stands on.
/// </summary>
/// <remarks>
/// The whole set of roots is simulated before any of it is written, and a single blocked position
/// fails the tree outright. That is what makes mangroves refuse to grow where their roots would be cut
/// off rather than growing half a set of them.
/// </remarks>
public sealed record MangroveRootPlacer(Values.IIntProvider TrunkOffsetY, BlockStateProvider RootProvider,
    AboveRootPlacement? AbovePlacement, int MaxRootWidth, int MaxRootLength, float RandomSkewChance,
    Identifier CanGrowThrough, IReadOnlySet<Identifier> MuddyRootsIn, BlockStateProvider MuddyRootsProvider)
    : RootPlacerBase(TrunkOffsetY, RootProvider, AbovePlacement) {

    public override bool CanPlaceRoot(IFeatureLevel level, Vec3<int> pos) {
        return base.CanPlaceRoot(level, pos)
            || level.Blocks.IsIn(CanGrowThrough, level.GetState(pos.X, pos.Y, pos.Z));
    }

    public override bool PlaceRoots(IFeatureLevel level, ITreeWriter writer, RandomSource random,
        Vec3<int> origin, Vec3<int> trunkOrigin, TreeConfiguration config) {

        List<Vec3<int>> rootPositions = [];

        // The column between where the tree was placed and where its trunk starts has to be clear, or
        // the trunk would be floating over something.
        for (Vec3<int> column = origin; column.Y < trunkOrigin.Y; column = column.WithY(column.Y + 1)) {
            if (!CanPlaceRoot(level, column)) {
                return false;
            }
        }

        rootPositions.Add(trunkOrigin.WithY(trunkOrigin.Y - 1));

        foreach (Vec3<int> direction in TrunkPlacers.Horizontal) {
            Vec3<int> start = trunkOrigin + direction;
            List<Vec3<int>> inDirection = [];

            if (!SimulateRoots(level, random, start, direction, trunkOrigin, inDirection, 0)) {
                return false;
            }

            rootPositions.AddRange(inDirection);
            rootPositions.Add(trunkOrigin + direction);
        }

        foreach (Vec3<int> pos in rootPositions) {
            PlaceRoot(level, writer, random, pos, config);
        }

        return true;
    }

    /// <summary>
    /// Walks one root down and outwards. Returning false is what fails the whole tree, and it happens
    /// when a root runs out of length rather than when it is merely blocked.
    /// </summary>
    private bool SimulateRoots(IFeatureLevel level, RandomSource random, Vec3<int> rootPos,
        Vec3<int> direction, Vec3<int> rootOrigin, List<Vec3<int>> rootPositions, int layer) {

        if (layer == MaxRootLength || rootPositions.Count > MaxRootLength) {
            return false;
        }

        foreach (Vec3<int> next in PotentialRootPositions(rootPos, direction, random, rootOrigin)) {
            if (!CanPlaceRoot(level, next)) {
                continue;
            }

            rootPositions.Add(next);
            if (!SimulateRoots(level, random, next, direction, rootOrigin, rootPositions, layer + 1)) {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Where a root may go next: down, or one further out. Past the width limit it can only go down,
    /// which is what makes the arch close rather than spreading forever.
    /// </summary>
    private IReadOnlyList<Vec3<int>> PotentialRootPositions(Vec3<int> pos, Vec3<int> previousDirection,
        RandomSource random, Vec3<int> rootOrigin) {

        Vec3<int> below = pos.WithY(pos.Y - 1);
        Vec3<int> nextTo = pos + previousDirection;

        int width = Math.Abs(pos.X - rootOrigin.X) + Math.Abs(pos.Y - rootOrigin.Y)
            + Math.Abs(pos.Z - rootOrigin.Z);

        if (width > MaxRootWidth - 3 && width <= MaxRootWidth) {
            return random.NextFloat() < RandomSkewChance
                ? [below, nextTo.WithY(nextTo.Y - 1)]
                : [below];
        }

        if (width > MaxRootWidth) {
            return [below];
        }

        if (random.NextFloat() < RandomSkewChance) {
            return [below];
        }

        return random.NextBoolean() ? [nextTo] : [below];
    }

    /// <summary>
    /// A root in mud comes out as the muddy form, which is why this is an override rather than a
    /// second provider on the base.
    /// </summary>
    protected override void PlaceRoot(IFeatureLevel level, ITreeWriter writer, RandomSource random,
        Vec3<int> pos, TreeConfiguration config) {

        Identifier here = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z)).Identifier;

        if (MuddyRootsIn.Contains(here)) {
            writer.SetRoot(pos, Waterlogged(level, pos,
                MuddyRootsProvider.GetState(level, random, pos.X, pos.Y, pos.Z)));
            return;
        }

        base.PlaceRoot(level, writer, random, pos, config);
    }
}
