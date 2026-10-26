using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>BoundingBox</c>: an inclusive box of block positions, which is how every structure piece says
/// where it is.
/// </summary>
/// <remarks>
/// <b>Mutable, as vanilla's is.</b> <see cref="Move"/> and <see cref="Encapsulate"/> change the box in
/// place and the whole piece layer depends on it: <c>StructurePiece.move</c> shifts a piece by moving
/// the box it already handed to its parent, and a builder that has offset every piece vertically has
/// not rebuilt anything. Making this a record would leave those callers silently shifting a copy.
/// <p/>
/// Both bounds are <b>inclusive</b>, so a one block box has equal minimum and maximum and a span of one.
/// </remarks>
public sealed class BoundingBox {
    public BoundingBox(int minX, int minY, int minZ, int maxX, int maxY, int maxZ) {
        MinX = minX;
        MinY = minY;
        MinZ = minZ;
        MaxX = maxX;
        MaxY = maxY;
        MaxZ = maxZ;
    }

    /// <summary>The single block at a position.</summary>
    public BoundingBox(int x, int y, int z) : this(x, y, z, x, y, z) { }

    public int MinX { get; private set; }
    public int MinY { get; private set; }
    public int MinZ { get; private set; }
    public int MaxX { get; private set; }
    public int MaxY { get; private set; }
    public int MaxZ { get; private set; }

    public int XSpan => MaxX - MinX + 1;
    public int YSpan => MaxY - MinY + 1;
    public int ZSpan => MaxZ - MinZ + 1;

    /// <summary>
    /// A box from a corner, an offset, a size and a facing, vanilla's <c>orientBox</c>.
    /// </summary>
    /// <remarks>
    /// The width runs along the direction's left to right and the depth along the direction itself, so
    /// the same arguments describe the same room whichever way a corridor turned to reach it. On the two
    /// x facing directions the offsets swap with it: <c>offX</c> moves along z and <c>offZ</c> along x.
    /// </remarks>
    public static BoundingBox Orient(int footX, int footY, int footZ, int offX, int offY, int offZ,
        int width, int height, int depth, Direction direction) {

        return direction switch {
            Direction.North => new BoundingBox(footX + offX, footY + offY, footZ - depth + 1 + offZ,
                footX + width - 1 + offX, footY + height - 1 + offY, footZ + offZ),

            Direction.West => new BoundingBox(footX - depth + 1 + offZ, footY + offY, footZ + offX,
                footX + offZ, footY + height - 1 + offY, footZ + width - 1 + offX),

            Direction.East => new BoundingBox(footX + offZ, footY + offY, footZ + offX,
                footX + depth - 1 + offZ, footY + height - 1 + offY, footZ + width - 1 + offX),

            _ => new BoundingBox(footX + offX, footY + offY, footZ + offZ, footX + width - 1 + offX,
                footY + height - 1 + offY, footZ + depth - 1 + offZ)
        };
    }

    /// <summary>The smallest box holding every box given, or null for none.</summary>
    public static BoundingBox? Encapsulating(IEnumerable<BoundingBox> boxes) {
        BoundingBox? result = null;

        foreach (BoundingBox box in boxes) {
            result ??= new BoundingBox(box.MinX, box.MinY, box.MinZ, box.MaxX, box.MaxY, box.MaxZ);
            result.Encapsulate(box);
        }

        return result;
    }

    public bool Intersects(BoundingBox other) {
        return MaxX >= other.MinX && MinX <= other.MaxX
            && MaxZ >= other.MinZ && MinZ <= other.MaxZ
            && MaxY >= other.MinY && MinY <= other.MaxY;
    }

    /// <summary>Whether the box overlaps a horizontal region, ignoring y.</summary>
    public bool Intersects(int minX, int minZ, int maxX, int maxZ) {
        return MaxX >= minX && MinX <= maxX && MaxZ >= minZ && MinZ <= maxZ;
    }

    public bool IsInside(int x, int y, int z) {
        return x >= MinX && x <= MaxX && z >= MinZ && z <= MaxZ && y >= MinY && y <= MaxY;
    }

    /// <summary>Grows the box to hold another, in place.</summary>
    public BoundingBox Encapsulate(BoundingBox other) {
        MinX = Math.Min(MinX, other.MinX);
        MinY = Math.Min(MinY, other.MinY);
        MinZ = Math.Min(MinZ, other.MinZ);
        MaxX = Math.Max(MaxX, other.MaxX);
        MaxY = Math.Max(MaxY, other.MaxY);
        MaxZ = Math.Max(MaxZ, other.MaxZ);
        return this;
    }

    /// <summary>Shifts the box, in place.</summary>
    public BoundingBox Move(int dx, int dy, int dz) {
        MinX += dx;
        MinY += dy;
        MinZ += dz;
        MaxX += dx;
        MaxY += dy;
        MaxZ += dz;
        return this;
    }

    /// <summary>A shifted copy, leaving this one alone.</summary>
    public BoundingBox Moved(int dx, int dy, int dz) {
        return new BoundingBox(MinX + dx, MinY + dy, MinZ + dz, MaxX + dx, MaxY + dy, MaxZ + dz);
    }

    /// <summary>A copy grown by the same amount on every side.</summary>
    public BoundingBox InflatedBy(int amount) {
        return new BoundingBox(MinX - amount, MinY - amount, MinZ - amount,
            MaxX + amount, MaxY + amount, MaxZ + amount);
    }

    /// <summary>
    /// The middle of the box, rounded up on each axis. Structure pieces measure their offsets from it,
    /// so the rounding is part of where the blocks land.
    /// </summary>
    public Vec3<int> Center => new(MinX + XSpan / 2, MinY + YSpan / 2, MinZ + ZSpan / 2);

    public override string ToString() {
        return $"[{MinX}, {MinY}, {MinZ}] -> [{MaxX}, {MaxY}, {MaxZ}]";
    }
}
