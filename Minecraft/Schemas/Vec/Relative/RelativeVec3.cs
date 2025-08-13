using System.Numerics;

namespace Minecraft.Schemas.Vec.Relative;

public record RelativeVec3<T>(RelativeCoordinate<T> X, RelativeCoordinate<T> Y, RelativeCoordinate<T> Z) where T : INumber<T> {
    public static RelativeVec3<T> Absolute(T x, T y, T z) => 
        new(RelativeCoordinate<T>.Absolute(x), RelativeCoordinate<T>.Absolute(y), RelativeCoordinate<T>.Absolute(z));
    public static RelativeVec3<T> Relative(T x, T y, T z) => 
        new(RelativeCoordinate<T>.Relative(x), RelativeCoordinate<T>.Relative(y), RelativeCoordinate<T>.Relative(z));

    public Vec3<T> GetValue(Vec3<T> origin) {
        return new Vec3<T>(
            X.GetValue(origin.X),
            Y.GetValue(origin.Y),
            Z.GetValue(origin.Z)
        );
    }
    
    public override string ToString() {
        return $"{X} {Y} {Z}";
    }
}
