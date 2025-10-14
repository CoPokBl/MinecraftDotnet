namespace NBT.Tags;

/// <summary>
/// Represents an array of values of a specific type in NBT format.
/// The type must be one of the supported types: int, long, or sbyte.
/// </summary>
/// <typeparam name="T">One of: int, long, or sbyte.</typeparam>
public class ArrayTag<T> : INbtTag<ArrayTag<T>> {
    // ReSharper disable once StaticMemberInGenericType
    private static readonly Type[] SupportedTypes = [
        typeof(int), typeof(long), typeof(sbyte)
    ];
    
    public ArrayTag(string? name, params T[] values) {
        if (!SupportedTypes.Contains(typeof(T))) {
            throw new ArgumentException("Unsupported type for ArrayTag: " + typeof(T).Name);
        }
        Name = name;
        Values = values;
    }

    public string? Name { get; }
    public T[] Values { get; }

    public byte GetPrefix() {
        return typeof(T) switch {
            { } t when t == typeof(int) => NbtTagPrefix.Integers,
            { } t when t == typeof(long) => NbtTagPrefix.Longs,
            { } t when t == typeof(sbyte) => NbtTagPrefix.Bytes,
            _ => throw new ArgumentException("Unsupported type for ArrayTag: " + typeof(T).Name)
        };
    }
    
    public string? GetName() {
        return Name;
    }
    
    ArrayTag<T> INbtTag<ArrayTag<T>>.WithName(string? name) {
        return new ArrayTag<T>(name, Values);
    }

    public INbtTag WithName(string? name) => ((INbtTag<ArrayTag<T>>)this).WithName(name);
    
    public byte[] Serialise(bool noType = false) {
        NbtBuilder b = new NbtBuilder()
            .WriteType(GetPrefix(), noType)
            .WriteName(Name)
            .WriteInteger(Values.Length);
        foreach (T v in Values) {
            switch (v) {
                case int iv:
                    b.WriteInteger(iv);
                    break;
                case long lv:
                    b.WriteLong(lv);
                    break;
                case sbyte bv:
                    b.WriteByte(bv);
                    break;
                default:
                    throw new ArgumentException("Unsupported type in ArrayTag: " + v!.GetType().Name);
            }
        }
        return b.ToArray();
    }
}
