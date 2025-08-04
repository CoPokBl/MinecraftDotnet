using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class MagicToyStickItem : SkyWarsItem {
    private const double MaxDistance = 100.0; // Maximum distance the stick can reach
    private const int ExplodeRadius = 5; // Radius of the explosion effect
    private const int LaunchRadius = 6; // Radius of players being launched into the air
    private const double LaunchPower = 1.05;
    
    public override ItemStack Item => new ItemStack(Minecraft.Data.Generated.Item.BreezeRod)
        .With(DataComponent.ItemName, TextComponent.FromLegacyString("&c&lMagic Toy Stick"))
        .With(DataComponent.EnchantmentGlintOverride, true);
    public override string Id => "magic_toy_stick";

    public override bool Use(PlayerEntity player) {
        Vec3<int>? targetBlock = SkyWarsUtils.GetTargetBlock(player, MaxDistance, true);
        if (targetBlock == null) {
            player.SendMessage(TextComponent.FromLegacyString("&cNo target found within range."));
            return false;
        }
        
        Hit(player, targetBlock.Value);
        return true;
    }

    private static void Hit(PlayerEntity player, Vec3<int> location) {
        player.SendMessage("Boom!");
        DoKaboom(player.World!, location, ExplodeRadius, LaunchRadius, LaunchPower);
    }
}
