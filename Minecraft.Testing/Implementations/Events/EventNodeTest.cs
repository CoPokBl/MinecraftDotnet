using Minecraft.Implementations.Events;

namespace Minecraft.Testing.Implementations.Events;

public class EventNodeTest {

    [Test]
    public void CancelListenerTest() {
        EventNode<int> node = new();
        bool set = false;
        Action cancel = node.AddListener<int>(e => {
            set = true;
        });
        
        node.CallEvent(1);
        Assert.That(set, Is.True);

        set = false;
        cancel();
        node.CallEvent(1);
        
        Assert.That(set, Is.False);
        
        set = false;
        node.OnFirstWhere<int>(i => i==2, _ => {
            set = true;
        });
        Assert.That(set, Is.False);
        node.CallEvent(1);
        Assert.That(set, Is.False);
        node.CallEvent(2);
        Assert.That(set, Is.True);
    }
}