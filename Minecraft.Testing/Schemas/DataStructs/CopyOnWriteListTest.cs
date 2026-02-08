using Minecraft.Schemas.DataStructs;

namespace Minecraft.Testing.Schemas.DataStructs;

public class CopyOnWriteListTest {
    
    [Test]
    public void TestCopyOnWriteList() {
        CopyOnWriteList<int> list = [1, 2, 3];

        // Test enumeration
        Assert.That(list.ToArray(), Is.EqualTo([1, 2, 3]));
        
        // Test copy on write behaviour
        IEnumerator<int> enumerator = list.GetEnumerator();
        list.Add(4);
        List<int> enumeratedItems = [];
        while (enumerator.MoveNext()) {
            enumeratedItems.Add(enumerator.Current);
        }
        enumerator.Dispose();
        Assert.That(enumeratedItems, Is.EqualTo([1, 2, 3]));
        Assert.That(list.ToArray(), Is.EqualTo([1, 2, 3, 4]));
    }
}
