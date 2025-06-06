namespace Minecraft.Implementations.Server.Worlds.TerrainProviders;

public class TestingProvider() : ThreadedPerBlockTerrainProvider() {
    
    public override uint GetBlock(int x, int y, int z) {
        int height = (int)Math.Sqrt(x*x + z*z);
        return y >= height ? (uint)0 : 11;
    }
}