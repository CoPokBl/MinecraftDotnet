using ManagedServer;
using ManagedServer.Events;
using ManagedServer.Inventory;
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

    private static readonly LootTableEntry[] LootTable = [
        new(new ItemStack(1, Item.Stone), 10, 1, 64),
        new(new ItemStack(1, Item.GoldenApple), 5, 1, 8),
        new(LuckyBlocksFeature.GetLuckyBlock(), 4, 1, 5),
        new(ItemStack.Air, 50, 1, 1)
    ];
    private static readonly int WeightSum = LootTable.Sum(entry => entry.Weight);
    
    private record LootTableEntry(ItemStack Item, int Weight, int MinCount, int MaxCount);
    
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
            
            for (int i = 0; i < inv.Size; i++) {
                int num = Random.Shared.Next(WeightSum);
                foreach (LootTableEntry entry in LootTable) {
                    num -= entry.Weight;
                    if (num >= 0) continue;
                    inv[i] = entry.Item.WithCount(Random.Shared.Next(entry.MinCount, entry.MaxCount + 1));
                    break;
                }
            }
            
            worldData.Add(pos, inv);
            e.World.SetTag(ChestsTag, worldData);
            e.Player.OpenInventory = inv;
        });
    }
}
