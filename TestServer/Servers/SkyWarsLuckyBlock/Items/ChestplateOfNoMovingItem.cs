using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class ChestplateOfNoMovingItem : SkyWarsItem {
    public override ItemStack Item => new ItemStack(Minecraft.Data.Generated.Item.LeatherChestplate)
        .With(DataComponent.ItemName, "Brittle Chestplate")
        .With(DataComponent.DyedColor, TextColor.Black)
        .With(DataComponent.Lore, [
            TextComponent.FromLegacyString("&7This chestplate stops you taking knockback,"),
            TextComponent.FromLegacyString("&7but you take more damage while wearing it!")
        ])
        .WithTag(SkyWarsCombatFeature.KnockbackReductionTag, 1f)
        .WithTag(SkyWarsCombatFeature.DamageReductionTag, -0.2f);
    public override string Id => "chestplate_of_no_moving";
}
