using ManagedServer.Events;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ManagedServer.Features.Basic;

/// <summary>
/// <c>ServerGamePacketListenerImpl.handlePunch</c>: a player swinging at nothing swings the main hand
/// item's attack animation for everyone watching. Their own client already played it.
/// </summary>
/// <remarks>
/// Upstream also resets the attack strength ticker here. Nothing on the server models attack
/// strength, so there is nothing to reset, and damage is not scaled by the cooldown.
/// </remarks>
public class ArmSwingFeature : ScopedFeature {
    
    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundPunchPacket) {
                return;
            }

            e.Player.Swing(Hand.MainHand, e.Player.GetItemInHand(Hand.MainHand).Get(DataComponent.AttackAnimation), false);
        });
    }
}
