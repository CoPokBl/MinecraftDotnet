using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas;

public readonly struct BlockPosition(int x, int y, int z) : IEquatable<BlockPosition> {
    public readonly int X = x;
    public readonly int Y = y;
    public readonly int Z = z;
    
    public static readonly BlockPosition Zero = new(0, 0, 0);

    public bool IsWithinRadiusOf(BlockPosition other, int radius) {
        return Math.Abs(X - other.X) <= radius && Math.Abs(Z - other.Z) <= radius;
    }

    public double DistanceTo(BlockPosition other) {
        double distanceTopDown = Math.Sqrt(Math.Pow(Math.Abs(X - other.X), 2) + Math.Pow(Math.Abs(Z - other.Z), 2));
        return Math.Sqrt(Math.Pow(distanceTopDown, 2) + Math.Pow(Math.Abs(Y - other.Y), 2));
    }

    public bool Equals(BlockPosition other) {
        return X == other.X && Z == other.Z && Y == other.Y;
    }

    public override int GetHashCode() {
        long l = (long)X | ((long)Z << 32);
        return l.GetHashCode();
    }

    public override bool Equals(object? obj) {
        return obj is ChunkPosition other && Equals(other);
    }

    public override string ToString() {
        return $"{X},{Y},{Z}";
    }

    public BlockPosition GetBlockTowards(BlockFace face) {
        return face switch {
            BlockFace.NegY => new BlockPosition(X, Y - 1, Z),
            BlockFace.PosY => new BlockPosition(X, Y + 1, Z),
            BlockFace.NegZ => new BlockPosition(X, Y, Z - 1),
            BlockFace.PosZ => new BlockPosition(X, Y, Z + 1),
            BlockFace.NegX => new BlockPosition(X - 1, Y, Z),
            BlockFace.PosX => new BlockPosition(X + 1, Y, Z),
            _ => throw new ArgumentOutOfRangeException(nameof(face), face, null)
        };
    }

    public static implicit operator Vec3(BlockPosition pos) => new(pos.X + 0.5, pos.Y + 0.5, pos.Z + 0.5);

    public static bool operator ==(BlockPosition left, BlockPosition right) {
        return left.Equals(right);
    }

    public static bool operator !=(BlockPosition left, BlockPosition right) {
        return !(left == right);
    }
}