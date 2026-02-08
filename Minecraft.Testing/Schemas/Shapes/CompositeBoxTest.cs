using Minecraft.Schemas.Shapes;

namespace Minecraft.Testing.Schemas.Shapes;

public class CompositeBoxTest {
    
    [Test]
    public void TestCompositeBox() {
        TestCollision(true, "AABB[0.1,0.1,0.1] -> [-1,1.5,1]", "AABB[0,0,0] -> [0.5,0.5,0.5]", "AABB[0.5,0.5,0.5] -> [1.5,1.5,1.5]");
        TestCollision(false, "AABB[2.1,2.1,2.1] -> [3,3,3]", "AABB[0,0,0] -> [1,1,1]", "AABB[1.1,1.1,1.1] -> [2,2,2]");
        TestCollision(true, "AABB[26, 64, 22] -> [34.5, 69, 8.5]", "AABB[33.13243, 65, 14.23] -> [0.6, 1.8, 0.6]", "AABB[0,0,0] -> [10,10,10]");
        TestCollision(false, "AABB[50,50,50] -> [60,60,60]", "AABB[0,0,0] -> [10,10,10]", "AABB[20,20,20] -> [30,30,30]");
    }
    
    /// <summary>
    /// Checks between an Aabb and multiple Aabbs (using CompositeBox) for collision.
    /// </summary>
    /// <param name="expected">Whether they should collide.</param>
    /// <param name="targetAabb">The Aabb to check again.</param>
    /// <param name="aabbs">List of Aabbs that will make up the CompositeBox.</param>
    private static void TestCollision(bool expected, string targetAabb, params string[] aabbs) {
        Aabb a = Aabb.FromString(targetAabb);
        ICollisionBox b = ICollisionBox.ParseAabbArrayString("[" + string.Join(", ", aabbs) + "]");
        Assert.That(b.CollidesWithAabb(a), Is.EqualTo(expected));
    }
}
