using Minecraft.Data.Generated;

namespace Minecraft.Implementations.Server.Terrain.Providers;

public class TestingProvider() : ThreadedPerBlockTerrainProvider() {
    
    public override uint GetBlock(int x, int y, int z) {
        int height = (int)Math.Sqrt(x*x + z*z);
        return y >= height ? 0 : (Block.Barrier with {
            Waterlogged = true
        }).StateId;
    }
}