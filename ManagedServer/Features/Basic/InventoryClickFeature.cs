using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Inventory;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Items;
using Newtonsoft.Json;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerDropItemEvent))]
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
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundClickContainerPacket packet) {
                return;
            }
            
            HandleInventoryClick(e.Player, packet);
        });
    }
    
    private static int GetRegularInvDestinationSlot(ItemStack item, Inventory.Inventory inv) {
        for (int i = 0; i < inv.Size; i++) {
            int maxStackSize = inv[i].GetMaxStackSize(DefaultMaxStackSize);
            if (inv[i].CanStackWith(item) && inv[i].Count < maxStackSize) {
                return i;
            }
        }

        for (int i = 0; i < inv.Size; i++) {
            if (inv[i].IsAir()) {
                return i;
            }
        }

        return -1;  // No available slot found
    }
    
    private static int GetPlayerInvDestinationSlot(ItemStack item, Inventory.Inventory inv) {
        for (int i = inv.PlayerInventoryStartIndex; i < inv.Size; i++) {
            int maxStackSize = inv[i].GetMaxStackSize(DefaultMaxStackSize);
            if (inv[i].CanStackWith(item) && inv[i].Count < maxStackSize) {
                return i;
            }
        }

        // no similar item found, so move to the first empty slot
        // start from the end of the player inventory to find an empty slot
        // hotbar slot 9 is the last actual inventory slot (the one after it is the offhand)
        // so start from there and go backwards
        for (int i = PlayerInventory.HotbarSlot9; i > inv.PlayerInventoryStartIndex; i--) {
            if (inv[i].IsAir()) {
                return i;
            }
        }
        
        return -1;  // No available slot found
    }
    
    private void HandleInventoryClick(PlayerEntity player, ServerBoundClickContainerPacket packet) {
        // player.SendMessage($"Inventory Clicked: {packet.Slot}, Mode: {packet.Mode}");
        Inventory.Inventory clickedInventory = packet.WindowId == 0 ? player.Inventory : player.OpenInventory!;
        Inventory.Inventory targetInventory = packet.Slot == -999 ? clickedInventory :
            packet.Slot >= clickedInventory.PlayerInventoryStartIndex ? player.Inventory : clickedInventory;
        int effectiveSlot = targetInventory == clickedInventory
            ? packet.Slot
            : packet.Slot - clickedInventory.PlayerInventoryStartIndex + player.Inventory.PlayerInventoryStartIndex;

        try
        {
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

                // Shift-click
                case 1: {
                    // Move to other container (identical for both left and right click)
                    // if the item is coming from the player inventory then it should go to the lowest id available slot in the other.
                    // if it's coming from the other container then it should go to the highest id available slot in the player inventory
                    // because mojang is weird like that.
                    ItemStack itemToMove = targetInventory[effectiveSlot];
                    bool isFromPlayerInventory = targetInventory == player.Inventory;
                    if (itemToMove.IsAir()) {
                        // Nothing to move
                        return;
                    }

                    Inventory.Inventory destinationInventory =
                        isFromPlayerInventory ? clickedInventory : player.Inventory;
                    Func<ItemStack, Inventory.Inventory, int> destinationSlotGetter = isFromPlayerInventory
                        ? GetRegularInvDestinationSlot
                        : GetPlayerInvDestinationSlot;

                    if (isFromPlayerInventory && destinationInventory == player.Inventory) {
                        // TODO
                        // They only have one inventory open (their own)
                        // This needs to be implemented
                        break;
                    }

                    // We'll keep trying to move more of the item until we run out of it or can't find a slot
                    while (true) {
                        int destinationSlot = destinationSlotGetter(itemToMove, destinationInventory);
                        if (destinationSlot == -1) {
                            targetInventory[effectiveSlot] =
                                itemToMove; // Put the rest of the item back in the original slot
                            break;
                        }

                        ItemStack destinationItem = destinationInventory[destinationSlot];
                        if (destinationItem.IsAir()) {
                            // If the best slot is empty, just move the whole itemstack there
                            targetInventory[effectiveSlot] = ItemStack.Air; // Clear the slot we moved from
                            destinationInventory[destinationSlot] = itemToMove;
                            break;
                        }

                        // Okay so it's stackable
                        int maxStackSize = destinationItem.GetMaxStackSize(DefaultMaxStackSize);
                        int newCount = Math.Min(itemToMove.Count + destinationItem.Count, maxStackSize);

                        int leftOverCount = itemToMove.Count + destinationItem.Count - newCount;
                        if (leftOverCount <= 0) {
                            // We moved all the item, so clear the slot we moved from
                            targetInventory[effectiveSlot] = ItemStack.Air;
                            destinationInventory[destinationSlot] = destinationItem.WithCount(newCount);
                            break;
                        }
                        
                        destinationInventory[destinationSlot] = destinationItem.WithCount(newCount);

                        // We didn't move all the item, so update the item to move
                        itemToMove = itemToMove.WithCount(leftOverCount);
                    }

                    break;
                }

                // Hotkey it into a slot
                case 2: {
                    int slotToSwapTo = packet.Button; // this is apparently a hotbar slot index

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
                                        Inventory.Inventory slotInventory =
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
                                        Inventory.Inventory slotInventory =
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
        player.Inventory.SendUpdateTo(player);
    }

    /// <summary>
    /// Process a drop action from the player.
    /// </summary>
    /// <param name="player">The player performing the drop.</param>
    /// <param name="item">The item being dropped.</param>
    /// <returns>Whether the item should be removed from the inventory.</returns>
    private bool HandleDrop(PlayerEntity player, ItemStack item) {
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
