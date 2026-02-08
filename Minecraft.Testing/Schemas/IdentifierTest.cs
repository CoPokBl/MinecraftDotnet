using Minecraft.Schemas;

namespace Minecraft.Testing.Schemas;

public class IdentifierTest {
    
    [Test]
    public void FullyQualifiedParseTest() {
        Identifier id = Identifier.Parse("customnamespace:customkey");
        Assert.That(id.Namespace, Is.EqualTo("customnamespace"));
        Assert.That(id.Key, Is.EqualTo("customkey"));
        Assert.That(id.ToString(), Is.EqualTo("customnamespace:customkey"));
    }
    
    [Test]
    public void DefaultNamespaceParseTest() {
        Identifier id = Identifier.Parse("defaultkey");
        Assert.That(id.Namespace, Is.EqualTo("minecraft"));
        Assert.That(id.Key, Is.EqualTo("defaultkey"));
        Assert.That(id.ToString(), Is.EqualTo("minecraft:defaultkey"));
    }
}
