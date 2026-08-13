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
/// <c>DoorBlock</c>, the worked example of a two cell block: it refuses to place unless the cell
/// above can be replaced, places the lower half, and writes the upper half from
/// <see cref="OnPlaced"/> once the lower one exists.
/// </summary>
public sealed class DoorPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.DoorBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        Vec3<int> pos = context.PlacePos;
        Vec3<int> above = pos.WithY(pos.Y + 1);
        if (pos.Y >= PlacementHelpers.MaxY(context.World) || !context.CanReplaceAt(above)) {
            return null;
        }

        bool powered = Redstone.HasNeighbourSignal(context.World, pos)
                       || Redstone.HasNeighbourSignal(context.World, above);

        IBlock state = block;
        if (state is IHorizontalFacing facing) {
            state = facing.WithFacing(context.HorizontalDirection);
        }

        if (state is IHinged hinged) {
            state = hinged.WithHinge(Hinge(context));
        }

        if (state is IPowered poweredProp) {
            state = poweredProp.WithPowered(powered);
        }

        if (state is IOpenable openable) {
            state = openable.WithOpen(powered);
        }

        return state is IDoubleHalved halved ? halved.WithHalf(BlockHalf.Lower) : state;
    }

    /// <summary>
    /// <c>setPlacedBy</c>: the top half, which has to go in after the bottom because vanilla only
    /// reaches this once the bottom is really in the world.
    /// </summary>
    public void OnPlaced(IBlock placed, IBlockPlaceContext context) {
        if (placed is not IDoubleHalved halved) {
            return;
        }

        Vec3<int> above = context.PlacePos.WithY(context.PlacePos.Y + 1);
        context.World.SetBlock(above, halved.WithHalf(BlockHalf.Upper));
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        Vec3<int> below = pos.WithY(pos.Y - 1);
        if (block is IDoubleHalved { Half: BlockHalf.Upper }) {
            // The top half only needs the bottom half of the same door under it.
            return IBlock.SimilarTo(world.GetBlock(below), block);
        }

        return PlacementHelpers.FaceSturdy(world, below, BlockFace.PosY);
    }

    /// <summary>
    /// The two cell rule. Breaking either half takes the other with it, which is the whole reason a
    /// door is not two independent blocks.
    /// <p/>
    /// Vanilla's shape is inside out, like the tall plant's: the interesting case is the else. An
    /// update coming from the partner's cell either finds the opposite half of a door there, in which
    /// case this half <b>copies the partner's state</b> and keeps only its own half, or finds
    /// something else and dies. Copying is what carries an opening through both halves.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (block is not IDoubleHalved halved) {
            return block;
        }

        bool lower = halved.Half == BlockHalf.Lower;
        bool towardsPartner = !Directions.IsHorizontal(toNeighbour)
                              && lower == (toNeighbour == BlockFace.PosY);

        if (towardsPartner) {
            return BlockClasses.Is(neighbourState.Identifier, BlockClass.DoorBlock)
                   && neighbourState is IDoubleHalved partner && partner.Half != halved.Half
                ? partner.WithHalf(halved.Half)
                : Block.Air;
        }

        return lower && toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos)
            ? Block.Air
            : block;
    }

    /// <summary>
    /// <c>DoorBlock.getHinge</c>. Counts full blocks and existing doors to the left and the right of
    /// where the door will stand, over both of its cells, and hangs it away from whichever side has
    /// more. A tie is broken by which half of the block the cursor was on, which is what lets two
    /// doors placed side by side open as a pair.
    /// </summary>
    private static LeftRight Hinge(IBlockPlaceContext context) {
        World world = context.World;
        Vec3<int> pos = context.PlacePos;
        Direction placeDirection = context.HorizontalDirection;
        Vec3<int> abovePos = pos.WithY(pos.Y + 1);

        BlockFace left = placeDirection.CounterClockWise().ToFace();
        BlockFace right = placeDirection.ClockWise().ToFace();
        Vec3<int> leftPos = pos.GetBlockTowards(left);
        Vec3<int> leftAbove = abovePos.GetBlockTowards(left);
        Vec3<int> rightPos = pos.GetBlockTowards(right);
        Vec3<int> rightAbove = abovePos.GetBlockTowards(right);

        IBlock leftState = world.GetBlock(leftPos);
        IBlock rightState = world.GetBlock(rightPos);

        int balance = (IsFullBlock(leftState) ? -1 : 0)
                      + (IsFullBlock(world.GetBlock(leftAbove)) ? -1 : 0)
                      + (IsFullBlock(rightState) ? 1 : 0)
                      + (IsFullBlock(world.GetBlock(rightAbove)) ? 1 : 0);

        bool doorLeft = IsLowerDoor(leftState);
        bool doorRight = IsLowerDoor(rightState);

        if ((doorLeft && !doorRight) || balance > 0) {
            return LeftRight.Right;
        }

        if ((doorRight && !doorLeft) || balance < 0) {
            return LeftRight.Left;
        }

        // Nothing to prefer, so it comes down to which side of the block was clicked, read against
        // the direction the door will face.
        int stepX = StepX(placeDirection);
        int stepZ = StepZ(placeDirection);
        double clickX = context.ClickLocation.X - pos.X;
        double clickZ = context.ClickLocation.Z - pos.Z;
        bool leftHinge = (stepX >= 0 || !(clickZ < 0.5))
                         && (stepX <= 0 || !(clickZ > 0.5))
                         && (stepZ >= 0 || !(clickX > 0.5))
                         && (stepZ <= 0 || !(clickX < 0.5));
        return leftHinge ? LeftRight.Left : LeftRight.Right;
    }

    private static int StepX(Direction direction) => direction switch {
        Direction.East => 1,
        Direction.West => -1,
        _ => 0
    };

    private static int StepZ(Direction direction) => direction switch {
        Direction.South => 1,
        Direction.North => -1,
        _ => 0
    };

    /// <summary>
    /// <c>BlockState.isCollisionShapeFullBlock</c>: what the hinge test asks of the blocks either
    /// side, so a door placed in a gap between a wall and a slab hangs off the wall.
    /// </summary>
    private static bool IsFullBlock(IBlock block) => ShapeSupport.IsShapeFullBlock(block.CollisionShape);

    private static bool IsLowerDoor(IBlock block) {
        return BlockClasses.Is(block.Identifier, BlockClass.DoorBlock)
               && block is IDoubleHalved { Half: BlockHalf.Lower };
    }
}
