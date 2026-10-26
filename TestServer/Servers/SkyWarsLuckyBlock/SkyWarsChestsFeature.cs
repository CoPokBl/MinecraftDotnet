using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Interaction;
using ManagedServer.Inventories;
using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using TestServer.Servers.SkyWarsLuckyBlock.Items;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class SkyWarsChestsFeature : ScopedFeature {
    private static readonly Tag<Dictionary<Vec3<int>, Inventory>> ChestsTag = new("skywars:loot_chests");

    private static readonly LootTableEntry[] LootTable = [
        new(new ItemStack(Item.Stone), 10, 16, 256),
        new(SkyWarsItemsFeature.CreateItem(typeof(GoldenAppleItem)), 0.5f, 1, 8),
        new(LuckyBlocksFeature.GetLuckyBlock(), 1f, 1, 32),
        
        // buckets, for bridging and for dropping on someone
        new(new ItemStack(Item.WaterBucket), 0.5f, 1, 1),
        new(new ItemStack(Item.LavaBucket), 0.3f, 1, 1),

        // tools
        new(new ItemStack(Item.DiamondPickaxe).With(DataComponent.Enchantments, [
            (Enchantment.Efficiency, 10)
        ]), 1f, 1, 1),
        
        new(new ItemStack(Item.DiamondPickaxe).With(DataComponent.Enchantments, [
            // (Enchantment.Efficiency, 10)
        ]), 1f, 1, 1),
        
        // weapons
        new(new ItemStack(Item.StoneSword).WithTag(SkyWarsCombatFeature.DamageTag, 6f), 0.8f, 1, 1),
        new(new ItemStack(Item.IronSword).WithTag(SkyWarsCombatFeature.DamageTag, 8f), 0.3f, 1, 1),
        new(new ItemStack(Item.DiamondSword).WithTag(SkyWarsCombatFeature.DamageTag, 10f), 0.1f, 1, 1),

        // Axes hit for a little less than the sword of the same tier and take a shield away for five
        // seconds, which they carry themselves in their weapon component
        new(new ItemStack(Item.StoneAxe).WithTag(SkyWarsCombatFeature.DamageTag, 5f), 0.5f, 1, 1),
        new(new ItemStack(Item.IronAxe).WithTag(SkyWarsCombatFeature.DamageTag, 7f), 0.25f, 1, 1),
        new(new ItemStack(Item.DiamondAxe).WithTag(SkyWarsCombatFeature.DamageTag, 9f), 0.1f, 1, 1),
        
        // armour
        new(new ItemStack(Item.GoldenChestplate).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.05f), 0.2f, 1, 1),
        new(new ItemStack(Item.GoldenLeggings).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.05f), 0.1f, 1, 1),
        new(new ItemStack(Item.GoldenHelmet).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.05f), 0.2f, 1, 1),
        new(new ItemStack(Item.GoldenBoots).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.05f), 0.2f, 1, 1),
        
        new(new ItemStack(Item.IronChestplate).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.1f), 0.15f, 1, 1),
        new(new ItemStack(Item.IronLeggings).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.1f), 0.1f, 1, 1),
        new(new ItemStack(Item.IronHelmet).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.1f), 0.15f, 1, 1),
        new(new ItemStack(Item.IronBoots).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.1f), 0.15f, 1, 1),
        
        new(new ItemStack(Item.DiamondChestplate).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.2f), 0.1f, 1, 1),
        new(new ItemStack(Item.DiamondLeggings).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.2f), 0.05f, 1, 1),
        new(new ItemStack(Item.DiamondHelmet).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.2f), 0.1f, 1, 1),
        new(new ItemStack(Item.DiamondBoots).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.2f), 0.1f, 1, 1),
        new(new ItemStack(Item.TurtleHelmet)
            .WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.5f)
            .With(DataComponent.ItemName, TextComponent.FromLegacyString("&aHelmet of the no moving and no damage"))
            // .WithTag(AttributeModifiersFeature.AttributeModifiersTag, [
            //     new AttributeModifiersFeature.Modifier(Attribute.MovementSpeed.Identifier, -1, 
            //         "skywars:nomovenodamagehelmet", AttributeOperation.AddMultipliedTotal)
            // ])
            .With(DataComponent.AttributeModifiers, [new ItemAttributeModifier(
                Attribute.MovementSpeed, 
                "skywars:nomovenodamagehelmet",
                -1,
                AttributeOperation.AddMultipliedTotal,
                EquipmentSlotGroup.Head, ItemAttributeModifier.Display.DefaultMode())])
            , 1f, 1, 1),
    ];
    
    private record LootTableEntry(ItemStack Item, float Chance, int MinCount, int MaxCount);
    
    public override void Register() {
        // ChestBlock overrides useWithoutItem, not useItemOn, so this gates on that stage rather than
        // matching the packet. Doing it the way the real block does inherits the whole rule for free:
        // the click is skipped while crouching with a full hand (so sneak-placing a block against a
        // chest still works), it still runs bare handed while crouching, and the offhand never
        // reaches it. Vanilla's own chest behaves exactly this way.
        AddEventHandler<PlayerBlockInteractEvent>(e => {
            if (e.Result.ConsumesAction || e.Stage != InteractStage.UseWithoutItem) {
                return;
            }

            if (!IBlock.SimilarTo(e.Block, Block.Chest)) {
                return;
            }

            Vec3<int> pos = e.Position;

            // Chest right click
            Dictionary<Vec3<int>, Inventory> worldData = e.World.GetTagOrSetDefault(ChestsTag, []);

            if (worldData.TryGetValue(pos, out Inventory? value)) {
                e.Player.OpenInventory = value;
                e.Result = InteractionResult.Success;
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

                // Add to loot. Both bounds are inclusive, so an entry that wants exactly one of
                // something gets one rather than none.
                int count = Random.Shared.Next(entry.MinCount, entry.MaxCount + 1);
                int itemMaxStack = entry.Item.GetMaxStackSize();

                while (count > 0 && emptySlots.Count > 0) {
                    int effectiveMax = Random.Shared.Next(1, itemMaxStack + 1);
                    int amount = Math.Min(count, effectiveMax);
                    inv[emptySlots.Dequeue()] = entry.Item.WithCount(amount);
                    count -= amount;
                }
            }
            
            worldData.Add(pos, inv);
            e.World.SetTag(ChestsTag, worldData);
            e.Player.OpenInventory = inv;

            // ChestBlock.useWithoutItem returns SUCCESS. This is what stops the held block being
            // placed, and it does not depend on this feature being registered before or after
            // BlockPlacingFeature.
            e.Result = InteractionResult.Success;
        });
    }
}
