using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Viewables;
using Minecraft.Packets.Play.ServerBound;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerChatEvent))]
public class BasicChatFeature : ScopedFeature {
    
    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundChatMessagePacket chatPacket) {
                return;
            }

            PlayerChatEvent chatEvent = new() {
                Player = e.Player,
                RawMessage = chatPacket.Message,
                World = e.World,
                Audience = new AudiencesList(Scope.Players.Cast<IAudience>().ToArray()),
                Message = $"<{e.Player.Name}> " + chatPacket.Message
            };
            Scope.Events.CallEvent(chatEvent);

            if (chatEvent.Cancelled) {
                return;
            }
            
            chatEvent.Audience.SendMessage(chatEvent.Message);
        });
    }
}
