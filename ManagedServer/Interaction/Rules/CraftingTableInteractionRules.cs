using ManagedServer.Entities.Types;
using ManagedServer.Inventories;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace ManagedServer.Interaction.Rules;

/// <summary>
/// <c>CraftingTableBlock.useWithoutItem</c>: right clicking a crafting table opens a grid.
/// </summary>
/// <remarks>
/// <b>Registered by <c>CraftingFeature</c> rather than by <c>VanillaBlockInteractions</c></b>: a
/// window that opens and never fills its result slot is worse than a block that does nothing, so the
/// rule belongs to the thing that answers it.
/// <p/>
/// <c>Stats.INTERACT_WITH_CRAFTING_TABLE</c> is skipped; there is no statistics system.
/// </remarks>
public sealed class CraftingTableInteractionRule : IBlockInteractionRule {
    /// <summary>Vanilla's <c>CONTAINER_TITLE</c>.</summary>
    public static readonly TextComponent ContainerTitle = TextComponent.Translatable("container.crafting");

    public BlockClass VanillaClass => BlockClass.CraftingTableBlock;

    public InteractionResult UseWithoutItem(IBlock block, World world, Vec3<int> pos, Player player,
        BlockHit hit) {

        player.OpenInventory = new CraftingInventory(player.Server) { Title = ContainerTitle };
        return InteractionResult.Success;
    }
}

/// <summary>
/// <c>SmithingTableBlock.useWithoutItem</c>, which opens a smithing menu that has no port here.
/// </summary>
/// <remarks>
/// <b>This rule exists to stop something happening.</b> A smithing table's class chain runs through
/// <c>CraftingTableBlock</c>, so without an entry of its own it would inherit
/// <see cref="CraftingTableInteractionRule"/> and open a crafting grid. Upstream's answer is the same,
/// an override on the subclass.
/// <p/>
/// It answers <c>SUCCESS</c> and opens nothing, which is vanilla's return value with the menu it
/// cannot build left out.
/// </remarks>
public sealed class SmithingTableInteractionRule : IBlockInteractionRule {
    public BlockClass VanillaClass => BlockClass.SmithingTableBlock;

    public InteractionResult UseWithoutItem(IBlock block, World world, Vec3<int> pos, Player player,
        BlockHit hit) {

        return InteractionResult.Success;
    }
}
