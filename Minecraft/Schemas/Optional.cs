namespace Minecraft.Schemas;

/// <summary>
/// Class to differentiate between a Nullable fields and an optional nullable field.
/// </summary>
/// <param name="present">Whether the value is present.</param>
/// <param name="val">The value.</param>
/// <typeparam name="T">The underlying type.</typeparam>
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
    
    public Optional(T? v) : this(v != null, v) { }
    
    public Optional() : this(false, default) { }

    public static implicit operator Optional<T>(T? val) {
        return val == null ? new Optional<T>() : new Optional<T>(val);
    }
    
    public static Optional<T> FromNullable(T? val) {
        return new Optional<T>(val != null, val);
    }

    public static readonly Optional<T> Empty = new();
}