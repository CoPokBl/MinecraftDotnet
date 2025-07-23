using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.SkyWarsLuckyBlock.BlockResults;

public record ItemBlockResult(ItemStack Item) : IBlockResult {
    
    public ItemBlockResult(Type itemType) : this(SkyWarsItemsFeature.CreateItem(itemType)) { }
    
    public void Trigger(World world, PlayerEntity? player, IVec3 position) {
        world.DropItem(position + new Vec3(0.5, 0, 0.5), Item);
    }
}
