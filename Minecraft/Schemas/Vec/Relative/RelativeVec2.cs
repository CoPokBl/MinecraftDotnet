using System.Numerics;

namespace Minecraft.Schemas.Vec.Relative;

public record RelativeVec2<T>(RelativeCoordinate<T> X, RelativeCoordinate<T> Y) where T : INumber<T> {
    public static RelativeVec2<T> Absolute(T x, T y) => new(RelativeCoordinate<T>.Absolute(x), RelativeCoordinate<T>.Absolute(y));
    public static RelativeVec2<T> Relative(T x, T y) => new(RelativeCoordinate<T>.Relative(x), RelativeCoordinate<T>.Relative(y));
    
    public Vec2<T> GetValue(Vec2<T> origin) {
        return new Vec2<T>(
            X.GetValue(origin.X),
            Y.GetValue(origin.Y)
        );
    }
    
    public override string ToString() {
        return $"{X} {Y}";
    }
}
