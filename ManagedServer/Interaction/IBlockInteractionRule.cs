using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Interaction;

/// <summary>
/// What one vanilla block class does about being right clicked, transcribing that class's overrides
/// of <c>BlockBehaviour.useItemOn</c> and <c>useWithoutItem</c>.
/// <p/>
/// One rule per vanilla class, named after it, exactly as <c>IBlockPlacementRule</c> works and for
/// the same reason: vanilla has a single pair of these methods per block, so rules do not compose
/// and there is no ordering between them.
/// <p/>
/// Both members are defaulted to the vanilla method bodies, so a rule writes only what its class
/// actually overrides. A block with no rule at all does nothing when clicked, which is what
/// <c>BlockBehaviour</c> does for a class that overrides neither.
/// </summary>
public interface IBlockInteractionRule {
    /// <summary>
    /// The vanilla class this transcribes, its simple name (<c>DoorBlock</c>, <c>LeverBlock</c>).
    /// <p/>
    /// Resolution walks the block's class chain from <c>BlockClasses</c> nearest first and takes the
    /// first class with a rule, which is Java's own virtual dispatch.
    /// </summary>
    public BlockClass VanillaClass { get; }

    /// <summary>
    /// <c>BlockBehaviour.useItemOn</c>: what the held item does to this block.
    /// <p/>
    /// The default is vanilla's, <c>TRY_WITH_EMPTY_HAND</c>, which asks for
    /// <see cref="UseWithoutItem"/> to be tried next rather than falling through to the item. Only
    /// eighteen classes override this one; most interactive blocks, doors and chests included,
    /// override <see cref="UseWithoutItem"/> instead.
    /// </summary>
    public InteractionResult UseItemOn(IBlock block, World world, Vec3<int> pos, Player player,
        Hand hand, ItemStack stack, BlockHit hit) => InteractionResult.TryWithEmptyHand;

    /// <summary>
    /// <c>BlockBehaviour.useWithoutItem</c>: what clicking this block does regardless of what is
    /// held. Vanilla only reaches it when <see cref="UseItemOn"/> asked for it <b>and</b> the click
    /// was with the main hand.
    /// <p/>
    /// The default is vanilla's, <c>PASS</c>: nothing happened, carry on to the held item.
    /// </summary>
    public InteractionResult UseWithoutItem(IBlock block, World world, Vec3<int> pos, Player player,
        BlockHit hit) => InteractionResult.Pass;
}
