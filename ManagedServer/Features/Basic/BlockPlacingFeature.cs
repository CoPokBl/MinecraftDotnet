using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using Minecraft.Data.Blocks;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerPlaceBlockEvent))]
public class BlockPlacingFeature : ScopedFeature {
    private const double PlayerWidth = 0.6;
    private const double PlayerHeight = 1.8;
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemOnPacket packet) {
                return;
            }
            
            CheckBlockPlace(e.Player, packet);
        });
    }
    
    private void CheckBlockPlace(PlayerEntity player, ServerBoundUseItemOnPacket use) {
        IVec3 target = use.Position.GetBlockTowards(use.Face);
        player.Inventory.SendSlotUpdate(player.ActiveHotbarSlot);
        
        // let's get the block
        ItemStack heldItem = player.HeldItem;
        Identifier? blockId = heldItem.Type.CorrespondingBlock;
        if (blockId == null) {
            return;  // no block to place
        }
        IBlock block = player.Server.Registry.Blocks[blockId.Value];
        
        // is player inside that block?
        bool insideEntity = false;
        foreach (Entity en in player.World!.Entities.Entities.Where(en => en is PlayerEntity)) {
            Vec3 pos = ((PlayerEntity)en).Position;
            Vec3 blockPos = new(target.X + 0.5, target.Y + 0.5, target.Z + 0.5);
            if (Math.Abs(pos.X - blockPos.X) < 0.5 + PlayerWidth/2 && 
                Math.Abs(pos.Z - blockPos.Z) < 0.5 + PlayerWidth/2 && 
                Math.Abs(pos.Y + PlayerHeight/2 - blockPos.Y) + 0.001 < 0.5 + PlayerHeight/2) {
                // they're in the block
                insideEntity = true;
                break;
            }
        }
        
        MinecraftPacket ackPacket = new ClientBoundAcknowledgeBlockChangePacket {
            SequenceId = use.Sequence
        };

        if (insideEntity) {
            // don't place, make it air again
            player.World!.SendBlockUpdate(target, player);
            player.SendPacket(ackPacket);
            return;
        }

        PlayerPlaceBlockEvent placeEvent = new() {
            Player = player,
            Block = block,
            Position = target,
            World = player.World!,
            UsedItem = heldItem
        };
        Scope.Events.CallEvent(placeEvent);

        if (placeEvent.Cancelled) {
            player.World!.SendBlockUpdate(target, player);
            player.SendPacket(ackPacket);
            return;
        }
        
        // Okay place it
        player.World!.SetBlock(placeEvent.Position, placeEvent.Block);
        player.SendPacket(ackPacket);

        if (placeEvent.ConsumeItem) {
            ItemStack newItem = heldItem.Count > 1 ? heldItem.WithCount(heldItem.Count - 1) : ItemStack.Air;
            player.Inventory.SetHotbarItem(player.ActiveHotbarSlot, newItem);
        }
    }
}
