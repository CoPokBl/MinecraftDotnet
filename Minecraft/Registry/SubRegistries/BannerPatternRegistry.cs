using Minecraft.Data.BannerPattern;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class BannerPatternRegistry : SequentialRegistry<BannerPatternRegistry, IBannerPattern>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:banner_pattern";

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                Add(IBannerPattern.FromNbt(entry.Key, compoundTag, reg));
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (IBannerPattern entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
