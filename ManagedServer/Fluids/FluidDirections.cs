using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Fluids;

/// <summary>
/// <see cref="BlockFace"/> helpers, standing in for vanilla's <c>Direction</c>. The horizontal set
/// is in vanilla's <c>Direction.Plane.HORIZONTAL</c> order (north, south, west, east), which decides
/// which way a fluid picks when two spreads tie.
/// </summary>
public static class FluidDirections {
    public static readonly BlockFace[] Horizontal = [BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX];

    /// <summary>0 for X, 1 for Y, 2 for Z.</summary>
    public static int Axis(BlockFace face) {
        return face switch {
            BlockFace.NegY or BlockFace.PosY => 1,
            BlockFace.NegZ or BlockFace.PosZ => 2,
            _ => 0
        };
    }

    /// <summary>Whether the face points along the positive direction of its axis.</summary>
    public static bool IsPositive(BlockFace face) {
        return face is BlockFace.PosY or BlockFace.PosZ or BlockFace.PosX;
    }

    public static BlockFace Opposite(BlockFace face) {
        return face switch {
            BlockFace.NegY => BlockFace.PosY,
            BlockFace.PosY => BlockFace.NegY,
            BlockFace.NegZ => BlockFace.PosZ,
            BlockFace.PosZ => BlockFace.NegZ,
            BlockFace.NegX => BlockFace.PosX,
            _ => BlockFace.NegX
        };
    }

    public static Vec3<int> Relative(Vec3<int> pos, BlockFace face) => pos.GetBlockTowards(face);

    public static Vec3<int> Below(Vec3<int> pos) => pos.WithY(pos.Y - 1);

    public static Vec3<int> Above(Vec3<int> pos) => pos.WithY(pos.Y + 1);
}
