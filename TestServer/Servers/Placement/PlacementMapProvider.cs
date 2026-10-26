using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace TestServer.Servers.Placement;

/// <summary>
/// A flat yard with the props each family of placement rule needs to be visible.
/// <p/>
/// Everything here exists because some rule reads the world rather than just the player: a wall to
/// attach to, water to log into, a slab to double, and snow and grass to be replaced instead of
/// placed beside. On an empty floor most of the rules look the same as no rules at all.
/// </summary>
public class PlacementMapProvider : IGenerator {
    /// <summary>Where the floor is, in game coordinates. A player standing on it is at y 0.</summary>
    public const int FloorY = 0;

    public const int Radius = 40;

    /// <summary>A stone wall to hang torches, signs, ladders, levers and buttons on. Runs along x.</summary>
    private const int WallZ = -10;
    private const int WallHalfLength = 10;
    private const int WallHeight = 4;

    /// <summary>A pool sunk into the floor, for waterlogging.</summary>
    private const int PoolX = 12;
    private const int PoolHalf = 3;

    /// <summary>A row of bottom slabs to double, and a patch of snow and grass to replace in place.</summary>
    private const int SlabRowZ = 6;
    private const int SnowZ = 10;

    public void Generate(IGenerationUnit unit) {
        unit.Modifier.SetAll(BlockAt);
    }

    private static IBlock BlockAt(int x, int y, int z) {
        if (Math.Abs(x) > Radius || Math.Abs(z) > Radius) {
            return Block.Air;
        }

        if (y < FloorY - 1) {
            return Block.Air;
        }

        if (y == FloorY - 1) {
            return Block.SmoothStone;
        }

        if (y == FloorY) {
            if (InPool(x, z)) {
                return Block.Water;
            }

            // A run of bottom slabs. Clicking the top of one with another oak slab doubles it; a
            // spruce slab goes on top instead, because a slab only merges with its own kind.
            if (z == SlabRowZ && x is >= -4 and <= 4) {
                return ((ISlabTyped)Block.OakSlab).WithType(SlabType.Bottom);
            }

            // Snow one layer deep, which anything may replace outright, next to grass, which is
            // replaceable the ordinary way. Both are the "placed into, not beside" case.
            if (z == SnowZ && x is >= -4 and <= 0) {
                return Block.Snow;
            }

            if (z == SnowZ && x is >= 2 and <= 6) {
                return Block.ShortGrass;
            }

            return Block.Air;
        }

        // The wall, four blocks tall, for everything that attaches to a surface.
        if (z == WallZ && Math.Abs(x) <= WallHalfLength && y < FloorY + WallHeight) {
            return Block.StoneBricks;
        }

        return Block.Air;
    }

    private static bool InPool(int x, int z) {
        return Math.Abs(x - PoolX) <= PoolHalf && Math.Abs(z) <= PoolHalf;
    }
}
