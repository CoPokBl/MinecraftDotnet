using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;

namespace ManagedServer.Features;

public class ItemPickupFeature : ScopedFeature {
    private const double PickupRange = 2.0;
    private static readonly TimeSpan PickupDelay = TimeSpan.FromSeconds(1);
    
    public override void Register() {
        AddEventListener<EntityMoveEvent>(e => {
            if (e.Entity is not PlayerEntity player) {
                return;
            }
            
            // Check for items in the player's vicinity
            Entity[] nearbyEntities = e.World.Entities.GetNearbyEntities(player.Position, PickupRange);
            foreach (Entity entity in nearbyEntities) {
                if (entity.Type.Identifier != EntityType.Item.Identifier) {
                    continue;
                }

                if (entity.Meta is not ItemMeta meta || meta.Item == null) {
                    continue;  // We can only pick up items with ItemMeta
                }

                DateTime dropTime = entity.GetTagOrDefault(World.ItemDropTimeTag, DateTime.MinValue);
                if (DateTime.Now - dropTime < PickupDelay) {
                    return;  // Too soon to pick up this item
                }
                
                // try add
                ItemStack? remainder = player.Inventory.AddItem(meta.Item);
                if (remainder?.Count == meta.Item.Count) {
                    return;  // Inventory is full, cannot pick up item
                }
                // At least some of the item was picked up, so we can proceed
                
                // Okay pick it up
                player.SendToSelfAndViewers(new ClientBoundPickupItemPacket {
                    CollectedEntityId = entity.NetId,
                    CollectorEntityId = player.NetId,
                    PickupItemCount = meta.Item.Count
                });
                player.PlaySound(SoundType.ItemPickup, entity);

                if (remainder == null) {
                    // All items were picked up, so we can despawn the entity
                    entity.Despawn();
                }
                else {
                    // Update the item entity with the remainder
                    entity.Meta = (ItemMeta)entity.Meta with {
                        Item = remainder
                    };
                }
            }
        });
    }
}
