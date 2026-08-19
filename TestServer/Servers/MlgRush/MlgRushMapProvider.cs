using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.MlgRush;

/// <summary>
/// The two spawn plates, the bridge between them, and a wool "bed" at each end.
/// </summary>
/// <remarks>
/// Written as the handful of blocks it is, rather than answered per position out of a dictionary,
/// which would be 98,304 hashes of a three int struct to place about seventy blocks.
/// <p/>
/// All coordinates are game y, including the bed constants the game logic compares a click against,
/// so there is one constant per bed rather than a protocol y copy beside it.
/// </remarks>
public class MlgRushMapProvider : IGenerator {
    private static readonly IBlock PlatformBlock = Block.RedSandstone;

    // Map params
    public const int PlatformLength = 22;
    public const double P1SpawnX = -1.5;
    public const double P2SpawnX = PlatformLength + 0.5;

    /// <summary>Where the bridge and the spawn plates sit.</summary>
    private const int PlatformY = -4;

    /// <summary>The wool a player has to break, one above the plate holding it up.</summary>
    public static readonly Vec3<int> P1BedPos = new(-4, PlatformY + 1, 0);
    public static readonly Vec3<int> P2BedPos = new(PlatformLength + 3, PlatformY + 1, 0);

    private static readonly Dictionary<Vec3<int>, IBlock> Map = new() {
        // The wool "beds", and the plate under each.
        { P1BedPos, Block.WhiteWool },
        { P2BedPos, Block.WhiteWool },
        { new Vec3<int>(-4, PlatformY, 0), PlatformBlock },
        { new Vec3<int>(PlatformLength + 3, PlatformY, 0), PlatformBlock }
    };

    static MlgRushMapProvider() {
        for (int i = 0; i < PlatformLength; i++) {
            Map.Add(new Vec3<int>(i, PlatformY, 0), PlatformBlock);
        }

        for (int i = -1; i < 2; i++) {
            for (int j = -1; j < 2; j++) {
                Map.Add(new Vec3<int>(PlatformLength + 1 + i, PlatformY, j), PlatformBlock);
                Map.Add(new Vec3<int>(-2 + i, PlatformY, j), PlatformBlock);
            }
        }
    }

    public void Generate(IGenerationUnit unit) {
        Vec3<int> start = unit.AbsoluteStart;
        Vec3<int> end = unit.AbsoluteEnd;

        foreach ((Vec3<int> pos, IBlock block) in Map) {
            if (pos.X < start.X || pos.X >= end.X || pos.Z < start.Z || pos.Z >= end.Z) {
                continue;
            }

            unit.Modifier.SetBlock(pos, block);
        }
    }
}
