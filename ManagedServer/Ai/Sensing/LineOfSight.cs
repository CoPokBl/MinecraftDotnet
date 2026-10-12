using ManagedServer.Entities.Types;
using Minecraft.Physics;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Ai.Sensing;

/// <summary>
/// <c>LivingEntity.hasLineOfSight</c>: whether a straight segment between two eyes reaches without
/// meeting a block. Vanilla answers it with <c>BlockGetter.clip</c> under
/// <c>ClipContext.Block.COLLIDER</c> and asks whether the result missed, so it is the
/// <b>collision</b> shape that blocks sight, not the outline: a mob can see a player through a torch
/// or a sign and not through glass.
/// <p/>
/// This is a separate traversal from <see cref="Fluids.FluidRaycast"/>, which reads the outline shape
/// and returns which face was struck. Everything here needs is whether anything was struck at all,
/// which is the cheaper half of the same walk.
/// </summary>
public static class LineOfSight {
    private const double Epsilon = 1.0E-7;

    /// <summary>Vanilla gives up past this rather than walking a long ray, which caps the cost.</summary>
    private const double MaxDistance = 128.0;

    public static bool Between(LivingEntity from, Entity to) {
        if (from.World == null || from.World != to.World) {
            return false;
        }

        // Vanilla measures from the looker's feet-x/z at eye height, and to the target's eye position.
        Vec3<double> start = from.Position.WithY(from.Position.Y + from.Type.EyeHeight);
        Vec3<double> end = to.Position.WithY(to.Position.Y + to.Type.EyeHeight);

        if (SquaredDistance(start, end) > MaxDistance * MaxDistance) {
            return false;
        }

        return !Blocked(from.World, start, end);
    }

    /// <summary>
    /// <c>BlockGetter.traverseBlocks</c> reduced to a yes or no. The two ends are pulled a hair inwards
    /// the way vanilla's are, which is what keeps a ray that starts exactly on a block boundary out of
    /// the block it only touches.
    /// </summary>
    public static bool Blocked(World world, Vec3<double> from, Vec3<double> to) {
        if (from == to) {
            return false;
        }

        double toX = Lerp(-Epsilon, to.X, from.X);
        double toY = Lerp(-Epsilon, to.Y, from.Y);
        double toZ = Lerp(-Epsilon, to.Z, from.Z);
        double fromX = Lerp(-Epsilon, from.X, to.X);
        double fromY = Lerp(-Epsilon, from.Y, to.Y);
        double fromZ = Lerp(-Epsilon, from.Z, to.Z);

        int x = (int)Math.Floor(fromX), y = (int)Math.Floor(fromY), z = (int)Math.Floor(fromZ);

        Vec3<double> start = new(fromX, fromY, fromZ);
        Vec3<double> end = new(toX, toY, toZ);

        if (BlocksAt(world, new Vec3<int>(x, y, z), start, end)) {
            return true;
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

            if (BlocksAt(world, new Vec3<int>(x, y, z), start, end)) {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Whether the segment meets any of a block's collision boxes. The <b>unsplit</b> boxes, because
    /// <c>VoxelShape.clip</c> iterates <c>toAabbs</c>, which merges the grid split ones back; splitting
    /// them would only cost time, not change the answer.
    /// </summary>
    private static bool BlocksAt(World world, Vec3<int> pos, Vec3<double> from, Vec3<double> to) {
        IBlock block = world.GetBlockOr(pos, Block.Air);
        if (block.StateId == Block.Air.StateId) {
            return false;
        }

        foreach (Box box in BlockPhysicsData.ShapeBoxesOf(block.CollisionShape)) {
            if (Clips(box.Translate(pos.X, pos.Y, pos.Z), from, to)) {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// The slab test <c>AABB.clip</c> performs, reduced to whether the segment enters the box at all.
    /// Segment parameters outside [0, 1] are misses, which is what stops a box behind the eye or past
    /// the target counting.
    /// </summary>
    private static bool Clips(Box box, Vec3<double> from, Vec3<double> to) {
        double enter = 0.0;
        double exit = 1.0;

        return Slab(from.X, to.X - from.X, box.MinX, box.MaxX, ref enter, ref exit)
               && Slab(from.Y, to.Y - from.Y, box.MinY, box.MaxY, ref enter, ref exit)
               && Slab(from.Z, to.Z - from.Z, box.MinZ, box.MaxZ, ref enter, ref exit);
    }

    private static bool Slab(double origin, double direction, double min, double max,
        ref double enter, ref double exit) {
        if (Math.Abs(direction) < Epsilon) {
            return origin >= min && origin <= max;
        }

        double near = (min - origin) / direction;
        double far = (max - origin) / direction;
        if (near > far) {
            (near, far) = (far, near);
        }

        enter = Math.Max(enter, near);
        exit = Math.Min(exit, far);
        return enter <= exit;
    }

    private static double Lerp(double delta, double start, double end) {
        return start + delta * (end - start);
    }

    private static double Frac(double value) {
        return value - Math.Floor(value);
    }

    private static double SquaredDistance(Vec3<double> a, Vec3<double> b) {
        double dx = a.X - b.X;
        double dy = a.Y - b.Y;
        double dz = a.Z - b.Z;
        return dx * dx + dy * dy + dz * dz;
    }
}
