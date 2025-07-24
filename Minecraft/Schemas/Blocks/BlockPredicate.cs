using Minecraft.Data;
using Minecraft.Registry;
using NBT;

namespace Minecraft.Schemas.Blocks;

public record BlockPredicate(
    IdSet? Blocks = null, 
    BlockPropertyFilter[]? Properties = null, 
    INbtTag? Nbt = null, 
    ExactDataComponentMatcher[]? Components = null,
    PartialDataComponentMatcher[]? PartialComponents = null) : INetworkType<BlockPredicate> {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WritePrefixedOptional(Blocks, registry)
            .WritePrefixedOptional(Properties, (filters, w) =>
                w.WritePrefixedArray(filters, registry))
            .WritePrefixedOptional(Nbt, (tag, w) => w.WriteNbt(tag))
            .WritePrefixedArray(Components ?? [], (matcher, w) => {
                matcher.Write(w, registry);
            })
            .WritePrefixedArray(PartialComponents ?? [], (matcher, w) => {
                matcher.Write(w);
            });
    }
    
    public static BlockPredicate ReadData(DataReader reader, MinecraftRegistry registry) {
        IdSet? blocks = reader.ReadPrefixedOptional<IdSet>(registry);
        BlockPropertyFilter[]? properties = reader.ReadPrefixedOptional(r => r.ReadPrefixedArray<BlockPropertyFilter>(registry));
        INbtTag? nbt = reader.ReadPrefixedOptional(r => r.ReadNbt());
        ExactDataComponentMatcher[] components = reader.ReadPrefixedArray(r => ExactDataComponentMatcher.Read(r, registry));
        PartialDataComponentMatcher[] partialComponents = reader.ReadPrefixedArray(r => PartialDataComponentMatcher.Read(r, registry));
        return new BlockPredicate(blocks, properties, nbt, components, partialComponents);
    }
}
