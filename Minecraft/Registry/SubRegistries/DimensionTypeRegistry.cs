using Minecraft.Data.DimensionType;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class DimensionTypeRegistry : ProtocolTypeRegistry<DimensionTypeRegistry, IDimensionType>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:dimension_type";
    
    public IEnumerable<Identifier> Identifiers => ById.Keys;

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        int cId = 0;
        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                IDimensionType dimensionType = IDimensionType.FromNbt(entry.Key, cId++, compoundTag, reg);
                Add(dimensionType);
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (KeyValuePair<Identifier, IDimensionType> pair in ById) {
            nbtDict.Add(pair.Key.ToString(), pair.Value.ToNbt());
        }
        return nbtDict;
    }
}
