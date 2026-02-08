using Minecraft.Schemas.Shapes;

namespace Minecraft.Testing.Schemas.Shapes;

public class CollisionTest {

    [Test]
    public void TestAabb() {
        TestCollision("AABB[0.1,0.1,0.1] -> [-1,1.5,1]", "AABB[0,0,0] -> [1,1,1]");
        TestCollision("AABB[0.5,0.5,0.5] -> [1.5,1.5,1.5]", "AABB[0,0,0] -> [1,1,1]");
        TestCollision("AABB[26, 64, 22] -> [34.5, 69, 8.5]", "AABB[33.13243, 65, 14.23] -> [0.6, 1.8, 0.6]");
        TestCollision("AABB[0,0,0] -> [1,1,1]", "AABB[2,2,2] -> [3,3,3]", false);
        TestCollision("AABB[0,0,0] -> [1,1,1]", "AABB[0.5,0.5,0.5] -> [1.5,1.5,1.5]");
    }
    
    private static void TestCollision(string aabb1, string aabb2, bool expected = true) {
        Aabb a = Aabb.FromString(aabb1);
        Aabb b = Aabb.FromString(aabb2);
        Assert.That(a.CollidesWithAabb(b), Is.EqualTo(expected));
        Assert.That(b.CollidesWithAabb(a), Is.EqualTo(expected));
    }
}
