using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Entities;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace TestServer.Servers.MlgRush;

public class PlaceOneBlockFeature(Func<PlayerConnection, int> block, int disappearTime = -1) : IFeature {
    private const double PlayerWidth = 0.6;
    private const double PlayerHeight = 1.8;

    // so that they don't get deleted
    private List<Timer> _timers = [];
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemOnPacket ui) {
                return;
            }

            BlockPosition target = ui.Position.GetBlockTowards(ui.Face);
            
            // is player inside that block?
            bool insideEntity = false;
            foreach (Entity en in server.Feature<SimpleEntitiesFeature>()!.Entities.Where(en => en is PlayerEntity)) {
                Vec3 pos = ((PlayerEntity)en).Position;
                Vec3 blockPos = new(target.X + 0.5, target.Y + 0.5, target.Z + 0.5);
                if (Math.Abs(pos.X - blockPos.X) < 0.5 + PlayerWidth/2 && 
                    Math.Abs(pos.Z - blockPos.Z) < 0.5 + PlayerWidth/2 && 
                    Math.Abs(pos.Y + PlayerHeight/2 - blockPos.Y) < 0.5 + PlayerHeight/2) {
                    // they're in the block
                    insideEntity = true;
                    break;
                }
            }

            // NO BUILDING IN SPAWN CODE
            // if (target.X is < 2 or > 19) {
            //     insideEntity = true;
            // }

            if (target.Y > 10) {
                insideEntity = true;
            }

            if (insideEntity) {
                // don't place, make it air again
                e.Connection.SendPackets(
                    new ClientBoundBlockUpdatePacket(target, 0),
                    new ClientBoundAcknowledgeBlockChangePacket(ui.Sequence));
                return;
            }
            
            // PLACE IT
            
            MinecraftPacket packet = new ClientBoundBlockUpdatePacket(target, block.Invoke(e.Connection));
            foreach (PlayerConnection connection in server.Connections) {
                connection.SendPacket(packet);
            }
            
            e.Connection.SendPacket(new ClientBoundAcknowledgeBlockChangePacket(ui.Sequence));

            if (disappearTime == -1) {
                return;
            }
            
            // Make it disappear
            Timer t = null!;
            t = new Timer(_ => {
                foreach (PlayerConnection con in server.Connections) {
                    con.SendPacket(new ClientBoundBlockUpdatePacket(target, 0));
                }

                _timers.Remove(t);
            }, null, TimeSpan.FromSeconds(disappearTime), Timeout.InfiniteTimeSpan);
            _timers.Add(t);
        });
    }

    public Type[] GetDependencies() {
        return [typeof(SimpleEntitiesFeature)];
    }
}