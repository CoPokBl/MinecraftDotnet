using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas;

namespace TestServer.Servers.BlockSumo;

public class BlockSumoMapProvider : ThreadedPerBlockTerrainProvider {

    private static readonly IBlock PlatformBlock = Block.RawCopperBlock;

    private Dictionary<BlockPosition, IBlock> Map = new();

    public BlockSumoMapProvider(int radius) {
        for (int x = -radius; x < radius; x++) {
            for (int z = -radius; z < radius; z++) {
                if (new BlockPosition(x, 0, z).DistanceTo(BlockPosition.Zero) > radius) {
                    continue;
                }
                
                Map.Add(new BlockPosition(x, 60, z), PlatformBlock);
            }
        }
    }
    
    public override uint GetBlock(int x, int y, int z) {
        return Map.GetValueOrDefault(new BlockPosition(x, y, z), Block.Air).StateId;
    }
}
