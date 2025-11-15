using Minecraft.Data;
using Minecraft.Registry;
using Minecraft.Schemas.Tags;
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

    public virtual bool Equals(BlockPredicate? other) {
        if (other == null) return false;
        if (Blocks != other.Blocks) return false;
        if ((Properties == null) != (other.Properties == null)) return false;
        if ((Properties != null && other.Properties != null) && !Properties.SequenceEqual(other.Properties)) return false;
        if ((Nbt == null) != (other.Nbt == null)) return false;
        if (Nbt != null && other.Nbt != null && Nbt.ToJsonString() != other.Nbt.ToJsonString()) return false;
        if (Components == null != (other.Components == null)) return false;
        if (Components != null && other.Components != null && !Components.SequenceEqual(other.Components)) return false;
        if (PartialComponents == null != (other.PartialComponents == null)) return false;
        if (PartialComponents != null && other.PartialComponents != null && !PartialComponents.SequenceEqual(other.PartialComponents)) return false;
        return true;
    }

    public override int GetHashCode() {
        int hash = 17;
        hash = hash * 31 + (Blocks?.GetHashCode() ?? 0);
        if (Properties != null) {
            foreach (BlockPropertyFilter prop in Properties) {
                hash = hash * 31 + prop.GetHashCode();
            }
        }
        hash = hash * 31 + (Nbt?.ToJsonString().GetHashCode() ?? 0);
        if (Components != null) {
            foreach (ExactDataComponentMatcher comp in Components) {
                hash = hash * 31 + comp.GetHashCode();
            }
        }
        if (PartialComponents != null) {
            foreach (PartialDataComponentMatcher pcomp in PartialComponents) {
                hash = hash * 31 + pcomp.GetHashCode();
            }
        }
        return hash;
    }
}
