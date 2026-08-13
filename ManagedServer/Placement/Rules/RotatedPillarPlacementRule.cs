using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

using Minecraft.Data.Generated;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// <c>RotatedPillarBlock</c>: logs, basalt, bone blocks and the rest of the pillars. The whole of
/// vanilla's override is <c>setValue(AXIS, context.getClickedFace().getAxis())</c>, so a log lies
/// along whichever way you were facing when you clicked.
/// </summary>
public sealed class RotatedPillarPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.RotatedPillarBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return block is IAxisAligned pillar ? pillar.WithAxis(AxisOf(context.ClickedFace)) : block;
    }

    private static Axis AxisOf(BlockFace face) => face switch {
        BlockFace.NegY or BlockFace.PosY => Axis.Y,
        BlockFace.NegZ or BlockFace.PosZ => Axis.Z,
        _ => Axis.X
    };
}
