using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Shapes;

public record Aabb(Vec3 Position, Vec3 Size) : ICollisionBox {

    public static Aabb FromString(string str) {
        str = str.Trim();
        
        // looks like: "AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]"
        
        if (!str.StartsWith("AABB[") || !str.EndsWith("]")) {
            throw new FormatException($"Invalid AABB format: {str}");
        }
        
        str = str[5..^1]; // Remove "AABB[" from start and "]" from end
        string[] parts = str.Split("] -> [");
        if (parts.Length != 2) {
            throw new FormatException($"Invalid AABB format: {str}");
        }
        float[] startValues = ParseAabbValues(parts[0]);
        float[] endValues = ParseAabbValues(parts[1][..^1]);
        if (startValues.Length != 3 || endValues.Length != 3) {
            throw new FormatException($"Invalid AABB values: {str}");
        }
        Vec3 position = new(startValues[0], startValues[1], startValues[2]);
        Vec3 size = new(endValues[0] - startValues[0], endValues[1] - startValues[1], endValues[2] - startValues[2]);
        return new Aabb(position, size);
    }

    // looks like: N.N, N.N, N.N
    private static float[] ParseAabbValues(string str) {
        string[] parts = str.Split(',');
        return parts.Select(p => float.Parse(p.Trim())).ToArray();
    }
}
