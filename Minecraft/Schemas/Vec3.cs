namespace Minecraft.Schemas;

public record Vec3(double X, double Y, double Z) {
    public static readonly Vec3 Zero = new(0.0, 0.0, 0.0);

    public Vec3 Multiply(double scalar) {
        return new Vec3(X * scalar, Y * scalar, Z * scalar);
    }
}