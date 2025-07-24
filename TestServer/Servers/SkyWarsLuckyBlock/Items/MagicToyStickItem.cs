using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class MagicToyStickItem : SkyWarsItem {
    private const double MaxDistance = 100.0; // Maximum distance the stick can reach
    private const int ExplodeRadius = 5; // Radius of the explosion effect
    private const int LaunchRadius = 6; // Radius of players being launched into the air
    private const double LaunchPower = 4;
    
    public override ItemStack Item => new ItemStack(1, Minecraft.Data.Generated.Item.BreezeRod)
        .With(DataComponent.ItemName, TextComponent.FromLegacyString("&c&lMagic Toy Stick"))
        .With(DataComponent.EnchantmentGlintOverride, true);
    public override string Id => "magic_toy_stick";

    public override bool Use(PlayerEntity player) {
        Vec3<int>? targetBlock = SkyWarsUtils.GetTargetBlock(player, MaxDistance, true);
        if (targetBlock == null) {
            player.SendMessage("No target found within range.");
            return false;
        }
        
        Hit(player, targetBlock.Value);
        return true;
    }

    private static void Hit(PlayerEntity player, Vec3<int> location) {
        player.SendMessage("Boom!");
        World world = player.World!;

        IAudience audience = world.GetViewersOf(location);
        
        // Destroy all blocks in a 5 block radius
        for (int x = -ExplodeRadius; x <= ExplodeRadius; x++) {
            for (int y = -ExplodeRadius; y <= ExplodeRadius; y++) {
                for (int z = -ExplodeRadius; z <= ExplodeRadius; z++) {
                    Vec3<int> blockPos = location + new Vec3<int>(x, y, z);

                    if (blockPos.DistanceTo(location) > ExplodeRadius) {
                        continue; // Skip blocks outside the radius
                    }
                    
                    IBlock block = world.GetBlock(blockPos);
                    if (block.Identifier != Block.Air.Identifier) {
                        world.SetBlock(blockPos, Block.Air);
                    }
                    
                    audience.ShowParticle(Particle.Explosion, blockPos);
                }
            }
        }
        
        // Launch nearby players into the air
        Entity[] nearby = world.Entities.GetNearbyEntities(location, 5);
        foreach (Entity entity in nearby) {
            if (entity is not PlayerEntity playerEntity ||
                !(playerEntity.Position.DistanceTo(location) <= LaunchRadius)) continue;
            
            // Direction should be away from the explosion but with some vertical component
            Vec3<double> direction = (playerEntity.Position - location).Normalize() * LaunchPower;
            playerEntity.SetVelocity(direction);
        }
        
        audience.PlaySound(SoundType.GenericExplode, location);
    }
}
