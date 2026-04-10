using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerSwapItemEvent))]
public class PlayerSwapItemFeature : ScopedFeature {
    
    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundPlayerActionPacket packet) {
                return;
            }

            if (packet.ActionStatus != ServerBoundPlayerActionPacket.Status.SwapItem) {
                return;
            }

            PlayerSwapItemEvent swapEvent = new() {
                Player = e.Player,
                World = e.World,
                MainHand = e.Player.GetItemInHand(Hand.MainHand),
                OffHand = e.Player.GetItemInHand(Hand.OffHand)
            };
            CallEvent(swapEvent);

            if (swapEvent.Cancelled) {
                e.Player.Inventory.SendUpdateTo(e.Player);
                return;
            }
            
            e.Player.SwapHeld();
        });
    }
}
