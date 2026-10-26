using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;

namespace ManagedServer.Features.Impl;

public class ItemPickupFeature : ScopedFeature {
    private const double PickupRange = 2.0;

    /// <summary>
    /// How long a stack is uncollectable when nothing is counting <see cref="ItemEntity.PickupDelay"/>
    /// down for it. Only reached without <c>ItemEntityFeature</c> registered, and it is a wall clock
    /// span because <see cref="World.ItemDropTimeTag"/> is a timestamp.
    /// </summary>
    private static readonly TimeSpan FallbackPickupDelay = TimeSpan.FromSeconds(1);

    public override void Register() {
        AddEventHandler<EntityMoveEvent>(e => {
            if (e.Entity is not Player player) {
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

                if (!CanBePickedUp(entity)) {
                    continue;
                }

                // try add
                ItemStack? remainder = player.Inventory.AddItem(meta.Item);
                if (remainder?.Count == meta.Item.Count) {
                    continue;  // Inventory is full for this stack, but another one may still fit
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

    /// <summary>
    /// Vanilla's <c>pickupDelay</c> is a tick counter on <see cref="ItemEntity"/>, but only
    /// <c>ItemEntityFeature</c> counts it down, and without that feature it would never reach zero and
    /// nothing would ever be collectable.
    /// <p/>
    /// Which of the two is live is read off <see cref="ItemEntity.Age"/> rather than by looking for the
    /// feature: age only moves when something is ticking the stack, and asking the world's features
    /// would miss a server scoped registration. Both answers agree before the first tick, when the age
    /// is zero and the stack has only just been dropped.
    /// </summary>
    private static bool CanBePickedUp(Entity entity) {
        if (entity is ItemEntity { Age: > 0 } item) {
            return item.PickupDelay <= 0;
        }

        DateTime dropTime = entity.GetTagOrDefault(World.ItemDropTimeTag, DateTime.MinValue);
        return DateTime.Now - dropTime >= FallbackPickupDelay;
    }
}
