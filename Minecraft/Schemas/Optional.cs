namespace Minecraft.Schemas;

/// <summary>
/// Class to differentiate between a Nullable fields and an optional nullable field.
/// </summary>
/// <param name="present">Whether the value is present.</param>
/// <param name="val">The value.</param>
/// <typeparam name="T">The underlying type.</typeparam>
public class Optional<T>(bool present, T? val) : IEquatable<Optional<T>> {
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
    
    public bool Equals(Optional<T>? other) {
        if (other == null) return false;
        if (Present != other.Present) return false;
        if (!Present) return true; // Both are not present, so they are equal
        return EqualityComparer<T>.Default.Equals(Value, other.Value);
    }
    
    public override bool Equals(object? obj) {
        return obj is Optional<T> other && Equals(other);
    }
    
    public override int GetHashCode() {
        return HashCode.Combine(Present, Present ? Value : default);
    }
}