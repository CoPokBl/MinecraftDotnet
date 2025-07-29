using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Items;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerUseItemEvent))]
public class UseItemEventFeature : ScopedFeature {
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemPacket packet) {
                return;
            }

            ItemStack item = e.Player.GetItemInHand(packet.UsedHand);
            
            PlayerUseItemEvent useItemEvent = new() {
                Player = e.Player,
                World = e.World,
                Item = item,
                Hand = packet.UsedHand
            };
            CallEvent(useItemEvent);
        });
    }
}
