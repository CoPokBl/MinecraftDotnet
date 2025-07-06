namespace Minecraft.Schemas.Vec;

public readonly struct IVec2(int x, int z) : IEquatable<IVec2> {
    public readonly int X = x;
    public readonly int Z = z;

    public bool IsWithinRadiusOf(IVec2 other, int radius) {
        return Math.Abs(X - other.X) <= radius && Math.Abs(Z - other.Z) <= radius;
    }

    public double DistanceTo(IVec2 other) {
        return Math.Sqrt(Math.Pow(Math.Abs(X - other.X), 2) + Math.Pow(Math.Abs(Z - other.Z), 2));
    }

    public bool Equals(IVec2 other) {
        return X == other.X && Z == other.Z;
    }

    public override int GetHashCode() {
        long l = (long)X | ((long)Z << 32);
        return l.GetHashCode();
    }

    public override bool Equals(object? obj) {
        return obj is IVec2 other && Equals(other);
    }

    public override string ToString() {
        return $"{X}, {Z}";
    }
}