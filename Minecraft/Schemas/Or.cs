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
}
