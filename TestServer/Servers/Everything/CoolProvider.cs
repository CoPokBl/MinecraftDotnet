using Minecraft.Implementations.Server.Terrain.Providers;

namespace TestServer.Servers.Everything;

public class CoolProvider : ThreadedPerBlockTerrainProvider {
    public override uint GetBlock(int x, int y, int z) {
        int height = Height(x, z);
        return y >= height ? (uint)0 : 11;
    }

    private static int Height(int x, int z) {
        const double len = 50;
        const double amp = 50;
        return (int)(amp*Math.Sin(x*(1/len)) + amp*Math.Sin(z*(1/len)) + 2*amp + 1);
    }
}