namespace Minecraft.Schemas.Vec;

public readonly struct IVec3(int x, int y, int z) {
    public int X { get; init; } = x;
    public int Y { get; init; } = y;
    public int Z { get; init; } = z;
    
    // This is the default anyway.
    public static readonly IVec3 Zero = new(0, 0, 0);

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

    public void Deconstruct(out int x, out int y, out int z) {
        x = X;
        y = Y;
        z = Z;
    }
}
