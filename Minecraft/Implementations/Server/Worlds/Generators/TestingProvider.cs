namespace Minecraft.Implementations.Server.Worlds.Generators;

public class TestingProvider : ITerrainProvider {
    
    public uint GetBlock(int x, int y, int z) {
        if (y == 0) {
            return 17;
        }

        if (y < 80) {
            return 11;
        }

        return 0;
    }
}