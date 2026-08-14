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
/// <c>WallSignBlock</c>. The attachment search, waterlogging once a candidate has been chosen.
/// </summary>
public sealed class WallSignPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.WallSignBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing sign) {
            return null;
        }

        IBlock? placed = PlacementHelpers.FirstSurviving(context, this, face =>
            Directions.IsHorizontal(face) ? sign.WithFacing(face.Opposite().ToDirection()) : null);
        return placed is null ? null : PlacementHelpers.Waterlog(placed, context);
    }

    /// <summary>
    /// <c>WallSignBlock.canSurvive</c> is <c>isSolid()</c> on the block behind, not a face test.
    /// </summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        if (block is not IHorizontalFacing sign) {
            return false;
        }

        return world.GetBlock(pos.GetBlockTowards(sign.Facing.ToFace().Opposite())).Solid;
    }

    /// <summary>
    /// <c>direction.getOpposite() == state.getValue(FACING)</c>: the wall behind it only, tested
    /// before the survival question.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return block is IHorizontalFacing sign
               && toNeighbour.Opposite() == sign.Facing.ToFace()
               && !CanSurvive(block, world, pos)
            ? Block.Air
            : block;
    }
}

/// <summary>
/// <c>WallHangingSignBlock</c>. Faces along the axis it was hung across, so the search takes the
/// clicked face rather than its opposite.
/// </summary>
public sealed class WallHangingSignPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.WallHangingSignBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing sign) {
            return null;
        }

        IBlock? placed = PlacementHelpers.FirstSurviving(context, this, face =>
            Directions.IsHorizontal(face) ? sign.WithFacing(face.ToDirection().ClockWise()) : null);
        return placed is null ? null : PlacementHelpers.Waterlog(placed, context);
    }
}

/// <summary>
/// <c>ChainBlock</c>. A pillar that also waterlogs: axis from the clicked face, then the fluid.
/// </summary>
public sealed class ChainPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.ChainBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock state = block is IAxisAligned chain
            ? chain.WithAxis(AxisOf(context.ClickedFace))
            : block;
        return PlacementHelpers.Waterlog(state, context);
    }

    internal static Axis AxisOf(BlockFace face) => face switch {
        BlockFace.NegY or BlockFace.PosY => Axis.Y,
        BlockFace.NegZ or BlockFace.PosZ => Axis.Z,
        _ => Axis.X
    };
}

/// <summary>
/// <c>LightningRodBlock</c>. Points out of whatever it was placed on, in any of the six directions,
/// and waterlogs.
/// </summary>
public sealed class LightningRodPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.LightningRodBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock state = block is IDirectional rod
            ? rod.WithFacing(context.ClickedFace.ToCardinal())
            : block;
        return PlacementHelpers.Waterlog(state, context);
    }
}

/// <summary>
/// <c>HopperBlock</c>. Points away from the face that was clicked, except that a vertical click gives
/// a downward hopper rather than an upward one, because there is no upward hopper.
/// </summary>
public sealed class HopperPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.HopperBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IDirectional hopper) {
            return block;
        }

        BlockFace facing = context.ClickedFace.Opposite();
        if (facing is BlockFace.PosY or BlockFace.NegY) {
            facing = BlockFace.NegY;
        }

        IBlock state = hopper.WithFacing(facing.ToCardinal());
        return state is IEnabled switchable ? switchable.WithEnabled(true) : state;
    }
}

/// <summary>
/// <c>WaterloggedTransparentBlock</c>: tinted glass and the like. Nothing but the waterlog line.
/// </summary>
public sealed class WaterloggedTransparentPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.WaterloggedTransparentBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return PlacementHelpers.Waterlog(block, context);
    }
}

/// <summary>
/// <c>BaseRailBlock</c>, which the powered and detector rails inherit. Placement only picks a straight
/// shape along the way the player is facing.
/// <p/>
/// The curves and slopes are <b>not</b> here: vanilla works those out afterwards in <c>onPlace</c>,
/// through <c>RailState.place</c>, which also rewrites the rails around it. That is a second phase
/// with no equivalent yet, so a rail placed next to another comes out straight where the game would
/// have curved it. Placing the straight shape is what vanilla does at this point either way.
/// </summary>
public sealed class BaseRailPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.BaseRailBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        Direction facing = context.HorizontalDirection;
        bool eastWest = facing is Direction.East or Direction.West;
        // BaseRailBlock covers both the plain rail, whose shape includes the four curves, and the
        // three powered ones, whose shape is vanilla's narrowed RAIL_SHAPE_STRAIGHT. Two value sets,
        // so two generated enums and two interfaces; both are set to the same two straight values.
        IBlock state = block switch {
            IRailShaped rail => rail.WithShape(eastWest ? RailShape.EastWest : RailShape.NorthSouth),
            IRailDirected rail => rail.WithShape(
                eastWest ? RailDirection.EastWest : RailDirection.NorthSouth),
            _ => block
        };
        return PlacementHelpers.Waterlog(state, context);
    }

    /// <summary>
    /// <c>canSupportRigidBlock</c> on the block below, so the outer frame of the face rather than the
    /// whole of it. A rail goes on a hopper, whose top is a rim around a hole, and does not go on a
    /// fence post, whose top is only the middle.
    /// </summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return PlacementHelpers.SupportsRigid(world, pos.WithY(pos.Y - 1));
    }
}
