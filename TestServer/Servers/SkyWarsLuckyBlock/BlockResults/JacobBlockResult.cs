using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.BlockResults;

public class JacobBlockResult : IBlockResult {
    
    public void Trigger(World world, PlayerEntity? player, Vec3<int> position) {
        LivingEntity jacob = new(EntityType.Goat) {
            Position = position.BlockPosToDouble()
        };
        jacob.Meta = jacob.Meta with {
            CustomName = TextComponent.Text("Jacob"),
            CustomNameVisible = true
        };
        jacob.SetWorld(world);
    }
}
