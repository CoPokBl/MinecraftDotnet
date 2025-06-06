namespace Minecraft.Schemas;

public readonly struct BlockPosition(int x, int y, int z) : IEquatable<BlockPosition> {
    public readonly int X = x;
    public readonly int Y = y;
    public readonly int Z = z;

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
}