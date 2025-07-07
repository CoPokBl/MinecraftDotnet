namespace Minecraft.Schemas;

public class Atomic<T> where T : struct {
    private readonly object _lock = new();
    private T _value;

    public T Value {
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

    public Atomic(T value) {
        Value = value;
    }

    public static implicit operator Atomic<T>(T value) {
        return new Atomic<T>(value);
    }
}
