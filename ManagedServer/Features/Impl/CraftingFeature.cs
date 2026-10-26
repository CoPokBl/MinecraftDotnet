using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Interaction;
using ManagedServer.Interaction.Rules;
using ManagedServer.Inventories;
using ManagedServer.Schemas;
using Minecraft.Data.Recipes;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Turns the grids into results: the two by two in a player's own inventory and the three by three of
/// a <see cref="CraftingInventory"/>.
/// </summary>
/// <remarks>
/// <paramref name="recipes"/> is <b>required</b>: nothing here ships any, see
/// <see cref="ICraftingRecipeSource"/>.
/// <p/>
/// <b>The feature owns the result slot outright.</b> Every click on it is cancelled before
/// <c>InventoryClickFeature</c> sees it and answered here, because taking the result and spending the
/// grid are one action: a generic click that moved the stack and left the grid alone is an infinite
/// supply of anything.
/// <p/>
/// The result is recomputed from <c>InventoryChangeEvent</c> rather than from the click, so a grid
/// filled by a command lights up too.
/// <p/>
/// Needs <c>InventoryClickFeature</c> registered to hear clicks and <c>InventoryClosingFeature</c> to
/// hear a window close. Neither is a constructor argument, since both are ordinary registrations.
/// </remarks>
/// <param name="openCraftingTables">
/// Whether to register the rule that opens a window on a crafting table. Off for a game whose
/// crafting tables are scenery.
/// </param>
[CallsEvent(typeof(PlayerDropItemEvent))]
public class CraftingFeature(ICraftingRecipeSource recipes, bool openCraftingTables = true)
    : ScopedFeature {

    /// <summary>
    /// A stop, not a rule: the loop terminates on its own, but a consumer's recipe that hands its own
    /// ingredients back must not hang the server on one click.
    /// </summary>
    private const int MaxCraftsPerShiftClick = 1024;

    /// <summary>The magic button for the offhand in a swap click, not a hotbar index.</summary>
    private const int OffhandButton = 40;

    /// <summary>Where the recipes come from.</summary>
    public ICraftingRecipeSource Recipes => recipes;

    public override void Register() {
        // Whatever wrote to the grid, the result follows it.
        AddEventHandler<InventoryChangeEvent>(e => {
            if (ResolveGrid(e.Inventory) is not { } grid) {
                return;
            }

            if (e.Slot < grid.FirstInputSlot || e.Slot >= grid.FirstInputSlot + grid.Width * grid.Height) {
                return;
            }

            // The write has not landed yet, so the changed slot's new value is substituted in.
            RefreshResult(grid, e.Slot, e.NewItem);
        });

        AddEventHandler<InventoryClearEvent>(e => {
            if (ResolveGrid(e.Inventory) is { } grid) {
                grid.Inventory[grid.ResultSlot] = ItemStack.Air;
            }
        });

        AddEventMutator<InventoryPreClickEvent>(e => {
            if (ResolveGrid(e.Inventory) is not { } grid || e.Slot != grid.ResultSlot) {
                return;
            }

            // Whatever happens next, the generic click handling must not touch this slot.
            e.Cancelled = true;
            Take(e.Player, grid, e.Type, e.Button, e.CursorItem);
        });

        AddEventHandler<PlayerCloseInventoryEvent>(e => {
            if (ResolveGrid(e.Inventory) is { } grid) {
                ReturnGrid(e.Player, grid);
            }
        });

        if (openCraftingTables) {
            AddInteractionRule(new CraftingTableInteractionRule());

            // A smithing table's class chain runs through CraftingTableBlock, so without this it
            // inherits the rule above and opens a crafting grid.
            AddInteractionRule(new SmithingTableInteractionRule());
        }
    }

    /// <summary>
    /// One grid inside an inventory. The two grids differ only in these numbers, so everything below
    /// is written once.
    /// </summary>
    private readonly record struct Grid(
        Inventory Inventory,
        int Width,
        int Height,
        int FirstInputSlot,
        int ResultSlot);

    /// <summary>
    /// The grid an inventory carries, or null. <b>An inventory with no grid must fall out here</b>:
    /// slot zero of a chest is a chest slot, and the click events carry the window rather than saying
    /// which.
    /// </summary>
    private static Grid? ResolveGrid(Inventory inventory) {
        return inventory switch {
            CraftingInventory => new Grid(inventory, CraftingInventory.GridWidth,
                CraftingInventory.GridHeight, CraftingInventory.FirstGridSlot,
                CraftingInventory.ResultSlot),

            PlayerInventory => new Grid(inventory, 2, 2, PlayerInventory.CraftingInput1Slot,
                PlayerInventory.CraftingOutputSlot),

            _ => null
        };
    }

    /// <summary>The grid, optionally with one slot's value replaced by one not yet written.</summary>
    private static CraftingInput.Positioned ReadGrid(Grid grid, int overriddenSlot = -1,
        ItemStack? overriding = null) {

        int cells = grid.Width * grid.Height;
        ItemStack[] items = new ItemStack[cells];

        for (int cell = 0; cell < cells; cell++) {
            int slot = grid.FirstInputSlot + cell;
            items[cell] = slot == overriddenSlot && overriding is not null
                ? overriding
                : grid.Inventory[slot];
        }

        return CraftingInput.OfPositioned(grid.Width, grid.Height, items);
    }

    /// <summary>What the grid currently makes, or air.</summary>
    private void RefreshResult(Grid grid, int overriddenSlot = -1, ItemStack? overriding = null) {
        CraftingInput input = ReadGrid(grid, overriddenSlot, overriding).Input;
        ICraftingRecipe? recipe = recipes.Find(input);
        ItemStack result = recipe?.Assemble(input) ?? ItemStack.Air;

        // Unconditional: a slot the client already agrees about costs one packet, a stale one is a
        // ghost item somebody can pick up.
        grid.Inventory[grid.ResultSlot] = result;
    }

    /// <summary>
    /// A click on the result slot. Every path either crafts or changes nothing; the click is already
    /// cancelled, so the player's view is resent either way.
    /// </summary>
    private void Take(Player player, Grid grid, ClickType type, int button, ItemStack cursor) {
        switch (type) {
            case ClickType.Regular:
                // Both buttons take the whole result: half a craft is not something a grid can be
                // spent on.
                TakeToCursor(player, grid);
                break;

            case ClickType.Shift:
                TakeToInventory(player, grid);
                break;

            case ClickType.HotkeyToSlot:
                TakeToHotbar(player, grid, button);
                break;

            case ClickType.Drop:
                // The drop key is gated on an empty cursor, so a press with something on the cursor
                // is not a drop.
                if (cursor.IsAir()) {
                    TakeToGround(player, grid);
                }

                break;

            // Middle click, drag and double click do nothing: a result slot refuses to be placed
            // into, and is left out of pick-all.
            default:
                break;
        }
    }

    /// <summary>One craft onto the cursor, which is the plain left or right click.</summary>
    private void TakeToCursor(Player player, Grid grid) {
        if (CurrentCraft(grid) is not { } craft || craft.Result.IsAir()) {
            return;
        }

        ItemStack cursor = player.CursorItem;

        if (cursor.IsAir()) {
            player.CursorItem = craft.Result;
        } else if (cursor.CanStackWith(craft.Result)
            && cursor.Count + craft.Result.Count <= cursor.GetMaxStackSize()) {

            player.CursorItem = cursor.WithCount(cursor.Count + craft.Result.Count);
        } else {
            // Nowhere to put it, so nothing is spent.
            return;
        }

        SpendOnce(player, grid, craft.Positioned, craft.Recipe);
        RefreshResult(grid);
    }

    /// <summary>
    /// Shift click: repeat <b>while the result slot keeps offering the same item</b>, not while the
    /// recipe stays the same, so a grid of mixed logs keeps making planks as the recipe underneath
    /// changes.
    /// </summary>
    /// <remarks>
    /// The crafts land in <see cref="PlayerInventory.BackwardsQuickMoveSlots"/> order, as everything
    /// out of a result slot does: <b>the last hotbar slot first</b>. The client draws its own answer
    /// in that order, so any other one is a stack that visibly jumps slot when the server's lands.
    /// </remarks>
    private void TakeToInventory(Player player, Grid grid) {
        ItemStack? first = null;

        for (int attempt = 0; attempt < MaxCraftsPerShiftClick; attempt++) {
            if (CurrentCraft(grid) is not { } craft || craft.Result.IsAir()) {
                break;
            }

            if (first is null) {
                first = craft.Result;
            } else if (!first.CanStackWith(craft.Result)) {
                break;
            }

            // All or nothing: a half fitting craft would spend the grid for items on the floor.
            if (player.Inventory.AddItem(craft.Result, true,
                    PlayerInventory.BackwardsQuickMoveSlots) is not null) {
                break;
            }

            SpendOnce(player, grid, craft.Positioned, craft.Recipe);
        }

        RefreshResult(grid);
    }

    /// <summary>
    /// A number key: one craft into that hotbar slot, or the offhand. A swap cannot put the hotbar's
    /// stack into a result slot, so only the <b>empty</b> target case is left: a key aimed at an
    /// occupied slot does nothing, even if the two stack.
    /// </summary>
    private void TakeToHotbar(Player player, Grid grid, int button) {
        if (button is not ((>= 0 and < 9) or OffhandButton)) {
            return;
        }

        int slot = button == OffhandButton ? PlayerInventory.OffhandSlot
            : PlayerInventory.HotbarSlot1 + button;

        if (!player.Inventory[slot].IsAir()) {
            return;
        }

        if (CurrentCraft(grid) is not { } craft || craft.Result.IsAir()) {
            return;
        }

        player.Inventory[slot] = craft.Result;
        SpendOnce(player, grid, craft.Positioned, craft.Recipe);
        RefreshResult(grid);
    }

    /// <summary>The drop key on the result slot: one craft, straight onto the ground.</summary>
    /// <remarks>
    /// <b>A deliberate divergence, in the player's favour.</b> The real game takes one item and then
    /// spends a whole craft, leaving the rest to be overwritten by the recompute, so the drop key on
    /// four torches throws one and destroys three. That was read off the source rather than measured
    /// in game, so an item sink is not copied on the strength of it.
    /// </remarks>
    private void TakeToGround(Player player, Grid grid) {
        if (CurrentCraft(grid) is not { } craft || craft.Result.IsAir()) {
            return;
        }

        PlayerDropItemEvent drop = new() {
            Player = player,
            Item = craft.Result,
            World = player.World!
        };
        CallEvent(drop);

        if (drop.Cancelled) {
            return;
        }

        SpendOnce(player, grid, craft.Positioned, craft.Recipe);
        RefreshResult(grid);
    }

    /// <summary>
    /// What the grid makes now, resolved fresh rather than read off the result slot, since a shift
    /// click changes the grid under itself.
    /// </summary>
    private (ICraftingRecipe Recipe, CraftingInput.Positioned Positioned, ItemStack Result)? CurrentCraft(
        Grid grid) {

        CraftingInput.Positioned positioned = ReadGrid(grid);
        ICraftingRecipe? recipe = recipes.Find(positioned.Input);

        return recipe is null ? null : (recipe, positioned, recipe.Assemble(positioned.Input));
    }

    /// <summary>
    /// One item out of every occupied cell, and whatever they leave behind put back. The walk is over
    /// the <b>cropped</b> input and offset by where it was cropped from.
    /// </summary>
    private static void SpendOnce(Player player, Grid grid, CraftingInput.Positioned positioned,
        ICraftingRecipe recipe) {

        CraftingInput input = positioned.Input;
        ItemStack[] remaining = recipe.GetRemainingItems(input);

        for (int y = 0; y < input.Height; y++) {
            for (int x = 0; x < input.Width; x++) {
                int slot = grid.FirstInputSlot + x + positioned.Left
                    + (y + positioned.Top) * grid.Width;

                ItemStack stack = grid.Inventory[slot];
                ItemStack replacement = remaining[x + y * input.Width];

                if (!stack.IsAir()) {
                    grid.Inventory[slot] = stack.SubtractCount(1);
                    stack = grid.Inventory[slot];
                }

                if (replacement.IsAir()) {
                    continue;
                }

                if (stack.IsAir()) {
                    grid.Inventory[slot] = replacement;
                } else if (stack.CanStackWith(replacement)) {
                    grid.Inventory[slot] = replacement.WithCount(replacement.Count + stack.Count);
                } else if (player.Inventory.AddItem(replacement) is { } leftover) {
                    player.World?.DropItem(player.Position + new Vec3<double>(0, 1, 0), leftover);
                }
            }
        }
    }

    /// <summary>
    /// The grid goes back to the player on close, and onto the floor if it will not fit. Runs for the
    /// player's own two by two too.
    /// </summary>
    private static void ReturnGrid(Player player, Grid grid) {
        for (int cell = 0; cell < grid.Width * grid.Height; cell++) {
            int slot = grid.FirstInputSlot + cell;

            if (grid.Inventory[slot].IsAir()) {
                continue;
            }

            if (player.Inventory.AddItem(grid.Inventory[slot]) is { } leftover) {
                player.World?.DropItem(player.Position + new Vec3<double>(0, 1, 0), leftover);
            }

            grid.Inventory[slot] = ItemStack.Air;
        }

        grid.Inventory[grid.ResultSlot] = ItemStack.Air;
    }
}
