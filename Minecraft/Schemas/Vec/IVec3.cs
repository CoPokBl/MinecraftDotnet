namespace Minecraft.Schemas.Vec;

public readonly struct IVec3(int x, int y, int z) : IEquatable<IVec3> {
    public int X { get; init; } = x;
    public int Y { get; init; } = y;
    public int Z { get; init; } = z;
    
    // This is the default anyway.
    public static readonly IVec3 Zero = new(0, 0, 0);

    public static implicit operator Vec3(IVec3 vec) {
        return new Vec3(vec.X, vec.Y, vec.Z);
    }
    
#region combined_params
// ReSharper disable InconsistentNaming
    public IVec3 XXX => new(X, X, X);
    public IVec3 XXY => new(X, X, Y);
    public IVec3 XXZ => new(X, X, Z);
    public IVec3 XYX => new(X, Y, X);
    public IVec3 XYY => new(X, Y, Y);
    public IVec3 XYZ => new(X, Y, Z);
    public IVec3 XZX => new(X, Z, X);
    public IVec3 XZY => new(X, Z, Y);
    public IVec3 XZZ => new(X, Z, Z);
    public IVec3 YXX => new(Y, X, X);
    public IVec3 YXY => new(Y, X, Y);
    public IVec3 YXZ => new(Y, X, Z);
    public IVec3 YYX => new(Y, Y, X);
    public IVec3 YYY => new(Y, Y, Y);
    public IVec3 YYZ => new(Y, Y, Z);
    public IVec3 YZX => new(Y, Z, X);
    public IVec3 YZY => new(Y, Z, Y);
    public IVec3 YZZ => new(Y, Z, Z);
    public IVec3 ZXX => new(Z, X, X);
    public IVec3 ZXY => new(Z, X, Y);
    public IVec3 ZXZ => new(Z, X, Z);
    public IVec3 ZYX => new(Z, Y, X);
    public IVec3 ZYY => new(Z, Y, Y);
    public IVec3 ZYZ => new(Z, Y, Z);
    public IVec3 ZZX => new(Z, Z, X);
    public IVec3 ZZY => new(Z, Z, Y);
    public IVec3 ZZZ => new(Z, Z, Z);
    public IVec2 XY => new(X, Y);
    public IVec2 XZ => new(X, Z);
    public IVec2 YZ => new(Y, Z);
    public IVec2 YX => new(Y, X);
    public IVec2 ZX => new(Z, X);
    public IVec2 ZY => new(Z, Y);
    public IVec2 ZZ => new(Z, Z);
    public IVec2 XX => new(X, X);
    public IVec2 YY => new(Y, Y);
// ReSharper restore InconsistentNaming
#endregion


    public double ComputeLength() {
        return Math.Sqrt(X*X + Y*Y + Z*Z);
    }

    public IVec3 Multiply(double scalar) {
        return new IVec3((int)(X * scalar), (int)(Y * scalar), (int)(Z * scalar));
    }

    /// <summary>
    /// Gets the 2-dimensional distance to another vec3.
    /// This means that the Y value is ignored.
    /// </summary>
    /// <param name="other">The other Vec3.</param>
    /// <returns>The distance between the two Vec3s.</returns>
    public double DistanceTo2D(IVec3 other) {
        return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Z - other.Z, 2));
    }
    
    public bool IsWithinRadiusOf(IVec3 other, int radius) {
        return Math.Abs(X - other.X) <= radius && Math.Abs(Z - other.Z) <= radius;
    }
    
    public double DistanceTo(IVec3 other) {
        double distanceTopDown = Math.Sqrt(Math.Pow(Math.Abs(X - other.X), 2) + Math.Pow(Math.Abs(Z - other.Z), 2));
        return Math.Sqrt(Math.Pow(distanceTopDown, 2) + Math.Pow(Math.Abs(Y - other.Y), 2));
    }
    
    public IVec3 GetBlockTowards(BlockFace face) {
        return face switch {
            BlockFace.NegY => new IVec3(X, Y - 1, Z),
            BlockFace.PosY => new IVec3(X, Y + 1, Z),
            BlockFace.NegZ => new IVec3(X, Y, Z - 1),
            BlockFace.PosZ => new IVec3(X, Y, Z + 1),
            BlockFace.NegX => new IVec3(X - 1, Y, Z),
            BlockFace.PosX => new IVec3(X + 1, Y, Z),
            _ => throw new ArgumentOutOfRangeException(nameof(face), face, null)
        };
    }
    
    public Vec3 BlockPositionToVec3() {
        return new Vec3(X + 0.5, Y + 0.5, Z + 0.5);
    }

    public void Deconstruct(out int x, out int y, out int z) {
        x = X;
        y = Y;
        z = Z;
    }

    public override string ToString() {
        return $"{X}, {Y}, {Z}";
    }

    public bool Equals(IVec3 other) {
        return X == other.X && Y == other.Y && Z == other.Z;
    }

    public override bool Equals(object? obj) {
        return obj is IVec3 other && Equals(other);
    }

    public override int GetHashCode() {
        return HashCode.Combine(X, Y, Z);
    }

    public static bool operator ==(IVec3 left, IVec3 right) {
        return left.Equals(right);
    }

    public static bool operator !=(IVec3 left, IVec3 right) {
        return !(left == right);
    }
}
