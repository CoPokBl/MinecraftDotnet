namespace Minecraft.Schemas;

public class Optional<T>(bool present, T? val) {
    public bool Present { get; } = present;

    public T Value {
        get {
            if (!Present) {
                throw new Exception("Value is not present");
            }

            return val!;
        }
    }

    public Optional(T v) : this(true, v) { }
    
    public Optional() : this(false, default) { }

    public static implicit operator Optional<T>(T val) {
        return new Optional<T>(val);
    }
}