using ManagedServer;
using ManagedServer.Events;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class LuckyBlocksFeature : ScopedFeature {
    private static readonly Tag<LuckyBlock> LuckyBlockItemTag = new("lucky_block_item");
    
    private static readonly ItemStack[] LuckyItems = [
        new(5, Item.AcaciaBoat)
    ];
    
    private enum LuckyBlockType {
        Normal,
        Super,
        Ultra
    }
    
    private record LuckyBlock(LuckyBlockType Type, string Name);
    
    private readonly List<IVec3> _placedBlocks = [];

    public static ItemStack GetLuckyBlock(int count = 1) {
        return new ItemStack(count, Item.YellowStainedGlass)
            .With(LuckyBlockItemTag, new LuckyBlock(LuckyBlockType.Normal, "Hello there"));
    }
    
    public override void Register() {
        AddEventListener<PlayerPlaceBlockEvent>(e => {
            LuckyBlock? block = e.UsedItem.GetTagOrNull(LuckyBlockItemTag);
            if (block == null) {
                return;
            }
            
            Console.WriteLine("Placing lucky block: " + block.Name);
            
            // Lucky block placed, let's do something
            e.Block = Block.YellowStainedGlass;
            _placedBlocks.Add(e.Position);
        });
        
        AddEventListener<PlayerBreakBlockEvent>(e => {
            if (!_placedBlocks.Contains(e.Position)) {
                return;
            }
            
            // Lucky block broken, let's do something
            _placedBlocks.Remove(e.Position);
            e.World.DropItem(e.Position, LuckyItems[Random.Shared.Next(LuckyItems.Length)]);
        });
    }
}
