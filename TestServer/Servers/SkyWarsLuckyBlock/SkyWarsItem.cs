using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public abstract class SkyWarsItem {
    public abstract ItemStack Item { get; }
    public abstract string Id { get; }

    public virtual bool Use(PlayerEntity player) {
        return false;
    }

    public virtual void OnEat(PlayerEntity player) {
        
    }

    public virtual bool OnPlace(PlayerEntity player, Vec3<int> position) {
        return true;
    }

    public virtual void OnHitWhileWearing(PlayerEntity wearer, PlayerEntity attacker) {
        
    }

    public static void DoKaboom(World world, Vec3<int> position, int explodeRadius, int launchRadius, double launchPower) {
        IAudience audience = world.GetViewersOf(position);
        
        // Destroy all blocks in a 5 block radius
        for (int x = -explodeRadius; x <= explodeRadius; x++) {
            for (int y = -explodeRadius; y <= explodeRadius; y++) {
                for (int z = -explodeRadius; z <= explodeRadius; z++) {
                    Vec3<int> blockPos = position + new Vec3<int>(x, y, z);

                    if (blockPos.DistanceTo(position) > explodeRadius) {
                        continue; // Skip blocks outside the radius
                    }
                    
                    IBlock block = world.GetBlockOr(blockPos, Block.Air);
                    if (block.Identifier != Block.Air.Identifier) {
                        world.SetBlock(blockPos, Block.Air);
                    }
                    
                    audience.ShowParticle(Particle.DragonBreath, blockPos);
                }
            }
        }
            
        Vec3<double> pos = position.BlockPosToDouble();
        
        // Launch nearby players into the air
        Entity[] nearby = world.Entities.GetNearbyEntities(pos, explodeRadius);
        foreach (Entity entity in nearby) {
            if (!(entity.Position.DistanceTo(pos) <= launchRadius)) continue;

            double kbReduction = 0.0;
            if (entity is PlayerEntity p) {
                ItemStack[] armour = [
                    p.Inventory.Helmet,
                    p.Inventory.Chestplate,
                    p.Inventory.Leggings,
                    p.Inventory.Boots
                ];
                
                foreach (ItemStack armourPiece in armour) {
                    kbReduction += armourPiece.GetTagOrDefault(SkyWarsCombatFeature.KnockbackReductionTag, 0.0);
                }
            }
            
            Vec3<double> normalizedDirection = (entity.Position - pos).Normalize();
            entity.Velocity = normalizedDirection * (launchRadius - (entity.Position - pos).ComputeLength()) * launchPower * (1.0 - kbReduction);
        }
        
        audience.PlaySound(SoundType.GenericExplode, pos);
    }
}
