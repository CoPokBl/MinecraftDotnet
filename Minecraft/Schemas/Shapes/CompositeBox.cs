using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Shapes;

public record CompositeBox(params ICollisionBox[] Children) : ICollisionBox {
    public bool CollidesWithAabb(Aabb other) {
        return Children.Any(child => child.CollidesWithAabb(other));
    }

    public Aabb? CollidesWhichAabb(Aabb other) {
        return Children.Select(child => child.CollidesWhichAabb(other)).FirstOrDefault(child => child != null);
    }

    public ICollisionBox Add(Vec3 other) {
        return new CompositeBox(Children.Select(child => child.Add(other)).ToArray());
    }
}
