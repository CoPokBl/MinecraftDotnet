using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public static class SkyWarsUtils {

    public static IVec3? GetTargetBlock(PlayerEntity player, double maxDist = 100, bool particle = false) {
        Vec3 direction = player.Direction;
        
        // Cast a ray in the direction the player is looking
        // slowly moving towards the target and checking for blocks
        // or entities
        Vec3 start = player.Position + new Vec3(0, player.EyeHeight, 0);
        float distance = 0.0f;
        while (distance < maxDist) {
            Vec3 pos = start + direction * distance;
            distance += 0.1f;

            if (particle) {
                player.ShowParticle(Particle.Crit, pos, maxSpeed:0f);
            }
            
            // Check if there's an entity at this position
            IBlock block = pos.Y < player.World!.Dimension.MinY ? Block.Air : player.World!.GetBlock(pos);
            if (block.Identifier == Block.Air.Identifier) {
                continue;
            }
            
            // Remove the item
            return pos.ToBlockPos();
        }
        
        player.SendMessage("No target found within range.");
        return null;
    }
}
