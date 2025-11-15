using Minecraft.Registry;
using NBT;

namespace Minecraft.Schemas.Blocks;

// TODO: Actual implement type and a more structured way to do this
public record PartialDataComponentMatcher(int Type, INbtTag Predicate) {
    
    public void Write(DataWriter writer) {
        writer.WriteVarInt(Type);
        writer.WriteNbt(Predicate);
    }

    public static PartialDataComponentMatcher Read(DataReader reader, MinecraftRegistry registry) {
        int type = reader.ReadVarInt();
        INbtTag predicate = reader.ReadNbt();
        return new PartialDataComponentMatcher(type, predicate);
    }

    public virtual bool Equals(PartialDataComponentMatcher? other) {
        if (other == null) return false;
        if (Type != other.Type) return false;
        if (Predicate.ToJsonString() != other.Predicate.ToJsonString()) return false;
        return true;
    }
    
    public override int GetHashCode() {
        int hash = 17;
        hash = hash * 31 + Type.GetHashCode();
        hash = hash * 31 + Predicate.ToJsonString().GetHashCode();
        return hash;
    }
}
