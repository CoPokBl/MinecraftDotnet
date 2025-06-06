using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;

namespace Minecraft.Implementations.Server.Features;

public class BlockBreakingFeature : IFeature {
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundPlayerActionPacket packet) {
                return;
            }
            
            Console.WriteLine($"Action: {packet.ActionStatus}");

            if (packet.ActionStatus != ServerBoundPlayerActionPacket.Status.StartedDigging) {
                return;
            }
            
            // they say they broke a block
            MinecraftPacket changePacket = new ClientBoundBlockUpdatePacket(packet.Location, 0);
            foreach (PlayerConnection connection in server.Connections) {
                if (connection == e.Connection) {
                    continue;
                }

                connection.SendPacket(changePacket);
            }
        });
    }

    public Type[] GetDependencies() {
        return [];
    }
}