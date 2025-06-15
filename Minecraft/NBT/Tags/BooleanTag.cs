namespace Minecraft.NBT.Tags;

public class BooleanTag(string? name, bool value) : ByteTag(name, (byte)(value ? 0x01 : 0x00)) {
    public string? Name { get; } = name;
    public new bool Value { get; } = value;
}
