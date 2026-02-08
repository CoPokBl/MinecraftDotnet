namespace Minecraft.Schemas;

public class Or<T1, T2> {
    public T1? Value1 { get; }
    public T2? Value2 { get; }
    
    private bool _isValue1;  // true if Value1 is set, false if Value2 is set
    
    public Or(T1 value) {
        Value1 = value;
        Value2 = default;
        _isValue1 = true;
    }
    
    public Or(T2 value) {
        Value1 = default;
        Value2 = value;
        _isValue1 = false;
    }
    
    public Or(T1? value1, T2? value2) {
        Value1 = value1;
        Value2 = value2;

        if (value1 == null && value2 == null) {
            throw new ArgumentException("At least one value must be non-null.");
        }

        if (value1 != null && value2 != null) {
            throw new ArgumentException("Only one value can be non-null.");
        }
        
        _isValue1 = value1 != null;
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
    
    public bool IsValue1 => _isValue1;
    public bool IsValue2 => !_isValue1;
    public T GetValue<T>() {
        if (typeof(T) == typeof(T1) && _isValue1) {
            return (T)(object)Value1!;
        }
        if (typeof(T) == typeof(T2) && !_isValue1) {
            return (T)(object)Value2!;
        }
        throw new InvalidOperationException("No value of the requested type is present.");
    }

    public override bool Equals(object? obj) {
        if (obj is Or<T1, T2> other) {
            return Equals(other);
        }
        return false;
    }

    public bool Equals(Or<T1, T2> other) {
        if (IsValue1 && other.IsValue1) {
            return EqualityComparer<T1>.Default.Equals(Value1!, other.Value1!);
        }
        if (IsValue2 && other.IsValue2) {
            return EqualityComparer<T2>.Default.Equals(Value2!, other.Value2!);
        }
        return false; // One is Value1 and the other is Value2, so they are not equal
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
        return IsValue1 ? HashCode.Combine(Value1) : HashCode.Combine(Value2);
    }
}
