using ManagedServer.Events;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ManagedServer.Features.Basic;

public class ArmSwingFeature : ScopedFeature {
    
    public override void Register() {
        Scope.Events.AddListener<PlayerPacketEvent>(e => {
            if (e.Packet is not ServerBoundSwingArmPacket sa) {
                return;
            }
            
            ClientBoundEntityAnimationPacket.AnimationType animation = sa.UsedHand switch {
                Hand.MainHand => ClientBoundEntityAnimationPacket.AnimationType.SwingMainArm,
                Hand.OffHand => ClientBoundEntityAnimationPacket.AnimationType.SwingOffhand,
                _ => throw new ArgumentOutOfRangeException()
            };
            e.Player.SendToViewers(new ClientBoundEntityAnimationPacket {
                EntityId = e.Player.NetId,
                Animation = animation
            });
        });
    }
}
