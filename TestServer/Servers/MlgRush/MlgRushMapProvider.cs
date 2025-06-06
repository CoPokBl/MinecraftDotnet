using Minecraft.Implementations.Server.Worlds.TerrainProviders;
using Minecraft.Schemas;

namespace TestServer.Servers.MlgRush;

public class MlgRushMapProvider : ThreadedPerBlockTerrainProvider {
    private const uint RedSandstone = 11968;
    private const uint WhiteWool = 2093;
    private const uint Air = 0;

    private const int PlatformLength = 20;
    
    private static readonly Dictionary<BlockPosition, uint> Map = new() {
        { new BlockPosition(0, 61, 0), WhiteWool },
        { new BlockPosition(PlatformLength-1, 61, 0), WhiteWool }
    };

    static MlgRushMapProvider() {
        for (int i = 0; i < PlatformLength; i++) {
            Map.Add(new BlockPosition(i, 60, 0), RedSandstone);
        }
    }
    
    public override uint GetBlock(int x, int y, int z) {
        return Map.GetValueOrDefault(new BlockPosition(x, y, z), Air);
    }
}