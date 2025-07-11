using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Data;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Items;
using static Minecraft.Data.Items.IItem;

namespace ManagedServer.Features.Basic;

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
    
    private static void HandleInventoryClick(PlayerEntity player, ServerBoundClickContainerPacket packet) {
        player.SendMessage("Inventory Clicked: " + packet.Slot);
        Inventory.Inventory clickedInventory = packet.WindowId == 0 ? player.Inventory : player.OpenInventory!;
        Inventory.Inventory targetInventory = packet.Slot == -999 ? clickedInventory :
            packet.Slot >= clickedInventory.PlayerInventoryStartIndex ? player.Inventory : clickedInventory;
        int effectiveSlot = targetInventory == clickedInventory
            ? packet.Slot
            : packet.Slot - clickedInventory.PlayerInventoryStartIndex + player.Inventory.PlayerInventoryStartIndex;

        switch (packet.Mode) {
            // Regular clicks (left and right)
            case 0: {
                switch (packet.Button) {
                    // Left click (apply to whole stack)
                    case 0: {
                        if (packet.Slot < 0) {
                            // Clicked outside the inventory (so drop it I guess)
                            player.CursorItem = packet.Button switch {
                                0 => // Left click (drop stack)
                                    ItemStack.Air,
                                1 => // Right click (drop single item)
                                    player.CursorItem.Count > 1
                                        ? player.CursorItem.WithCount(player.CursorItem.Count - 1)
                                        : // There is more than one item, so subtract one
                                        ItemStack.Air // There is only one item, so drop it all
                                ,
                                _ => throw new ArgumentOutOfRangeException($"Unknown button type: {packet.Button}")
                            };
                        }
                        else {
                            if (targetInventory[effectiveSlot].CanStackWith(player.CursorItem)) {
                                // Clicked inside the inventory (stack with cursor)
                                int newCount = targetInventory[effectiveSlot].Count + player.CursorItem.Count;
                                int maxStackSize = player.CursorItem.Get(DataComponent.MaxStackSize)?.Value ?? DefaultMaxStackSize;
                                if (newCount > maxStackSize) {
                                    // If the new count exceeds the max stack size, split the items
                                    int excessCount = newCount - maxStackSize;
                                    targetInventory[effectiveSlot] = targetInventory[effectiveSlot].WithCount(maxStackSize);
                                    player.CursorItem = player.CursorItem.WithCount(excessCount);
                                }
                                else {
                                    // Otherwise, just stack them
                                    targetInventory[effectiveSlot] = targetInventory[effectiveSlot].WithCount(newCount);
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
                            if (packet.Slot < 0) {  // Drop single item
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
                            if (packet.Slot < 0) {  // Drop single item
                                player.CursorItem = player.CursorItem.Count > 1
                                    ? player.CursorItem.WithCount(player.CursorItem.Count - 1)
                                    : ItemStack.Air; // Drop single item
                            }
                            else {
                                // Right click inside the inventory with item in cursor
                                if (targetInventory[effectiveSlot].CanStackWith(player.CursorItem) || targetInventory[effectiveSlot].IsAir()) {
                                    // deposit one of the cursor items into the slot
                                    int newCount = targetInventory[effectiveSlot].Count + 1;
                                    int maxStackSize = player.CursorItem.Get(DataComponent.MaxStackSize)?.Value ?? DefaultMaxStackSize;
                                    if (newCount > maxStackSize) {
                                        // not allowed, do nothing
                                    }
                                    else {
                                        // If the new count does not exceed the max stack size, stack it
                                        targetInventory[effectiveSlot] = player.CursorItem.WithCount(newCount);
                                        player.CursorItem = player.CursorItem.Count > 1 ? 
                                            player.CursorItem.WithCount(player.CursorItem.Count - 1) :
                                            ItemStack.Air; // They deposited all of the cursor item
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
            case 1: {  // Move to other container (identical for both left and right click)
                // if the item is coming from the player inventory then it should go to the lowest id available slot in the other.
                // if it's coming from the other container then it should go to the highest id available slot in the player inventory
                // because mojang is weird like that.
                ItemStack itemToMove = targetInventory[effectiveSlot];
                bool isFromPlayerInventory = targetInventory == player.Inventory;
                if (itemToMove.IsAir()) {
                    // Nothing to move
                    return;
                }

                if (isFromPlayerInventory) {  // going to non player inventory (like a chest)
                    // check if a similar item exists in the target inventory
                    bool foundSimilarItem = false;
                    for (int i = 0; i < clickedInventory.Size; i++) {
                        if (clickedInventory[i].CanStackWith(itemToMove)) {
                            // Found a slot to stack it
                            int newCount = clickedInventory[i].Count + itemToMove.Count;
                            int maxStackSize = itemToMove.Get(DataComponent.MaxStackSize)?.Value ?? DefaultMaxStackSize;
                            if (newCount > maxStackSize) {
                                // If the new count exceeds the max stack size, split the items
                                int excessCount = newCount - maxStackSize;
                                clickedInventory[i] = clickedInventory[i].WithCount(maxStackSize);
                                targetInventory[effectiveSlot] = itemToMove.WithCount(excessCount);
                            }
                            else {
                                // Otherwise, just stack them
                                clickedInventory[i] = clickedInventory[i].WithCount(newCount);
                                targetInventory[effectiveSlot] = ItemStack.Air;  // Clear the slot that it came from
                            }
                            
                            foundSimilarItem = true;
                            break;  // Exit the loop after stacking
                        }
                    }

                    if (!foundSimilarItem) {  // no similar item found, so move to the first empty slot
                        for (int i = 0; i < clickedInventory.Size; i++) {
                            if (clickedInventory[i].IsAir()) {
                                clickedInventory[i] = itemToMove;
                                targetInventory[effectiveSlot] = ItemStack.Air;  // Clear the slot that it came from
                                break;  // Exit the loop after moving
                            }
                        }
                    }
                }
                else {  // It's going into the player's inventory
                    // check if a similar item exists in the player inventory
                    bool foundSimilarItem = false;
                    for (int i = player.Inventory.PlayerInventoryStartIndex; i < player.Inventory.Size; i++) {
                        if (player.Inventory[i].CanStackWith(itemToMove)) {
                            // Found a slot to stack it
                            int newCount = player.Inventory[i].Count + itemToMove.Count;
                            int maxStackSize = itemToMove.Get(DataComponent.MaxStackSize)?.Value ?? DefaultMaxStackSize;
                            if (newCount > maxStackSize) {
                                // If the new count exceeds the max stack size, split the items
                                int excessCount = newCount - maxStackSize;
                                player.Inventory[i] = player.Inventory[i].WithCount(maxStackSize);
                                targetInventory[effectiveSlot] = itemToMove.WithCount(excessCount);
                            }
                            else {
                                // Otherwise, just stack them
                                player.Inventory[i] = player.Inventory[i].WithCount(newCount);
                                targetInventory[effectiveSlot] = ItemStack.Air;  // Clear the slot that it came from
                            }
                            
                            foundSimilarItem = true;
                            break;  // Exit the loop after stacking
                        }
                    }

                    if (!foundSimilarItem) {  // no similar item found, so move to the first empty slot
                        // start from the end of the player inventory to find an empty slot
                        for (int i = player.Inventory.Size - 1; i > player.Inventory.PlayerInventoryStartIndex; i--) {
                            if (player.Inventory[i].IsAir()) {
                                player.Inventory[i] = itemToMove;
                                targetInventory[effectiveSlot] = ItemStack.Air;  // Clear the slot that it came from
                                break;  // Exit the loop after moving
                            }
                        }
                    }
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
                switch (packet.Button) {
                    case 0: // Drop key, so drop one (usually Q)
                        targetInventory[effectiveSlot] = targetInventory[effectiveSlot].Count > 1
                            ? targetInventory[effectiveSlot].WithCount(targetInventory[effectiveSlot].Count - 1)
                            : // There is more than one item, so subtract one
                            ItemStack.Air; // There is only one item, so drop it all
                        break;

                    case 1: // Control + Drop key, so drop all (usually Ctrl + Q)
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
                                player.SendMessage("Splitting " + itemToSplit.Count + " items into " + slotsToUpdate.Count + " slots, "
                                                   + itemsPerSplit + " per slot, with " + remainder + " remainder.");

                                for (int i = 0; i < slotsToUpdate.Count; i++) {
                                    int slotIndex = slotsToUpdate[i];
                                    Inventory.Inventory slotInventory = slotIndex >= clickedInventory.PlayerInventoryStartIndex
                                        ? player.Inventory
                                        : clickedInventory;
                                    int targetIndex = slotIndex >= clickedInventory.PlayerInventoryStartIndex
                                        ? slotIndex - clickedInventory.PlayerInventoryStartIndex + player.Inventory.PlayerInventoryStartIndex
                                        : slotIndex;
                                    
                                    ItemStack currentItem = slotInventory[targetIndex];
                                    if (IProtocolType.Equals(currentItem.Type, Item.Air)) {
                                        slotInventory[targetIndex] =
                                            itemToSplit.WithCount(itemsPerSplit + (i < remainder ? 1 : 0));
                                    }
                                }
                                
                                // Now the cursor item should be empty
                                player.CursorItem = ItemStack.Air;
                                break;
                            
                            case DragType.RightClick:  // One item per drag (max of the itemToSplit count)
                                foreach (int slotIndex in slotsToUpdate) {
                                    Inventory.Inventory slotInventory = slotIndex >= clickedInventory.PlayerInventoryStartIndex
                                        ? player.Inventory
                                        : clickedInventory;
                                    int targetIndex = slotIndex >= clickedInventory.PlayerInventoryStartIndex
                                        ? slotIndex - clickedInventory.PlayerInventoryStartIndex + player.Inventory.PlayerInventoryStartIndex
                                        : slotIndex;

                                    ItemStack currentItem = slotInventory[targetIndex];
                                    if (IProtocolType.Equals(currentItem.Type, Item.Air)) {
                                        if (itemToSplit.Count > 0) {
                                            slotInventory[targetIndex] = itemToSplit.WithCount(1);
                                            itemToSplit = itemToSplit.WithCount(itemToSplit.Count - 1);
                                        }
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
            case 6: {
                break;  // TODO
            }
        }

        clickedInventory.SendUpdateTo(player);
        player.Inventory.SendUpdateTo(player);
    }
}
