using Minecraft.Registry;
using NBT;

namespace Minecraft.Schemas.Blocks;

public class BlockPredicate(
    IdSet? Blocks = null, 
    BlockPropertyFilter[]? Properties = null, 
    INbtTag? Nbt = null, 
    ExactDataComponentMatcher[]? Components = null,
    PartialDataComponentMatcher[]? PartialComponents = null) {
    
    public void Write(DataWriter writer, MinecraftRegistry registry) {
        writer
            .WritePrefixedOptional(Blocks, (set, w) => w.Write(set))
            .WritePrefixedOptional(Properties, (filters, w) =>
                w.WritePrefixedArray(filters, (prop, wr) => wr.Write(prop)))
            .WritePrefixedOptional(Nbt, (tag, w) => w.WriteNbt(tag))
            .WritePrefixedArray(Components ?? [], (matcher, w) => {
                matcher.Write(w, registry);
            })
            .WritePrefixedArray(PartialComponents ?? [], (matcher, w) => {
                matcher.Write(w);
            });
    }
    
    public static BlockPredicate Read(DataReader reader, MinecraftRegistry registry) {
        IdSet? blocks = reader.ReadPrefixedOptional(IdSet.Read);
        BlockPropertyFilter[]? properties = reader.ReadPrefixedOptional(r => r.ReadPrefixedArray(BlockPropertyFilter.Read));
        INbtTag? nbt = reader.ReadPrefixedOptional(r => r.ReadNbt());
        ExactDataComponentMatcher[] components = reader.ReadPrefixedArray(r => ExactDataComponentMatcher.Read(r, registry));
        PartialDataComponentMatcher[] partialComponents = reader.ReadPrefixedArray(r => PartialDataComponentMatcher.Read(r, registry));
        return new BlockPredicate(blocks, properties, nbt, components, partialComponents);
    }
}
