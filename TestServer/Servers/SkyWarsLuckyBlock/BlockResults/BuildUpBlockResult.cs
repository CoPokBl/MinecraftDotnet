using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.SkyWarsLuckyBlock.BlockResults;

public class BuildUpBlockResult : IBlockResult {
    
    public void Trigger(World world, PlayerEntity? player, Vec3<int> position) {
        int yOffset = 0;
        world.Server.Scheduler.ScheduleRepeatingTask(TimeSpan.FromSeconds(0.2), () => {
            if (!world.IsInBounds(position.WithY(position.Y - yOffset))) {
                return false;  // We hit a height limit
            }
            
            world.SetBlock(position.WithY(position.Y + yOffset), Block.IronBlock);
            world.SetBlock(position.WithY(position.Y - yOffset), Block.IronBlock);
            world.PlaySound(SoundType.IronGolemHurt, position.WithY(position.Y + yOffset), volume:0.2f);
            yOffset++;

            return true;
        });
    }
}
