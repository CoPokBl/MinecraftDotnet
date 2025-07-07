using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features;

public class BlockBreakingFeature(bool instaMine = true) : IWorldFeature {
    
    public void Register(World world) {
        world.Events.AddListener<PacketHandleEvent>(e => {
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

            MinecraftPacket ackPacket = new ClientBoundAcknowledgeBlockChangePacket {
                SequenceId = packet.Sequence
            };
            
            if (breakEvent.Cancelled) {
                // TODO: Tell them it wasn't broken (we don't know what the block is), for now just acknowledge that it happened.
                e.Connection.SendPacket(ackPacket);
                return;
            }
            
            MinecraftPacket changePacket = new ClientBoundBlockUpdatePacket {
                Block = Block.Air,
                Location = packet.Location
            };
            foreach (PlayerEntity p in world.Players) {
                p.Connection.SendPacket(changePacket);
            }
            
            e.Connection.SendPacket(ackPacket);
        });
    }

    public void Unregister() {
        
    }

    public Type[] GetDependencies() {
        return [];
    }

    public class BlockBreakEvent : IServerEvent, ICancelableEvent {
        public required PlayerConnection Connection { get; set; }
        public required IVec3 Position { get; set; }
        public bool Cancelled { get; set; }
    }
}