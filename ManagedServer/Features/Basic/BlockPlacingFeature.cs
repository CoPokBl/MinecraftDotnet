using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Inventory;
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
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemOnPacket packet) {
                return;
            }
            
            CheckBlockPlace(e.Player, packet);
        });
    }
    
    private void CheckBlockPlace(PlayerEntity player, ServerBoundUseItemOnPacket use) {
        if (player.GameMode == GameMode.Spectator) {
            return;
        }
        
        Vec3<int> target = use.Position.GetBlockTowards(use.Face);
        if (!player.World!.IsInBounds(target)) {
            return;  // out of bounds, can't place block
        }
        player.Inventory.SendSlotUpdate(player.ActiveHotbarSlot);
        
        IBlock existingBlock = player.World!.GetBlock(target);
        if (!existingBlock.Replaceable) {
            // can't replace this block
            return;
        }
        
        // let's get the block
        Identifier blockId;
        ItemStack usedItem;
        Hand hand;

        if (player.HeldItem.Type.CorrespondingBlock != null) {
            blockId = player.HeldItem.Type.CorrespondingBlock.Value;
            usedItem = player.HeldItem;
            hand = Hand.MainHand;
        }
        else if (player.Inventory.Offhand.Type.CorrespondingBlock != null) {
            blockId = player.Inventory.Offhand.Type.CorrespondingBlock.Value;
            usedItem = player.Inventory.Offhand;
            hand = Hand.OffHand;
        }
        else {
            // no block to place
            return;
        }
        
        IBlock block = player.Server.Registry.Blocks[blockId];
        
        // is player inside that block?
        bool insideEntity = false;
        foreach (Entity en in player.World!.Entities.Entities.Where(en => en is PlayerEntity)) {
            Vec3<double> pos = ((PlayerEntity)en).Position;
            Vec3<double> blockPos = new(target.X + 0.5, target.Y + 0.5, target.Z + 0.5);
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
            UsedItem = usedItem,
            Hand = hand
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
            ItemStack newItem = usedItem.SubtractCount(1);
            player.SetItemInHand(hand, newItem);
        }
        
        // prevent ghost items by sending the item update
        player.Inventory.SendSlotUpdate(hand == Hand.MainHand 
            ? PlayerInventory.HotbarSlot1 + player.ActiveHotbarSlot 
            : PlayerInventory.OffhandSlot);
    }
}
