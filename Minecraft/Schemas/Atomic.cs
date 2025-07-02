namespace Minecraft.Schemas;

public class Atomic<T> where T : struct {
    public T Value { get; set; }

    public Atomic(T value) {
        Value = value;
    }
}
