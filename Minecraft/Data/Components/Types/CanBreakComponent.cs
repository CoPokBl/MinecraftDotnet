using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks;

namespace Minecraft.Data.Components.Types;

public record CanBreakComponent(params BlockPredicate[] Value) : IDataComponent<BlockPredicate[]> {
    public Identifier Identifier => "minecraft:can_break";
    public static CanBreakComponent Default => new();
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(Value, (predicate, w) => w.Write(wr => predicate.Write(wr, registry)));
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        BlockPredicate[] predicates = reader.ReadPrefixedArray(r => BlockPredicate.Read(r, registry));
        return new CanPlaceOnComponent(predicates);
    }
}
