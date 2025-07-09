using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerCrouchEvent))]
public class PlayerCrouchFeature : ScopedFeature {
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundPlayerCommandPacket packet) {
                return;
            }

            bool? newValue = packet.PlayAction switch {
                PlayerAction.PressSneak => true,
                PlayerAction.ReleaseSneak => false,
                _ => null
            };
            
            if (newValue is null) {
                return;
            }
            
            PlayerCrouchEvent crouchEvent = new() {
                Player = e.Player,
                World = e.World,
                IsCrouching = newValue.Value
            };
            Scope.Events.CallEvent(crouchEvent);
            
            if (crouchEvent.Cancelled) {
                return;
            }
            
            e.Player.Crouching = crouchEvent.IsCrouching;
        });
    }
}
