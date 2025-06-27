namespace Minecraft.Schemas.Vec;

public record IVec3(double X, double Y, double Z) {
    public static readonly IVec3 Zero = new(0, 0, 0);
    
    public IVec3 Normalize() {
        double len = ComputeLength();
        if (len == 0) {
            return Zero;
        }
        return new IVec3(X/len, Y/len, Z/len);
    }

    public double ComputeLength() {
        return Math.Sqrt(X*X + Y*Y + Z*Z);
    }

    public IVec3 Multiply(double scalar) {
        return new IVec3(X * scalar, Y * scalar, Z * scalar);
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
}