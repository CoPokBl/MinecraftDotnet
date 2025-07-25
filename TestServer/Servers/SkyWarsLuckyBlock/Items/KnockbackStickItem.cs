using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class KnockbackStickItem : SkyWarsItem {
    public override ItemStack Item => new ItemStack(1, Minecraft.Data.Generated.Item.Stick)
        .WithTag(SkyWarsCombatFeature.KnockbackTag, 5)
        .With(DataComponent.ItemName, TextComponent.FromLegacyString("&aKnockback Stick"));
    public override string Id => "knockback_stick";
}
