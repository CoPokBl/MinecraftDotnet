using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.BlockSumo;

public class BlockSumoMapProvider : ThreadedPerBlockTerrainProvider {

    private static readonly IBlock PlatformBlock = Block.RawCopperBlock;

    private Dictionary<IVec3, IBlock> Map = new();

    public BlockSumoMapProvider(int radius) {
        for (int x = -radius; x < radius; x++) {
            for (int z = -radius; z < radius; z++) {
                if (new IVec3(x, 0, z).DistanceTo(IVec3.Zero) > radius) {
                    continue;
                }
                
                Map.Add(new IVec3(x, 60, z), PlatformBlock);
            }
        }
    }
    
    public override uint GetBlock(int x, int y, int z) {
        return Map.GetValueOrDefault(new IVec3(x, y, z), Block.Air).StateId;
    }
}
