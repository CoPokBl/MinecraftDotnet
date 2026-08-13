using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;

namespace TestServer.Servers.MobAi;

/// <summary>
/// A flat arena with the things worth watching mob movement against: a wall with a gap in it, a
/// staircase of steps one, two and three blocks high, and a pool of lava.
/// <p/>
/// Each is a different part of the pathfinder. The wall is planning, and a mob should walk to the gap
/// rather than into the bricks. The staircase is the step and jump rules: one block is a jump the
/// search will take, and the taller steps are not, so a mob climbs the first and routes round the
/// rest. The lava is the malus, which is the only thing keeping a mob out of it, since nothing about
/// lava is solid.
/// </summary>
public class MobAiMapProvider : ThreadedPerBlockTerrainProvider {
    /// <summary>Where the floor is, in game coordinates. A mob standing on it is at y 0.</summary>
    public const int FloorY = 0;

    /// <summary>The arena is this many blocks either side of the origin.</summary>
    public const int Radius = 32;

    /// <summary>Where the wall runs, in game x.</summary>
    private const int WallX = 12;

    /// <summary>How wide the gap in the wall is, centred on z zero.</summary>
    private const int GapHalfWidth = 2;

    private const int WallHeight = 4;

    /// <summary>Where the staircase starts, in game x. It runs away from the origin.</summary>
    private const int StairsX = -8;

    /// <summary>A pool of lava north of the origin, wide enough that a mob has to go round it.</summary>
    private const int LavaZ = 10;
    private const int LavaHalfDepth = 1;
    private const int LavaHalfWidth = 5;

    private static readonly IBlock Floor = Block.SmoothStone;
    private static readonly IBlock Wall = Block.StoneBricks;
    private static readonly IBlock Step = Block.OakPlanks;

    /// <summary>
    /// The provider works in protocol y (zero at the bottom of the world), so everything below is
    /// written in game y and shifted here. Getting this backwards puts the floor 64 blocks under the
    /// spawn point, which looks exactly like the terrain having failed to generate.
    /// </summary>
    private const int MinY = -64;

    public override uint GetBlock(int x, int y, int z) {
        return BlockAt(x, y + MinY, z).StateId;
    }

    private static IBlock BlockAt(int x, int y, int z) {
        if (Math.Abs(x) > Radius || Math.Abs(z) > Radius) {
            return Block.Air;
        }

        if (y == FloorY - 1) {
            // The pool is sunk into the floor rather than sitting on it, so a mob walking into it
            // would fall in rather than wade. Nothing here is solid: only the malus keeps it out.
            return InLava(x, z) ? Block.Lava : Floor;
        }

        if (y < FloorY - 1) {
            return Block.Air;
        }

        // The wall, with a gap a mob has to aim for rather than walk through.
        if (x == WallX && y < FloorY + WallHeight && Math.Abs(z) > GapHalfWidth) {
            return Wall;
        }

        // Three steps going west, each two blocks deep so a mob can stand on one, and one block taller
        // each: 1, 2 and 3 high. Only the first is a step vanilla walks up without a jump.
        int stepsWest = (StairsX - x) / 2;
        if (x <= StairsX && stepsWest is >= 0 and < 3 && y < FloorY + stepsWest + 1) {
            return Step;
        }

        return Block.Air;
    }

    private static bool InLava(int x, int z) {
        return Math.Abs(z - LavaZ) <= LavaHalfDepth && Math.Abs(x) <= LavaHalfWidth;
    }
}
