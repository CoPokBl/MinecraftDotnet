using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.BlockSumo;

public class BlockSumoMapProvider : ThreadedPerBlockTerrainProvider {

    private static readonly IBlock PlatformBlock = Block.RawCopperBlock;

    private readonly Dictionary<Vec3<int>, IBlock> _map = new();

    public BlockSumoMapProvider(int radius) {
        for (int x = -radius; x < radius; x++) {
            for (int z = -radius; z < radius; z++) {
                if (new Vec3<int>(x, 0, z).DistanceTo(Vec3<int>.Zero) > radius) {
                    continue;
                }
                
                _map.Add(new Vec3<int>(x, 60, z), PlatformBlock);
            }
        }
    }
    
    public override uint GetBlock(int x, int y, int z) {
        return _map.GetValueOrDefault(new Vec3<int>(x, y, z), Block.Air).StateId;
    }
}
