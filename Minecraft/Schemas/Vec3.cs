namespace Minecraft.Schemas;

public record Vec3(double X, double Y, double Z) {
    public static readonly Vec3 Zero = new(0.0, 0.0, 0.0);
    
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
}