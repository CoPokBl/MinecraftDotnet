using Minecraft.Schemas;

namespace Minecraft.Testing.Schemas;

public class QuanternionTest {
    
    [Test]
    public void AddTest() {
        Quaternion q1 = new(1, 2, 3, 4);
        Quaternion q2 = new(5, 6, 7, 8);
        
        Quaternion result = q1 + q2;
        
        Assert.That(result.X, Is.EqualTo(6));
        Assert.That(result.Y, Is.EqualTo(8));
        Assert.That(result.Z, Is.EqualTo(10));
        Assert.That(result.W, Is.EqualTo(12));
    }

    [Test]
    public void SubtractTest() {
        Quaternion q1 = new(5, 6, 7, 8);
        Quaternion q2 = new(1, 2, 3, 4);
        
        Quaternion result = q1 - q2;
        
        Assert.That(result.X, Is.EqualTo(4));
        Assert.That(result.Y, Is.EqualTo(4));
        Assert.That(result.Z, Is.EqualTo(4));
        Assert.That(result.W, Is.EqualTo(4));
    }

    [Test]
    public void MultiplyTest() {
        Quaternion q1 = new(1, 2, 3, 4);
        Quaternion q2 = new(5, 6, 7, 8);
        
        Quaternion result = q1 * q2;
        
        Assert.That(result.X, Is.EqualTo(24));
        Assert.That(result.Y, Is.EqualTo(48));
        Assert.That(result.Z, Is.EqualTo(48));
        Assert.That(result.W, Is.EqualTo(-6));
    }

    [Test]
    public void DivideTest() {
        Quaternion q = new(2, 4, 6, 8);
        float scalar = 2;
        
        Quaternion result = q / scalar;
        
        Assert.That(result.X, Is.EqualTo(1));
        Assert.That(result.Y, Is.EqualTo(2));
        Assert.That(result.Z, Is.EqualTo(3));
        Assert.That(result.W, Is.EqualTo(4));
    }
    
    [Test]
    public void ToAngleTest() {
        Quaternion q = new(0, 0, (float)Math.Sin(Math.PI / 4), (float)Math.Cos(Math.PI / 4));
        Angle angle = q.ToAngle();
        
        Assert.That(angle.Radians, Is.EqualTo(Math.PI / 2).Within(0.0001));
    }
}
