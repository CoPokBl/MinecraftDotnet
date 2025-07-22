using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class TeleportOrbItem : SkyWarsItem {
    public override ItemStack Item => new ItemStack(3, Minecraft.Data.Generated.Item.EnderEye)
        .With(DataComponent.ItemName, TextComponent.FromLegacyString("&bTeleport Orb &7(Right Click)"));
    public override string Id => "teleport_orb";

    public override bool Use(PlayerEntity player) {
        IVec3? targetBlock = SkyWarsUtils.GetTargetBlock(player);
        if (targetBlock == null) {
            player.SendMessage("No target found within range.");
            return false;
        }
        
        // Teleport the player to the target block
        player.Teleport(targetBlock.Value + new IVec3(0, 2, 0));
        player.SendMessage(TextComponent.FromLegacyString("&aYou have been teleported!"));
        player.ShowParticle(Particle.Enchant, targetBlock.Value, maxSpeed: 0.1f);
        return true;
    }
}
