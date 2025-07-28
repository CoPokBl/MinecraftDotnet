using ManagedServer;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Inventory;
using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using TestServer.Servers.SkyWarsLuckyBlock.Items;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class SkyWarsChestsFeature : ScopedFeature {
    private static readonly Tag<Dictionary<Vec3<int>, Inventory>> ChestsTag = new("skywars:loot_chests");

    private static readonly LootTableEntry[] LootTable = [
        new(new ItemStack(1, Item.StoneSword).WithTag(SkyWarsCombatFeature.DamageTag, 5f), 0.75f, 1, 1),
        new(new ItemStack(1, Item.Stone), 10, 16, 256),
        new(SkyWarsItemsFeature.CreateItem(typeof(GoldenAppleItem)), 0.5f, 1, 8),
        new(LuckyBlocksFeature.GetLuckyBlock(), 1f, 1, 32)
    ];
    
    private record LootTableEntry(ItemStack Item, float Chance, int MinCount, int MaxCount);
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemOnPacket packet) {
                return;
            }

            Vec3<int> pos = packet.Position;
            IBlock block = e.World.GetBlock(pos);

            if (!IBlock.SimilarTo(block, Block.Chest)) {
                return;
            }
            
            // Chest right click
            Dictionary<Vec3<int>, Inventory> worldData = e.World.GetTagOrSetDefault(ChestsTag, []);

            if (worldData.TryGetValue(pos, out Inventory? value)) {
                e.Player.OpenInventory = value;
                return;
            }
            
            // Generate loot
            ChestInventory inv = ChestInventory.Create(Scope.Server, 3);
            inv.Title = "SkyWars Chest";

            int[] emptySlotsArr = new int[inv.Size];
            for (int i = 0; i < inv.Size; i++) {
                emptySlotsArr[i] = i;
            }
            Random.Shared.Shuffle(emptySlotsArr);
            Queue<int> emptySlots = new(emptySlotsArr);
            
            foreach (LootTableEntry entry in LootTable) {
                if (!(Random.Shared.NextDouble() < entry.Chance)) continue;
                
                // Add to loot
                int count = Random.Shared.Next(entry.MinCount, entry.MaxCount);
                int itemMaxStack = entry.Item.GetMaxStackSize();

                while (count > 0) {
                    int effectiveMax = Random.Shared.Next(1, itemMaxStack);
                    int amount = Math.Min(count, effectiveMax);
                    inv[emptySlots.Dequeue()] = entry.Item.WithCount(amount);
                    count -= amount;
                }
            }
            
            worldData.Add(pos, inv);
            e.World.SetTag(ChestsTag, worldData);
            e.Player.OpenInventory = inv;
        });
    }
}
