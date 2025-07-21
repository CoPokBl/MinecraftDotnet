using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using TestServer.Servers.SkyWarsLuckyBlock.Items;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class LuckyBlocksFeature : ScopedFeature {
    private static readonly Tag<LuckyBlockType> LuckyBlockItemTag = new("lucky_block_item");
    
    private static readonly ItemStack[] LuckyItems = [
        SkyWarsItemsFeature.CreateItem(typeof(TestItem)),
        SkyWarsItemsFeature.CreateItem(typeof(KnockbackStickItem))
    ];
    
    private enum LuckyBlockType {
        Normal,
        Super,
        Ultra
    }
    
    private record LuckyBlock(LuckyBlockType Type, Entity? PlacedEntity);
    
    private readonly Dictionary<IVec3, LuckyBlock> _placedBlocks = [];

    public static ItemStack GetLuckyBlock(int count = 1) {
        return new ItemStack(count, Item.YellowStainedGlass)
            .WithTag(LuckyBlockItemTag, LuckyBlockType.Normal);
    }
    
    public override void Register() {
        AddEventListener<PlayerPlaceBlockEvent>(e => {
            if (!e.UsedItem.HasTag(LuckyBlockItemTag)) {
                return;
            }
            
            LuckyBlockType block = e.UsedItem.GetTag(LuckyBlockItemTag);
            
            // Lucky block placed, let's do something
            e.Block = Block.YellowStainedGlass;

            Entity insideThing = new(EntityType.Bee) {
                Position = e.Position.BlockPositionToVec3() - new Vec3(0, 0.3, 0)
            };
            e.World.Spawn(insideThing);
            
            _placedBlocks.Add(e.Position, new LuckyBlock(block, insideThing));
        });
        
        AddEventListener<PlayerBreakBlockEvent>(e => {
            if (!_placedBlocks.Remove(e.Position, out LuckyBlock? block)) {
                return;
            }
            
            // Lucky block broken, let's do something
            e.World.DropItem(e.Position, LuckyItems[Random.Shared.Next(LuckyItems.Length)]);
            block.PlacedEntity?.Despawn();
        });
    }
}
