using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Shapes;

public record Aabb(Vec3<double> Position, Vec3<double> Size) : ICollisionBox {
    public Vec3<double> End => Position + Size;
    public Vec3<double>[] Corners => [
        Position, Position + new Vec3<double>(Size.X, 0, 0), Position + new Vec3<double>(0, 0, Size.Z), Position + new Vec3<double>(Size.X, 0, Size.Z),
        Position + new Vec3<double>(0, Size.Y, 0), Position + new Vec3<double>(Size.X, Size.Y, 0), Position + new Vec3<double>(0, Size.Y, Size.Z), Position + Size
    ];
    
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
        float[] endValues = ParseAabbValues(parts[1]);
        if (startValues.Length != 3 || endValues.Length != 3) {
            throw new FormatException($"Invalid AABB values: {str}");
        }
        Vec3<double> position = new(startValues[0], startValues[1], startValues[2]);
        Vec3<double> size = new(endValues[0] - startValues[0], endValues[1] - startValues[1], endValues[2] - startValues[2]);
        return new Aabb(position, size);
    }

    // looks like: N.N, N.N, N.N
    private static float[] ParseAabbValues(string str) {
        string[] parts = str.Split(',');
        return parts.Select(p => float.Parse(p.Trim())).ToArray();
    }

    public bool CollidesWithAabb(Aabb other) {
        return Position.X < other.Position.X + other.Size.X &&
               Position.X + Size.X > other.Position.X &&
               Position.Y < other.Position.Y + other.Size.Y &&
               Position.Y + Size.Y > other.Position.Y &&
               Position.Z < other.Position.Z + other.Size.Z &&
               Position.Z + Size.Z > other.Position.Z;
    }

    public Aabb? CollidesWhichAabb(Aabb other) {
        return CollidesWithAabb(other) ? this : null;
    }

    public ICollisionBox Add(Vec3<double> other) {
        return this with {
            Position = Position + other
        };
    }

    public Aabb Contract(double amount) {
        return new Aabb(Position + amount, Size - amount * 2.0);
    }
}
