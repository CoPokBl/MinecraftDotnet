namespace NBT.Tags;

public class BooleanTag(string? name, bool value) : ByteTag(name, (sbyte)(value ? 0x01 : 0x00)) {
    public new bool Value { get; } = value;
}
