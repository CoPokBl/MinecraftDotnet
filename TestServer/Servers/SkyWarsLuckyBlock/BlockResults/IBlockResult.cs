using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.SkyWarsLuckyBlock.BlockResults;

public interface IBlockResult {
    public void Trigger(World world, PlayerEntity? player, IVec3 position);
}
