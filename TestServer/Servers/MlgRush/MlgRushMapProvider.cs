using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.MlgRush;

public class MlgRushMapProvider : ThreadedPerBlockTerrainProvider {
    
    // Blocks
    private static readonly IBlock PlatformBlock = Block.RedSandstone;

    // Map params
    public const int PlatformLength = 22;
    public const double P1SpawnX = -1.5;
    public const double P2SpawnX = PlatformLength + 0.5;
    public static readonly IVec3 P1BedPos = new(-4, 60, 0);
    public static readonly IVec3 P2BedPos = new(PlatformLength+3, 60, 0);
    
    public static readonly IVec3 P1BedPosClient = new(-4, -3, 0);
    public static readonly IVec3 P2BedPosClient = new(PlatformLength+3, -3, 0);
    
    private static readonly Dictionary<IVec3, IBlock> Map = new() {
        // "beds"
        { new IVec3(-4, 61, 0), Block.WhiteWool },
        { new IVec3(PlatformLength+3, 61, 0), Block.WhiteWool },
        
        // bed plate
        { P1BedPos, PlatformBlock },
        { P2BedPos, PlatformBlock },
    };

    static MlgRushMapProvider() {
        for (int i = 0; i < PlatformLength; i++) {
            Map.Add(new IVec3(i, 60, 0), PlatformBlock);
        }

        for (int i = -1; i < 2; i++) {
            for (int j = -1; j < 2; j++) {
                // spawn block for p1
                Map.Add(new IVec3(PlatformLength + 1 + i, 60, j), PlatformBlock);
                
                // spawn block for p2
                Map.Add(new IVec3(-2 + i, 60, j), PlatformBlock);
            }
        }
    }
    
    public override uint GetBlock(int x, int y, int z) {
        return Map.GetValueOrDefault(new IVec3(x, y, z), Block.Air).StateId;
    }
}
