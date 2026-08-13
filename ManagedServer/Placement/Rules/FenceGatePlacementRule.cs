using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

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

        return WithInWall(state, context.World.GetBlock(SideA(context.PlacePos, facing)),
            context.World.GetBlock(SideB(context.PlacePos, facing)));
    }

    /// <summary>
    /// A gate facing along Z looks west and east for a wall, one facing along X looks north and
    /// south. <c>in_wall</c> is not exposed as a property interface because only this block has it,
    /// so it goes through the state NBT.
    /// </summary>
    private static IBlock WithInWall(IBlock state, IBlock sideA, IBlock sideB) {
        bool inWall = IsWall(sideA) || IsWall(sideB);
        return state.WithState(new NBT.Tags.CompoundTag(
            ("in_wall", new NBT.Tags.StringTag(inWall ? "true" : "false"))));
    }

    private static Vec3<int> SideA(Vec3<int> pos, Direction facing) {
        return pos.GetBlockTowards(facing.ClockWise().ToFace());
    }

    private static Vec3<int> SideB(Vec3<int> pos, Direction facing) {
        return pos.GetBlockTowards(facing.CounterClockWise().ToFace());
    }

    /// <summary><c>FenceGateBlock.isWall</c>, an <c>instanceof WallBlock</c> upstream.</summary>
    private static bool IsWall(IBlock block) => BlockClasses.Is(block.Identifier, BlockClass.WallBlock);
}
