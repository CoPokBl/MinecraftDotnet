namespace Minecraft.Schemas;

public record FVec3(float X, float Y, float Z) {
    public static readonly FVec3 Zero = new FVec3(0.0f, 0.0f, 0.0f);
}