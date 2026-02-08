using Minecraft.Schemas.Vec.Relative;

namespace Minecraft.Testing.Schemas.Vec.Relative;

public class RelativeCoordinateTest {
    
    [Test]
    public void TestGetValue() {
        int origin = 10;
        RelativeCoordinate<int> absoluteCoord = RelativeCoordinate<int>.Absolute(5);
        RelativeCoordinate<int> relativeCoord = RelativeCoordinate<int>.Relative(3);
        
        Assert.That(absoluteCoord.GetValue(origin), Is.EqualTo(5));
        Assert.That(relativeCoord.GetValue(origin), Is.EqualTo(13));
    }
    
    [Test]
    public void TestParse() {
        RelativeCoordinate<int> a1 = RelativeCoordinate<int>.Parse("15");
        RelativeCoordinate<int> r1 = RelativeCoordinate<int>.Parse("~7");
        RelativeCoordinate<int> a2 = RelativeCoordinate<int>.Parse("-20");
        RelativeCoordinate<int> r2 = RelativeCoordinate<int>.Parse("~-3");
        RelativeCoordinate<int> a3 = RelativeCoordinate<int>.Parse("0");
        RelativeCoordinate<int> r3 = RelativeCoordinate<int>.Parse("~");
        
        Assert.That(a1, Is.EqualTo(RelativeCoordinate<int>.Absolute(15)));
        Assert.That(r1, Is.EqualTo(RelativeCoordinate<int>.Relative(7)));
        Assert.That(a2, Is.EqualTo(RelativeCoordinate<int>.Absolute(-20)));
        Assert.That(r2, Is.EqualTo(RelativeCoordinate<int>.Relative(-3)));
        Assert.That(a3, Is.EqualTo(RelativeCoordinate<int>.Absolute(0)));
        Assert.That(r3, Is.EqualTo(RelativeCoordinate<int>.Relative(0)));
    }

    [Test]
    public void TestToString() {
        RelativeCoordinate<int> absoluteCoord = RelativeCoordinate<int>.Absolute(12);
        RelativeCoordinate<int> relativeCoord = RelativeCoordinate<int>.Relative(4);
        Assert.That(absoluteCoord.ToString(), Is.EqualTo("12"));
        Assert.That(relativeCoord.ToString(), Is.EqualTo("~4"));
    }
}
