namespace Minecraft.Schemas;

public record Vec3(double X, double Y, double Z) {
    public static readonly Vec3 Zero = new Vec3(0.0, 0.0, 0.0);
}