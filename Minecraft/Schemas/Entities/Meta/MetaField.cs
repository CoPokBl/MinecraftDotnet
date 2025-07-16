namespace Minecraft.Schemas.Entities.Meta;

public class MetaField<T>(MetaFieldType type, T value) : MetaField(type, value!) {
    public new T Value { get; } = value;

    public override string ToString() {
        return $"MetaField(Type: {Type}, Value: {Value})";
    }
}

public class MetaField(MetaFieldType type, object value) {
    public MetaFieldType Type { get; } = type;
    public object Value { get; } = value;
    
    public T GetValue<T>() => (T)Value;

    public override string ToString() {
        return $"MetaField(Type: {Type}, Value: {Value})";
    }
}
