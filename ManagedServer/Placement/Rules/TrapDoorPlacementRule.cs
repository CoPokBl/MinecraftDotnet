using ManagedServer.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

using Minecraft.Data.Generated;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// <c>TrapDoorBlock</c>. Two ways round depending on how it was clicked, plus the redstone state it
/// is born into.
/// <p/>
/// Clicking the side of a neighbouring block hangs the trapdoor on that side facing out of it, with
/// the half taken from the cursor height. Anything else, including replacing the clicked block, puts
/// it flat: facing the player and in the half opposite the face that was clicked. Note the half rule
/// is not the shared one stairs and slabs use, and neither branch matches it: the second branch
/// looks only at whether the face was up.
/// </summary>
public sealed class TrapDoorPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.TrapDoorBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        BlockFace clickedFace = context.ClickedFace;
        IBlock state = block;

        if (!context.ReplacingClickedOnBlock && Directions.IsHorizontal(clickedFace)) {
            if (state is IHorizontalFacing facing) {
                state = facing.WithFacing(clickedFace.ToDirection());
            }

            if (state is IHalved halved) {
                state = halved.WithHalf(context.ClickLocation.Y - context.PlacePos.Y > 0.5
                    ? TopBottom.Top
                    : TopBottom.Bottom);
            }
        }
        else {
            if (state is IHorizontalFacing facing) {
                state = facing.WithFacing(context.HorizontalDirection.Opposite());
            }

            if (state is IHalved halved) {
                state = halved.WithHalf(clickedFace == BlockFace.PosY ? TopBottom.Bottom : TopBottom.Top);
            }
        }

        // Placed next to a live wire it comes out already open, rather than waiting for an update
        // that will not arrive because nothing around it changed.
        if (Redstone.HasNeighbourSignal(context.World, context.PlacePos)) {
            if (state is IOpenable openable) {
                state = openable.WithOpen(true);
            }

            if (state is IPowered powered) {
                state = powered.WithPowered(true);
            }
        }

        return PlacementHelpers.Waterlog(state, context);
    }
}
