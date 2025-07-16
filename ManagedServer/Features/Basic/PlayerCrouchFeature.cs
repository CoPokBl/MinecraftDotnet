using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using Minecraft.Packets.Play.ServerBound;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerCrouchEvent))]
public class PlayerCrouchFeature : ScopedFeature {
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundPlayerInputPacket packet) {
                return;
            }

            bool value = packet.Flags.HasFlag(ServerBoundPlayerInputPacket.Input.Sneak);
            
            if (value == e.Player.Crouching) {  // didn't change
                return;
            }
            
            PlayerCrouchEvent crouchEvent = new() {
                Player = e.Player,
                World = e.World,
                IsCrouching = value
            };
            Scope.Events.CallEvent(crouchEvent);
            
            if (crouchEvent.Cancelled) {
                return;
            }
            
            e.Player.Crouching = crouchEvent.IsCrouching;
        });
    }
}
