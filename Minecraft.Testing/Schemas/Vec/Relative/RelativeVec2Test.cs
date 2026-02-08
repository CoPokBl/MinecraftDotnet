using Minecraft.Schemas.Vec;
using Minecraft.Schemas.Vec.Relative;

namespace Minecraft.Testing.Schemas.Vec.Relative;

public class RelativeVec2Test {
    
    [Test]
    public void TestResolve() {
        RelativeVec2<int> relVec = new(
            RelativeCoordinate<int>.Relative(3),
            RelativeCoordinate<int>.Absolute(10)
        );
        Vec2<int> origin = new(5, 5);
        Vec2<int> resolved = relVec.GetValue(origin);
        Assert.That(resolved, Is.EqualTo(new Vec2<int>(8, 10)));
    }
}
