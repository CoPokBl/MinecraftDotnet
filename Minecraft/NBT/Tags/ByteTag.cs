namespace Minecraft.NBT.Tags;

public class ByteTag(string? name, byte value) : ITag {
    public string? Name { get; } = name;
    public byte Value { get; } = value;

    public bool BoolValue => Value != 0x00;

    public byte GetPrefix() {
        return NbtTagPrefix.Byte;
    }

    public string? GetName() {
        return Name;
    }

    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).Write(Value).ToArray();
    }
}