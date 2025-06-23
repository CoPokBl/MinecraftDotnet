using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Managed.Entities.Types;
using Minecraft.Implementations.Server.Worlds;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Features;

public class BlockBreakingFeature(bool instaMine = true) {
    
    public void Register(World world) {
        world.PlayerPacketEvents.AddListener<PacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundPlayerActionPacket packet) {
                return;
            }

            if (packet.ActionStatus != 
                (instaMine ? ServerBoundPlayerActionPacket.Status.StartedDigging : ServerBoundPlayerActionPacket.Status.FinishedDigging)) {
                return;
            }
            
            // they say they broke a block
            BlockBreakEvent breakEvent = new() {
                Connection = e.Connection,
                Position = packet.Location
            };
            world.Events.CallEvent(breakEvent);
            
            if (breakEvent.Cancelled) {
                // TODO: Tell them it wasn't broken (we don't know what the block is), for now just acknowledge that it happened.
                e.Connection.SendPacket(new ClientBoundAcknowledgeBlockChangePacket(packet.Sequence));
                return;
            }
            
            MinecraftPacket changePacket = new ClientBoundBlockUpdatePacket(packet.Location, 0);
            foreach (PlayerEntity p in world.Players) {
                // if (connection == e.Connection) {
                //     continue;
                // }

                p.Connection.SendPacket(changePacket);
            }
            
            e.Connection.SendPacket(new ClientBoundAcknowledgeBlockChangePacket(packet.Sequence));
        });
    }

    public void Unregister() {
        
    }

    public Type[] GetDependencies() {
        return [];
    }

    public class BlockBreakEvent : IServerEvent, ICancelableEvent {
        public required PlayerConnection Connection { get; set; }
        public required BlockPosition Position { get; set; }
        public bool Cancelled { get; set; } = false;
    }
}