namespace Minecraft.NBT.Tags;

public class StringTag(string? name, string val) : ITag {

    public byte GetPrefix() {
        return NbtTagPrefix.String;
    }
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(NbtTagPrefix.String, noType).WriteName(name).WriteString(val).ToArray();
    }
}
