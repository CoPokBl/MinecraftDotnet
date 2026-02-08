using Minecraft.Schemas.Vec;

namespace Minecraft.Testing.Schemas.Vec;

public class Vec2Test {
    
    [Test]
    public void TestIsWithinRadiusOf() {
        Vec2<int> vecA = new(5, 5);
        Vec2<int> vecB = new(7, 7);
        Vec2<int> vecC = new(10, 10);
        
        Assert.That(vecA.IsWithinRadiusOf(vecB, 2), Is.True);
        Assert.That(vecA.IsWithinRadiusOf(vecC, 2), Is.False);
    }

    [Test]
    public void TestDistanceTo() {
        Vec2<int> vecA = new(0, 0);
        Vec2<int> vecB = new(3, 4);
        double distance = vecA.DistanceTo(vecB);
        Assert.That(distance, Is.EqualTo(5.0).Within(0.0001));
    }
    
    // BASIC OPS
    
    [Test]
    public void TestAddition() {
        Vec2<int> vecA = new(2, 3);
        Vec2<int> vecB = new(4, 5);
        Vec2<int> result = vecA + vecB;
        Assert.That(result, Is.EqualTo(new Vec2<int>(6, 8)));
    }

    [Test]
    public void TestSubtraction() {
        Vec2<int> vecA = new(5, 7);
        Vec2<int> vecB = new(2, 3);
        Vec2<int> result = vecA - vecB;
        Assert.That(result, Is.EqualTo(new Vec2<int>(3, 4)));
    }

    [Test]
    public void TestScalarMultiplication() {
        Vec2<int> vec = new(3, 4);
        int scalar = 2;
        Vec2<int> result = vec * scalar;
        Assert.That(result, Is.EqualTo(new Vec2<int>(6, 8)));
    }

    [Test]
    public void TestScalarDivision() {
        Vec2<int> vec = new(8, 4);
        int scalar = 2;
        Vec2<int> result = vec / scalar;
        Assert.That(result, Is.EqualTo(new Vec2<int>(4, 2)));
    }
    
    [Test]
    public void TestVectorMultiplication() {
        Vec2<int> vecA = new(2, 3);
        Vec2<int> vecB = new(4, 5);
        Vec2<int> result = vecA * vecB;
        Assert.That(result, Is.EqualTo(new Vec2<int>(8, 15)));
    }

    [Test]
    public void TestVectorDivision() {
        Vec2<int> vecA = new(8, 9);
        Vec2<int> vecB = new(2, 3);
        Vec2<int> result = vecA / vecB;
        Assert.That(result, Is.EqualTo(new Vec2<int>(4, 3)));
    }
    
    [Test]
    public void TestEquality() {
        Vec2<int> vecA = new(3, 4);
        Vec2<int> vecB = new(3, 4);
        Vec2<int> vecC = new(5, 6);
        
        Assert.That(vecA, Is.EqualTo(vecB));
        Assert.That(vecA, Is.Not.EqualTo(vecC));
    }
    
    // SWIZZLING

    [Test]
    public void TestSwizzling() {
        Vec2<int> vec = new(7, 9);
        Assert.That(vec.YX, Is.EqualTo(new Vec2<int>(9, 7)));
        Assert.That(vec.XY, Is.EqualTo(vec));
        Assert.That(vec.XX, Is.EqualTo(new Vec2<int>(7)));
        Assert.That(vec.YY, Is.EqualTo(new Vec2<int>(9)));
        
        // Test Vec3 swizzles
        Assert.That(vec.XXX, Is.EqualTo(new Vec3<int>(7, 7, 7)));
        Assert.That(vec.XYY, Is.EqualTo(new Vec3<int>(7, 9, 9)));
        Assert.That(vec.YXY, Is.EqualTo(new Vec3<int>(9, 7, 9)));
    }
}
