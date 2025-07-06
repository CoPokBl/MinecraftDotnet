using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks;

namespace Minecraft.Data.Components.Types;

public record CanPlaceOnComponent(params BlockPredicate[] Value) : IDataComponent<BlockPredicate[]> {
    public static CanPlaceOnComponent Default => new();
    public Identifier Identifier => "minecraft:can_place_on";
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(Value, (predicate, w) => w.Write(wr => predicate.Write(wr, registry)));
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        BlockPredicate[] predicates = reader.ReadPrefixedArray(r => BlockPredicate.Read(r, registry));
        return new CanPlaceOnComponent(predicates);
    }
}
