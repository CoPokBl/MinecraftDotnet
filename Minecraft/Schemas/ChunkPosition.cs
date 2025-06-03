namespace Minecraft.Schemas;

public readonly struct ChunkPosition(int x, int z) : IEquatable<ChunkPosition> {
    public readonly int X = x;
    public readonly int Z = z;

    public bool IsWithinRadiusOf(ChunkPosition other, int radius) {
        return Math.Abs(X - other.X) <= radius && Math.Abs(Z - other.Z) <= radius;
    }

    public bool Equals(ChunkPosition other) {
        return X == other.X && Z == other.Z;
    }

    public override int GetHashCode() {
        long l = (long)X | ((long)Z << 32);
        return l.GetHashCode();
    }

    public override bool Equals(object? obj) {
        return obj is ChunkPosition other && Equals(other);
    }
}