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
/// <c>CeilingHangingSignBlock</c>. The only rule that decides between two <b>shapes</b> of the same
/// block rather than a facing: <c>attached</c> chooses the short chain that hangs under a solid
/// ceiling and the long V that hangs off a bar.
/// <p/>
/// Three inputs, in vanilla's order. A ceiling that is not a full face gives the V; sneaking forces
/// the V; and hanging under another hanging sign lined up along the same axis forces the chain back
/// off again. Only the last of those is subtle, and it is what lets a row of hanging signs be built
/// downwards without each one turning to face a different way.
/// </summary>
public sealed class CeilingHangingSignPlacementRule : IBlockPlacementRule {
    private static readonly Identifier AllHangingSigns = "minecraft:all_hanging_signs";

    public BlockClass VanillaClass => BlockClass.CeilingHangingSignBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        World world = context.World;
        Vec3<int> above = context.PlacePos.WithY(context.PlacePos.Y + 1);
        IBlock stateAbove = world.GetBlock(above);

        bool isBelowHangingSign =
            PlacementHelpers.InTag(world.Server.Registry, AllHangingSigns, stateAbove.Identifier);
        Direction direction = Directions.FromYRot(context.Rotation);

        // The collision shape, not the support shape: a hanging sign takes the chain under anything
        // that fills its underside, including the blocks that support nothing.
        bool attachedToMiddle = !ShapeSupport.IsFaceFull(stateAbove.CollisionShape, BlockFace.NegY)
                                || context.IsSecondaryUseActive;

        if (isBelowHangingSign && !context.IsSecondaryUseActive) {
            Direction? aboveDirection = HangingSignAxis(stateAbove);
            if (aboveDirection is not null && Directions.SameAxis(aboveDirection.Value, direction)) {
                attachedToMiddle = false;
            }
        }

        int rotationSegment = !attachedToMiddle
            ? PlacementHelpers.SegmentOfDirection(direction.Opposite())
            : PlacementHelpers.RotationSegment(context.Rotation + 180.0f);

        IBlock state = block is IAttached sign ? sign.WithAttached(attachedToMiddle) : block;
        state = state is IRotated rotated ? rotated.WithRotation(rotationSegment) : state;
        return PlacementHelpers.Waterlog(state, context);
    }

    /// <summary>
    /// Which way the hanging sign above lies. A wall hanging sign says so with its facing; a ceiling
    /// one says so through its rotation, and only the four rotations that land on an axis count.
    /// </summary>
    private static Direction? HangingSignAxis(IBlock sign) {
        if (BlockClasses.Is(sign.Identifier, BlockClass.WallHangingSignBlock)) {
            return sign is IHorizontalFacing wall ? wall.Facing : null;
        }

        return sign is IRotated ceiling ? PlacementHelpers.DirectionOfSegment(ceiling.Rotation) : null;
    }

    /// <summary>
    /// The centre column of the face above, not the whole of it, which is why a hanging sign hangs
    /// off a chain and off the bar of another hanging sign.
    /// </summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return PlacementHelpers.FaceSturdy(world, pos.WithY(pos.Y + 1), BlockFace.NegY, SupportType.Center);
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.PosY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>TripWireHookBlock</c>. The horizontal attachment search, facing out of the wall it found.
/// </summary>
public sealed class TripWireHookPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.TripWireHookBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing hook) {
            return null;
        }

        return PlacementHelpers.FirstSurviving(context, this, face =>
            Directions.IsHorizontal(face) ? hook.WithFacing(face.Opposite().ToDirection()) : null);
    }

    /// <summary>
    /// The full face of the wall behind, unlike the sign and banner rules beside it, which settle for
    /// <c>isSolid()</c>. A hook does not go on the side of a bottom slab.
    /// </summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        if (block is not IHorizontalFacing hook) {
            return false;
        }

        BlockFace facing = hook.Facing.ToFace();
        return PlacementHelpers.FaceSturdy(world, pos.GetBlockTowards(facing.Opposite()), facing);
    }

    /// <summary>
    /// Only the wall's own face matters. Anything else changing leaves the hook alone, so a hook
    /// stays put when the wire it was holding is broken.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (block is not IHorizontalFacing hook) {
            return block;
        }

        return toNeighbour.Opposite() == hook.Facing.ToFace() && !CanSurvive(block, world, pos)
            ? Block.Air
            : block;
    }
}

/// <summary>
/// <c>BaseCoralPlantTypeBlock</c>: the standing corals and the floor fans. Waterlogs from a
/// <b>full</b> water cell, and stands on any sturdy face below.
/// <p/>
/// The wall fans extend this and add the attachment search, so they take their own rule; both
/// resolve through the class chain the way vanilla's virtual dispatch does.
/// </summary>
public sealed class BaseCoralPlantTypePlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.BaseCoralPlantTypeBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return WaterlogFull(block, context);
    }

    internal static IBlock WaterlogFull(IBlock block, IBlockPlaceContext context) {
        return block is IWaterlogged coral
            ? coral.WithWaterlogged(PlacementHelpers.IsFullWaterAt(context.World, context.PlacePos))
            : block;
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return PlacementHelpers.FaceSturdy(world, pos.WithY(pos.Y - 1), BlockFace.PosY);
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>BaseCoralWallFanBlock</c>. Its own waterlog line comes from the coral plant above it in the
/// hierarchy, then the horizontal attachment search on top.
/// </summary>
public sealed class BaseCoralWallFanPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.BaseCoralWallFanBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing fan) {
            return null;
        }

        IBlock waterlogged = BaseCoralPlantTypePlacementRule.WaterlogFull(block, context);
        return PlacementHelpers.FirstSurviving(context, this, face =>
            Directions.IsHorizontal(face)
                ? ((IHorizontalFacing)waterlogged).WithFacing(face.Opposite().ToDirection())
                : null);
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        if (block is not IHorizontalFacing fan) {
            return false;
        }

        BlockFace facing = fan.Facing.ToFace();
        return PlacementHelpers.FaceSturdy(world, pos.GetBlockTowards(facing.Opposite()), facing);
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (block is not IHorizontalFacing fan) {
            return block;
        }

        return toNeighbour.Opposite() == fan.Facing.ToFace() && !CanSurvive(block, world, pos)
            ? Block.Air
            : block;
    }
}

/// <summary>
/// <c>HangingRootsBlock</c>. Hangs off a sturdy face above and waterlogs.
/// </summary>
public sealed class HangingRootsPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.HangingRootsBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return PlacementHelpers.Waterlog(block, context);
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return PlacementHelpers.FaceSturdy(world, pos.WithY(pos.Y + 1), BlockFace.NegY);
    }

    /// <summary>
    /// Inherited from <c>VegetationBlock</c>: the block dies as soon as it cannot survive, whichever
    /// neighbour changed, not only the one above it.
    /// </summary>
    /// <summary><c>direction == Direction.UP</c>: only the ceiling it hangs from can drop it.</summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.PosY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}
