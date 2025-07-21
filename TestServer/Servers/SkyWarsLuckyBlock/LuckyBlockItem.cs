using ManagedServer.Entities.Types;
using Minecraft.Schemas.Items;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public abstract class LuckyBlockItem {
    public abstract ItemStack Item { get; }
    public abstract string Id { get; }

    public virtual void Use(PlayerEntity player) {
        
    }

    public virtual void OnEat(PlayerEntity player) {
        
    }
}
