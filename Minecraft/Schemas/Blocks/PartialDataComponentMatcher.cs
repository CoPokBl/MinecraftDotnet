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
}
