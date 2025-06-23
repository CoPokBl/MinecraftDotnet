using Minecraft.Implementations.Server.Events;
using Minecraft.Packets.Status.ServerBound;

namespace Minecraft.Implementations.Server.Features;

public class PingRespondFeature : IServerFeature {
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PacketHandleEvent>(e => {
            if (e.Packet is ServerBoundPingRequestPacket ping) {
                e.Connection.SendPacket(ping.CreateResponse());
            }
        });
    }
    
    public void Unregister() {
        
    }

    public Type[] GetDependencies() {
        return [];
    }
}