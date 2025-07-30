using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class KnockbackStickItem : SkyWarsItem {
    public override ItemStack Item => new ItemStack(Minecraft.Data.Generated.Item.Stick)
        .WithTag(SkyWarsCombatFeature.KnockbackTag, 10)
        .With(DataComponent.ItemName, TextComponent.FromLegacyString("&aKnockback Stick"));
    public override string Id => "knockback_stick";
}
