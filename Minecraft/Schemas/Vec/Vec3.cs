namespace Minecraft.Schemas.Vec;

public readonly struct Vec3(double x, double y, double z) {
    public double X { get; init; } = x;
    public double Y { get; init; } = y;
    public double Z { get; init; } = z;
    
    // This is the default anyway.
    public static readonly Vec3 Zero = new(0.0, 0.0, 0.0);
    
    // ReSharper disable InconsistentNaming
    public Vec3 XXX => new(X, X, X);
    public Vec3 XXY => new(X, X, Y);
    public Vec3 XXZ => new(X, X, Z);
    public Vec3 XYX => new(X, Y, X);
    public Vec3 XYY => new(X, Y, Y);
    public Vec3 XYZ => new(X, Y, Z);
    public Vec3 XZX => new(X, Z, X);
    public Vec3 XZY => new(X, Z, Y);
    public Vec3 XZZ => new(X, Z, Z);
    public Vec3 YXX => new(Y, X, X);
    public Vec3 YXY => new(Y, X, Y);
    public Vec3 YXZ => new(Y, X, Z);
    public Vec3 YYX => new(Y, Y, X);
    public Vec3 YYY => new(Y, Y, Y);
    public Vec3 YYZ => new(Y, Y, Z);
    public Vec3 YZX => new(Y, Z, X);
    public Vec3 YZY => new(Y, Z, Y);
    public Vec3 YZZ => new(Y, Z, Z);
    public Vec3 ZXX => new(Z, X, X);
    public Vec3 ZXY => new(Z, X, Y);
    public Vec3 ZXZ => new(Z, X, Z);
    public Vec3 ZYX => new(Z, Y, X);
    public Vec3 ZYY => new(Z, Y, Y);
    public Vec3 ZYZ => new(Z, Y, Z);
    public Vec3 ZZX => new(Z, Z, X);
    public Vec3 ZZY => new(Z, Z, Y);
    public Vec3 ZZZ => new(Z, Z, Z);
    // ReSharper restore InconsistentNaming

    public Vec3 Normalize() {
        double len = ComputeLength();
        if (len == 0) {
            return Zero;
        }
        return new Vec3(X/len, Y/len, Z/len);
    }

    public double ComputeLength() {
        return Math.Sqrt(X*X + Y*Y + Z*Z);
    }

    public Vec3 Multiply(double scalar) {
        return new Vec3(X * scalar, Y * scalar, Z * scalar);
    }

    /// <summary>
    /// Gets the 2-dimensional distance to another vec3.
    /// This means that the Y value is ignored.
    /// </summary>
    /// <param name="other">The other Vec3.</param>
    /// <returns>The distance between the two Vec3s.</returns>
    public double DistanceTo2D(Vec3 other) {
        return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Z - other.Z, 2));
    }
    
    public bool IsWithinRadiusOf(Vec3 other, int radius) {
        return Math.Abs(X - other.X) <= radius && Math.Abs(Z - other.Z) <= radius;
    }
    
    public double DistanceTo(Vec3 other) {
        double distanceTopDown = Math.Sqrt(Math.Pow(Math.Abs(X - other.X), 2) + Math.Pow(Math.Abs(Z - other.Z), 2));
        return Math.Sqrt(Math.Pow(distanceTopDown, 2) + Math.Pow(Math.Abs(Y - other.Y), 2));
    }

    public void Deconstruct(out double x, out double y, out double z) {
        x = X;
        y = Y;
        z = Z;
    }
    
    public override string ToString() {
        return $"{X}, {Y}, {Z}";
    }
}
