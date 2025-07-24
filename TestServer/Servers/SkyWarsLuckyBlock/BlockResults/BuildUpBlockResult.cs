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
            if (position.Y - yOffset < world.Dimension.MinY + 1) {
                return false; // Stop the task
            }
            
            world.SetBlock(position.WithY(position.Y + yOffset), Block.IronBlock);
            world.SetBlock(position.WithY(position.Y - yOffset), Block.IronBlock);
            world.PlaySound(SoundType.IronGolemHurt, position.WithY(position.Y + yOffset));
            yOffset++;

            return true;
        });
    }
}
