namespace Minecraft.Schemas.Vec;

public readonly struct SVec3(short x, short y, short z) {
    public short X { get; init; } = x;
    public short Y { get; init; } = y;
    public short Z { get; init; } = z;
    
    // This is the default anyway.
    public static readonly SVec3 Zero = new(0, 0, 0);
    
    // ReSharper disable InconsistentNaming
    public SVec3 XXX => new(X, X, X);
    public SVec3 XXY => new(X, X, Y);
    public SVec3 XXZ => new(X, X, Z);
    public SVec3 XYX => new(X, Y, X);
    public SVec3 XYY => new(X, Y, Y);
    public SVec3 XYZ => new(X, Y, Z);
    public SVec3 XZX => new(X, Z, X);
    public SVec3 XZY => new(X, Z, Y);
    public SVec3 XZZ => new(X, Z, Z);
    public SVec3 YXX => new(Y, X, X);
    public SVec3 YXY => new(Y, X, Y);
    public SVec3 YXZ => new(Y, X, Z);
    public SVec3 YYX => new(Y, Y, X);
    public SVec3 YYY => new(Y, Y, Y);
    public SVec3 YYZ => new(Y, Y, Z);
    public SVec3 YZX => new(Y, Z, X);
    public SVec3 YZY => new(Y, Z, Y);
    public SVec3 YZZ => new(Y, Z, Z);
    public SVec3 ZXX => new(Z, X, X);
    public SVec3 ZXY => new(Z, X, Y);
    public SVec3 ZXZ => new(Z, X, Z);
    public SVec3 ZYX => new(Z, Y, X);
    public SVec3 ZYY => new(Z, Y, Y);
    public SVec3 ZYZ => new(Z, Y, Z);
    public SVec3 ZZX => new(Z, Z, X);
    public SVec3 ZZY => new(Z, Z, Y);
    public SVec3 ZZZ => new(Z, Z, Z);
    // ReSharper restore InconsistentNaming

    public double ComputeLength() {
        return Math.Sqrt(X*X + Y*Y + Z*Z);
    }

    public SVec3 Multiply(double scalar) {
        return new SVec3((short)(X * scalar), (short)(Y * scalar), (short)(Z * scalar));
    }

    /// <summary>
    /// Gets the 2-dimensional distance to another vec3.
    /// This means that the Y value is ignored.
    /// </summary>
    /// <param name="other">The other Vec3.</param>
    /// <returns>The distance between the two Vec3s.</returns>
    public double DistanceTo2D(SVec3 other) {
        return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Z - other.Z, 2));
    }
    
    public bool IsWithinRadiusOf(SVec3 other, int radius) {
        return Math.Abs(X - other.X) <= radius && Math.Abs(Z - other.Z) <= radius;
    }
    
    public double DistanceTo(SVec3 other) {
        double distanceTopDown = Math.Sqrt(Math.Pow(Math.Abs(X - other.X), 2) + Math.Pow(Math.Abs(Z - other.Z), 2));
        return Math.Sqrt(Math.Pow(distanceTopDown, 2) + Math.Pow(Math.Abs(Y - other.Y), 2));
    }

    public void Deconstruct(out short x, out short y, out short z) {
        x = X;
        y = Y;
        z = Z;
    }
    
    public override string ToString() {
        return $"{X}, {Y}, {Z}";
    }
}
