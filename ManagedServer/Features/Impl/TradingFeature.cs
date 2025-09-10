using ManagedServer.Events;
using ManagedServer.Inventories;
using ManagedServer.Schemas;
using Minecraft;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features.Impl;

public class TradingFeature : ScopedFeature {
    private static readonly Tag<int> SelectedTradeTag = new("managedserver:trading_feature:selected_trade");
    
    // it's reversed slot index order for some reason
    // I hate minecraft inventories
    private static readonly int[] BadItemRemoveSlotSearchOrder = 
        Enumerable.Range(
            PlayerInventory.RegularInventoryStartIndex, 
            PlayerInventory.HotbarSlot9 + 1 - PlayerInventory.RegularInventoryStartIndex)
            .Reverse()
            .ToArray();
    
    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundSelectTradePacket packet) {
                return;
            }

            if (e.Player.OpenInventory is not TradeInventory tradeInv) {
                return;
            }

            if (tradeInv.Trades.Length <= packet.SelectedSlot) {
                return;
            }
            
            // Okay they selected a valid trade, change the slots
            Trade trade = tradeInv.Trades[packet.SelectedSlot];
            
            e.Player.SetTag(SelectedTradeTag, packet.SelectedSlot);
            
            // Let's start by removing existing items from the trade slots
            for (int i = 0; i < 2; i++) {
                if (tradeInv[i].IsAir()) {
                    continue;
                }
                
                bool foundSpot = e.Player.Inventory.AddItem(
                    tradeInv[i], true, BadItemRemoveSlotSearchOrder) == null;

                if (!foundSpot) {
                    // Couldn't find a spot, just stop everything here
                    tradeInv[TradeInventory.OutputSlot] = ItemStack.Air;
                    return;
                }
                
                // Successfully added the item, clear the slot
                tradeInv[i] = ItemStack.Air;
            }

            bool hasEverything = true;
            
            // search for the first input item and get as close to a stack as possible
            PlayerInventory pInv = e.Player.Inventory;
            int input1Count = 0;
            foreach (int slot in e.Player.Inventory.AddItemSearchOrder) {
                if (!pInv[slot].CanStackWith(trade.InputItem1)) {
                    continue;
                }
                
                int amountToTake = Math.Min(
                    trade.InputItem1.Item.GetMaxStackSize() - input1Count, 
                    pInv[slot].Count);
                input1Count += amountToTake;
                
                pInv[slot] = pInv[slot].SubtractCount(amountToTake);

                if (input1Count == trade.InputItem1.Item.GetMaxStackSize()) {
                    break;
                }
            }
            if (input1Count < trade.InputItem1.Item.Count) {
                hasEverything = false;
            }
            
            // search for the second input item if it exists
            int input2Count = 0;
            if (trade.InputItem2 != null) {
                foreach (int slot in e.Player.Inventory.AddItemSearchOrder) {
                    if (!pInv[slot].CanStackWith(trade.InputItem2)) {
                        continue;
                    }
                
                    int amountToTake = Math.Min(
                        trade.InputItem2.Item.GetMaxStackSize() - input2Count, 
                        pInv[slot].Count);
                    input2Count += amountToTake;
                
                    pInv[slot] = pInv[slot].SubtractCount(amountToTake);

                    if (input2Count == trade.InputItem2.Item.GetMaxStackSize()) {
                        break;
                    }
                }
                if (input2Count < trade.InputItem2.Item.Count) {
                    hasEverything = false;
                }
            }

            if (input1Count > 0) {
                tradeInv[TradeInventory.InputSlot1] = trade.InputItem1.Item.WithCount(input1Count);
            }
            
            if (input2Count > 0) {
                tradeInv[TradeInventory.InputSlot2] = trade.InputItem2!.Item.WithCount(input2Count);
            }

            tradeInv[TradeInventory.OutputSlot] = hasEverything ? trade.OutputItem : ItemStack.Air;
        });
        
        AddEventMutator<InventoryPreClickEvent>(e => {
            if (e.Player.OpenInventory is not TradeInventory tradeInv) {
                return;
            }

            if (e.Slot != TradeInventory.OutputSlot) {
                // They clicked outside the output slot, ignore
                return;
            }
            
            // We just need to handle someone clicking the output slot
            // because we can't let them put anything in there
            if (e.Player.CursorItem.IsAir()) {
                return;
            }
            
            // if it's a shift click it doesn't matter what they have on their cursor
            if (e.Type == ClickType.Shift) {
                return;
            }
            
            // Check if they both stack
            if (!e.Player.CursorItem.CanStackWith(tradeInv[TradeInventory.OutputSlot])) {
                e.Cancelled = true;
                return;
            }
            
            // Okay they do stack
            // TODO: Handle this
            // for but now, cancel
            e.Cancelled = true;
        });
        
        AddEventHandler<InventoryClickEvent>(e => {
            if (e.Player.OpenInventory is not TradeInventory tradeInv) {
                return;
            }

            if (e.Slot > TradeInventory.OutputSlot) {
                // They clicked outside the trade slots, ignore
                return;
            }

            // The first trade is selected by default
            int selectedTradeIndex = e.Player.GetTagOrDefault(SelectedTradeTag, 0);
            if (selectedTradeIndex >= tradeInv.Trades.Length) {
                tradeInv[TradeInventory.OutputSlot] = ItemStack.Air;
                return;
            }
            
            // They clicked a trade slot
            // find best matching trade
            Trade trade = tradeInv.Trades[selectedTradeIndex];
            
            // Check if they have everything
            bool hasItem1 = tradeInv[TradeInventory.InputSlot1].CanStackWith(trade.InputItem1) && 
                            tradeInv[TradeInventory.InputSlot1].Count >= trade.InputItem1.Item.Count;
            bool hasItem2 = trade.InputItem2 == null ||
                            (tradeInv[TradeInventory.InputSlot2].CanStackWith(trade.InputItem2) && 
                             tradeInv[TradeInventory.InputSlot2].Count >= trade.InputItem2.Item.Count);
            if (!hasItem1 || !hasItem2) {
                tradeInv[TradeInventory.OutputSlot] = ItemStack.Air;
                return;
            }
            
            if (e.Slot != TradeInventory.OutputSlot) {
                // Update trade info
                tradeInv[TradeInventory.OutputSlot] = trade.OutputItem;
                return;
            }
            
            // Trying to perform a trade
            bool tradeAll = e.Type == ClickType.Shift;
            
            int bundlesOfItem1 = tradeInv[TradeInventory.InputSlot1].Count / trade.InputItem1.Item.Count;
            int bundlesOfItem2 = trade.InputItem2 == null ? int.MaxValue :
                tradeInv[TradeInventory.InputSlot2].Count / trade.InputItem2.Item.Count;
            int maxTrades = Math.Min(bundlesOfItem1, bundlesOfItem2);
            
            int tradesToDo = tradeAll ? maxTrades : 1;
            
            // Take fee
            for (int i = 0; i < tradesToDo; i++) {
                // Give all but the first item to the player (because inv click feat will do it for the first)
                // do this first so if they don't have space we don't take their items
                if (i != 0) {
                    ItemStack? remaining = e.Player.Inventory.AddItem(trade.OutputItem, true);
                    if (remaining != null) {
                        // Couldn't fit the item, stop here
                        break;
                    }
                }
                
                tradeInv[TradeInventory.InputSlot1] = tradeInv[TradeInventory.InputSlot1]
                    .SubtractCount(trade.InputItem1.Item.Count);
                if (trade.InputItem2 != null) {
                    tradeInv[TradeInventory.InputSlot2] = tradeInv[TradeInventory.InputSlot2]
                        .SubtractCount(trade.InputItem2.Item.Count);
                }
            }
            
            // Refresh output slot
            bool hasEverything = tradeInv[TradeInventory.InputSlot1].Count >= trade.InputItem1.Item.Count;
            hasEverything &= trade.InputItem2 == null || 
                             tradeInv[TradeInventory.InputSlot2].Count >= trade.InputItem2.Item.Count;
                
            tradeInv[TradeInventory.OutputSlot] = hasEverything ? trade.OutputItem : ItemStack.Air;
        });
        
        AddEventHandler<PlayerCloseInventoryEvent>(e => {
            if (e.Inventory is not TradeInventory tradeInv) {
                return;
            }
            
            // Give back any items in the trade slots
            for (int i = 0; i < 2; i++) {
                if (tradeInv[i].IsAir()) {
                    continue;
                }

                ItemStack? remainder = e.Player.Inventory.AddItem(tradeInv[i]);
                
                if (remainder != null) {
                    // TODO: Is this the best thing to do? Maybe make it configurable?
                    // Couldn't fit the item, drop it on the ground
                    e.World.DropItem(e.Player.Position + new Vec3<double>(0, 1, 0), remainder);
                }
                
                // Remove them from the inventory
                tradeInv[i] = ItemStack.Air;
            }
        });
    }
}
