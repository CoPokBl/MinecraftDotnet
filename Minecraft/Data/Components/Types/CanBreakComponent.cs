using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks;

namespace Minecraft.Data.Components.Types;

public record CanBreakComponent(int ProtocolId) : IDataComponent<BlockPredicate[]> {
    public override Identifier Identifier => "minecraft:can_break";
    
    public override DataWriter WriteData(BlockPredicate[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (predicate, w) => w.Write(predicate, registry));
    }

    public override BlockPredicate[] ReadData(DataReader reader, MinecraftRegistry registry) {
        BlockPredicate[] predicates = reader.ReadPrefixedArray<BlockPredicate>(registry);
        return predicates;
    }

    public override bool ValuesEqual(BlockPredicate[] val1, BlockPredicate[] val2) {
        if (val1.Length != val2.Length) {
            return false;
        }

        for (int i = 0; i < val1.Length; i++) {
            if (!val1[i].Equals(val2[i])) {
                return false;
            }
        }

        return true;
    }
}
