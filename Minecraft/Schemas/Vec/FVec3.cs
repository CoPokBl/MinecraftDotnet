namespace Minecraft.Schemas.Vec;

public readonly struct FVec3(float x, float y, float z) {
    public float X { get; init; } = x;
    public float Y { get; init; } = y;
    public float Z { get; init; } = z;
    
    // This is the default anyway.
    public static readonly FVec3 Zero = new(0.0f, 0.0f, 0.0f);
    
    // ReSharper disable InconsistentNaming
    public FVec3 XXX => new(X, X, X);
    public FVec3 XXY => new(X, X, Y);
    public FVec3 XXZ => new(X, X, Z);
    public FVec3 XYX => new(X, Y, X);
    public FVec3 XYY => new(X, Y, Y);
    public FVec3 XYZ => new(X, Y, Z);
    public FVec3 XZX => new(X, Z, X);
    public FVec3 XZY => new(X, Z, Y);
    public FVec3 XZZ => new(X, Z, Z);
    public FVec3 YXX => new(Y, X, X);
    public FVec3 YXY => new(Y, X, Y);
    public FVec3 YXZ => new(Y, X, Z);
    public FVec3 YYX => new(Y, Y, X);
    public FVec3 YYY => new(Y, Y, Y);
    public FVec3 YYZ => new(Y, Y, Z);
    public FVec3 YZX => new(Y, Z, X);
    public FVec3 YZY => new(Y, Z, Y);
    public FVec3 YZZ => new(Y, Z, Z);
    public FVec3 ZXX => new(Z, X, X);
    public FVec3 ZXY => new(Z, X, Y);
    public FVec3 ZXZ => new(Z, X, Z);
    public FVec3 ZYX => new(Z, Y, X);
    public FVec3 ZYY => new(Z, Y, Y);
    public FVec3 ZYZ => new(Z, Y, Z);
    public FVec3 ZZX => new(Z, Z, X);
    public FVec3 ZZY => new(Z, Z, Y);
    public FVec3 ZZZ => new(Z, Z, Z);
    // ReSharper restore InconsistentNaming

    public FVec3 Normalize() {
        float len = ComputeLength();
        if (len == 0) {
            return Zero;
        }
        return new FVec3(X/len, Y/len, Z/len);
    }

    public float ComputeLength() {
        return MathF.Sqrt(X*X + Y*Y + Z*Z);
    }

    public FVec3 Multiply(float scalar) {
        return new FVec3(X * scalar, Y * scalar, Z * scalar);
    }

    /// <summary>
    /// Gets the 2-dimensional distance to another vec3.
    /// This means that the Y value is ignored.
    /// </summary>
    /// <param name="other">The other Vec3.</param>
    /// <returns>The distance between the two Vec3s.</returns>
    public float DistanceTo2D(FVec3 other) {
        return MathF.Sqrt(MathF.Pow(X - other.X, 2) + MathF.Pow(Z - other.Z, 2));
    }
    
    public bool IsWithinRadiusOf(FVec3 other, int radius) {
        return Math.Abs(X - other.X) <= radius && Math.Abs(Z - other.Z) <= radius;
    }
    
    public double DistanceTo(FVec3 other) {
        double distanceTopDown = Math.Sqrt(Math.Pow(Math.Abs(X - other.X), 2) + Math.Pow(Math.Abs(Z - other.Z), 2));
        return Math.Sqrt(Math.Pow(distanceTopDown, 2) + Math.Pow(Math.Abs(Y - other.Y), 2));
    }

    public void Deconstruct(out float x, out float y, out float z) {
        x = X;
        y = Y;
        z = Z;
    }
    
    public override string ToString() {
        return $"{X}, {Y}, {Z}";
    }
}
