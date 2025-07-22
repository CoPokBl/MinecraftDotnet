using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class OneUpItem : SkyWarsItem {
    public override ItemStack Item => new ItemStack(1, Minecraft.Data.Generated.Item.RedMushroom)
        .With(DataComponent.ItemName, "One-Up Mushroom");
    public override string Id => "skywars:one_up_item";

    public override bool Use(PlayerEntity player) {
        // Heal the player by 2 hearts
        player.Heal();
        player.SendMessage(TextComponent.FromLegacyString("&aYou have been healed!"));
        
        // Play a sound effect
        player.World?.PlaySound(SoundType.PlayerBurp, player);
        
        return true;
    }
}
