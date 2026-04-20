using Minecraft.Data.PaintingVariant;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class PaintingVariantRegistry : SequentialRegistry<PaintingVariantRegistry, IPaintingVariant>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:painting_variant";

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                IPaintingVariant variant = IPaintingVariant.FromNbt(entry.Key, compoundTag, reg);
                Add(variant);
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (IPaintingVariant entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
