using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// <c>LadderBlock</c>. The attachment search again, with two things on top: it waterlogs, and it
/// refuses outright when you clicked the face of a ladder that already faces that way.
/// <p/>
/// That refusal is what stops a ladder column being extended sideways off its own front, and it is
/// checked before anything else, so it happens even where a candidate would have survived.
/// </summary>
public sealed class LadderPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.LadderBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (!context.ReplacingClickedOnBlock) {
            IBlock behind = context.World.GetBlock(
                context.PlacePos.GetBlockTowards(context.ClickedFace.Opposite()));
            if (IBlock.SimilarTo(behind, block)
                && behind is IHorizontalFacing behindFacing
                && Directions.IsHorizontal(context.ClickedFace)
                && behindFacing.Facing == context.ClickedFace.ToDirection()) {
                return null;
            }
        }

        if (block is not IHorizontalFacing ladder) {
            return null;
        }

        IBlock? placed = PlacementHelpers.FirstSurviving(context, this, face =>
            Directions.IsHorizontal(face) ? ladder.WithFacing(face.Opposite().ToDirection()) : null);

        return placed is null ? null : PlacementHelpers.Waterlog(placed, context);
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        if (block is not IHorizontalFacing ladder) {
            return false;
        }

        BlockFace facing = ladder.Facing.ToFace();
        return PlacementHelpers.FaceSturdy(world, pos.GetBlockTowards(facing.Opposite()), facing);
    }

    /// <summary>
    /// <c>direction.getOpposite() == state.getValue(FACING)</c>: only the wall behind it counts. The
    /// direction is tested first, so nothing else changing near a ladder can take it down.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return block is IHorizontalFacing ladder
               && toNeighbour.Opposite() == ladder.Facing.ToFace()
               && !CanSurvive(block, world, pos)
            ? Block.Air
            : block;
    }
}
