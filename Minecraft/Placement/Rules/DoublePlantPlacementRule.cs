using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement.Rules;

/// <summary>
/// <c>DoublePlantBlock</c>: sunflowers, lilacs, tall grass and the rest. Tall flowers inherit this
/// unchanged, which is why one rule covers them too.
/// <p/>
/// The same two cell shape as a door, without the facing: refuse unless the cell above can be
/// replaced, place the lower half, write the upper half afterwards.
/// <p/>
/// It extends <c>VegetationBlock</c>, so it is a <see cref="VegetationPlacementRuleBase"/> and not a
/// bare rule. That is what its <c>updateShape</c> falls through to, and reading only its own body
/// misses the half of the behaviour that lives up there.
/// </summary>
public class DoublePlantPlacementRule()
    : TagVegetationPlacementRule("minecraft:supports_vegetation") {
    public override BlockClass VanillaClass => BlockClass.DoublePlantBlock;

    public override IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        Vec3<int> pos = context.PlacePos;
        return pos.Y < PlacementHelpers.MaxY(context.World) && context.CanReplaceAt(pos.WithY(pos.Y + 1))
            ? block
            : null;
    }

    public override void OnPlaced(IBlock placed, IBlockPlaceContext context) {
        if (placed is not IDoubleHalved halved) {
            return;
        }

        Vec3<int> above = context.PlacePos.WithY(context.PlacePos.Y + 1);
        IBlock upper = halved.WithHalf(BlockHalf.Upper);

        // copyWaterloggedFrom: the top half takes the water that was already in its cell, so a tall
        // seagrass planted underwater stays underwater all the way up.
        if (upper is IWaterlogged waterlogged) {
            upper = waterlogged.WithWaterlogged(context.World.GetBlock(above).Fluid == Water);
        }

        context.World.SetBlock(above, upper);
    }

    /// <summary>
    /// Two different questions by half. The upper half only wants its own lower half underneath it,
    /// which is what stops a stray top of a sunflower existing. The lower half falls through to
    /// <c>VegetationBlock.canSurvive</c>, ie. this rule's <c>mayPlaceOn</c>, which is what stops a
    /// sunflower being planted on stone.
    /// <p/>
    /// The fall through is what a subclass changes: every one of them overrides
    /// <see cref="VegetationPlacementRuleBase.MayPlaceOn"/> and leaves the upper half's question
    /// alone.
    /// </summary>
    public override bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        if (block is not IDoubleHalved { Half: BlockHalf.Upper }) {
            return base.CanSurvive(block, world, pos);
        }

        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        return IBlock.SimilarTo(below, block) && below is IDoubleHalved { Half: BlockHalf.Lower };
    }

    /// <summary>
    /// The two cell rule, and the reason breaking either half takes the other with it.
    /// <p/>
    /// Written as vanilla writes it, which is inside out: the interesting case is the <b>else</b>.
    /// A half whose partner's cell has just changed, and no longer holds the opposite half of the
    /// same plant, dies.
    /// <p/>
    /// Everything else falls through to <c>VegetationBlock.updateShape</c>, which kills the block the
    /// moment it cannot survive, whichever neighbour changed. Vanilla writes a "lower half that lost
    /// its ground" test in front of that <c>super</c> call, and it is a special case of it, so the
    /// base rule answers both.
    /// </summary>
    public override IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (block is not IDoubleHalved halved) {
            return block;
        }

        bool lower = halved.Half == BlockHalf.Lower;
        bool towardsPartner = !Directions.IsHorizontal(toNeighbour)
                              && lower == (toNeighbour == BlockFace.PosY);
        bool partnerIntact = IBlock.SimilarTo(neighbourState, block)
                             && neighbourState is IDoubleHalved partner && partner.Half != halved.Half;

        return towardsPartner && !partnerIntact
            ? Block.Air
            : base.UpdateShape(block, world, pos, toNeighbour, neighbourPos, neighbourState);
    }

    private static readonly Identifier Water = "minecraft:water";
}
