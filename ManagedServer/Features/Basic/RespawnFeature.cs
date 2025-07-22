using ManagedServer.Events;
using ManagedServer.Worlds;
using Minecraft.Packets.Play.ServerBound;

namespace ManagedServer.Features.Basic;

public class RespawnFeature : ScopedFeature {
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundClientStatusPacket packet) {
                return;
            }

            if (packet.Action != ServerBoundClientStatusPacket.StatusAction.Respawn) {
                return;
            }
            
            World world = e.Player.World!;
            
            world.RemovePlayer(e.Player);
            e.Player.Heal();
            e.Player.Respawn();
            world.AddPlayer(e.Player);
        });
    }
}
