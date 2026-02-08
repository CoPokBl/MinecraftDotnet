using Minecraft.Schemas;

namespace Minecraft.Testing.Schemas;

public class AtomicCounterTest {

    [Test]
    public void TestSyncCounting() {
        AtomicCounter counter = new(0);
        for (int i = 0; i < 12; i++) {
            counter.Increment();
        }
        Assert.That(counter.Value, Is.EqualTo(12));
    }

    [Test]
    public void TestMaxReset() {
        AtomicCounter counter = new(5, 10);
        for (int i = 0; i < 7; i++) {
            counter.Increment();
        }
        
        Assert.That(counter.Value, Is.EqualTo(6));
    }
    
    [Test]
    public void TestAsyncCounting() {
        AtomicCounter counter = new(0);
        const int increments = 1000;
        const int threads = 10;
        Parallel.For(0, threads, _ => {
            for (int i = 0; i < increments; i++) {
                counter.Increment();
            }
        });
        
        Assert.That(counter.Value, Is.EqualTo(increments * threads));
    }
}
