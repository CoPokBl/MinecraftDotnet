using Minecraft.Implementations.Server.Worlds.TerrainProviders;
using Minecraft.Schemas;

namespace TestServer.Servers.MlgRush;

public class MlgRushMapProvider : ThreadedPerBlockTerrainProvider {
    private const uint RedSandstone = 11968;
    public const uint WhiteWool = 2093;
    private const uint Air = 0;
    private const uint BlueBed = 1909;
    
    // Blocks
    private const uint PlatformBlock = RedSandstone;

    // Map params
    public const int PlatformLength = 22;
    public const double P1SpawnX = -1.5;
    public const double P2SpawnX = PlatformLength + 1.5;
    public static readonly BlockPosition P1BedPos = new(-4, 60, 0);
    public static readonly BlockPosition P2BedPos = new(PlatformLength+4, 60, 0);
    
    public static readonly BlockPosition P1BedPosClient = new(-4, -3, 0);
    public static readonly BlockPosition P2BedPosClient = new(PlatformLength+4, -3, 0);
    
    private static readonly Dictionary<BlockPosition, uint> Map = new() {
        // "beds"
        { new BlockPosition(-4, 61, 0), WhiteWool },
        { new BlockPosition(PlatformLength+4, 61, 0), WhiteWool },
        
        // bed plate
        { P1BedPos, PlatformBlock },
        { P2BedPos, PlatformBlock },
    };

    static MlgRushMapProvider() {
        for (int i = 0; i < PlatformLength; i++) {
            Map.Add(new BlockPosition(i, 60, 0), PlatformBlock);
        }

        for (int i = -1; i < 2; i++) {
            for (int j = -1; j < 2; j++) {
                // spawn block for p1
                Map.Add(new BlockPosition(PlatformLength + 1 + i, 60, j), PlatformBlock);
                
                // spawn block for p2
                Map.Add(new BlockPosition(-2 + i, 60, j), PlatformBlock);
            }
        }
    }
    
    public override uint GetBlock(int x, int y, int z) {
        return Map.GetValueOrDefault(new BlockPosition(x, y, z), Air);
    }
}