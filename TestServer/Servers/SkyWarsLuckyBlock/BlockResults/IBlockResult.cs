using ManagedServer.Entities.Types;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.SkyWarsLuckyBlock.BlockResults;

public interface IBlockResult {
    public void Trigger(PlayerEntity player, IVec3 position);
}
