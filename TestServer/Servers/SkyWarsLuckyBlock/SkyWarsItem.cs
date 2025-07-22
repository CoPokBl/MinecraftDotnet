using ManagedServer.Entities.Types;
using Minecraft.Schemas.Items;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public abstract class SkyWarsItem {
    public abstract ItemStack Item { get; }
    public abstract string Id { get; }

    public virtual bool Use(PlayerEntity player) {
        return false;
    }

    public virtual void OnEat(PlayerEntity player) {
        
    }
}
