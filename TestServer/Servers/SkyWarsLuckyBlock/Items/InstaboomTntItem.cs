using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class InstaboomTntItem : SkyWarsItem {
    public override ItemStack Item => new ItemStack(4, Minecraft.Data.Generated.Item.Tnt)
        .With(DataComponent.ItemName, TextComponent.FromLegacyString("&cInstaboom TNT"))
        .With(DataComponent.EnchantmentGlintOverride, true);
    
    public override string Id => "instaboom_tnt";
    
    private const int ExplodeRadius = 4;
    private const int LaunchRadius = 4;
    private const double LaunchPower = 1.025;
    
    public override bool OnPlace(PlayerEntity player, Vec3<int> position) {
        DoKaboom(player.World!, position, ExplodeRadius, LaunchRadius, LaunchPower);
        World world = player.World!;
        player.Server.Scheduler.ScheduleNextTick(() => {
            world.SetBlock(position, Block.Air);
        });
        return true;
    }
}