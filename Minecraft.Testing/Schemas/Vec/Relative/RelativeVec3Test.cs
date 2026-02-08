using Minecraft.Schemas.Vec;
using Minecraft.Schemas.Vec.Relative;

namespace Minecraft.Testing.Schemas.Vec.Relative;

public class RelativeVec3Test {
    
    [Test]
    public void TestResolve() {
        RelativeVec3<int> relVec = new(
            RelativeCoordinate<int>.Relative(3),
            RelativeCoordinate<int>.Absolute(10),
            RelativeCoordinate<int>.Relative(-2)
        );
        Vec3<int> origin = new(5, 5, 5);
        Vec3<int> resolved = relVec.GetValue(origin);
        Assert.That(resolved, Is.EqualTo(new Vec3<int>(8, 10, 3)));
    }
}
