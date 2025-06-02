namespace Minecraft.NBT.Tags;

public class IntegerTag(string? name, int val) : ITag {
    
    public byte GetPrefix() {
        return NbtTagPrefix.Integer;
    }
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(name).WriteInteger(val).ToArray();
    }
}