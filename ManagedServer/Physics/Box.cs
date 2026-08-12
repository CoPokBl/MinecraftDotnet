using Minecraft.Schemas.Shapes;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Physics;

/// <summary>
/// An axis aligned box in min/max form, which is how vanilla stores them and what the sweep maths
/// below wants. <see cref="Aabb"/> is a record (so a heap allocation per box) held as position plus
/// size, and the physics loop builds thousands of these per tick, so it works in this instead and
/// converts at the edges.
/// </summary>
public readonly struct Box(double minX, double minY, double minZ, double maxX, double maxY, double maxZ) {
    public readonly double MinX = minX;
    public readonly double MinY = minY;
    public readonly double MinZ = minZ;
    public readonly double MaxX = maxX;
    public readonly double MaxY = maxY;
    public readonly double MaxZ = maxZ;

    public Box(Aabb aabb) : this(
        aabb.Position.X, aabb.Position.Y, aabb.Position.Z,
        aabb.Position.X + aabb.Size.X, aabb.Position.Y + aabb.Size.Y, aabb.Position.Z + aabb.Size.Z) { }

    public double Min(int axis) => axis switch {
        0 => MinX,
        1 => MinY,
        _ => MinZ
    };

    public double Max(int axis) => axis switch {
        0 => MaxX,
        1 => MaxY,
        _ => MaxZ
    };

    public Box Translate(double x, double y, double z) {
        return new Box(MinX + x, MinY + y, MinZ + z, MaxX + x, MaxY + y, MaxZ + z);
    }

    public Box Translate(Vec3<double> by) => Translate(by.X, by.Y, by.Z);

    /// <summary>
    /// Grows the box in the direction of a movement so that it covers everywhere the box passes
    /// through. Vanilla's <c>AABB.expandTowards</c>.
    /// </summary>
    public Box ExpandTowards(double x, double y, double z) {
        return new Box(
            MinX + Math.Min(x, 0), MinY + Math.Min(y, 0), MinZ + Math.Min(z, 0),
            MaxX + Math.Max(x, 0), MaxY + Math.Max(y, 0), MaxZ + Math.Max(z, 0));
    }

    public Box ExpandTowards(Vec3<double> by) => ExpandTowards(by.X, by.Y, by.Z);

    /// <summary>
    /// Vanilla's <c>AABB.intersects</c>: strict on every axis, so boxes that merely touch do not
    /// count as intersecting.
    /// </summary>
    public bool Intersects(Box other) {
        return MinX < other.MaxX && MaxX > other.MinX &&
               MinY < other.MaxY && MaxY > other.MinY &&
               MinZ < other.MaxZ && MaxZ > other.MinZ;
    }

    public Aabb ToAabb() {
        return new Aabb(new Vec3<double>(MinX, MinY, MinZ), new Vec3<double>(MaxX - MinX, MaxY - MinY, MaxZ - MinZ));
    }
}
