namespace ClientLib.Maths;

/// <summary>A double vector, vanilla's <c>Vec3</c>. Positions and velocities are doubles upstream and stay doubles here.</summary>
public readonly record struct Vec3d(double X, double Y, double Z) {
    public static readonly Vec3d Zero = new(0, 0, 0);

    public static Vec3d operator +(Vec3d a, Vec3d b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Vec3d operator -(Vec3d a, Vec3d b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    public static Vec3d operator *(Vec3d a, double s) => new(a.X * s, a.Y * s, a.Z * s);

    public Vec3d Add(double x, double y, double z) => new(X + x, Y + y, Z + z);
    public Vec3d Multiply(double x, double y, double z) => new(X * x, Y * y, Z * z);
    public double LengthSqr() => X * X + Y * Y + Z * Z;
    public double Length() => Math.Sqrt(LengthSqr());
    public double HorizontalDistanceSqr() => X * X + Z * Z;
    public double DistanceToSqr(Vec3d other) => (this - other).LengthSqr();

    /// <summary><c>Vec3.normalize</c>, which leaves anything shorter than 1e-5 as zero.</summary>
    public Vec3d Normalize() {
        double length = Math.Sqrt(X * X + Y * Y + Z * Z);
        return length < 1.0E-5F ? Zero : new Vec3d(X / length, Y / length, Z / length);
    }

    public Vec3d WithX(double x) => new(x, Y, Z);
    public Vec3d WithY(double y) => new(X, y, Z);
    public Vec3d WithZ(double z) => new(X, Y, z);

    public override string ToString() => $"({X:F3}, {Y:F3}, {Z:F3})";
}
