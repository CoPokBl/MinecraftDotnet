namespace Minecraft.Schemas;

/// <summary>
/// A Thread safe reference to a value type.
/// Just get and set the Value property without
/// worrying about thread safety.
/// </summary>
/// <typeparam name="T">The type to encapsulate.</typeparam>
public class ThreadSafeRef<T> where T : struct {
    private readonly object _lock = new();

    public T Value {
        get {
            lock (_lock) {
                return field;
            }
        }
        set {
            lock (_lock) {
                field = value;
            }
        }
    }

    public ThreadSafeRef(T value) {
        Value = value;
    }

    public static implicit operator ThreadSafeRef<T>(T value) {
        return new ThreadSafeRef<T>(value);
    }
}
