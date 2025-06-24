using System.Diagnostics.Metrics;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Managed.Entities.Types;
using Minecraft.Implementations.Server.Worlds;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace TestServer.Servers.MlgRush;

public class PlaceOneBlockFeature(Func<PlayerConnection, int> block, int disappearTime = -1) {
    private const double PlayerWidth = 0.6;
    private const double PlayerHeight = 1.8;

    // so that they don't get deleted
    private List<Timer> _timers = [];
    
    public void Register(World world) {
        world.PlayerPacketEvents.AddListener<PacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemOnPacket ui) {
                return;
            }

            BlockPosition target = ui.Position.GetBlockTowards(ui.Face);
            
            // is player inside that block?
            bool insideEntity = false;
            foreach (Entity en in world.Entities.Entities.Where(en => en is PlayerEntity)) {
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

            if (target.Y > 1) {
                insideEntity = true;
            }

            if (insideEntity) {
                // don't place, make it air again
                e.Connection.SendPackets(
                    new ClientBoundBlockUpdatePacket {
                        Location = target,
                        BlockId = 0
                    },
                    new ClientBoundAcknowledgeBlockChangePacket {
                        SequenceId = ui.Sequence
                    });
                return;
            }
            
            // PLACE IT
            int breakingEntity = Random.Shared.Next();
            MinecraftPacket packet = new ClientBoundBlockUpdatePacket {
                Location = target,
                BlockId = block.Invoke(e.Connection)
            };
            foreach (PlayerConnection connection in world.Players.Select(p => p.Connection)) {
                connection.SendPackets(packet, new ClientBoundSetBlockDestroyStage {
                    EntityId = breakingEntity,
                    Block = target,
                    Stage = 0
                });
            }
            
            e.Connection.SendPacket(new ClientBoundAcknowledgeBlockChangePacket {
                SequenceId = ui.Sequence
            });

            if (disappearTime == -1) {
                return;
            }
            
            // Make it disappear
            Timer t = null!;
            Atomic<int> s = new(0);
            t = new Timer(state => {
                int st = ((Atomic<int>)state!).Value;
                if (st != 9) {
                    // send break animation
                    foreach (PlayerConnection con in world.Players.Select(p => p.Connection)) {
                        con.SendPacket(new ClientBoundSetBlockDestroyStage {
                            EntityId = breakingEntity,
                            Block = target,
                            Stage = (byte)st
                        });
                    }

                    ((Atomic<int>)state).Value++;
                    return;
                }
                
                foreach (PlayerConnection con in world.Players.Select(p => p.Connection)) {
                    con.SendPackets(new ClientBoundBlockUpdatePacket {
                        Location = target,
                        BlockId = 0
                    }, new ClientBoundSetBlockDestroyStage {
                        EntityId = breakingEntity,
                        Block = target,
                        Stage = 16
                    });
                }

                t.Change(-1, -1);
                _timers.Remove(t);
            }, s, TimeSpan.FromSeconds(disappearTime/9f), TimeSpan.FromSeconds(disappearTime/9f));
            _timers.Add(t);
        });
    }
}