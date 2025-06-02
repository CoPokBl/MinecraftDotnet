namespace Minecraft.NBT.Tags;

public class FloatTag(string? name, float val) : ITag {
    
    public byte GetPrefix() {
        return NbtTagPrefix.Float;
    }
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(name).WriteFloat(val).ToArray();
    }
}