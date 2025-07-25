using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.BlockResults;

public class BobBlockResult : IBlockResult {
    
    public void Trigger(World world, PlayerEntity? player, Vec3<int> position) {
        LivingEntity bob = new(EntityType.IronGolem) {
            Position = position.BlockPosToDouble()
        };
        bob.Meta = bob.Meta with {
            CustomName = TextComponent.Text("Bob"),
            CustomNameVisible = true
        };
        bob.SetWorld(world);
    }
}
