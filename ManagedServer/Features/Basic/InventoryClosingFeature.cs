using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using Minecraft.Packets.Play.ServerBound;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerCloseInventoryEvent))]
public class InventoryClosingFeature : ScopedFeature {
    
    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundCloseContainerPacket packet) {
                return;
            }

            // Let's make sure that we know what inventory
            // they're talking about.
            // If we can't work it out we'll just ignore it.
            // 0 means the player inventory
            if (packet.WindowId != 0 && 
                (e.Player.OpenInventory == null ||
                 e.Player.OpenInventory.WindowId != packet.WindowId)) {
                return;
            }
            
            // Okay we know what inventory they're closing
            PlayerCloseInventoryEvent closeEvent = new() {
                Player = e.Player,
                World = e.Player.World!,
                Inventory = packet.WindowId == 0 ? e.Player.Inventory : e.Player.OpenInventory!
            };
            CallEvent(closeEvent);
        });
    }
}
