namespace NBT.Tags;

public class ByteTag(string? name, sbyte value) : INbtTag<ByteTag> {
    public string? Name { get; } = name;
    public sbyte Value { get; } = value;

    public bool BoolValue => Value != 0x00;

    public byte GetPrefix() {
        return NbtTagPrefix.Byte;
    }

    public string? GetName() {
        return Name;
    }

    ByteTag INbtTag<ByteTag>.WithName(string? name) {
        return new ByteTag(name, Value);
    }

    public INbtTag WithName(string? name) => ((INbtTag<ByteTag>)this).WithName(name);

    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteByte(Value).ToArray();
    }
}
