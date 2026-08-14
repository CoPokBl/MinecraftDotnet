using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// <c>WallTorchBlock</c>, and the redstone wall torch that extends it. The attachment search in its
/// simplest form: walk the looking order, skip anything vertical, try facing out of each horizontal,
/// and take the first that has a wall behind it.
/// <p/>
/// A torch is only ever placed as a wall torch when the standing variant could not go, which is the
/// item's decision rather than the block's. Until that item level split exists, a torch aimed at a
/// wall reaches this rule only if the wall torch block itself is what is being placed.
/// </summary>
public class WallTorchPlacementRule : IBlockPlacementRule {
    public virtual BlockClass VanillaClass => BlockClass.WallTorchBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing torch) {
            return null;
        }

        return PlacementHelpers.FirstSurviving(context, this, face =>
            Directions.IsHorizontal(face) ? torch.WithFacing(face.Opposite().ToDirection()) : null);
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        if (block is not IHorizontalFacing torch) {
            return false;
        }

        // The wall is behind the torch, ie. across the face opposite the one it points out of.
        BlockFace facing = torch.Facing.ToFace();
        return PlacementHelpers.FaceSturdy(world, pos.GetBlockTowards(facing.Opposite()), facing);
    }

    /// <summary>
    /// <c>direction.getOpposite() == state.getValue(FACING)</c>, then the survival test. Returning
    /// air is what the update driver turns into a break, but only the wall behind the torch can ask
    /// for it.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return block is IHorizontalFacing torch
               && toNeighbour.Opposite() == torch.Facing.ToFace()
               && !CanSurvive(block, world, pos)
            ? Block.Air
            : block;
    }
}

/// <summary>
/// <c>RedstoneWallTorchBlock</c>, which is the same three hooks as a wall torch and inherits none of
/// them: it extends <c>RedstoneTorchBlock</c> and calls <c>WallTorchBlock</c>'s static
/// <c>canSurvive</c> by hand.
/// <p/>
/// So the class chain here is <c>[RedstoneWallTorchBlock, RedstoneTorchBlock, BaseTorchBlock, ...]</c>
/// with no <c>WallTorchBlock</c> in it, and without this rule a redstone wall torch resolves to
/// <see cref="BaseTorchPlacementRule"/> and asks the block <b>below</b> for support instead of the
/// one behind it. That is permissive rather than obviously broken, which is why the conformance
/// fixture found it and reading the hierarchy did not.
/// </summary>
public sealed class RedstoneWallTorchPlacementRule : WallTorchPlacementRule {
    public override BlockClass VanillaClass => BlockClass.RedstoneWallTorchBlock;
}
