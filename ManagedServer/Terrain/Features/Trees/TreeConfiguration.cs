using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Trees;

/// <summary>
/// <c>TreeConfiguration</c>: everything the tree feature reads about the tree it is growing.
/// </summary>
/// <remarks>
/// The three providers are separate rather than one because they answer at different positions and a
/// rule based provider is common for the block below the trunk: an oak turns the grass under it into
/// dirt, and does not if what is there is already dirt or a root.
/// </remarks>
public sealed record TreeConfiguration(
    BlockStateProvider TrunkProvider,
    TrunkPlacer TrunkPlacer,
    BlockStateProvider FoliageProvider,
    FoliagePlacer FoliagePlacer,
    RootPlacer? RootPlacer,
    BlockStateProvider BelowTrunkProvider,
    FeatureSize MinimumSize,
    IReadOnlyList<TreeDecorator> Decorators,
    bool IgnoreVines,
    bool ForceDirt);

/// <summary>
/// <c>FeatureSize</c>: how wide the tree needs the space above it to be, checked before anything is
/// placed.
/// </summary>
/// <remarks>
/// <see cref="MinClippedHeight"/> is what lets a tree grow shorter than it wanted rather than not at
/// all, and it is null for most of them.
/// </remarks>
public abstract record FeatureSize(int? MinClippedHeight) {
    public abstract int GetSizeAtHeight(int treeHeight, int y);

    /// <summary>
    /// <c>TwoLayersFeatureSize</c>: a narrow lower part and a wider upper one, with the boundary a
    /// fixed number of blocks up.
    /// </summary>
    public sealed record TwoLayers(int Limit, int LowerSize, int UpperSize, int? MinClippedHeightValue)
        : FeatureSize(MinClippedHeightValue) {

        public override int GetSizeAtHeight(int treeHeight, int y) {
            return y < Limit ? LowerSize : UpperSize;
        }
    }

    /// <summary>
    /// <c>ThreeLayersFeatureSize</c>: the same with a third band, whose start is measured down from
    /// the top of the tree rather than up from the bottom.
    /// </summary>
    public sealed record ThreeLayers(int Limit, int UpperLimit, int LowerSize, int MiddleSize, int UpperSize,
        int? MinClippedHeightValue) : FeatureSize(MinClippedHeightValue) {

        public override int GetSizeAtHeight(int treeHeight, int y) {
            if (y < Limit) {
                return LowerSize;
            }

            return y >= treeHeight - UpperLimit ? UpperSize : MiddleSize;
        }
    }
}

/// <summary>
/// <c>FoliagePlacer.FoliageAttachment</c>: where a clump of leaves hangs off the trunk.
/// </summary>
/// <remarks>
/// <see cref="RadiusOffset"/> widens or narrows that clump and <see cref="DoubleTrunk"/> says the
/// trunk under it is two by two rather than one, which shifts every leaf ring outwards by half a
/// block.
/// </remarks>
public readonly record struct FoliageAttachment(Vec3<int> Pos, int RadiusOffset, bool DoubleTrunk);

/// <summary>Where a tree's blocks go, and what has already been written there.</summary>
/// <remarks>
/// Vanilla passes four different <c>BiConsumer</c>s plus a <c>FoliageSetter</c> so that it can tell
/// roots, trunk, foliage and decorations apart afterwards, which is what the leaf distance pass and
/// the decorators need. One interface with four calls says the same thing and keeps the sets in one
/// place.
/// </remarks>
public interface ITreeWriter {
    void SetRoot(Vec3<int> pos, IBlock state);

    void SetTrunk(Vec3<int> pos, IBlock state);

    void SetFoliage(Vec3<int> pos, IBlock state);

    void SetDecoration(Vec3<int> pos, IBlock state);

    /// <summary><c>FoliageSetter.isSet</c>: whether this tree has already put a leaf here.</summary>
    bool IsFoliageSet(Vec3<int> pos);
}

/// <summary>
/// <c>TrunkPlacer</c>: puts the wood down and says where the leaves attach.
/// </summary>
/// <remarks>
/// <see cref="GetTreeHeight"/> is two draws rather than one, and the pair is what gives the height
/// distribution its shape.
/// </remarks>
public abstract record TrunkPlacer(int BaseHeight, int HeightRandA, int HeightRandB) {
    public abstract IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
        RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config);

    public int GetTreeHeight(RandomSource random) {
        return BaseHeight + random.NextInt(HeightRandA + 1) + random.NextInt(HeightRandB + 1);
    }

    /// <summary>
    /// <c>placeBelowTrunkBlock</c>: the dirt under the tree. The provider is allowed to decline,
    /// which is what leaves an existing root or mud alone.
    /// </summary>
    protected static void PlaceBelowTrunkBlock(IFeatureLevel level, ITreeWriter writer, RandomSource random,
        Vec3<int> pos, TreeConfiguration config) {

        IBlock? below = config.BelowTrunkProvider.GetOptionalState(level, random, pos.X, pos.Y, pos.Z);
        if (below is not null) {
            writer.SetTrunk(pos, below);
        }
    }

    protected bool PlaceLog(IFeatureLevel level, ITreeWriter writer, RandomSource random, Vec3<int> pos,
        TreeConfiguration config, Func<IBlock, IBlock>? modifier = null) {

        if (!ValidTreePos(level, pos)) {
            return false;
        }

        IBlock state = config.TrunkProvider.GetState(level, random, pos.X, pos.Y, pos.Z);
        writer.SetTrunk(pos, modifier is null ? state : modifier(state));
        return true;
    }

    protected void PlaceLogIfFree(IFeatureLevel level, ITreeWriter writer, RandomSource random, Vec3<int> pos,
        TreeConfiguration config) {

        if (IsFree(level, pos)) {
            PlaceLog(level, writer, random, pos, config);
        }
    }

    /// <summary>
    /// <c>validTreePos</c>: somewhere a log may be written. Overridden by the mangrove's placer,
    /// which is allowed to grow through its own roots.
    /// </summary>
    public virtual bool ValidTreePos(IFeatureLevel level, Vec3<int> pos) {
        return TreeFeature.ValidTreePos(level, pos);
    }

    /// <summary>
    /// <c>isFree</c>: whether the space check may pass here. Wider than
    /// <see cref="ValidTreePos"/> by logs, so two trees may share a trunk column rather than the
    /// second one refusing to grow.
    /// </summary>
    public bool IsFree(IFeatureLevel level, Vec3<int> pos) {
        return ValidTreePos(level, pos) || level.Blocks.IsIn(TreeFeature.LogsTag, level.GetState(pos.X, pos.Y, pos.Z));
    }
}

/// <summary>
/// <c>RootPlacer</c>: the mangrove's roots, and the only thing that moves the trunk off the position
/// the tree was placed at.
/// </summary>
public abstract record RootPlacer(Values.IIntProvider TrunkOffsetY, BlockStateProvider RootProvider) {
    public abstract bool PlaceRoots(IFeatureLevel level, ITreeWriter writer, RandomSource random,
        Vec3<int> origin, Vec3<int> trunkOrigin, TreeConfiguration config);

    /// <summary>
    /// Where the trunk starts, which for a mangrove is a few blocks above where the tree was placed.
    /// </summary>
    public Vec3<int> GetTrunkOrigin(Vec3<int> origin, RandomSource random) {
        return origin.WithY(origin.Y + TrunkOffsetY.Sample(random));
    }
}
