using Minecraft.Schemas;

namespace Minecraft.Testing.Schemas;

public class OrTest {
    
    [Test]
    public void TestOr() {
        Or<int, bool> or = new(5);
        Assert.That(or.IsValue1, Is.True);
        Assert.That(or.Value1, Is.EqualTo(5));
        Assert.That(or.IsValue2, Is.False);
        
        Or<int, bool> or2 = new(true);
        Assert.That(or2.IsValue1, Is.False);
        Assert.That(or2.IsValue2, Is.True);
        Assert.That(or2.Value2, Is.True);
    }
}
