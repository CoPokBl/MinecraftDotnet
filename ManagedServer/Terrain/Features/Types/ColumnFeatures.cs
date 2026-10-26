using Minecraft.Placement.Helpers;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Placement;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>SpringFeature</c>: the single fluid block a waterfall or lavafall starts from.
/// </summary>
/// <remarks>
/// <b>The flow is missing and the source is not.</b> Vanilla places the block and follows it with
/// <c>scheduleTick</c>, and the fall itself is the fluid simulation running from that tick. There is
/// no block tick scheduler in the generator, the same gap the placement rules document, so a spring
/// generates as the one block vanilla writes and stays that way until something updates it. Wiring it
/// up is a scheduled tick at this position, not a change to this feature.
/// <p/>
/// The counts are exact equalities rather than minimums, which is what makes a spring appear in a
/// wall of stone with one open side instead of anywhere the two blocks happen to line up.
/// </remarks>
public sealed record SpringFeature(uint State, bool RequiresBlockBelow, int RockCount, int HoleCount,
    IReadOnlySet<Identifier> ValidBlocks) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;

        if (!IsValid(level, origin.X, origin.Y + 1, origin.Z)) {
            return false;
        }

        if (RequiresBlockBelow && !IsValid(level, origin.X, origin.Y - 1, origin.Z)) {
            return false;
        }

        uint here = level.GetState(origin.X, origin.Y, origin.Z);
        if (!level.Blocks.IsAir(here) && !Contains(level, here)) {
            return false;
        }

        int rocks = 0;
        int holes = 0;

        // West, east, north, south, below, which is the order the sides are counted in. Only the
        // totals are read, so the order is kept for the diff rather than for the result.
        foreach (Vec3<int> side in Sides) {
            int x = origin.X + side.X;
            int y = origin.Y + side.Y;
            int z = origin.Z + side.Z;

            if (IsValid(level, x, y, z)) {
                rocks++;
            }

            if (level.IsEmptyBlock(x, y, z)) {
                holes++;
            }
        }

        if (rocks != RockCount || holes != HoleCount) {
            return false;
        }

        level.SetState(origin.X, origin.Y, origin.Z, State);
        return true;
    }

    private static readonly Vec3<int>[] Sides = [
        new(-1, 0, 0), new(1, 0, 0), new(0, 0, -1), new(0, 0, 1), new(0, -1, 0)
    ];

    private bool IsValid(IFeatureLevel level, int x, int y, int z) {
        return Contains(level, level.GetState(x, y, z));
    }

    private bool Contains(IFeatureLevel level, uint state) {
        return ValidBlocks.Contains(level.Registry.Blocks.GetByStateId(state).Identifier);
    }
}

/// <summary>One run of a <see cref="BlockColumnFeature"/>, a height and what fills it.</summary>
public sealed record BlockColumnLayer(IIntProvider Height, BlockStateProvider State);

/// <summary>
/// <c>BlockColumnFeature</c>: a stack of layers grown along one direction, cut short where it runs
/// into something.
/// </summary>
/// <remarks>
/// This is what a cave vine and a big dripleaf stem are: a long body layer and a one block tip layer,
/// so the berries and the leaf land at the end of the run however long it turned out to be.
/// <p/>
/// <b>Every layer's height is sampled before anything is placed</b>, and the fit is a truncation
/// afterwards. A shorter column therefore consumes exactly as much random as a tall one, which is what
/// keeps a chunk's later features in step whatever the ceiling happened to be.
/// <p/>
/// The first block goes down without being tested: the allowed placement walk starts one step along
/// from the origin, because the origin is where the placement modifiers already decided the column
/// belongs.
/// </remarks>
public sealed record BlockColumnFeature(IReadOnlyList<BlockColumnLayer> Layers, BlockFace Direction,
    BlockPredicate AllowedPlacement, bool PrioritizeTip) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;

        int[] heights = new int[Layers.Count];
        int total = 0;

        for (int i = 0; i < Layers.Count; i++) {
            heights[i] = Layers[i].Height.Sample(random);
            total += heights[i];
        }

        if (total == 0) {
            return false;
        }

        Vec3<int> step = PlacementParser.Step(Direction);
        Vec3<int> place = context.Origin;
        Vec3<int> next = place + step;

        for (int i = 0; i < total; i++) {
            if (!AllowedPlacement.Test(level, next)) {
                Truncate(heights, total, i, PrioritizeTip);
                break;
            }

            next += step;
        }

        for (int i = 0; i < Layers.Count; i++) {
            for (int placed = 0; placed < heights[i]; placed++) {
                IBlock state = Layers[i].State.GetState(level, random, place.X, place.Y, place.Z);
                level.SetState(place.X, place.Y, place.Z, state.StateId);
                place += step;
            }
        }

        return true;
    }

    /// <summary>
    /// Takes the overshoot off the layers, from the tip end or the base end.
    /// </summary>
    /// <remarks>
    /// Which end decides what a shortened column loses. A cave vine prioritises the tip, so a vine
    /// stopped by the floor keeps its berries and loses body; without it the tip is what falls off and
    /// the vine ends in a bare plant block.
    /// </remarks>
    private static void Truncate(int[] heights, int total, int newHeight, bool prioritizeTip) {
        int remaining = total - newHeight;
        int direction = prioritizeTip ? 1 : -1;
        int start = prioritizeTip ? 0 : heights.Length - 1;
        int end = prioritizeTip ? heights.Length : -1;

        for (int i = start; i != end && remaining > 0; i += direction) {
            int take = Math.Min(heights[i], remaining);
            remaining -= take;
            heights[i] -= take;
        }
    }
}

/// <summary>
/// <c>VinesFeature</c>: one vine on the first side of an air block that can hold it.
/// </summary>
/// <remarks>
/// The search runs in <c>Direction</c>'s own order with down skipped, and it returns at the first
/// face that takes a vine rather than picking among them, so the order is what decides which way a
/// vine faces when it has a choice. <see cref="BlockFace"/> is declared in that order.
/// </remarks>
public sealed record VinesFeature : ConfiguredFeature {
    public static readonly VinesFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;

        if (!level.IsEmptyBlock(origin.X, origin.Y, origin.Z)) {
            return false;
        }

        for (int face = 0; face < 6; face++) {
            BlockFace direction = (BlockFace)face;
            if (direction == BlockFace.NegY) {
                continue;
            }

            Vec3<int> neighbour = origin + PlacementParser.Step(direction);
            if (!IsAcceptableNeighbour(level, neighbour, direction)) {
                continue;
            }

            IBlock vine = Block.Vine;
            level.SetState(origin.X, origin.Y, origin.Z,
                (vine is IFaceConnected connected ? connected.WithConnection(direction, true) : vine).StateId);

            return true;
        }

        return false;
    }

    /// <summary>
    /// <c>MultifaceBlock.canAttachTo</c>: either shape of the neighbour covering the face the vine
    /// would hang from.
    /// </summary>
    /// <remarks>
    /// The face tested is the neighbour's, so it is the opposite of the direction walked in. Both the
    /// support shape and the collision shape count, and they disagree often enough to matter: a leaf
    /// block supports nothing and collides as a cube, and vines do hang off leaves.
    /// </remarks>
    private static bool IsAcceptableNeighbour(IFeatureLevel level, Vec3<int> pos, BlockFace direction) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));
        BlockFace against = direction.Opposite();

        return ShapeSupport.IsFaceFull(block.SupportShape, against)
            || ShapeSupport.IsFaceFull(block.CollisionShape, against);
    }

}
