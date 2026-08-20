using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Inventories;
using ManagedServer.Schemas;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Items;
using Newtonsoft.Json;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Feature that implements inventory click handling for players.
/// This includes handling left and right clicks, shift-clicks, hotkeying items, dragging
/// and dropping items, and double-clicking to collect items.
/// It also handles the drop key for dropping items from the inventory and fires the <see cref="PlayerDropItemEvent"/>.
/// </summary>
[CallsEvent(typeof(PlayerDropItemEvent), typeof(InventoryClickEvent), typeof(InventoryPreClickEvent))]
public class InventoryClickFeature : ScopedFeature {
    private static readonly Tag<DragType> DraggingTag = new("managedserver:inventoryclick:dragging");
    private static readonly Tag<List<int>> DragSlotsTag = new("managedserver:inventoryclick:drag_slots");
    private const int DefaultMaxStackSize = 64; // Default max stack size for items
    
    private enum DragType {
        None,
        LeftClick,
        RightClick
    }
    
    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundClickContainerPacket packet) {
                return;
            }
            
            HandleInventoryClick(e.Player, packet);
        });
    }
    
    /// <summary>
    /// The window's own slots, which is where a shift click out of the player's inventory aims.
    /// Which of them will actually have the stack is <see cref="Inventory.AcceptsQuickMove"/>.
    /// </summary>
    private static int[] WindowSlots(Inventory inventory) {
        return Enumerable.Range(0, inventory.PlayerInventoryStartIndex).ToArray();
    }

    /// <summary>
    /// The half of the player's inventory a stack in <paramref name="slot"/> crosses into: the hotbar
    /// for a main inventory slot, and back again.
    /// </summary>
    private static int[] PlayerSectionSwap(int slot) {
        return slot switch {
            >= PlayerInventory.RegularInventoryStartIndex and < PlayerInventory.HotbarSlot1 =>
                PlayerInventory.HotbarSlots,
            >= PlayerInventory.HotbarSlot1 and <= PlayerInventory.HotbarSlot9 =>
                PlayerInventory.MainInventorySlots,

            // The offhand, which has no other half: it empties into the whole inventory.
            _ => PlayerInventory.QuickMoveSlots
        };
    }

    /// <summary>
    /// The armour or offhand slot an item belongs in, if that slot is empty. Checked <b>before</b>
    /// the hotbar, so a helmet in the main inventory equips rather than moving down.
    /// </summary>
    private static int? EquipmentDestination(PlayerInventory inventory, ItemStack item) {
        int slot = item.GetOrNull(DataComponent.Equippable)?.Slot switch {
            EquippableComponent.Slot.Head => PlayerInventory.HelmetSlot,
            EquippableComponent.Slot.Chest => PlayerInventory.ChestplateSlot,
            EquippableComponent.Slot.Legs => PlayerInventory.LeggingsSlot,
            EquippableComponent.Slot.Feet => PlayerInventory.BootsSlot,
            EquippableComponent.Slot.OffHand => PlayerInventory.OffhandSlot,
            _ => -1
        };

        return slot != -1 && inventory[slot].IsAir() ? slot : null;
    }

    /// <summary>
    /// Where a shift click inside the player's own window sends the stack in <paramref name="slot"/>.
    /// </summary>
    private static int[] OwnInventoryDestination(PlayerInventory inventory, int slot, ItemStack item) {
        // The two by two and the armour slots empty into the whole inventory, main half first. This
        // comes before the equipment check, so a helmet taken off does not put itself back on.
        if (slot is >= PlayerInventory.CraftingInput1Slot and <= PlayerInventory.BootsSlot) {
            return PlayerInventory.QuickMoveSlots;
        }

        if (EquipmentDestination(inventory, item) is { } equipment) {
            return [equipment];
        }

        return PlayerSectionSwap(slot);
    }

    /// <summary>
    /// Top up every stack in <paramref name="order"/> that will take some, then put whatever is left
    /// in the first empty slot in it. Anything still left over stays where it came from.
    /// </summary>
    /// <remarks>
    /// <paramref name="order"/> carries both the destination and the direction, so a caller that has
    /// the order right cannot get the direction wrong. It must not contain
    /// <paramref name="originSlot"/>.
    /// </remarks>
    /// <returns>Whether any of it moved.</returns>
    private static bool TransferItemToInventorySection(ItemStack itemToMove, int originSlot,
        Inventory originInventory, Inventory destinationInventory, int[] order) {
        ItemStack remaining = itemToMove;

        foreach (int slot in order) {
            if (remaining.IsAir()) {
                break;
            }

            ItemStack destination = destinationInventory[slot];
            if (destination.IsAir() || !destination.CanStackWith(remaining)
                || !destinationInventory.AcceptsQuickMove(slot, remaining)) {
                continue;
            }

            int maxStackSize = destination.GetMaxStackSize(DefaultMaxStackSize);
            if (destination.Count >= maxStackSize) {
                continue;
            }

            int moved = Math.Min(maxStackSize - destination.Count, remaining.Count);
            destinationInventory[slot] = destination.WithCount(destination.Count + moved);
            remaining = remaining.Count > moved ? remaining.WithCount(remaining.Count - moved) : ItemStack.Air;
        }

        // One empty slot, not every empty slot.
        if (!remaining.IsAir()) {
            foreach (int slot in order) {
                if (!destinationInventory[slot].IsAir()
                    || !destinationInventory.AcceptsQuickMove(slot, remaining)) {
                    continue;
                }

                int moved = Math.Min(remaining.GetMaxStackSize(DefaultMaxStackSize), remaining.Count);
                destinationInventory[slot] = remaining.WithCount(moved);
                remaining = remaining.Count > moved ? remaining.WithCount(remaining.Count - moved) : ItemStack.Air;
                break;
            }
        }

        if (remaining.Count == itemToMove.Count && !remaining.IsAir()) {
            return false;  // Nothing fit, so the origin slot is untouched.
        }

        originInventory[originSlot] = remaining;
        return true;
    }

    private void HandleInventoryClick(Player player, ServerBoundClickContainerPacket packet) {
        // player.SendMessage($"Inventory Clicked: {packet.Slot}, Mode: {packet.Mode}");
        Inventory clickedInventory = packet.WindowId == 0 ? player.Inventory : player.OpenInventory!;
        Inventory targetInventory = packet.Slot == -999 ? clickedInventory :
            packet.Slot >= clickedInventory.PlayerInventoryStartIndex ? player.Inventory : clickedInventory;
        int effectiveSlot = targetInventory == clickedInventory
            ? packet.Slot
            : packet.Slot - clickedInventory.PlayerInventoryStartIndex + player.Inventory.PlayerInventoryStartIndex;

        ClickType type = packet.Mode switch {
            0 => ClickType.Regular,
            1 => ClickType.Shift,
            2 => ClickType.HotkeyToSlot,
            3 => ClickType.Middle,
            4 => ClickType.Drop,
            5 => ClickType.Drag,
            6 => ClickType.Double,
            _ => throw new ArgumentOutOfRangeException()
        };
        
        InventoryPreClickEvent preClickEvent = new() {
            Player = player,
            Inventory = clickedInventory,
            Slot = effectiveSlot,
            ClickedItem = effectiveSlot >= 0 ? targetInventory[effectiveSlot] : null,
            CursorItem = player.CursorItem,
            World = player.World!,
            Type = type,
            Button = packet.Button
        };
        CallEvent(preClickEvent);

        if (preClickEvent.Cancelled) {
            clickedInventory.SendUpdateTo(player);
            if (clickedInventory != player.Inventory) {
                player.Inventory.SendUpdateTo(player);
            }
            return; // Cancelled the click, so do nothing
        }
        
        try {
            switch (packet.Mode) {
                // Regular clicks (left and right)
                case 0: {
                    switch (packet.Button) {
                        // Left click (apply to whole stack)
                        case 0: {
                            if (packet.Slot < 0) {
                                // Clicked outside the inventory (so drop stack)
                                bool removeItem = HandleDrop(player, player.CursorItem);
                                player.CursorItem = removeItem ? ItemStack.Air : player.CursorItem;
                            }
                            else {
                                if (targetInventory[effectiveSlot].CanStackWith(player.CursorItem)) {
                                    // Clicked inside the inventory (stack with cursor)
                                    int newCount = targetInventory[effectiveSlot].Count + player.CursorItem.Count;
                                    int maxStackSize = player.CursorItem.GetMaxStackSize(DefaultMaxStackSize);
                                    if (newCount > maxStackSize) {
                                        // If the new count exceeds the max stack size, split the items
                                        int excessCount = newCount - maxStackSize;
                                        targetInventory[effectiveSlot] =
                                            targetInventory[effectiveSlot].WithCount(maxStackSize);
                                        player.CursorItem = player.CursorItem.WithCount(excessCount);
                                    }
                                    else {
                                        // Otherwise, just stack them
                                        targetInventory[effectiveSlot] =
                                            targetInventory[effectiveSlot].WithCount(newCount);
                                        player.CursorItem = ItemStack.Air; // Clear cursor item
                                    }
                                }
                                else {
                                    // Clicked inside the inventory (swap with cursor)
                                    (targetInventory[effectiveSlot], player.CursorItem) =
                                        (player.CursorItem, targetInventory[effectiveSlot]);
                                }
                            }

                            break;
                        }

                        // Right click (split stack or drop single item)
                        case 1: {
                            if (player.CursorItem.IsAir()) {
                                if (packet.Slot < 0) {
                                    // Drop single item
                                    // They right-clicked outside the inventory, but have no item in cursor
                                }
                                else {
                                    // Right click inside the inventory (split stack)
                                    ItemStack currentItem = targetInventory[effectiveSlot];
                                    if (currentItem.Count > 1) {
                                        int halfCount = currentItem.Count / 2;
                                        targetInventory[effectiveSlot] = currentItem.WithCount(halfCount);
                                        player.CursorItem = currentItem.WithCount(currentItem.Count - halfCount);
                                    }
                                }
                            }
                            else {
                                if (packet.Slot < 0) {
                                    // Drop single item
                                    bool removeSingleItem = HandleDrop(player, player.CursorItem.WithCount(1));
                                    if (removeSingleItem) {
                                        player.CursorItem = player.CursorItem.Count > 1
                                            ? player.CursorItem.WithCount(player.CursorItem.Count - 1)
                                            : ItemStack.Air; // Drop single item
                                    }
                                }
                                else {
                                    // Right click inside the inventory with item in cursor
                                    if (targetInventory[effectiveSlot].CanStackWith(player.CursorItem) ||
                                        targetInventory[effectiveSlot].IsAir()) {
                                        // deposit one of the cursor items into the slot
                                        int newCount = targetInventory[effectiveSlot].Count + 1;
                                        int maxStackSize = player.CursorItem.GetMaxStackSize(DefaultMaxStackSize);
                                        if (newCount > maxStackSize) {
                                            // not allowed, do nothing
                                        }
                                        else {
                                            // If the new count does not exceed the max stack size, stack it
                                            targetInventory[effectiveSlot] = player.CursorItem.WithCount(newCount);
                                            player.CursorItem = player.CursorItem.Count > 1
                                                ? player.CursorItem.WithCount(player.CursorItem.Count - 1)
                                                : ItemStack.Air; // They deposited all of the cursor item
                                        }
                                    }
                                    else {
                                        // Swap cursor item with the slot item
                                        (targetInventory[effectiveSlot], player.CursorItem) =
                                            (player.CursorItem, targetInventory[effectiveSlot]);
                                    }
                                }
                            }

                            break;
                        }
                    }

                    break;
                }

                // Shift-click, which moves the stack somewhere else outright. Left and right click
                // are identical.
                case 1: {
                    if (effectiveSlot < 0) {
                        // A shift click on the space outside the window, which has nothing to move.
                        break;
                    }

                    ItemStack itemToMove = targetInventory[effectiveSlot];
                    if (itemToMove.IsAir()) {
                        // Nothing to move
                        return;
                    }

                    if (clickedInventory == player.Inventory) {
                        // Their own window, so the two by two, the armour and both halves are in play.
                        TransferItemToInventorySection(itemToMove, effectiveSlot, player.Inventory,
                            player.Inventory,
                            OwnInventoryDestination(player.Inventory, effectiveSlot, itemToMove));
                        break;
                    }

                    if (targetInventory == clickedInventory) {
                        // Out of the open window and into the player's inventory, which is the only
                        // direction a window's own slot moves in.
                        TransferItemToInventorySection(itemToMove, effectiveSlot, clickedInventory,
                            player.Inventory,
                            clickedInventory.QuickMoveFillsBackwards(effectiveSlot)
                                ? PlayerInventory.BackwardsQuickMoveSlots
                                : PlayerInventory.QuickMoveSlots);
                        break;
                    }

                    // Out of the player's inventory and into the open window. Its own slots say which
                    // of them will have it, so a result slot is not among them.
                    if (TransferItemToInventorySection(itemToMove, effectiveSlot, player.Inventory,
                            clickedInventory, WindowSlots(clickedInventory))
                        || !clickedInventory.QuickMoveFallsBackToPlayerSections) {
                        break;
                    }

                    // The window would take none of it, so the stack crosses the player's own two
                    // halves instead. Only some windows do this; a chest leaves the stack where it is.
                    TransferItemToInventorySection(itemToMove, effectiveSlot, player.Inventory,
                        player.Inventory, PlayerSectionSwap(effectiveSlot));
                    break;
                }

                // Hotkey it into a slot
                case 2: {
                    int slotToSwapTo = packet.Button; // this is apparently a hotbar slot index
                    if (slotToSwapTo == 40) {  // Magic number for offhand slot
                        // TODO: Stop putting offhand into armour slot when it's not a valid armour piece
                        (player.Inventory.Offhand, targetInventory[effectiveSlot]) = (targetInventory[effectiveSlot], player.Inventory.Offhand);
                        break;
                    }

                    ItemStack hotBarItem = player.Inventory.GetHotbarItem(slotToSwapTo);
                    player.Inventory.SetHotbarItem(slotToSwapTo, targetInventory[effectiveSlot]);
                    targetInventory[effectiveSlot] = hotBarItem;
                    break;
                }

                // Middle click (only exists in creative mode, duplicates item)
                case 3: {
                    break; // TODO
                }

                // Drop key
                case 4: {
                    if (packet.Slot == -999) {
                        return;  // drop key outside of inventory, so do nothing
                    }
                    
                    switch (packet.Button) {
                        case 0: // Drop key, so drop one (usually Q)
                            if (!HandleDrop(player, targetInventory[effectiveSlot].WithCount(1))) {
                                break;
                            }

                            targetInventory[effectiveSlot] = targetInventory[effectiveSlot].Count > 1
                                ? targetInventory[effectiveSlot].WithCount(targetInventory[effectiveSlot].Count - 1)
                                : // There is more than one item, so subtract one
                                ItemStack.Air; // There is only one item, so drop it all
                            break;

                        case 1: // Control + Drop key, so drop all (usually Ctrl + Q)
                            if (!HandleDrop(player, targetInventory[effectiveSlot])) {
                                break;
                            }

                            targetInventory[effectiveSlot] = ItemStack.Air; // Drop all items in the slot
                            break;
                    }

                    break;
                }

                // Dragging (paint mode)
                case 5: {
                    bool updateInventory = false;
                    switch (packet.Button) {
                        case 0: // Left click (start dragging)
                            player.SetTag(DraggingTag, DragType.LeftClick);
                            break;

                        case 4:
                            // Right click (start dragging)
                            player.SetTag(DraggingTag, DragType.RightClick);
                            break;

                        case 8: // Middle click (start dragging)
                            break;

                        case 9:
                        case 5:
                        case 1: // Add slot for left click drag
                            List<int> slots = player.GetTagOrDefault(DragSlotsTag, []);
                            if (!slots.Contains(packet.Slot)) {
                                slots.Add(packet.Slot);
                                player.SetTag(DragSlotsTag, slots);
                            }

                            break;

                        case 2:
                        case 6:
                        case 10: // End drag
                            updateInventory = true;
                            List<int> slotsToUpdate = player.GetTagOrDefault(DragSlotsTag, []);
                            DragType dragType = player.GetTagOrDefault(DraggingTag, DragType.None);
                            if (dragType == DragType.None) {
                                // huh
                                player.SendMessage("You wot mate? No drag type set.");
                                return;
                            }

                            ItemStack itemToSplit = player.CursorItem;
                            switch (dragType) {
                                case DragType.LeftClick: // Split items across slots
                                    int itemsPerSplit = itemToSplit.Count / slotsToUpdate.Count;
                                    int remainder = itemToSplit.Count % slotsToUpdate.Count;
                                    // player.SendMessage("Splitting " + itemToSplit.Count + " items into " + slotsToUpdate.Count + " slots, "
                                    //                    + itemsPerSplit + " per slot, with " + remainder + " remainder.");

                                    foreach (int slotIndex in slotsToUpdate) {
                                        Inventory slotInventory =
                                            slotIndex >= clickedInventory.PlayerInventoryStartIndex
                                                ? player.Inventory
                                                : clickedInventory;
                                        int targetIndex = slotIndex >= clickedInventory.PlayerInventoryStartIndex
                                            ? slotIndex - clickedInventory.PlayerInventoryStartIndex +
                                              player.Inventory.PlayerInventoryStartIndex
                                            : slotIndex;

                                        ItemStack currentItem = slotInventory[targetIndex];
                                        int existingCount = currentItem.IsAir() ? 0 : currentItem.Count;
                                        int maxStackSize = itemToSplit.GetMaxStackSize(DefaultMaxStackSize);

                                        // So if the current item can be stacked with the item to split
                                        // then we should add it to the stack. If it can't then we'll 
                                        // skip that slot. Vanilla clients only send the slots that can
                                        // be stacked with the item to split. So we'll assume that all
                                        // slots are valid for stacking.
                                        if (!currentItem.IsAir() &&
                                            !currentItem.CanStackWith(itemToSplit.WithCount(itemsPerSplit))) continue;
                                        // Add the count
                                        int wantedCount = itemsPerSplit + existingCount;
                                        int splitCount = Math.Min(wantedCount, maxStackSize);
                                        remainder += wantedCount - splitCount; // Add any excess to the remainder
                                        slotInventory[targetIndex] = itemToSplit.WithCount(splitCount);
                                    }

                                    // Now the cursor item should be the remainder (unless it's 0)
                                    player.CursorItem = remainder == 0
                                        ? ItemStack.Air
                                        : player.CursorItem.WithCount(remainder);
                                    break;

                                case DragType.RightClick: // One item per drag (max of the itemToSplit count)
                                    foreach (int slotIndex in slotsToUpdate) {
                                        Inventory slotInventory =
                                            slotIndex >= clickedInventory.PlayerInventoryStartIndex
                                                ? player.Inventory
                                                : clickedInventory;
                                        int targetIndex = slotIndex >= clickedInventory.PlayerInventoryStartIndex
                                            ? slotIndex - clickedInventory.PlayerInventoryStartIndex +
                                              player.Inventory.PlayerInventoryStartIndex
                                            : slotIndex;

                                        ItemStack currentItem = slotInventory[targetIndex];
                                        int existingCount = currentItem.IsAir() ? 0 : currentItem.Count;
                                        bool isMaxStack = currentItem.GetMaxStackSize(DefaultMaxStackSize) <=
                                                          existingCount;
                                        if ((currentItem.IsAir() ||
                                             currentItem.CanStackWith(itemToSplit.WithCount(1))) &&
                                            !isMaxStack &&
                                            itemToSplit.Count > 0) {
                                            // If we:
                                            // 1. Still have items left on the cursor to split
                                            // 2. Are currently in an empty slot or a stack that can be stacked with the item to split
                                            // and isn't already full
                                            // then we can add one item to the slot
                                            slotInventory[targetIndex] = itemToSplit.WithCount(existingCount + 1);
                                            itemToSplit = itemToSplit.WithCount(itemToSplit.Count - 1);
                                        }
                                    }

                                    if (itemToSplit.Count <= 0) {
                                        itemToSplit = ItemStack.Air;
                                    }

                                    player.CursorItem = itemToSplit;
                                    break;

                            }

                            player.SetTag(DraggingTag, DragType.None);
                            player.SetTag(DragSlotsTag, []); // Clear the drag slots
                            break;
                    }

                    // Don't update inventory until end of drag
                    if (!updateInventory) return;
                    break;
                }

                // Double click (collect to cursor)
                // Vanilla clients send a left click first and then a double click
                // So the item we're collecting is already in the cursor
                case 6: {
                    ItemStack itemToCollect = player.CursorItem;
                    if (itemToCollect.IsAir()) {
                        // Nothing to collect
                        break;
                    }

                    if (!targetInventory[effectiveSlot].IsAir()) {
                        // If the clicked slot item, swap it with the cursor item (like a left click)
                        (targetInventory[effectiveSlot], player.CursorItem) =
                            (player.CursorItem, targetInventory[effectiveSlot]);
                        break;
                    }

                    int maxStackSize = itemToCollect.GetMaxStackSize(DefaultMaxStackSize);
                    if (itemToCollect.Count >= maxStackSize) {
                        // Already full stack, so do nothing
                        break;
                    }

                    // Collect all similar items from both the clicked inventory and the player's inventory
                    // but start with the clicked inventory
                    for (int i = 0; i < clickedInventory.Size; i++) {
                        ItemStack item = clickedInventory[i];
                        if (!item.CanStackWith(itemToCollect)) {
                            continue;
                        }

                        // Okay it's a similar item, collect it
                        int needed = maxStackSize - itemToCollect.Count;

                        if (needed >= item.Count) {
                            // Collect all of it
                            clickedInventory[i] = ItemStack.Air; // Remove it from the clicked inventory
                            itemToCollect = itemToCollect.WithCount(itemToCollect.Count + item.Count);
                        }
                        else {
                            // We only need some of it
                            clickedInventory[i] = item.WithCount(item.Count - needed);
                            itemToCollect = itemToCollect.WithCount(maxStackSize); // Fill the stack
                            break;
                        }

                        if (itemToCollect.Count >= maxStackSize) {
                            // We filled the stack, so stop collecting
                            break;
                        }
                    }

                    // Now collect from the player's inventory
                    if (itemToCollect.Count < maxStackSize) {
                        // but only if we still need more items
                        for (int i = player.Inventory.PlayerInventoryStartIndex; i < PlayerInventory.HotbarSlot9; i++) {
                            ItemStack item = player.Inventory[i];
                            if (!item.CanStackWith(itemToCollect)) {
                                continue;
                            }

                            // Okay it's a similar item, collect it
                            int needed = maxStackSize - itemToCollect.Count;

                            if (needed >= item.Count) {
                                // Collect all of it
                                player.Inventory[i] = ItemStack.Air; // Remove it from the clicked inventory
                                itemToCollect = itemToCollect.WithCount(itemToCollect.Count + item.Count);
                            }
                            else {
                                // We only need some of it
                                player.Inventory[i] = item.WithCount(item.Count - needed);
                                itemToCollect = itemToCollect.WithCount(maxStackSize); // Fill the stack
                                break;
                            }

                            if (itemToCollect.Count >= maxStackSize) {
                                // We filled the stack, so stop collecting
                                break;
                            }
                        }
                    }

                    // Finally, set the cursor item to the collected item and clear the slot
                    player.CursorItem = itemToCollect;
                    break;
                }
            }
        }
        catch (Exception e) {
            Console.WriteLine("Error handling inventory click:");
            Console.WriteLine(e);
            Console.WriteLine("Packet: " + JsonConvert.SerializeObject(packet));
        }

        clickedInventory.SendUpdateTo(player);
        if (clickedInventory != player.Inventory) {
            player.Inventory.SendUpdateTo(player);
        }
        
        InventoryClickEvent clickEvent = new() {
            Player = player,
            Inventory = clickedInventory,
            Slot = effectiveSlot,
            ClickedItem = effectiveSlot >= 0 ? targetInventory[effectiveSlot] : null,
            CursorItem = player.CursorItem,
            World = player.World!,
            Type = type
        };
        CallEvent(clickEvent);
    }

    /// <summary>
    /// Process a drop action from the player.
    /// </summary>
    /// <param name="player">The player performing the drop.</param>
    /// <param name="item">The item being dropped.</param>
    /// <returns>Whether the item should be removed from the inventory.</returns>
    private bool HandleDrop(Player player, ItemStack item) {
        if (item.IsAir()) {
            return false;
        }
        PlayerDropItemEvent e = new() {
            Player = player,
            Item = item,
            World = player.World!
        };
        Scope.Events.CallEvent(e);
        
        return !e.Cancelled;
    }
}
