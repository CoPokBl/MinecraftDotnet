using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Packets.Status.ServerBound;

namespace Minecraft.Implementations.Server.Features;

public class ServerListPingFeature(Func<PlayerConnection, ClientBoundStatusResponsePacket> pingResponseSupplier) : IServerFeature {
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundStatusRequestPacket) return;

            _ = e.Connection.SendPacket(pingResponseSupplier.Invoke(e.Connection)); // don't bother waiting
        });
    }
    
    public void Unregister() {
        
    }
    
    public Type[] GetDependencies() {
        return [];
    }
}