using ManagedServer.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

using Minecraft.Data.Generated;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// <c>SlabBlock</c>. Half from the click point, and a second slab of the same kind merges into a
/// double.
/// <p/>
/// The merge is worth following through, because it is spread across two methods and a context. The
/// slab already in the world answers <see cref="CanBeReplaced"/> yes, which makes the context report
/// the clicked position as the position being placed at, which makes
/// <see cref="GetStateForPlacement"/> look up the block there and find the slab, which is how it
/// knows to return a double rather than a new slab beside it.
/// </summary>
public sealed class SlabPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.SlabBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock existing = context.World.GetBlock(context.PlacePos);
        if (IBlock.SimilarTo(existing, block) && existing is ISlabTyped merging) {
            IBlock doubled = merging.WithType(SlabType.Double);
            // A double slab has no room for the water, so vanilla clears it rather than leaving a
            // state that says it is waterlogged and full.
            return doubled is IWaterlogged waterlogged ? waterlogged.WithWaterlogged(false) : doubled;
        }

        if (block is not ISlabTyped slab) {
            return block;
        }

        IBlock state = PlacementHelpers.Waterlog(slab.WithType(SlabType.Bottom), context);
        return PlacementHelpers.HalfFromClick(context) == TopBottom.Bottom
            ? state
            : ((ISlabTyped)state).WithType(SlabType.Top);
    }

    /// <summary>
    /// <c>SlabBlock.canBeReplaced</c>. A single slab lets its own item replace it, but only when the
    /// click was on the empty half: clicking the top of a bottom slab merges, clicking its side
    /// merges only if the cursor was in the upper half, and anything else places a new slab next to
    /// it instead.
    /// <p/>
    /// The geometric branch is the one that runs while the context is still being built, because
    /// vanilla's <c>replaceClicked</c> starts true. It is what decides the whole question: the answer
    /// here is what the context stores, so a "no" is what turns a click on a slab's side into a slab
    /// placed beside it rather than a double. See the field note on <see cref="PlayerPlaceContext"/>.
    /// </summary>
    public bool CanBeReplaced(IBlock existing, IBlockPlaceContext context) {
        if (existing is not ISlabTyped slab) {
            return IBlockPlacementRule.DefaultCanBeReplaced(existing, context);
        }

        if (slab.Type == SlabType.Double || context.ItemInHand.Type.Identifier != existing.Item) {
            return false;
        }

        if (!context.ReplacingClickedOnBlock) {
            return true;
        }

        bool above = context.ClickLocation.Y - context.PlacePos.Y > 0.5;
        BlockFace face = context.ClickedFace;
        return slab.Type == SlabType.Bottom
            ? face == BlockFace.PosY || (above && Directions.IsHorizontal(face))
            : face == BlockFace.NegY || (!above && Directions.IsHorizontal(face));
    }
}
