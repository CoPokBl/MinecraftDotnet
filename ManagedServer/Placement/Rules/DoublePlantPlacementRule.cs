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
/// <c>DoublePlantBlock</c>: sunflowers, lilacs, tall grass and the rest. Tall flowers inherit this
/// unchanged, which is why one rule covers them too.
/// <p/>
/// The same two cell shape as a door, without the facing: refuse unless the cell above can be
/// replaced, place the lower half, write the upper half afterwards.
/// </summary>
public sealed class DoublePlantPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.DoublePlantBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        Vec3<int> pos = context.PlacePos;
        return pos.Y < PlacementHelpers.MaxY(context.World) && context.CanReplaceAt(pos.WithY(pos.Y + 1))
            ? block
            : null;
    }

    public void OnPlaced(IBlock placed, IBlockPlaceContext context) {
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
    /// <c>VegetationBlock.canSurvive</c>, the <c>supports_vegetation</c> tag, which is what stops a
    /// sunflower being planted on stone.
    /// </summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        if (block is not IDoubleHalved { Half: BlockHalf.Upper }) {
            return PlacementHelpers.SupportsVegetation(world, pos);
        }

        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        return IBlock.SimilarTo(below, block) && below is IDoubleHalved { Half: BlockHalf.Lower };
    }

    /// <summary>
    /// The two cell rule, and the reason breaking either half takes the other with it.
    /// <p/>
    /// Written as vanilla writes it, which is inside out: the interesting case is the <b>else</b>.
    /// A half whose partner's cell has just changed, and no longer holds the opposite half of the
    /// same plant, dies. Everything else falls through, except a lower half that has lost the ground
    /// under it, which dies for the other reason.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (block is not IDoubleHalved halved) {
            return block;
        }

        bool lower = halved.Half == BlockHalf.Lower;
        bool towardsPartner = !Directions.IsHorizontal(toNeighbour)
                              && lower == (toNeighbour == BlockFace.PosY);
        bool partnerIntact = IBlock.SimilarTo(neighbourState, block)
                             && neighbourState is IDoubleHalved partner && partner.Half != halved.Half;

        if (towardsPartner && !partnerIntact) {
            return Block.Air;
        }

        return lower && toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos)
            ? Block.Air
            : block;
    }

    private static readonly Identifier Water = "minecraft:water";
}
