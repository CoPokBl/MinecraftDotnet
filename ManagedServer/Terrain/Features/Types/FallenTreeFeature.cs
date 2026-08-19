using ManagedServer.Placement;
using ManagedServer.Placement.Helpers;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Trees;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>FallenTreeFeature</c>: a stump with a log lying on the ground beside it.
/// </summary>
/// <remarks>
/// Two separate placements, and the log is not attached to the stump: it starts two or three blocks
/// away in a random horizontal direction and then hunts up to six blocks down for ground to lie on.
/// The gap between them is what makes it read as a tree that fell rather than one that was cut.
/// <p/>
/// <b>The stump is placed before the log is judged</b>, so a position where the log does not fit still
/// leaves the stump standing on its own. Vanilla's, and it is why fallen trees are often stumps alone.
/// <p/>
/// The log runs along its direction's axis, which is the one thing the state modifier does.
/// </remarks>
public sealed record FallenTreeFeature(BlockStateProvider TrunkProvider, IIntProvider LogLength,
    IReadOnlyList<TreeDecorator> StumpDecorators, IReadOnlyList<TreeDecorator> LogDecorators)
    : ConfiguredFeature {

    /// <summary>The gap the log may bridge before it is judged unsupported.</summary>
    private const int MaxGroundGap = 2;

    /// <summary>How far down the start of the log will hunt for ground.</summary>
    private const int MaxFallHeight = 6;

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        PlaceStump(context, origin);

        BlockFace direction = Directions.Horizontal[random.NextInt(Directions.Horizontal.Length)];

        // Two blocks are the stump and the empty space after it, so the configured length is the
        // visible log plus those.
        int logLength = LogLength.Sample(random) - 2;

        Vec3<int> step = Placement.PlacementParser.Step(direction);
        Vec3<int> start = origin + step * (2 + random.NextInt(2));

        start = GroundHeightForLogStart(level, start);

        if (CanPlaceEntireLog(level, logLength, start, step)) {
            PlaceLog(context, logLength, start, step, direction);
        }

        return true;
    }

    private void PlaceStump(FeaturePlaceContext context, Vec3<int> pos) {
        Vec3<int> placed = PlaceLogBlock(context, pos, null);
        Decorate(context, [placed], StumpDecorators);
    }

    /// <summary>
    /// Walks up one and then down six looking for somewhere the log can start.
    /// </summary>
    /// <remarks>
    /// If nothing is found the cursor is left at the bottom of the search rather than reset, and the
    /// fit test that follows is what rejects it.
    /// </remarks>
    private static Vec3<int> GroundHeightForLogStart(IFeatureLevel level, Vec3<int> start) {
        Vec3<int> cursor = start.WithY(start.Y + 1);

        for (int step = 0; step < MaxFallHeight; step++) {
            if (TreeFeature.ValidTreePos(level, cursor) && IsOverSolidGround(level, cursor)) {
                return cursor;
            }

            cursor = cursor.WithY(cursor.Y - 1);
        }

        return cursor;
    }

    /// <summary>
    /// The whole log has to fit before any of it is placed, so a log never stops halfway through a
    /// wall.
    /// </summary>
    private static bool CanPlaceEntireLog(IFeatureLevel level, int logLength, Vec3<int> start,
        Vec3<int> step) {

        int gap = 0;
        Vec3<int> cursor = start;

        for (int i = 0; i < logLength; i++) {
            if (!TreeFeature.ValidTreePos(level, cursor)) {
                return false;
            }

            if (!IsOverSolidGround(level, cursor)) {
                if (++gap > MaxGroundGap) {
                    return false;
                }
            } else {
                gap = 0;
            }

            cursor += step;
        }

        return true;
    }

    private void PlaceLog(FeaturePlaceContext context, int logLength, Vec3<int> start, Vec3<int> step,
        BlockFace direction) {

        // A java.util.HashSet, because its iteration order is what the decorators walk. The context
        // sorts by y with a stable sort and a fallen log is horizontal, so every entry shares a y and
        // the set's own order survives the sort whole: collecting these in the order they were laid
        // puts every decorator's draw on a different log.
        JavaHashSet<Vec3<int>> log = FeatureUtil.PositionSet();
        Vec3<int> cursor = start;

        for (int i = 0; i < logLength; i++) {
            log.Add(PlaceLogBlock(context, cursor, AxisOf(direction)));
            cursor += step;
        }

        Decorate(context, log.OrderBy(pos => pos.Y).ToList(), LogDecorators);
    }

    private Vec3<int> PlaceLogBlock(FeaturePlaceContext context, Vec3<int> pos, Axis? axis) {
        IFeatureLevel level = context.Level;
        IBlock state = TrunkProvider.GetState(level, context.Random, pos.X, pos.Y, pos.Z);

        // trySetValue: a trunk provider handing back something with no axis is left alone rather than
        // failing.
        if (axis is { } value && state is IAxisAligned aligned) {
            state = aligned.WithAxis(value);
        }

        level.SetState(pos.X, pos.Y, pos.Z, state.StateId);
        return pos;
    }

    /// <summary>
    /// Runs the decorators over a set of logs with no leaves and no roots, which is the whole reason a
    /// fallen tree can reuse them.
    /// </summary>
    private static void Decorate(FeaturePlaceContext context, IReadOnlyList<Vec3<int>> logs,
        IReadOnlyList<TreeDecorator> decorators) {

        if (decorators.Count == 0) {
            return;
        }

        TreeDecoratorContext decoratorContext = new(context.Placement, new DecorationWriter(context.Level),
            context.Random, logs, [], []);

        foreach (TreeDecorator decorator in decorators) {
            decorator.Place(decoratorContext);
        }
    }

    private static bool IsOverSolidGround(IFeatureLevel level, Vec3<int> pos) {
        IBlock below = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y - 1, pos.Z));
        return ShapeSupport.IsFaceSturdy(below, BlockFace.PosY);
    }

    private static Axis AxisOf(BlockFace face) {
        return face switch {
            BlockFace.NegY or BlockFace.PosY => Axis.Y,
            BlockFace.NegZ or BlockFace.PosZ => Axis.Z,
            _ => Axis.X
        };
    }

    /// <summary>Writes straight through, since a fallen tree has no staging of its own.</summary>
    private sealed class DecorationWriter(IFeatureLevel level) : ITreeWriter {
        public void SetRoot(Vec3<int> pos, IBlock state) => Write(pos, state);
        public void SetTrunk(Vec3<int> pos, IBlock state) => Write(pos, state);
        public void SetFoliage(Vec3<int> pos, IBlock state) => Write(pos, state);
        public void SetDecoration(Vec3<int> pos, IBlock state) => Write(pos, state);

        /// <summary>A fallen tree has no leaves, so nothing is ever already set.</summary>
        public bool IsFoliageSet(Vec3<int> pos) => false;

        private void Write(Vec3<int> pos, IBlock state) {
            level.SetState(pos.X, pos.Y, pos.Z, state.StateId);
        }
    }
}
