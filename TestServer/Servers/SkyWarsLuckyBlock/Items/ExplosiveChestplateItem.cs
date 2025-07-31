using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class ExplosiveChestplateItem : SkyWarsItem {
    public override ItemStack Item => new ItemStack(Minecraft.Data.Generated.Item.LeatherChestplate)
        .With(DataComponent.EnchantmentGlintOverride, true)
        .With(DataComponent.ItemName, "Explosive Chestplate");
    public override string Id => "skywars:explosive_chestplate";

    public override void OnHitWhileWearing(PlayerEntity wearer, PlayerEntity attacker) {
        DoKaboom(wearer.World!, wearer.Position.ToBlockPos(), 4, 4, 2);
    }
}
