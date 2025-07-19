using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks;

namespace Minecraft.Data.Components.Types;

public record CanBreakComponent(int ProtocolId) : IDataComponent<BlockPredicate[]> {
    public override Identifier Identifier => "minecraft:can_break";
    
    public override DataWriter WriteData(BlockPredicate[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (predicate, w) => w.Write(wr => predicate.Write(wr, registry)));
    }

    public override BlockPredicate[] ReadData(DataReader reader, MinecraftRegistry registry) {
        BlockPredicate[] predicates = reader.ReadPrefixedArray(r => BlockPredicate.Read(r, registry));
        return predicates;
    }
}
