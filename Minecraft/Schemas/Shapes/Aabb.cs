using System.Globalization;
using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Shapes;

public record Aabb(Vec3<double> Position, Vec3<double> Size) : ICollisionBox {
    private static readonly NumberFormatInfo NumberFormat = new() {
        NumberDecimalSeparator = "."
    };
    
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
        return parts.Select(p => float.Parse(p.Trim(), NumberFormat)).ToArray();
    }

    public bool CollidesWithAabb(Aabb other) {
        double thisMinX = Math.Min(Position.X, Position.X + Size.X);
        double thisMaxX = Math.Max(Position.X, Position.X + Size.X);
        double otherMinX = Math.Min(other.Position.X, other.Position.X + other.Size.X);
        double otherMaxX = Math.Max(other.Position.X, other.Position.X + other.Size.X);
        if (thisMaxX < otherMinX || thisMinX > otherMaxX) return false;

        double thisMinY = Math.Min(Position.Y, Position.Y + Size.Y);
        double thisMaxY = Math.Max(Position.Y, Position.Y + Size.Y);
        double otherMinY = Math.Min(other.Position.Y, other.Position.Y + other.Size.Y);
        double otherMaxY = Math.Max(other.Position.Y, other.Position.Y + other.Size.Y);
        if (thisMaxY < otherMinY || thisMinY > otherMaxY) return false;

        double thisMinZ = Math.Min(Position.Z, Position.Z + Size.Z);
        double thisMaxZ = Math.Max(Position.Z, Position.Z + Size.Z);
        double otherMinZ = Math.Min(other.Position.Z, other.Position.Z + other.Size.Z);
        double otherMaxZ = Math.Max(other.Position.Z, other.Position.Z + other.Size.Z);
        if (thisMaxZ < otherMinZ || thisMinZ > otherMaxZ) return false;
        return true;
    }

    public bool CollidesWithRaycast(Vec3<double> origin, Vec3<double> end) {
        Vec3<double> direction = end - origin;
        
        double minX = Math.Min(Position.X, Position.X + Size.X);
        double maxX = Math.Max(Position.X, Position.X + Size.X);
        double minY = Math.Min(Position.Y, Position.Y + Size.Y);
        double maxY = Math.Max(Position.Y, Position.Y + Size.Y);
        double minZ = Math.Min(Position.Z, Position.Z + Size.Z);
        double maxZ = Math.Max(Position.Z, Position.Z + Size.Z);

        double tMin = 0.0;
        double tMax = 1.0;

        if (!IntersectsAxis(origin.X, direction.X, minX, maxX, ref tMin, ref tMax)) {
            return false;
        }
        if (!IntersectsAxis(origin.Y, direction.Y, minY, maxY, ref tMin, ref tMax)) {
            return false;
        }
        return IntersectsAxis(origin.Z, direction.Z, minZ, maxZ, ref tMin, ref tMax);
    }

    private static bool IntersectsAxis(double origin, double direction, double min, double max, ref double tMin, ref double tMax) {
        const double epsilon = 1e-9;
        if (Math.Abs(direction) < epsilon) {
            return origin >= min && origin <= max;
        }
        
        double t1 = (min - origin) / direction;
        double t2 = (max - origin) / direction;
        if (t1 > t2) {
            (t1, t2) = (t2, t1);
        }
        
        tMin = Math.Max(tMin, t1);
        tMax = Math.Min(tMax, t2);
        return tMin <= tMax;
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
