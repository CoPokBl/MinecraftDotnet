using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement.Rules;

/// <summary>
/// <c>FaceAttachedHorizontalDirectionalBlock</c>: buttons, levers and the grindstone.
/// <p/>
/// Those three have no <c>getStateForPlacement</c> of their own at all, they inherit this one
/// entirely, which is why one rule covers all of them. Resolution finds it by walking the block's
/// class chain, the same way the JVM would.
/// <p/>
/// Vertical faces give a floor or ceiling mount turned to face the player; horizontal faces give a
/// wall mount facing out of the wall. First candidate that has something to hold on to wins.
/// </summary>
public sealed class FaceAttachedPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.FaceAttachedHorizontalDirectionalBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IAttachFaced attached || block is not IHorizontalFacing) {
            return null;
        }

        return PlacementHelpers.FirstSurviving(context, this, face => {
            if (face is BlockFace.PosY or BlockFace.NegY) {
                IBlock state = attached.WithFace(face == BlockFace.PosY
                    ? AttachDirection.Ceiling
                    : AttachDirection.Floor);
                return ((IHorizontalFacing)state).WithFacing(context.HorizontalDirection);
            }

            IBlock wall = attached.WithFace(AttachDirection.Wall);
            return ((IHorizontalFacing)wall).WithFacing(face.Opposite().ToDirection());
        });
    }

    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        return CanAttach(world, pos, ConnectedDirection(block).Opposite());
    }

    /// <summary>
    /// <c>FaceAttachedHorizontalDirectionalBlock.canAttach</c>: whether the neighbour that way round
    /// presents a whole face back. Public and static upstream, and used from outside the family:
    /// <c>BellBlock</c> reaches for it rather than writing the two lines again.
    /// </summary>
    public static bool CanAttach(IPlacementLevel world, Vec3<int> pos, BlockFace direction) {
        return PlacementHelpers.FaceSturdy(world, pos.GetBlockTowards(direction), direction.Opposite());
    }

    /// <summary>
    /// Only the neighbour it is stuck to can knock it off. Vanilla tests the direction <b>before</b>
    /// asking whether it can survive, so a lever on an intact wall is not even asked when something
    /// changes on its other five sides.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return ConnectedDirection(block).Opposite() == toNeighbour && !CanSurvive(block, world, pos)
            ? Block.Air
            : block;
    }

    /// <summary>
    /// <c>getConnectedDirection</c>: which way the block points away from what it is stuck to. A
    /// ceiling mount points down, a floor mount up, and a wall mount out along its facing.
    /// </summary>
    private static BlockFace ConnectedDirection(IBlock block) {
        if (block is not IAttachFaced attached) {
            return BlockFace.PosY;
        }

        return attached.Face switch {
            AttachDirection.Ceiling => BlockFace.NegY,
            AttachDirection.Floor => BlockFace.PosY,
            _ => block is IHorizontalFacing facing ? facing.Facing.ToFace() : BlockFace.PosY
        };
    }
}
