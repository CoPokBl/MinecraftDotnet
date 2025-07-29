using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.BlockResults;

public class NukeBlockResult : IBlockResult {
    
    public void Trigger(World world, PlayerEntity? player, Vec3<int> position) {
        world.SendMessage(TextComponent.FromLegacyString("&cNuclear launch activated!"));
        world.SendMessage(TextComponent.FromLegacyString("&cSetting coordinates for the nuke..."));
        world.SendMessage(TextComponent.FromLegacyString("&cX: " + position.X + ", Y: " + position.Y + ", Z: " + position.Z));
        world.SendMessage(TextComponent.FromLegacyString("&cT-minus 10 seconds until detonation!"));
        world.PlaySound(SoundType.RaidHorn, player!);

        world.Server.Scheduler.ScheduleTask(TimeSpan.FromSeconds(10), () => {
            SkyWarsItem.DoKaboom(world, position, 30, 40, 5);
            world.SendMessage(TextComponent.FromLegacyString("&cNuclear detonation complete!"));
        });
    }
}
