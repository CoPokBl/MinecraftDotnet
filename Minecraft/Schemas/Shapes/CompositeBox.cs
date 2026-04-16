using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Shapes;

public record CompositeBox(params ICollisionBox[] Children) : ICollisionBox {
    public bool CollidesWithAabb(Aabb other) {
        return Children.Any(child => child.CollidesWithAabb(other));
    }

    public Aabb? CollidesWhichAabb(Aabb other) {
        return Children.Select(child => child.CollidesWhichAabb(other)).FirstOrDefault(child => child != null);
    }

    public bool CollidesWithRaycast(Vec3<double> origin, Vec3<double> end) {
        return Children.Any(child => child.CollidesWithRaycast(origin, end));
    }
    
    public ICollisionBox Add(Vec3<double> other) {
        return new CompositeBox(Children.Select(child => child.Add(other)).ToArray());
    }
}
