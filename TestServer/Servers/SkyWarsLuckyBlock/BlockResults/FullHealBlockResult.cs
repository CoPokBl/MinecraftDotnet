using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock.BlockResults;

public class FullHealBlockResult : IBlockResult {
    
    public void Trigger(World world, PlayerEntity? player, IVec3 position) {
        player?.Heal();
        player?.SendMessage(TextComponent.FromLegacyString("&aYou have been fully healed!"));
    }
}
