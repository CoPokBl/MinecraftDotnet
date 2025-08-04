using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class TeleportOrbItem : SkyWarsItem {
    private const int CooldownSeconds = 10;
    private const int Range = 40;
    
    private static readonly Tag<DateTime> LastUsedTag = new("skywars:teleport_orb_last_used");
    
    public override ItemStack Item => new ItemStack(Minecraft.Data.Generated.Item.EnderEye, 3)
        .With(DataComponent.ItemName, TextComponent.FromLegacyString("&bTeleport Orb &7(Right Click)"))
        .With(DataComponent.UseCooldown, new UseCooldownComponent.Data(0.1f, "skywars:teleport_orb"));
    public override string Id => "teleport_orb";

    public override bool Use(PlayerEntity player) {
        Vec3<int>? targetBlock = SkyWarsUtils.GetTargetBlock(player);
        if (targetBlock == null) {
            player.SendMessage(TextComponent.FromLegacyString("&cNo target found within range."));
            return false;
        }
        
        double distance = player.Position.DistanceTo(targetBlock.Value.BlockPosToDouble());
        if (distance > Range) {
            player.SendMessage(TextComponent.FromLegacyString("&cYou are too far away!"));
            return false;
        }
        
        // Check if the player has used the teleport orb recently
        DateTime? lastUsed = player.GetTagOrNull(LastUsedTag);
        if (lastUsed != null && (DateTime.Now - lastUsed.Value).TotalSeconds < CooldownSeconds) {
            int remainingSeconds = CooldownSeconds - (int)(DateTime.Now - lastUsed.Value).TotalSeconds;
            player.SendMessage(TextComponent.FromLegacyString("&cYou can use the Teleport Orb again in " + remainingSeconds + " seconds."));
            return false;
        }
        
        // Teleport the player to the target block
        player.Teleport(targetBlock.Value.BlockPosToDouble() + new Vec3<int>(0, 2, 0));
        player.SendMessage(TextComponent.FromLegacyString("&aYou have been teleported!"));
        player.ShowParticle(Particle.Enchant, targetBlock.Value, maxSpeed: 0.1f);
        // Set the last used time
        player.SetTag(LastUsedTag, DateTime.Now);
        // Send the cooldown packet
        player.SendPacket(new ClientBoundSetCooldownPacket {
            CooldownGroup = "skywars:teleport_orb",
            Ticks = CooldownSeconds * 20
        });
        return true;
    }
}
