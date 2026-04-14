using Minecraft.Data.DimensionType;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class DimensionTypeRegistry : SequentialRegistry<DimensionTypeRegistry, IDimensionType>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:dimension_type";
    
    public IEnumerable<Identifier> Identifiers => ProtocolIds.Keys;

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                IDimensionType dimensionType = IDimensionType.FromNbt(entry.Key, compoundTag, reg);
                Add(dimensionType);
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (IDimensionType entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
