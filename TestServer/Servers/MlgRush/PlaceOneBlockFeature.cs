using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace TestServer.Servers.MlgRush;

public class PlaceOneBlockFeature(uint block) : IFeature {
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemOnPacket ui) {
                return;
            }

            BlockPosition target = ui.Position.GetBlockTowards(ui.Face);
            MinecraftPacket packet = new ClientBoundBlockUpdatePacket(target, (int)block);
            foreach (PlayerConnection connection in server.Connections) {
                connection.SendPacket(packet);
            }
        });
    }

    public Type[] GetDependencies() {
        return [];
    }
}