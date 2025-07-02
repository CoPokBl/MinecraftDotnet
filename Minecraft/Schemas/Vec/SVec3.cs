namespace Minecraft.Schemas.Vec;

public readonly struct SVec3(short x, short y, short z) {
    public short X { get; init; } = x;
    public short Y { get; init; } = y;
    public short Z { get; init; } = z;
    
    // This is the default anyway.
    public static readonly SVec3 Zero = new(0, 0, 0);

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

    public void Deconstruct(out short x, out short y, out short z) {
        x = X;
        y = Y;
        z = Z;
    }
}
