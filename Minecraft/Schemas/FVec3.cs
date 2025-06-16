namespace Minecraft.Schemas;

public record FVec3(float X, float Y, float Z) {
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
    
    public Vec3 Multiply(double scalar) {
        return new Vec3(X * scalar, Y * scalar, Z * scalar);
    }
}