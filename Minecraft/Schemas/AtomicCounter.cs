namespace Minecraft.Schemas;

public class AtomicCounter(int start, int max = int.MaxValue) {
    private readonly object _lock = new();
    private int _value = start;

    public void Increment() {
        lock (_lock) {
            if (_value >= max) {
                Value = start;
            } else _value++;
        }
    }

    public int Next() {
        Increment();
        return Value;
    }
    
    public int Value {
        get {
            lock (_lock) {
                return _value;
            }
        }
        set {
            lock (_lock) {
                _value = value;
            }
        }
    }
}