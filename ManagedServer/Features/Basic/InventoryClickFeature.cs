using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Items;

namespace ManagedServer.Features.Basic;

public class InventoryClickFeature : ScopedFeature {
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundClickContainerPacket packet) {
                return;
            }
            
            HandleInventoryClick(e.Player, packet);
        });
    }
    
    private void HandleInventoryClick(PlayerEntity player, ServerBoundClickContainerPacket packet) {
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
                if (packet.Slot < 0) {  // Clicked outside the inventory (so drop it I guess)
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
                else {  // Clicked inside the inventory (swap with cursor)
                    (targetInventory[effectiveSlot], player.CursorItem) = (player.CursorItem, targetInventory[effectiveSlot]);
                }
                clickedInventory.SendUpdateTo(player);
                break;
            }

            case 1: {
                // TODO: Shift-click
                break;
            }

            case 2: {  // Hotkey it into a slot
                int slotToSwapTo = packet.Button;
                (clickedInventory[slotToSwapTo], clickedInventory[packet.Slot]) = (clickedInventory[packet.Slot], clickedInventory[slotToSwapTo]);
                clickedInventory.SendUpdateTo(player);
                break;
            }

            case 3: {  // Middle click (only exists in creative mode)
                break;  // TODO
            }

            case 4: {  // Drop key
                switch (packet.Button) {
                    case 0:  // Drop key, so drop one (usually Q)
                        clickedInventory[packet.Slot] = clickedInventory[packet.Slot].Count > 1
                            ? clickedInventory[packet.Slot].WithCount(clickedInventory[packet.Slot].Count - 1)
                            : // There is more than one item, so subtract one
                            ItemStack.Air; // There is only one item, so drop it all
                        break;
                    
                    case 1:  // Control + Drop key, so drop all (usually Ctrl + Q)
                        clickedInventory[packet.Slot] = ItemStack.Air;  // Drop all items in the slot
                        break;
                }
                clickedInventory.SendUpdateTo(player);
                break;
            }
        }
    }
}
