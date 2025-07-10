using ManagedServer;
using ManagedServer.Events;
using ManagedServer.Inventory;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class SkyWarsChestsFeature : ScopedFeature {
    private static readonly Tag<Dictionary<IVec3, Inventory>> ChestsTag = new("skywars:loot_chests");
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemOnPacket packet) {
                return;
            }

            IVec3 pos = packet.Position;
            IBlock block = e.World.GetBlock(pos);

            if (!IBlock.SimilarTo(block, Block.Chest)) {
                return;
            }
            
            // Chest right click
            Dictionary<IVec3, Inventory> worldData = e.World.GetTagOrSetDefault(ChestsTag, []);

            if (worldData.TryGetValue(pos, out Inventory? value)) {
                e.Player.OpenInventory = value;
                return;
            }
            
            // Generate loot
            ChestInventory inv = ChestInventory.Create(3);
            inv.Title = "SkyWars Chest";

            inv[0] = new ItemStack(40, Item.Stone);
            inv[1] = new ItemStack(8, Item.GoldenApple);
            
            worldData.Add(pos, inv);
            e.World.SetTag(ChestsTag, worldData);
            e.Player.OpenInventory = inv;
        });
    }
}
