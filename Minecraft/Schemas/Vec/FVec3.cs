namespace Minecraft.Schemas.Vec;

public readonly struct FVec3(float x, float y, float z) {
    public float X { get; init; } = x;
    public float Y { get; init; } = y;
    public float Z { get; init; } = z;
    
    // This is the default anyway.
    public static readonly FVec3 Zero = new(0.0f, 0.0f, 0.0f);

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

    public void Deconstruct(out float x, out float y, out float z) {
        x = X;
        y = Y;
        z = Z;
    }
    
    public override string ToString() {
        return $"{X}, {Y}, {Z}";
    }
}
