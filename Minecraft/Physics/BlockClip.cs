using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Physics;

/// <summary>
/// The world independent half of <c>BlockGetter.clip</c>: walking a segment through the blocks it
/// crosses, and clipping it against a block's boxes. What a block's shape is stays with the caller.
/// </summary>
public static class BlockClip {
    /// <summary>Where along the segment a shape was hit, as a fraction, and through which face.</summary>
    public readonly record struct ShapeHit(double Scale, BlockFace Face);

    private const double Epsilon = 1.0E-7;

    /// <summary>
    /// <c>BlockGetter.traverseBlocks</c>, the walk that visits every block the segment crosses in the
    /// order it crosses them, so the first shape that answers is the nearest one.
    /// </summary>
    public static T? TraverseBlocks<T>(Vec3<double> from, Vec3<double> to, Func<Vec3<int>, T?> visit) where T : struct {
        if (from == to) {
            return null;
        }

        // Both ends are pulled a hair inwards, which is what keeps a ray starting or ending exactly on a
        // block boundary out of the block it only touches.
        double toX = Lerp(-Epsilon, to.X, from.X);
        double toY = Lerp(-Epsilon, to.Y, from.Y);
        double toZ = Lerp(-Epsilon, to.Z, from.Z);
        double fromX = Lerp(-Epsilon, from.X, to.X);
        double fromY = Lerp(-Epsilon, from.Y, to.Y);
        double fromZ = Lerp(-Epsilon, from.Z, to.Z);

        int x = (int)Math.Floor(fromX), y = (int)Math.Floor(fromY), z = (int)Math.Floor(fromZ);

        T? first = visit(new Vec3<int>(x, y, z));
        if (first != null) {
            return first;
        }

        double dx = toX - fromX, dy = toY - fromY, dz = toZ - fromZ;
        int signX = Math.Sign(dx), signY = Math.Sign(dy), signZ = Math.Sign(dz);

        double deltaX = signX == 0 ? double.MaxValue : signX / dx;
        double deltaY = signY == 0 ? double.MaxValue : signY / dy;
        double deltaZ = signZ == 0 ? double.MaxValue : signZ / dz;

        double tX = deltaX * (signX > 0 ? 1.0 - Frac(fromX) : Frac(fromX));
        double tY = deltaY * (signY > 0 ? 1.0 - Frac(fromY) : Frac(fromY));
        double tZ = deltaZ * (signZ > 0 ? 1.0 - Frac(fromZ) : Frac(fromZ));

        while (tX <= 1.0 || tY <= 1.0 || tZ <= 1.0) {
            if (tX < tY) {
                if (tX < tZ) {
                    x += signX;
                    tX += deltaX;
                }
                else {
                    z += signZ;
                    tZ += deltaZ;
                }
            }
            else if (tY < tZ) {
                y += signY;
                tY += deltaY;
            }
            else {
                z += signZ;
                tZ += deltaZ;
            }

            T? hit = visit(new Vec3<int>(x, y, z));
            if (hit != null) {
                return hit;
            }
        }

        return null;
    }

    /// <summary>
    /// <c>VoxelShape.clip</c>. A ray that starts inside the shape hits it at once, through the face it
    /// is most nearly travelling away from, which is what stops a bucket used inside a block from
    /// reaching through it.
    /// </summary>
    /// <param name="boxes">The shape as <c>VoxelShape.toAabbs</c> gives it, block local and unsplit.</param>
    public static ShapeHit? ClipShape(Box[] boxes, Vec3<int> pos, Vec3<double> from, Vec3<double> to) {
        if (boxes.Length == 0) {
            return null;
        }

        double dx = to.X - from.X, dy = to.Y - from.Y, dz = to.Z - from.Z;
        if (dx * dx + dy * dy + dz * dz < Epsilon) {
            return null;
        }

        double testX = from.X + dx * 0.001 - pos.X;
        double testY = from.Y + dy * 0.001 - pos.Y;
        double testZ = from.Z + dz * 0.001 - pos.Z;

        foreach (Box box in boxes) {
            // Vanilla asks the voxel grid whether the cell holding the point is filled, so a point on a
            // box's far boundary belongs to the next cell along rather than to this box.
            if (testX >= box.MinX && testX < box.MaxX &&
                testY >= box.MinY && testY < box.MaxY &&
                testZ >= box.MinZ && testZ < box.MaxZ) {
                return new ShapeHit(0.001, Opposite(ApproximateNearest(dx, dy, dz)));
            }
        }

        return ClipBoxes(boxes, pos, from, dx, dy, dz);
    }

    /// <summary>
    /// <c>AABB.clip</c> for one box in world coordinates. Unlike <see cref="ClipShape"/> a ray starting
    /// inside misses, which is why entity picking tests containment separately.
    /// </summary>
    public static ShapeHit? ClipAabb(Box box, Vec3<double> from, Vec3<double> to) {
        return ClipBoxes([box], new Vec3<int>(0, 0, 0), from, to.X - from.X, to.Y - from.Y, to.Z - from.Z);
    }

    /// <summary><c>AABB.clip</c>: the nearest face any of the boxes offers, sharing one running scale.</summary>
    private static ShapeHit? ClipBoxes(Box[] boxes, Vec3<int> pos, Vec3<double> from, double dx, double dy, double dz) {
        double scale = 1.0;
        BlockFace? face = null;

        foreach (Box box in boxes) {
            double minX = box.MinX + pos.X, minY = box.MinY + pos.Y, minZ = box.MinZ + pos.Z;
            double maxX = box.MaxX + pos.X, maxY = box.MaxY + pos.Y, maxZ = box.MaxZ + pos.Z;

            if (dx > Epsilon) {
                face = ClipPoint(ref scale, face, dx, dy, dz, minX, minY, maxY, minZ, maxZ, BlockFace.NegX, from.X, from.Y, from.Z);
            }
            else if (dx < -Epsilon) {
                face = ClipPoint(ref scale, face, dx, dy, dz, maxX, minY, maxY, minZ, maxZ, BlockFace.PosX, from.X, from.Y, from.Z);
            }

            if (dy > Epsilon) {
                face = ClipPoint(ref scale, face, dy, dz, dx, minY, minZ, maxZ, minX, maxX, BlockFace.NegY, from.Y, from.Z, from.X);
            }
            else if (dy < -Epsilon) {
                face = ClipPoint(ref scale, face, dy, dz, dx, maxY, minZ, maxZ, minX, maxX, BlockFace.PosY, from.Y, from.Z, from.X);
            }

            if (dz > Epsilon) {
                face = ClipPoint(ref scale, face, dz, dx, dy, minZ, minX, maxX, minY, maxY, BlockFace.NegZ, from.Z, from.X, from.Y);
            }
            else if (dz < -Epsilon) {
                face = ClipPoint(ref scale, face, dz, dx, dy, maxZ, minX, maxX, minY, maxY, BlockFace.PosZ, from.Z, from.X, from.Y);
            }
        }

        return face == null ? null : new ShapeHit(scale, face.Value);
    }

    /// <summary>
    /// <c>AABB.clipPoint</c>: where the ray meets one plane of a box, kept only when it lands inside the
    /// face and nearer than anything found so far.
    /// </summary>
    private static BlockFace? ClipPoint(ref double scale, BlockFace? face, double da, double db, double dc,
        double point, double minB, double maxB, double minC, double maxC, BlockFace newFace,
        double fromA, double fromB, double fromC) {

        double s = (point - fromA) / da;
        double b = fromB + s * db;
        double c = fromC + s * dc;

        if (0.0 < s && s < scale &&
            minB - Epsilon < b && b < maxB + Epsilon &&
            minC - Epsilon < c && c < maxC + Epsilon) {
            scale = s;
            return newFace;
        }

        return face;
    }

    /// <summary><c>Direction.getApproximateNearest</c>, in vanilla's declaration order so ties match.</summary>
    public static BlockFace ApproximateNearest(double dx, double dy, double dz) {
        BlockFace result = BlockFace.NegZ;
        float highest = float.MinValue;

        foreach ((BlockFace face, int nx, int ny, int nz) in Normals) {
            float dot = (float)dx * nx + (float)dy * ny + (float)dz * nz;
            if (dot > highest) {
                highest = dot;
                result = face;
            }
        }

        return result;
    }

    /// <summary><c>Direction.VALUES</c>, which is declaration order: down, up, north, south, west, east.</summary>
    private static readonly (BlockFace Face, int X, int Y, int Z)[] Normals = [
        (BlockFace.NegY, 0, -1, 0),
        (BlockFace.PosY, 0, 1, 0),
        (BlockFace.NegZ, 0, 0, -1),
        (BlockFace.PosZ, 0, 0, 1),
        (BlockFace.NegX, -1, 0, 0),
        (BlockFace.PosX, 1, 0, 0)
    ];

    /// <summary>The face on the other side: the enum pairs them, so flipping the low bit is enough.</summary>
    public static BlockFace Opposite(BlockFace face) => (BlockFace)((int)face ^ 1);

    /// <summary><c>Mth.lerp</c>.</summary>
    private static double Lerp(double delta, double start, double end) => start + delta * (end - start);

    /// <summary><c>Mth.frac</c>.</summary>
    private static double Frac(double value) => value - Math.Floor(value);
}
