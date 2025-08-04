using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerDropItemEvent))]
public class DropItemsEventFeature : ScopedFeature {
    
    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundPlayerActionPacket packet) {
                return;
            }

            if (e.Player.GameMode == GameMode.Spectator) {
                return;
            }
            
            if (packet.ActionStatus == ServerBoundPlayerActionPacket.Status.DropItem) {
                ItemStack item = e.Player.HeldItem.WithCount(1);
                if (item.IsAir()) {
                    return;
                }

                PlayerDropItemEvent dropEvent = new() {
                    Player = e.Player,
                    World = e.World,
                    Item = item
                };
                Scope.Events.CallEvent(dropEvent);

                if (dropEvent.Cancelled) {
                    return;
                }

                e.Player.HeldItem = e.Player.HeldItem.SubtractCount(1);
            }
            else if (packet.ActionStatus == ServerBoundPlayerActionPacket.Status.DropItemStack) {
                ItemStack item = e.Player.HeldItem;
                if (item.IsAir()) {
                    return;
                }

                PlayerDropItemEvent dropEvent = new() {
                    Player = e.Player,
                    World = e.World,
                    Item = item
                };
                Scope.Events.CallEvent(dropEvent);

                if (dropEvent.Cancelled) {
                    return;
                }

                e.Player.HeldItem = ItemStack.Air;
            }
        });
    }
}
