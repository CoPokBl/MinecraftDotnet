namespace Minecraft.NBT.Tags;

public class DoubleTag(string? name, double val) : ITag {
    
    public byte GetPrefix() {
        return NbtTagPrefix.Double;
    }
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(name).WriteDouble(val).ToArray();
    }
}