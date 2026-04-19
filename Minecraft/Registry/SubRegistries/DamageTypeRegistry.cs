using Minecraft.Data.DamageType;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class DamageTypeRegistry : SequentialRegistry<DamageTypeRegistry, IDamageType>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:damage_type";

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                IDamageType damageType = IDamageType.FromNbt(entry.Key, compoundTag, reg);
                Add(damageType);
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (IDamageType entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
