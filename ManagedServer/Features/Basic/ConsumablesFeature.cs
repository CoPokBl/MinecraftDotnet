using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Inventory;
using ManagedServer.Scheduling;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerConsumeItemEvent))]
public class ConsumablesFeature : ScopedFeature {
    private static readonly Tag<ScheduledTask> EatingTaskTag = new("consumables:eating_task");
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is ServerBoundUseItemPacket usePacket) {
                ItemStack item = usePacket.UsedHand == Hand.MainHand ? e.Player.HeldItem : e.Player.Inventory.Offhand;
                ConsumableComponent.Data? food = item.GetOrNull(DataComponent.Consumable);
            
                if (food == null) {
                    return; // Not a consumable item
                }
            
                // Okay they started, record it
                ScheduledTask task = Scope.Server.Scheduler.ScheduleTask(TimeSpan.FromSeconds(food.ConsumeSeconds), () => {
                    PlayerConsumeItemEvent consumeEvent = new() {
                        Player = e.Player,
                        World = e.World,
                        Item = item,
                        ConsumedAmount = 1
                    };
                    CallEvent(consumeEvent);
                
                    // Acknowledge the consumption
                    e.Player.SendToSelfAndViewers(new ClientBoundEntityEventPacket {
                        EntityId = e.Player.NetId,
                        Status = ClientBoundEntityEventPacket.EntityEventType.PlayerFinishedUsing
                    });

                    if (consumeEvent.ConsumedAmount == 0) {
                        return;
                    }
                
                    // Remove the item from the player's hand
                    e.Player.SetItemInHand(usePacket.UsedHand, item.SubtractCount(consumeEvent.ConsumedAmount));
                });
                e.Player.SetTag(EatingTaskTag, task);
            }
            
            else if (e.Packet is ServerBoundPlayerActionPacket actionPacket) {
                if (actionPacket.ActionStatus != ServerBoundPlayerActionPacket.Status.UpdateHeldItem) {
                    return;
                }
                
                // They finished using the item, check if they were eating
                if (!e.Player.HasTag(EatingTaskTag)) {
                    return;
                }
                
                // Cancel the eating task
                CancelEating(e.Player);
            }
        });
        
        AddEventListener<PlayerSwitchHotbarSlotEvent>(e => {
            CancelEating(e.Player);
        });
        
        AddEventListener<InventoryChangeEvent>(e => {
            if (e.Inventory is not PlayerInventory pi) {
                return;
            }

            if (PlayerInventory.HotbarSlot1 + pi.Owner.ActiveHotbarSlot != e.Slot) {
                return;  // Not a change to their held item
            }

            if (e.PreviousItem.Type.Identifier == e.NewItem.Type.Identifier) {
                return;
            }
            
            // The item in their hand changed, cancel the eating task
            CancelEating(pi.Owner);
        });
    }

    private static void CancelEating(PlayerEntity player) {
        // They finished using the item, check if they were eating
        if (!player.HasTag(EatingTaskTag)) {
            return;
        }
        
        // Cancel the eating task
        player.GetTag(EatingTaskTag).Cancel();
        player.RemoveTag(EatingTaskTag);
    }
}
