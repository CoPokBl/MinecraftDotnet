using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement.Rules;

/// <summary>
/// <c>BedBlock</c>. A two cell block laid sideways: the foot goes where you clicked and the head one
/// block further along the way you were facing, so it refuses unless that cell can be replaced.
/// <p/>
/// Vanilla also checks the head is inside the world border. There is no world border here, so the
/// bounds check stands in for it; that is a narrower test, and the case it misses is a bed placed
/// with its head across a border, which cannot happen without one.
/// </summary>
public sealed class BedPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.BedBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing bed) {
            return block;
        }

        Direction facing = context.HorizontalDirection;
        Vec3<int> head = context.PlacePos.GetBlockTowards(facing.ToFace());
        if (!context.CanReplaceAt(head) || !context.World.IsInBounds(head)) {
            return null;
        }

        return bed.WithFacing(facing);
    }

    public void OnPlaced(IBlock placed, IBlockPlaceContext context) {
        if (placed is not IHorizontalFacing bed || placed is not IBedParted parted) {
            return;
        }

        context.World.SetBlock(context.PlacePos.GetBlockTowards(bed.Facing.ToFace()),
            parted.WithPart(BedPart.Head));
    }

    /// <summary>
    /// The two cell rule, sideways. Only the update coming from the other end matters; a bed does not
    /// care what is under it, which is why one can be laid across a gap.
    /// <p/>
    /// The other end still being there does not just keep it alive, it <b>copies the occupied flag
    /// across</b>, so the two halves agree about who is asleep in them.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (block is not IHorizontalFacing bed || block is not IBedParted parted
            || toNeighbour != NeighbourDirection(parted.Part, bed.Facing)) {
            return block;
        }

        if (!IBlock.SimilarTo(neighbourState, block)
            || neighbourState is not IBedParted otherEnd || otherEnd.Part == parted.Part) {
            return Block.Air;
        }

        // occupied is a bed only property with no interface, so it goes through the checked route.
        return block is IOccupied half && neighbourState is IOccupied partner
            ? half.WithOccupied(partner.Occupied)
            : block;
    }


    /// <summary>
    /// <c>BedBlock.getNeighbourDirection</c>: the head lies along the facing from the foot, so each
    /// end looks for the other in the opposite direction.
    /// </summary>
    private static BlockFace NeighbourDirection(BedPart part, Direction facing) {
        return part == BedPart.Head ? facing.Opposite().ToFace() : facing.ToFace();
    }
}
