namespace Minecraft.Schemas;

public class Or<T1, T2> {
    public T1? Value1 { get; }
    public T2? Value2 { get; }
    
    public Or(T1 value) {
        Value1 = value;
        Value2 = default;
    }
    
    public Or(T2 value) {
        Value1 = default;
        Value2 = value;
    }
    
    public Or(T1? value1, T2? value2) {
        Value1 = value1;
        Value2 = value2;
    }
    
    public static implicit operator Or<T1, T2>(T1 value) {
        return new Or<T1, T2>(value);
    }
    
    public static implicit operator Or<T1, T2>(T2 value) {
        return new Or<T1, T2>(value);
    }
    
    public static Or<T1, T2> FromValue1(T1 value) {
        return new Or<T1, T2>(value);
    }
    
    public static Or<T1, T2> FromValue2(T2 value) {
        return new Or<T1, T2>(value);
    }
    
    public bool IsValue1 => Value1 != null;
    public bool IsValue2 => Value2 != null;
    public T GetValue<T>() {
        if (typeof(T) == typeof(T1) && Value1 != null) {
            return (T)(object)Value1;
        }
        if (typeof(T) == typeof(T2) && Value2 != null) {
            return (T)(object)Value2;
        }
        throw new InvalidOperationException("No value of the requested type is present.");
    }

    public override bool Equals(object? obj) {
        if (obj is Or<T1, T2> other) {
            return Equals(Value1, other.Value1) && Equals(Value2, other.Value2);
        }
        return false;
    }

    protected bool Equals(Or<T1, T2> other) {
        return EqualityComparer<T1?>.Default.Equals(Value1, other.Value1) && EqualityComparer<T2?>.Default.Equals(Value2, other.Value2);
    }
    
    public static bool operator ==(Or<T1, T2>? left, Or<T1, T2>? right) {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }
    
    public static bool operator !=(Or<T1, T2>? left, Or<T1, T2>? right) {
        return !(left == right);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Value1, Value2);
    }
}
