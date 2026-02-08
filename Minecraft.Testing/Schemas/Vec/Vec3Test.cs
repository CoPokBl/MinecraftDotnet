using Minecraft.Schemas.Vec;

namespace Minecraft.Testing.Schemas.Vec;

public class Vec3Test {
    
    [Test]
    public void TestIsWithinRadiusOf() {
        Vec3<int> vecA = new(5, 5, 5);
        Vec3<int> vecB = new(7, 7, 7);
        Vec3<int> vecC = new(10, 10, 10);
        
        Assert.That(vecA.IsWithinRadiusOf(vecB, 2), Is.True);
        Assert.That(vecA.IsWithinRadiusOf(vecC, 2), Is.False);
    }
    
    [Test]
    public void TestDistanceTo() {
        Vec3<int> vecA = new(0, 0, 0);
        Vec3<int> vecB = new(3, 4, 12);
        double distance = vecA.DistanceTo(vecB);
        Assert.That(distance, Is.EqualTo(13.0).Within(0.0001));
    }
    
    // BASIC OPS
    
    [Test]
    public void TestAddition() {
        Vec3<int> vecA = new(2, 3, 4);
        Vec3<int> vecB = new(4, 5, 6);
        Vec3<int> result = vecA + vecB;
        Assert.That(result, Is.EqualTo(new Vec3<int>(6, 8, 10)));
    }
    
    [Test]
    public void TestSubtraction() {
        Vec3<int> vecA = new(5, 7, 9);
        Vec3<int> vecB = new(2, 3, 4);
        Vec3<int> result = vecA - vecB;
        Assert.That(result, Is.EqualTo(new Vec3<int>(3, 4, 5)));
    }
    
    [Test]
    public void TestScalarMultiplication() {
        Vec3<int> vec = new(3, 4, 5);
        int scalar = 2;
        Vec3<int> result = vec * scalar;
        Assert.That(result, Is.EqualTo(new Vec3<int>(6, 8, 10)));
    }
    
    [Test]
    public void TestScalarDivision() {
        Vec3<int> vec = new(8, 4, 2);
        int scalar = 2;
        Vec3<int> result = vec / scalar;
        Assert.That(result, Is.EqualTo(new Vec3<int>(4, 2, 1)));
    }
    
    [Test]
    public void TestVectorMultiplication() {
        Vec3<int> vecA = new(2, 3, 4);
        Vec3<int> vecB = new(5, 6, 7);
        Vec3<int> result = vecA * vecB;
        Assert.That(result, Is.EqualTo(new Vec3<int>(10, 18, 28)));
    }
    
    [Test]
    public void TestVectorDivision() {
        Vec3<int> vecA = new(8, 9, 10);
        Vec3<int> vecB = new(2, 3, 5);
        Vec3<int> result = vecA / vecB;
        Assert.That(result, Is.EqualTo(new Vec3<int>(4, 3, 2)));
    }
    
    [Test]
    public void TestEquality() {
        Vec3<int> vecA = new(1, 2, 3);
        Vec3<int> vecB = new(1, 2, 3);
        Vec3<int> vecC = new(4, 5, 6);
        
        Assert.That(vecA, Is.EqualTo(vecB));
        Assert.That(vecA, Is.Not.EqualTo(vecC));
    }
    
    // SWIZZLING
    
    [Test]
    public void TestSwizzling() {
        Vec3<int> vec = new(1, 2, 3);
        
        Vec2<int> xy = vec.XY;
        Vec2<int> yz = vec.YZ;
        Vec2<int> xz = vec.XZ;
        
        Assert.That(xy, Is.EqualTo(new Vec2<int>(1, 2)));
        Assert.That(yz, Is.EqualTo(new Vec2<int>(2, 3)));
        Assert.That(xz, Is.EqualTo(new Vec2<int>(1, 3)));
        
        Vec3<int> xyz = vec.XYZ;
        Vec3<int> zyx = vec.ZYX;
        Vec3<int> zyy = vec.ZYY;
        Vec3<int> zzz = vec.ZZZ;
        Assert.That(xyz, Is.EqualTo(vec));
        Assert.That(zyx, Is.EqualTo(new Vec3<int>(3, 2, 1)));
        Assert.That(zyy, Is.EqualTo(new Vec3<int>(3, 2, 2)));
        Assert.That(zzz, Is.EqualTo(new Vec3<int>(3, 3, 3)));
    }
}
