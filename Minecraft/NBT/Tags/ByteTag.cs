namespace Minecraft.NBT.Tags;

public class ByteTag(string? name, byte val) : ITag {
    
    public byte GetPrefix() {
        return NbtTagPrefix.Byte;
    }

    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(name).Write(val).ToArray();
    }
}