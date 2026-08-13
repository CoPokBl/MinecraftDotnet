using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// <c>StairBlock</c>. Facing from the player, half from the click point, waterlogging from the fluid
/// being replaced, and then the corner shape from the stairs in front and behind.
/// <p/>
/// The shape is computed last, over the state the first three produced, and it is recomputed by
/// <see cref="UpdateShape"/> on every horizontal neighbour change. Both go through the same
/// <see cref="ShapeAt"/>, because a placement that disagreed with the update would put a corner in
/// and then take it straight back out.
/// </summary>
public sealed class StairPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.StairBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing facing) {
            return block;
        }

        IBlock state = facing.WithFacing(context.HorizontalDirection);
        if (state is IHalved halved) {
            state = halved.WithHalf(PlacementHelpers.HalfFromClick(context));
        }

        state = PlacementHelpers.Waterlog(state, context);
        return state is IStairShaped shaped
            ? shaped.WithShape(ShapeAt(state, context.World, context.PlacePos))
            : state;
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        // Only a horizontal neighbour can change a stair's corner. Vanilla also schedules a water
        // tick for a waterlogged stair here, which belongs to the fluid simulation rather than here.
        return Directions.IsHorizontal(toNeighbour) && block is IStairShaped shaped
            ? shaped.WithShape(ShapeAt(block, world, pos))
            : block;
    }

    /// <summary>
    /// <c>StairBlock.getStairsShape</c>. A stair turns an outer corner towards a stair behind it and
    /// an inner corner towards one in front, in both cases only when that stair crosses its axis and
    /// the stair on the far side does not already claim it.
    /// </summary>
    private static StairShape ShapeAt(IBlock block, World world, Vec3<int> pos) {
        if (block is not IHorizontalFacing self || block is not IHalved selfHalf) {
            return StairShape.Straight;
        }

        Direction facing = self.Facing;

        IBlock behind = world.GetBlock(pos.GetBlockTowards(facing.ToFace()));
        if (IsStairs(behind) && behind is IHorizontalFacing behindFacing && behind is IHalved behindHalf
            && selfHalf.Half == behindHalf.Half
            && !Directions.SameAxis(behindFacing.Facing, facing)
            && CanTakeShape(block, world, pos, behindFacing.Facing.Opposite())) {
            return behindFacing.Facing == facing.CounterClockWise()
                ? StairShape.OuterLeft
                : StairShape.OuterRight;
        }

        IBlock front = world.GetBlock(pos.GetBlockTowards(facing.Opposite().ToFace()));
        if (IsStairs(front) && front is IHorizontalFacing frontFacing && front is IHalved frontHalf
            && selfHalf.Half == frontHalf.Half
            && !Directions.SameAxis(frontFacing.Facing, facing)
            && CanTakeShape(block, world, pos, frontFacing.Facing)) {
            return frontFacing.Facing == facing.CounterClockWise()
                ? StairShape.InnerLeft
                : StairShape.InnerRight;
        }

        return StairShape.Straight;
    }

    /// <summary>
    /// <c>StairBlock.canTakeShape</c>: whether the stair on the far side is not an identical one
    /// already forming the corner. Two stairs facing the same way and in the same half cancel it.
    /// </summary>
    private static bool CanTakeShape(IBlock block, World world, Vec3<int> pos, Direction neighbour) {
        IBlock other = world.GetBlock(pos.GetBlockTowards(neighbour.ToFace()));
        if (!IsStairs(other)) {
            return true;
        }

        return block is not IHorizontalFacing self || other is not IHorizontalFacing otherFacing
               || block is not IHalved selfHalf || other is not IHalved otherHalf
               || otherFacing.Facing != self.Facing
               || otherHalf.Half != selfHalf.Half;
    }

    /// <summary><c>StairBlock.isStairs</c>, which is an <c>instanceof</c> upstream.</summary>
    private static bool IsStairs(IBlock block) => BlockClasses.Is(block.Identifier, BlockClass.StairBlock);
}
