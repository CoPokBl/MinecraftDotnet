using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement.Rules;

/// <summary>
/// <c>FenceGateBlock</c>. Faces the player, opens if it is born powered, and drops into the wall if
/// there is a wall either side of it across its axis.
/// <p/>
/// <c>in_wall</c> lowers the gate so it lines up with a wall's shorter top. It is checked against the
/// two blocks perpendicular to the gate's facing, not the two it faces.
/// </summary>
public sealed class FenceGatePlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.FenceGateBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing gate) {
            return block;
        }

        bool open = Redstone.HasNeighbourSignal(context.World, context.PlacePos);
        Direction facing = context.HorizontalDirection;

        IBlock state = gate.WithFacing(facing);
        if (state is IOpenable openable) {
            state = openable.WithOpen(open);
        }

        if (state is IPowered powered) {
            state = powered.WithPowered(open);
        }

        IPlacementLevel world = context.World;
        bool inWall = IsWall(world, world.GetBlock(SideA(context.PlacePos, facing)))
                      || IsWall(world, world.GetBlock(SideB(context.PlacePos, facing)));

        return state is IInWall gated ? gated.WithInWall(inWall) : state;
    }

    /// <summary>
    /// A wall arriving or leaving beside the gate raises or drops it, and only across the gate's own
    /// axis: the two cells the gate faces cannot change <c>in_wall</c> however they change.
    /// <p/>
    /// Both sides are read again rather than only the one that changed, because <c>in_wall</c> is a
    /// single flag for the pair: a wall being broken on one side leaves the gate down if the other
    /// side still has one.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (block is not IHorizontalFacing gate || !Directions.IsHorizontal(toNeighbour)
            || !Directions.SameAxis(gate.Facing.ClockWise(), toNeighbour.ToDirection())) {
            return block;
        }

        bool inWall = IsWall(world, neighbourState)
                      || IsWall(world, world.GetBlock(pos.GetBlockTowards(toNeighbour.Opposite())));

        return block is IInWall gated ? gated.WithInWall(inWall) : block;
    }

    private static Vec3<int> SideA(Vec3<int> pos, Direction facing) {
        return pos.GetBlockTowards(facing.ClockWise().ToFace());
    }

    private static Vec3<int> SideB(Vec3<int> pos, Direction facing) {
        return pos.GetBlockTowards(facing.CounterClockWise().ToFace());
    }

    /// <summary>
    /// <c>FenceGateBlock.isWall</c>, which is <c>state.is(BlockTags.WALLS)</c> and not an
    /// <c>instanceof WallBlock</c>: the tag is what a datapack can change.
    /// </summary>
    private static bool IsWall(IPlacementLevel world, IBlock block) {
        return world.IsInBlockTag(Walls, block.Identifier);
    }

    private static readonly Identifier Walls = "minecraft:walls";
}
