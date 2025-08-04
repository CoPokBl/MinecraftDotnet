using Minecraft.Implementations.Server.Events;
using Minecraft.Packets.Status.ServerBound;

namespace ManagedServer.Features.Basic;

public class PongFeature : ScopedFeature {
    public override void Register() {
        if (Scope is not ManagedMinecraftServer) {
            throw new InvalidOperationException("PongFeature can only be registered on a ManagedMinecraftServer.");
        }
        
        AddEventHandler<PacketHandleEvent>(e => {
            if (e.Packet is ServerBoundPingRequestPacket ping) {
                e.Connection.SendPacket(ping.CreateResponse());
            }
        });
    }
}
