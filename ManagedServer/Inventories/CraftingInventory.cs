using Minecraft.Data.Generated;
using Minecraft.Data.Inventories;
using Minecraft.Schemas.Items;

namespace ManagedServer.Inventories;

/// <summary>
/// A crafting table's window: a three by three grid and a result slot.
/// </summary>
/// <remarks>
/// <b>Opening one is not what makes it craft.</b> The window is inert on its own, as a bare
/// <see cref="ChestInventory"/> is; <c>CraftingFeature</c> is what fills the result slot.
/// </remarks>
public class CraftingInventory(ManagedMinecraftServer server) : Inventory(server, SlotCount, SlotCount) {
    /// <summary>The result slot plus the nine grid cells. Everything past it is window zero.</summary>
    public const int SlotCount = 10;

    /// <summary>The slot the result appears in, which no click may put anything into.</summary>
    public const int ResultSlot = 0;

    /// <summary>The top left cell. The nine run from here in row major order.</summary>
    public const int FirstGridSlot = 1;

    public const int GridWidth = 3;
    public const int GridHeight = 3;

    public override IInventoryType Type => InventoryType.Crafting;

    /// <summary>
    /// Nothing. A crafting window is not storage, so <see cref="Inventory.AddItem"/> hands the stack
    /// back rather than dropping it into the grid or the result slot.
    /// </summary>
    public override int[] AddItemSearchOrder => [];

    /// <summary>The nine cells, never the result slot.</summary>
    public override bool AcceptsQuickMove(int slot, ItemStack item) {
        return slot != ResultSlot;
    }

    /// <summary>
    /// A cell empties into the main inventory first. Only the result slot fills backwards, and
    /// <see cref="Features.Impl.CraftingFeature"/> owns that one.
    /// </summary>
    public override bool QuickMoveFillsBackwards(int slot) {
        return slot == ResultSlot;
    }

    /// <summary>A stack the grid will not take crosses the player's own two halves instead.</summary>
    public override bool QuickMoveFallsBackToPlayerSections => true;

    public CraftingInventory(ManagedMinecraftServer server, string title) : this(server) {
        Title = title;
    }
}
