using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
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
    private static readonly Tag<Action> EatingTaskTag = new("consumables:eating_task");
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is ServerBoundUseItemPacket usePacket) {
                ItemStack item = usePacket.UsedHand == Hand.MainHand ? e.Player.HeldItem : e.Player.Inventory.Offhand;
                ConsumableComponent.Data? food = item.Get(DataComponent.Consumable);
            
                if (food == null) {
                    return; // Not a consumable item
                }
            
                // Okay they started, record it
                Action cancel = Scope.Server.ScheduleTask(TimeSpan.FromSeconds(food.ConsumeSeconds), () => {
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
                e.Player.SetTag(EatingTaskTag, cancel);
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
                e.Player.GetTag(EatingTaskTag).Invoke();
            }
        });
    }
}
