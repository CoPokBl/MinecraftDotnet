using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement.Rules;

/// <summary>
/// <c>BellBlock</c>. Not one of the "face the player" one liners despite having a horizontal facing:
/// it picks an attachment as well, and the attachment decides what the bell is holding on to.
/// <p/>
/// A bell put on a floor or ceiling faces the player. A bell put on a wall faces out of it, and takes
/// the two post form if there is a second wall directly opposite, which is the only reason this needs
/// to look at two neighbours. If the wall form cannot survive it falls back to a floor or ceiling
/// mount <b>while keeping the wall facing</b>, so a bell placed at the side of a block that turns out
/// to be no good still stands the way it was aimed.
/// <p/>
/// <c>attachment</c> is a one off property with no interface, so it goes through the checked string
/// route rather than <c>WithState</c>, which would ignore a misspelling.
/// </summary>
public sealed class BellPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.BellBlock;


    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing) {
            return null;
        }

        IPlacementLevel world = context.World;
        Vec3<int> pos = context.PlacePos;
        BlockFace clicked = context.ClickedFace;

        if (!Directions.IsHorizontal(clicked)) {
            IBlock vertical = Facing(
                WithAttachment(block,
                    clicked == BlockFace.NegY ? BellAttachType.Ceiling : BellAttachType.Floor),
                context.HorizontalDirection);
            return CanSurvive(vertical, world, pos) ? vertical : null;
        }

        // Two posts only when both walls along the clicked axis are there. Vanilla spells the axis
        // out rather than deriving it, and the pair is checked against the whole face each side.
        BlockFace side = clicked.Opposite();
        bool doubleAttached =
            PlacementHelpers.FaceSturdy(world, pos.GetBlockTowards(side), clicked)
            && PlacementHelpers.FaceSturdy(world, pos.GetBlockTowards(clicked), side);

        IBlock wall = Facing(
            WithAttachment(block,
                doubleAttached ? BellAttachType.DoubleWall : BellAttachType.SingleWall),
            clicked.Opposite().ToDirection());
        if (CanSurvive(wall, world, pos)) {
            return wall;
        }

        bool standsBelow = PlacementHelpers.FaceSturdy(world, pos.WithY(pos.Y - 1), BlockFace.PosY);
        IBlock fallback = WithAttachment(wall,
            standsBelow ? BellAttachType.Floor : BellAttachType.Ceiling);
        return CanSurvive(fallback, world, pos) ? fallback : null;
    }

    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        BlockFace towardsSupport = ConnectedDirection(block).Opposite();
        return towardsSupport == BlockFace.PosY
            ? PlacementHelpers.SupportsCenter(world, pos.WithY(pos.Y + 1), BlockFace.NegY)
            : FaceAttachedPlacementRule.CanAttach(world, pos, towardsSupport);
    }

    /// <summary>
    /// Three separate rules that happen to share a method. A bell dies when what it hangs from goes,
    /// <b>unless</b> it has two posts, which is what makes the two post form worth having. A two post
    /// bell that loses one wall becomes a one post bell facing the wall it still has, and a one post
    /// bell that gains a wall opposite becomes a two post one.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (block is not IHorizontalFacing bell) {
            return block;
        }

        BellAttachType attachment = AttachmentOf(block);
        BlockFace connection = ConnectedDirection(block).Opposite();
        if (connection == toNeighbour && attachment != BellAttachType.DoubleWall
            && !CanSurvive(block, world, pos)) {
            return Block.Air;
        }

        if (!Directions.IsHorizontal(toNeighbour)
            || !Directions.SameAxis(bell.Facing, toNeighbour.ToDirection())) {
            return block;
        }

        // Both face tests below read the neighbour's face on the side vanilla names, which for the
        // first one is the face pointing away from the bell rather than back at it. Transcribed as
        // written: it makes no difference for a whole cube and every one of these neighbours is a
        // wall, but the two are not the same question and the jar picks this one.
        if (attachment == BellAttachType.DoubleWall
            && !ShapeSupport.IsFaceSturdy(neighbourState, toNeighbour)) {
            return Facing(WithAttachment(block, BellAttachType.SingleWall),
                toNeighbour.Opposite().ToDirection());
        }

        if (attachment == BellAttachType.SingleWall
            && connection.Opposite() == toNeighbour
            && ShapeSupport.IsFaceSturdy(neighbourState, bell.Facing.ToFace())) {
            return WithAttachment(block, BellAttachType.DoubleWall);
        }

        return block;
    }

    /// <summary>
    /// <c>getConnectedDirection</c>: which way the bell points away from what holds it. A wall bell
    /// points back along its facing, so the two post form points at one of its two posts and the
    /// survival test above lets it off.
    /// </summary>
    private static BlockFace ConnectedDirection(IBlock block) {
        return AttachmentOf(block) switch {
            BellAttachType.Floor => BlockFace.PosY,
            BellAttachType.Ceiling => BlockFace.NegY,
            _ => block is IHorizontalFacing facing ? facing.Facing.ToFace().Opposite() : BlockFace.PosY
        };
    }

    private static IBlock WithAttachment(IBlock block, BellAttachType attachment) {
        return block is IBellAttached bell ? bell.WithAttachment(attachment) : block;
    }

    private static BellAttachType AttachmentOf(IBlock block) {
        return block is IBellAttached bell ? bell.Attachment : BellAttachType.Floor;
    }

    private static IBlock Facing(IBlock block, Direction direction) {
        return block is IHorizontalFacing facing ? facing.WithFacing(direction) : block;
    }
}
