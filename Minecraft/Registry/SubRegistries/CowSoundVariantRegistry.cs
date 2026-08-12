using Minecraft.Data.CowSoundVariant;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class CowSoundVariantRegistry : SequentialRegistry<CowSoundVariantRegistry, ICowSoundVariant>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:cow_sound_variant";

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                Add(ICowSoundVariant.FromNbt(entry.Key, compoundTag, reg));
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (ICowSoundVariant entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
